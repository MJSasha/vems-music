using Microsoft.AspNetCore.Mvc;

namespace VemsMusic.Controllers
{
    public class AboutController : Controller
    {
        [Route("~/AboutUs")]
        public ViewResult Index()
        {
            return View();
        }
    }
}
