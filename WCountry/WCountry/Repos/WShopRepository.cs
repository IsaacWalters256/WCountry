using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WCountry.Models;

namespace WCountry.Repos
{
    public class WShopRepository : IWShops
    {
        private WShopContext context;
        public WShopRepository(WShopContext c)
        {
            context = c;
        }

        public IQueryable<WShop> WShop { get { return context.WShops.Include(wshops => wshops.Owner).Include(wshop => wshop.SaleItems).ThenInclude(item => item.Owner); } }

        public void AddItem(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
        }

        public void AddWShop(WShop wshop)
        {
            context.WShops.Add(wshop);
            context.SaveChanges();
        }

        public void AddWTown(WTown wtown)
        {
            context.WTowns.Add(wtown);
            context.SaveChanges();
        }

        public List<Item> GetAllItems()
        {
            return context.Items.Include(async => async.Owner).ToList();
        }

        public List<WShop> GetAllWShops()
        {
            return context.WShops.Include(async => async.Owner).ToList();
        }

        public List<WTown> GetAllWTowns()
        {
            return context.WTowns.Include(async => async.Mayor).ToList();
        }

        public WShop GetWShopByName(string name)
        {
            return (from r in context.WShops where r.WShopName == name select r).FirstOrDefault<WShop>();
        }

        public WShop GetWShopByOwner(string name)
        {
            return (from r in context.WShops where r.Owner.Name == name select r).FirstOrDefault<WShop>();
        }

        public void UpdateWShop(WShop wshop)
        {
            context.WShops.Update(wshop);
            context.SaveChanges();
        }
    }
}
