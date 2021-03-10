using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WCountry.Controllers
{
    public class WTownController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateWShop()
        {
            return View();
        }

        public IActionResult EditWShop()
        {
            return View();
        }

        public IActionResult ViewWShop()
        {
            return View();
        }
    }
}
