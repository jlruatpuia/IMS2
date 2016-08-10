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
    public partial class frmEditProduct : DevExpress.XtraEditors.XtraForm
    {
        public int _id { get; set; }

        void InitCategory()
        {
            ProductContext pc = new ProductContext();
            ServerToClient sc = new ServerToClient();
            sc = pc.GetCategories();
            lueCAT.Properties.DataSource = sc.DT;
            lueCAT.Properties.DisplayMember = "CategoryName";
            lueCAT.Properties.ValueMember = "ID";
        }

        void InitSubCategory(int CategoryID)
        {
            ProductContext pc = new ProductContext();
            ServerToClient sc = new ServerToClient();
            sc = pc.GetSubCategory(CategoryID);
            for (int i = 0; i <= sc.DT.Rows.Count - 1; i++)
            {
                cboSCT.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
            }
        }

        void InitCompany()
        {
            ProductContext pc = new ProductContext();
            ServerToClient sc = new ServerToClient();
            sc = pc.GetCompany();
            for (int i = 0; i <= sc.DT.Rows.Count - 1; i++)
            {
                cboCMP.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
            }
        }
        public frmEditProduct(int ID)
        {
            InitializeComponent();
            _id = ID;
            InitCategory();
            InitCompany();

            ProductContext pc = new ProductContext();
            Product p = new Product();
            p = pc.GetProduct(ID);
            cboCMP.Text = p.Company;
            txtPNM.Text = p.ProductName;
            txtBCD.Text = p.BarCode;
            txtBVL.Text = p.BuyingValue.ToString();
            txtSVL.Text = p.SellingValue.ToString();
            txtMFG.Text = p.MfgDate;
            txtEXP.Text = p.ExpDate;
            lueCAT.EditValue = p.Category;
            cboSCT.Text = p.SubCategory;
            txtPKG.Text = p.PackageSize;
            txtQTY.Text = p.Quantity.ToString();
        }

        private void lueCAT_EditValueChanged(object sender, EventArgs e)
        {
            InitSubCategory(Convert.ToInt32(lueCAT.EditValue));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProductContext pc = new ProductContext();
            ServerToClient sc = new ServerToClient();

            Product p = new Product();
            p.ID = _id;
            p.Company = cboCMP.Text;
            p.ProductName = txtPNM.Text;
            p.BarCode = txtBCD.Text;
            p.BuyingValue = Convert.ToDouble(txtBVL.Text);
            p.SellingValue = Convert.ToDouble(txtSVL.Text);
            p.MfgDate = txtMFG.Text;
            p.ExpDate = txtEXP.Text;
            p.Category = Convert.ToInt32(lueCAT.EditValue);
            p.SubCategory = cboSCT.Text;
            p.PackageSize = txtPKG.Text;
            p.Quantity = Convert.ToInt32(txtQTY.Text);
            sc = pc.UpdateProduct(p);

            if (sc.Message == null)
            {
                XtraMessageBox.Show("Product Updated!");
                DialogResult = DialogResult.OK;
            }
        }
    }
}