using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using IMS2.Codes;

namespace IMS2.Reports
{
    public partial class rptProductPerformance : DevExpress.XtraReports.UI.XtraReport
    {
        public rptProductPerformance()
        {
            InitializeComponent();
        }

        public rptProductPerformance(DateTime df, DateTime dt)
        {
            InitializeComponent();
            ServerToClient sc = new ServerToClient();
            SalesContext sx = new SalesContext();

            sc = sx.SalesByProductNameChart(df, dt);

            xrChart1.DataSource = sc.DT;
        }

    }
}
