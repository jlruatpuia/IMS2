using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace IMS2.Forms
{
    public partial class frmPrinter : DevExpress.XtraEditors.XtraForm
    {
        public frmPrinter()
        {
            InitializeComponent();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                //MessageBox.Show(printer);
                cboRCPT.Properties.Items.Add(printer);
                cboOTHR.Properties.Items.Add(printer);
            }

            cboRCPT.Text = Properties.Settings.Default.ReceiptPrinter;
            cboOTHR.Text = Properties.Settings.Default.OtherPrinter;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ReceiptPrinter = cboRCPT.Text;
            Properties.Settings.Default.OtherPrinter = cboOTHR.Text;
            Properties.Settings.Default.Save();
            XtraMessageBox.Show("Printer settings saved!");
            Close();
        }
    }
}