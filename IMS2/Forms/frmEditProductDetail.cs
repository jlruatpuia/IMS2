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
    public partial class frmEditProductDetail : XtraForm
    {
        public int DID { get; set; }
        public int SID { get; set; }

        ServerToClient sc;
        ProductContext px;

        void InitProducts()
        {
            sc = new ServerToClient();
            px = new ProductContext();

            sc = px.GetProductSimple();

            luePNM.Properties.DataSource = sc.DT;
            luePNM.Properties.DisplayMember = "ProductName";
            luePNM.Properties.ValueMember = "ID";
        }
        public frmEditProductDetail()
        {
            InitializeComponent();

            InitProducts();
        }

        public frmEditProductDetail(int PID, int DID)
        {
            InitializeComponent();

            InitProducts();
 this.DID = DID;
            luePNM.EditValue = PID;
           
        }

        private void luePNM_EditValueChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(luePNM.EditValue);

            sc = new ServerToClient();
            px = new ProductContext();
            ProductDetail pd = new ProductDetail();

            pd = px.GetProductDetail(DID);

            txtBVL.Text = pd.BuyingValue.ToString();
            txtSVL.Text = pd.SellingValue.ToString();
            txtMFG.Text = pd.MfgDate;
            txtEXP.Text = pd.ExpDate;
            txtBCD.Text = pd.BarCode;
            txtQTY.Text = pd.Quantity.ToString();
            SID = pd.Supplier;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            px = new ProductContext();
            ProductDetail pd = new ProductDetail();

            pd.ID = DID;
            pd.ProductID = Convert.ToInt32(luePNM.EditValue);
            pd.BuyingValue = Convert.ToDouble(txtBVL.EditValue);
            pd.SellingValue = Convert.ToDouble(txtSVL.EditValue);
            pd.MfgDate = txtMFG.Text;
            pd.ExpDate = txtEXP.Text;
            pd.Quantity = Convert.ToInt32(txtQTY.Text);
            pd.Supplier = SID;

            sc = new ServerToClient();
            sc = px.UpdateProductDetail(pd);
            if(sc.Message == null)
            {
                XtraMessageBox.Show("Product detail updated!");
                Close();
            }
            else
            {
                XtraMessageBox.Show(sc.Message);
            }
        }
    }
}