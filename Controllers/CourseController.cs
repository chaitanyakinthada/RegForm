using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext db;

        public CourseController(AppDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            IEnumerable<Course> obj = db.courses;
            return View(obj);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course c)
        {
            if(ModelState.IsValid)
            {
                db.courses.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }


        public IActionResult Delete(int? id)
        {
            if(id==null || id ==0)
            {
                return NotFound();
            }
            var obj = db.courses.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = db.courses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            db.courses.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            var obj = db.courses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Course obj)
        {
            if(ModelState.IsValid)
            {
                db.courses.Update(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


    }
}
