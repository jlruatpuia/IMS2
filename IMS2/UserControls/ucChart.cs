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
using IMS2.Charts;
using DevExpress.XtraCharts;
using IMS2.Codes;

namespace IMS2.UserControls
{
    public partial class ucChart : XtraUserControl
    {

        //ChartControl chart = new ChartControl();
        public ucChart()
        {
            InitializeComponent();
            beiType.EditValue = "Sales By Category";
            bsbcFr.EditValue = DateTime.Now.Date;
            bsbcTo.EditValue = DateTime.Now.Date;

            
        }

        private void bsbcView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime dtFR = DateTime.Parse(bsbcFr.EditValue.ToString());
            DateTime dtTO = DateTime.Parse(bsbcTo.EditValue.ToString());
            ServerToClient sc = new ServerToClient();
            Dashboard d = new Dashboard();
           
            if(beiType.EditValue.ToString() == "Sales By Category")
            {
                sc = d.SalesByCategory(dtFR, dtTO);
                CreateChart(sc.DT, "CategoryName", "TotalQuantity");
            }
            else if(beiType.EditValue.ToString() == "Sales By Product")
            {
                sc = d.SalesByProduct(dtFR, dtTO);
                CreateChart(sc.DT, "ProductName", "TotalQuantity");
            }
            else if(beiType.EditValue.ToString() == "Sales By Company")
            {
                sc = d.SalesByCompany(dtFR, dtTO);
                CreateChart(sc.DT, "Company", "TotalQuantity");
            }

        }

        void CreateChart(DataTable dt, string ArgumentDataMember, string ValueDataMember)
        {
            // Create an empty Bar series and add it to the chart.
            Series series = new Series("Series1", ViewType.Bar);
            chartControl.Series.Add(series);

            // Generate a data table and bind the series to it.
            series.DataSource = dt;

            // Specify data members to bind the series.
            series.ArgumentScaleType = ScaleType.Auto;
            series.ArgumentDataMember = ArgumentDataMember;
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { ValueDataMember });

            // Set some properties to get a nice-looking chart.
            ((SideBySideBarSeriesView)series.View).ColorEach = true;
            ((XYDiagram)chartControl.Diagram).AxisY.Visibility = DevExpress.Utils.DefaultBoolean.False;
            chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Dock the chart into its parent and add it to the current form.
            chartControl.Dock = DockStyle.Fill;
        }
    }
}
