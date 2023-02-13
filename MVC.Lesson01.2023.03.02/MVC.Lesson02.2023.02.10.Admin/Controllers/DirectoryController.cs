using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Lesson02._2023._02._10.Admin.Models;
using MVC.Lesson3.Lib;

namespace MVC.Lesson02._2023._02._10.Admin.Controllers
{
    public class DirectoryController : Controller
    {
        private IWebHostEnvironment hostEnvironment;
        public DirectoryController(IWebHostEnvironment _hostEnvironment)
        {
            hostEnvironment = _hostEnvironment;
        }

        public IActionResult Index(string message)
        {
            return View(message);
            // return View("~/Views/Home/Privacy.cshtml", "test")
        }

        public IActionResult DirectoryRoomProperties(int page=0) // site_url?page=666 changes value of page
        {
            var data = new RoomPropertyModel()
            {
                RoomProperties = new List<RoomProperty>(),
                RoomProperty = new RoomProperty()
            };

            return View(data);
        }

        [HttpPost]
        public IActionResult RoomProperties()
        {
            string nameProp = Request.Form["NameProperties"];
            string descrProp = Request.Form["Decription"];
            return View("Index", "Данные добавлены 1");
        }

        [HttpPost]
        public IActionResult RoomPropertiesModel(RoomProperty roomProperties)
        {
            RoomService roomService = new();
            roomService.AddRoomProperties(roomProperties);
            return View("Index", "Данные добавлены 2");
        }

        [HttpPost]
        public async Task<IActionResult> RoomPropertiesFile(IFormFile photo)
        {
            using(var stream = new FileStream(Path.Combine(hostEnvironment.WebRootPath, photo.FileName), FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }
            string fileName = photo.FileName;
            return View("Index", "Данные добавлены 3");
        }

    }
}
