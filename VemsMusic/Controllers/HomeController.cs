using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VemsMusic.Interfaces;
using VemsMusic.Models;
using VemsMusic.Models.ViewModels;

namespace VemsMusic.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllGenre _allGenre;
        private readonly IAllGroups _allGroups;

        public HomeController(IAllGenre allGenre, IAllGroups allGroups)
        {
            _allGenre = allGenre;
            _allGroups = allGroups;
        }

        [Route("~/")]
        public IActionResult Index()
        {
            IEnumerable<Genre> genres = _allGenre.GetAllGenres;
            var genreObj = new GenreViewModel
            {
                AllGenres = genres
            };
            return View(genreObj);
        }

        [Route("~/Home/Category")]
        [HttpPost]
        public IActionResult InGenre(string genre)
        {
            IEnumerable<MusicalGroup> musicalGroups = _allGroups.GetMusicalGroups.Where(g => g.GenreName == genre);
            var groupObj = new GroupsViewModel
            {
                AllGroups = musicalGroups
            };
            return View(groupObj);
        }
    }
}
