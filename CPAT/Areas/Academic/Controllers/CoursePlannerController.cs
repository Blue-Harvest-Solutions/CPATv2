using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPAT.Models;
using CPAT.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CPAT.Extensions;

namespace CPAT.Areas.Academic.Controllers
{
    [Area("Academic")]
    public class CoursePlannerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CoursePlannerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            //var courseList = await _db.Courses.Include(m=>m.CourseID).ToListAsync();
            return View(await _db.Courses.ToListAsync());
        }

        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexPost(int id)
        {
            List<int> lstCourseCart = HttpContext.Session.Get<List<int>>("sessionCourseCart");
            if (lstCourseCart == null)
            {
                lstCourseCart = new List<int>();
            }
            lstCourseCart.Add(id);
            HttpContext.Session.Set("sessionCourseCart", lstCourseCart);

            return RedirectToAction("Index", "Academic", new { area = "Academic" });
        }
    }             
}