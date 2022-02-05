using DDAC_MVC_.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DDAC_MVC.S3Manager;

namespace DDAC_MVC_.Controllers
{
    public class MusicListController : Controller
    {
        public async Task<IActionResult> Index() //
        {
            IEnumerable<Music> music = null;

            HttpResponseMessage response = await GlobalVariables.WebApiClient.GetAsync("music");

            if (response.IsSuccessStatusCode)
            {
                music = response.Content.ReadAsAsync<IEnumerable<Music>>().Result;
                DataTable table = new DataTable();
                table.Columns.Add("musicid");
                table.Columns.Add("img");
                table.Columns.Add("title");
                table.Columns.Add("artist");
                table.Columns.Add("genre");
                table.Columns.Add("description");
                table.Columns.Add("button");
                
                foreach (var item in music)
                {
                    var url = "https://elasticbeanstalk-us-east-1-788946909279.s3.amazonaws.com/images/" + item.title + " - " + item.artist+".jpg";
                     url = url.Replace(" ", "+");
                    var row = table.NewRow();
                    row["musicid"] = item.musicid;
                    row["img"] = url;
                    row["title"] = item.title;
                    row["artist"] = item.artist;
                    row["genre"] = item.genre;
                    row["description"] = item.description;
                    row["button"] = @"
                         <div>
                        <button id = '" + item.musicid + "' class=\"remove action btn-danger\" style=\"width:120px;border-radius:5px;\"><i class=\"bi bi-x-lg\"></i>Remove</button>" +
                        "</div>";
                    table.Rows.Add(row);
                }

                return View(table);



            }
            else
            {
                TempData["error"] = "Error - Unable to load Articles";
                return BadRequest();
            }

        }
        
        public async Task<IActionResult> Create() //
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Music music) //
        {
            var image = Request.Form.Files.GetFile("image");
            var song = Request.Form.Files.GetFile("song");
            const long MaxLength = 10485760;
            HttpResponseMessage response = await GlobalVariables.WebApiClient.PostAsJsonAsync("music", music);
            if (response.IsSuccessStatusCode)
            {
                S3Manager s3uploader = new S3Manager();
                s3uploader.Main();
                if(image!= null)
                {
                    await s3uploader.WritingAnObjectAsync(image, music.title + " - " + music.artist + ".jpg", "images");
                }
                if (song != null)
                {
                    await s3uploader.WritingAnObjectAsync(song, music.title + " - " + music.artist, "musics");
                }
               

                return RedirectToAction("Index", "MusicList");
            }
            else
            {
                return RedirectToAction("Index", "MusicList");
            }
               
        }
               /*
            [HttpPost]
            public async Task<IActionResult> Edit(int id, String title, String artist, String genre, String description)
            {
                var music = new Music();
                music.title = title;
                music.artist = artist;
                music.genre = genre;
                music.description = description;
                HttpResponseMessage response = await GlobalVariables.WebApiClient.PutAsJsonAsync("music/" + id,music);
                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Success - Music Updated!";
                    return Ok();
                }
                else
                {
                    TempData["error"] = "Error - Unable to update music";
                    return BadRequest();
                }
            }*/



            public async Task<Music> GetMusic(int id) //
        {

            HttpResponseMessage response = await GlobalVariables.WebApiClient.GetAsync("music/" + id);
            var music = response.Content.ReadAsStringAsync().Result;
            Music item = JsonConvert.DeserializeObject<Music>(music);

            return item;
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Music music = await GetMusic(id);
            
            
            HttpResponseMessage response = await GlobalVariables.WebApiClient.DeleteAsync("music/"+id);

                if (response.IsSuccessStatusCode)
                {
                S3Manager s3uploader = new S3Manager();
                s3uploader.Main();
                await s3uploader.DeleteObjectNonVersionedBucketAsync(music.title + "-" + music.artist);
                TempData["success"] = "Music Deleted";
                    return Ok();
                }
                else
                {
                    TempData["error"] = "Error - Unable to delete music";
                    return BadRequest();
                }
        }


    }
        

}
