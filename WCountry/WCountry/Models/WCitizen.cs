using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WCountry.Models
{
    public class WCitizen : IdentityUser
    {
        [StringLength(60, MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        public int WDollars { get; set; }
        public string AvatarColor { get; set; }
        public IList<WShop> OwnedWShops { get; set; }
        public IList<Item> OwnedItems { get; set; }

        [NotMapped]
        public IList<string> RoleNames { get; set; }
    }
}
/*
Rii   Qwerty1!
Death     Death1!


*/