namespace UBRS.Forms.Bills
{
    partial class frmDailyView
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
            this.dtpCurrentDate = new System.Windows.Forms.DateTimePicker();
            this.ctrlBillList1 = new UBRS.Forms.Bills.ctrlBillList();
            this.SuspendLayout();
            // 
            // dtpCurrentDate
            // 
            this.dtpCurrentDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpCurrentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCurrentDate.Location = new System.Drawing.Point(13, 13);
            this.dtpCurrentDate.Name = "dtpCurrentDate";
            this.dtpCurrentDate.Size = new System.Drawing.Size(105, 20);
            this.dtpCurrentDate.TabIndex = 1;
            this.dtpCurrentDate.ValueChanged += new System.EventHandler(this.dtpCurrentDate_ValueChanged);
            // 
            // ctrlBillList1
            // 
            this.ctrlBillList1.CurrentDate = new System.DateTime(((long)(0)));
            this.ctrlBillList1.Form_Title = null;
            this.ctrlBillList1.Location = new System.Drawing.Point(13, 40);
            this.ctrlBillList1.Name = "ctrlBillList1";
            this.ctrlBillList1.Size = new System.Drawing.Size(418, 478);
            this.ctrlBillList1.TabIndex = 2;
            // 
            // frmDailyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 461);
            this.Controls.Add(this.ctrlBillList1);
            this.Controls.Add(this.dtpCurrentDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDailyView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DailyView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpCurrentDate;
        private ctrlBillList ctrlBillList1;
    }
}