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
    public partial class frmBillList : BaseForm 
    {
        public frmBillList() : base()
        {
            InitializeComponent();
            Form_Title = "Bills";
            this.Text = Form_Title;
            loadGrid();
        }

        private void loadGrid()
        {
            this.dgBills.Left = 3;
            this.dgBills.Top = 3;
            this.dgBills.Height = this.Height - 75;
            this.dgBills.Width = this.Width - 25;
            this.dgBills.AutoGenerateColumns = false;
            this.dgBills.DataSource = DALBill.GetBills();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditBill childform = new frmEditBill(PageMode.Add);
            childform.ShowDialog();
            loadGrid();
        }

        private void editBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgBills.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                frmEditBill childform = new frmEditBill(PageMode.Edit);
                childform.ItemID = Convert.ToInt32(this.dgBills.CurrentRow.Cells[0].Value);
                childform.ShowDialog();
                loadGrid();
            }
        }

        private void deleteBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgBills.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                int billID = Convert.ToInt32(this.dgBills.CurrentRow.Cells[0].Value);
                DALBill.DeleteBill(billID);
                loadGrid();
            }
        }
    }
}
