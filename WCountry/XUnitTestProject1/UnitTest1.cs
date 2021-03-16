using System;
using Xunit;
using WCountry.Controllers;
using WCountry.Models;
using WCountry.Repos;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void AddWShopTest()
        {
            var fakeRepo = new FakeRepo();
            var wshop = new WShop() { WShopName = "Name", Owner = new WCitizen() { Name = "John", UserName = "John" } };

            fakeRepo.AddWShop(wshop);

            var retrievedWShop = fakeRepo.wshops.ToList()[0];
            Assert.Equal(0, wshop.WShopName.CompareTo(retrievedWShop.WShopName));
        }

        [Fact]
        public void GetByNameTest()
        {
            var fakeRepo = new FakeRepo();
            var wshop = new WShop() { WShopName = "Name", Owner = new WCitizen() { Name = "John", UserName = "John" } };

            fakeRepo.AddWShop(wshop);

            var retrievedWShop = fakeRepo.GetWShopByName("Name");
            Assert.Equal(0, wshop.WShopName.CompareTo(retrievedWShop.WShopName));
        }

        [Fact]
        public void GetByOwnerTest()
        {
            var fakeRepo = new FakeRepo();
            var wshop = new WShop() { WShopName = "Name", Owner = new WCitizen() { Name = "John", UserName = "John" } };

            fakeRepo.AddWShop(wshop);

            var retrievedWShop = fakeRepo.GetWShopByOwner("John");
            Assert.Equal(0, wshop.WShopName.CompareTo(retrievedWShop.WShopName));
        }
    }
}
