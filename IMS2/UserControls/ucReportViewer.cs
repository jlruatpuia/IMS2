using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using IMS2.Codes;
using IMS2.Reports;
using IMS2.Forms;

namespace IMS2.UserControls
{
    public partial class ucReportViewer : XtraUserControl
    {
        public ucReportViewer()
        {
            InitializeComponent();
        }

        public ucReportViewer(XtraReport rpt)
        {
            InitializeComponent();

            dv.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument(true);
        }

        private void bProducts_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProductContext px = new ProductContext();
            ServerToClient sc = new ServerToClient();
            sc = px.GetProductReport();
            rptStockReport rpt = new rptStockReport() { DataSource = sc.DT };
            XRSummary sqt = new XRSummary();
            XRSummary sbv = new XRSummary();
            XRSummary ssv = new XRSummary();
            XRSummary scp = new XRSummary();
            XRSummary ssp = new XRSummary();
            XRSummary gqt = new XRSummary();
            XRSummary gbv = new XRSummary();
            XRSummary gsv = new XRSummary();
            XRSummary gcp = new XRSummary();
            XRSummary gsp = new XRSummary();

            GroupField grp = new GroupField("CategoryName");
            rpt.GroupHeader1.GroupFields.Add(grp);

            rpt.lbCAT.DataBindings.Add("Text", null, "CategoryName");
            rpt.lbSCT.DataBindings.Add("Text", null, "SubCategory");
            rpt.lbCMP.DataBindings.Add("Text", null, "Company");
            rpt.lbPNM.DataBindings.Add("Text", null, "ProductName");
            rpt.lbQTY.DataBindings.Add("Text", null, "TotalQuantity");
            rpt.lbBVL.DataBindings.Add("Text", null, "BuyingValue", "{0:C2}");
            rpt.lbSVL.DataBindings.Add("Text", null, "SellingValue", "{0:C2}");
            rpt.lbCPR.DataBindings.Add("Text", null, "TotalBuyingValue", "{0:C2}");
            rpt.lbSPR.DataBindings.Add("Text", null, "TotalSellingValue", "{0:C2}");
            rpt.lbTQT.DataBindings.Add("Text", null, "TotalQuantity");
            rpt.lbTBV.DataBindings.Add("Text", null, "BuyingValue", "{0:C2}");
            rpt.lbTSV.DataBindings.Add("Text", null, "SellingValue", "{0:C2}");
            rpt.lbTCP.DataBindings.Add("Text", null, "TotalBuyingValue", "{0:C2}");
            rpt.lbTSP.DataBindings.Add("Text", null, "TotalSellingValue", "{0:C2}");
            rpt.lbGQT.DataBindings.Add("Text", null, "TotalQuantity");
            rpt.lbGBV.DataBindings.Add("Text", null, "BuyingValue", "{0:C2}");
            rpt.lbGSV.DataBindings.Add("Text", null, "SellingValue", "{0:C2}");
            rpt.lbGCP.DataBindings.Add("Text", null, "TotalBuyingValue", "{0:C2}");
            rpt.lbGSP.DataBindings.Add("Text", null, "TotalSellingValue", "{0:C2}");

            sqt.Running = SummaryRunning.Group;
            rpt.lbTQT.Summary = sqt;

            sbv.FormatString = "{0:C2}";
            sbv.Running = SummaryRunning.Group;
            rpt.lbTBV.Summary = sbv;
            ssv.FormatString = "{0:C2}";
            ssv.Running = SummaryRunning.Group;
            rpt.lbTSV.Summary = ssv;
            scp.FormatString = "{0:C2}";
            scp.Running = SummaryRunning.Group;
            rpt.lbTCP.Summary = scp;
            ssp.FormatString = "{0:C2}";
            ssp.Running = SummaryRunning.Group;
            rpt.lbTSP.Summary = ssp;

            gqt.Running = SummaryRunning.Report;
            rpt.lbGQT.Summary = gqt;

            gbv.FormatString = "{0:C2}";
            gbv.Running = SummaryRunning.Report;
            rpt.lbGBV.Summary = gbv;
            gsv.FormatString = "{0:C2}";
            gsv.Running = SummaryRunning.Report;
            rpt.lbGSV.Summary = gsv;
            gcp.FormatString = "{0:C2}";
            gcp.Running = SummaryRunning.Report;
            rpt.lbGCP.Summary = gcp;
            gsp.FormatString = "{0:C2}";
            gsp.Running = SummaryRunning.Report;
            rpt.lbGSP.Summary = gsp;

            dv.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument(true);
           
        }

        private void bsSupplier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ServerToClient sc = new ServerToClient();
            SupplierContext sx = new SupplierContext();
            sc = sx.GetSuppliers();
            rptSupplier rpt = new rptSupplier();
            rpt.DataSource = sc.DT;

            rpt.lbSNM.DataBindings.Add("Text", null, "SupplierName");
            rpt.lbADR.DataBindings.Add("Text", null, "Address");
            rpt.lbPHN.DataBindings.Add("Text", null, "Phone");
            dv.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument(true);
        }

        private void bsSupplierDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ServerToClient sc = new ServerToClient();
            SupplierContext sx = new SupplierContext();
            sc = sx.SupplierDetailReport();
            rptSupplierDetail rpt = new rptSupplierDetail();
            rpt.DataSource = sc.DT;

            GroupField snm = new GroupField("SupplierName");
            GroupField adr = new GroupField("Address");
            GroupField phn = new GroupField("Phone");

            XRSummary tdr = new XRSummary();
            XRSummary tcr = new XRSummary();
            XRSummary tbl = new XRSummary();
            XRSummary gdr = new XRSummary();
            XRSummary gcr = new XRSummary();
            XRSummary gbl = new XRSummary();


            rpt.GroupHeader1.GroupFields.Add(snm);
            rpt.GroupHeader1.GroupFields.Add(adr);
            rpt.GroupHeader1.GroupFields.Add(phn);

            rpt.lbSNM.DataBindings.Add("Text", null, "SupplierName");
            rpt.lbADR.DataBindings.Add("Text", null, "Address");
            rpt.lbPHN.DataBindings.Add("Text", null, "Phone");
            rpt.lbTDT.DataBindings.Add("Text", null, "TransDate", "{0:dd-MM-yyyy}");
            rpt.lbREF.DataBindings.Add("Text", null, "Description");
            rpt.lbDBT.DataBindings.Add("Text", null, "Debit", "{0:C2}");
            rpt.lbCDT.DataBindings.Add("Text", null, "Credit", "{0:C2}");
            rpt.lbBAL.DataBindings.Add("Text", null, "Balance", "{0:C2}");
            rpt.lbTDR.DataBindings.Add("Text", null, "Debit", "{0:C2}");
            rpt.lbTCR.DataBindings.Add("Text", null, "Credit", "{0:C2}");
            rpt.lbTBL.DataBindings.Add("Text", null, "Balance", "{0:C2}");
            rpt.lbGDR.DataBindings.Add("Text", null, "Debit", "{0:C2}");
            rpt.lbGCR.DataBindings.Add("Text", null, "Credit", "{0:C2}");
            rpt.lbGBL.DataBindings.Add("Text", null, "Balance", "{0:C2}");
            tdr.FormatString = "{0:C2}";
            tdr.Running = SummaryRunning.Group;
            rpt.lbTDR.Summary = tdr;
            tcr.FormatString = "{0:C2}";
            tcr.Running = SummaryRunning.Group;
            rpt.lbTCR.Summary = tcr;
            tbl.FormatString = "{0:C2}";
            tbl.Running = SummaryRunning.Group;
            rpt.lbTBL.Summary = tbl;
            gdr.FormatString = "{0:C2}";
            gdr.Running = SummaryRunning.Report;
            rpt.lbGDR.Summary = gdr;
            gcr.FormatString = "{0:C2}";
            gcr.Running = SummaryRunning.Report;
            rpt.lbGCR.Summary = gcr;
            gbl.FormatString = "{0:C2}";
            gbl.Running = SummaryRunning.Report;
            rpt.lbGBL.Summary = gbl;

            dv.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument(true);
        }

        private void bSold_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDateRangeSelector frm = new frmDateRangeSelector();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                rptSoldProducts rpt = new rptSoldProducts();
                SalesContext sx = new SalesContext();
                ServerToClient sc = new ServerToClient();
                switch (frm.SelectedValue)
                {
                    case 1:
                        sc = sx.GetSales(frm.DateOn);
                        if (sc.DT.Rows.Count <= 0)
                        {
                            XtraMessageBox.Show("No Record found for Date: " + frm.DateOn.ToShortDateString());
                            return;
                        }
                        rpt.DataSource = sc.DT;
                        GroupField pdt = new GroupField("SellDate");
                        rpt.GroupHeader1.GroupFields.Add(pdt);
                        XRSummary sub_dsc = new XRSummary();
                        XRSummary sub_bal = new XRSummary();
                        XRSummary grn_dsc = new XRSummary();
                        XRSummary grn_bal = new XRSummary();
                        XRSummary sub_total = new XRSummary();
                        XRSummary grn_total = new XRSummary();

                        sub_dsc.FormatString = "{0:C2}";
                        sub_dsc.Running = SummaryRunning.Group;

                        grn_dsc.FormatString = "{0:C2}";
                        grn_dsc.Running = SummaryRunning.Report;

                        sub_bal.FormatString = "{0:C2}";
                        sub_bal.Running = SummaryRunning.Group;

                        grn_bal.FormatString = "{0:C2}";
                        grn_bal.Running = SummaryRunning.Report;

                        sub_total.FormatString = "{0:C2}";
                        sub_total.Running = SummaryRunning.Group;

                        grn_total.FormatString = "{0:C2}";
                        grn_total.Running = SummaryRunning.Report;

                        rpt.lbHDR.Text = "On " + frm.DateOn.ToShortDateString();
                        rpt.lbSDT.DataBindings.Add("Text", null, "SellDate", "{0:dd-MM-yyyy}");
                        rpt.lbPNM.DataBindings.Add("Text", null, "ProductName");
                        rpt.lbPKG.DataBindings.Add("Text", null, "PackageSize");
                        rpt.lbSLV.DataBindings.Add("Text", null, "SellingValue", "{0:C2}");
                        rpt.lbQTY.DataBindings.Add("Text", null, "TotalQuantity");
                        rpt.lbAMT.DataBindings.Add("Text", null, "Amount", "{0:C2}");
                        rpt.lbSAMT.DataBindings.Add("Text", null, "Amount");
                        rpt.lbTAMT.DataBindings.Add("Text", null, "Amount");
                        rpt.lbDSC.DataBindings.Add("Text", null, "Discount", "{0:C2}");
                        rpt.lbSDSC.DataBindings.Add("Text", null, "Discount");
                        rpt.lbTDSC.DataBindings.Add("Text", null, "Discount");
                        rpt.lbBAL.DataBindings.Add("Text", null, "Balance", "{0:C2}");
                        rpt.lbSBAL.DataBindings.Add("Text", null, "Balance");
                        rpt.lbTBAL.DataBindings.Add("Text", null, "Balance");

                        rpt.lbSDSC.Summary = sub_dsc;
                        rpt.lbTDSC.Summary = grn_dsc;
                        rpt.lbSBAL.Summary = sub_bal;
                        rpt.lbTBAL.Summary = grn_bal;
                        rpt.lbSAMT.Summary = sub_total;
                        rpt.lbTAMT.Summary = grn_total;
                        dv.PrintingSystem = rpt.PrintingSystem;
                        rpt.CreateDocument(true);
                        break;
                    case 2:
                        sc = sx.GetSales(frm.DateFr, frm.DateTo);
                        if (sc.DT.Rows.Count <= 0)
                        {
                            XtraMessageBox.Show("No Record found for Date between: " + frm.DateFr.ToShortDateString() + " and " + frm.DateTo.ToShortDateString());
                            return;
                        }
                        rpt.DataSource = sc.DT;
                        pdt = new GroupField("SellDate");
                        rpt.GroupHeader1.GroupFields.Add(pdt);
                        sub_dsc = new XRSummary();
                        sub_bal = new XRSummary();
                        grn_dsc = new XRSummary();
                        grn_bal = new XRSummary();
                        sub_total = new XRSummary();
                        grn_total = new XRSummary();

                        sub_dsc.FormatString = "{0:C2}";
                        sub_dsc.Running = SummaryRunning.Group;

                        grn_dsc.FormatString = "{0:C2}";
                        grn_dsc.Running = SummaryRunning.Report;

                        sub_bal.FormatString = "{0:C2}";
                        sub_bal.Running = SummaryRunning.Group;

                        grn_bal.FormatString = "{0:C2}";
                        grn_bal.Running = SummaryRunning.Report;

                        sub_total.FormatString = "{0:C2}";
                        sub_total.Running = SummaryRunning.Group;

                        grn_total.FormatString = "{0:C2}";
                        grn_total.Running = SummaryRunning.Report;

                        rpt.lbHDR.Text = "On " + frm.DateOn.ToShortDateString();
                        rpt.lbSDT.DataBindings.Add("Text", null, "SellDate", "{0:dd-MM-yyyy}");
                        rpt.lbPNM.DataBindings.Add("Text", null, "ProductName");
                        rpt.lbPKG.DataBindings.Add("Text", null, "PackageSize");
                        rpt.lbSLV.DataBindings.Add("Text", null, "SellingValue", "{0:C2}");
                        rpt.lbQTY.DataBindings.Add("Text", null, "TotalQuantity");
                        rpt.lbAMT.DataBindings.Add("Text", null, "Amount", "{0:C2}");
                        rpt.lbSAMT.DataBindings.Add("Text", null, "Amount");
                        rpt.lbTAMT.DataBindings.Add("Text", null, "Amount");
                        rpt.lbDSC.DataBindings.Add("Text", null, "Discount", "{0:C2}");
                        rpt.lbSDSC.DataBindings.Add("Text", null, "Discount");
                        rpt.lbTDSC.DataBindings.Add("Text", null, "Discount");
                        rpt.lbBAL.DataBindings.Add("Text", null, "Balance", "{0:C2}");
                        rpt.lbSBAL.DataBindings.Add("Text", null, "Balance");
                        rpt.lbTBAL.DataBindings.Add("Text", null, "Balance");

                        rpt.lbSDSC.Summary = sub_dsc;
                        rpt.lbTDSC.Summary = grn_dsc;
                        rpt.lbSBAL.Summary = sub_bal;
                        rpt.lbTBAL.Summary = grn_bal;
                        rpt.lbSAMT.Summary = sub_total;
                        rpt.lbTAMT.Summary = grn_total;
                        dv.PrintingSystem = rpt.PrintingSystem;
                        rpt.CreateDocument(true);
                        break;
                    case 3:
                        sc = new ServerToClient();
                        sx = new SalesContext();
                        //CustomerContext cx = new CustomerContext();
                        //Customer cc = new Customer();
                        //cc = cx.GetCustomer(sc.DT)
                        sc = sx.GetSales(frm.InvoiceNo);
                        rptSaleInvoice r = new rptSaleInvoice() { DataSource = sc.DT };
                        r.lbCNM.Text = sc.DT.Rows[0].ItemArray[0].ToString();
                        r.lbADR.Text = sc.DT.Rows[0].ItemArray[1].ToString();
                        r.lbPHN.Text = sc.DT.Rows[0].ItemArray[2].ToString();

                        r.lbINV.Text = frm.InvoiceNo;
                        DateTime sdt = DateTime.Parse(sc.DT.Rows[0].ItemArray[4].ToString());
                        r.lbSDT.Text = sdt.ToShortDateString();

                        r.lbPNM.DataBindings.Add("Text", null, "ProductName");
                        r.lbBCD.DataBindings.Add("Text", null, "BarCode");
                        r.lbQTY.DataBindings.Add("Text", null, "Quantity");
                        r.lbPRC.DataBindings.Add("Text", null, "SellingValue", "{0:c}");
                        r.lbAMT.DataBindings.Add("Text", null, "Amount", "{0:c}");

                        if (Convert.ToInt32(sc.DT.Rows[0].ItemArray[5]) > 0)
                        {
                            r.xrLabel3.Visible = true;
                            r.lbDSC.Text = "(-) " + sc.DT.Rows[0].ItemArray[5].ToString();
                        }
                        else
                        {
                            r.xrLabel3.Visible = false;
                            r.lbDSC.Text = "";
                        }

                        double amt = 0;
                        double bal = Convert.ToDouble(sc.DT.Rows[0].ItemArray[5]);

                        for (int i = 0; i <= sc.DT.Rows.Count - 1; i++)
                        {
                            amt = amt + Convert.ToDouble(sc.DT.Rows[i].ItemArray[10]);
                            //bal = bal + Convert.ToDouble(sc.DT.Rows[i].ItemArray[5]);
                        }

                        r.lbTTL.Text = (amt - bal).ToString("C2");
                        //r.lbTTL.Text = (s.Amount - s.Discount).ToString("c2");
                        r.lbWRD.Text = "Rupees " + MySettings.NumbersToWords(Convert.ToInt32(amt - bal)) + " only";
                        dv.PrintingSystem = r.PrintingSystem;
                        r.CreateDocument(true);
                        break;
                }
            }
        }

        private void bPurchased_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDateRangeSelector frm = new frmDateRangeSelector();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                rptPurchase rpt = new rptPurchase();
                PurchaseContext px = new PurchaseContext();
                ServerToClient sc = new ServerToClient();
                switch (frm.SelectedValue)
                {
                    case 1:
                        sc = px.ViewPurchase(frm.DateOn);
                        if(sc.DT.Rows.Count <= 0)
                        {
                            XtraMessageBox.Show("No Record found for Date: " + frm.DateOn.ToShortDateString());
                            return;
                        }
                        rpt.DataSource = sc.DT;
                        GroupField pdt = new GroupField("PurchaseDate");
                        rpt.GroupHeader1.GroupFields.Add(pdt);

                        XRSummary sub_total = new XRSummary();
                        XRSummary grn_total = new XRSummary();

                        sub_total.FormatString = "{0:C2}";
                        sub_total.Running = SummaryRunning.Group;

                        grn_total.FormatString = "{0:C2}";
                        grn_total.Running = SummaryRunning.Report;

                        rpt.lbHDR.Text = "On " + frm.DateOn.ToShortDateString();
                        rpt.lbPDT.DataBindings.Add("Text", null, "PurchaseDate", "{0:dd-MM-yyyy}");
                        rpt.lbPNM.DataBindings.Add("Text", null, "ProductName");
                        rpt.lbPKG.DataBindings.Add("Text", null, "PackageSize");
                        rpt.lbBVL.DataBindings.Add("Text", null, "BuyingValue", "{0:C2}");
                        rpt.lbQTY.DataBindings.Add("Text", null, "SumOfQuantity");
                        rpt.lbAMT.DataBindings.Add("Text", null, "SumOfAmount", "{0:C2}");
                        rpt.lbSAMT.DataBindings.Add("Text", null, "SumOfAmount");
                        rpt.lbGAMT.DataBindings.Add("Text", null, "SumOfAmount");

                        rpt.lbSAMT.Summary = sub_total;
                        rpt.lbGAMT.Summary = grn_total;

                        dv.PrintingSystem = rpt.PrintingSystem;
                        rpt.CreateDocument(true);
                        break;
                    case 2:
                        sc = px.ViewPurchase(frm.DateFr, frm.DateTo);
                        if (sc.DT.Rows.Count <= 0)
                        {
                            XtraMessageBox.Show("No Record found for Date between: " + frm.DateFr.ToShortDateString() + " and " + frm.DateTo.ToShortDateString());
                            return;
                        }
                        rpt.DataSource = sc.DT;
                        
                        pdt = new GroupField("PurchaseDate");
                        rpt.GroupHeader1.GroupFields.Add(pdt);

                        sub_total = new XRSummary();
                        grn_total = new XRSummary();

                        sub_total.FormatString = "{0:C2}";
                        sub_total.Running = SummaryRunning.Group;

                        grn_total.FormatString = "{0:C2}";
                        grn_total.Running = SummaryRunning.Report;

                        rpt.lbHDR.Text = "Between " + frm.DateFr.ToShortDateString() + " and " + frm.DateTo.ToShortDateString();
                        rpt.lbPDT.DataBindings.Add("Text", null, "PurchaseDate", "{0:dd-MM-yyyy}");
                        rpt.lbPNM.DataBindings.Add("Text", null, "ProductName");
                        rpt.lbPKG.DataBindings.Add("Text", null, "PackageSize");
                        rpt.lbBVL.DataBindings.Add("Text", null, "BuyingValue", "{0:C2}");
                        rpt.lbQTY.DataBindings.Add("Text", null, "SumOfQuantity");
                        rpt.lbAMT.DataBindings.Add("Text", null, "SumOfAmount", "{0:C2}");
                        rpt.lbSAMT.DataBindings.Add("Text", null, "SumOfAmount");
                        rpt.lbGAMT.DataBindings.Add("Text", null, "SumOfAmount");

                        rpt.lbSAMT.Summary = sub_total;
                        rpt.lbGAMT.Summary = grn_total;

                        dv.PrintingSystem = rpt.PrintingSystem;
                        rpt.CreateDocument(true);
                        break;
                }
            }
        }

        private void bCusAC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmSelectCustomer frm = new frmSelectCustomer();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    ServerToClient sc = new ServerToClient();
            //    CustomerContext cx = new CustomerContext();
            //    Customer c = new Customer();

            //    double bal = 0;
            //    c = cx.GetCustomer(frm.CID);
            //    rptAccountStatement rpt = new rptAccountStatement();

            //    XRSummary tdr = new XRSummary();
            //    XRSummary tcr = new XRSummary();

            //    rpt.lbCNM.Text = c.CustomerName;
            //    rpt.lbADR.Text = c.Address;
            //    rpt.lbPHN.Text = c.Phone;
            //    //rpt.lbEML.Text = c.Email;

            //    if (!frm.DateSelected)
            //    {
            //        sc = cx.getCustomerBalanceByID(frm.CustomerID);
            //        bal = sc.Value;
            //        sc = cx.getTransactionDetails(frm.CustomerID);
            //        rpt.DataSource = sc.dataTable;
            //    }
            //    else
            //    {
            //        sc = cus.getCustomerBalanceByDates(frm.CustomerID, frm.DateFrom, frm.DateTo);
            //        bal = sc.Value;
            //        //DataTable dt = cus.AccountStatement(frm.CustomerID, frm.DateFrom, frm.DateTo).dataTable;
            //        sc = cus.AccountStatement(frm.CustomerID, frm.DateFrom, frm.DateTo);
            //        rpt.DataSource = sc.dataTable;
            //    }
            //    rpt.lbTDT.DataBindings.Add("Text", null, "TransDate", "{0:dd-MM-yyyy}");
            //    rpt.lbRMK.DataBindings.Add("Text", null, "Description");
            //    rpt.lbTDR.DataBindings.Add("Text", null, "Debit", "{0:c}");
            //    rpt.lbTCR.DataBindings.Add("Text", null, "Credit", "{0:c}");
            //    rpt.lbBAL.DataBindings.Add("Text", null, "Balance", "{0:c}");
            //    rpt.lblTDR.DataBindings.Add("Text", null, "Debit", "{0:C2}");
            //    rpt.lblTCR.DataBindings.Add("Text", null, "Credit", "{0:C2}");
            //    rpt.lblTBL.Text = bal.ToString("c2");
            //    tdr.FormatString = "{0:C2}";
            //    tcr.FormatString = "{0:C2}";
            //    tdr.Running = SummaryRunning.Report;
            //    tcr.Running = SummaryRunning.Report;
            //    rpt.lblTCR.Summary = tdr;
            //    rpt.lblTDR.Summary = tcr;

            //    dv.PrintingSystem = rpt.PrintingSystem;
            //    rpt.CreateDocument(true);
            //}
        }

        private void bProductPerf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDateRangeSelector frm = new frmDateRangeSelector();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                if(frm.SelectedValue == 2)
                {
                    rptProductPerformance rpt = new rptProductPerformance(frm.DateFr, frm.DateTo);
                    dv.PrintingSystem = rpt.PrintingSystem;
                    rpt.CreateDocument(true);
                }
            }
            
        }
    }
}
