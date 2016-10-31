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
using DevExpress.XtraEditors.DXErrorProvider;

namespace IMS2.Forms
{
    public partial class frmManageUser : XtraForm
    {
        ServerToClient sc;
        UserContext ux;

        int ID;
        public frmManageUser()
        {
            InitializeComponent();
            lcOPWD.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            Text = "Add New User";
        }

        public frmManageUser(int ID)
        {
            InitializeComponent();
            lcOPWD.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            this.ID = ID;

            Users u = new Users();
            UserContext ux = new UserContext();
            u = ux.getUser(ID);
            ID = u.ID;
            txtUNM.Text = u.UserName;
            rdoLVL.EditValue = u.UserLevel;
            btnSave.Text = "&Update";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;

            sc = new ServerToClient();
            ux = new UserContext();
            Users u = new Users();

            u.ID = ID;
            u.UserName = txtUNM.Text;
            u.Password = txtPWD1.Text;
            u.UserLevel = Convert.ToInt32(rdoLVL.EditValue);

            if(btnSave.Text == "&Save")
            {
                sc = ux.addUser(u);
                if(sc.Message == null)
                {
                    XtraMessageBox.Show("New User created!");
                    txtUNM.Text = "";
                    txtPWD1.Text = "";
                    txtPWD2.Text = "";
                    rdoLVL.SelectedIndex = -1;
                }
                else
                {
                    XtraMessageBox.Show(sc.Message);
                }
            }
            else
            {
                if (string.Compare(txtPWDO.Text, MySettings.Password) == 0)
                {
                    ConditionValidationRule rule = new ConditionValidationRule();

                rule.ConditionOperator = ConditionOperator.IsNotBlank;
                rule.ErrorText = "This value is not valid";
                dxValidationProvider1.SetValidationRule(txtPWDO, rule);

                //CompareAgainstControlValidationRule compare = new CompareAgainstControlValidationRule();
                //compare.CompareControlOperator = CompareControlOperator.Equals;
                //compare.Control = txtPWDO;
                //compare.ErrorText = "Password missmatch";
                //this.dxValidationProvider1.SetValidationRule(txtPWD1, compare);

                if (!dxValidationProvider1.Validate()) return;

                
                    sc = ux.updateUser(u);
                    if (sc.Message == null)
                    {
                        XtraMessageBox.Show("User details updated!");
                        Close();
                    }
                    else
                    {
                        XtraMessageBox.Show(sc.Message);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Old password incorrect!");
                }

            }
        }
    }
}