using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VemsMusic.Interfaces;
using VemsMusic.Models;

namespace VemsMusic.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllGenre _allGenre;

        public HomeController(IAllGenre allGenre)
        {
            _allGenre = allGenre;
        }

        [Route("~/")]
        public IActionResult Index()
        {
            IEnumerable<Genre> genres = _allGenre.GetAllGenres;
            return View(genres);
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
