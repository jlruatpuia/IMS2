using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using IMS2.Codes;

namespace IMS2.Reports
{
    public partial class rptSoldByInvoice : XtraReport
    {
        public rptSoldByInvoice()
        {
            InitializeComponent();
        }

        public rptSoldByInvoice(string InvoiceNo)
        {
            InitializeComponent();
            ServerToClient sc = new ServerToClient();
            SalesContext sx = new SalesContext();

            sc = sx.GetSales(InvoiceNo);
            DataSource = sc.DT;


        }

    }
}
