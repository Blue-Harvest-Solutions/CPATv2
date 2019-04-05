using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPAT.Data;
using CPAT.Models;
using CPAT.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CPAT.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class AdminUsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ApplicationDbContext _db;

        public AdminUsersController(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(_db.ApplicationUser.ToList());
        }

        //Get Edit
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || id.Trim().Length == 0)
            {
                return NotFound();
            }

            var userFromDb = await _db.ApplicationUser.FindAsync(id);
            if (userFromDb == null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                ApplicationUser userFromDb = _db.ApplicationUser.Where(u => u.Id == id).FirstOrDefault();
                userFromDb.Name = applicationUser.Name;
                userFromDb.IsAdvisor = applicationUser.IsAdvisor;
                userFromDb.IsSuperAdmin = applicationUser.IsSuperAdmin;

                if (!await _roleManager.RoleExistsAsync(SD.AdvisorEndUser))
                {
                    await _roleManager.CreateAsync(new IdentityRole(SD.AdvisorEndUser));
                }
                if (!await _roleManager.RoleExistsAsync(SD.SuperAdminEndUser))
                {
                    await _roleManager.CreateAsync(new IdentityRole(SD.SuperAdminEndUser));
                }
                if (!await _roleManager.RoleExistsAsync(SD.RegularEndUser))
                {
                    await _roleManager.CreateAsync(new IdentityRole(SD.RegularEndUser));
                }


                await _userManager.RemoveFromRoleAsync(userFromDb, SD.SuperAdminEndUser);
                await _userManager.RemoveFromRoleAsync(userFromDb, SD.AdvisorEndUser);

                if (userFromDb.IsSuperAdmin)
                {
                    await _userManager.AddToRoleAsync(userFromDb, SD.SuperAdminEndUser);
                }
                if (userFromDb.IsAdvisor)
                {
                    await _userManager.AddToRoleAsync(userFromDb, SD.AdvisorEndUser);
                }
                if (!userFromDb.IsAdvisor || !userFromDb.IsSuperAdmin)
                {
                    //var roles = await _userManager.GetRolesAsync(userFromDb);
                    await _userManager.AddToRoleAsync(userFromDb, SD.RegularEndUser);
                }


                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(applicationUser);
        }

        //Get Delete
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || id.Trim().Length == 0)
            {
                return NotFound();
            }

            var userFromDb = await _db.ApplicationUser.FindAsync(id);
            if (userFromDb == null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }

        //Post Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(string id)
        {
            ApplicationUser userFromDb = _db.ApplicationUser.Where(u => u.Id == id).FirstOrDefault();
            userFromDb.LockoutEnd = DateTime.Now.AddYears(1000);

            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}