namespace IMS2.UserControls
{
    partial class ucSuppliers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSuppliers));
            this.grvD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDBR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDCR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSNM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPHN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bNew = new DevExpress.XtraBars.BarButtonItem();
            this.bEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bExport = new DevExpress.XtraBars.BarButtonItem();
            this.bPrints = new DevExpress.XtraBars.BarSubItem();
            this.bSupList = new DevExpress.XtraBars.BarButtonItem();
            this.bDetailReport = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgRecords = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.colCST = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTIN = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grvD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // grvD
            // 
            this.grvD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTDT,
            this.colREF,
            this.colDBR,
            this.colDCR,
            this.colBAL});
            this.grvD.GridControl = this.grd;
            this.grvD.Name = "grvD";
            this.grvD.OptionsView.ShowGroupPanel = false;
            // 
            // colTDT
            // 
            this.colTDT.Caption = "Trans. Date";
            this.colTDT.FieldName = "TransDate";
            this.colTDT.Name = "colTDT";
            this.colTDT.OptionsColumn.AllowEdit = false;
            this.colTDT.OptionsColumn.AllowFocus = false;
            this.colTDT.OptionsColumn.ReadOnly = true;
            this.colTDT.Visible = true;
            this.colTDT.VisibleIndex = 0;
            // 
            // colREF
            // 
            this.colREF.Caption = "Reference";
            this.colREF.FieldName = "Description";
            this.colREF.Name = "colREF";
            this.colREF.OptionsColumn.AllowEdit = false;
            this.colREF.OptionsColumn.AllowFocus = false;
            this.colREF.OptionsColumn.ReadOnly = true;
            this.colREF.Visible = true;
            this.colREF.VisibleIndex = 1;
            // 
            // colDBR
            // 
            this.colDBR.Caption = "Debit";
            this.colDBR.FieldName = "Debit";
            this.colDBR.Name = "colDBR";
            this.colDBR.OptionsColumn.AllowEdit = false;
            this.colDBR.OptionsColumn.AllowFocus = false;
            this.colDBR.OptionsColumn.ReadOnly = true;
            this.colDBR.Visible = true;
            this.colDBR.VisibleIndex = 2;
            // 
            // colDCR
            // 
            this.colDCR.Caption = "Credit";
            this.colDCR.FieldName = "Credit";
            this.colDCR.Name = "colDCR";
            this.colDCR.OptionsColumn.AllowEdit = false;
            this.colDCR.OptionsColumn.AllowFocus = false;
            this.colDCR.OptionsColumn.ReadOnly = true;
            this.colDCR.Visible = true;
            this.colDCR.VisibleIndex = 3;
            // 
            // colBAL
            // 
            this.colBAL.Caption = "Balance";
            this.colBAL.FieldName = "Balance";
            this.colBAL.Name = "colBAL";
            this.colBAL.OptionsColumn.AllowEdit = false;
            this.colBAL.OptionsColumn.AllowFocus = false;
            this.colBAL.OptionsColumn.ReadOnly = true;
            this.colBAL.Visible = true;
            this.colBAL.VisibleIndex = 4;
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.grvD;
            gridLevelNode1.RelationName = "Level1";
            this.grd.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grd.Location = new System.Drawing.Point(0, 141);
            this.grd.MainView = this.grv;
            this.grd.MenuManager = this.ribbonControl1;
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(819, 342);
            this.grd.TabIndex = 1;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv,
            this.grvD});
            // 
            // grv
            // 
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSID,
            this.colSNM,
            this.colADR,
            this.colPHN,
            this.colCST,
            this.colTIN});
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsView.ShowGroupPanel = false;
            // 
            // colSID
            // 
            this.colSID.Caption = "ID";
            this.colSID.FieldName = "ID";
            this.colSID.Name = "colSID";
            this.colSID.OptionsColumn.AllowEdit = false;
            this.colSID.OptionsColumn.AllowFocus = false;
            this.colSID.OptionsColumn.ReadOnly = true;
            // 
            // colSNM
            // 
            this.colSNM.Caption = "Supplier Name";
            this.colSNM.FieldName = "SupplierName";
            this.colSNM.Name = "colSNM";
            this.colSNM.OptionsColumn.AllowEdit = false;
            this.colSNM.OptionsColumn.AllowFocus = false;
            this.colSNM.OptionsColumn.ReadOnly = true;
            this.colSNM.Visible = true;
            this.colSNM.VisibleIndex = 0;
            this.colSNM.Width = 232;
            // 
            // colADR
            // 
            this.colADR.Caption = "Address";
            this.colADR.FieldName = "Address";
            this.colADR.Name = "colADR";
            this.colADR.OptionsColumn.AllowEdit = false;
            this.colADR.OptionsColumn.AllowFocus = false;
            this.colADR.OptionsColumn.ReadOnly = true;
            this.colADR.Visible = true;
            this.colADR.VisibleIndex = 1;
            this.colADR.Width = 319;
            // 
            // colPHN
            // 
            this.colPHN.Caption = "Phone";
            this.colPHN.FieldName = "Phone";
            this.colPHN.Name = "colPHN";
            this.colPHN.OptionsColumn.AllowEdit = false;
            this.colPHN.OptionsColumn.AllowFocus = false;
            this.colPHN.OptionsColumn.ReadOnly = true;
            this.colPHN.Visible = true;
            this.colPHN.VisibleIndex = 2;
            this.colPHN.Width = 155;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bNew,
            this.bEdit,
            this.bDelete,
            this.bExport,
            this.bPrints,
            this.bSupList,
            this.bDetailReport});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 9;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(819, 141);
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
            // bDelete
            // 
            this.bDelete.Caption = "&Delete";
            this.bDelete.Glyph = ((System.Drawing.Image)(resources.GetObject("bDelete.Glyph")));
            this.bDelete.Id = 3;
            this.bDelete.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bDelete.LargeGlyph")));
            this.bDelete.Name = "bDelete";
            this.bDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bDelete_ItemClick);
            // 
            // bExport
            // 
            this.bExport.Caption = "E&xport";
            this.bExport.Glyph = ((System.Drawing.Image)(resources.GetObject("bExport.Glyph")));
            this.bExport.Id = 5;
            this.bExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bExport.LargeGlyph")));
            this.bExport.Name = "bExport";
            this.bExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bExport_ItemClick);
            // 
            // bPrints
            // 
            this.bPrints.Caption = "Print";
            this.bPrints.Glyph = ((System.Drawing.Image)(resources.GetObject("bPrints.Glyph")));
            this.bPrints.Id = 6;
            this.bPrints.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bPrints.LargeGlyph")));
            this.bPrints.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bSupList),
            new DevExpress.XtraBars.LinkPersistInfo(this.bDetailReport)});
            this.bPrints.Name = "bPrints";
            // 
            // bSupList
            // 
            this.bSupList.Caption = "Supplier List";
            this.bSupList.Glyph = ((System.Drawing.Image)(resources.GetObject("bSupList.Glyph")));
            this.bSupList.Id = 7;
            this.bSupList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bSupList.LargeGlyph")));
            this.bSupList.Name = "bSupList";
            this.bSupList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bSupList_ItemClick);
            // 
            // bDetailReport
            // 
            this.bDetailReport.Caption = "Detail Report";
            this.bDetailReport.Glyph = ((System.Drawing.Image)(resources.GetObject("bDetailReport.Glyph")));
            this.bDetailReport.Id = 8;
            this.bDetailReport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bDetailReport.LargeGlyph")));
            this.bDetailReport.Name = "bDetailReport";
            this.bDetailReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bDetailReport_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgRecords,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Suppliers";
            // 
            // rpgRecords
            // 
            this.rpgRecords.ItemLinks.Add(this.bNew);
            this.rpgRecords.ItemLinks.Add(this.bEdit);
            this.rpgRecords.ItemLinks.Add(this.bDelete);
            this.rpgRecords.Name = "rpgRecords";
            this.rpgRecords.ShowCaptionButton = false;
            this.rpgRecords.Text = "Data";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bPrints);
            this.ribbonPageGroup2.ItemLinks.Add(this.bExport);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Print";
            // 
            // colCST
            // 
            this.colCST.Caption = "CST No";
            this.colCST.FieldName = "CST";
            this.colCST.Name = "colCST";
            this.colCST.OptionsColumn.AllowEdit = false;
            this.colCST.OptionsColumn.AllowFocus = false;
            this.colCST.OptionsColumn.ReadOnly = true;
            this.colCST.Visible = true;
            this.colCST.VisibleIndex = 3;
            this.colCST.Width = 175;
            // 
            // colTIN
            // 
            this.colTIN.Caption = "TIN No";
            this.colTIN.FieldName = "TIN";
            this.colTIN.Name = "colTIN";
            this.colTIN.OptionsColumn.AllowEdit = false;
            this.colTIN.OptionsColumn.AllowFocus = false;
            this.colTIN.OptionsColumn.ReadOnly = true;
            this.colTIN.Visible = true;
            this.colTIN.VisibleIndex = 4;
            this.colTIN.Width = 197;
            // 
            // ucSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grd);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "ucSuppliers";
            this.Size = new System.Drawing.Size(819, 483);
            ((System.ComponentModel.ISupportInitialize)(this.grvD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem bNew;
        private DevExpress.XtraBars.BarButtonItem bEdit;
        private DevExpress.XtraBars.BarButtonItem bDelete;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgRecords;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Views.Grid.GridView grvD;
        private DevExpress.XtraGrid.Columns.GridColumn colSID;
        private DevExpress.XtraGrid.Columns.GridColumn colSNM;
        private DevExpress.XtraGrid.Columns.GridColumn colADR;
        private DevExpress.XtraGrid.Columns.GridColumn colPHN;
        private DevExpress.XtraGrid.Columns.GridColumn colTDT;
        private DevExpress.XtraGrid.Columns.GridColumn colREF;
        private DevExpress.XtraGrid.Columns.GridColumn colDBR;
        private DevExpress.XtraGrid.Columns.GridColumn colDCR;
        private DevExpress.XtraGrid.Columns.GridColumn colBAL;
        private DevExpress.XtraBars.BarButtonItem bExport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarSubItem bPrints;
        private DevExpress.XtraBars.BarButtonItem bSupList;
        private DevExpress.XtraBars.BarButtonItem bDetailReport;
        private DevExpress.XtraGrid.Columns.GridColumn colCST;
        private DevExpress.XtraGrid.Columns.GridColumn colTIN;
    }
}
