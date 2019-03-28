using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPAT.Data;
using CPAT.Models;
using CPAT.Utility;
using Microsoft.AspNetCore.Authorization;

namespace CPAT.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class AcademicTermsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcademicTermsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AcademicTerms
        public async Task<IActionResult> Index()
        {
            return View(await _context.AcademicTerms.ToListAsync());
        }

        // GET: Admin/AcademicTerms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicTerms = await _context.AcademicTerms.FindAsync(id);
            if (academicTerms == null)
            {
                return NotFound();
            }

            return View(academicTerms);
        }

        // GET: Admin/AcademicTerms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AcademicTerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Season,Year")] AcademicTerms academicTerms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicTerms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academicTerms);
        }

        /*
         * IN PROGRESS
         * TODO: Update courses to have the term Id as a reference if they have been selected in the form
         * 
        //GET Action Method
        public async Task<IActionResult> AddCoursesToTerm(int? id, AcademicTerms term)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CourseList = await _context.Courses.ToListAsync();

            return View(CourseList);
        }

        //POST Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCoursesToTerm(int id, AcademicTerms term)
        {
            if(ModelState.IsValid)
            {
                
            }

            var CourseList = await _context.Courses.ToListAsync();

            return View(CourseList);
        }

    */


        // GET: Admin/AcademicTerms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicTerms = await _context.AcademicTerms.FindAsync(id);
            if (academicTerms == null)
            {
                return NotFound();
            }
            return View(academicTerms);
        }

        // POST: Admin/AcademicTerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Season,Year")] AcademicTerms academicTerms)
        {
            if (id != academicTerms.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicTerms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicTermsExists(academicTerms.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(academicTerms);
        }

        // GET: Admin/AcademicTerms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicTerms = await _context.AcademicTerms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicTerms == null)
            {
                return NotFound();
            }

            return View(academicTerms);
        }

        // POST: Admin/AcademicTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicTerms = await _context.AcademicTerms.FindAsync(id);
            _context.AcademicTerms.Remove(academicTerms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicTermsExists(int id)
        {
            return _context.AcademicTerms.Any(e => e.Id == id);
        }
    }
}
