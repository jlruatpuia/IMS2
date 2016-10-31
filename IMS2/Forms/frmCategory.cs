using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IMS2.Codes;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;

namespace IMS2.Forms
{
    public partial class frmCategory : XtraForm
    {
        public int CID { get; set; }
        public string CNM { get; set; }

        ServerToClient sc = new ServerToClient();
        ProductContext px = new ProductContext();

        ContextMenu ContextMenu1 = new ContextMenu();

        public frmCategory()
        {
            InitializeComponent();

            sc = new ServerToClient();
            px = new ProductContext();

            sc = px.GetCategories();
            //grd.DataSource = sc.DT;

        }

        public frmCategory(int ID)
        {
            InitializeComponent();
            CID = ID;
            ProductContext pc = new ProductContext();
            Category c = new Category();

            c = pc.GetCategory(ID);
            txtCNM.Text = c.CategoryName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CNM = txtCNM.Text.ToUpper();

            DialogResult = DialogResult.OK;
        }

        private void grv_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
             //cMenu.Show(view.GridControl, e.Point);
            
        }

        private void mEdit_Click(object sender, EventArgs e)
        {
            //CID = Convert.ToInt32(grv.GetFocusedRowCellValue(colCID));
           // CNM = grv.GetFocusedRowCellValue(colCNM).ToString();
           // txtCNM.Text = CNM;
        }

        private void mDel_Click(object sender, EventArgs e)
        {
            //grv.ShowEditor();
        }
    }
}