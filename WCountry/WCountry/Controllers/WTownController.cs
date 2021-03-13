using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        public WTownController(IWShops r, UserManager<WCitizen> u)
        {
            //context = c;
            repo = r;
            userManager = u;

        }

        public IActionResult Index()
        {
            List<WShop> wshops = repo.WShop.ToList<WShop>();
            
            return View(wshops);
        }

        [HttpPost]
        public IActionResult Index(string owner)//, string shopName)
        {
            List<WShop> wshops = null;

            if (owner != null)//messageSender != "" && 
            {
                wshops = (from m in repo.WShop
                          where m.Owner.Name == owner
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

        [Authorize]
        public IActionResult CreateWShop()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateWShop(WShop model)
        {

            model.Owner = userManager.GetUserAsync(User).Result;
            //model.TownLocation = userManager.GetUserAsync(User).Result.TownResidence;


            repo.AddWShop(model);

            return RedirectToAction("Index", "WTown");
        }

        [Authorize]
        public IActionResult CreateItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateItem(Item model)
        {

            model.Owner = userManager.GetUserAsync(User).Result;
            model.IsInShop = false;

            repo.AddItem(model);
            return RedirectToAction("Index", "WTown");
        }

        public IActionResult ViewWShop(string wshopName)
        {
            //var wshopVM = new WShopVM { WShopName = wshopName };
            WShop wshop = repo.GetWShopByName(wshopName);
            return View(wshop);
        }


    }
}
