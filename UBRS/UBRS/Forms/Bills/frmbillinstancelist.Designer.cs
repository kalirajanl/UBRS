namespace UBRS.Forms.Bills
{
    partial class frmbillinstancelist
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
            this.btnClose = new System.Windows.Forms.Button();
            this.dtpAsofDate = new System.Windows.Forms.DateTimePicker();
            this.dgBills = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Biller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstanceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.markCompletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgBills)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(689, 467);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "C&lose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtpAsofDate
            // 
            this.dtpAsofDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpAsofDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAsofDate.Location = new System.Drawing.Point(12, 12);
            this.dtpAsofDate.Name = "dtpAsofDate";
            this.dtpAsofDate.Size = new System.Drawing.Size(103, 20);
            this.dtpAsofDate.TabIndex = 3;
            this.dtpAsofDate.ValueChanged += new System.EventHandler(this.dtpAsofDate_ValueChanged);
            // 
            // dgBills
            // 
            this.dgBills.AllowUserToAddRows = false;
            this.dgBills.AllowUserToDeleteRows = false;
            this.dgBills.AllowUserToResizeRows = false;
            this.dgBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Biller,
            this.BillTitle,
            this.InstanceDate,
            this.BillAmount});
            this.dgBills.ContextMenuStrip = this.contextMenuStrip1;
            this.dgBills.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgBills.Location = new System.Drawing.Point(6, 38);
            this.dgBills.Name = "dgBills";
            this.dgBills.RowHeadersWidth = 20;
            this.dgBills.Size = new System.Drawing.Size(765, 423);
            this.dgBills.TabIndex = 1;
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
            this.Biller.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Biller.DataPropertyName = "BillerName";
            this.Biller.FillWeight = 68.45806F;
            this.Biller.HeaderText = "Biller";
            this.Biller.Name = "Biller";
            this.Biller.Width = 54;
            // 
            // BillTitle
            // 
            this.BillTitle.DataPropertyName = "BillTitle";
            this.BillTitle.HeaderText = "Title";
            this.BillTitle.Name = "BillTitle";
            // 
            // InstanceDate
            // 
            this.InstanceDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.InstanceDate.DataPropertyName = "InstanceDate";
            this.InstanceDate.FillWeight = 94.41624F;
            this.InstanceDate.HeaderText = "Due On";
            this.InstanceDate.MinimumWidth = 130;
            this.InstanceDate.Name = "InstanceDate";
            this.InstanceDate.Width = 130;
            // 
            // BillAmount
            // 
            this.BillAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.BillAmount.DataPropertyName = "Amount";
            this.BillAmount.FillWeight = 137.1257F;
            this.BillAmount.HeaderText = "Bill Amount";
            this.BillAmount.MinimumWidth = 130;
            this.BillAmount.Name = "BillAmount";
            this.BillAmount.Width = 130;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markCompletedToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 48);
            // 
            // markCompletedToolStripMenuItem
            // 
            this.markCompletedToolStripMenuItem.Name = "markCompletedToolStripMenuItem";
            this.markCompletedToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.markCompletedToolStripMenuItem.Text = "Mark Completed";
            this.markCompletedToolStripMenuItem.Click += new System.EventHandler(this.markCompletedToolStripMenuItem_Click);
            // 
            // frmbillinstancelist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 493);
            this.Controls.Add(this.dtpAsofDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgBills);
            this.Name = "frmbillinstancelist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmbillinstancelist";
            ((System.ComponentModel.ISupportInitialize)(this.dgBills)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtpAsofDate;
        private System.Windows.Forms.DataGridView dgBills;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Biller;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstanceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillAmount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem markCompletedToolStripMenuItem;
    }
}