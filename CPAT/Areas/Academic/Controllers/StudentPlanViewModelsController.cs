using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPAT.Data;
using CPAT.Models.ViewModels;

namespace CPAT.Areas.Academic.Controllers
{
    [Area("Academic")]
    public class StudentPlanViewModelsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentPlanViewModelsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Academic/StudentPlanViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _db.StudentPlanViewModel.ToListAsync());
        }

        // GET: Academic/StudentPlanViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentPlanViewModel = await _db.StudentPlanViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentPlanViewModel == null)
            {
                return NotFound();
            }

            return View(studentPlanViewModel);
        }

        // GET: Academic/StudentPlanViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Academic/StudentPlanViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] StudentPlanViewModel studentPlanViewModel)
        {
            if (ModelState.IsValid)
            {
                _db.Add(studentPlanViewModel);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentPlanViewModel);
        }

        // GET: Academic/StudentPlanViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentPlanViewModel = await _db.StudentPlanViewModel.FindAsync(id);
            if (studentPlanViewModel == null)
            {
                return NotFound();
            }
            return View(studentPlanViewModel);
        }

        // POST: Academic/StudentPlanViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] StudentPlanViewModel studentPlanViewModel)
        {
            if (id != studentPlanViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(studentPlanViewModel);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentPlanViewModelExists(studentPlanViewModel.Id))
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
            return View(studentPlanViewModel);
        }

        // GET: Academic/StudentPlanViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentPlanViewModel = await _db.StudentPlanViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentPlanViewModel == null)
            {
                return NotFound();
            }

            return View(studentPlanViewModel);
        }

        // POST: Academic/StudentPlanViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentPlanViewModel = await _db.StudentPlanViewModel.FindAsync(id);
            _db.StudentPlanViewModel.Remove(studentPlanViewModel);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentPlanViewModelExists(int id)
        {
            return _db.StudentPlanViewModel.Any(e => e.Id == id);
        }
    }
}
