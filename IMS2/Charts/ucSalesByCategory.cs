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
using IMS2.Codes;

namespace IMS2.Charts
{
    public partial class ucSalesByCategory : XtraUserControl
    {

        public string ArgumentDataMember {
            get { return chart.Series[0].ArgumentDataMember; }
            set { chart.Series[0].ArgumentDataMember = value; }
        }
        public string ValueDataMember {
            get { return chart.Series[0].ValueDataMembers[0]; }
            set { chart.Series[0].ValueDataMembers[0] = value; }
        }
        public ucSalesByCategory()
        {
            InitializeComponent();
        }

        public ucSalesByCategory(DateTime dateFr, DateTime dateTo)
        {
            InitializeComponent();
            ServerToClient sc = new ServerToClient();
            Dashboard d = new Dashboard();
            sc = d.SalesByCategory(dateFr, dateTo);
            chart.DataSource = sc.DT;
            //chart.Series[0].ArgumentDataMember = ArgumentDataMember;
            //chart.Series[0].ValueDataMembers[0] = ValueDataMember;
        }
    }
}
