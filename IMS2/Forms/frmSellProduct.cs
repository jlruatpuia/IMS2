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
using IMS2.Reports;
using DevExpress.XtraReports.UI;

namespace IMS2.Forms
{
    public partial class frmSellProduct : XtraForm
    {
        DataTable dt = new DataTable();
        public double CustomerBalance { get; set; }
        void InitDataTable()
        {
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("BarCode", typeof(string));
            dt.Columns.Add("SellingValue", typeof(double));
            dt.Columns.Add("BuyingValue", typeof(double));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Amount", typeof(double));
        }

        void Clear()
        {
            luePNM.EditValue = null;
            txtBVL.EditValue = 0;
            txtSVL.EditValue = 0;
            txtQTY.EditValue = 0;
            txtAMT.EditValue = 0;
        }

        void Reset()
        {
            InitInvoiceNo();
            lueCNM.EditValue = null;
            //lueCAT.EditValue = null;
            Clear();
            dt = new DataTable();
            InitDataTable();
            grd.DataSource = dt;
            grd.Refresh();
            txtTAM.EditValue = 0;
            txtPAM.EditValue = 0;
            txtDSC.EditValue = 0;
            txtBAL.EditValue = 0;
        }

        void InitInvoiceNo()
        {
            MySettings m = new MySettings();
            txtINV.Text = m.GetInvoiceNo(DateTime.Now.Date, "sale", "KVM");
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

        void InitProducts()
        {
            ServerToClient sc = new ServerToClient();
            ProductContext pc = new ProductContext();
            sc = pc.GetProducts();
            luePNM.Properties.DataSource = sc.DT;
            luePNM.Properties.DisplayMember = "ProductName";
            luePNM.Properties.ValueMember = "ID";
        }

        public frmSellProduct()
        {
            InitializeComponent();

            InitDataTable();

            dtpSDT.DateTime = DateTime.Now.Date;

            InitInvoiceNo();
            InitCustomers();
            InitProducts();
        }

        private void lueCNM_EditValueChanged(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(lueCNM.EditValue);

            CustomerContext cc = new CustomerContext();
            ServerToClient sc = new ServerToClient();

            sc = cc.GetCustomerBalance(cid);
            CustomerBalance = sc.Value;
        }

        private void txtBCD_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                lblMSG.Text = "";
                string bcd = txtBCD.Text.ToUpper();
                ProductContext pc = new ProductContext();
                Product p = new Product();
                ProductDetail d = new ProductDetail();
                p = pc.GetProduct(bcd);
                d = pc.GetProductDetail(bcd);

                if(d.Quantity <= 0)
                {
                    lblMSG.Text = "Product not available right now";
                    txtBCD.Text = "";
                    return;
                }
                if (p.Message == null)
                {
                    dt.Rows.Add(p.ID, p.ProductName, d.BarCode, d.SellingValue, d.BuyingValue, 1, d.SellingValue);
                    grd.DataSource = dt;
                    grd.Refresh();

                    double TotalAmount = Convert.ToDouble(colAMT.SummaryText);
                    txtTAM.Text = TotalAmount.ToString();
                    txtPAM.Text = TotalAmount.ToString();
                }
                else
                    lblMSG.Text = p.Message;
                txtBCD.Text = "";
                txtBCD.Focus();
            }
        }

        private void luePNM_EditValueChanged(object sender, EventArgs e)
        {
            if(luePNM.EditValue != null)
            {
                int pid = Convert.ToInt32(luePNM.EditValue);

                ProductContext pc = new ProductContext();
                Product p = new Product();
                ProductDetail d = new ProductDetail();
                p = pc.GetProduct(pid);
                d = pc.GetProductDetail(pid);

                txtBVL.EditValue = d.BuyingValue;
                txtSVL.EditValue = d.SellingValue;
                txtQTY.Properties.MaxValue = d.Quantity;
                if (d.Quantity <= 0)
                    btnAdd.Enabled = false;
                else
                {
                    txtQTY.EditValue = 1;
                    btnAdd.Enabled = true;
                }
                txtAMT.EditValue = d.SellingValue * 1;
            }
            else
            {
                txtBVL.EditValue = 0;
                txtSVL.EditValue = 0;
                txtQTY.EditValue = 0;
                txtAMT.EditValue = 0;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string bcd = txtBCD.Text.ToUpper();
            ProductContext pc = new ProductContext();
            Product p = new Product();
            ProductDetail d = new ProductDetail();
            int pid = Convert.ToInt32(luePNM.EditValue);
            p = pc.GetProduct(pid);
            d = pc.GetProductDetail(pid);
            if (d.Quantity <= 0)
            {
                lblMSG.Text = "Product not available right now";
            }
            if (p.Message == null)
            {
                dt.Rows.Add(pid, p.ProductName, d.BarCode, d.SellingValue, d.BuyingValue, 1, d.SellingValue);
                grd.DataSource = dt;
                grd.Refresh();

                double TotalAmount = Convert.ToDouble(colAMT.SummaryText);
                txtTAM.Text = TotalAmount.ToString();
                txtPAM.Text = TotalAmount.ToString();

                Clear();
            }
            else
                lblMSG.Text = p.Message;
            
        }

        private void grv_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            double svl = Convert.ToDouble(grv.GetFocusedRowCellValue(colSVL));
            int qty = Convert.ToInt32(grv.GetFocusedRowCellValue(colQTY));
            double amt = qty * svl;
            grv.SetFocusedRowCellValue(colAMT, amt);

            grv.UpdateSummary();

            double TotalAmount = Convert.ToDouble(colAMT.SummaryText);
            txtTAM.Text = TotalAmount.ToString();
            txtPAM.Text = TotalAmount.ToString();
        }

        private void grv_Click(object sender, EventArgs e)
        {
            GridHitInfo hi = grv.CalcHitInfo(grd.PointToClient(MousePosition));
            if (hi.InRowCell && hi.Column == colDel)
            {
                if (XtraMessageBox.Show("Do you really want to remove this product from Sales list?", "Confirm remove", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    grv.DeleteRow(hi.RowHandle);

                    grv.UpdateSummary();

                    double TotalAmount = Convert.ToDouble(colAMT.SummaryText);
                    txtTAM.EditValue = TotalAmount;
                    txtPAM.EditValue = TotalAmount;
                }
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

            sc = ss.AddSale(s);

            CustomerContext cc = new CustomerContext();
            CustomerAccount ca = new CustomerAccount();
            //Customer c = new Customer();

            ca.CustomerID = Convert.ToInt32(lueCNM.EditValue);
            ca.TransDate = s.SellDate;
            ca.Description = s.InvoiceNo;

            //c.CustomerName = cc.GetCustomer(ca.CustomerID).CustomerName;


            if (s.Balance == 0)
            {
                ca.Debit = s.Payment;
                ca.Credit = s.Payment;
            }
            else
            {
                ca.Debit = s.Amount - s.Discount;
                ca.Credit = s.Payment;
            }
            ca.Balance = CustomerBalance + s.Balance;
            sc = cc.AddTrans(ca);

            if (sc.Message == null)
            {
                for (int i = 0; i <= grv.RowCount - 1; i++)
                {
                    sd.InvoiceNo = txtINV.Text;
                    sd.Product = Convert.ToInt32(grv.GetRowCellValue(i, colPID));
                    sd.BuyingValue = Convert.ToDouble(grv.GetRowCellValue(i, colBVL));
                    sd.SellingValue = Convert.ToDouble(grv.GetRowCellValue(i, colSVL));
                    sd.Quantity = Convert.ToInt32(grv.GetRowCellValue(i, colQTY));
                    sd.Amount = Convert.ToDouble(grv.GetRowCellValue(i, colAMT));

                    sc = ss.AddSaleDetails(sd);
                    if (sc.Message != null)
                    {
                        XtraMessageBox.Show(sc.Message);
                        break;
                    }
                    else
                    {
                        ProductContext pc = new ProductContext();
                        sc = pc.updateQuantity(sd.Product, sd.Quantity, "-");
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(sc.Message);
                return;
            }
            if(XtraMessageBox.Show("Product(s) sold. Print Receipt?", "Print", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sc = new ServerToClient();
                ss = new SalesContext();
                sc = ss.GetSales(txtINV.Text);
                rptSaleInvoice rpt = new rptSaleInvoice() { DataSource = sc.DT };
                rpt.lbCNM.Text = cc.GetCustomer(ca.CustomerID).CustomerName;
                rpt.lbADR.Text = cc.GetCustomer(ca.CustomerID).Address;
                rpt.lbPHN.Text = cc.GetCustomer(ca.CustomerID).Phone;

                rpt.lbINV.Text = txtINV.Text;
                rpt.lbSDT.Text = dtpSDT.DateTime.ToShortDateString();

                rpt.lbPNM.DataBindings.Add("Text", null, "ProductName");
                rpt.lbBCD.DataBindings.Add("Text", null, "BarCode");
                rpt.lbQTY.DataBindings.Add("Text", null, "Quantity");
                rpt.lbPRC.DataBindings.Add("Text", null, "SellingValue", "{0:c}");
                rpt.lbAMT.DataBindings.Add("Text", null, "Amount", "{0:c}");

                if (s.Discount > 0)
                {
                    rpt.xrLabel3.Visible = true;
                    rpt.lbDSC.Text = "(-) " + s.Discount.ToString("c2");
                }
                else
                {
                    rpt.xrLabel3.Visible = false;
                    rpt.lbDSC.Text = "";
                }

                rpt.lbTTL.Text = (s.Amount - s.Discount).ToString("c2");
                rpt.lbWRD.Text = "Rupees " + MySettings.NumbersToWords(Convert.ToInt32(s.Amount - s.Discount)) + " only";

                rpt.ShowPreviewDialog();

            }
            grd.DataSource = null;
            InitInvoiceNo();
            //lueCAT.EditValue = null;
            //luePNM.EditValue = null;
            //lueCAT.Properties.DataSource = null;
            //luePNM.Properties.DataSource = null;
            //InitCategories();
            InitProducts();
            dt.Clear();
            Reset();


        
            Reset();
        }

        private void txtDSC_EditValueChanged(object sender, EventArgs e)
        {
            double Amount = 0;
            double Discount = 0;

            if (txtTAM.EditValue != null || txtTAM.Text != "")
                Amount = Convert.ToDouble(txtTAM.EditValue);
            else
                Amount = 0;

            if (txtDSC.EditValue != null || txtDSC.Text != "")
                Discount = Convert.ToDouble(txtDSC.EditValue);
            else
                Discount = 0;
            txtPAM.Text = (Amount - Discount).ToString();
        }

        private void txtPAM_EditValueChanged(object sender, EventArgs e)
        {
            double Amount = 0;
            double Discount = 0;
            double Paid = 0;
            if (txtTAM.EditValue != null || txtTAM.Text != "")
                Amount = Convert.ToDouble(txtTAM.EditValue);
            else
                Amount = 0;

            if (txtDSC.EditValue != null || txtDSC.Text != "")
                Discount = Convert.ToDouble(txtDSC.EditValue);
            else
                Discount = 0;

            if (txtPAM.EditValue != null || txtPAM.Text != "")
                Paid = Convert.ToDouble(txtPAM.EditValue);
            else
                Paid = 0;

            double toPay = Amount - Discount;
            txtBAL.Text = (toPay - Paid).ToString();
        }

        private void lueCNM_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index == 1)
            {
                frmCustomer frm = new frmCustomer("");
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    ServerToClient sc = new ServerToClient();
                    CustomerContext cc = new CustomerContext();
                    Customer c = new Customer();
                    c.CustomerName = frm.CNM;
                    c.Address = frm.ADR;
                    c.Phone = frm.PHN;

                    sc = cc.AddCustomer(c);
                    if(sc.Message == null)
                    {
                        InitCustomers();
                        lueCNM.EditValue = sc.Count;
                    }
                }
            }
        }
    }
}