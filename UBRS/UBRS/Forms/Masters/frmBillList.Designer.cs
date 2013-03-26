namespace UBRS.Forms.Masters
{
    partial class frmBillList
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
            this.components = new System.ComponentModel.Container();
            this.dgBills = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Biller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgBills)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgBills
            // 
            this.dgBills.AllowUserToAddRows = false;
            this.dgBills.AllowUserToDeleteRows = false;
            this.dgBills.AllowUserToOrderColumns = true;
            this.dgBills.AllowUserToResizeRows = false;
            this.dgBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Biller,
            this.StartDate,
            this.FinishDate,
            this.BillAmount});
            this.dgBills.ContextMenuStrip = this.contextMenuStrip1;
            this.dgBills.Location = new System.Drawing.Point(13, 13);
            this.dgBills.Name = "dgBills";
            this.dgBills.RowHeadersWidth = 20;
            this.dgBills.Size = new System.Drawing.Size(765, 447);
            this.dgBills.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBillToolStripMenuItem,
            this.editBillToolStripMenuItem,
            this.deleteBillToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 70);
            // 
            // addBillToolStripMenuItem
            // 
            this.addBillToolStripMenuItem.Name = "addBillToolStripMenuItem";
            this.addBillToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.addBillToolStripMenuItem.Text = "&Add Bill";
            this.addBillToolStripMenuItem.Click += new System.EventHandler(this.addBillToolStripMenuItem_Click);
            // 
            // editBillToolStripMenuItem
            // 
            this.editBillToolStripMenuItem.Name = "editBillToolStripMenuItem";
            this.editBillToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.editBillToolStripMenuItem.Text = "&Edit Bill";
            this.editBillToolStripMenuItem.Click += new System.EventHandler(this.editBillToolStripMenuItem_Click);
            // 
            // deleteBillToolStripMenuItem
            // 
            this.deleteBillToolStripMenuItem.Name = "deleteBillToolStripMenuItem";
            this.deleteBillToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.deleteBillToolStripMenuItem.Text = "&Delete Bill";
            this.deleteBillToolStripMenuItem.Click += new System.EventHandler(this.deleteBillToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(703, 466);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "C&lose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Biller
            // 
            this.Biller.DataPropertyName = "Biller.Name";
            this.Biller.HeaderText = "Biller";
            this.Biller.Name = "Biller";
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            this.StartDate.HeaderText = "Start Date";
            this.StartDate.Name = "StartDate";
            // 
            // FinishDate
            // 
            this.FinishDate.DataPropertyName = "FinishDate";
            this.FinishDate.HeaderText = "Finish Date";
            this.FinishDate.Name = "FinishDate";
            // 
            // BillAmount
            // 
            this.BillAmount.DataPropertyName = "Amount";
            this.BillAmount.HeaderText = "Bill Amount";
            this.BillAmount.Name = "BillAmount";
            // 
            // frmBillList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(790, 493);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgBills);
            this.Name = "frmBillList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBillList";
            ((System.ComponentModel.ISupportInitialize)(this.dgBills)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBills;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteBillToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Biller;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinishDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillAmount;
    }
}