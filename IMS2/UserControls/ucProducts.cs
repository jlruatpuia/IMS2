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
using IMS2.Forms;
using IMS2.Codes;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace IMS2.UserControls
{
    public partial class ucProducts : XtraUserControl
    {
        ProductContext pc = new ProductContext();
        ServerToClient sc = new ServerToClient();
        public ucProducts()
        {
            InitializeComponent();
            sc = pc.GetProductsSimple();

            bExpand_CheckedChanged(null, null);
        }

        private void bNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddProduct frm = new frmAddProduct();
            frm.ShowDialog();
        }

        private void bExpand_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bExpand.Checked)
            {
                bExpand.Caption = "Extended";
                bExpand.Glyph = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/squeeze_16x16.png");
                bExpand.LargeGlyph = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/squeeze_32x32.png");
                colBCD.Visible = true;
                grd.DataSource = null;
                grd.Refresh();
                sc = new ServerToClient();
                sc = pc.GetProductsFull();
                grd.DataSource = sc.DT;
                bEdit.Enabled = true;
                bDel.Enabled = true;
            }
            else
            {
                bExpand.Caption = "Simple";
                bExpand.Glyph = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/stretch_16x16.png");
                bExpand.LargeGlyph = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/stretch_32x32.png");
                colBCD.Visible = false;
                grd.DataSource = null;
                grd.Refresh();
                sc = new ServerToClient();
                sc = pc.GetProductsSimple();
                grd.DataSource = sc.DT;
                bEdit.Enabled = false;
                bDel.Enabled = false;
            }
            //grv_Click(null, null);
        }

        private void grv_Click(object sender, EventArgs e)
        {
            GridHitInfo hi = grv.CalcHitInfo(grd.PointToClient(MousePosition));
            if (grv.IsGroupRow(hi.RowHandle) && bExpand.Checked == false)
            {
                bEdit.Enabled = false;
                bDel.Enabled = false;
            }
            else if(grv.IsGroupRow(hi.RowHandle) && bExpand.Checked)
            {
                bEdit.Enabled = false;
                bDel.Enabled = false;
            }
            else if(!grv.IsGroupRow(hi.RowHandle) && bExpand.Checked)
            {
                bEdit.Enabled = true;
                bDel.Enabled = true;
            }
        }

        private void grv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            grv_Click(null, null);
        }

        private void bEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (grd.IsGroupRowHandle(grv.FocusedRowHandle)) return;
            GridHitInfo hi = grv.CalcHitInfo(grd.PointToClient(MousePosition));
            if (grv.IsGroupRow(hi.RowHandle) || hi.RowHandle < 0) return;

            int id = Convert.ToInt32(grv.GetFocusedRowCellValue(colPID));

            frmEditProduct frm = new frmEditProduct(id);
            if (frm.ShowDialog() == DialogResult.OK)
                bExpand_CheckedChanged(null, null);
        }

        private void bDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridHitInfo hi = grv.CalcHitInfo(grd.PointToClient(MousePosition));
            if (grv.IsGroupRow(hi.RowHandle) || hi.RowHandle < 0) return;

            int id = Convert.ToInt32(grv.GetFocusedRowCellValue(colPID));
            if(XtraMessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ProductContext pc = new ProductContext();
                ServerToClient sc = new ServerToClient();

                sc = pc.DeleteProduct(id);

                if(sc.Message == null)
                {
                    XtraMessageBox.Show("Product deleted successfully!");
                    bExpand_CheckedChanged(null, null);
                }
            }
        }
    }
}
