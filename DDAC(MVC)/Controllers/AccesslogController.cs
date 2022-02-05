using DDAC_MVC_.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DDAC_MVC_.Controllers
{
    public class AccesslogController : Controller
    {
        public async Task<IActionResult> Index()
        { 
            IEnumerable <UserLog> log = null;

            HttpResponseMessage response = await GlobalVariables.WebApiClient.GetAsync("useraccesslog");

            if (response.IsSuccessStatusCode)
            {
                log = response.Content.ReadAsAsync<IEnumerable<UserLog>>().Result;
                return View(log);

            }
            else
            {
                TempData["error"] = "Error - Unable to load Articles";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
