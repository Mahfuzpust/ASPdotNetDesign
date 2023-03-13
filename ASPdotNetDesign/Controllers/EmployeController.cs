using ASPdotNetDesign.Data;
using ASPdotNetDesign.Migrations;
using ASPdotNetDesign.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPdotNetDesign.Controllers
{
    public class EmployeController : Controller
    {
        private readonly ApplicationDbContext context;
        public EmployeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // --Employee--
        public IActionResult Index()
        {
            var result = context.Employees.ToList();
            return View(result);
        }

        // --Employee Create--
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    Name = model.Name,
                    City = model.City,
                    State = model.State,
                    Salary = model.Salary
                };
                context.Employees.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Empty field can not submit";
                return View(model);
            }
        }
        // --Employe Edit--
        public IActionResult Edit(int id)
        {
            var emp = context.Employees.SingleOrDefault(u => u.Id == id);
            var result = new Employee()
            {
                Name = emp.Name,
                City = emp.City,
                State = emp.State,
                Salary = emp.Salary

            };
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                Id = model.Id,
                Name = model.Name,
                City = model.City,
                State = model.State,
                Salary = model.Salary
            };
            context.Employees.Update(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // --Employe Delete--
        public IActionResult Delete(int id)
        {
            var del = context.Employees.SingleOrDefault(u => u.Id == id);
            context.Employees.Remove(del);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // --Student--
        public IActionResult Student()
        {
            var res = context.StudentInfoes.ToList();
            //var studentResult = context.StudentInfoes.ToList();
            return View(res);
        }

        // --Student Create--
        [HttpGet]
        public IActionResult CreateStu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateStu(StudentInfo model)
        {
            if (ModelState.IsValid)
            {
                var emp = new StudentInfo()
                {
                    Reg = model.Reg,
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    Dept = model.Dept,
                    varsity = model.varsity
                };
                context.StudentInfoes.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Student");
            }
            else
            {
                TempData["error"] = "Empty field can not submit";
                return View(model);
            }
        }

        // --Student Delete--
        public IActionResult DeleteStu(int id)
        {
            var del = context.StudentInfoes.SingleOrDefault(u => u.Id == id);
            context.StudentInfoes.Remove(del);
            context.SaveChanges();
            return RedirectToAction("Student");
        }

        // --Student Edit--
        public IActionResult EditStu(int id)
        {
            var emp = context.StudentInfoes.SingleOrDefault(u => u.Id == id);
            var result = new StudentInfo()
            {
                Reg = emp.Reg,
                Name = emp.Name,
                Email = emp.Email,
                Phone = emp.Phone,
                Dept = emp.Dept,
                varsity = emp.varsity

            };
            return View(result);
        }

        [HttpPost]
        public IActionResult EditStu(StudentInfo model)
        {
            var emp = new StudentInfo()
            {
                Id = model.Id,
                Reg = model.Reg,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Dept = model.Dept,
                varsity = model.varsity
            };
            context.StudentInfoes.Update(emp);
            context.SaveChanges();
            return RedirectToAction("Student");
        }

        public IActionResult Department()
        {
            return View();
        }
    }
}
