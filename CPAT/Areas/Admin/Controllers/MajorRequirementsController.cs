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
    public class MajorRequirementsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public MajorRequirementsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: MajorRequirements
        public IActionResult Index()
        {
            return View(_db.MajorRequirements.ToList());
        }

        // GET: MajorRequirements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MajorRequirements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MajorRequirements majorRequirements)
        {
                if(ModelState.IsValid)
                {
                    _db.Add(majorRequirements);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return View(majorRequirements);
        }


        // GET: MajorRequirements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var majorRequirement = await _db.MajorRequirements.FindAsync(id);
            if (majorRequirement == null)
            {
                return NotFound();
            }

            var courseList = _db.Courses.ToList();
            
            ViewBag.availableCourses = courseList;

            return View(majorRequirement);
        }

        // GET: MajorRequirements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var majorRequirements = await _db.MajorRequirements.FindAsync(id);

            if (majorRequirements == null)
            {
                return NotFound();
            }

            return View(majorRequirements);
        }

        // POST: MajorRequirements/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MajorRequirements majorRequirements)
        {
            try
            {
                if (id != majorRequirements.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _db.Update(majorRequirements);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return View(majorRequirements);
            }
            catch
            {
                return View();
            }
        }

        //GET: MajorRequirements/AddCourses
        public async Task<IActionResult> AddCourses (int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var major = await _db.MajorRequirements.FindAsync(id);
            if (major == null)
            {
                return NotFound();
            }

            return View(major);
        }

        //POST: MajorRequirements/AddCourses
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCourses(int id, MajorRequirements major)
        {
            try
            {
                if (id != major.Id)
                {
                    return NotFound();
                }

                //TODO: Add each course to the major

                //foreach course that's been added/selected, add it to major

                if (ModelState.IsValid)
                {
                    _db.Update(major);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return View(major);
            }
            catch
            {
                return View();
            }
        }


        // GET: MajorRequirements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var major = await _db.MajorRequirements.FindAsync(id);
            if (major == null)
            {
                return NotFound();
            }
            return View(major);
        }

        // POST: MajorRequirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {     
            var major = await _db.MajorRequirements.FindAsync(id);
            _db.MajorRequirements.Remove(major);
            await _db.SaveChangesAsync();
           
            return RedirectToAction(nameof(Index));
        }
    }
}