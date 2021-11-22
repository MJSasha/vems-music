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
            if (!genres.Any())
            {
                return Redirect("~/Home/NoItems/Жанры не добавлены");
            }
            var genreObj = new GenreViewModel
            {
                AllGenres = genres
            };
            return View(genreObj);
        }

        [Route("~/Home/Category/{id}")]
        public IActionResult InGenre(int id)
        {
            IEnumerable<MusicalGroup> musicalGroups = _allGroups.GetMusicalGroups.Where(g => g.GenreId == id);
            if (!musicalGroups.Any())
            {
                return Redirect("~/Home/NoItems/Группы не добавлены");
            }
            var groupObj = new GroupsViewModel
            {
                AllGroups = musicalGroups
            };
            return View(groupObj);
        }

        [Route("~/Home/NoItems/{message}")]
        public ViewResult NoItems(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}
