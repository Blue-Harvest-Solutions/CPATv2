using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPAT.Data;
using CPAT.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPAT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoursesController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CoursesController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View(_db.Courses.ToList());
        }


        //GET Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        //POST Create Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (Courses courses)
        {
            if(ModelState.IsValid)
            {
                _db.Add(courses);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(courses);
        }


        //GET Edit Action Method
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var course = await _db.Courses.FindAsync(id);
            if(course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        //POST Edit Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Courses courses)
        {

            if (id != courses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(courses);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(courses);
        }

    }
}