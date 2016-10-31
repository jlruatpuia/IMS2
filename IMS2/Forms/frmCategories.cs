using DevExpress.XtraEditors;
using IMS2.Codes;
using System;
using System.Windows.Forms;

namespace IMS2.Forms
{
    public partial class frmCategories : DevExpress.XtraEditors.XtraForm
    {

        ServerToClient sc;
        ProductContext px;

        public int cid { get; set; }
        public string cnm { get; set; }

        public frmCategories()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            sc = new ServerToClient();
            px = new ProductContext();

            sc = px.GetCategories();
            grd.DataSource = sc.DT;
        }

        private void grv_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                grv.FocusedRowHandle = e.HitInfo.RowHandle;
                cMenu.Show(grv.GridControl, e.Point);
            }
        }

        private void mEdit_Click(object sender, System.EventArgs e)
        {
            cid = Convert.ToInt32(grv.GetFocusedRowCellValue(colCID));
            cnm = grv.GetFocusedRowCellValue(colCNM).ToString();
            txtCNM.Text = cnm;
            btnSave.Text = "&Update";
        }

        private void mDelete_Click(object sender, EventArgs e)
        {
            cid = Convert.ToInt32(grv.GetFocusedRowCellValue(colCID));
            if(XtraMessageBox.Show("Deleting category will also delete all the corresponding products. Do you want to continue?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sc = new ServerToClient();
                px = new ProductContext();
                sc = px.DeleteCategory(cid);
                if (sc.Message == null)
                {
                    XtraMessageBox.Show("Category deleted!");
                    Init();
                }
                else
                    XtraMessageBox.Show(sc.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!dxVP.Validate()) return;

            sc = new ServerToClient();
            px = new ProductContext();

            if(btnSave.Text == "&Save")
            {
                Category c = new Category();
                c.CategoryName = txtCNM.Text.ToUpper();

                sc = px.AddCategory(c);

                if (sc.Message == null)
                {
                    XtraMessageBox.Show("New category added!");
                    txtCNM.Text = "";
                    Init();
                }
                else
                    XtraMessageBox.Show(sc.Message);
            }
            else
            {
                Category c = new Category();
                c.ID = cid;
                c.CategoryName = txtCNM.Text.ToUpper();

                sc = px.UpdateCategory(c);
                if (sc.Message == null)
                {
                    XtraMessageBox.Show("Category Name updated!");
                    txtCNM.Text = "";
                    btnSave.Text = "&Save";
                    Init();
                }
                else
                    XtraMessageBox.Show(sc.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCNM.Text = "";
            btnSave.Text = "&Save";
        }
    }
}