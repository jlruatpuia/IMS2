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
    public partial class frmDateRangeSelector : XtraForm
    {
        public DateTime DateOn { get; set; }
        public DateTime DateFr { get; set; }
        public DateTime DateTo { get; set; }
        public string InvoiceNo { get; set; }
        public int SelectedValue { get; set; }

        public frmDateRangeSelector()
        {
            InitializeComponent();
            rdoSelect.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (rdoSelect.SelectedIndex)
            {
                case 0:
                    SelectedValue = 1;
                    DateOn = dtpON.DateTime;
                    break;
                case 1:
                    SelectedValue = 2;
                    DateFr = dtpFR.DateTime;
                    DateTo = dtpTO.DateTime;
                    break;
                case 2:
                    SelectedValue = 3;
                    InvoiceNo = txtINV.Text;
                    break;
            }
            DialogResult = DialogResult.OK;
        }

        private void rdoSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdoSelect.SelectedIndex)
            {
                case 0:
                    lcINV.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lcON.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lcFR.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lcTO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    break;
                case 1:
                    lcINV.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lcON.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lcFR.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lcTO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    break;
                case 2:
                    lcINV.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lcON.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lcFR.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lcTO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    break;
            }
        }
    }
}