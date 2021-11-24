using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VemsMusic.Interfaces;
using VemsMusic.Models;
using VemsMusic.Models.ViewModels;
using VemsMusic.Other_Data.Interfaces;
using VemsMusic.Other_Data.ViewModels;

namespace VemsMusic.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllGenre _allGenre;
        private readonly IAllGroups _allGroups;
        private readonly IAllMusic _allMusic;

        public HomeController(IAllGenre allGenre, IAllGroups allGroups, IAllMusic allMusic)
        {
            _allGenre = allGenre;
            _allGroups = allGroups;
            _allMusic = allMusic;
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
            Genre genre = _allGenre.GetGenreById(id);

            if (!musicalGroups.Any())
            {
                return Redirect("~/Home/NoItems/Группы не добавлены");
            }

            var groupObj = new GroupsViewModel
            {
                AllGroups = musicalGroups
            };

            ViewBag.Genre = genre.Name;
            return View(groupObj);
        }

        [Route("~/Home/Executors")]
        public ViewResult Executors()
        {
            var groupsObj = new GroupsViewModel
            {
                AllGroups = _allGroups.GetMusicalGroups
            };

            return View(groupsObj);
        }

        [Route("~/Home/AllMusic")]
        public ViewResult AllMusic()
        {
            var musicsObj = new MusicViewModel
            {
                AllMusic = _allMusic.GetAllMusic
            };

            return View(musicsObj);
        }

        [Route("~/Home/NoItems/{message}")]
        public ViewResult NoItems(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}
