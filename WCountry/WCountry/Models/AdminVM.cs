﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WCountry.Models
{
    public class AdminVM
    {
        public IEnumerable<WCitizen> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
