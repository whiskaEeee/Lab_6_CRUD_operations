using Lab_6_CRUD_operations.Data;
using Lab_6_CRUD_operations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Lab_6_CRUD_operations.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DatabaseController(ApplicationDbContext db)
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
        public IActionResult CreateShop(Store obj)
        {
            _db.Stores.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("shop");
        }




        public IActionResult department()
        {
            List<Department> departmentObjectList = _db.Departments.ToList();
            return View(departmentObjectList);
        }
        public IActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDepartment(Department obj)
        {
            _db.Departments.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("department");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
