using Microsoft.AspNetCore.Authorization;
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
    public class DBRedactionController : Controller
    {
        private readonly IAllGenre _allGenre;
        private readonly IAllGroups _allGroups;
        private readonly IAllMusic _allMusic;

        public DBRedactionController(IAllGenre allGenre, IAllGroups allGroups, IAllMusic allMusic)
        {
            _allGenre = allGenre;
            _allGroups = allGroups;
            _allMusic = allMusic;
        }

        [Route("~/DBRedaction/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("~/DBRedaction/AllGenre")]
        public IActionResult AllGenre()
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
        [Route("~/DBRedaction/AllGroup")]
        public IActionResult AllGroup()
        {
            IEnumerable<MusicalGroup> musicalGroups = _allGroups.GetMusicalGroups;

            if (!musicalGroups.Any())
            {
                return Redirect("~/Home/NoItems/Группы не добавлены");
            }

            var groupObj = new AllGroupAndAllGenreViewModel
            {
                AllGroups = musicalGroups,
                AllGenres = _allGenre.GetAllGenres
            };

            return View(groupObj);
        }
        [Route("~/DBRedaction/AllMusic")]
        public IActionResult AllMusic()
        {
            IEnumerable<Music> musics = _allMusic.GetAllMusic;

            if (!musics.Any())
            {
                return Redirect("~/Home/NoItems/Музыка не добавлена");
            }

            var musicsObj = new AllMusicAndAllGroupAndAllGenreViewModel
            {
                AllMusic = musics,
                AllGenre = _allGenre.GetAllGenres,
                AllGroup = _allGroups.GetMusicalGroups
            };

            return View(musicsObj);
        }


        [Route("~/DBRedaction/AddGenre")]
        [HttpPost]
        public RedirectResult AddGenre(Genre genre)
        {
            _allGenre.AddGenre(genre);

            return Redirect("~/DBRedaction/AllGenre");
        }
        [Route("~/DBRedaction/AddGroup")]
        [HttpPost]
        public RedirectResult AddGroup(MusicalGroup group)
        {
            _allGroups.AddGroup(group);

            return Redirect("~/DBRedaction/AllGroup");
        }
        [Route("~/DBRedaction/AddMusic")]
        [HttpPost]
        public RedirectResult AddMusic(Music music)
        {
            _allMusic.AddMusic(music);

            return Redirect("~/DBRedaction/AllMusic");
        }


        [Route("~/DBRedaction/DeleteGenre/{id}")]
        public RedirectResult DeleteGenre(int id)
        {
            _allGenre.DeleteGenre(id);

            return Redirect("~/DBRedaction/AllGenre");
        }
        [Route("~/DBRedaction/DeleteGroup/{id}")]
        public RedirectResult DeleteGroup(int id)
        {
            _allGroups.DeleteGroup(id);

            return Redirect("~/DBRedaction/AllGroup");
        }
        [Route("~/DBRedaction/DeleteMusic/{id}")]
        public RedirectResult DeleteMusic(int id)
        {
            _allMusic.DeleteMusic(id);

            return Redirect("~/DBRedaction/AllMusic");
        }


        [Route("~/DBRedaction/RedactGenres")]
        [HttpPost]
        public RedirectResult RedactGenres(Genre genre)
        {
            _allGenre.UpdateGenre(genre);

            return Redirect("~/DBRedaction/AllGenre");
        }
        [Route("~/DBRedaction/RedactGroups")]
        [HttpPost]
        public RedirectResult RedactGroups(MusicalGroup musicalGroup)
        {
            _allGroups.UpdateGroup(musicalGroup);

            return Redirect("~/DBRedaction/AllGroup");
        }
        [Route("~/DBRedaction/RedactMusics")]
        [HttpPost]
        public RedirectResult RedactMusics(Music music)
        {
            _allMusic.UpdateMusic(music);

            return Redirect("~/DBRedaction/AllMusic");
        }
    }
}
