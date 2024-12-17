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
        [ActionName("CreateShop")]
        public IActionResult CreateShop(Store obj)
        {
            _db.Stores.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("shop");
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
            _db.Stores.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("shop");
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
            _db.Departments.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("department");
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



        public IActionResult employee()
        {
            List<Employee> employeeObjectList = _db.Employees.ToList();
            return View(employeeObjectList);
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee obj)
        {
            _db.Employees.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("employee");
        }
        public IActionResult EditEmployee(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Employee employeefromdb = _db.Employees.Find(id);
            return View(employeefromdb);
        }

        [HttpPost]
        [ActionName("EditEmployee")]
        public IActionResult EditEmployee(Employee obj)
        {
            _db.Employees.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("employee");
        }

        public IActionResult DeleteEmployee(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Employee employeefromdb = _db.Employees.Find(id);
            return View(employeefromdb);
        }

        [HttpPost]
        [ActionName("DeleteEmployee")]
        public IActionResult DeleteEmployeePost(int? id)
        {
            Employee? obj = _db.Employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("employee");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
