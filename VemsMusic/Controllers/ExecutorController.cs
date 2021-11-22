using Microsoft.AspNetCore.Mvc;
using VemsMusic.Interfaces;
using VemsMusic.Models;

namespace VemsMusic.Controllers
{
    public class ExecutorController : Controller
    {
        private readonly IAllGroups _allGroups;

        public ExecutorController(IAllGroups allGroups)
        {
            _allGroups = allGroups;
        }

        [Route("~/Executor")]
        [HttpPost]
        public IActionResult Index(int id)
        {
            MusicalGroup group = _allGroups.GetMusicalGroupById(id);
            return View(group);
        }
    }
}
