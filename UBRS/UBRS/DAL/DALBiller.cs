using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBRS.Models;

namespace UBRS.DAL
{
    public class DALBiller
    {
        public static List<BillerItem> GetBillers()
        {
            return new List<BillerItem>{
                new BillerItem { ID = 1, Name = "BSNL", City="Chennai", State = "TN", Country = "India", AddressLine1 = "", AddressLine2 = ""},
                new BillerItem { ID = 2, Name = "TWAD", City="Chennai", State = "TN", Country = "India", AddressLine1 = "", AddressLine2 = ""}
            };

        }

        public static BillerItem GetBiller(int billerID)
        {
            List<BillerItem> billers = GetBillers();
            return billers.FirstOrDefault(x => x.ID == billerID);
        }

    }
}
