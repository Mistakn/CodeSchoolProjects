using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMovies.Controllers {
    public class HelloWorldController : Controller {
        public string Index() {
            return "Heroh Warudo";
            //return View();
            //return View("/Views/HelloWorld/Index.cshtml");
        }

        public string Werucom(string name, int numTimes = 1) {
            return $"Werucomu tu eM Vi Ci {name}, uwu {numTimes}";
        }

        public IActionResult Werucomu(string name, int id = 1) {
            //return $"Werucomu tu eM Vi Ci {name}, uwu {id}";

            ViewData["Name"] = name;
            ViewData["id"] = id;

            return View();
        }
    }
}
