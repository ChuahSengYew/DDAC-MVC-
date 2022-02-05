using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DDAC_MVC_.Controllers
{
    public class Logout : Controller
    {
        public async Task<IActionResult> Index()
           
        {

           var id = TempData["sessionid"];
           
            var data = new StringContent(JsonConvert.SerializeObject(id));
            HttpResponseMessage response = await GlobalVariables.WebApiClient.GetAsync("useraccesslog/logout/"+id);
            if(response.IsSuccessStatusCode)
            {
                TempData.Clear();
                return View();
            }
            else
            {
                return BadRequest();
            }
            
            
        }
    }
}
