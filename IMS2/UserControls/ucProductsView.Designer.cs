namespace IMS2.UserControls
{
    partial class ucProductsView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProductsView));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bNew = new DevExpress.XtraBars.BarButtonItem();
            this.bPrint = new DevExpress.XtraBars.BarButtonItem();
            this.bExport = new DevExpress.XtraBars.BarSubItem();
            this.bPDF = new DevExpress.XtraBars.BarButtonItem();
            this.bXLS = new DevExpress.XtraBars.BarButtonItem();
            this.bXLSX = new DevExpress.XtraBars.BarButtonItem();
            this.bDOC = new DevExpress.XtraBars.BarButtonItem();
            this.bEdit2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgRecords = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCNM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSCT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCMP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPNM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBVL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSVL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMFG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEXP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPKG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtQuery = new DevExpress.XtraEditors.SearchControl();
            this.cboField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.reportGenerator1 = new DevExpress.XtraReports.ReportGeneration.ReportGenerator(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bEdit,
            this.bDelete,
            this.bNew,
            this.bPrint,
            this.bExport,
            this.bPDF,
            this.bXLS,
            this.bXLSX,
            this.bDOC,
            this.bEdit2});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 12;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.Size = new System.Drawing.Size(821, 141);
            // 
            // bEdit
            // 
            this.bEdit.Caption = "Edit Product";
            this.bEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("bEdit.Glyph")));
            this.bEdit.Id = 1;
            this.bEdit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bEdit.LargeGlyph")));
            this.bEdit.Name = "bEdit";
            this.bEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bEdit_ItemClick);
            // 
            // bDelete
            // 
            this.bDelete.Caption = "Delete";
            this.bDelete.Glyph = ((System.Drawing.Image)(resources.GetObject("bDelete.Glyph")));
            this.bDelete.Id = 2;
            this.bDelete.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bDelete.LargeGlyph")));
            this.bDelete.Name = "bDelete";
            this.bDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bDelete_ItemClick);
            // 
            // bNew
            // 
            this.bNew.Caption = "New";
            this.bNew.Glyph = ((System.Drawing.Image)(resources.GetObject("bNew.Glyph")));
            this.bNew.Id = 3;
            this.bNew.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bNew.LargeGlyph")));
            this.bNew.Name = "bNew";
            this.bNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bNew_ItemClick);
            // 
            // bPrint
            // 
            this.bPrint.Caption = "&Print";
            this.bPrint.Glyph = ((System.Drawing.Image)(resources.GetObject("bPrint.Glyph")));
            this.bPrint.Id = 4;
            this.bPrint.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bPrint.LargeGlyph")));
            this.bPrint.Name = "bPrint";
            this.bPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bPrint_ItemClick);
            // 
            // bExport
            // 
            this.bExport.Caption = "Export";
            this.bExport.Glyph = ((System.Drawing.Image)(resources.GetObject("bExport.Glyph")));
            this.bExport.Id = 6;
            this.bExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bExport.LargeGlyph")));
            this.bExport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bPDF),
            new DevExpress.XtraBars.LinkPersistInfo(this.bXLS),
            new DevExpress.XtraBars.LinkPersistInfo(this.bXLSX),
            new DevExpress.XtraBars.LinkPersistInfo(this.bDOC)});
            this.bExport.Name = "bExport";
            // 
            // bPDF
            // 
            this.bPDF.Caption = "To PDF";
            this.bPDF.Glyph = ((System.Drawing.Image)(resources.GetObject("bPDF.Glyph")));
            this.bPDF.Id = 7;
            this.bPDF.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bPDF.LargeGlyph")));
            this.bPDF.Name = "bPDF";
            this.bPDF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bPDF_ItemClick);
            // 
            // bXLS
            // 
            this.bXLS.Caption = "To XLS";
            this.bXLS.Glyph = ((System.Drawing.Image)(resources.GetObject("bXLS.Glyph")));
            this.bXLS.Id = 8;
            this.bXLS.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bXLS.LargeGlyph")));
            this.bXLS.Name = "bXLS";
            this.bXLS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bXLS_ItemClick);
            // 
            // bXLSX
            // 
            this.bXLSX.Caption = "To XLSX";
            this.bXLSX.Glyph = ((System.Drawing.Image)(resources.GetObject("bXLSX.Glyph")));
            this.bXLSX.Id = 9;
            this.bXLSX.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bXLSX.LargeGlyph")));
            this.bXLSX.Name = "bXLSX";
            this.bXLSX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bXLSX_ItemClick);
            // 
            // bDOC
            // 
            this.bDOC.Caption = "To DOC";
            this.bDOC.Glyph = ((System.Drawing.Image)(resources.GetObject("bDOC.Glyph")));
            this.bDOC.Id = 10;
            this.bDOC.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bDOC.LargeGlyph")));
            this.bDOC.Name = "bDOC";
            this.bDOC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bDOC_ItemClick);
            // 
            // bEdit2
            // 
            this.bEdit2.Caption = "Edit Product Detail";
            this.bEdit2.Glyph = ((System.Drawing.Image)(resources.GetObject("bEdit2.Glyph")));
            this.bEdit2.Id = 11;
            this.bEdit2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bEdit2.LargeGlyph")));
            this.bEdit2.Name = "bEdit2";
            this.bEdit2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bEdit2_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgRecords,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Products";
            // 
            // rpgRecords
            // 
            this.rpgRecords.ItemLinks.Add(this.bNew);
            this.rpgRecords.ItemLinks.Add(this.bEdit);
            this.rpgRecords.ItemLinks.Add(this.bEdit2);
            this.rpgRecords.ItemLinks.Add(this.bDelete);
            this.rpgRecords.Name = "rpgRecords";
            this.rpgRecords.ShowCaptionButton = false;
            this.rpgRecords.Text = "Records";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bPrint);
            this.ribbonPageGroup2.ItemLinks.Add(this.bExport);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Print && Export";
            // 
            // grd
            // 
            this.grd.Location = new System.Drawing.Point(12, 36);
            this.grd.MainView = this.grv;
            this.grd.MenuManager = this.ribbonControl;
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(797, 313);
            this.grd.TabIndex = 1;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPID,
            this.colDID,
            this.colCNM,
            this.colSCT,
            this.colCMP,
            this.colPNM,
            this.colBVL,
            this.colSVL,
            this.colQTY,
            this.colMFG,
            this.colEXP,
            this.colPKG});
            this.grv.GridControl = this.grd;
            this.grv.GroupCount = 1;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.AutoExpandAllGroups = true;
            this.grv.OptionsFind.AllowFindPanel = false;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCNM, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colPID
            // 
            this.colPID.Caption = "ID";
            this.colPID.FieldName = "PID";
            this.colPID.Name = "colPID";
            // 
            // colDID
            // 
            this.colDID.Caption = "gridColumn1";
            this.colDID.FieldName = "DID";
            this.colDID.Name = "colDID";
            // 
            // colCNM
            // 
            this.colCNM.Caption = "Category";
            this.colCNM.FieldName = "CategoryName";
            this.colCNM.Name = "colCNM";
            this.colCNM.OptionsColumn.AllowEdit = false;
            this.colCNM.OptionsColumn.AllowFocus = false;
            this.colCNM.OptionsColumn.ReadOnly = true;
            this.colCNM.Visible = true;
            this.colCNM.VisibleIndex = 0;
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
            this.colBVL.VisibleIndex = 3;
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
            this.colSVL.VisibleIndex = 4;
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
            this.colQTY.VisibleIndex = 5;
            // 
            // colMFG
            // 
            this.colMFG.Caption = "Mfg. Date";
            this.colMFG.FieldName = "MfgDate";
            this.colMFG.Name = "colMFG";
            this.colMFG.OptionsColumn.AllowEdit = false;
            this.colMFG.OptionsColumn.AllowFocus = false;
            this.colMFG.OptionsColumn.ReadOnly = true;
            this.colMFG.Visible = true;
            this.colMFG.VisibleIndex = 6;
            // 
            // colEXP
            // 
            this.colEXP.Caption = "Exp. Date";
            this.colEXP.FieldName = "ExpDate";
            this.colEXP.Name = "colEXP";
            this.colEXP.OptionsColumn.AllowEdit = false;
            this.colEXP.OptionsColumn.AllowFocus = false;
            this.colEXP.OptionsColumn.ReadOnly = true;
            this.colEXP.Visible = true;
            this.colEXP.VisibleIndex = 7;
            // 
            // colPKG
            // 
            this.colPKG.Caption = "Pkg. Size";
            this.colPKG.FieldName = "PackageSize";
            this.colPKG.Name = "colPKG";
            this.colPKG.OptionsColumn.AllowEdit = false;
            this.colPKG.OptionsColumn.AllowFocus = false;
            this.colPKG.OptionsColumn.ReadOnly = true;
            this.colPKG.Visible = true;
            this.colPKG.VisibleIndex = 8;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtQuery);
            this.layoutControl1.Controls.Add(this.cboField);
            this.layoutControl1.Controls.Add(this.grd);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 141);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(545, 273, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(821, 361);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(291, 12);
            this.txtQuery.MenuManager = this.ribbonControl;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.txtQuery.Size = new System.Drawing.Size(187, 20);
            this.txtQuery.StyleController = this.layoutControl1;
            this.txtQuery.TabIndex = 7;
            this.txtQuery.TextChanged += new System.EventHandler(this.txtQuery_TextChanged);
            // 
            // cboField
            // 
            this.cboField.Location = new System.Drawing.Point(77, 12);
            this.cboField.MenuManager = this.ribbonControl;
            this.cboField.Name = "cboField";
            this.cboField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboField.Properties.Items.AddRange(new object[] {
            "ProductName",
            "CategoryName",
            "SubCategory",
            "Company"});
            this.cboField.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboField.Size = new System.Drawing.Size(145, 20);
            this.cboField.StyleController = this.layoutControl1;
            this.cboField.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(821, 361);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grd;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(801, 317);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cboField;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(214, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(214, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(214, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Search By:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(62, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(470, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(331, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtQuery;
            this.layoutControlItem5.Location = new System.Drawing.Point(214, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(256, 24);
            this.layoutControlItem5.Text = "Search Text:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(62, 13);
            // 
            // ucProductsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl);
            this.Name = "ucProductsView";
            this.Size = new System.Drawing.Size(821, 502);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtQuery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgRecords;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn colPID;
        private DevExpress.XtraGrid.Columns.GridColumn colCNM;
        private DevExpress.XtraGrid.Columns.GridColumn colSCT;
        private DevExpress.XtraGrid.Columns.GridColumn colCMP;
        private DevExpress.XtraGrid.Columns.GridColumn colPNM;
        private DevExpress.XtraGrid.Columns.GridColumn colBVL;
        private DevExpress.XtraGrid.Columns.GridColumn colSVL;
        private DevExpress.XtraGrid.Columns.GridColumn colQTY;
        private DevExpress.XtraGrid.Columns.GridColumn colMFG;
        private DevExpress.XtraGrid.Columns.GridColumn colEXP;
        private DevExpress.XtraGrid.Columns.GridColumn colPKG;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboField;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraEditors.SearchControl txtQuery;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraBars.BarButtonItem bEdit;
        private DevExpress.XtraBars.BarButtonItem bDelete;
        private DevExpress.XtraBars.BarButtonItem bNew;
        private DevExpress.XtraBars.BarButtonItem bPrint;
        private DevExpress.XtraBars.BarSubItem bExport;
        private DevExpress.XtraBars.BarButtonItem bPDF;
        private DevExpress.XtraBars.BarButtonItem bXLS;
        private DevExpress.XtraBars.BarButtonItem bXLSX;
        private DevExpress.XtraBars.BarButtonItem bDOC;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colDID;
        private DevExpress.XtraReports.ReportGeneration.ReportGenerator reportGenerator1;
    }
}
