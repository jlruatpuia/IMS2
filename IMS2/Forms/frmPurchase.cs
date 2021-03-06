﻿using System;
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
    public partial class frmPurchase : XtraForm
    {
        DataTable dt = new DataTable();

        void InitDataTable()
        {
            dt.Columns.Add("Supplier", typeof(int));
            dt.Columns.Add("Category", typeof(int));
            dt.Columns.Add("SubCategory", typeof(string));
            dt.Columns.Add("Company", typeof(string));
            dt.Columns.Add("ProductName", typeof(int));
            dt.Columns.Add("BuyingValue", typeof(double));
            dt.Columns.Add("SellingValue", typeof(double));
            dt.Columns.Add("MfgDate", typeof(string));
            dt.Columns.Add("ExpDate", typeof(string));
            dt.Columns.Add("PackageSize", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("BarCode", typeof(string));
            dt.Columns.Add("Amount", typeof(double));
        }

        void InitSuppliers()
        {
            ServerToClient sc = new ServerToClient();
            SupplierContext sx = new SupplierContext();
            sc = sx.GetSuppliers();
            lueSUP.Properties.DataSource = sc.DT;
            lueSUP.Properties.DisplayMember = "SupplierName";
            lueSUP.Properties.ValueMember = "ID";
            repSNM.DataSource = sc.DT;
            repSNM.DisplayMember = "SupplierName";
            repSNM.ValueMember = "ID";
        }

        void InitProducts()
        {
            ServerToClient sc = new ServerToClient();
            ProductContext px = new ProductContext();
            sc = px.GetProductSimple();
            luePNM.Properties.DataSource = sc.DT;
            luePNM.Properties.DisplayMember = "ProductName";
            luePNM.Properties.ValueMember = "ID";
            repPNM.DataSource = sc.DT;
            repPNM.DisplayMember = "ProductName";
            repPNM.ValueMember = "ID";

            sc = px.GetCategories();
            lueCAT.Properties.DataSource = sc.DT;
            lueCAT.Properties.DisplayMember = "CategoryName";
            lueCAT.Properties.ValueMember = "ID";
            repCAT.DataSource = sc.DT;
            repCAT.DisplayMember = "CategoryName";
            repCAT.ValueMember = "ID";
            repCNM.DataSource = sc.DT;
            repCNM.DisplayMember = "CategoryName";
            repCNM.ValueMember = "ID";
        }

        void InitSubCategory(int CategoryID)
        {
            ProductContext pc = new ProductContext();
            ServerToClient sc = new ServerToClient();
            sc = pc.GetSubCategory(CategoryID);
            cboSCT.Properties.Items.Clear();
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
            cboCMP.Properties.Items.Clear();
            for (int i = 0; i <= sc.DT.Rows.Count - 1; i++)
            {
                cboCMP.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
            }
        }

        void InitInvoiceNo()
        {
            MySettings m = new MySettings();
            txtINV.Text = m.GetInvoiceNo(DateTime.Now.Date, "purchase", "KVM");
        }

        public frmPurchase()
        {
            InitializeComponent();
            dtpPDT.DateTime = DateTime.Now;
            InitSuppliers();
            InitProducts();
            InitDataTable();
            InitInvoiceNo();
            InitCompany();
        }

        void Reset()
        {
            InitInvoiceNo();
            lueSUP.EditValue = null;
            lueCAT.EditValue = null;
            cboSCT.SelectedIndex = -1;
            cboCMP.SelectedIndex = -1;
            luePNM.EditValue = null;
            txtBVL.EditValue = 0;
            txtSVL.EditValue = 0;
            txtMFG.EditValue = "";
            txtEXP.EditValue = "";
            txtPKG.EditValue = "";
            txtQTY.EditValue = 0;
            txtAMT.EditValue = 0;
            txtPAM.EditValue = 0;
            txtBAL.EditValue = 0;
            dt = new DataTable();
            InitDataTable();
            grd.DataSource = dt;
            grd.Refresh();

            lueSUP.Focus();
        }

        private void lueSUP_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index == 1)
            {
                frmSupplier frm = new frmSupplier("");
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    ServerToClient sc = new ServerToClient();
                    SupplierContext sx = new SupplierContext();
                    Supplier s = new Supplier();
                    s.SupplierName = frm.SNM;
                    s.Address = frm.ADR;
                    s.Phone = frm.PHN;
                    s.CST = frm.CST;
                    s.TIN = frm.TIN;

                    sc = sx.AddSupplier(s);
                    if (sc.Message == null)
                    {
                        InitSuppliers();
                        lueSUP.EditValue = sc.Count;
                    }
                    else
                        XtraMessageBox.Show(sc.Message);
                }
            }
            else if(e.Button.Index == 2)
            {
                lueSUP.EditValue = null;
            }
        }

        private void lueCAT_EditValueChanged(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(lueCAT.EditValue);
            InitSubCategory(cid);
        }

        private void lueCAT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index == 1)
            {
                frmCategory frm = new frmCategory();
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    ServerToClient sc = new ServerToClient();
                    ProductContext px = new ProductContext();
                    Category c = new Category();
                    c.CategoryName = frm.CNM;

                    sc = px.AddCategory(c);

                    if(sc.Message == null)
                    {
                        InitProducts();
                        lueCAT.EditValue = sc.Count;
                    }
                    else
                    {
                        XtraMessageBox.Show(sc.Message);
                    }
                }
            }
        }
        private void luePNM_EditValueChanged(object sender, EventArgs e)
        {
            int PID = Convert.ToInt32(luePNM.EditValue);
            //int pdid = Convert.ToInt32(luePNM.Properties.View.GetFocusedRowCellValue("ProductDetailID"));
            ProductContext px = new ProductContext();
            Product p = new Product();
            //ProductDetail d = new ProductDetail();
            p = px.GetProduct(PID);
            //d = px.GetProductDetail(pdid);
            lueCAT.EditValue = p.Category;
            cboSCT.Text = p.SubCategory;
            cboCMP.Text = p.Company;
            txtPKG.Text = p.PackageSize;

            //txtQTY.Properties.MaxValue = d.Quantity;
        }

        private void luePNM_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index == 1)
            {
                ServerToClient sc = new ServerToClient();
                ProductContext px = new ProductContext();
                Product p = new Product();

                frmNewProduct frm;
                if (luePNM.EditValue != null)
                {
                    int ID = Convert.ToInt32(luePNM.EditValue);
                    p = px.GetProduct(ID);
                    frm = new frmNewProduct(p.Category, p.SubCategory, p.Company, p.ProductName, p.PackageSize);
                }
                else
                {
                    frm = new frmNewProduct();
                }
                
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    p.Category = frm.CAT;
                    p.SubCategory = frm.SCT;
                    p.Company = frm.CMP;
                    p.ProductName = frm.PNM;
                    p.PackageSize = frm.PKG;

                    sc = px.AddProduct(p);

                    if (sc.Message == null)
                    {
                        InitProducts();
                        luePNM.EditValue = sc.Count;
                        p = px.GetProduct(sc.Count);

                        lueCAT.EditValue = p.Category;
                        cboSCT.Text = p.SubCategory;
                        cboCMP.Text = p.Company;
                        txtPKG.Text = p.PackageSize;
                    }
                    else
                        XtraMessageBox.Show(sc.Message);
                }
            }
        }

        private void txtBCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataRow r = dt.NewRow();
                if(lueSUP.EditValue == null)
                {
                    if(XtraMessageBox.Show("Are you sure you want to purchase without selecting Supplier?", "Supplier", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Supplier s = new Supplier();
                        SupplierContext sx = new SupplierContext();
                        s = sx.DefaultSupplier();
                        r["Supplier"] = s.ID;
                    }
                }
                else
                r["Supplier"] = lueSUP.EditValue;
                r["Category"] = lueCAT.EditValue;
                r["SubCategory"] = cboSCT.Text;
                r["Company"] = cboCMP.Text;
                r["ProductName"] = luePNM.EditValue;
                r["BuyingValue"] = txtBVL.EditValue;
                r["SellingValue"] = txtSVL.EditValue;
                r["MfgDate"] = txtMFG.EditValue;
                r["ExpDate"] = txtEXP.EditValue;
                r["PackageSize"] = txtPKG.Text;
                r["Quantity"] = txtQTY.EditValue;
                r["BarCode"] = txtBCD.Text;
                r["Amount"] = Convert.ToInt32(txtQTY.EditValue) * Convert.ToDouble(txtBVL.EditValue);
                dt.Rows.Add(r);
                grd.DataSource = dt;

                txtBCD.Text = "";
                txtBCD.Focus();

                double TotalAmount = Convert.ToDouble(colAMT.SummaryText);
                txtAMT.Text = TotalAmount.ToString();
                txtPAM.Text = TotalAmount.ToString();
            }
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            DataRow r = dt.NewRow();
            if (lueSUP.EditValue == null)
            {
                if (XtraMessageBox.Show("Are you sure you want to purchase without selecting Supplier?", "Supplier", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Supplier s = new Supplier();
                    SupplierContext sx = new SupplierContext();
                    s = sx.DefaultSupplier();
                    r["Supplier"] = s.ID;
                    
                    lueSUP.EditValue = s.ID;
                }
            }
            else
            r["Supplier"] = lueSUP.EditValue;
            r["Category"] = lueCAT.EditValue;
            r["SubCategory"] = cboSCT.Text;
            r["Company"] = cboCMP.Text;
            r["ProductName"] = luePNM.EditValue;
            r["BuyingValue"] = txtBVL.EditValue;
            r["SellingValue"] = txtSVL.EditValue;
            r["MfgDate"] = txtMFG.EditValue;
            r["ExpDate"] = txtEXP.EditValue;
            r["PackageSize"] = txtPKG.Text;
            r["Quantity"] = txtQTY.EditValue;
            r["BarCode"] = txtBCD.Text;
            r["Amount"] = Convert.ToInt32(txtQTY.EditValue) * Convert.ToDouble(txtBVL.EditValue);
            dt.Rows.Add(r);
            grd.DataSource = dt;

            double TotalAmount = Convert.ToDouble(colAMT.SummaryText);
            txtAMT.Text = TotalAmount.ToString();
            txtPAM.Text = TotalAmount.ToString();
        }

        private void grv_Click(object sender, EventArgs e)
        {
            GridHitInfo hi = grv.CalcHitInfo(grd.PointToClient(MousePosition));
            if (hi.InRowCell && hi.Column == colEDT)
            {
                if (XtraMessageBox.Show("Do you really want to remove this product from Purchase list?", "Confirm remove", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    grv.DeleteRow(hi.RowHandle);
                    double TotalAmount = Convert.ToDouble(colAMT.SummaryText);
                    txtAMT.EditValue = TotalAmount;
                    txtPAM.EditValue = TotalAmount;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int SupplierID = 0;
            SupplierContext sx = new SupplierContext();
            Supplier s = new Supplier();

            if (lueSUP.EditValue == null)
            {
                s = sx.DefaultSupplier();
                SupplierID = s.ID;
            }
            else
                SupplierID = Convert.ToInt32(lueSUP.EditValue);

            ServerToClient sc = new ServerToClient();
            PurchaseContext px = new PurchaseContext();
            Purchase pp = new Purchase();

            pp.InvoiceNo = txtINV.Text;
            pp.PurchaseDate = dtpPDT.DateTime;
            pp.SupplierID = SupplierID;
            pp.Amount = Convert.ToDouble(txtAMT.EditValue);
            pp.Payment = Convert.ToDouble(txtPAM.EditValue);
            pp.Balance = Convert.ToInt32(txtBAL.EditValue);

            sc = px.AddPurchase(pp);

            if(sc.Message != null)
            {
                XtraMessageBox.Show(sc.Message);
                return;
            }

            SupplierAccount sa = new SupplierAccount();

            sa.SupplierID = SupplierID;
            sa.TransDate = dtpPDT.DateTime;
            sa.Description = "Purchase Invoice No:" + txtINV.Text;
            sa.Debit = Convert.ToDouble(txtAMT.EditValue);
            sa.Credit = Convert.ToDouble(txtPAM.EditValue);
            sa.Balance = Convert.ToDouble(txtBAL.EditValue);

            sc = sx.AddTrans(sa);

            if(sc.Message != null)
            {
                XtraMessageBox.Show(sc.Message);
                return;
            }

            

            for(int i = 0; i <= grv.RowCount - 1; i++)
            {
                PurchaseDetail pd = new PurchaseDetail();
                pd.InvoiceNo = txtINV.Text;
                pd.ProductID = Convert.ToInt32(grv.GetRowCellValue(i, colPNM));
                pd.BuyingValue = Convert.ToDouble(grv.GetRowCellValue(i, colBVL));
                pd.SellingValue = Convert.ToDouble(grv.GetRowCellValue(i, colSVL));
                pd.Quantity = Convert.ToInt32(grv.GetRowCellValue(i, colQTY));
                pd.Amount = pd.BuyingValue * pd.Quantity;

                sc = px.AddPurchaseDetail(pd);

                ProductContext PX = new ProductContext();
                ProductDetail pD = new ProductDetail();
                pD.ProductID = Convert.ToInt32(grv.GetRowCellValue(i, colPNM));
                pD.BuyingValue = Convert.ToDouble(grv.GetRowCellValue(i, colBVL));
                pD.SellingValue = Convert.ToDouble(grv.GetRowCellValue(i, colSVL));
                pD.MfgDate = grv.GetRowCellValue(i, colMFG).ToString();
                pD.ExpDate = grv.GetRowCellValue(i, colEXP).ToString();
                pD.Quantity = Convert.ToInt32(grv.GetRowCellValue(i, colQTY));
                pD.BarCode = grv.GetRowCellValue(i, colBCD).ToString();
                pD.Supplier = Convert.ToInt32(grv.GetRowCellValue(i, colSUP));

                sc = PX.AddProductDetail(pD);
            }
            Reset();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}