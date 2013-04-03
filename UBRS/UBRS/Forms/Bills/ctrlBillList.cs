using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBRS.DAL;
using UBRS.Models;
using UBRS.Common;

namespace UBRS.Forms.Bills
{
    public partial class ctrlBillList : BaseUserControl
    {

        private DateTime _currentDate;
        
        public ctrlBillList()
        {
            InitializeComponent();
        }

        public ctrlBillList(DateTime asofdate )
        {
            InitializeComponent();
            _currentDate = asofdate;
        }

        public DateTime CurrentDate
        {
            get
            {
                return _currentDate;
            }
            set
            {
                _currentDate = value;
            }
        }

        public void LoadBills()
        {
            this.dgBills.Left = 0;
            this.dgBills.Top = 30;
            this.dgBills.Height = this.Height - 35;
            this.dgBills.Width = this.Width - 5;
            this.dgBills.AutoGenerateColumns = false;
            this.dgBills.DataSource = DALBillInstance.GetBillsByDate(CurrentDate);
            Form_Title = "Bills";
        }

        private void markCompleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgBills.CurrentRow == null)
            {
                ShowError("Please select a row.", Form_Title);
            }
            else
            {
                BillInstanceItem billinstance = ((List<BillInstanceItem>)this.dgBills.DataSource)[this.dgBills.CurrentRow.Index];
                if (billinstance.IsCompleted)
                {
                    DALBillInstance.MarkAsNotCompleted(billinstance.ID);
                }
                else
                {
                    DALBillInstance.MarkAsCompleted(billinstance.ID);
                }
                LoadBills();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.dgBills.CurrentRow == null)
            {
                this.markCompleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                BillInstanceItem billinstance = ((List<BillInstanceItem>)this.dgBills.DataSource)[this.dgBills.CurrentRow.Index];
                if (billinstance.IsCompleted)
                {
                    this.markCompleteToolStripMenuItem.Text = "Mark As Incomplete";
                }
                else
                {
                    this.markCompleteToolStripMenuItem.Text = "Mark As Complete";
                }
            }
        }

        private void dgBills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgBills.Rows[e.RowIndex].Cells[1] != null)
            {
                Font tn = e.CellStyle.Font;
                if (tn == null)
                {
                    tn = this.dgBills.Font;
                }
                if (tn == null)
                {
                    tn = new Font("Arial", 12);
                }
                List<BillInstanceItem> bills = (List<BillInstanceItem>)this.dgBills.DataSource;
                if (bills[e.RowIndex].IsCompleted)
                {
                    tn = new Font(tn.FontFamily, tn.SizeInPoints, FontStyle.Strikeout);
                }
                e.CellStyle.Font = tn;
            }
        }
    }
}
