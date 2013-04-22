namespace UBRS.Forms.Bills
{
    partial class frmBillSummary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboBillers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblToCaption = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromCaption = new System.Windows.Forms.Label();
            this.chrtReport = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtReport)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.cboBillers);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.lblToCaption);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Controls.Add(this.lblFromCaption);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 65);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::UBRS.Properties.Resources.report_go_16X16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(318, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 47);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "&View Report";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboBillers
            // 
            this.cboBillers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBillers.FormattingEnabled = true;
            this.cboBillers.Location = new System.Drawing.Point(72, 35);
            this.cboBillers.Name = "cboBillers";
            this.cboBillers.Size = new System.Drawing.Size(240, 21);
            this.cboBillers.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Biller : ";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(209, 9);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(103, 20);
            this.dtpEndDate.TabIndex = 22;
            // 
            // lblToCaption
            // 
            this.lblToCaption.AutoSize = true;
            this.lblToCaption.Location = new System.Drawing.Point(180, 13);
            this.lblToCaption.Name = "lblToCaption";
            this.lblToCaption.Size = new System.Drawing.Size(29, 13);
            this.lblToCaption.TabIndex = 24;
            this.lblToCaption.Text = "To : ";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(72, 9);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(103, 20);
            this.dtpStartDate.TabIndex = 21;
            // 
            // lblFromCaption
            // 
            this.lblFromCaption.AutoSize = true;
            this.lblFromCaption.Location = new System.Drawing.Point(15, 13);
            this.lblFromCaption.Name = "lblFromCaption";
            this.lblFromCaption.Size = new System.Drawing.Size(39, 13);
            this.lblFromCaption.TabIndex = 23;
            this.lblFromCaption.Text = "From : ";
            // 
            // chrtReport
            // 
            chartArea1.Name = "ChartArea1";
            this.chrtReport.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrtReport.Legends.Add(legend1);
            this.chrtReport.Location = new System.Drawing.Point(13, 95);
            this.chrtReport.Name = "chrtReport";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chrtReport.Series.Add(series1);
            this.chrtReport.Size = new System.Drawing.Size(429, 457);
            this.chrtReport.TabIndex = 1;
            this.chrtReport.Text = "chart1";
            // 
            // frmBillSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 564);
            this.Controls.Add(this.chrtReport);
            this.Controls.Add(this.panel1);
            this.Name = "frmBillSummary";
            this.Text = "frmBillSummary";
            this.Load += new System.EventHandler(this.frmBillSummary_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblToCaption;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblFromCaption;
        private System.Windows.Forms.ComboBox cboBillers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtReport;
    }
}