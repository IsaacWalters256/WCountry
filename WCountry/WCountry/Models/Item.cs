using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WCountry.Models
{
    public class Item
    {
        public WCitizen Owner { get; set; }
        [Key]
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public bool IsInShop { get; set; }
        public int ItemPrice { get; set; }
    }
}
