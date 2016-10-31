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
    public partial class ucCustomers : DevExpress.XtraEditors.XtraUserControl
    {
        void ButtonDisableEnable(int count)
        {
            if (MySettings.UserLevel == 1) return;
            if (count < 1)
            {
                bEdit.Enabled = false;
                bDelete.Enabled = false;
                //bPay.Enabled = false;
            }
            else
            {
                bEdit.Enabled = true;
                bDelete.Enabled = true;
                //bPay.Enabled = true;
            }
        }
        void FillGrid()
        {
            ServerToClient sc = new ServerToClient();
            CustomerContext cc = new CustomerContext();

            sc = cc.GetCustomers();

            grd.DataSource = sc.DT;

            ButtonDisableEnable(sc.Count);
        }
        void FillGridView()
        {
            ServerToClient sc = new ServerToClient();
            CustomerContext cc = new CustomerContext();
            sc = cc.GetCustomerAccount();

            grd.DataSource = sc.DS.Tables[0];
            grd.ForceInitialize();
            grd.LevelTree.Nodes.Add(sc.Message, grvD);
            grvD.PopulateColumns(sc.DS.Tables[1]);
            grvD.ViewCaption = "Summary";
            grvD.OptionsView.ShowGroupPanel = false;
            grvD.Columns["ID"].VisibleIndex = -1;
            grvD.Columns["CustomerID"].VisibleIndex = -1;
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

            ButtonDisableEnable(sc.Count);
        }
        public ucCustomers()
        {
            InitializeComponent();
            if (MySettings.UserLevel == 1)
                rpgRecords.Enabled = false;

            FillGrid();
            FillGridView();
        }

        private void bNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.ShowDialog();
            FillGrid();
            FillGridView();
        }

        private void bEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = Convert.ToInt32(grv.GetFocusedRowCellValue(colCID));
            frmCustomer frm = new frmCustomer(id);
            frm.ShowDialog();
            FillGrid();
            FillGridView();
        }

        private void bDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ServerToClient sc = new ServerToClient();
            CustomerContext cc = new CustomerContext();
            int id = Convert.ToInt32(grv.GetFocusedRowCellValue(colCID));

            if(XtraMessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sc = cc.DeleteCustomer(id);
                if (sc.Message == null)
                {
                    XtraMessageBox.Show("Customer deleted successfully!");
                    FillGrid();
                    FillGridView();
                }
                else
                    XtraMessageBox.Show(sc.Message);
            }
        }

        private void bCusList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ServerToClient sc = new ServerToClient();
            CustomerContext cx = new CustomerContext();

            sc = cx.GetCustomers();

            rptCustomers rpt = new rptCustomers() { DataSource = sc.DT };
            rpt.lbCNM.DataBindings.Add("Text", null, "CustomerName");
            rpt.lbADR.DataBindings.Add("Text", null, "Address");
            rpt.lbPHN.DataBindings.Add("Text", null, "Phone");

            rpt.ShowPreviewDialog();
        }

        private XtraReport rpt()
        {
            ServerToClient sc = new ServerToClient();
            CustomerContext cx = new CustomerContext();
            sc = cx.CustomerDetailReport();
            rptCustomerDetail rpt = new rptCustomerDetail();
            rpt.DataSource = sc.DT;

            GroupField snm = new GroupField("CustomerName");
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

            rpt.lbCNM.DataBindings.Add("Text", null, "CustomerName");
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

        private void bCustDtlReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rpt().ShowPreviewDialog();
        }

        private void bExpPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Portable Document Format (pdf)|*.pdf" };
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                rpt().ExportToPdf(sfd.FileName);
            }
        }

        private void bExpXLS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel 2003 Format (xls)|*.xls" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                rpt().ExportToXls(sfd.FileName);
            }
        }

        private void bExpXLSX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel 2007 Format (xlsx)|*.xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                rpt().ExportToXlsx(sfd.FileName);
            }
        }

        private void bCustAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new frmCustomerSelect().ShowDialog();
            frmCustomerSelect frm = new frmCustomerSelect();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                ServerToClient sc = new ServerToClient();
                CustomerContext cx = new CustomerContext();
                sc = cx.CustomerDetailReport(frm.CID);
                rptCustomerDetail rpt = new rptCustomerDetail();
                rpt.DataSource = sc.DT;

                GroupField snm = new GroupField("CustomerName");
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

                rpt.lbCNM.DataBindings.Add("Text", null, "CustomerName");
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
                rpt.ShowPreviewDialog();
            }

        }
    }
}
