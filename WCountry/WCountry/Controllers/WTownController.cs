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
            //int sum = repo.AddReviews()

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


        public IActionResult ViewItems()
        {
            List<Item> items = repo.GetAllItems();

            return View(items);
        }

        [HttpPost]
        public IActionResult ViewItems(string owner)
        {
            List<Item> items = null;

            if (owner != null)
            {
                items = (from m in repo.GetAllItems()
                         where m.Owner.Name == owner
                         select m).ToList();
            }

            return View(items);
        }

        [Authorize]
        public IActionResult ReviewPage(string wshopName)
        {
            var reviewVM = new ReviewVM { WShopName = wshopName };
            return View(reviewVM);
        }

        [HttpPost]
        public RedirectToActionResult ReviewPage(ReviewVM reviewVM)
        {
            var review = new Review { ReviewNumber = reviewVM.ReviewNumber };
            review.Reviewer = userManager.GetUserAsync(User).Result;
            review.Reviewer.Name = review.Reviewer.UserName;

            var wshop = (from r in repo.WShop where r.WShopName == reviewVM.WShopName select r).First<WShop>();

            wshop.Reviews.Add(review);
            repo.UpdateWShop(wshop);

            return RedirectToAction("Index");
        }
    }
}
