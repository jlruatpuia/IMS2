namespace IMS2.UserControls
{
    partial class ucProducts
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProducts));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bNew = new DevExpress.XtraBars.BarButtonItem();
            this.bEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bDel = new DevExpress.XtraBars.BarButtonItem();
            this.bExpand = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSCT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPNM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBVL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSVL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMFG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEXP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPKG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTBV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTSV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBCD = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bNew,
            this.bEdit,
            this.bDel,
            this.bExpand});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 5;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.Size = new System.Drawing.Size(806, 141);
            // 
            // bNew
            // 
            this.bNew.Caption = "&New";
            this.bNew.Glyph = ((System.Drawing.Image)(resources.GetObject("bNew.Glyph")));
            this.bNew.Id = 1;
            this.bNew.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bNew.LargeGlyph")));
            this.bNew.Name = "bNew";
            this.bNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bNew_ItemClick);
            // 
            // bEdit
            // 
            this.bEdit.Caption = "&Edit";
            this.bEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("bEdit.Glyph")));
            this.bEdit.Id = 2;
            this.bEdit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bEdit.LargeGlyph")));
            this.bEdit.Name = "bEdit";
            this.bEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bEdit_ItemClick);
            // 
            // bDel
            // 
            this.bDel.Caption = "&Delete";
            this.bDel.Glyph = ((System.Drawing.Image)(resources.GetObject("bDel.Glyph")));
            this.bDel.Id = 3;
            this.bDel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bDel.LargeGlyph")));
            this.bDel.Name = "bDel";
            this.bDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bDel_ItemClick);
            // 
            // bExpand
            // 
            this.bExpand.Caption = "Simple";
            this.bExpand.Glyph = ((System.Drawing.Image)(resources.GetObject("bExpand.Glyph")));
            this.bExpand.Id = 4;
            this.bExpand.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bExpand.LargeGlyph")));
            this.bExpand.Name = "bExpand";
            this.bExpand.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.bExpand_CheckedChanged);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Products";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bDel);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Records";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bExpand);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "View";
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(0, 141);
            this.grd.MainView = this.grv;
            this.grd.MenuManager = this.ribbonControl;
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(806, 364);
            this.grd.TabIndex = 1;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPID,
            this.colCAT,
            this.colSCT,
            this.colPNM,
            this.colBVL,
            this.colSVL,
            this.colMFG,
            this.colEXP,
            this.colPKG,
            this.colQTY,
            this.colTBV,
            this.colTSV,
            this.colBCD});
            this.grv.GridControl = this.grd;
            this.grv.GroupCount = 1;
            this.grv.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BuyingValue", this.colBVL, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SellingValue", this.colSVL, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", this.colQTY, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalBuyingValue", this.colTBV, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalSellingValue", this.colTSV, "{0:c2}")});
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.AutoExpandAllGroups = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCAT, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grv.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grv_FocusedRowChanged);
            this.grv.Click += new System.EventHandler(this.grv_Click);
            // 
            // colPID
            // 
            this.colPID.Caption = "ID";
            this.colPID.FieldName = "ID";
            this.colPID.Name = "colPID";
            this.colPID.OptionsColumn.AllowEdit = false;
            this.colPID.OptionsColumn.AllowFocus = false;
            this.colPID.OptionsColumn.ReadOnly = true;
            // 
            // colCAT
            // 
            this.colCAT.Caption = "Category";
            this.colCAT.FieldName = "CategoryName";
            this.colCAT.Name = "colCAT";
            this.colCAT.OptionsColumn.AllowEdit = false;
            this.colCAT.OptionsColumn.AllowFocus = false;
            this.colCAT.OptionsColumn.ReadOnly = true;
            this.colCAT.Visible = true;
            this.colCAT.VisibleIndex = 0;
            // 
            // colSCT
            // 
            this.colSCT.Caption = "Sub-Category";
            this.colSCT.FieldName = "SubCategory";
            this.colSCT.Name = "colSCT";
            this.colSCT.OptionsColumn.AllowEdit = false;
            this.colSCT.OptionsColumn.AllowFocus = false;
            this.colSCT.OptionsColumn.ReadOnly = true;
            this.colSCT.Visible = true;
            this.colSCT.VisibleIndex = 0;
            // 
            // colPNM
            // 
            this.colPNM.Caption = "Product Name";
            this.colPNM.FieldName = "ProductName";
            this.colPNM.Name = "colPNM";
            this.colPNM.OptionsColumn.AllowEdit = false;
            this.colPNM.OptionsColumn.AllowFocus = false;
            this.colPNM.OptionsColumn.ReadOnly = true;
            this.colPNM.Visible = true;
            this.colPNM.VisibleIndex = 1;
            // 
            // colBVL
            // 
            this.colBVL.Caption = "Buying Value";
            this.colBVL.DisplayFormat.FormatString = "{0:C2}";
            this.colBVL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBVL.FieldName = "BuyingValue";
            this.colBVL.Name = "colBVL";
            this.colBVL.OptionsColumn.AllowEdit = false;
            this.colBVL.OptionsColumn.AllowFocus = false;
            this.colBVL.OptionsColumn.ReadOnly = true;
            this.colBVL.Visible = true;
            this.colBVL.VisibleIndex = 2;
            // 
            // colSVL
            // 
            this.colSVL.Caption = "Selling Value";
            this.colSVL.DisplayFormat.FormatString = "{0:C2}";
            this.colSVL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSVL.FieldName = "SellingValue";
            this.colSVL.Name = "colSVL";
            this.colSVL.OptionsColumn.AllowEdit = false;
            this.colSVL.OptionsColumn.AllowFocus = false;
            this.colSVL.OptionsColumn.ReadOnly = true;
            this.colSVL.Visible = true;
            this.colSVL.VisibleIndex = 3;
            // 
            // colMFG
            // 
            this.colMFG.Caption = "Mfg. Date";
            this.colMFG.DisplayFormat.FormatString = "d";
            this.colMFG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colMFG.FieldName = "MfgDate";
            this.colMFG.Name = "colMFG";
            this.colMFG.OptionsColumn.AllowEdit = false;
            this.colMFG.OptionsColumn.AllowFocus = false;
            this.colMFG.OptionsColumn.ReadOnly = true;
            this.colMFG.Visible = true;
            this.colMFG.VisibleIndex = 4;
            // 
            // colEXP
            // 
            this.colEXP.Caption = "Expiry Date";
            this.colEXP.DisplayFormat.FormatString = "d";
            this.colEXP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEXP.FieldName = "ExpDate";
            this.colEXP.Name = "colEXP";
            this.colEXP.OptionsColumn.AllowEdit = false;
            this.colEXP.OptionsColumn.AllowFocus = false;
            this.colEXP.OptionsColumn.ReadOnly = true;
            this.colEXP.Visible = true;
            this.colEXP.VisibleIndex = 5;
            // 
            // colPKG
            // 
            this.colPKG.Caption = "Package Size";
            this.colPKG.FieldName = "PackageSize";
            this.colPKG.Name = "colPKG";
            this.colPKG.OptionsColumn.AllowEdit = false;
            this.colPKG.OptionsColumn.AllowFocus = false;
            this.colPKG.OptionsColumn.ReadOnly = true;
            this.colPKG.Visible = true;
            this.colPKG.VisibleIndex = 6;
            // 
            // colQTY
            // 
            this.colQTY.Caption = "Quantity";
            this.colQTY.FieldName = "Quantity";
            this.colQTY.Name = "colQTY";
            this.colQTY.OptionsColumn.AllowEdit = false;
            this.colQTY.OptionsColumn.AllowFocus = false;
            this.colQTY.OptionsColumn.ReadOnly = true;
            this.colQTY.Visible = true;
            this.colQTY.VisibleIndex = 7;
            // 
            // colTBV
            // 
            this.colTBV.Caption = "Total Buying Value";
            this.colTBV.DisplayFormat.FormatString = "{0:C2}";
            this.colTBV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTBV.FieldName = "TotalBuyingValue";
            this.colTBV.Name = "colTBV";
            this.colTBV.OptionsColumn.AllowEdit = false;
            this.colTBV.OptionsColumn.AllowFocus = false;
            this.colTBV.OptionsColumn.ReadOnly = true;
            this.colTBV.Visible = true;
            this.colTBV.VisibleIndex = 8;
            // 
            // colTSV
            // 
            this.colTSV.Caption = "Total Selling Value";
            this.colTSV.DisplayFormat.FormatString = "{0:C2}";
            this.colTSV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTSV.FieldName = "TotalSellingValue";
            this.colTSV.Name = "colTSV";
            this.colTSV.OptionsColumn.AllowEdit = false;
            this.colTSV.OptionsColumn.AllowFocus = false;
            this.colTSV.OptionsColumn.ReadOnly = true;
            this.colTSV.Visible = true;
            this.colTSV.VisibleIndex = 9;
            // 
            // colBCD
            // 
            this.colBCD.Caption = "Bar Code";
            this.colBCD.FieldName = "BarCode";
            this.colBCD.Name = "colBCD";
            this.colBCD.OptionsColumn.AllowEdit = false;
            this.colBCD.OptionsColumn.AllowFocus = false;
            this.colBCD.OptionsColumn.ReadOnly = true;
            this.colBCD.Visible = true;
            this.colBCD.VisibleIndex = 10;
            // 
            // ucProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grd);
            this.Controls.Add(this.ribbonControl);
            this.Name = "ucProducts";
            this.Size = new System.Drawing.Size(806, 505);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bNew;
        private DevExpress.XtraBars.BarButtonItem bEdit;
        private DevExpress.XtraBars.BarButtonItem bDel;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn colPID;
        private DevExpress.XtraGrid.Columns.GridColumn colCAT;
        private DevExpress.XtraGrid.Columns.GridColumn colSCT;
        private DevExpress.XtraGrid.Columns.GridColumn colPNM;
        private DevExpress.XtraGrid.Columns.GridColumn colBVL;
        private DevExpress.XtraGrid.Columns.GridColumn colSVL;
        private DevExpress.XtraGrid.Columns.GridColumn colMFG;
        private DevExpress.XtraGrid.Columns.GridColumn colEXP;
        private DevExpress.XtraGrid.Columns.GridColumn colPKG;
        private DevExpress.XtraGrid.Columns.GridColumn colQTY;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraGrid.Columns.GridColumn colTBV;
        private DevExpress.XtraGrid.Columns.GridColumn colTSV;
        private DevExpress.XtraBars.BarCheckItem bExpand;
        private DevExpress.XtraGrid.Columns.GridColumn colBCD;
    }
}
