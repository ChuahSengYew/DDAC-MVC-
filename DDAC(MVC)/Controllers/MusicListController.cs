using DDAC_MVC_.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

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
                Console.WriteLine(music);
                return View(music);
                
                

            }
            else
            {
                TempData["error"] = "Error - Unable to load Articles";
                return RedirectToAction("Index", "Home");
            }

        }


    }
}
