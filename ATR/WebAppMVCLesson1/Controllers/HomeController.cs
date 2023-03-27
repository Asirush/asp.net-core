using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMVCLesson1.Models;

namespace WebAppMVCLesson1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                string useremail = "abdukasi";
                _logger.LogInformation("A user email: {0} logged in {1}", useremail, DateTime.Now);
                _logger.LogInformation("LogInformation");
                _logger.LogError("LogError");
                throw new Exception("test Error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Location()
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