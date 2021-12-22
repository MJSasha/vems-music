using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            IEnumerable<Genre> genres = await _allGenre.GetAllGenresAsync();

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

        [Route("~/Home/NewMusic")]
        public async Task<IActionResult> NewMusic()
        {
            var newMusic = await _allMusic.GetAllMusicAsync();

            if (!newMusic.Any())
            {
                return Redirect("~/Home/NoItems/Музыка не добавлена");
            }

            //TORelease Three is for the test, then change
            //To display the complete list, delete Take
            newMusic = newMusic.OrderByDescending(m => m.AdditionDateAndTime).Take(3);//ToList();

            var musicObj = new MusicViewModel
            {
                AllMusic = newMusic
            };

            ViewBag.Id = HttpContext.Request.Cookies["id"];
            return View(musicObj);
        }

        [Route("~/Home/Category/{id}")]
        public async Task<IActionResult> InGenre(int id)
        {
            Genre genre = await _allGenre.GetGenreByIdAsync(id);
            IEnumerable<MusicalGroup> musicalGroups = (await _allGroups.GetMusicalGroupsAsync()).
                Where(g => g.Genres.Contains(genre));

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
        public async Task<ViewResult> Executors()
        {
            var groupsObj = new GroupsViewModel
            {
                AllGroups = await _allGroups.GetMusicalGroupsAsync()
            };

            return View(groupsObj);
        }

        [Route("~/Home/AllMusic")]
        public async Task<ViewResult> AllMusic()
        {
            var musicsObj = new MusicViewModel
            {
                AllMusic = await _allMusic.GetAllMusicAsync()
            };

            ViewBag.Id = HttpContext.Request.Cookies["id"];
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
