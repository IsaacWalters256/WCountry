using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WCountry.Models;

namespace WCountry.Repos
{
    public class FakeRepo : IWShops
    {
        public List<WShop> wshops = new List<WShop>();
        public IQueryable<WShop> WShop { get { return (IQueryable<WShop>)wshops; } }

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public int AddReviews(List<Review> reviews)
        {
            throw new NotImplementedException();
        }

        public void AddWShop(WShop wshop)
        {
            wshops.Add(wshop);
        }

        public List<Item> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public List<WShop> GetAllWShops()
        {
            return wshops;
        }

        public WShop GetWShopByName(string name)
        {
            return (from r in wshops where r.WShopName == name select r).FirstOrDefault<WShop>();
        }

        public WShop GetWShopByOwner(string name)
        {
            return (from r in wshops where r.Owner.Name == name select r).FirstOrDefault<WShop>();
        }

        public void UpdateWShop(WShop wshop)
        {
            throw new NotImplementedException();
        }
    }
}
