using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext db;
        private readonly IWebHostEnvironment iweb;
        public StudentController(AppDbContext _db, IWebHostEnvironment _iweb)
        {
            db = _db;
            iweb = _iweb;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> obj = db.students;
            return View(obj);
        }
        public IActionResult Create()
        {
            StudentVM svm = new StudentVM()
            {
                Student = new Student(),
                TypeDropDown = db.countries.Select(i=> new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }
                ),
            };
            svm.Courses = db.courses.ToList<Course>();

            return View(svm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile fileobj, StudentVM svm)
        {
            

            
            var c = svm.Courses.Where(x => x.IsChecked == true).ToList<Course>();
            var result = Content(String.Join(",", c.Select(x => x.Name)));
            
            svm.Student.Coursess = result.Content.ToString();
            if(svm.Student.Coursess == "")
            {
                ViewBag.Course = "Please choose the Course";

                //ViewData["Course"] = "Please choose the Course";
                return View(svm);
                //return Content("Course field is required");
            }
            

            //svm.Courses = db.courses.ToList<Course>();
            //Path.Combine()
            string imgtxt = Path.GetExtension(fileobj.FileName);
            string imtxt = imgtxt.ToLower();
            
            if (imtxt== ".jpg" || imtxt ==".gif" )
            {
                long a = fileobj.Length;
                if (a < 1000000)
                {
                    var uploadimg = Path.Combine(iweb.WebRootPath, "Images", fileobj.FileName);
                    var stream = new FileStream(uploadimg, FileMode.Create);
                    await fileobj.CopyToAsync(stream);
                    svm.Student.ProfilePic = uploadimg;
                }
                else 
                {
                    ViewData["ImageSize"] = "File size should be less than 2 mb";
                    return View(svm);

                    //return Content("File size should be less than 2 mb"); 
                }
                
            }
            //if(svm.Student.CountryId == null)
            //{
            //    TempData["CountryId"] = "Choose the country";
            //    return View(svm);
            //}
            

            if (ModelState.IsValid)
            {
                await db.students.AddAsync(svm.Student);
                await db.SaveChangesAsync();
               // ViewBag.Success = $"{svm.Student.Name} successfully registered";
                TempData["Success"] =  $"{svm.Student.Name} successfully registered";
                return RedirectToAction("Create");

            }
            //return View("Create",svm);
            



            return RedirectToAction("Create");
        }
    }
}



















//else
//{

//    //ViewData["Upload"] = "Upload only in jpg OR gif.";
//    //return View(svm);
//    return Content("Upload only in jpg OR gif.");
//}


//let x = document.getElementById("Name").value;
//let y = document.getElementById("Age").value;
//let z = document.getElementById("Email").value;

//var re = /\S+@\S+\.\S+/;
//var r = re.test(z);
//if (r == true) {
//    return true;
//}
//else {
//    alert("Invalid Email");
//    return false;
//}



//let z = document.getElementById("Email").value;

//var re = /\S+@\S+\.\S+/;
//var r = re.test(z);
//if (r == true) {
//    return true;
//}
//else {
//    document.getElementById("Email").innerHTML = "Invalid Email";
//    return false;
//}