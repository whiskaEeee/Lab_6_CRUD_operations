using Lab_6_CRUD_operations.Data;
using Lab_6_CRUD_operations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Lab_6_CRUD_operations.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StoreController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        
            public IActionResult shop()
        {
            List<Store> shopObjectList = _db.Stores.ToList();
            return View(shopObjectList);
        }

        public IActionResult CreateShop()
        {
            return View();
        }

        [HttpPost]
        [ActionName("CreateShop")]
        public IActionResult CreateShop(Store obj)
        {

            if (!ModelState["StoreName"].Errors.Any() &&
                !ModelState["Specialization"].Errors.Any() &&
                !ModelState["INN"].Errors.Any() &&
                !ModelState["Address"].Errors.Any() &&
                !ModelState["DirectorId"].Errors.Any())
            {

                _db.Stores.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("shop");
            }
            return View();
        }

        public IActionResult EditShop(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Store storefromdb = _db.Stores.Find(id);
            return View(storefromdb);
        }

        [HttpPost]
        [ActionName("EditShop")]
        public IActionResult EditShop(Store obj)
        {
            if (!ModelState["StoreName"].Errors.Any() &&
                !ModelState["Specialization"].Errors.Any() &&
                !ModelState["INN"].Errors.Any() &&
                !ModelState["Address"].Errors.Any() &&
                !ModelState["DirectorId"].Errors.Any())
            {

                _db.Stores.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("shop");
            }
            return View();
        }
        public IActionResult DeleteShop(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Store storefromdb = _db.Stores.Find(id);
            return View(storefromdb);
        }

        [HttpPost]
        [ActionName("DeleteShop")]
        public IActionResult DeleteShopPost(int? id)
        {
            Store? obj = _db.Stores.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Stores.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("shop");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
