﻿using ASPdotNetDesign.Data;
using ASPdotNetDesign.Models;
using ASPdotNetDesign.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ASPdotNetDesign.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IHostingEnvironment environment;
        public UploadController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        [HttpGet]
        public ActionResult UploadImage()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult UploadImage(ImageCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var path = environment.WebRootPath;
                var filePath = "Content/Image/" + model.ImagePath.FileName;
                var fullPath = Path.Combine(path, filePath);
                UploadFile(model.ImagePath, fullPath);
                var data = new NewImage()
                {
                    Name = model.Name,
                    ImagePath = filePath,
                };
                context.Add(data);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        [AllowAnonymous]
        public void UploadFile(IFormFile file, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }

        // --Image Edit--
        public IActionResult EditImage(int id)
        {
            var emp = context.NewImages.SingleOrDefault(u => u.Id == id);
            var result = new NewImage()
            {
                Name = emp.Name,
                ImagePath = emp.ImagePath
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult EditImage(NewImage model)
        {
            var emp = new NewImage()
            {
                Id = model.Id,
                Name = model.Name,
                ImagePath = model.ImagePath,
            };
            context.NewImages.Update(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        // --Image Delete--
        public IActionResult Delete(int id)
        {
            var del = context.NewImages.SingleOrDefault(u => u.Id == id);
            context.NewImages.Remove(del);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var data = context.NewImages.ToList();
            return View(data);
        }
    }
}
