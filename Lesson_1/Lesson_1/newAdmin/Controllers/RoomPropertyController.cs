using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newAdmin.Data;
using newAdmin.Modals;

namespace newAdmin.Controllers
{
    public class RoomPropertyController : Controller
    {
        public WebAppMVCLesson1DbContext db { get; set; }

        public RoomPropertyController(WebAppMVCLesson1DbContext _db)
        {
            db = _db;
        }

        // GET: RoomPropertyController
        public ActionResult Index()
        {
            List<RoomProperty> roomProperties = new List<RoomProperty>();
            return View(roomProperties);
        }

        // GET: RoomPropertyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoomPropertyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomPropertyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Name)
        {
            try
            {
                RoomProperty roomProperty = new RoomProperty();
                roomProperty.Name = Name;
                db.Add(roomProperty);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomPropertyController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.RoomProperties.FirstOrDefault(f => db.RoomPropertyId == id);
            if (data != null) return View(data);
            else return RedirectToAction(nameof(Index));
        }

        // POST: RoomPropertyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomPropertyController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.RoomProperties.FirstOrDefault(f => db.RoomPropertyId == id);
            if (data != null) return View(data);
            else return RedirectToAction(nameof(Index));
        }

        // POST: RoomPropertyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
