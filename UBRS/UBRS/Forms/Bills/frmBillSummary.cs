using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBRS.Models;
using UBRS.DAL;

namespace UBRS.Forms.Bills
{
    public partial class frmBillSummary : BaseForm 
    {
        public frmBillSummary()
        {
            InitializeComponent();
            Form_Title = "Bill Summary Report";
            this.Text = Form_Title;
            this.Top = 0;
            this.Height = 606;
            this.Width = 1274;
        }

        private void frmBillSummary_Load(object sender, EventArgs e)
        {
            initPage();
        }

        private void initPage()
        {
            loadBillers();
            this.dtpEndDate.Value = DateTime.Today;
            this.dtpStartDate.Value = this.dtpEndDate.Value.AddDays(-30);
            btnSave_Click(null, null);
            this.dtpStartDate.Focus();
        }

        private void loadBillers()
        {
            List<BillerItem> billers = DALBiller.GetBillers();
            billers.Insert(0, new BillerItem { ID = 0, Name = "All Billers" });
            this.cboBillers.DataSource = billers;
            this.cboBillers.ValueMember = "ID";
            this.cboBillers.DisplayMember = "Name";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            if (this.cboBillers.SelectedIndex == 0)
            {
                dt = DALBillInstance.GetBillsSummaryInDateRange(this.dtpStartDate.Value, this.dtpEndDate.Value);
                this.chrtReport.Series.Clear();
                this.chrtReport.Series.Add("Biller");
                this.chrtReport.Series["Biller"].SetDefault(true);
                this.chrtReport.Series["Biller"].Enabled = true;
                this.chrtReport.Series["Biller"].XValueMember = dt.Columns[0].ToString();
                this.chrtReport.Series["Biller"].YValueMembers = dt.Columns[1].ToString();
                this.chrtReport.Series["Biller"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                this.chrtReport.Width = 400;
            }
            else
            {
                dt = DALBillInstance.GetBillsSummaryByBiller(this.dtpStartDate.Value, this.dtpEndDate.Value, ((BillerItem)cboBillers.SelectedItem).ID);
                this.chrtReport.Series.Clear();
                this.chrtReport.Series.Add("Bill Date");
                this.chrtReport.Series["Bill Date"].SetDefault(true);
                this.chrtReport.Series["Bill Date"].Enabled = true;
                this.chrtReport.Series["Bill Date"].XValueMember = dt.Columns[0].ToString();
                this.chrtReport.Series["Bill Date"].YValueMembers = dt.Columns[1].ToString();
                this.chrtReport.Width = 1200;
            }

            this.chrtReport.DataSource = dt;
            this.chrtReport.DataBind();
                this.chrtReport.Visible = true;

        }

    }
}
