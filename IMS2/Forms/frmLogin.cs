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
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
            lbMSG.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ServerToClient sc = new ServerToClient();
            UserContext ux = new UserContext();

            sc = ux.Login(txtUNM.Text, txtPWD.Text);

            if(sc.Message == null)
            {
                MySettings.Password = txtPWD.Text;
                MySettings.UserID = sc.Count;
                //MySettings.UserLevel = sc.Count;
                Hide();
            }
            else
            {
                lbMSG.Text = sc.Message;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}