using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WCountry.Models;
using WCountry.Repos;

namespace WCountry.Controllers
{
    public class WTownController : Controller
    {
        IWShops repo;
        UserManager<WCitizen> userManager;

        public IActionResult Index()
        {
            List<WShop> wshops = repo.WShop.ToList<WShop>();
            
            return View(wshops);
        }

        [HttpPost]
        public IActionResult Messages(string owner, string wtown)//, string shopName)
        {
            List<WShop> wshops = null;

            if (owner != null)//messageSender != "" && 
            {
                wshops = (from m in repo.WShop
                          where m.Owner.Name == owner
                          select m).ToList();
            }
            else if (wtown != null)
            {
                wshops = (from m in repo.WShop
                          where m.TownLocation.TownName == wtown
                          select m).ToList();
            }
            //else if (shopName != null)
            //{
            //    shopName = (from m in repo.WShop
            //                where m.WShopName == shopName
            //                select m).ToList();
            //}
            return View(wshops);
        }

        public IActionResult CreateWShop()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateWShop(WShop model)
        {

            model.Owner = userManager.GetUserAsync(User).Result;
            //model.TownLocation = userManager.GetUserAsync(User).Result.TownResidence;
            model.TownLocation = (from m in repo.WTown
                                  where m.TownName == "Wenchester"
                                  select m).First();


            repo.AddWShop(model);

            return View(model);
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
