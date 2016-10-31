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
using DevExpress.XtraReports.UI;
using IMS2.Reports;
using IMS2.Forms;

namespace IMS2.UserControls
{
    public partial class ucProductsView : XtraUserControl
    {
        ServerToClient sc;
        ProductContext px;

        public ucProductsView()
        {
            InitializeComponent();
            if (MySettings.UserLevel == 1)
                rpgRecords.Enabled = false;

            cboField.SelectedIndex = 0;
            InitGrid();
        }

        void InitGrid()
        {
            sc = new ServerToClient();
            px = new ProductContext();
            sc = px.GetProductReport();
            grd.DataSource = sc.DT;
            grv.ExpandAllGroups();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sc = new ServerToClient();
            px = new ProductContext();

            sc = px.GetProductReport(cboField.Text, txtQuery.Text);

            grd.DataSource = sc.DT;
        }

        private void txtQuery_TextChanged(object sender, EventArgs e)
        {
            sc = new ServerToClient();
            px = new ProductContext();
            if (txtQuery.Text == "")
            {
                sc = px.GetProductReport();

                grd.DataSource = sc.DT;
            }
            else
            {
                sc = px.GetProductReport(cboField.Text, txtQuery.Text);

                grd.DataSource = sc.DT;
            }
        }

        private void bPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grd.ShowPrintPreview();
        }

        private void bPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF|*.pdf" };
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                grv.ExportToPdf(sfd.FileName);
            }
        }

        private void bXLS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "XLS|*.xls" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                grv.ExportToXls(sfd.FileName);
            }
        }

        private void bXLSX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "XLSX|*.xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                grv.ExportToXlsx(sfd.FileName);
            }
        }

        private void bDOC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "DOC|*.doc" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                grv.ExportToRtf(sfd.FileName);
            }
        }

        private void bNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEditProduct frm = new frmEditProduct();
            sc = new ServerToClient();
            px = new ProductContext();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Product p = new Product();
                p = frm.p;

                sc = px.AddProduct(p);

                if (sc.Message != null)
                    XtraMessageBox.Show(sc.Message);
            }
        }

        private void bEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = Convert.ToInt32(grv.GetFocusedRowCellValue(colPID));

            if (id <= 0) return;

            frmEditProduct frm = new frmEditProduct(id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Product p = new Product();
                p = frm.p;

                sc = px.UpdateProduct(p);
                if (sc.Message != null)
                    XtraMessageBox.Show(sc.Message);
            }
        }

        private void bDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = Convert.ToInt32(grv.GetFocusedRowCellValue(colPID));
            if (id <= 0) return;
            if (XtraMessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ProductContext pc = new ProductContext();
                ServerToClient sc = new ServerToClient();

                sc = pc.DeleteProduct(id);

                if (sc.Message == null)
                {
                    XtraMessageBox.Show("Product deleted successfully!");
                    //bExpand_CheckedChanged(null, null);
                }
            }
        }

        private void bEdit2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int pid = Convert.ToInt32(grv.GetFocusedRowCellValue(colPID));
            int did = Convert.ToInt32(grv.GetFocusedRowCellValue(colDID));

            //if (id <= 0) return;

            new frmEditProductDetail(pid, did).ShowDialog();

            InitGrid();
            //frmEditProductDetail frm = new frmEditProductDetail(id);
            
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    //Product p = new Product();
            //    //p = frm.p;

            //    //sc = px.UpdateProduct(p);
            //    //if (sc.Message != null)
            //    //    XtraMessageBox.Show(sc.Message);
            //}
        }
    }
}
