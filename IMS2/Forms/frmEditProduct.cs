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
        public Product p { get; set; }

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

        public frmEditProduct()
        {
            InitializeComponent();
            InitCategory();
            InitCompany();
            Text = "Add New Product";
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
            lueCAT.EditValue = p.Category;
            cboSCT.Text = p.SubCategory;
            cboCMP.Text = p.Company;
            txtPNM.Text = p.ProductName;
            txtPKG.Text = p.PackageSize;
        }

        public frmEditProduct(int ID, string Something)
        {
            InitializeComponent();
        }

        private void lueCAT_EditValueChanged(object sender, EventArgs e)
        {
            InitSubCategory(Convert.ToInt32(lueCAT.EditValue));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            p = new Product();
            p.ID = _id;
            p.Category = Convert.ToInt32(lueCAT.EditValue);
            p.SubCategory = cboSCT.Text;
            p.Company = cboCMP.Text;
            p.ProductName = txtPNM.Text;
            p.PackageSize = txtPKG.Text;
            DialogResult = DialogResult.OK;
        }

        private void lueCAT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index == 1)
            {
                frmCategory frm = new frmCategory();
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    Category c = new Category();
                    ServerToClient sc = new ServerToClient();
                    ProductContext px = new ProductContext();

                    c.CategoryName = frm.CNM;

                    sc = px.AddCategory(c);

                    if (sc.Message == null)
                    {
                        InitCategory();
                        lueCAT.EditValue = sc.Count;
                    }
                    else
                        XtraMessageBox.Show(sc.Message);
                }
            }
        }
    }
}