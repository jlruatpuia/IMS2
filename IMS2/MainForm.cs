using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS2.Codes;
using IMS2.Forms;
using IMS2.UserControls;
using IMS2.Reports;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using MySql.Data.MySqlClient;

namespace IMS2
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
            dlaf.LookAndFeel.SkinName = Properties.Settings.Default.WindowTheme;
            MySettings.GeometryFromString(Properties.Settings.Default.WindowGeometry, this);

            new frmLogin().ShowDialog();
        }

        private void LoadControl(XtraUserControl ctrl)
        {
            ctrl.Dock = DockStyle.Fill;
            spl.Panel2.Controls.Clear();
            spl.Panel2.Controls.Add(ctrl);
            bClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            
        }

        private void bPrd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucProductsView uc = new ucProductsView() { Dock = DockStyle.Fill };
            LoadControl(uc);
            MainRibbon.MergeRibbon(uc.ribbonControl);
            MainRibbon.SelectedPage = MainRibbon.MergedRibbon.SelectedPage;
        }

        private void nProducts_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ucProductsView uc = new ucProductsView() { Dock = DockStyle.Fill };
            LoadControl(uc);
            MainRibbon.MergeRibbon(uc.ribbonControl);
            MainRibbon.SelectedPage = MainRibbon.MergedRibbon.SelectedPage;
        }

        private void nSuppliers_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ucSuppliers uc = new ucSuppliers() { Dock = DockStyle.Fill };
            LoadControl(uc);
            MainRibbon.MergeRibbon(uc.ribbonControl1);
            MainRibbon.SelectedPage = MainRibbon.MergedRibbon.SelectedPage;
        }

        private void nCustomers_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ucCustomers uc = new ucCustomers() { Dock = DockStyle.Fill };
            LoadControl(uc);
            MainRibbon.MergeRibbon(uc.ribbonControl1);
            MainRibbon.SelectedPage = MainRibbon.MergedRibbon.SelectedPage;
        }

        private void bSell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSellProduct frm = new frmSellProduct();
            frm.ShowDialog();
        }

        private void bQSell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmQuickSale().Show();
        }

        private void bPurchase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPurchase frm = new frmPurchase();
            frm.ShowDialog();
        }

        private void bCat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmCategories().ShowDialog();
        }

        private void bSoldProducts_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void nProductList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void nSupplierDetailReport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void nSupplierReport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void bPrinterSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmPrinter().ShowDialog();
        }

        private void bBackup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                string file = null;
                fbd.RootFolder = System.Environment.SpecialFolder.Desktop;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    file = fbd.SelectedPath + "\\DB_BACKUP_" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString() + ".sql";
                }

                using (MySqlConnection conn = new MySqlConnection(MySettings.ConnString()))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
            }
            catch {; }
        }

        private void bRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string file = null;
                OpenFileDialog sfd = new OpenFileDialog() { Filter = "Backup File (*.sql)|*.sql|All Files (*.*)|*.*" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //File.Copy(sfd.FileName, Application.StartupPath + "/ims.mdb", true);
                    file = sfd.FileName;
                }
                using (MySqlConnection conn = new MySqlConnection(MySettings.ConnString()))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(file);
                            conn.Close();
                        }
                    }
                }
            }
            catch {; }
        }

        private void bUsers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmUsers().ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.WindowTheme = dlaf.LookAndFeel.ActiveSkinName;
            Properties.Settings.Default.WindowGeometry = MySettings.GeometryToString(this);
            Properties.Settings.Default.Save();
        }

        private void bSchedule_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmSchedule().ShowDialog();
        }

        private void nReports_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ucReportViewer uc = new ucReportViewer() { Dock = DockStyle.Fill };
            LoadControl(uc);
            MainRibbon.MergeRibbon(uc.ribbonControl1);
            MainRibbon.SelectedPage = MainRibbon.MergedRibbon.SelectedPage;
        }

        private void bClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucDashboard uc = new ucDashboard() { Dock = DockStyle.Fill };
            LoadControl(uc);
            MainRibbon.MergeRibbon(uc.ribbonControl1);
            MainRibbon.SelectedPage = MainRibbon.MergedRibbon.SelectedPage;
            bClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
    }
}
