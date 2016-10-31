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
using DevExpress.Utils;

namespace IMS2.UserControls
{
    public partial class ucProducts : XtraUserControl
    {
        ProductContext pc = new ProductContext();
        ServerToClient sc = new ServerToClient();

        void FillGrid()
        {
            ServerToClient sc = new ServerToClient();
            sc = pc.GetProducts();

            grd.DataSource = sc.DT;

            //ButtonDisableEnable(sc.Count);
        }

        void FillGridViewFull()
        {
            sc = pc.GetProductDetailFull();

            grd.DataSource = sc.DS.Tables[0];
            grd.ForceInitialize();
            grd.LevelTree.Nodes.Add(sc.Message, grvD);
            grvD.PopulateColumns(sc.DS.Tables[1]);
            grvD.ViewCaption = "Summary";
            grvD.OptionsView.ShowGroupPanel = false;
            grvD.Columns["ID"].VisibleIndex = -1;
            grvD.Columns["ProductID"].VisibleIndex = -1;
            grvD.Columns["BuyingValue"].OptionsColumn.AllowEdit = false;
            grvD.Columns["BuyingValue"].OptionsColumn.AllowFocus = false;
            grvD.Columns["BuyingValue"].OptionsColumn.ReadOnly = true;
            grvD.Columns["BuyingValue"].DisplayFormat.FormatType = FormatType.Numeric;
            grvD.Columns["BuyingValue"].DisplayFormat.FormatString = "{0:c}";
            grvD.Columns["SellingValue"].OptionsColumn.AllowEdit = false;
            grvD.Columns["SellingValue"].OptionsColumn.AllowFocus = false;
            grvD.Columns["SellingValue"].OptionsColumn.ReadOnly = true;
            grvD.Columns["SellingValue"].DisplayFormat.FormatType = FormatType.Numeric;
            grvD.Columns["SellingValue"].DisplayFormat.FormatString = "{0:c}";
            grvD.Columns["MfgDate"].OptionsColumn.AllowEdit = false;
            grvD.Columns["MfgDate"].OptionsColumn.AllowFocus = false;
            grvD.Columns["MfgDate"].OptionsColumn.ReadOnly = true;
            
            grvD.Columns["ExpDate"].OptionsColumn.AllowEdit = false;
            grvD.Columns["ExpDate"].OptionsColumn.AllowFocus = false;
            grvD.Columns["ExpDate"].OptionsColumn.ReadOnly = true;
            grvD.Columns["Quantity"].OptionsColumn.AllowEdit = false;
            grvD.Columns["Quantity"].OptionsColumn.AllowFocus = false;
            grvD.Columns["Quantity"].OptionsColumn.ReadOnly = true;
            grvD.Columns["BarCode"].OptionsColumn.AllowEdit = false;
            grvD.Columns["BarCode"].OptionsColumn.AllowFocus = false;
            grvD.Columns["BarCode"].OptionsColumn.ReadOnly = true;

            //ButtonDisableEnable(sc.Count);
        }

        void FillGridViewSimple()
        {
            sc = pc.GetProductDetailSimple();

            grd.DataSource = sc.DS.Tables[0];
            grd.ForceInitialize();
            grd.LevelTree.Nodes.Add(sc.Message, grvD);
            grvD.PopulateColumns(sc.DS.Tables[1]);
            grvD.ViewCaption = "Summary";
            grvD.OptionsView.ShowGroupPanel = false;
            //grvD.Columns["ID"].VisibleIndex = -1;
            grvD.Columns["ProductID"].VisibleIndex = -1;
            grvD.Columns["BuyingValue"].OptionsColumn.AllowEdit = false;
            grvD.Columns["BuyingValue"].OptionsColumn.AllowFocus = false;
            grvD.Columns["BuyingValue"].OptionsColumn.ReadOnly = true;
            grvD.Columns["BuyingValue"].DisplayFormat.FormatType = FormatType.Numeric;
            grvD.Columns["BuyingValue"].DisplayFormat.FormatString = "{0:c}";
            grvD.Columns["SellingValue"].OptionsColumn.AllowEdit = false;
            grvD.Columns["SellingValue"].OptionsColumn.AllowFocus = false;
            grvD.Columns["SellingValue"].OptionsColumn.ReadOnly = true;
            grvD.Columns["SellingValue"].DisplayFormat.FormatType = FormatType.Numeric;
            grvD.Columns["SellingValue"].DisplayFormat.FormatString = "{0:c}";
            grvD.Columns["MfgDate"].OptionsColumn.AllowEdit = false;
            grvD.Columns["MfgDate"].OptionsColumn.AllowFocus = false;
            grvD.Columns["MfgDate"].OptionsColumn.ReadOnly = true;
            grvD.Columns["ExpDate"].OptionsColumn.AllowEdit = false;
            grvD.Columns["ExpDate"].OptionsColumn.AllowFocus = false;
            grvD.Columns["ExpDate"].OptionsColumn.ReadOnly = true;
            grvD.Columns["Quantity"].OptionsColumn.AllowEdit = false;
            grvD.Columns["Quantity"].OptionsColumn.AllowFocus = false;
            grvD.Columns["Quantity"].OptionsColumn.ReadOnly = true;
        }

        public ucProducts()
        {
            InitializeComponent();
            //sc = pc.GetProducts();
            FillGrid();
            FillGridViewFull();
            bExpand_CheckedChanged(null, null);
        }

        private void bNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEditProduct frm = new frmEditProduct();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                Product p = new Product();
                p = frm.p;

                sc = pc.AddProduct(p);

                if (sc.Message == null)
                    bExpand_CheckedChanged(null, null);
                else
                    XtraMessageBox.Show(sc.Message);
            }
        }

        private void bExpand_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bExpand.Checked)
            {
                bExpand.Caption = "Extended";
                bExpand.Glyph = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/squeeze_16x16.png");
                bExpand.LargeGlyph = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/squeeze_32x32.png");
                //colBCD.Visible = true;
                grd.DataSource = null;
                grd.Refresh();
                //sc = new ServerToClient();
                //sc = pc.GetProductDetailSimple();
                //grd.DataSource = sc.DT;
                FillGrid();
                FillGridViewFull();
                bEdit.Enabled = true;
                bDel.Enabled = true;
            }
            else
            {
                bExpand.Caption = "Simple";
                bExpand.Glyph = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/stretch_16x16.png");
                bExpand.LargeGlyph = DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/stretch_32x32.png");
                //colBCD.Visible = false;
                grd.DataSource = null;
                grd.Refresh();
                //sc = new ServerToClient();
                //sc = pc.GetProductDetailFull();
                //grd.DataSource = sc.DT;
                FillGrid();
                FillGridViewSimple();
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
            ////if (grd.IsGroupRowHandle(grv.FocusedRowHandle)) return;
            //GridHitInfo hi = grv.CalcHitInfo(grd.PointToClient(MousePosition));
            ////if (grv.IsGroupRow(hi.RowHandle) || hi.RowHandle < 0) return;

            int id = Convert.ToInt32(grv.GetFocusedRowCellValue(colPID));

            if (id <= 0) return;

            frmEditProduct frm = new frmEditProduct(id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Product p = new Product();
                p = frm.p;

                sc = pc.UpdateProduct(p);
                if (sc.Message == null)
                    bExpand_CheckedChanged(null, null);
                else
                    XtraMessageBox.Show(sc.Message);
            }
        }

        private void bDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id = Convert.ToInt32(grv.GetFocusedRowCellValue(colPID));
            if (id <= 0) return;
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
