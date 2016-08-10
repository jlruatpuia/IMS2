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
    public partial class frmAddCategory : XtraForm
    {
        public int CID { get; set; }
        public string CNM { get; set; }
        public frmAddCategory()
        {
            InitializeComponent();
        }

        public frmAddCategory(int ID)
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
            CNM = txtCNM.Text;

            DialogResult = DialogResult.OK;
        }
    }
}