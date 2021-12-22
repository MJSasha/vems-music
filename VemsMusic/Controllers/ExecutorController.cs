using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VemsMusic.Interfaces;

namespace VemsMusic.Controllers
{
    public class ExecutorController : Controller
    {
        private readonly IAllGroups _allGroups;

        public ExecutorController(IAllGroups allGroups)
        {
            _allGroups = allGroups;
        }

        [Route("~/Executor/Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var musicalGroup = await _allGroups.GetMusicalGroupByIdAsync(id);

            if (!musicalGroup.Musics.Any())
            {
                return Redirect("~/Home/NoItems/Музыка не добавлена");
            }

            ViewBag.Id = HttpContext.Request.Cookies["id"];
            if (ViewBag.Id == null)
            {
                return Redirect("~/Home/NoItems/Ошибка. Пожалуйста перерегистрируйтесь");
            }
            return View(musicalGroup);
        }
    }
}
