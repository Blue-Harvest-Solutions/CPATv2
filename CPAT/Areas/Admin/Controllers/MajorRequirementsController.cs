using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPAT.Data;
using CPAT.Models;
using Microsoft.AspNetCore.Http;
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
        public ActionResult Index()
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



        // GET: MajorRequirements/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MajorRequirements/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}