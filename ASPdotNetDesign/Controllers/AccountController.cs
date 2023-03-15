using ASPdotNetDesign.Data;
using ASPdotNetDesign.Models.Account;
using ASPdotNetDesign.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ASPdotNetDesign.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext context;
        public AccountController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginSignUpViewModel model)
        {
            return View();
        }
        //Unique Username 

        [AcceptVerbs("Post", "Get")]
        public IActionResult UserNameisExit(string userName)
        {
            var data = context.Users.Where(e => e.Username == userName).SingleOrDefault();
            if (data != null)
            {
                return Json($"Username {userName} already in use");
            }
            else
            {
                return Json(true);
            }
        }
        public IActionResult SignUP()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = new User()
                {
                    Username= model.Username,
                    Email=model.Email,
                    Mobile=model.Mobile,
                    Password=model.Password,
                    IsActive=model.IsActive
                };
                context.Users.Add(data);
                context.SaveChanges();
                TempData["successMessage"] = "You are eligible to login";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["errorMessage"] = "Empty form can not submitted";
                return View(model);
            }
        }
    }
}
