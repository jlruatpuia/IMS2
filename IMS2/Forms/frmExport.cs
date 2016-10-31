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
using DevExpress.XtraReports.UI;

namespace IMS2.Forms
{
    public partial class frmExport : XtraForm
    {
        XtraReport rpt;
        public frmExport(XtraReport rpt)
        {
            InitializeComponent();
            this.rpt = rpt;
            rdoFormat.SelectedIndex = 0;
        }

        private void txtPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog() { RootFolder = Environment.SpecialFolder.Desktop };
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = fbd.SelectedPath; 
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;

            switch (rdoFormat.SelectedIndex)
            {
                case 0:
                    rpt.ExportToPdf(txtPath.Text + @"\Supplier Detail Report.pdf");
                    break;
                case 1:
                    rpt.ExportToXls(txtPath.Text + @"\Supplier Detail Report.xls");
                    break;
                case 2:
                    rpt.ExportToXlsx(txtPath.Text + @"\Supplier Detail Report.xlsx");
                    break;
            }
        }
    }
}