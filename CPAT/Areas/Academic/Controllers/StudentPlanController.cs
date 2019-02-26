using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPAT.Models;
using CPAT.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPAT.Areas.Academic.Controllers
{
    [Area("Academic")]
    public class StudentPlanController : Controller
    {

        private readonly ApplicationDbContext _db;

        public StudentPlanController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: StudentPlan
        public async Task<IActionResult> Index(string searchString)
        {
            var student = from s in _db.Students
                          select s;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                student = student.Where(s => s.LastName.StartsWith(searchString));
                //studentId = student.Select(id => id.Id);
            }

            return RedirectToAction(nameof(Details), await student.FirstOrDefaultAsync());//
        }

        // GET: StudentPlan/Details/5
        public ActionResult Details(Students student)//int id
        {
            return View();
        }

        // GET: StudentPlan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentPlan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentPlan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentPlan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentPlan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentPlan/Delete/5
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