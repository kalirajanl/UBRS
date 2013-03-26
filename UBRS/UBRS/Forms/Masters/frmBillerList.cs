using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBRS.DAL;
using UBRS.Common;

namespace UBRS.Forms.Masters
{
    public partial class frmBillerList : BaseForm 
    {
        public frmBillerList() : base()
        {
            InitializeComponent();
            Form_Title = "Billers";
            this.Text = Form_Title;
            loadGrid();
        }

        private void loadGrid()
        {
            this.dgBillers.Left = 3;
            this.dgBillers.Top = 3;
            this.dgBillers.Height = this.Height - 75;
            this.dgBillers.Width = this.Width - 25;
            this.dgBillers.AutoGenerateColumns = false;
            this.dgBillers.DataSource = DALBiller.GetBillers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBillerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditBiller childform = new frmEditBiller(PageMode.Add);
            childform.ShowDialog();
            loadGrid();
        }

        private void editBillerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgBillers.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                frmEditBiller childform = new frmEditBiller(PageMode.Edit);
                childform.ItemID = Convert.ToInt32(this.dgBillers.CurrentRow.Cells[0].Value);
                childform.ShowDialog();
                loadGrid();
            }
        }

        private void deleteBillerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgBillers.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                int billerID = Convert.ToInt32(this.dgBillers.CurrentRow.Cells[0].Value);
                DALBiller.DeleteBiller(billerID);
                loadGrid();
            }
        }
    }
}
