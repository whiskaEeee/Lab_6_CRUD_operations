using Lab_6_CRUD_operations.Data;
using Lab_6_CRUD_operations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Lab_6_CRUD_operations.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
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

            if (!_db.Departments.Any(s => s.DepartmentId == obj.DepartmentId))
            {
                ModelState.AddModelError("DepartmentId", "Указанный DepartmentId не существует.");
            }
            if (!ModelState["Surname"].Errors.Any() &&
                !ModelState["Name"].Errors.Any() &&
                !ModelState["Otchestvo"].Errors.Any() &&
                !ModelState["Address"].Errors.Any() &&
                !ModelState["Gender"].Errors.Any() &&
                !ModelState["DateOfBirth"].Errors.Any() &&
                !ModelState["DepartmentId"].Errors.Any())
            {

                _db.Employees.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("employee");
            }
            return View();
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
            if (!_db.Departments.Any(s => s.DepartmentId == obj.DepartmentId))
            {
                ModelState.AddModelError("DepartmentId", "Указанный DepartmentId не существует.");
            }
            if (!ModelState["Surname"].Errors.Any() &&
                !ModelState["Name"].Errors.Any() &&
                !ModelState["Otchestvo"].Errors.Any() &&
                !ModelState["Address"].Errors.Any() &&
                !ModelState["Gender"].Errors.Any() &&
                !ModelState["DateOfBirth"].Errors.Any() &&
                !ModelState["DepartmentId"].Errors.Any())
            {

                _db.Employees.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("employee");
            }
            return View();
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
