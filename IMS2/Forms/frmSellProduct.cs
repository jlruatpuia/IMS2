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
    public partial class frmSellProduct : DevExpress.XtraEditors.XtraForm
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
            lueCAT.EditValue = null;
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

        void InitSubCategories()
        {
            ServerToClient sc = new ServerToClient();
            ProductContext pc = new ProductContext();
            sc = pc.GetSubCategory();
            for(int i = 0; i <= sc.DT.Rows.Count - 1; i++)
            {
                cboSCT.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
            }
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

        void InitCompany()
        {
            ServerToClient sc = new ServerToClient();
            ProductContext pc = new ProductContext();
            sc = pc.GetCompany();
            for (int i = 0; i <= sc.DT.Rows.Count - 1; i++)
            {
                cboCMP.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
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
            InitSubCategories();
            InitCompany();
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

                p = pc.GetProduct(bcd);
                if(p.Quantity <= 0)
                {
                    lblMSG.Text = "Product not available right now";
                }
                if (p.Message == null)
                {
                    dt.Rows.Add(p.ID, p.ProductName, p.BarCode, p.SellingValue, p.BuyingValue, 1, p.SellingValue);
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

        private void lueCAT_EditValueChanged(object sender, EventArgs e)
        {
            ProductContext pc = new ProductContext();
            ServerToClient sc = new ServerToClient();

            cboSCT.Properties.Items.Clear();
            cboCMP.Properties.Items.Clear();

            if (lueCAT.EditValue != null)
            {
                int cid = Convert.ToInt32(lueCAT.EditValue);

                //sc = new ServerToClient();
                sc = pc.GetSubCategory(cid);

                for (int i = 0; i <= sc.DT.Rows.Count - 1; i++)
                {
                    cboSCT.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
                }

                //sc = new ServerToClient();
                sc = pc.GetCompany(cid);

                for(int i = 0; i <= sc.DT.Rows.Count - 1; i++)
                {
                    cboCMP.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
                }

                //sc = new ServerToClient();
                sc = pc.GetProducts(cid);

                luePNM.Properties.DataSource = sc.DT;
                luePNM.Properties.DisplayMember = "ProductName";
                luePNM.Properties.ValueMember = "ID";
            }
            else
            {
                //sc = new ServerToClient();
                sc = pc.GetSubCategory();
                for (int i = 0; i <= sc.DT.Rows.Count - 1; i++)
                {
                    cboSCT.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
                }

                //sc = new ServerToClient();
                sc = pc.GetCompany();
                for (int i = 0; i <= sc.DT.Rows.Count - 1; i++)
                {
                    cboCMP.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
                }

                //sc = new ServerToClient();
                sc = pc.GetProducts();

                luePNM.Properties.DataSource = sc.DT;
                luePNM.Properties.DisplayMember = "ProductName";
                luePNM.Properties.ValueMember = "ID";
            }
        }

        private void lueCAT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index == 1)
            {
                lueCAT.EditValue = null;
                luePNM.EditValue = null;
                cboSCT.SelectedIndex = -1;
                cboCMP.SelectedIndex = -1;
            }
        }

        private void cboSCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductContext pc = new ProductContext();
            ServerToClient sc = new ServerToClient();
            cboCMP.Properties.Items.Clear();
            if (lueCAT.EditValue == null)
            {
                //Category null
                if(cboSCT.SelectedIndex == -1)
                {
                    //SubCategory null
                    sc = pc.GetProducts();
                    luePNM.Properties.DataSource = sc.DT;
                }
                else
                {
                    //SubCategory value
                    sc = pc.GetCompany();
                    for (int i = 0; i <= sc.DT.Rows.Count - 1; i++)
                    {
                        cboCMP.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
                    }

                    sc = pc.GetProducts(cboSCT.Text);
                    luePNM.Properties.DataSource = sc.DT;
                }
            }
            else
            {
                //Category value
                int cid = Convert.ToInt32(lueCAT.EditValue);
                if (cboSCT.SelectedIndex == -1)
                {
                    //SubCategory null
                    sc = pc.GetCompany(cid);
                    for (int i = 0; i <= sc.DT.Rows.Count - 1; i++)
                    {
                        cboCMP.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
                    }
                    sc = pc.GetProducts(cid);
                    luePNM.Properties.DataSource = sc.DT;
                }
                else
                {
                    //SubCategory Value
                    sc = pc.GetCompany(cid, cboSCT.Text);
                    for (int i = 0; i <= sc.DT.Rows.Count - 1; i++)
                    {
                        cboCMP.Properties.Items.Add(sc.DT.Rows[i].ItemArray[0].ToString());
                    }
                    sc = pc.GetProducts(cid, cboSCT.Text);
                    luePNM.Properties.DataSource = sc.DT;
                }
            }
            
            luePNM.Properties.DisplayMember = "ProductName";
            luePNM.Properties.ValueMember = "ID";
        }

        private void cboCMP_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerToClient sc = new ServerToClient();
            ProductContext pc = new ProductContext();

            if(lueCAT.EditValue == null)
            {
                if(cboSCT.SelectedIndex == -1)
                {
                    if(cboCMP.SelectedIndex == -1)
                    {
                        sc = pc.GetProducts();
                        luePNM.Properties.DataSource = sc.DT;
                    }
                    else
                    {
                        sc = pc.GetProducts(cboCMP.Text, false);
                        luePNM.Properties.DataSource = sc.DT;
                    }
                }
                else
                {
                    if (cboCMP.SelectedIndex == -1)
                    {
                        sc = pc.GetProducts(cboSCT.Text);
                        luePNM.Properties.DataSource = sc.DT;
                    }
                    else
                    {
                        sc = pc.GetProducts(cboSCT.Text, cboCMP.Text);
                        luePNM.Properties.DataSource = sc.DT;
                    }
                }
            }
            else
            {
                int cid = Convert.ToInt32(lueCAT.EditValue);
                if (cboSCT.SelectedIndex == -1)
                {
                    if (cboCMP.SelectedIndex == -1)
                    {
                        sc = pc.GetProducts(cid);
                        luePNM.Properties.DataSource = sc.DT;
                    }
                }
                else
                {
                    if (cboCMP.SelectedIndex == -1)
                    {
                        sc = pc.GetProducts(cboSCT.Text);
                        luePNM.Properties.DataSource = sc.DT;
                    }
                    else
                    {
                        sc = pc.GetProducts(cboSCT.Text, cboCMP.Text);
                        luePNM.Properties.DataSource = sc.DT;
                    }
                }
            }
            luePNM.Properties.DisplayMember = "ProductName";
            luePNM.Properties.ValueMember = "ID";
        }

        private void luePNM_EditValueChanged(object sender, EventArgs e)
        {
            if(luePNM.EditValue != null)
            {
                int pid = Convert.ToInt32(luePNM.EditValue);

                ProductContext pc = new ProductContext();
                Product p = new Product();

                p = pc.GetProduct(pid);

                txtBVL.EditValue = p.BuyingValue;
                txtSVL.EditValue = p.SellingValue;
                txtQTY.Properties.MaxValue = p.Quantity;
                if (p.Quantity <= 0)
                    btnAdd.Enabled = false;
                else
                {
                    txtQTY.EditValue = 1;
                    btnAdd.Enabled = true;
                }
                txtAMT.EditValue = p.SellingValue * 1;
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
            int pid = Convert.ToInt32(luePNM.EditValue);
            p = pc.GetProduct(pid);
            if (p.Quantity <= 0)
            {
                lblMSG.Text = "Product not available right now";
            }
            if (p.Message == null)
            {
                dt.Rows.Add(pid, p.ProductName, p.BarCode, p.SellingValue, p.BuyingValue, 1, p.SellingValue);
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

            ca.CustomerID = Convert.ToInt32(lueCNM.EditValue);
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
                //--------------------------
                

            }
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