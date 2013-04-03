using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UBRS.Models
{
    public class BillInstanceItem
    {
        public long ID { get; set; }
        public long BillID { get; set; }
        public string BillerName { get; set; }
        public string BillTitle { get; set; }
        public DateTime InstanceDate { get; set; }
        public bool IsCompleted { get; set; }
        public decimal Amount { get; set; }
    }
}
