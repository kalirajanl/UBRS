using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using UBRS.Common;

namespace UBRS
{
    public class PopupForm : Form
    {

        protected string Form_Title = "";

        public void ShowError(string message, string fromForm)
        {
            MessageBox.Show(message, ApplicationTitle + " - " + fromForm + " Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public void ShowInfo(string message, string fromForm)
        {
            MessageBox.Show(message, ApplicationTitle + " - " + fromForm + " Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DialogResult ShowConfirmation(string message, string fromForm, MessageBoxButtons mbtns)
        {
            return MessageBox.Show(message, ApplicationTitle + " - " + fromForm, mbtns,MessageBoxIcon.Question );
        }

        public PageMode CurrentPageMode { get; set; }

        public bool IsPageDirty { get; set; }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string ApplicationTitle
        {
            get
            {
                return AssemblyProduct + " v" + AssemblyVersion.Substring(0, AssemblyVersion.IndexOf(".", AssemblyVersion.IndexOf(".") + 1));
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PopupForm
            // 
            this.ClientSize = new System.Drawing.Size(372, 361);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PopupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

    }
}
