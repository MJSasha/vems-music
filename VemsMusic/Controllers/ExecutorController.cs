using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VemsMusic.Interfaces;
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
        public async Task<IActionResult> Index(int id)
        {
            var groupWithMusics = new GroupWithMusicsViewModel
            {
                MusicalGroup = await _allGroups.GetMusicalGroupByIdAsync(id),
                GetAllMusic = _allMusic.GetAllMusic.Where(m => m.GroupId == id)
            };

            if (!groupWithMusics.GetAllMusic.Any())
            {
                return Redirect("~/Home/NoItems/Музыка не добавлена");
            }

            return View(groupWithMusics);
        }
    }
}
