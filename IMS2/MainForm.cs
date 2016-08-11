﻿using System;
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
using DevExpress.XtraEditors;

namespace IMS2
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadControl(XtraUserControl ctrl)
        {
            ctrl.Dock = DockStyle.Fill;
            spl.Panel2.Controls.Clear();
            spl.Panel2.Controls.Add(ctrl);
            //bClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            
        }

        private void bPrd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucProducts uc = new ucProducts() { Dock = DockStyle.Fill };
            LoadControl(uc);
            MainRibbon.MergeRibbon(uc.ribbonControl);
            MainRibbon.SelectedPage = MainRibbon.MergedRibbon.SelectedPage;
        }

        private void nProducts_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ucProducts uc = new ucProducts() { Dock = DockStyle.Fill };
            LoadControl(uc);
            MainRibbon.MergeRibbon(uc.ribbonControl);
            MainRibbon.SelectedPage = MainRibbon.MergedRibbon.SelectedPage;
        }

        private void nSuppliers_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

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
            frmQuickSale frm = new frmQuickSale();
            frm.ShowDialog();
        }
    }
}
