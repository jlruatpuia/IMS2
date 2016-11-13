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

namespace IMS2.UserControls
{
    public partial class ucDashboard : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDashboard()
        {
            InitializeComponent();
            bsbcFr.EditValue = DateTime.Now.Date;
            bsbcTo.EditValue = DateTime.Now.Date;

        }

        private void bsbcView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime dtFR = DateTime.Parse(bsbcFr.EditValue.ToString());
            DateTime dtTO = DateTime.Parse(bsbcTo.EditValue.ToString());
            ServerToClient sc = new ServerToClient();
            Dashboard d = new Dashboard();
            sc = d.SalesByCategory(dtFR, dtTO);
            chartControl1.DataSource = sc.DT;
            //chartControl1.
        }
    }
}
