namespace UBRS.Forms.Bills
{
    partial class ctrlBillList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.markCompleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgBills = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Biller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstanceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCompleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBills)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markCompleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // markCompleteToolStripMenuItem
            // 
            this.markCompleteToolStripMenuItem.Name = "markCompleteToolStripMenuItem";
            this.markCompleteToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.markCompleteToolStripMenuItem.Text = "Mark Complete";
            this.markCompleteToolStripMenuItem.Click += new System.EventHandler(this.markCompleteToolStripMenuItem_Click);
            // 
            // dgBills
            // 
            this.dgBills.AllowUserToAddRows = false;
            this.dgBills.AllowUserToDeleteRows = false;
            this.dgBills.AllowUserToResizeRows = false;
            this.dgBills.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Biller,
            this.BillTitle,
            this.InstanceDate,
            this.BillAmount,
            this.IsCompleted});
            this.dgBills.ContextMenuStrip = this.contextMenuStrip1;
            this.dgBills.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgBills.Location = new System.Drawing.Point(3, 27);
            this.dgBills.MultiSelect = false;
            this.dgBills.Name = "dgBills";
            this.dgBills.ReadOnly = true;
            this.dgBills.RowHeadersWidth = 20;
            this.dgBills.Size = new System.Drawing.Size(341, 384);
            this.dgBills.TabIndex = 2;
            this.dgBills.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgBills_CellFormatting);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "ID";
            this.Column1.FillWeight = 1F;
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Biller
            // 
            this.Biller.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Biller.DataPropertyName = "BillerName";
            this.Biller.FillWeight = 1F;
            this.Biller.HeaderText = "Biller";
            this.Biller.Name = "Biller";
            this.Biller.ReadOnly = true;
            this.Biller.Visible = false;
            // 
            // BillTitle
            // 
            this.BillTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BillTitle.DataPropertyName = "BillTitle";
            this.BillTitle.FillWeight = 75F;
            this.BillTitle.HeaderText = "Title";
            this.BillTitle.MinimumWidth = 100;
            this.BillTitle.Name = "BillTitle";
            this.BillTitle.ReadOnly = true;
            // 
            // InstanceDate
            // 
            this.InstanceDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InstanceDate.DataPropertyName = "InstanceDate";
            this.InstanceDate.FillWeight = 1F;
            this.InstanceDate.HeaderText = "Due On";
            this.InstanceDate.Name = "InstanceDate";
            this.InstanceDate.ReadOnly = true;
            this.InstanceDate.Visible = false;
            this.InstanceDate.Width = 130;
            // 
            // BillAmount
            // 
            this.BillAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BillAmount.DataPropertyName = "Amount";
            this.BillAmount.FillWeight = 25F;
            this.BillAmount.HeaderText = "Bill Amount";
            this.BillAmount.MinimumWidth = 100;
            this.BillAmount.Name = "BillAmount";
            this.BillAmount.ReadOnly = true;
            // 
            // IsCompleted
            // 
            this.IsCompleted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IsCompleted.DataPropertyName = "IsCompleted";
            this.IsCompleted.HeaderText = "IsCompleted";
            this.IsCompleted.Name = "IsCompleted";
            this.IsCompleted.ReadOnly = true;
            this.IsCompleted.Visible = false;
            // 
            // ctrlBillList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgBills);
            this.Name = "ctrlBillList";
            this.Size = new System.Drawing.Size(353, 422);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBills)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBills;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem markCompleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Biller;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstanceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsCompleted;
    }
}
