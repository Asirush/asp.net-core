using Microsoft.AspNetCore.Mvc;

namespace admin_panel.Controllers
{
    public class DirectoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DirectoryRoomProperties()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RoomProperties()
        {
            string nameProp = Request.Form["NameProperties"];
            string descrProp = Request.Form["Description"];

            return View();
        }
    }
}