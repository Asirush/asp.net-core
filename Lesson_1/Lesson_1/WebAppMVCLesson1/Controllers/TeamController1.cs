using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCLesson1.Controllers
{
    public class TeamController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
