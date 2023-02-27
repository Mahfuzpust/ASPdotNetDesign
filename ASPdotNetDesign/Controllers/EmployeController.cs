using ASPdotNetDesign.Data;
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
        public IActionResult Index()
        {
            var result = context.Employees.ToList();
            return View(result);
        }
    }
}
