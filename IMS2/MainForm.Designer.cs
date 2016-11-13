namespace IMS2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainRibbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bPrd = new DevExpress.XtraBars.BarButtonItem();
            this.bCat = new DevExpress.XtraBars.BarButtonItem();
            this.bSell = new DevExpress.XtraBars.BarButtonItem();
            this.bQSell = new DevExpress.XtraBars.BarButtonItem();
            this.bPurchase = new DevExpress.XtraBars.BarButtonItem();
            this.bPrinterSettings = new DevExpress.XtraBars.BarButtonItem();
            this.bClose = new DevExpress.XtraBars.BarButtonItem();
            this.bUsers = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.bBackup = new DevExpress.XtraBars.BarButtonItem();
            this.bRestore = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.bSchedule = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.spl = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nProducts = new DevExpress.XtraNavBar.NavBarItem();
            this.nSuppliers = new DevExpress.XtraNavBar.NavBarItem();
            this.nCustomers = new DevExpress.XtraNavBar.NavBarItem();
            this.nReports = new DevExpress.XtraNavBar.NavBarItem();
            this.nProductList = new DevExpress.XtraNavBar.NavBarItem();
            this.bSoldProducts = new DevExpress.XtraNavBar.NavBarItem();
            this.nSupplierReport = new DevExpress.XtraNavBar.NavBarItem();
            this.nSupplierDetailReport = new DevExpress.XtraNavBar.NavBarItem();
            this.dlaf = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.nChart = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.MainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spl)).BeginInit();
            this.spl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainRibbon
            // 
            this.MainRibbon.ExpandCollapseItem.Id = 0;
            this.MainRibbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.MainRibbon.ExpandCollapseItem,
            this.bPrd,
            this.bCat,
            this.bSell,
            this.bQSell,
            this.bPurchase,
            this.bPrinterSettings,
            this.bClose,
            this.bUsers,
            this.barSubItem1,
            this.bBackup,
            this.bRestore,
            this.skinRibbonGalleryBarItem1,
            this.bSchedule});
            this.MainRibbon.Location = new System.Drawing.Point(0, 0);
            this.MainRibbon.MaxItemId = 16;
            this.MainRibbon.Name = "MainRibbon";
            this.MainRibbon.PageHeaderItemLinks.Add(this.bClose);
            this.MainRibbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.MainRibbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.MainRibbon.Size = new System.Drawing.Size(837, 143);
            this.MainRibbon.Toolbar.ItemLinks.Add(this.bPrinterSettings);
            // 
            // bPrd
            // 
            this.bPrd.Caption = "Products";
            this.bPrd.Glyph = ((System.Drawing.Image)(resources.GetObject("bPrd.Glyph")));
            this.bPrd.Id = 1;
            this.bPrd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bPrd.LargeGlyph")));
            this.bPrd.Name = "bPrd";
            this.bPrd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bPrd_ItemClick);
            // 
            // bCat
            // 
            this.bCat.Caption = "Categories";
            this.bCat.Glyph = ((System.Drawing.Image)(resources.GetObject("bCat.Glyph")));
            this.bCat.Id = 2;
            this.bCat.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bCat.LargeGlyph")));
            this.bCat.Name = "bCat";
            this.bCat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bCat_ItemClick);
            // 
            // bSell
            // 
            this.bSell.Caption = "Sell";
            this.bSell.Glyph = ((System.Drawing.Image)(resources.GetObject("bSell.Glyph")));
            this.bSell.Id = 3;
            this.bSell.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.bSell.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bSell.LargeGlyph")));
            this.bSell.Name = "bSell";
            this.bSell.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bSell_ItemClick);
            // 
            // bQSell
            // 
            this.bQSell.Caption = "Quick Sell";
            this.bQSell.Glyph = ((System.Drawing.Image)(resources.GetObject("bQSell.Glyph")));
            this.bQSell.Id = 4;
            this.bQSell.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.bQSell.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bQSell.LargeGlyph")));
            this.bQSell.Name = "bQSell";
            this.bQSell.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bQSell_ItemClick);
            // 
            // bPurchase
            // 
            this.bPurchase.Caption = "Purchase";
            this.bPurchase.Glyph = ((System.Drawing.Image)(resources.GetObject("bPurchase.Glyph")));
            this.bPurchase.Id = 5;
            this.bPurchase.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.bPurchase.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bPurchase.LargeGlyph")));
            this.bPurchase.Name = "bPurchase";
            this.bPurchase.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bPurchase_ItemClick);
            // 
            // bPrinterSettings
            // 
            this.bPrinterSettings.Caption = "Printer Settings";
            this.bPrinterSettings.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bPrinterSettings.Glyph = ((System.Drawing.Image)(resources.GetObject("bPrinterSettings.Glyph")));
            this.bPrinterSettings.Id = 7;
            this.bPrinterSettings.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bPrinterSettings.LargeGlyph")));
            this.bPrinterSettings.Name = "bPrinterSettings";
            this.bPrinterSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bPrinterSettings_ItemClick);
            // 
            // bClose
            // 
            this.bClose.Caption = "Close";
            this.bClose.Glyph = ((System.Drawing.Image)(resources.GetObject("bClose.Glyph")));
            this.bClose.Id = 8;
            this.bClose.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bClose.LargeGlyph")));
            this.bClose.Name = "bClose";
            this.bClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bClose_ItemClick);
            // 
            // bUsers
            // 
            this.bUsers.Caption = "Users";
            this.bUsers.Glyph = ((System.Drawing.Image)(resources.GetObject("bUsers.Glyph")));
            this.bUsers.Id = 9;
            this.bUsers.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bUsers.LargeGlyph")));
            this.bUsers.Name = "bUsers";
            this.bUsers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bUsers_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Database";
            this.barSubItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barSubItem1.Glyph")));
            this.barSubItem1.Id = 11;
            this.barSubItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barSubItem1.LargeGlyph")));
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bBackup),
            new DevExpress.XtraBars.LinkPersistInfo(this.bRestore)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // bBackup
            // 
            this.bBackup.Caption = "Backup Database";
            this.bBackup.Id = 12;
            this.bBackup.Name = "bBackup";
            this.bBackup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBackup_ItemClick);
            // 
            // bRestore
            // 
            this.bRestore.Caption = "Restore Database";
            this.bRestore.Id = 13;
            this.bRestore.Name = "bRestore";
            this.bRestore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bRestore_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 14;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // bSchedule
            // 
            this.bSchedule.Caption = "Schedule Backup";
            this.bSchedule.Id = 15;
            this.bSchedule.Name = "bSchedule";
            this.bSchedule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bSchedule_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bQSell);
            this.ribbonPageGroup3.ItemLinks.Add(this.bSell);
            this.ribbonPageGroup3.ItemLinks.Add(this.bPurchase);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "Transaction";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bPrd);
            this.ribbonPageGroup1.ItemLinks.Add(this.bCat);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Product";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bUsers);
            this.ribbonPageGroup2.ItemLinks.Add(this.barSubItem1);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Settings";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            this.ribbonPageGroup4.Text = "Theme";
            // 
            // spl
            // 
            this.spl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spl.Location = new System.Drawing.Point(0, 143);
            this.spl.Name = "spl";
            this.spl.Panel1.Controls.Add(this.navBarControl1);
            this.spl.Panel1.Text = "Panel1";
            this.spl.Panel2.Text = "Panel2";
            this.spl.Size = new System.Drawing.Size(837, 366);
            this.spl.SplitterPosition = 188;
            this.spl.TabIndex = 3;
            this.spl.Text = "splitContainerControl1";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nProducts,
            this.nSuppliers,
            this.nCustomers,
            this.nProductList,
            this.bSoldProducts,
            this.nSupplierReport,
            this.nSupplierDetailReport,
            this.nReports,
            this.nChart});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 188;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(188, 366);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Data";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nProducts),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nSuppliers),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nCustomers),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nReports),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nChart)});
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.TopVisibleLinkIndex = 2;
            // 
            // nProducts
            // 
            this.nProducts.Caption = "Products";
            this.nProducts.LargeImage = ((System.Drawing.Image)(resources.GetObject("nProducts.LargeImage")));
            this.nProducts.Name = "nProducts";
            this.nProducts.SmallImage = ((System.Drawing.Image)(resources.GetObject("nProducts.SmallImage")));
            this.nProducts.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nProducts_LinkClicked);
            // 
            // nSuppliers
            // 
            this.nSuppliers.Caption = "Suppliers";
            this.nSuppliers.LargeImage = ((System.Drawing.Image)(resources.GetObject("nSuppliers.LargeImage")));
            this.nSuppliers.Name = "nSuppliers";
            this.nSuppliers.SmallImage = ((System.Drawing.Image)(resources.GetObject("nSuppliers.SmallImage")));
            this.nSuppliers.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nSuppliers_LinkClicked);
            // 
            // nCustomers
            // 
            this.nCustomers.Caption = "Customers";
            this.nCustomers.LargeImage = ((System.Drawing.Image)(resources.GetObject("nCustomers.LargeImage")));
            this.nCustomers.Name = "nCustomers";
            this.nCustomers.SmallImage = ((System.Drawing.Image)(resources.GetObject("nCustomers.SmallImage")));
            this.nCustomers.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nCustomers_LinkClicked);
            // 
            // nReports
            // 
            this.nReports.Caption = "Reports";
            this.nReports.LargeImage = ((System.Drawing.Image)(resources.GetObject("nReports.LargeImage")));
            this.nReports.Name = "nReports";
            this.nReports.SmallImage = ((System.Drawing.Image)(resources.GetObject("nReports.SmallImage")));
            this.nReports.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nReports_LinkClicked);
            // 
            // nProductList
            // 
            this.nProductList.Caption = "Stock Report";
            this.nProductList.Name = "nProductList";
            this.nProductList.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nProductList_LinkClicked);
            // 
            // bSoldProducts
            // 
            this.bSoldProducts.Caption = "Sold Products";
            this.bSoldProducts.Name = "bSoldProducts";
            this.bSoldProducts.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.bSoldProducts_LinkClicked);
            // 
            // nSupplierReport
            // 
            this.nSupplierReport.Caption = "Supplier Report";
            this.nSupplierReport.Name = "nSupplierReport";
            this.nSupplierReport.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nSupplierReport_LinkClicked);
            // 
            // nSupplierDetailReport
            // 
            this.nSupplierDetailReport.Caption = "Supplier Detail Report";
            this.nSupplierDetailReport.Name = "nSupplierDetailReport";
            this.nSupplierDetailReport.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nSupplierDetailReport_LinkClicked);
            // 
            // nChart
            // 
            this.nChart.Caption = "Chart";
            this.nChart.LargeImage = ((System.Drawing.Image)(resources.GetObject("nChart.LargeImage")));
            this.nChart.Name = "nChart";
            this.nChart.SmallImage = ((System.Drawing.Image)(resources.GetObject("nChart.SmallImage")));
            this.nChart.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nChart_LinkClicked);
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 509);
            this.Controls.Add(this.spl);
            this.Controls.Add(this.MainRibbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Ribbon = this.MainRibbon;
            this.Text = "KV Mart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.MainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spl)).EndInit();
            this.spl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl MainRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bPrd;
        private DevExpress.XtraBars.BarButtonItem bCat;
        private DevExpress.XtraEditors.SplitContainerControl spl;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem nProducts;
        private DevExpress.XtraNavBar.NavBarItem nSuppliers;
        private DevExpress.XtraNavBar.NavBarItem nCustomers;
        private DevExpress.XtraBars.BarButtonItem bSell;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bQSell;
        private DevExpress.XtraBars.BarButtonItem bPurchase;
        private DevExpress.XtraNavBar.NavBarItem nProductList;
        private DevExpress.XtraNavBar.NavBarItem bSoldProducts;
        private DevExpress.XtraNavBar.NavBarItem nSupplierReport;
        private DevExpress.XtraNavBar.NavBarItem nSupplierDetailReport;
        private DevExpress.XtraBars.BarButtonItem bPrinterSettings;
        private DevExpress.XtraBars.BarButtonItem bClose;
        private DevExpress.XtraBars.BarButtonItem bUsers;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem bBackup;
        private DevExpress.XtraBars.BarButtonItem bRestore;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.LookAndFeel.DefaultLookAndFeel dlaf;
        private DevExpress.XtraBars.BarButtonItem bSchedule;
        private DevExpress.XtraNavBar.NavBarItem nReports;
        private DevExpress.XtraNavBar.NavBarItem nChart;
    }
}

