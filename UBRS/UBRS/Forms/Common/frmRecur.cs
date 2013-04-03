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

        public DateTime StartDate
        {
            get
            {
                return this.dtpStartDate.Value;
            }
            set
            {
                this.dtpStartDate.Value = value;
            }
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
            this.Tag = "OK";
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Tag = "Cancel";
            this.Hide();
        }

        public void LoadSchedule(ISchedule sched)
        {
            if (sched != null)
            {
                if (sched.GetType() == typeof(WeeklySchedule))
                {
                    WeeklySchedule wSched = (WeeklySchedule)sched;
                    this.rdobtnWeekly.Checked = true;
                    this.dtpStartDate.Value = wSched.StartDate;
                    this.dtpEndDate.Value = wSched.EndDate;
                    this.chkFriday.Checked = wSched.OnFridays;
                    this.chkMonday.Checked = wSched.OnMondays;
                    this.chkSaturday.Checked = wSched.OnSaturdays;
                    this.chkSunday.Checked = wSched.OnSundays;
                    this.chkThursday.Checked = wSched.OnThursdays;
                    this.chkTuesday.Checked = wSched.OnTuesdays;
                    this.chkWednesday.Checked = wSched.OnWednesdays;
                    this.txtWlyUnits.Text = wSched.RecurEveryNoOfWeeks.ToString();
                }
                else if (sched.GetType() == typeof(MonthlySchedule))
                {
                    MonthlySchedule mSched = (MonthlySchedule)sched;
                    this.rdobtnMonthly.Checked = true;
                    this.dtpStartDate.Value = mSched.StartDate;
                    this.dtpEndDate.Value = mSched.EndDate;
                    this.txtMlyOnDay.Text = mSched.OnDay.ToString();
                    this.txtMlyUnits.Text = mSched.RecurEveryNoOfMonths.ToString();
                }
                else if (sched.GetType() == typeof(YearlySchedule))
                {
                    YearlySchedule ySched = (YearlySchedule)sched;
                    this.rdobtnYearly.Checked = true;
                    this.dtpStartDate.Value = ySched.StartDate;
                    this.dtpEndDate.Value = ySched.EndDate;
                    this.txtYlyOnDay.Text = ySched.OnDay.ToString();
                    this.cboYlyOnMonth.SelectedIndex = Convert.ToInt32(ySched.OnMonth);
                    this.txtYlyUnits.Text = ySched.RecurEveryNoOfYears.ToString();
                }
                else
                {
                    DailySchedule dSched = (DailySchedule)sched;
                    this.rdobtnDaily.Checked = true;
                    this.dtpStartDate.Value = dSched.StartDate;
                    this.dtpEndDate.Value = dSched.EndDate;
                    this.txtDlyUnits.Text = dSched.RecurEveryNoOfDays.ToString();
                    this.rdobtnDlyWeekdaysOnly.Checked = dSched.WeekDaysOnly;
                }
            }
        }

        public ISchedule GetSchedule()
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
            this.Tag = "Remove";
            this.Hide();
        }
    }
}
