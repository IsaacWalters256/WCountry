using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WCountry.Models;

namespace WCountry.Repos
{
    public interface IWShops
    {
        IQueryable<WShop> WShop { get; }

        void AddWShop(WShop wshop);
        void AddItem(Item item);
        WShop GetWShopByName(string name);
        WShop GetWShopByOwner(string name);
        void UpdateWShop(WShop wshop);
        List<WShop> GetAllWShops();
        List<Item> GetAllItems();
        int AddReviews(List<Review> reviews);

    }
}
