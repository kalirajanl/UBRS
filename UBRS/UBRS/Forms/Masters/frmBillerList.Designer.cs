namespace UBRS.Forms.Masters
{
    partial class frmBillerList
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
            this.dgBillers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addBillerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editBillerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBillerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgBillers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgBillers
            // 
            this.dgBillers.AllowUserToAddRows = false;
            this.dgBillers.AllowUserToDeleteRows = false;
            this.dgBillers.AllowUserToOrderColumns = true;
            this.dgBillers.AllowUserToResizeRows = false;
            this.dgBillers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgBillers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBillers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.BillerName,
            this.City,
            this.Notes});
            this.dgBillers.ContextMenuStrip = this.contextMenuStrip1;
            this.dgBillers.Location = new System.Drawing.Point(13, 13);
            this.dgBillers.Name = "dgBillers";
            this.dgBillers.RowHeadersWidth = 20;
            this.dgBillers.Size = new System.Drawing.Size(765, 447);
            this.dgBillers.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBillerToolStripMenuItem,
            this.editBillerToolStripMenuItem,
            this.deleteBillerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 70);
            // 
            // addBillerToolStripMenuItem
            // 
            this.addBillerToolStripMenuItem.Name = "addBillerToolStripMenuItem";
            this.addBillerToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.addBillerToolStripMenuItem.Text = "&Add Biller";
            this.addBillerToolStripMenuItem.Click += new System.EventHandler(this.addBillerToolStripMenuItem_Click);
            // 
            // editBillerToolStripMenuItem
            // 
            this.editBillerToolStripMenuItem.Name = "editBillerToolStripMenuItem";
            this.editBillerToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.editBillerToolStripMenuItem.Text = "&Edit Biller";
            this.editBillerToolStripMenuItem.Click += new System.EventHandler(this.editBillerToolStripMenuItem_Click);
            // 
            // deleteBillerToolStripMenuItem
            // 
            this.deleteBillerToolStripMenuItem.Name = "deleteBillerToolStripMenuItem";
            this.deleteBillerToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.deleteBillerToolStripMenuItem.Text = "&Delete Biller";
            this.deleteBillerToolStripMenuItem.Click += new System.EventHandler(this.deleteBillerToolStripMenuItem_Click);
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
            this.Column1.HeaderText = "Biller ID";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // BillerName
            // 
            this.BillerName.DataPropertyName = "Name";
            this.BillerName.HeaderText = "Name";
            this.BillerName.Name = "BillerName";
            // 
            // City
            // 
            this.City.DataPropertyName = "City";
            this.City.HeaderText = "City";
            this.City.Name = "City";
            // 
            // Notes
            // 
            this.Notes.DataPropertyName = "Notes";
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            // 
            // frmBillerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(790, 493);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgBillers);
            this.Name = "frmBillerList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBillerList";
            ((System.ComponentModel.ISupportInitialize)(this.dgBillers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBillers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addBillerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editBillerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteBillerToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
    }
}