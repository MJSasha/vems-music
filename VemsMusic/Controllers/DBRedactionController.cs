using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> AllGenre()
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
        [Route("~/DBRedaction/AllGroup")]
        public async Task<IActionResult> AllGroup()
        {
            IEnumerable<MusicalGroup> musicalGroups = await _allGroups.GetMusicalGroupsAsync();

            if (!musicalGroups.Any())
            {
                return Redirect("~/Home/NoItems/Группы не добавлены");
            }

            ViewBag.Genres = new SelectList(await _allGenre.GetAllGenresAsync(), "Id", "Name");
            return View(new GroupsViewModel { AllGroups = musicalGroups });
        }
        [Route("~/DBRedaction/AllMusic")]
        public async Task<IActionResult> AllMusic()
        {
            IEnumerable<Music> musics = await _allMusic.GetAllMusicAsync();

            if (!musics.Any())
            {
                return Redirect("~/Home/NoItems/Музыка не добавлена");
            }

            ViewBag.Genres = new SelectList(await _allGenre.GetAllGenresAsync(), "Id", "Name");
            ViewBag.Groups = new SelectList(await _allGroups.GetMusicalGroupsAsync(), "Id", "Name");
            return View(new MusicViewModel { AllMusic = musics });
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
