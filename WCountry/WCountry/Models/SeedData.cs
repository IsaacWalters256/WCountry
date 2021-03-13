using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WCountry.Repos;

namespace WCountry.Models
{
    public class SeedData
    {
        public static void Seed(WShopContext context, UserManager<WCitizen> userManager, RoleManager<IdentityRole> roleManager)
        {

            if (!context.WShops.Any())
            {
                //create member role
                var result = roleManager.CreateAsync(new IdentityRole("Member")).Result;
                result = roleManager.CreateAsync(new IdentityRole("VIP")).Result;
                result = roleManager.CreateAsync(new IdentityRole("Admin")).Result;

                WCitizen emmaNioson = new WCitizen { UserName = "FunChaserSunny", Name = "Emma Nioson" };
                context.Users.Add(emmaNioson);
                WCitizen yuiNioson = new WCitizen { UserName = "Destroyer5757", Name = "Yui Nioson" };
                context.Users.Add(yuiNioson);


                WCitizen siteadmin = new WCitizen
                {
                    UserName = "Rii",
                    Name = "Tyger 12"
                };
                userManager.CreateAsync(siteadmin, "Qwerty1!").Wait();
                IdentityRole adminRole = roleManager.FindByNameAsync("Admin").Result;
                userManager.AddToRoleAsync(siteadmin, adminRole.Name);

                WShop wshop = new WShop
                {
                    WShopName = "A Tics Article",
                    Owner = emmaNioson
                };
                context.WShops.Add(wshop);

                context.SaveChanges(); // save all the data
            }
        }
    }
}