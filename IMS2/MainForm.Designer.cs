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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainRibbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bPrd = new DevExpress.XtraBars.BarButtonItem();
            this.bCat = new DevExpress.XtraBars.BarButtonItem();
            this.bSell = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.spl = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nProducts = new DevExpress.XtraNavBar.NavBarItem();
            this.nSuppliers = new DevExpress.XtraNavBar.NavBarItem();
            this.nCustomers = new DevExpress.XtraNavBar.NavBarItem();
            this.bQSell = new DevExpress.XtraBars.BarButtonItem();
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
            this.bQSell});
            this.MainRibbon.Location = new System.Drawing.Point(0, 0);
            this.MainRibbon.MaxItemId = 5;
            this.MainRibbon.Name = "MainRibbon";
            this.MainRibbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.MainRibbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.MainRibbon.Size = new System.Drawing.Size(1035, 143);
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
            // 
            // bSell
            // 
            this.bSell.Caption = "Sell";
            this.bSell.Glyph = ((System.Drawing.Image)(resources.GetObject("bSell.Glyph")));
            this.bSell.Id = 3;
            this.bSell.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bSell.LargeGlyph")));
            this.bSell.Name = "bSell";
            this.bSell.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bSell_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bQSell);
            this.ribbonPageGroup3.ItemLinks.Add(this.bSell);
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
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Supplier";
            // 
            // spl
            // 
            this.spl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spl.Location = new System.Drawing.Point(0, 143);
            this.spl.Name = "spl";
            this.spl.Panel1.Controls.Add(this.navBarControl1);
            this.spl.Panel1.Text = "Panel1";
            this.spl.Panel2.Text = "Panel2";
            this.spl.Size = new System.Drawing.Size(1035, 543);
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
            this.nCustomers});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 188;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(188, 543);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Data";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nProducts),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nSuppliers),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nCustomers)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // nProducts
            // 
            this.nProducts.Caption = "Products";
            this.nProducts.Name = "nProducts";
            this.nProducts.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nProducts_LinkClicked);
            // 
            // nSuppliers
            // 
            this.nSuppliers.Caption = "Suppliers";
            this.nSuppliers.Name = "nSuppliers";
            this.nSuppliers.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nSuppliers_LinkClicked);
            // 
            // nCustomers
            // 
            this.nCustomers.Caption = "Customers";
            this.nCustomers.Name = "nCustomers";
            this.nCustomers.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nCustomers_LinkClicked);
            // 
            // bQSell
            // 
            this.bQSell.Caption = "Quick Sell";
            this.bQSell.Glyph = ((System.Drawing.Image)(resources.GetObject("bQSell.Glyph")));
            this.bQSell.Id = 4;
            this.bQSell.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bQSell.LargeGlyph")));
            this.bQSell.Name = "bQSell";
            this.bQSell.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bQSell_ItemClick);
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 686);
            this.Controls.Add(this.spl);
            this.Controls.Add(this.MainRibbon);
            this.Name = "MainForm";
            this.Ribbon = this.MainRibbon;
            this.Text = "Form1";
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
    }
}

