﻿namespace UBRS.Forms.Masters
{
    partial class frmEditBill
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBillAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblToCaption = new System.Windows.Forms.Label();
            this.btnRecur = new System.Windows.Forms.Button();
            this.txtBillTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBillNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromCaption = new System.Windows.Forms.Label();
            this.cboBillers = new System.Windows.Forms.ComboBox();
            this.lblItemID = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtBillAmount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.lblToCaption);
            this.panel1.Controls.Add(this.btnRecur);
            this.panel1.Controls.Add(this.txtBillTitle);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtBillNotes);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Controls.Add(this.lblFromCaption);
            this.panel1.Controls.Add(this.cboBillers);
            this.panel1.Controls.Add(this.lblItemID);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 461);
            this.panel1.TabIndex = 0;
            // 
            // txtBillAmount
            // 
            this.txtBillAmount.Location = new System.Drawing.Point(310, 70);
            this.txtBillAmount.Name = "txtBillAmount";
            this.txtBillAmount.Size = new System.Drawing.Size(90, 20);
            this.txtBillAmount.TabIndex = 5;
            this.txtBillAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Amount : ";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(214, 42);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(103, 20);
            this.dtpEndDate.TabIndex = 3;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // lblToCaption
            // 
            this.lblToCaption.AutoSize = true;
            this.lblToCaption.Location = new System.Drawing.Point(185, 46);
            this.lblToCaption.Name = "lblToCaption";
            this.lblToCaption.Size = new System.Drawing.Size(29, 13);
            this.lblToCaption.TabIndex = 20;
            this.lblToCaption.Text = "To : ";
            // 
            // btnRecur
            // 
            this.btnRecur.Image = global::UBRS.Properties.Resources.clock;
            this.btnRecur.Location = new System.Drawing.Point(328, 41);
            this.btnRecur.Name = "btnRecur";
            this.btnRecur.Size = new System.Drawing.Size(73, 23);
            this.btnRecur.TabIndex = 18;
            this.btnRecur.Text = "Repeat";
            this.btnRecur.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecur.UseVisualStyleBackColor = true;
            this.btnRecur.Click += new System.EventHandler(this.btnRecur_Click);
            // 
            // txtBillTitle
            // 
            this.txtBillTitle.Location = new System.Drawing.Point(77, 70);
            this.txtBillTitle.Name = "txtBillTitle";
            this.txtBillTitle.Size = new System.Drawing.Size(179, 20);
            this.txtBillTitle.TabIndex = 4;
            this.txtBillTitle.TextChanged += new System.EventHandler(this.txtBillAmount_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Title : ";
            // 
            // txtBillNotes
            // 
            this.txtBillNotes.AcceptsReturn = true;
            this.txtBillNotes.AcceptsTab = true;
            this.txtBillNotes.Location = new System.Drawing.Point(76, 96);
            this.txtBillNotes.Multiline = true;
            this.txtBillNotes.Name = "txtBillNotes";
            this.txtBillNotes.Size = new System.Drawing.Size(324, 332);
            this.txtBillNotes.TabIndex = 6;
            this.txtBillNotes.TextChanged += new System.EventHandler(this.txtBillNotes_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Notes : ";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(77, 42);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(103, 20);
            this.dtpStartDate.TabIndex = 2;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // lblFromCaption
            // 
            this.lblFromCaption.AutoSize = true;
            this.lblFromCaption.Location = new System.Drawing.Point(20, 46);
            this.lblFromCaption.Name = "lblFromCaption";
            this.lblFromCaption.Size = new System.Drawing.Size(39, 13);
            this.lblFromCaption.TabIndex = 11;
            this.lblFromCaption.Text = "From : ";
            // 
            // cboBillers
            // 
            this.cboBillers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBillers.FormattingEnabled = true;
            this.cboBillers.Location = new System.Drawing.Point(77, 14);
            this.cboBillers.Name = "cboBillers";
            this.cboBillers.Size = new System.Drawing.Size(324, 21);
            this.cboBillers.TabIndex = 1;
            this.cboBillers.SelectedIndexChanged += new System.EventHandler(this.cboBillers_SelectedIndexChanged);
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(30, 434);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(13, 13);
            this.lblItemID.TabIndex = 10;
            this.lblItemID.Text = "0";
            this.lblItemID.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::UBRS.Properties.Resources.close_16X16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(334, 434);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Close";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::UBRS.Properties.Resources.save_16X16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(265, 434);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Biller : ";
            // 
            // frmEditBill
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(424, 476);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditBill";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditBill";
            this.Load += new System.EventHandler(this.frmEditBill_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.ComboBox cboBillers;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblFromCaption;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBillNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBillTitle;
        private System.Windows.Forms.Button btnRecur;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblToCaption;
        private System.Windows.Forms.TextBox txtBillAmount;
        private System.Windows.Forms.Label label2;

    }
}