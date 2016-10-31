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
    public partial class frmNewProduct : DevExpress.XtraEditors.XtraForm
    {
        public int CAT { get; set; }
        public string SCT { get; set; }
        public string CMP { get; set; }
        public string PNM { get; set; }
        public string PKG { get; set; }
        void Init()
        {
            ServerToClient sc = new ServerToClient();
            ProductContext px = new ProductContext();
            sc = px.GetCategories();
            lueCAT.Properties.DataSource = sc.DT;
            lueCAT.Properties.DisplayMember = "CategoryName";
            lueCAT.Properties.ValueMember = "ID";

            sc = px.GetSubCategory();
            cboSCT.Properties.Items.Clear();
            for(int i = 0; i <= sc.DT.Rows.Count -1; i++)
            {
                cboSCT.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
            }

            sc = px.GetCompany();
            cboCMP.Properties.Items.Clear();
            for (int i = 0; i <= sc.DT.Rows.Count - 1; i++)
            {
                cboCMP.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
            }
        }
        public frmNewProduct()
        {
            InitializeComponent();
            Init();
        }

        public frmNewProduct(int Category, string SubCategory, string Company, string ProductName, string PkgSize)
        {
            InitializeComponent();
            Init();
            lueCAT.EditValue = Category;
            cboSCT.Text = SubCategory;
            cboCMP.Text = Company;
            txtPNM.Text = ProductName;
            txtPKG.Text = PkgSize;

        }

        public frmNewProduct(int cat, string sct, string cmp)
        {
            InitializeComponent();
            Init();

            lueCAT.EditValue = cat;
            cboSCT.Text = sct;
            cboCMP.Text = cmp;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CAT = Convert.ToInt32(lueCAT.EditValue);
            SCT = cboSCT.Text;
            CMP = cboCMP.Text;
            PNM = txtPNM.Text;
            PKG = txtPKG.Text;

            DialogResult = DialogResult.OK;
        }

        private void lueCAT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                frmCategory frm = new frmCategory();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Category c = new Category();
                    ServerToClient sc = new ServerToClient();
                    ProductContext px = new ProductContext();

                    c.CategoryName = frm.CNM;

                    sc = px.AddCategory(c);

                    if (sc.Message == null)
                    {
                        Init();
                        lueCAT.EditValue = sc.Count;
                    }
                    else
                        XtraMessageBox.Show(sc.Message);
                }
            }
        }
    }
}