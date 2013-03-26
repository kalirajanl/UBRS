using System;
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
    public partial class frmEditBiller : PopupForm
    {

        public frmEditBiller(PageMode pageMode)
        {
            InitializeComponent();
            CurrentPageMode = pageMode;
        }

        private void frmEditBiller_Load(object sender, EventArgs e)
        {
            initPage();
        }

        private void initPage()
        {
            this.txtBillerName.Text = "";
            this.txtAddressLine1.Text = "";
            this.txtAddressLine2.Text = "";
            this.txtCity.Text = "Chennai";
            this.txtZip.Text = "600-";
            this.txtBillerNotes.Text = "";

            switch (this.CurrentPageMode)
            {
                case PageMode.Add:
                    {
                        this.Text = ApplicationTitle + " - Add Biller";
                        Form_Title = "Add Biller";
                        this.lblItemID.Text = "0";
                        enableNonDateFields(true);
                        break;
                    }
                case PageMode.Edit:
                    {
                        this.Text = ApplicationTitle + " - Edit Biller";
                        Form_Title = "Edit Biller";
                        enableNonDateFields(true);
                        loadData();
                        break;
                    }
            }
            this.IsPageDirty = false;
        }

        private void enableNonDateFields(bool enabled)
        {
            this.txtBillerName.ReadOnly = !enabled;
            this.txtAddressLine1.ReadOnly = !enabled;
            this.txtAddressLine2.ReadOnly = !enabled;
            this.txtCity.ReadOnly = !enabled;
            this.txtZip.ReadOnly = !enabled;
            this.txtBillerNotes.ReadOnly = !enabled;
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
            BillerItem biller = DALBiller.GetBillerByID(ItemID);
            if (biller != null)
            {
                this.txtBillerNotes.Text = biller.Notes;
                this.txtAddressLine1.Text = biller.AddressLine1;
                this.txtAddressLine2.Text = biller.AddressLine2;
                this.txtCity.Text = biller.City;
                this.txtZip.Text = biller.Zip;
                this.txtBillerName.Text = biller.Name;
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
                    BillerItem biller = null;
                    switch (this.CurrentPageMode)
                    {
                        case PageMode.Add:
                            {
                                biller = new BillerItem();
                                break;
                            }
                        case PageMode.Edit:
                            {
                                biller = DALBiller.GetBillerByID(ItemID);
                                break;
                            }
                    }

                    biller.Name = this.txtBillerName.Text;
                    biller.AddressLine1 = this.txtAddressLine1.Text;
                    biller.AddressLine2 = this.txtAddressLine2.Text;
                    biller.City = this.txtCity.Text;
                    biller.Zip = this.txtZip.Text;
                    biller.State = "TN";
                    biller.Country = "India";
                    biller.Notes = this.txtBillerNotes.Text;
                    try
                    {
                        switch (this.CurrentPageMode)
                        {
                            case PageMode.Add:
                                {
                                    returnValue = (DALBiller.AddBiller(biller) > 0);
                                    break;
                                }
                            case PageMode.Edit:
                                {
                                    returnValue = DALBiller.UpdateBiller(biller);
                                    break;
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError("Unable to save biller information. Please review the error message below and fix the data accordingly" + Environment.NewLine + ex.Message, Form_Title);
                    }
                    biller = null;
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
            if (this.txtBillerName.Text.Trim().Equals(""))
            {
                ShowError("Please enter name of the biller.", Form_Title);
                returnValue = false;
                this.txtBillerName.Focus();
            }
            return returnValue;
        }

        private void txtAddressLine1_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void txtBillerName_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void txtAddressLine2_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void txtZip_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }

        private void txtBillerNotes_TextChanged(object sender, EventArgs e)
        {
            IsPageDirty = true;
        }
    }
}
