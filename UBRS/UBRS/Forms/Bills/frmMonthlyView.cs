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
    public partial class frmMonthlyView : BaseForm 
    {

        private bool _workweekonly;

        public frmMonthlyView()
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
            this.Height = 607;
            this.Width = 1274;
            this.Text = "Bills Calendar - Monthly View";
            Form_Title = "Monthly View";
            //this.dtpCurrentDate.Value = UBRSValidators.StartOfMonth(value);
        }

        public DateTime CurrentDate
        {
            get
            {
                return this.dtpCurrentDate.Value;
            }
            set
            {
                this.dtpCurrentDate.Value = UBRSValidators.StartOfMonth(value);
            }
        }

        public bool ShowWorkWeekOnly
        {
            get
            {
                return _workweekonly;
            }
            set
            {
                _workweekonly = value;
                if (value)
                {
                    this.Text = "Calendar - Work Week View";
                }
                else
                {
                    this.Text = "Calendar - Week View";
                }
            }
        }

        private void dtpCurrentDate_ValueChanged(object sender, EventArgs e)
        {
            //this.dtpCurrentDate.Value = MyPlannerValidators.StartOfWeek(this.dtpCurrentDate.Value, DayOfWeek.Monday);
            initPage();
        }

        private void initPage()
        {
            this.ctrlMonthlyView1.CurrentDate = UBRSValidators.StartOfWeek(this.dtpCurrentDate.Value, DayOfWeek.Monday);
            this.ctrlMonthlyView1.LoadBills();
        }

    }
}
