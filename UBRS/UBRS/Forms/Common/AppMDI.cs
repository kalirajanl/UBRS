using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UBRS.Forms.Masters;
using UBRS.Forms.Bills;

namespace UBRS
{
    public partial class AppMDI : BaseForm
    {
        About wndAbout;

        public AppMDI()
        {
            InitializeComponent();
            this.Text = ApplicationTitle;
            Form_Title = ApplicationTitle;
            this.Height = 697;
            this.Width = 1295;
            this.statusStrip.Text = "Welcome to " + ApplicationTitle;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wndAbout != null)
            {
                wndAbout.Close();
            }
            wndAbout = new About();
            wndAbout.MdiParent = this;
            wndAbout.BringToFront();
            wndAbout.Show();
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void monthlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthlyView wndMonthView = new frmMonthlyView();
            wndMonthView.ShowInTaskbar = false;
            wndMonthView.MdiParent = this;
            wndMonthView.CurrentDate = DateTime.Today;
            wndMonthView.BringToFront();
            wndMonthView.Show();
        }

        private void billersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBillerList frm = new frmBillerList();
            frm.MdiParent = this;
            frm.BringToFront();
            frm.Show();
        }


        private void billsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBillList frm = new frmBillList();
            frm.MdiParent = this;
            frm.BringToFront();
            frm.Show();
        }


        private void billsDueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmbillinstancelist frm = new frmbillinstancelist(BillInstancePageMode.DueBills);
            frm.MdiParent = this;
            frm.BringToFront();
            frm.Show();
        }

        private void upcomingBillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmbillinstancelist frm = new frmbillinstancelist(BillInstancePageMode.UpcomingBills);
            frm.MdiParent = this;
            frm.BringToFront();
            frm.Show();

        }

        private void billsOverDueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmbillinstancelist frm = new frmbillinstancelist(BillInstancePageMode.OverdueBills);
            frm.MdiParent = this;
            frm.BringToFront();
            frm.Show();
        }

        private void dailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDailyView frm = new frmDailyView();
            frm.MdiParent = this;
            frm.BringToFront();
            frm.Show();
        }

        private void weeklyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWeeklyView wndWeekView = new frmWeeklyView();
            wndWeekView.ShowInTaskbar = false;
            wndWeekView.MdiParent = this;
            wndWeekView.CurrentDate = DateTime.Today;
            wndWeekView.BringToFront();
            wndWeekView.Show();
        }

        private void billSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBillSummary wndBillSummary = new frmBillSummary();
            wndBillSummary.ShowInTaskbar = false;
            wndBillSummary.MdiParent = this;
            wndBillSummary.BringToFront();
            wndBillSummary.Show();
        }

        private void AppMDI_Load(object sender, EventArgs e)
        {
            monthlyToolStripMenuItem_Click(null, null);
        }

    }
}
