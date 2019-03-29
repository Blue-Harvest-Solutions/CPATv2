using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPAT.Data;
using CPAT.Extensions;
using CPAT.Models.ViewModel;
using CPAT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPAT.Areas.Academic.Controllers
{
    [Area("Academic")]
    public class CourseCartController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public CourseCartViewModel CourseCartviewmodel { get; set; }

        public CourseCartController(ApplicationDbContext db)
        {
            _db = db;
            CourseCartviewmodel = new CourseCartViewModel()
            {
                Courses = new List<Models.Courses>()
            };
        }

        public IActionResult Index()
        {
            List<int> lstCourseCart = HttpContext.Session.Get<List<int>>("sessionCourseCart");

            if(lstCourseCart == null)
            {
                return View(CourseCartviewmodel);
            }

            if (lstCourseCart.Count > 0)
            {
                foreach (int cartItem in lstCourseCart)
                {
                    //Courses prod = _db.Products.Include(p => p.SpecialTags).Include(p => p.ProductTypes).Where(p => p.Id == cartItem).FirstOrDefault();
                    Courses course = _db.Courses.Where(p => p.Id == cartItem).FirstOrDefault();
                    CourseCartviewmodel.Courses.Add(course);
                }
            }
           
            return View(CourseCartviewmodel);
        }


        //*********
        //Figure this out later
        //******
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            List<int> lstCourseItems = HttpContext.Session.Get<List<int>>("sessionCourseCart");

            int courseId = courses.id;

            foreach (int courseId in lstCourseItems)
            {
                CoursesSelectedForTerm coursesSelectedForTerm = new CoursesSelectedForTerm()
                {
                    PlanCourseId = courseId
                };
                _db.CoursesSelectedForTerm.Add(coursesSelectedForTerm);
            }
            _db.SaveChanges(); 
            lstCourseItems = new List<int>();
            HttpContext.Session.Set("sessionCourseCart", lstCourseItems);

            return RedirectToAction("ConfirmationPage", "CourseCart", new { id = courseId });
        }
        */
        

        public IActionResult Remove(int id)
        {
            List<int> lstCourseItems = HttpContext.Session.Get<List<int>>("sessionCourseCart");

            if (lstCourseItems.Count > 0)
            {
                lstCourseItems.Remove(id);
            }

            HttpContext.Session.Set("sessionCourseCart", lstCourseItems);

            return RedirectToAction(nameof(Index));
        }
    }
}