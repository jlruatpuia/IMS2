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
    public partial class frmSelectCustomer : XtraForm
    {
        public int CID { get; set; }
        public bool DateSelected { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }


        public frmSelectCustomer()
        {
            InitializeComponent();

            ServerToClient sc = new ServerToClient();
            CustomerContext cx = new CustomerContext();

            sc = cx.GetCustomers();

            lueCNM.Properties.DataSource = sc.DT;
            lueCNM.Properties.DisplayMember = "CustomerName";
            lueCNM.Properties.ValueMember = "ID";

            checkEdit1_CheckedChanged(null, null);
            dtFR.DateTime = DateTime.Now.Date;
            dtTO.DateTime = DateTime.Now.Date;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CID = Convert.ToInt32(lueCNM.EditValue);
            if (DateSelected)
            {
                DateFrom = dtFR.DateTime;
                DateTo = dtTO.DateTime;
            }
            DialogResult = DialogResult.OK;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                dtFR.Enabled = true;
                dtTO.Enabled = true;
                DateSelected = true;
            }
            else
            {
                dtFR.Enabled = false;
                dtTO.Enabled = false;
                DateSelected = false;
            }
        }
    }
}