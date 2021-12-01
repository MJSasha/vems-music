using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "admin")]
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
        public async Task<RedirectResult> AddGenre(Genre genre)
        {
            await _allGenre.AddGenreAsync(genre);

            return Redirect("~/DBRedaction/AllGenre");
        }
        [Route("~/DBRedaction/AddGroup")]
        [HttpPost]
        public async Task<RedirectResult> AddGroup(MusicalGroup group)
        {
            await _allGroups.AddGroupAsync(group);

            return Redirect("~/DBRedaction/AllGroup");
        }
        [Route("~/DBRedaction/AddMusic")]
        [HttpPost]
        public async Task<RedirectResult> AddMusic(Music music)
        {
            await _allMusic.AddMusicAsync(music);

            return Redirect("~/DBRedaction/AllMusic");
        }


        [Route("~/DBRedaction/DeleteGenre/{id}")]
        public async Task<RedirectResult> DeleteGenre(int id)
        {
            await _allGenre.DeleteGenreAsync(id);

            return Redirect("~/DBRedaction/AllGenre");
        }
        [Route("~/DBRedaction/DeleteGroup/{id}")]
        public async Task<RedirectResult> DeleteGroup(int id)
        {
            await _allGroups.DeleteGroupAync(id);

            return Redirect("~/DBRedaction/AllGroup");
        }
        [Route("~/DBRedaction/DeleteMusic/{id}")]
        public async Task<RedirectResult> DeleteMusic(int id)
        {
            await _allMusic.DeleteMusicAsync(id);

            return Redirect("~/DBRedaction/AllMusic");
        }


        [Route("~/DBRedaction/RedactGenres/{id}")]
        [HttpPost]
        public async Task<RedirectResult> RedactGenres(Genre genre, int id)
        {
            genre.Id = id;
            await _allGenre.UpdateGenreAsync(genre);

            return Redirect("~/DBRedaction/AllGenre");
        }
        [Route("~/DBRedaction/RedactGroups/{id}")]
        [HttpPost]
        public async Task<RedirectResult> RedactGroups(MusicalGroup musicalGroup, int id)
        {
            musicalGroup.Id = id;
            await _allGroups.UpdateGroupAsync(musicalGroup);

            return Redirect("~/DBRedaction/AllGroup");
        }
        [Route("~/DBRedaction/RedactMusics/{id}")]
        [HttpPost]
        public async Task<RedirectResult> RedactMusics(Music music, int id)
        {
            music.Id = id;
            await _allMusic.UpdateMusicAsync(music);

            return Redirect("~/DBRedaction/AllMusic");
        }
    }
}
