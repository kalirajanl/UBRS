using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UBRS.DAL;
using UBRS.Models;
using UBRS.Common;

namespace UBRS.Forms.Bills
{
    public partial class CtrlWeeklyView : BaseUserControl
    {

        private DateTime _currentDate;
        private bool _workweekonly;
        private int _basectrlWidth;

        public CtrlWeeklyView()
        {
            InitializeComponent();
            _workweekonly = false;
            _currentDate = DateTime.Today;
            _basectrlWidth = 170;
        }

        public DateTime CurrentDate
        {
            get
            {
                return _currentDate;
            }
            set
            {
                _currentDate = UBRSValidators.StartOfWeek(value, DayOfWeek.Monday);
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
            }
        }

        public int BillWidth
        {
            get
            {
                return _basectrlWidth;
            }
            set
            {
                _basectrlWidth = value;
            }
        }

        private void initPage()
        {
            this.Controls.Clear();

            int ctrlWidth = _basectrlWidth;
            if (_workweekonly)
            {
                ctrlWidth = _basectrlWidth  + Convert.ToInt32(Math.Ceiling((double)(_basectrlWidth * 2) / 5));
            }

            for (int i = 0; i < 7; i++)
            {
                if ((i < 5) || (!_workweekonly))
                {
                    ctrlBillList bill = new ctrlBillList(CurrentDate.AddDays(i));
                    bill.Name = "bill" + i.ToString();
                    bill.LoadBills();
                    bill.Top = 3;
                    bill.Left = (i * (ctrlWidth+3)) + ((i) * 3) + 3;
                    bill.Width = ctrlWidth;
                    this.Controls.Add(bill);
                }
            }
        }

        public void LoadBills()
        {
            initPage();
        }
    }
}
