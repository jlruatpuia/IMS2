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

namespace IMS2.UserControls
{
    public partial class ucCustomers : DevExpress.XtraEditors.XtraUserControl
    {
        void ButtonDisableEnable(int count)
        {
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
    }
}
