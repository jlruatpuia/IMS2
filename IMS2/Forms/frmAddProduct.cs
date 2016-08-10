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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace IMS2.Forms
{
    public partial class frmAddProduct : XtraForm
    {
        DataTable dt;

        void InitDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("Category", typeof(int));
            dt.Columns.Add("SubCategory", typeof(string));
            dt.Columns.Add("Company", typeof(string));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("BuyingValue", typeof(double));
            dt.Columns.Add("SellingValue", typeof(double));
            dt.Columns.Add("MfgDate", typeof(string));
            dt.Columns.Add("ExpDate", typeof(string));
            dt.Columns.Add("PackageSize", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("BarCode", typeof(string));
        }
        void InitCategory()
        {
            ProductContext pc = new ProductContext();
            ServerToClient sc = new ServerToClient();
            sc = pc.GetCategories();
            lueCAT.Properties.DataSource = sc.DT;
            lueCAT.Properties.DisplayMember = "CategoryName";
            lueCAT.Properties.ValueMember = "ID";

            repCAT.DataSource = sc.DT;
            repCAT.DisplayMember = "CategoryName";
            repCAT.ValueMember = "ID";
        }

        void InitSubCategory(int CategoryID)
        {
            ProductContext pc = new ProductContext();
            ServerToClient sc = new ServerToClient();
            sc = pc.GetSubCategory(CategoryID);
            for (int i = 0; i<= sc.DT.Rows.Count - 1; i++)
            {
                cboSCT.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
                repSCT.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
            }
        }

        void InitCompany()
        {
            ProductContext pc = new ProductContext();
            ServerToClient sc = new ServerToClient();
            sc = pc.GetCompany();
            for(int i = 0; i<=sc.DT.Rows.Count -1; i++)
            {
                cboCMP.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
                repCMP.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
            }
        }

        void AddData()
        {
            DataRow r = dt.NewRow();
            r["Category"] = Convert.ToInt32(lueCAT.EditValue);
            r["SubCategory"] = cboSCT.Text;
            r["Company"] = cboCMP.Text;
            r["ProductName"] = txtPNM.Text;
            r["BuyingValue"] = Convert.ToDouble(txtBVL.EditValue);
            r["SellingValue"] = Convert.ToDouble(txtSVL.EditValue);
            r["MfgDate"] = txtMFG.Text;
            r["ExpDate"] = txtEXP.Text;
            r["PackageSize"] = txtPKG.Text;
            r["Quantity"] = Convert.ToInt32(txtQTY.EditValue);
            r["BarCode"] = txtBCD.Text.ToUpper();
            dt.Rows.Add(r);
            grd.DataSource = dt;
            grd.Refresh();
        }

        void Reset()
        {
            lueCAT.EditValue = null;
            cboSCT.Text = "";
            cboCMP.Text = "";
            txtPNM.Text = "";
            txtBVL.Text = "";
            txtSVL.Text = "";
            txtMFG.Text = "";
            txtEXP.Text = "";
            txtPKG.Text = "";
            txtQTY.EditValue = 0;
            txtBCD.Text = "";
        }

        public frmAddProduct()
        {
            InitializeComponent();
            InitCategory();
            InitDataTable();
            InitCompany();
        }

        private void lueCAT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index == 1)
            {
                frmAddCategory frm = new frmAddCategory();
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    Category c = new Category();
                    c.CategoryName = frm.CNM;

                    ProductContext pc = new ProductContext();
                    ServerToClient sc = new ServerToClient();

                    sc = pc.AddCategory(c);

                    if(sc.Message == null)
                    {
                        InitCategory();
                        lueCAT.EditValue = sc.Count;
                    }
                    else
                    {
                        XtraMessageBox.Show(sc.Message);
                    }
                }
            }
        }

        private void txtBCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Error Handler goes here
                AddData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Error Handler goes here

            AddData();
        }

        private void grv_Click(object sender, EventArgs e)
        {
            GridHitInfo hi = grv.CalcHitInfo(grd.PointToClient(MousePosition));
            if (hi.InRowCell && hi.Column == colDel)
            {
                if (XtraMessageBox.Show("Do you really want to remove this product?", "Confirm remove", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    grv.DeleteRow(hi.RowHandle);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProductContext pc = new ProductContext();
            ServerToClient sc = new ServerToClient();
            
            for (int i = 0; i <= grv.RowCount - 1; i++)
            {
                Product p = new Product();

                p.Company = grv.GetRowCellValue(i, colCMP).ToString();
                p.ProductName = grv.GetRowCellValue(i, colPNM).ToString();
                p.BarCode = grv.GetRowCellValue(i, colBCD).ToString();
                p.BuyingValue = Convert.ToDouble(grv.GetRowCellValue(i, colBVL));
                p.SellingValue = Convert.ToDouble(grv.GetRowCellValue(i, colSVL));
                p.MfgDate = grv.GetRowCellValue(i, colMFG).ToString();
                p.ExpDate = grv.GetRowCellValue(i, colEXP).ToString();
                p.Category = Convert.ToInt32(grv.GetRowCellValue(i, colCAT));
                p.SubCategory = grv.GetRowCellValue(i, colSCT).ToString();
                p.PackageSize = grv.GetRowCellValue(i, colPKG).ToString();
                p.Quantity = Convert.ToInt32(grv.GetRowCellValue(i, colQTY));
                sc = pc.AddProduct(p);
            }

            if(sc.Message == null)
            {
                Reset();
                grd.DataSource = null;
                grd.Refresh();
            }
        }

        private void lueCAT_EditValueChanged(object sender, EventArgs e)
        {
            if (lueCAT.EditValue != null)
                InitSubCategory(Convert.ToInt32(lueCAT.EditValue));

        }
    }
}