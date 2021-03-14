using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WCountry.Models
{
    public class WShop
    {
        private List<Review> reviews = new List<Review>();
        [Key]
        public string WShopName { get; set; }
        public WCitizen Owner { get; set; }
        public IList<Item> SaleItems { get; set; }
        public IList<Review> Reviews { get { return reviews; } }
        
    }
}
