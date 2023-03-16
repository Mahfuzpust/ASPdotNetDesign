using ASPdotNetDesign.Data;
using ASPdotNetDesign.Models.Account;
using ASPdotNetDesign.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        //Login form
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginSignUpViewModel model)
        {
            if(ModelState.IsValid)
            {
                var data = context.Users.Where(e => e.Username == model.Username).SingleOrDefault();
                if(data != null)
                {
                    bool isValid = (data.Username == model.Username && data.Password == model.Password);
                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] {new Claim(ClaimTypes.Name, model.Username) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var pricipal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, pricipal);
                        HttpContext.Session.SetString("Username", model.Username);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["errorPassword"] = "password invalid";
                        return View();
                    }
                }
                else
                {
                    TempData["errorUsername"] = "Username not found";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        //Logout
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storeCookies = Request.Cookies.Keys;
            foreach(var cookies in storeCookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("Login", "Account");
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

        //Unique Email
        [AcceptVerbs("Post", "Get")]
        public IActionResult EmailisExit(string email)
        {
            var data = context.Users.Where(e => e.Email == email).SingleOrDefault();
            if (data != null)
            {
                return Json($"Email {email} already in use");
            }
            else
            {
                return Json(true);
            }
        }
        //SignUp form
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
