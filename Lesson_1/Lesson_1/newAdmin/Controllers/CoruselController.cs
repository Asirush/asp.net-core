using Microsoft.AspNetCore.Mvc;
using newAdmin.Data;
using newAdmin.Modals;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace newAdmin.Controllers
{
    public class CoruselController : Controller
    {
        private WebAppMVCLesson1DbContext db;
        private IWebHostEnvironment env;

        public CoruselController(WebAppMVCLesson1DbContext _db, IWebHostEnvironment env)
        {
            db = _db;
            this.env = env;
        }
        public IActionResult Index()
        {
            var data = db.Carusels.ToList();
            return View(data);
        }

        public IActionResult AddCarusel()
        {
            Carusel car = new();
            return View(car);
        }

        [HttpPost]
        public IActionResult AddCarusel(string Tirle, string Description, string CreateUser)
        {
            try
            {
                Carusel carusel = new Carusel();
                carusel.Tirle = Tirle;
                carusel.Description = Description;
                carusel.CreateUser = CreateUser;
                db.Carusels.Add(carusel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }
    }
}
