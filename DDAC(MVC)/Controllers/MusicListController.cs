using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_MVC_.Controllers
{
    public class MusicListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



    }
}
