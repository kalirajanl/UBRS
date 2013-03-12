using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBRS.Models
{
    public class BillItem
    {
        public long ID { get; set; }
        public BillerItem Biller { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ISchedule BillSchedule { get; set; }
    }
}
