namespace UBRS.Forms.Bills
{
    partial class frmWeeklyView
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpCurrentDate = new System.Windows.Forms.DateTimePicker();
            this.ctrlWeeklyView1 = new UBRS.Forms.Bills.CtrlWeeklyView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Week Starting From";
            // 
            // dtpCurrentDate
            // 
            this.dtpCurrentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpCurrentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCurrentDate.Location = new System.Drawing.Point(119, 5);
            this.dtpCurrentDate.Name = "dtpCurrentDate";
            this.dtpCurrentDate.Size = new System.Drawing.Size(105, 20);
            this.dtpCurrentDate.TabIndex = 4;
            this.dtpCurrentDate.ValueChanged += new System.EventHandler(this.dtpCurrentDate_ValueChanged);
            // 
            // ctrlWeeklyView1
            // 
            this.ctrlWeeklyView1.BillWidth = 170;
            this.ctrlWeeklyView1.CurrentDate = new System.DateTime(2013, 1, 14, 0, 0, 0, 0);
            this.ctrlWeeklyView1.Form_Title = null;
            this.ctrlWeeklyView1.Location = new System.Drawing.Point(15, 31);
            this.ctrlWeeklyView1.Name = "ctrlWeeklyView1";
            this.ctrlWeeklyView1.ShowWorkWeekOnly = false;
            this.ctrlWeeklyView1.Size = new System.Drawing.Size(1230, 435);
            this.ctrlWeeklyView1.TabIndex = 6;
            // 
            // frmWeeklyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 483);
            this.Controls.Add(this.ctrlWeeklyView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpCurrentDate);
            this.Name = "frmWeeklyView";
            this.Text = "frmWeeklyView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpCurrentDate;
        private CtrlWeeklyView ctrlWeeklyView1;
    }
}