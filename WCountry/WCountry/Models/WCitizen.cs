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

        [NotMapped]
        public IList<string> RoleNames { get; set; }
    }
}
