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
    public partial class CtrlMonthlyView : BaseUserControl
    {

        private DateTime _currentDate;



        public CtrlMonthlyView()
        {
            InitializeComponent();
            _currentDate = DateTime.Today;
        }

        public DateTime CurrentDate
        {
            get
            {
                return _currentDate;
            }
            set
            {
                _currentDate = UBRSValidators.StartOfMonth(value);
            }
        }

        private void initPage()
        {
            this.Controls.Clear();

            DateTime startDate = _currentDate;
            DateTime endDate = UBRSValidators.EndOfMonth(startDate);

            DateTime runningDate = startDate;

            int ctrlWidth = 170;
            int ctrlHeight = 100;
            int startPosition = 0;

            switch (startDate.DayOfWeek)
            {
                case DayOfWeek.Monday: { startPosition = 0; break; }
                case DayOfWeek.Tuesday: { startPosition = 1; break; }
                case DayOfWeek.Wednesday: { startPosition = 2; break; }
                case DayOfWeek.Thursday: { startPosition = 3; break; }
                case DayOfWeek.Friday: { startPosition = 4; break; }
                case DayOfWeek.Saturday: { startPosition = 5; break; }
                case DayOfWeek.Sunday: { startPosition = 6; break; }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    string ctrlName = "bill" + i.ToString() + "_" + j.ToString();
                    int top = (i * (ctrlHeight + 5));
                    int left = (j * (ctrlWidth + 3)) + ((j) * 3) + 3;

                    if (i == 0)
                    {
                        if (j >= startPosition)
                        {
                            addControl(runningDate, ctrlName, top, left, ctrlWidth, ctrlHeight);
                            runningDate = runningDate.AddDays(1);
                        }
                    }
                    else
                    {
                        if (runningDate <= endDate)
                        {
                            addControl(runningDate, ctrlName, top, left, ctrlWidth, ctrlHeight);
                            runningDate = runningDate.AddDays(1);
                        }
                    }
                }
            }
        }

        private void addControl(DateTime forDate, string ctrlName, int top, int left, int width, int height)
        {
            RichTextBox bill = new RichTextBox();
            bill.Name = ctrlName;
            bill.ReadOnly = true;
            bill.Top = top;
            bill.Left = left;
            bill.Width = width;
            bill.Height = height;
            bill.Multiline = true;
            bill.Font = new Font("Consolas", 8, FontStyle.Bold);
            bill.Rtf = getBillString(forDate);
            this.Controls.Add(bill);
        }

        private string getBillString(DateTime forDate)
        {
            StringBuilder sbBills = new StringBuilder();
            sbBills.AppendLine("{\\rtf1\\ansi\\deff0");
            sbBills.AppendLine("{\\colortbl;\\red0\\green0\\blue0;\\red0\\green0\\blue255;}");
            sbBills.AppendLine("{\\qr\\tab\\tab\\tab\\cf2");
            sbBills.AppendLine(forDate.ToString("dd"));
            sbBills.AppendLine("}");
            sbBills.AppendLine("\\line\\line");
            List<BillInstanceItem> bills = DALBillInstance.GetBillsByDate(forDate);
            for (int i = 0; i <= bills.Count - 1; i++)
            {
                sbBills.AppendLine(bills[i].BillerName.Trim().PadRight(13) + " - " + bills[i].Amount.ToString("#0.00").PadLeft(10));
                sbBills.AppendLine("\\line");
            }
            sbBills.AppendLine("}");
            return sbBills.ToString();
        }

        public void LoadBills()
        {
            initPage();
        }
    }
}
