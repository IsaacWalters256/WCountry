using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WCountry.Models
{
    public class WShopContext : IdentityDbContext
    {
        public WShopContext(DbContextOptions<WShopContext> options) : base(options) { }
        public DbSet<WShop> WShops { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<WTown> WTowns { get; set; }

    }
}
