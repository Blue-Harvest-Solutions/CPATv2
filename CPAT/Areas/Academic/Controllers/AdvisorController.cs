using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CPAT.Areas.Academic.Controllers
{
    [Area("Academic")]
    public class AdvisorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }
    }
}