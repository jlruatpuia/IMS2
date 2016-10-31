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
using DevExpress.Utils;
using IMS2.Forms;
using IMS2.Reports;
using DevExpress.XtraReports.UI;

namespace IMS2.UserControls
{
    public partial class ucSuppliers : XtraUserControl
    {
        ServerToClient sc = new ServerToClient();
        SupplierContext sx = new SupplierContext();

        public ucSuppliers()
        {
            InitializeComponent();
            if (MySettings.UserLevel == 1)
                rpgRecords.Enabled = false;
            FillGrid();
            FillGridView();
        }

        void FillGrid()
        {
            sc = new ServerToClient();
            sx = new SupplierContext();

            sc = sx.GetSuppliers();

            grd.DataSource = sc.DT;

            //ButtonDisableEnable(sc.Count);
        }
        void FillGridView()
        {
            sc = new ServerToClient();
            sx = new SupplierContext();
            sc = sx.GetSupplierAccount();

            grd.DataSource = sc.DS.Tables[0];
            grd.ForceInitialize();
            grd.LevelTree.Nodes.Add(sc.Message, grvD);
            grvD.PopulateColumns(sc.DS.Tables[1]);
            grvD.ViewCaption = "Summary";
            grvD.OptionsView.ShowGroupPanel = false;
            grvD.Columns["ID"].VisibleIndex = -1;
            grvD.Columns["SupplierID"].VisibleIndex = -1;
            grvD.Columns["TransDate"].OptionsColumn.AllowEdit = false;
            grvD.Columns["TransDate"].OptionsColumn.AllowFocus = false;
            grvD.Columns["TransDate"].OptionsColumn.ReadOnly = true;
            grvD.Columns["Description"].OptionsColumn.AllowEdit = false;
            grvD.Columns["Description"].OptionsColumn.AllowFocus = false;
            grvD.Columns["Description"].OptionsColumn.ReadOnly = true;
            grvD.Columns["Debit"].OptionsColumn.AllowEdit = false;
            grvD.Columns["Debit"].OptionsColumn.AllowFocus = false;
            grvD.Columns["Debit"].OptionsColumn.ReadOnly = true;
            grvD.Columns["Debit"].DisplayFormat.FormatType = FormatType.Numeric;
            grvD.Columns["Debit"].DisplayFormat.FormatString = "{0:c}";
            grvD.Columns["Credit"].OptionsColumn.AllowEdit = false;
            grvD.Columns["Credit"].OptionsColumn.AllowFocus = false;
            grvD.Columns["Credit"].OptionsColumn.ReadOnly = true;
            grvD.Columns["Credit"].DisplayFormat.FormatType = FormatType.Numeric;
            grvD.Columns["Credit"].DisplayFormat.FormatString = "{0:c}";
            grvD.Columns["Balance"].OptionsColumn.AllowEdit = false;
            grvD.Columns["Balance"].OptionsColumn.AllowFocus = false;
            grvD.Columns["Balance"].OptionsColumn.ReadOnly = true;
            grvD.Columns["Balance"].DisplayFormat.FormatType = FormatType.Numeric;
            grvD.Columns["Balance"].DisplayFormat.FormatString = "{0:c}";

            //ButtonDisableEnable(sc.Count);
        }

        private void bNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSupplier frm = new frmSupplier();
            frm.ShowDialog();
            FillGrid();
            FillGridView();

        }

        private void bEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = Convert.ToInt32(grv.GetFocusedRowCellValue(colSID));
            frmSupplier frm = new frmSupplier(id);
            frm.ShowDialog();
            FillGrid();
            FillGridView();
        }

        private void bDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sc = new ServerToClient();
            sx = new SupplierContext();
            int id = Convert.ToInt32(grv.GetFocusedRowCellValue(colSID));

            if (XtraMessageBox.Show("Are you sure you want to delete this supplier?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sc = sx.DeleteSupplier(id);
                if (sc.Message == null)
                {
                    XtraMessageBox.Show("Supplier deleted successfully!");
                    FillGrid();
                    FillGridView();
                }
                else
                    XtraMessageBox.Show(sc.Message);
            }
        }

        private void bPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void bSupList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sc = new ServerToClient();
            sx = new SupplierContext();
            sc = sx.GetSuppliers();
            rptSupplier rpt = new rptSupplier();
            rpt.DataSource = sc.DT;

            rpt.lbSNM.DataBindings.Add("Text", null, "SupplierName");
            rpt.lbADR.DataBindings.Add("Text", null, "Address");
            rpt.lbPHN.DataBindings.Add("Text", null, "Phone");
            rpt.ShowPreviewDialog();
        }

        private void bDetailReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            rpt().ShowPreviewDialog();
        }

        private void bExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmExport frm = new frmExport(rpt());
            frm.ShowDialog();
        }

        private XtraReport rpt()
        {
            sc = new ServerToClient();
            sx = new SupplierContext();
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
            return rpt;

        }
    }
}
