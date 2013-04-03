namespace UBRS.Forms.Common
{
    partial class frmRecur
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
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbDaily = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDlyUnits = new System.Windows.Forms.TextBox();
            this.rdobtnDlyWeekdaysOnly = new System.Windows.Forms.RadioButton();
            this.rdobtnDlyUnits = new System.Windows.Forms.RadioButton();
            this.gbYearly = new System.Windows.Forms.GroupBox();
            this.txtYlyOnDay = new System.Windows.Forms.TextBox();
            this.cboYlyOnMonth = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtYlyUnits = new System.Windows.Forms.TextBox();
            this.rdobtnYearly = new System.Windows.Forms.RadioButton();
            this.gbWeekly = new System.Windows.Forms.GroupBox();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.chkFriday = new System.Windows.Forms.CheckBox();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkWednesday = new System.Windows.Forms.CheckBox();
            this.chkTuesday = new System.Windows.Forms.CheckBox();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWlyUnits = new System.Windows.Forms.TextBox();
            this.gbMonthly = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMlyOnDay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMlyUnits = new System.Windows.Forms.TextBox();
            this.rdobtnMonthly = new System.Windows.Forms.RadioButton();
            this.rdobtnWeekly = new System.Windows.Forms.RadioButton();
            this.rdobtnDaily = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRemoveRecurrance = new System.Windows.Forms.Button();
            this.groupbox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbDaily.SuspendLayout();
            this.gbYearly.SuspendLayout();
            this.gbWeekly.SuspendLayout();
            this.gbMonthly.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start :";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(62, 19);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(100, 20);
            this.dtpStartDate.TabIndex = 1;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(241, 19);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(100, 20);
            this.dtpEndDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "End :";
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.dtpEndDate);
            this.groupbox1.Controls.Add(this.dtpStartDate);
            this.groupbox1.Controls.Add(this.label2);
            this.groupbox1.Controls.Add(this.label1);
            this.groupbox1.Location = new System.Drawing.Point(13, 13);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(615, 50);
            this.groupbox1.TabIndex = 4;
            this.groupbox1.TabStop = false;
            this.groupbox1.Text = "Period";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gbDaily);
            this.groupBox2.Controls.Add(this.gbYearly);
            this.groupBox2.Controls.Add(this.rdobtnYearly);
            this.groupBox2.Controls.Add(this.gbWeekly);
            this.groupBox2.Controls.Add(this.gbMonthly);
            this.groupBox2.Controls.Add(this.rdobtnMonthly);
            this.groupBox2.Controls.Add(this.rdobtnWeekly);
            this.groupBox2.Controls.Add(this.rdobtnDaily);
            this.groupBox2.Location = new System.Drawing.Point(13, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(615, 148);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recurrance Pattern";
            // 
            // gbDaily
            // 
            this.gbDaily.Controls.Add(this.label3);
            this.gbDaily.Controls.Add(this.txtDlyUnits);
            this.gbDaily.Controls.Add(this.rdobtnDlyWeekdaysOnly);
            this.gbDaily.Controls.Add(this.rdobtnDlyUnits);
            this.gbDaily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbDaily.Location = new System.Drawing.Point(133, 19);
            this.gbDaily.Name = "gbDaily";
            this.gbDaily.Size = new System.Drawing.Size(476, 110);
            this.gbDaily.TabIndex = 6;
            this.gbDaily.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Day(s)";
            // 
            // txtDlyUnits
            // 
            this.txtDlyUnits.Location = new System.Drawing.Point(73, 17);
            this.txtDlyUnits.Name = "txtDlyUnits";
            this.txtDlyUnits.Size = new System.Drawing.Size(42, 20);
            this.txtDlyUnits.TabIndex = 4;
            this.txtDlyUnits.Text = "1";
            // 
            // rdobtnDlyWeekdaysOnly
            // 
            this.rdobtnDlyWeekdaysOnly.AutoSize = true;
            this.rdobtnDlyWeekdaysOnly.Location = new System.Drawing.Point(14, 50);
            this.rdobtnDlyWeekdaysOnly.Name = "rdobtnDlyWeekdaysOnly";
            this.rdobtnDlyWeekdaysOnly.Size = new System.Drawing.Size(101, 17);
            this.rdobtnDlyWeekdaysOnly.TabIndex = 3;
            this.rdobtnDlyWeekdaysOnly.TabStop = true;
            this.rdobtnDlyWeekdaysOnly.Text = "Every Weekday";
            this.rdobtnDlyWeekdaysOnly.UseVisualStyleBackColor = true;
            // 
            // rdobtnDlyUnits
            // 
            this.rdobtnDlyUnits.AutoSize = true;
            this.rdobtnDlyUnits.Location = new System.Drawing.Point(14, 19);
            this.rdobtnDlyUnits.Name = "rdobtnDlyUnits";
            this.rdobtnDlyUnits.Size = new System.Drawing.Size(52, 17);
            this.rdobtnDlyUnits.TabIndex = 2;
            this.rdobtnDlyUnits.TabStop = true;
            this.rdobtnDlyUnits.Text = "Every";
            this.rdobtnDlyUnits.UseVisualStyleBackColor = true;
            // 
            // gbYearly
            // 
            this.gbYearly.Controls.Add(this.txtYlyOnDay);
            this.gbYearly.Controls.Add(this.cboYlyOnMonth);
            this.gbYearly.Controls.Add(this.label11);
            this.gbYearly.Controls.Add(this.label9);
            this.gbYearly.Controls.Add(this.label10);
            this.gbYearly.Controls.Add(this.txtYlyUnits);
            this.gbYearly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbYearly.Location = new System.Drawing.Point(93, 44);
            this.gbYearly.Name = "gbYearly";
            this.gbYearly.Size = new System.Drawing.Size(476, 110);
            this.gbYearly.TabIndex = 9;
            this.gbYearly.TabStop = false;
            // 
            // txtYlyOnDay
            // 
            this.txtYlyOnDay.Location = new System.Drawing.Point(166, 54);
            this.txtYlyOnDay.Name = "txtYlyOnDay";
            this.txtYlyOnDay.Size = new System.Drawing.Size(39, 20);
            this.txtYlyOnDay.TabIndex = 15;
            this.txtYlyOnDay.Text = "1";
            // 
            // cboYlyOnMonth
            // 
            this.cboYlyOnMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYlyOnMonth.FormattingEnabled = true;
            this.cboYlyOnMonth.Items.AddRange(new object[] {
            "Select",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cboYlyOnMonth.Location = new System.Drawing.Point(39, 54);
            this.cboYlyOnMonth.Name = "cboYlyOnMonth";
            this.cboYlyOnMonth.Size = new System.Drawing.Size(121, 21);
            this.cboYlyOnMonth.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "On";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Recur every";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(131, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Year(s)";
            // 
            // txtYlyUnits
            // 
            this.txtYlyUnits.Location = new System.Drawing.Point(82, 21);
            this.txtYlyUnits.Name = "txtYlyUnits";
            this.txtYlyUnits.Size = new System.Drawing.Size(39, 20);
            this.txtYlyUnits.TabIndex = 7;
            this.txtYlyUnits.Text = "1";
            // 
            // rdobtnYearly
            // 
            this.rdobtnYearly.AutoSize = true;
            this.rdobtnYearly.Location = new System.Drawing.Point(8, 112);
            this.rdobtnYearly.Name = "rdobtnYearly";
            this.rdobtnYearly.Size = new System.Drawing.Size(54, 17);
            this.rdobtnYearly.TabIndex = 3;
            this.rdobtnYearly.TabStop = true;
            this.rdobtnYearly.Text = "Yearly";
            this.rdobtnYearly.UseVisualStyleBackColor = true;
            this.rdobtnYearly.CheckedChanged += new System.EventHandler(this.rdobtnYearly_CheckedChanged);
            // 
            // gbWeekly
            // 
            this.gbWeekly.Controls.Add(this.chkSaturday);
            this.gbWeekly.Controls.Add(this.chkFriday);
            this.gbWeekly.Controls.Add(this.chkThursday);
            this.gbWeekly.Controls.Add(this.chkWednesday);
            this.gbWeekly.Controls.Add(this.chkTuesday);
            this.gbWeekly.Controls.Add(this.chkMonday);
            this.gbWeekly.Controls.Add(this.chkSunday);
            this.gbWeekly.Controls.Add(this.label5);
            this.gbWeekly.Controls.Add(this.label4);
            this.gbWeekly.Controls.Add(this.txtWlyUnits);
            this.gbWeekly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbWeekly.Location = new System.Drawing.Point(127, 50);
            this.gbWeekly.Name = "gbWeekly";
            this.gbWeekly.Size = new System.Drawing.Size(476, 110);
            this.gbWeekly.TabIndex = 7;
            this.gbWeekly.TabStop = false;
            // 
            // chkSaturday
            // 
            this.chkSaturday.AutoSize = true;
            this.chkSaturday.Location = new System.Drawing.Point(200, 86);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(68, 17);
            this.chkSaturday.TabIndex = 13;
            this.chkSaturday.Text = "Saturday";
            this.chkSaturday.UseVisualStyleBackColor = true;
            // 
            // chkFriday
            // 
            this.chkFriday.AutoSize = true;
            this.chkFriday.Location = new System.Drawing.Point(106, 86);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(54, 17);
            this.chkFriday.TabIndex = 12;
            this.chkFriday.Text = "Friday";
            this.chkFriday.UseVisualStyleBackColor = true;
            // 
            // chkThursday
            // 
            this.chkThursday.AutoSize = true;
            this.chkThursday.Location = new System.Drawing.Point(14, 86);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(70, 17);
            this.chkThursday.TabIndex = 11;
            this.chkThursday.Text = "Thursday";
            this.chkThursday.UseVisualStyleBackColor = true;
            // 
            // chkWednesday
            // 
            this.chkWednesday.AutoSize = true;
            this.chkWednesday.Location = new System.Drawing.Point(297, 50);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(83, 17);
            this.chkWednesday.TabIndex = 10;
            this.chkWednesday.Text = "Wednesday";
            this.chkWednesday.UseVisualStyleBackColor = true;
            // 
            // chkTuesday
            // 
            this.chkTuesday.AutoSize = true;
            this.chkTuesday.Location = new System.Drawing.Point(200, 50);
            this.chkTuesday.Name = "chkTuesday";
            this.chkTuesday.Size = new System.Drawing.Size(67, 17);
            this.chkTuesday.TabIndex = 9;
            this.chkTuesday.Text = "Tuesday";
            this.chkTuesday.UseVisualStyleBackColor = true;
            // 
            // chkMonday
            // 
            this.chkMonday.AutoSize = true;
            this.chkMonday.Location = new System.Drawing.Point(106, 50);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(64, 17);
            this.chkMonday.TabIndex = 8;
            this.chkMonday.Text = "Monday";
            this.chkMonday.UseVisualStyleBackColor = true;
            // 
            // chkSunday
            // 
            this.chkSunday.AutoSize = true;
            this.chkSunday.Location = new System.Drawing.Point(14, 50);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(62, 17);
            this.chkSunday.TabIndex = 7;
            this.chkSunday.Text = "Sunday";
            this.chkSunday.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Recur every";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Week(s)";
            // 
            // txtWlyUnits
            // 
            this.txtWlyUnits.Location = new System.Drawing.Point(82, 17);
            this.txtWlyUnits.Name = "txtWlyUnits";
            this.txtWlyUnits.Size = new System.Drawing.Size(39, 20);
            this.txtWlyUnits.TabIndex = 4;
            this.txtWlyUnits.Text = "1";
            // 
            // gbMonthly
            // 
            this.gbMonthly.Controls.Add(this.label8);
            this.gbMonthly.Controls.Add(this.txtMlyOnDay);
            this.gbMonthly.Controls.Add(this.label6);
            this.gbMonthly.Controls.Add(this.label7);
            this.gbMonthly.Controls.Add(this.txtMlyUnits);
            this.gbMonthly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbMonthly.Location = new System.Drawing.Point(99, 50);
            this.gbMonthly.Name = "gbMonthly";
            this.gbMonthly.Size = new System.Drawing.Size(476, 110);
            this.gbMonthly.TabIndex = 8;
            this.gbMonthly.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(88, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "of every";
            // 
            // txtMlyOnDay
            // 
            this.txtMlyOnDay.Location = new System.Drawing.Point(43, 12);
            this.txtMlyOnDay.Name = "txtMlyOnDay";
            this.txtMlyOnDay.Size = new System.Drawing.Size(39, 20);
            this.txtMlyOnDay.TabIndex = 14;
            this.txtMlyOnDay.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Day";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Month(s)";
            // 
            // txtMlyUnits
            // 
            this.txtMlyUnits.Location = new System.Drawing.Point(139, 12);
            this.txtMlyUnits.Name = "txtMlyUnits";
            this.txtMlyUnits.Size = new System.Drawing.Size(39, 20);
            this.txtMlyUnits.TabIndex = 4;
            this.txtMlyUnits.Text = "1";
            // 
            // rdobtnMonthly
            // 
            this.rdobtnMonthly.AutoSize = true;
            this.rdobtnMonthly.Location = new System.Drawing.Point(8, 81);
            this.rdobtnMonthly.Name = "rdobtnMonthly";
            this.rdobtnMonthly.Size = new System.Drawing.Size(62, 17);
            this.rdobtnMonthly.TabIndex = 2;
            this.rdobtnMonthly.TabStop = true;
            this.rdobtnMonthly.Text = "Monthly";
            this.rdobtnMonthly.UseVisualStyleBackColor = true;
            this.rdobtnMonthly.CheckedChanged += new System.EventHandler(this.rdobtnMonthly_CheckedChanged);
            // 
            // rdobtnWeekly
            // 
            this.rdobtnWeekly.AutoSize = true;
            this.rdobtnWeekly.Location = new System.Drawing.Point(8, 50);
            this.rdobtnWeekly.Name = "rdobtnWeekly";
            this.rdobtnWeekly.Size = new System.Drawing.Size(61, 17);
            this.rdobtnWeekly.TabIndex = 1;
            this.rdobtnWeekly.TabStop = true;
            this.rdobtnWeekly.Text = "Weekly";
            this.rdobtnWeekly.UseVisualStyleBackColor = true;
            this.rdobtnWeekly.CheckedChanged += new System.EventHandler(this.rdobtnWeekly_CheckedChanged);
            // 
            // rdobtnDaily
            // 
            this.rdobtnDaily.AutoSize = true;
            this.rdobtnDaily.Location = new System.Drawing.Point(8, 19);
            this.rdobtnDaily.Name = "rdobtnDaily";
            this.rdobtnDaily.Size = new System.Drawing.Size(48, 17);
            this.rdobtnDaily.TabIndex = 0;
            this.rdobtnDaily.TabStop = true;
            this.rdobtnDaily.Text = "Daily";
            this.rdobtnDaily.UseVisualStyleBackColor = true;
            this.rdobtnDaily.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(468, 229);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(555, 229);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRemoveRecurrance
            // 
            this.btnRemoveRecurrance.Location = new System.Drawing.Point(377, 228);
            this.btnRemoveRecurrance.Name = "btnRemoveRecurrance";
            this.btnRemoveRecurrance.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveRecurrance.TabIndex = 8;
            this.btnRemoveRecurrance.Text = "&Remove";
            this.btnRemoveRecurrance.UseVisualStyleBackColor = true;
            this.btnRemoveRecurrance.Click += new System.EventHandler(this.btnRemoveRecurrance_Click);
            // 
            // frmRecur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(640, 258);
            this.Controls.Add(this.btnRemoveRecurrance);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupbox1);
            this.Name = "frmRecur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recurrance Details";
            this.groupbox1.ResumeLayout(false);
            this.groupbox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbDaily.ResumeLayout(false);
            this.gbDaily.PerformLayout();
            this.gbYearly.ResumeLayout(false);
            this.gbYearly.PerformLayout();
            this.gbWeekly.ResumeLayout(false);
            this.gbWeekly.PerformLayout();
            this.gbMonthly.ResumeLayout(false);
            this.gbMonthly.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupbox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdobtnDaily;
        private System.Windows.Forms.RadioButton rdobtnYearly;
        private System.Windows.Forms.RadioButton rdobtnMonthly;
        private System.Windows.Forms.RadioButton rdobtnWeekly;
        private System.Windows.Forms.GroupBox gbDaily;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDlyUnits;
        private System.Windows.Forms.RadioButton rdobtnDlyWeekdaysOnly;
        private System.Windows.Forms.RadioButton rdobtnDlyUnits;
        private System.Windows.Forms.GroupBox gbWeekly;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWlyUnits;
        private System.Windows.Forms.CheckBox chkSunday;
        private System.Windows.Forms.CheckBox chkTuesday;
        private System.Windows.Forms.CheckBox chkMonday;
        private System.Windows.Forms.CheckBox chkSaturday;
        private System.Windows.Forms.CheckBox chkFriday;
        private System.Windows.Forms.CheckBox chkThursday;
        private System.Windows.Forms.CheckBox chkWednesday;
        private System.Windows.Forms.GroupBox gbMonthly;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMlyUnits;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMlyOnDay;
        private System.Windows.Forms.GroupBox gbYearly;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtYlyUnits;
        private System.Windows.Forms.ComboBox cboYlyOnMonth;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtYlyOnDay;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRemoveRecurrance;
    }
}