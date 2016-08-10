namespace IMS2.UserControls
{
    partial class ucCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCustomers));
            this.grvD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDSC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDBA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCDA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCNM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colADR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPHN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bNew = new DevExpress.XtraBars.BarButtonItem();
            this.bEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bDelete = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
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
            this.colDSC,
            this.colDBA,
            this.colCDA,
            this.colBAL});
            this.grvD.GridControl = this.grd;
            this.grvD.Name = "grvD";
            // 
            // colTDT
            // 
            this.colTDT.Caption = "Transaction Date";
            this.colTDT.FieldName = "TransDate";
            this.colTDT.GroupFormat.FormatString = "d";
            this.colTDT.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTDT.Name = "colTDT";
            this.colTDT.OptionsColumn.AllowEdit = false;
            this.colTDT.OptionsColumn.AllowFocus = false;
            this.colTDT.OptionsColumn.ReadOnly = true;
            this.colTDT.Visible = true;
            this.colTDT.VisibleIndex = 0;
            // 
            // colDSC
            // 
            this.colDSC.Caption = "Reference";
            this.colDSC.FieldName = "Description";
            this.colDSC.Name = "colDSC";
            this.colDSC.OptionsColumn.AllowEdit = false;
            this.colDSC.OptionsColumn.AllowFocus = false;
            this.colDSC.OptionsColumn.ReadOnly = true;
            this.colDSC.Visible = true;
            this.colDSC.VisibleIndex = 1;
            // 
            // colDBA
            // 
            this.colDBA.Caption = "Debit";
            this.colDBA.FieldName = "Debit";
            this.colDBA.Name = "colDBA";
            this.colDBA.OptionsColumn.AllowEdit = false;
            this.colDBA.OptionsColumn.AllowFocus = false;
            this.colDBA.OptionsColumn.ReadOnly = true;
            this.colDBA.Visible = true;
            this.colDBA.VisibleIndex = 2;
            // 
            // colCDA
            // 
            this.colCDA.Caption = "Credit";
            this.colCDA.FieldName = "Credit";
            this.colCDA.Name = "colCDA";
            this.colCDA.OptionsColumn.AllowEdit = false;
            this.colCDA.OptionsColumn.AllowFocus = false;
            this.colCDA.OptionsColumn.ReadOnly = true;
            this.colCDA.Visible = true;
            this.colCDA.VisibleIndex = 3;
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
            this.grd.Size = new System.Drawing.Size(961, 487);
            this.grd.TabIndex = 1;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv,
            this.grvD});
            // 
            // grv
            // 
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCID,
            this.colCNM,
            this.colADR,
            this.colPHN});
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsView.ShowGroupPanel = false;
            // 
            // colCID
            // 
            this.colCID.Caption = "gridColumn1";
            this.colCID.FieldName = "ID";
            this.colCID.Name = "colCID";
            // 
            // colCNM
            // 
            this.colCNM.Caption = "Customer\'s Name";
            this.colCNM.FieldName = "CustomerName";
            this.colCNM.Name = "colCNM";
            this.colCNM.OptionsColumn.AllowEdit = false;
            this.colCNM.OptionsColumn.AllowFocus = false;
            this.colCNM.OptionsColumn.ReadOnly = true;
            this.colCNM.Visible = true;
            this.colCNM.VisibleIndex = 0;
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
            // 
            // colPHN
            // 
            this.colPHN.Caption = "Phone No";
            this.colPHN.FieldName = "Phone";
            this.colPHN.Name = "colPHN";
            this.colPHN.OptionsColumn.AllowEdit = false;
            this.colPHN.OptionsColumn.AllowFocus = false;
            this.colPHN.OptionsColumn.ReadOnly = true;
            this.colPHN.Visible = true;
            this.colPHN.VisibleIndex = 2;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bNew,
            this.bEdit,
            this.bDelete});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(961, 141);
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
            this.bEdit.Caption = "Edit";
            this.bEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("bEdit.Glyph")));
            this.bEdit.Id = 2;
            this.bEdit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bEdit.LargeGlyph")));
            this.bEdit.Name = "bEdit";
            this.bEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bEdit_ItemClick);
            // 
            // bDelete
            // 
            this.bDelete.Caption = "Delete";
            this.bDelete.Glyph = ((System.Drawing.Image)(resources.GetObject("bDelete.Glyph")));
            this.bDelete.Id = 3;
            this.bDelete.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bDelete.LargeGlyph")));
            this.bDelete.Name = "bDelete";
            this.bDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bDelete_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Customers";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bDelete);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Records";
            // 
            // ucCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grd);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "ucCustomers";
            this.Size = new System.Drawing.Size(961, 628);
            ((System.ComponentModel.ISupportInitialize)(this.grvD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bNew;
        private DevExpress.XtraBars.BarButtonItem bEdit;
        private DevExpress.XtraBars.BarButtonItem bDelete;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn colCID;
        private DevExpress.XtraGrid.Columns.GridColumn colCNM;
        private DevExpress.XtraGrid.Columns.GridColumn colADR;
        private DevExpress.XtraGrid.Columns.GridColumn colPHN;
        private DevExpress.XtraGrid.Views.Grid.GridView grvD;
        private DevExpress.XtraGrid.Columns.GridColumn colTDT;
        private DevExpress.XtraGrid.Columns.GridColumn colDSC;
        private DevExpress.XtraGrid.Columns.GridColumn colDBA;
        private DevExpress.XtraGrid.Columns.GridColumn colCDA;
        private DevExpress.XtraGrid.Columns.GridColumn colBAL;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
    }
}
