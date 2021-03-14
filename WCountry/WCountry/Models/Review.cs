using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WCountry.Models
{
    public class Review
    {
        [Key]
        public int ResponseID { get; set; }
        public int ReviewNumber { get; set; }
        public WCitizen Reviewer { get; set; }
    }
}
