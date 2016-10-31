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
using IMS2.Codes;

namespace IMS2.Forms
{
    public partial class frmCustomerSelect : DevExpress.XtraEditors.XtraForm
    {
        ServerToClient sc = new ServerToClient();
        CustomerContext cx = new CustomerContext();
        public int CID { get; set; }

        void InitCustomers()
        {
            sc = new ServerToClient();
            cx = new CustomerContext();
            sc = cx.GetCustomers();
            slueCUS.Properties.DataSource = sc.DT;
            slueCUS.Properties.DisplayMember = "CustomerName";
            slueCUS.Properties.ValueMember = "ID";
        }

        public frmCustomerSelect()
        {
            InitializeComponent();
            InitCustomers();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            CID = Convert.ToInt32(slueCUS.EditValue);
            DialogResult = DialogResult.OK;
        }
    }
}