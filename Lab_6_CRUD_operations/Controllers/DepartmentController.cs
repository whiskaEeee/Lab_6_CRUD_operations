using Lab_6_CRUD_operations.Data;
using Lab_6_CRUD_operations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace Lab_6_CRUD_operations.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
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
            
            if (!_db.Stores.Any(s => s.StoreId == obj.StoreId))
            {
                ModelState.AddModelError("StoreId", "Указанный StoreId не существует.");
            }
            if (!ModelState["StoreId"].Errors.Any() && !ModelState["DepartmentName"].Errors.Any() && !ModelState["DirectorId"].Errors.Any())
            {
                
                _db.Departments.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("department");
            }
            return View();

        }

        public IActionResult EditDepartment(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Department departmentfromdb = _db.Departments.Find(id);
            return View(departmentfromdb);
        }

        [HttpPost]
        [ActionName("EditDepartment")]
        public IActionResult EditDepartment(Department obj)
        {
            if (!_db.Stores.Any(s => s.StoreId == obj.StoreId))
            {
                ModelState.AddModelError("StoreId", "Указанный StoreId не существует.");
            }
            if (!ModelState["StoreId"].Errors.Any() && !ModelState["DepartmentName"].Errors.Any() && !ModelState["DirectorId"].Errors.Any())
            {
                _db.Departments.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("department");
            }
            return View();
        }

        public IActionResult DeleteDepartment(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Department departmentfromdb = _db.Departments.Find(id);
            return View(departmentfromdb);
        }

        [HttpPost]
        [ActionName("DeleteDepartment")]
        public IActionResult DeleteDepartmentPost(int? id)
        {
            Department? obj = _db.Departments.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Departments.Remove(obj);
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
