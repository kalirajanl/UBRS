using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBRS.Common;
using UBRS.Models;
using UBRS.DAL;

namespace UBRS.Forms.Common
{
    public partial class frmRecur : Form
    {
        public frmRecur()
        {
            this.Height = 400;
            this.Width = 400;
            InitializeComponent();
            initFormContent();
        }

        private void initFormContent()
        {
            this.gbMonthly.Top = this.gbDaily.Top;
            this.gbWeekly.Top = this.gbDaily.Top;
            this.gbYearly.Top = this.gbDaily.Top;
            this.gbMonthly.Left = this.gbDaily.Left;
            this.gbWeekly.Left = this.gbDaily.Left;
            this.gbYearly.Left = this.gbDaily.Left;
            this.dtpStartDate.Value = DateTime.Today;
            this.dtpEndDate.Value = DateTime.Today;
            this.txtDlyUnits.Text = "1";
            this.txtMlyOnDay.Text = this.dtpStartDate.Value.Day.ToString();
            this.txtMlyUnits.Text = "1";
            this.txtWlyUnits.Text = "1";
            this.txtYlyOnDay.Text = this.dtpStartDate.Value.Day.ToString();
            this.cboYlyOnMonth.SelectedIndex = this.dtpStartDate.Value.Month;
            this.txtYlyUnits.Text = "1";
            this.chkFriday.Checked = true;
            this.chkMonday.Checked = true;
            this.chkSaturday.Checked = false;
            this.chkSunday.Checked = false;
            this.chkThursday.Checked = true;
            this.chkTuesday.Checked = true;
            this.chkWednesday.Checked = true;

            this.rdobtnDlyUnits.Checked = true;

            this.rdobtnDaily.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.gbDaily.Visible = true;
            this.gbWeekly.Visible = false;
            this.gbMonthly.Visible = false;
            this.gbYearly.Visible = false;
        }

        private void rdobtnWeekly_CheckedChanged(object sender, EventArgs e)
        {
            this.gbDaily.Visible = false;
            this.gbWeekly.Visible = true;
            this.gbMonthly.Visible = false;
            this.gbYearly.Visible = false;
        }

        private void rdobtnMonthly_CheckedChanged(object sender, EventArgs e)
        {
            this.gbDaily.Visible = false;
            this.gbWeekly.Visible = false;
            this.gbMonthly.Visible = true;
            this.gbYearly.Visible = false;
        }

        private void rdobtnYearly_CheckedChanged(object sender, EventArgs e)
        {
            this.gbDaily.Visible = false;
            this.gbWeekly.Visible = false;
            this.gbMonthly.Visible = false;
            this.gbYearly.Visible = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ISchedule sched = loadSchedule();
            if (this.Parent != null)
                this.Parent.Tag = "Ok";
            this.Hide();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            this.Parent.Tag = "Cancel";
            this.Hide();
            this.Close();
        }

        private ISchedule loadSchedule()
        {
            ISchedule sched = null;
            if (this.rdobtnDaily.Checked)
            {
                DailySchedule dSched = new DailySchedule();
                dSched.EndDate = this.dtpEndDate.Value;
                dSched.RecurrencePattern = UBRS.Common.SchedRecurPatterns.Daily;
                dSched.RecurrencePatternMode = UBRS.Common.SchedRecurPatternModes.Simple;
                dSched.StartDate = this.dtpStartDate.Value;
                if (this.rdobtnDlyWeekdaysOnly.Checked)
                {
                    dSched.RecurEveryNoOfDays = 1;
                }
                else
                {
                    dSched.RecurEveryNoOfDays = Convert.ToInt32(this.txtDlyUnits.Text);
                }
                dSched.WeekDaysOnly = this.rdobtnDlyWeekdaysOnly.Checked;

                sched = dSched;
            }
            else if (this.rdobtnWeekly.Checked)
            {
                WeeklySchedule wSched = new WeeklySchedule();
                wSched.RecurrencePattern = SchedRecurPatterns.Weekly;
                wSched.RecurrencePatternMode = SchedRecurPatternModes.Simple;
                wSched.EndDate = this.dtpEndDate.Value;
                wSched.EndDateSpecifiedAs = SchedRangeEndTypes.ByEndDate;
                wSched.OnFridays = this.chkFriday.Checked;
                wSched.OnMondays = this.chkMonday.Checked;
                wSched.OnSaturdays = this.chkSaturday.Checked;
                wSched.OnSundays = this.chkSunday.Checked;
                wSched.OnThursdays = this.chkThursday.Checked;
                wSched.OnTuesdays = this.chkTuesday.Checked;
                wSched.OnWednesdays = this.chkWednesday.Checked;
                wSched.RecurEveryNoOfWeeks = Convert.ToInt32(this.txtWlyUnits.Text);
                wSched.StartDate = this.dtpStartDate.Value;
                sched = wSched;
            }
            else if (this.rdobtnMonthly.Checked)
            {
                MonthlySchedule mSched = new MonthlySchedule();
                mSched.RecurrencePattern = SchedRecurPatterns.Monthly;
                mSched.RecurrencePatternMode = SchedRecurPatternModes.Simple;
                mSched.EndDate = this.dtpEndDate.Value;
                mSched.EndDateSpecifiedAs = SchedRangeEndTypes.ByEndDate;
                mSched.OnDay = Convert.ToInt32(this.txtMlyOnDay.Text);
                mSched.RecurEveryNoOfMonths = Convert.ToInt32(this.txtMlyUnits.Text);
                mSched.StartDate = this.dtpStartDate.Value;
                sched = mSched;
            }
            else
            {
                YearlySchedule ySched = new YearlySchedule();
                ySched.EndDate = this.dtpEndDate.Value;
                ySched.EndDateSpecifiedAs = SchedRangeEndTypes.ByEndDate;
                ySched.OnDay = Convert.ToInt32(this.txtYlyOnDay.Text);
                ySched.OnMonth = Convert.ToInt32(this.cboYlyOnMonth.SelectedIndex);
                ySched.RecurEveryNoOfYears = Convert.ToInt32(this.txtYlyUnits.Text);
                ySched.RecurrencePattern = SchedRecurPatterns.Yearly;
                ySched.RecurrencePatternMode = SchedRecurPatternModes.Advanced;
                ySched.StartDate = this.dtpStartDate.Value;
                sched = ySched;
            }

            return sched;
        }

        private void btnRemoveRecurrance_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
                this.Parent.Tag = "Remove";
            this.Hide();
            this.Close();
        }
    }
}
