using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBRS.Models;

namespace UBRS.DAL
{
    public class DALBill
    {
        public static List<BillItem> GetBillers()
        {
            List<BillItem> bills = new List<BillItem>();
            DataTable dt = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "Bill"}, 0);
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                BillItem bill = loadBill(dt, i);
                if (bill != null)
                {
                    bills.Add(bill);
                }
            }
            return bills;
        }

        private static BillItem loadBill(DataTable dt, int rowNo)
        {
            BillItem bill = null;
            if (dt != null)
            {
                if (dt.Rows.Count > rowNo)
                {
                    bill = new BillItem();
                    bill.ID = (long)dt.Rows[rowNo]["BillID"];
                    bill.StartDate = Convert.ToDateTime(dt.Rows[rowNo]["StartDate"]);
                    bill.FinishDate = Convert.ToDateTime(dt.Rows[rowNo]["FinishDate"]);
                    bill.Amount = Convert.ToDecimal(dt.Rows[rowNo]["BillAmount"]);
                    bill.Notes = dt.Rows[rowNo]["Notes"].ToString();
                    // to do load the schedule
                }
            }
            return bill;
        }
    }

}
