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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProducts));
            this.grvD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSCT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCMP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPNM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPKG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bNew = new DevExpress.XtraBars.BarButtonItem();
            this.bEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bDel = new DevExpress.XtraBars.BarButtonItem();
            this.bExpand = new DevExpress.XtraBars.BarCheckItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.grvD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // grvD
            // 
            this.grvD.GridControl = this.grd;
            this.grvD.Name = "grvD";
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.grvD;
            gridLevelNode1.RelationName = "gvPD";
            this.grd.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grd.Location = new System.Drawing.Point(0, 141);
            this.grd.MainView = this.grv;
            this.grd.MenuManager = this.ribbonControl;
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(806, 364);
            this.grd.TabIndex = 1;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv,
            this.grvD});
            // 
            // grv
            // 
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPID,
            this.colCAT,
            this.colSCT,
            this.colCMP,
            this.colPNM,
            this.colPKG,
            this.colQTY});
            this.grv.GridControl = this.grd;
            this.grv.GroupCount = 1;
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
            // colCMP
            // 
            this.colCMP.Caption = "Company";
            this.colCMP.FieldName = "Company";
            this.colCMP.Name = "colCMP";
            this.colCMP.OptionsColumn.AllowEdit = false;
            this.colCMP.OptionsColumn.AllowFocus = false;
            this.colCMP.OptionsColumn.ReadOnly = true;
            this.colCMP.Visible = true;
            this.colCMP.VisibleIndex = 1;
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
            this.colPNM.VisibleIndex = 2;
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
            this.colPKG.VisibleIndex = 3;
            // 
            // colQTY
            // 
            this.colQTY.Caption = "Quantity";
            this.colQTY.FieldName = "TotalQuantity";
            this.colQTY.Name = "colQTY";
            this.colQTY.OptionsColumn.AllowEdit = false;
            this.colQTY.OptionsColumn.AllowFocus = false;
            this.colQTY.OptionsColumn.ReadOnly = true;
            this.colQTY.Visible = true;
            this.colQTY.VisibleIndex = 4;
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
            // ucProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grd);
            this.Controls.Add(this.ribbonControl);
            this.Name = "ucProducts";
            this.Size = new System.Drawing.Size(806, 505);
            ((System.ComponentModel.ISupportInitialize)(this.grvD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colPKG;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarCheckItem bExpand;
        private DevExpress.XtraGrid.Columns.GridColumn colCMP;
        private DevExpress.XtraGrid.Views.Grid.GridView grvD;
        private DevExpress.XtraGrid.Columns.GridColumn colQTY;
    }
}
