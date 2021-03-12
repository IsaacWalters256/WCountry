using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WCountry.Models
{
    public class WTown
    {
        [Key]
        public string TownName { get; set; }
        public WCitizen Mayor { get; set; }
        [Range(0, 50)]
        public int SalesTaxRed { get; set; }
        [Range(0, 50)]
        public int SalesTaxBlue { get; set; }
        [Range(0, 50)]
        public int SalesTaxGreen { get; set; }
        [Range(0, 50)]
        public int SalesTaxPurple { get; set; }
        [Range(0, 50)]
        public int SalesTaxYellow { get; set; }
        [Range(0, 50)]
        public int SalesTaxOrange { get; set; }
    }
}
