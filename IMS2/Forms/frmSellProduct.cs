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
    public partial class frmSellProduct : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();

        void InitDataTable()
        {
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("BarCode", typeof(string));
            dt.Columns.Add("SellingValue", typeof(double));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Amount", typeof(double));
        }
        void InitInvoiceNo()
        {
            MySettings m = new MySettings();
            txtINV.Text = m.GetInvoiceNo(DateTime.Now.Date, "sale", "SHN");
        }

        void InitCustomers()
        {
            ServerToClient sc = new ServerToClient();
            CustomerContext cc = new CustomerContext();
            sc = cc.GetCustomers();
            lueCNM.Properties.DataSource = sc.DT;
            lueCNM.Properties.DisplayMember = "CustomerName";
            lueCNM.Properties.ValueMember = "ID";
        }

        void InitCategories()
        {
            ServerToClient sc = new ServerToClient();
            ProductContext pc = new ProductContext();
            sc = pc.GetCategories();
            lueCAT.Properties.DataSource = sc.DT;
            lueCAT.Properties.DisplayMember = "CategoryName";
            lueCAT.Properties.ValueMember = "ID";
        }

        void InitSubCategories(int CategoryID)
        {
            ServerToClient sc = new ServerToClient();
            ProductContext pc = new ProductContext();
            sc = pc.GetSubCategory(CategoryID);
            for(int i = 0; i <= sc.DT.Rows.Count - 1; i++)
            {
                cboSCT.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
            }
        }

        void InitProducts(int Category)
        {
            ServerToClient sc = new ServerToClient();
            ProductContext pc = new ProductContext();
            sc = pc.GetProducts(Category);
            lueCAT.Properties.DataSource = sc.DT;
            lueCAT.Properties.DisplayMember = "ProductName";
            lueCAT.Properties.ValueMember = "ID";
        }

        void InitCompany()
        {
            ServerToClient sc = new ServerToClient();
            ProductContext pc = new ProductContext();
            sc = pc.GetCompany();
            for (int i = 0; i <= sc.DT.Rows.Count - 1; i++)
            {
                cboSCT.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
            }
        }

        public frmSellProduct()
        {
            InitializeComponent();

            InitDataTable();

            dtpSDT.DateTime = DateTime.Now.Date;

            InitInvoiceNo();
            InitCustomers();
            InitCategories();

        }

        private void txtBCD_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                lblMSG.Text = "";
                string bcd = txtBCD.Text.ToUpper();
                ProductContext pc = new ProductContext();
                Product p = new Product();

                p = pc.GetProduct(bcd);
                if (p.Message == null)
                {
                    dt.Rows.Add(p.ID, p.ProductName, p.BarCode, p.SellingValue, 1, p.SellingValue);
                    grd.DataSource = dt;
                    grd.Refresh();
                }
                else
                    lblMSG.Text = p.Message;
                txtBCD.Text = "";
                txtBCD.Focus();
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            ServerToClient sc = new ServerToClient();
            SalesContext ss = new SalesContext();
            Sale s = new Sale();
            SaleDetail sd = new SaleDetail();

            s.InvoiceNo = txtINV.Text;
            s.SellDate = dtpSDT.DateTime.Date;
            s.Customer = Convert.ToInt32(lueCNM.EditValue);
            s.Amount = Convert.ToDouble(txtTAM.Text);
            s.Discount = Convert.ToDouble(txtDSC.EditValue);
            s.Payment = Convert.ToDouble(txtPAM.Text);
            s.Balance = Convert.ToDouble(txtBAL.Text);

            for(int i = 0; i <= grv.RowCount - 1; i++)
            {

            }
        }
    }
}