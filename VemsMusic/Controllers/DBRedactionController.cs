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

            var groupObj = new GroupsViewModel
            {
                AllGroups = musicalGroups
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

            var musicsObj = new MusicViewModel
            {
                AllMusic = musics
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


        [Route("~/DBRedaction/DeleteGenre")]
        [HttpPost]
        public RedirectResult DeleteGenre(Genre genre)
        {
            _allGenre.DeleteGenre(genre);

            return Redirect("~/DBRedaction/AddGenre");
        }
        [Route("~/DBRedaction/DeleteGroup")]
        [HttpPost]
        public RedirectResult DeleteGroup(MusicalGroup group)
        {
            _allGroups.DeleteGroup(group);

            return Redirect("~/DBRedaction/AddGroup");
        }
        [Route("~/DBRedaction/DeleteMusic")]
        [HttpPost]
        public RedirectResult DeleteMusic(Music music)
        {
            _allMusic.DeleteMusic(music);

            return Redirect("~/DBRedaction/AddMusic");
        }


        //[Route("~/DBRedaction/RedactGenres")]
        //public ViewResult RedactGenres()
        //{
        //    return View();
        //}
        //[Route("~/DBRedaction/RedactGenres/{id}")]
        //public RedirectResult RedactGenres(int id)
        //{
        //    return Redirect("~/DBRedaction/RedactGenres");
        //}

        //[Route("~/DBRedaction/RedactGroups")]
        //public ViewResult RedactGroups()
        //{
        //    return View();
        //}
        //[Route("~/DBRedaction/RedactGroups/{id}")]
        //public RedirectResult RedactGroups(int id)
        //{
        //    return Redirect("~/DBRedaction/RedactGroups");
        //}

        //[Route("~/DBRedaction/RedactMusics")]
        //public ViewResult RedactMusics()
        //{
        //    return View();
        //}
        //[Route("~/DBRedaction/RedactMusics/{id}")]
        //public RedirectResult RedactMusics(int id)
        //{
        //    return Redirect("~/DBRedaction/RedactMusics");
        //}


        [Route("~/DBRedaction/Complete/{completeMessage}")]
        public ViewResult Complete(string completeMessage)
        {
            ViewBag.CompleteMessage = completeMessage; 
            return View();
        }
    }
}
