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
using IMS2.Reports;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;

namespace IMS2.Forms
{
    public partial class frmQuickSale : DevExpress.XtraEditors.XtraForm
    {
        public double bvl { get; set; }
        public double svl { get; set; }
        public double qty { get; set; }
        public double amt { get; set; }

        DataTable dt = new DataTable();
        public int pdid { get; set; }
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
            dt.Columns.Add("ProductDetailID", typeof(int));
        }

        void Clear()
        {
            luePNM.EditValue = null;
            
        }

        void Reset()
        {
            txtINV.Text = InitInvoiceNo();
            Clear();
            dt = new DataTable();
            InitDataTable();
            grd.DataSource = dt;
            grd.Refresh();
            //txtTAM.EditValue = 0;
            dgAMT.Text = "0.00";
            //txtPAM.EditValue = 0;
            txtDSC.EditValue = 0;
            //txtBAL.EditValue = 0;
        }

        string InitInvoiceNo()
        {
            MySettings m = new MySettings();
            return m.GetInvoiceNo(DateTime.Now.Date, "KVM");
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
        
        public frmQuickSale()
        {
            InitializeComponent();

            InitDataTable();

            dtpSDT.DateTime = DateTime.Now;

            txtINV.Text = InitInvoiceNo();
            InitProducts();
        }

        private void txtBCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbM.Text = "";
                string bcd = txtBCD.Text.ToUpper();
                ProductContext pc = new ProductContext();
                Product p = new Product();
                ProductDetail d = new ProductDetail();

                p = pc.GetProduct(bcd);
                d = pc.GetProductDetail(bcd);

                if (d.Quantity <= 0)
                {
                    lbM.Text = "Product not available right now";
                    txtBCD.Text = "";
                    return;
                }
                if (p.Message == null)
                {
                    dt.Rows.Add(p.ID, p.ProductName, d.BarCode, d.SellingValue, d.BuyingValue, 1, d.SellingValue, d.ID);
                    grd.DataSource = dt;
                    grd.Refresh();

                    double TotalAmount = Convert.ToDouble(colAMT.SummaryText);
                    //txtTAM.Text = TotalAmount.ToString();
                    dgAMT.Text = TotalAmount.ToString();
                    //txtPAM.Text = TotalAmount.ToString();
                }
                else
                    lbM.Text = p.Message;
                txtBCD.Text = "";
                txtBCD.Focus();
            }
        }

        private void luePNM_EditValueChanged(object sender, EventArgs e)
        {
            if (luePNM.EditValue != null)
            {
                int pid = Convert.ToInt32(luePNM.EditValue);
                pdid = Convert.ToInt32(luePNM.Properties.View.GetFocusedRowCellValue("ProductDetailID"));

                ProductContext pc = new ProductContext();
                Product p = new Product();
                ProductDetail d = new ProductDetail();

                p = pc.GetProduct(pid);
                d = pc.GetProductDetail(pdid);

                bvl = d.BuyingValue;
                svl = d.SellingValue;
                if (d.Quantity <= 0)
                {
                    qty = 0;
                    btnAdd.Enabled = false;
                }
                else
                {
                    qty = 1;
                    btnAdd.Enabled = true;
                }
                amt = d.SellingValue * 1;
                //dgAMT.Text = (d.SellingValue * 1).ToString();
            }
            else
            {
                bvl = 0;
                svl = 0;
                qty = 0;
                amt = 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string bcd = txtBCD.Text.ToUpper();
            ProductContext pc = new ProductContext();
            Product p = new Product();
            ProductDetail d = new ProductDetail();
            int pid = Convert.ToInt32(luePNM.EditValue);
            //pdid = Convert.ToInt32(luePNM.Properties.View.GetFocusedRowCellValue("ProductDetailID"));
            //GridView view = luePNM.Properties.View;
            //int rowHandle = luePNM.Properties.GetIndexByKeyValue(luePNM.EditValue);
            //object row = luePNM.Properties.View.GetRow(rowHandle);

            //pdid = Convert.ToInt32(view.GetRowCellValue(rowHandle, fieldName));
            //object displayMember = (row as DataRowView).Row["ProductDetailID"];
            p = pc.GetProduct(pid);
            d = pc.GetProductDetail(pdid);

            if (d.Quantity <= 0)
            {
                lbM.Text = "Product not available right now";
            }
            if (p.Message == null)
            {
                //dt.Columns.Add("ID", typeof(int));
                //dt.Columns.Add("ProductName", typeof(string));
                //dt.Columns.Add("BarCode", typeof(string));
                //dt.Columns.Add("SellingValue", typeof(double));
                //dt.Columns.Add("BuyingValue", typeof(double));
                //dt.Columns.Add("Quantity", typeof(int));
                //dt.Columns.Add("Amount", typeof(double));
                //dt.Columns.Add("ProductDetailID", typeof(int));
                DataRow dr = dt.NewRow();
                dr["ID"] = pid;
                dr["ProductName"] = p.ProductName;
                dr["BarCode"] = d.BarCode;
                dr["SellingValue"] = d.SellingValue;
                dr["BuyingValue"] = d.BuyingValue;
                dr["Quantity"] = 1;
                dr["Amount"] = d.SellingValue;
                dr["ProductDetailID"] = d.ID;
                //dt.Rows.Add(pid, p.ProductName, d.BarCode, d.SellingValue, d.BuyingValue, 1, d.SellingValue, d.ID);
                dt.Rows.InsertAt(dr, 0);
                grd.DataSource = dt;
                grd.Refresh();

                double TotalAmount = Convert.ToDouble(colAMT.SummaryText);
                //txtTAM.Text = TotalAmount.ToString();
                dgAMT.Text = TotalAmount.ToString();
                //txtPAM.Text = TotalAmount.ToString();

                Clear();
            }
            else
                lbM.Text = p.Message;
        }

        private void grv_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            double svl = Convert.ToDouble(grv.GetFocusedRowCellValue(colSVL));
            int qty = Convert.ToInt32(grv.GetFocusedRowCellValue(colQTY));
            double amt = qty * svl;
            grv.SetFocusedRowCellValue(colAMT, amt);

            grv.UpdateSummary();

            double TotalAmount = Convert.ToDouble(colAMT.SummaryText);
            //txtTAM.Text = TotalAmount.ToString();
            dgAMT.Text = TotalAmount.ToString();
            //txtPAM.Text = TotalAmount.ToString();
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
                    //txtTAM.EditValue = TotalAmount;
                    dgAMT.Text = TotalAmount.ToString();
                    //txtPAM.EditValue = TotalAmount;
                }
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            ServerToClient sc = new ServerToClient();
            SalesContext ss = new SalesContext();
            Sale s = new Sale();
            SaleDetail sd = new SaleDetail();
            CustomerContext cc = new CustomerContext();
            CustomerAccount ca = new CustomerAccount();
            Customer c = new Customer();

            c = cc.DefaultCustomer();

            s.InvoiceNo = InitInvoiceNo();
            s.SellDate = dtpSDT.DateTime;
            s.Customer = Convert.ToInt32(c.ID);
            s.Amount = Convert.ToDouble(dgAMT.Text);
            s.Discount = Convert.ToDouble(txtDSC.EditValue);
            s.Payment = s.Amount - s.Discount;
            s.Balance = 0;

            sc = ss.AddSale(s);

            ca.CustomerID = Convert.ToInt32(c.ID);
            ca.TransDate = s.SellDate;
            ca.Description = s.InvoiceNo;

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
                    sd.InvoiceNo = s.InvoiceNo;
                    sd.Product = Convert.ToInt32(grv.GetRowCellValue(i, colPID));
                    sd.BuyingValue = Convert.ToDouble(grv.GetRowCellValue(i, colBVL));
                    sd.SellingValue = Convert.ToDouble(grv.GetRowCellValue(i, colSVL));
                    sd.Quantity = Convert.ToInt32(grv.GetRowCellValue(i, colQTY));
                    sd.Amount = Convert.ToDouble(grv.GetRowCellValue(i, colAMT));
                    pdid = Convert.ToInt32(grv.GetRowCellValue(i, colPDID));
                    sc = ss.AddSaleDetails(sd);
                    if (sc.Message != null)
                    {
                        XtraMessageBox.Show(sc.Message);
                        break;
                    }
                    else
                    {
                        //int pdid = sc.Count;
                        ProductContext pc = new ProductContext();
                        sc = pc.updateQuantity(pdid, sd.Quantity, "-");
                        
                    }
                }
                if (XtraMessageBox.Show("Product(s) sold. Print Receipt?", "Print", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    rptQuickSale rpt = new rptQuickSale();
                    ss = new SalesContext();
                    sc = ss.QuickSaleReport(s.InvoiceNo);
                    rpt.DataSource = sc.DT;
                    XRSummary qty = new XRSummary();
                    qty.Running = SummaryRunning.Report;

                    rpt.lbINV.Text = s.InvoiceNo;

                    rpt.lbSDT.Text = s.SellDate.ToShortDateString() + ", " + s.SellDate.ToShortTimeString();
                    rpt.lbQTY.DataBindings.Add("Text", null, "Quantity");
                    rpt.lbITM.DataBindings.Add("Text", null, "productname");
                    rpt.lbPRC.DataBindings.Add("Text", null, "Amount", "{0:C2}");
                    //rpt.lbTQT.Text = sc.Count.ToString();
                    rpt.lbTQT.DataBindings.Add("Text", null, "Quantity");
                    
                    rpt.lbSTT.Text = s.Amount.ToString("C", Cultures.India);
                    if (s.Discount > 0)
                        rpt.lbDSC.Text = s.Discount.ToString("C", Cultures.India);
                    else
                    {
                        rpt.xrTableCell1.Visible = false;
                        rpt.lbDSC.Visible = false;
                    }
                    rpt.lbTTL.Text = (s.Amount - s.Discount).ToString("C", Cultures.India);
                    rpt.lbTQT.Summary = qty;
                    rpt.PrinterName = Properties.Settings.Default.ReceiptPrinter;
                    rpt.ShowPrintMarginsWarning = false;
                    ReportPrintTool rp = new ReportPrintTool(rpt);
                    rp.Print();
                    //rpt.PrintDialog();
                }
            }
            else
            {
                XtraMessageBox.Show(sc.Message);
                return;
            }
            
            Reset();
        }

        private void txtDSC_EditValueChanged(object sender, EventArgs e)
        {
            double Amount = 0;
            double Discount = 0;

            if (dgAMT.Text != "" || dgAMT.Text != "0.00")
            {
                Amount = Convert.ToDouble(dgAMT.Text);
                lbTTL.Text = (Amount - Convert.ToDouble(txtDSC.EditValue)).ToString("C2");
            }
            else
                Amount = 0;

            if (txtDSC.EditValue != null || txtDSC.Text != "")
                Discount = Convert.ToDouble(txtDSC.EditValue);
            else
                Discount = 0;
            //txtPAM.Text = (Amount - Discount).ToString();
        }

        private void txtPAM_EditValueChanged(object sender, EventArgs e)
        {
            double Amount = 0;
            double Discount = 0;
            //double Paid = 0;
            if (dgAMT.Text != "" || dgAMT.Text != "0.00")
                Amount = Convert.ToDouble(dgAMT.Text);
            else
                Amount = 0;

            if (txtDSC.EditValue != null || txtDSC.Text != "")
                Discount = Convert.ToDouble(txtDSC.EditValue);
            else
                Discount = 0;

            //if (txtPAM.EditValue != null || txtPAM.Text != "")
            //    Paid = Convert.ToDouble(txtPAM.EditValue);
            //else
            //    Paid = 0;

            double toPay = Amount - Discount;
            //txtBAL.Text = (toPay - Paid).ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}