using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WCountry.Models
{
    public class ReviewVM
    {
        public string WShopName { get; set; }//TODO this is broken, I think it only gives zeros and doesnt accually attach them to the store
        public int ReviewNumber { get; set; }
        public String ReviewerName { get; set; }
    }
}
