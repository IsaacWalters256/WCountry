using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WCountry.Models
{
    public class BlenderVM
    {
        public int SiteVariation { get; set; }
        public int UserAnswer1 { get; set; }
        public int UserAnswer2 { get; set; }

        public void CreateBackground()
        {
            SiteVariation = UserAnswer1 + UserAnswer2;
            /*if (UserAnswer1 == 1 && UserAnswer2 == 2 || UserAnswer1 == 2 && UserAnswer2 == 1)
            {
                //SiteVariation = "~/css/site1.css";
            }
            else if (UserAnswer1 == 2 && UserAnswer2 == 3 || UserAnswer1 == 3 && UserAnswer2 == 2)
            {
                //SiteVariation = "~/css/site2.css";
            }
            else if (UserAnswer1 == 1 && UserAnswer2 == 3 || UserAnswer1 == 3 && UserAnswer2 == 1)
            {
                //SiteVariation = "~/css/site3.css";
            }*/
        }
    }
}
