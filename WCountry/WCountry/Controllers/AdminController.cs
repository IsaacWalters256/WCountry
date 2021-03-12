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
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserManager<WCitizen> userManager;
        private RoleManager<IdentityRole> roleManager;
        private IWShops repo;

        public AdminController(UserManager<WCitizen> userMngr,
                               RoleManager<IdentityRole> roleMngr,
                               IWShops r)
        {
            userManager = userMngr;
            roleManager = roleMngr;
            repo = r;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ManagePeople()
        {
            List<WCitizen> users = new List<WCitizen>();
            foreach (WCitizen user in userManager.Users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                users.Add(user);
            }

            AdminVM model = new AdminVM
            {
                Users = users, // List of WCitizen
                Roles = roleManager.Roles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteWCitizen(string id)
        {
            IdentityResult result = null;
            WCitizen user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (0 == (from r in repo.WShop
                          where r.Owner.Name == user.Name
                          select r).Count<WShop>())
                {

                    result = await userManager.DeleteAsync(user);
                }
                else
                {
                    result = IdentityResult.Failed(new IdentityError()
                    { Description = "User's WShops must be deleted first" });
                }

                if (!result.Succeeded)
                {
                    string errorMessage = "";
                    foreach (IdentityError error in result.Errors)
                    {
                        errorMessage += errorMessage != "" ? " | " : "";
                        errorMessage += error.Description;
                        //errorMessage += error.Description + " | ";
                    }
                    TempData["message"] = errorMessage;
                }
                else
                {
                    TempData["message"] = "";  // No errors, clear the message
                }
            }
            return RedirectToAction("ManagePeople");
        }

        [HttpPost]
        public async Task<IActionResult> AddToAdmin(string id)
        {
            IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                TempData["message"] = "Admin role does not exist.";
            }
            else
            {
                WCitizen user = await userManager.FindByIdAsync(id);
                await userManager.AddToRoleAsync(user, adminRole.Name);
            }
            return RedirectToAction("ManagePeople");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromAdmin(string id)
        {
            WCitizen user = await userManager.FindByIdAsync(id);
            var result = await userManager.RemoveFromRoleAsync(user, "Admin");
            if (result.Succeeded) { }
            return RedirectToAction("ManagePeople");
        }
    }
}
