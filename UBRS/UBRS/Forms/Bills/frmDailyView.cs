using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UBRS.Models;
using UBRS.DAL;
using UBRS.Common;

namespace UBRS.Forms.Bills
{
    public partial class frmDailyView : BaseForm
    {
        public frmDailyView()
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
            this.Height = 593;
            this.Width = 378;
            this.dtpCurrentDate.Value = DateTime.Today;
            this.Text = "Bill Calendar - Daily View";
            Form_Title = "Daily View";
        }

        private void initPage()
        {
            this.ctrlBillList1.Top = 30;
            this.ctrlBillList1.Left = 9;
            this.ctrlBillList1.Height = this.Height - 70;
            this.ctrlBillList1.Width = 350;
            this.ctrlBillList1.CurrentDate = this.dtpCurrentDate.Value;
            this.ctrlBillList1.LoadBills();
        }

        private void dtpCurrentDate_ValueChanged(object sender, EventArgs e)
        {
            initPage();
        }
    }
}
