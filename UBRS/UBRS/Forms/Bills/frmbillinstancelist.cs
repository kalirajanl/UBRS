using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBRS.Models;
using UBRS.DAL;
using UBRS.Common;

namespace UBRS.Forms.Bills
{

    public enum BillInstancePageMode
    {
        UpcomingBills = 1,
        DueBills = 2,
        OverdueBills = 3
    }

    public partial class frmbillinstancelist : BaseForm
    {


        public frmbillinstancelist(BillInstancePageMode pageMode)
        {
            InitializeComponent();
            this.Text = Form_Title;
            CurrentPageMode = pageMode;
            switch (CurrentPageMode)
            {
                case BillInstancePageMode.DueBills:
                    {
                        Form_Title = "Bills Due";
                        break;
                    }
                case BillInstancePageMode.OverdueBills:
                    {
                        Form_Title = "Bills Overdue";
                        break;
                    }
                case BillInstancePageMode.UpcomingBills:
                    {
                        Form_Title = "Upcoming Bills";
                        break;
                    }
            }
            this.Text = Form_Title;
            this.dtpAsofDate.Value = DateTime.Today;
        }

        public BillInstancePageMode CurrentPageMode;

        private void loadGrid()
        {
            this.dgBills.Left = 3;
            this.dgBills.Top = 50;
            this.dgBills.Height = this.Height - 125;
            this.dgBills.Width = this.Width - 25;
            this.dgBills.AutoGenerateColumns = false;
            List<BillInstanceItem> data = null;
            switch (CurrentPageMode)
            {
                case BillInstancePageMode.DueBills:
                    {
                        data = DALBillInstance.GetDueBills(this.dtpAsofDate.Value);
                        break;
                    }
                case BillInstancePageMode.OverdueBills:
                    {
                        data = DALBillInstance.GetOverDueBills(this.dtpAsofDate.Value);
                        break;
                    }
                default:
                    {
                        data = DALBillInstance.GetUpcomingBills(this.dtpAsofDate.Value);
                        break;
                    }
            }
            this.dgBills.DataSource = data;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpAsofDate_ValueChanged(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void markCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgBills.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                long billinstanceID = Convert.ToInt32(this.dgBills.CurrentRow.Cells[0].Value);
                DALBillInstance.MarkAsCompleted(billinstanceID);
                loadGrid();
            }
        }

    }
}
