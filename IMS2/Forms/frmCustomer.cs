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
    public partial class frmCustomer : DevExpress.XtraEditors.XtraForm
    {
        public int CID { get; set; }
        public string CNM { get; set; }
        public string ADR { get; set; }
        public string PHN { get; set; }

        public frmCustomer()
        {
            InitializeComponent();
        }

        public frmCustomer(string asd)
        {
            InitializeComponent();
            btnSave.Text = "Save";
        }

        public frmCustomer(int ID)
        {
            InitializeComponent();

            CID = ID;
            CustomerContext cc = new CustomerContext();
            Customer c = new Customer();
            c = cc.GetCustomer(CID);
            
            txtCNM.Text = c.CustomerName;
            txtADR.Text = c.Address;
            txtPHN.Text = c.Phone;

            btnSave.Text = "&Update";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;

            ServerToClient sc = new ServerToClient();
            CustomerContext cc = new CustomerContext();
            Customer c = new Customer();
            c.ID = CID;
            c.CustomerName = txtCNM.Text;
            c.Address = txtADR.Text;
            c.Phone = txtPHN.Text;
            if(btnSave.Text == "Save")
            {
                CNM = txtCNM.Text;
                ADR = txtADR.Text;
                PHN = txtPHN.Text;

                DialogResult = DialogResult.OK;
            }
            else if (btnSave.Text == "&Save")
            {
                sc = cc.AddCustomer(c);
                if (sc.Message == null)
                {
                    XtraMessageBox.Show("New Customer added successfully!");
                    CID = sc.Count;
                    Reset();
                }
                else
                    XtraMessageBox.Show(sc.Message);
            }
            else
            {
                sc = cc.UpdateCustomer(c);
                if (sc.Message == null)
                {
                    XtraMessageBox.Show("Customer detail updated successfully!");
                    DialogResult =  DialogResult.OK;
                }
                else
                    XtraMessageBox.Show(sc.Message);
            }
        }

        private void Reset()
        {
            txtCNM.Text = "";
            txtADR.Text = "";
            txtPHN.Text = "";
        }
    }
}