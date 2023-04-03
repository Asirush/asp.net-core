using Microsoft.AspNetCore.Mvc;
using SimpleRouting.Models;
using System.Diagnostics;

namespace SimpleRouting.Controllers
{
    [Route("AsUsual")]
    [Route("Main")]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index(int id = 0)
        {
            ViewBag.Id = id;
            return View();
        }

        [Route("[action]/{id:int}/{name:maxlength(10)}")]
        public IActionResult Index(int id, string name)
        {
            ViewBag["id"] = id;
            ViewBag["name"] = name;
            return View();
        }

        public IActionResult Index(int a, int b = 0, int c = 0)
        {
            ViewBag.A = a;
            ViewBag.B = b;
            ViewBag.C = c;
            return View();
        }

        //[Route("Synny")]
        [HttpPost]
        [Route("CheckPrivacy")]
        [Route("[controller]/[action]")]
        [Route("~/PrivacyPage")]
        [Route("action", Name = "Privacy")]
        public IActionResult Privacy(params string[] obj)
        {
            var controller = RouteData.Values["controller"].ToString();
            var action = RouteData.Values["action"].ToString();
            ViewBag.data = obj;
            //return View();
            return Content($"controller: {controller} | action: {action}");
        }

        // Two Parametrs Route
        public IActionResult Privacy(int x, int y)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}