using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace VemsMusic.Controllers
{
    public class HomeController : Controller
    {
        [Route("~/")]
        public IActionResult Index()
        {
            //Список жанров
            return View();
        }

        [Route("~/Home/Category")]
        public IActionResult Category(string categoty)
        {
            //Артисты
            //name
            //description
            //img path
            return View();
        }
    }
}
