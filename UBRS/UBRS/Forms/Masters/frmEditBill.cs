﻿using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using UBRS.DAL;
using UBRS.Common;
using UBRS.Models;

namespace UBRS.Forms.Masters
{
    public partial class frmEditBill : PopupForm
    {

        public frmEditBill(PageMode pageMode)
        {
            InitializeComponent();
            CurrentPageMode = pageMode;
        }

        private void frmEditBill_Load(object sender, EventArgs e)
        {
            initPage();
            this.cboBillers.Focus();
        }

        private void initPage()
        {

            switch (this.CurrentPageMode)
            {
                case PageMode.Add:
                    {
                        this.Text = ApplicationTitle + " - Add Bill";
                        Form_Title = "Add Bill";
                        this.lblItemID.Text = "0";
                        loadBillers(null);
                        enableNonDateFields(true);
                        CurrentSchedule = null;
                        break;
                    }
                case PageMode.Edit:
                    {
                        this.Text = ApplicationTitle + " - Edit Bill";
                        Form_Title = "Edit Bill";
                        enableNonDateFields(true);
                        loadData();
                        break;
                    }
            }
            this.IsPageDirty = false;
        }

        private void loadBillers(BillerItem biller)
        {
            this.cboBillers.DataSource = DALBiller.GetBillers();
            this.cboBillers.ValueMember = "ID";
            this.cboBillers.DisplayMember = "Name";
            if (biller != null)
            {
                for (int i = 0; i <= this.cboBillers.Items.Count - 1; i++)
                {
                    BillerItem tmp = (BillerItem)this.cboBillers.Items[i];
                    if (biller.ID == tmp.ID)
                    {
                        this.cboBillers.SelectedItem = tmp;
                        break;
                    }
                }
            }
        }

        private void enableNonDateFields(bool enabled)
        {
            this.dtpStartDate.Enabled = enabled;
            this.txtBillTitle.ReadOnly = !enabled;
            this.txtBillAmount.ReadOnly = !enabled;
            this.txtBillNotes.ReadOnly = !enabled;
            this.cboBillers.Enabled = enabled;
            this.txtBillNotes.ReadOnly = !enabled;
        }

        public int ItemID
        {
            get
            {
                return Convert.ToInt32(this.lblItemID.Text);
            }
            set
            {
                this.lblItemID.Text = value.ToString();
            }
        }

        private void loadData()
        {
            BillItem bill = DALBill.GetBillByID(ItemID);
            if (bill != null)
            {
                this.txtBillNotes.Text = bill.Notes;
                this.txtBillAmount.Text = bill.Amount.ToString(Constants.CURRENCY_FORMAT_SQL);
                this.txtBillTitle.Text = bill.BillTitle;
                this.dtpStartDate.Value = bill.StartDate;
                this.dtpEndDate.Value = bill.EndDate;
                CurrentSchedule = bill.BillSchedule;
                loadBillers(bill.Biller);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (IsPageDirty)
            {
                DialogResult rslt = ShowConfirmation("Do you want to save changes?", Form_Title, MessageBoxButtons.YesNo);
                if (rslt == System.Windows.Forms.DialogResult.Yes)
                {
                    btnSave_Click(null, null);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool returnValue = false;
            if (isValidData(true))
            {
                if (IsPageDirty)
                {
                    BillItem bill = null;
                    switch (this.CurrentPageMode)
                    {
                        case PageMode.Add:
                            {
                                bill = new BillItem();
                                break;
                            }
                        case PageMode.Edit:
                            {
                                bill = DALBill.GetBillByID(ItemID);
                                break;
                            }
                    }
                    bill.BillTitle = this.txtBillTitle.Text;
                    bill.Amount = Convert.ToDecimal(this.txtBillAmount.Text);
                    bill.Biller = (BillerItem)this.cboBillers.SelectedItem;
                    bill.StartDate = this.dtpStartDate.Value;
                    bill.EndDate = this.dtpEndDate.Value;
                    bill.Notes = this.txtBillNotes.Text;

                    bill.BillSchedule = CurrentSchedule;

                    try
                    {
                        switch (this.CurrentPageMode)
                        {
                            case PageMode.Add:
                                {
                                    returnValue = (DALBill.AddBill(bill) > 0);
                                    break;
                                }
                            case PageMode.Edit:
                                {
                                    returnValue = DALBill.UpdateBill(bill);
                                    break;
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError("Unable to save bill information. Please review the error message below and fix the data accordingly" + Environment.NewLine + ex.Message, Form_Title);
                    }
                    bill = null;
                }
                if (returnValue)
                {
                    this.Hide();
                    this.Close();
                }
            }
        }

        private bool isValidData(bool showMessage)
        {
            bool returnValue = true;
            if (this.txtBillTitle.Text.Trim().Equals(""))
            {
                ShowError("Please enter the amount.", Form_Title);
                returnValue = false;
                this.txtBillTitle.Focus();
            }
            else if (Convert.ToDecimal(this.txtBillAmount.Text) <= 0)
            {
                ShowError("Please enter the amount.", Form_Title);
                returnValue = false;
                this.txtBillAmount.Focus();
            }
            return returnValue;
        }

        private void cboBillers_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void txtBillNotes_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void txtBillAmount_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private ISchedule currentSchedule;
        
        private ISchedule CurrentSchedule
        {
            get
            {
                return currentSchedule;
            }
            set
            {
                currentSchedule = value;
                this.dtpEndDate.Enabled = false;
                if (currentSchedule == null)
                {
                    this.lblFromCaption.Text = "  On :";
                    this.lblToCaption.Visible = false;
                    this.dtpEndDate.Visible = false;
                    this.dtpEndDate.Value = this.dtpStartDate.Value;
                }
                else
                {
                    this.lblFromCaption.Text = "From :";
                    this.lblToCaption.Visible = true;
                    this.dtpEndDate.Visible = true;
                    this.dtpStartDate.Value = currentSchedule.StartDate;
                    this.dtpEndDate.Value = currentSchedule.EndDate;
                }
            }
        }

        private void btnRecur_Click(object sender, EventArgs e)
        {
            UBRS.Forms.Common.frmRecur recur = new Common.frmRecur();
            if (CurrentSchedule != null)
            {
                recur.LoadSchedule(CurrentSchedule);
            }
            else
            {
                recur.StartDate = this.dtpStartDate.Value;
            }
            recur.ShowDialog();
            if (recur.Tag.ToString() == "OK")
            {
                CurrentSchedule = recur.GetSchedule();
                IsPageDirty = true;
            }
            else if (recur.Tag.ToString() == "Remove")
            {
                CurrentSchedule = null;
                IsPageDirty = true;
            }            
            recur.Close();
            this.txtBillTitle.Focus();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }
    }
}
