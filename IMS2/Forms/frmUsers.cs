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

namespace IMS2.Forms
{
    public partial class frmUsers : DevExpress.XtraEditors.XtraForm
    {
        ServerToClient sc; //= new ServerToClient();
        UserContext ux; //= new UserContext();
        public frmUsers()
        {
            InitializeComponent();

            Init();
        }

        void Init()
        {
            sc = new ServerToClient();
            ux = new UserContext();

            if (MySettings.UserLevel == 0)
            {
                sc = ux.getUsers();
            }
            else
            {
                sc = ux.getUsers(MySettings.UserID);
                bNew.Enabled = false;
                bDel.Enabled = false;
            }
            grd.DataSource = sc.DT;
            bNos.Caption = sc.Count.ToString();
        }

        private void bNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmManageUser().ShowDialog();
            Init();
        }

        private void bEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int ID = Convert.ToInt32(grv.GetFocusedRowCellValue(colUID));
            new frmManageUser(ID).ShowDialog();
            Init();
        }

        private void bDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int ID = Convert.ToInt32(grv.GetFocusedRowCellValue(colUID));
            if(XtraMessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sc = new ServerToClient();
                ux = new UserContext();
                sc = ux.deleteUser(ID);

                if(sc.Message == null)
                {
                    XtraMessageBox.Show("User successfully deleted!");
                    Init();
                }
                else
                {
                    XtraMessageBox.Show(sc.Message);
                }
            }
        }
    }
}