using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBRS.Models
{
    public class BillInstanceItem
    {
        public long ID { get; set; }
        public long BillID { get; set; }
        public DateTime InstanceDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
