using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VemsMusic.Interfaces;
using VemsMusic.Models;
using VemsMusic.Other_Data.Interfaces;
using VemsMusic.Other_Data.ViewModels;

namespace VemsMusic.Controllers
{
    public class ExecutorController : Controller
    {
        private readonly IAllGroups _allGroups;
        private readonly IAllMusic _allMusic;

        public ExecutorController(IAllGroups allGroups, IAllMusic allMusic)
        {
            _allGroups = allGroups;
            _allMusic = allMusic;
        }

        [Route("~/Executor/Index/{id}")]
        public IActionResult Index(int id)
        {
            MusicalGroup group = _allGroups.GetMusicalGroupById(id);
            IEnumerable<Music> musics = _allMusic.GetAllMusic;

            var groupWithMusics = new GroupWithMusicsViewModel
            {
                MusicalGroup = group,
                AllMusic = musics
            };

            return View(groupWithMusics);
        }
    }
}
