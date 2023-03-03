using ASPdotNetDesign.Data;
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
        // --Student--
        public IActionResult Student()
        {
            var studentResult = context.StudentInfoes.ToList();
            return View(studentResult);
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
    }
}
