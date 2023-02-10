using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Lesson02._2023._02._10.Admin.Models;

namespace MVC.Lesson02._2023._02._10.Admin.Controllers
{
    public class DirectoryController : Controller
    {
        private IWebHostEnvironment hostEnvironment;
        public DirectoryController(IWebHostEnvironment _hostEnvironment)
        {
            hostEnvironment = _hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DirectoryRoomProperties(int page=0) // site_url?page=666 changes value of page
        {
            return View(new RoomProperties());
        }

        [HttpPost]
        public IActionResult RoomProperties()
        {
            string nameProp = Request.Form["NameProperties"];
            string descrProp = Request.Form["Decription"];
            return View();
        }

        [HttpPost]
        public IActionResult RoomPropertiesModel(RoomProperties roomProperties)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoomPropertiesFile(IFormFile photo)
        {
            using(var stream = new FileStream(Path.Combine(hostEnvironment.WebRootPath, photo.FileName), FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }
            string fileName = photo.FileName;
            return View();
        }

    }
}
