using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UBRS.Forms.Masters;


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

        private void billsOverDueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void monthlyToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void AppMDI_Load(object sender, EventArgs e)
        {
            billsToolStripMenuItem_Click(null, null);
        }
    }
}
