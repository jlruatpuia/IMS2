namespace IMS2.Forms
{
    partial class frmDateRangeSelector
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dtpON = new DevExpress.XtraEditors.DateEdit();
            this.dtpTO = new DevExpress.XtraEditors.DateEdit();
            this.dtpFR = new DevExpress.XtraEditors.DateEdit();
            this.txtINV = new DevExpress.XtraEditors.TextEdit();
            this.rdoSelect = new DevExpress.XtraEditors.RadioGroup();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcINV = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcFR = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcTO = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcON = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpON.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpON.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTO.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFR.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtINV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoSelect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcINV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcFR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcON)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dtpON);
            this.layoutControl1.Controls.Add(this.dtpTO);
            this.layoutControl1.Controls.Add(this.dtpFR);
            this.layoutControl1.Controls.Add(this.txtINV);
            this.layoutControl1.Controls.Add(this.rdoSelect);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnOK);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(807, 157, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(358, 170);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dtpON
            // 
            this.dtpON.EditValue = null;
            this.dtpON.Location = new System.Drawing.Point(70, 64);
            this.dtpON.Name = "dtpON";
            this.dtpON.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpON.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpON.Size = new System.Drawing.Size(276, 20);
            this.dtpON.StyleController = this.layoutControl1;
            this.dtpON.TabIndex = 14;
            // 
            // dtpTO
            // 
            this.dtpTO.EditValue = null;
            this.dtpTO.Location = new System.Drawing.Point(70, 112);
            this.dtpTO.Name = "dtpTO";
            this.dtpTO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTO.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTO.Size = new System.Drawing.Size(276, 20);
            this.dtpTO.StyleController = this.layoutControl1;
            this.dtpTO.TabIndex = 13;
            // 
            // dtpFR
            // 
            this.dtpFR.EditValue = null;
            this.dtpFR.Location = new System.Drawing.Point(70, 88);
            this.dtpFR.Name = "dtpFR";
            this.dtpFR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFR.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFR.Size = new System.Drawing.Size(276, 20);
            this.dtpFR.StyleController = this.layoutControl1;
            this.dtpFR.TabIndex = 12;
            // 
            // txtINV
            // 
            this.txtINV.Location = new System.Drawing.Point(70, 40);
            this.txtINV.Name = "txtINV";
            this.txtINV.Size = new System.Drawing.Size(276, 20);
            this.txtINV.StyleController = this.layoutControl1;
            this.txtINV.TabIndex = 11;
            // 
            // rdoSelect
            // 
            this.rdoSelect.Location = new System.Drawing.Point(70, 12);
            this.rdoSelect.Name = "rdoSelect";
            this.rdoSelect.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rdoSelect.Properties.Appearance.Options.UseBackColor = true;
            this.rdoSelect.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rdoSelect.Properties.Columns = 3;
            this.rdoSelect.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Date On"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Date Between"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Invoice No")});
            this.rdoSelect.Size = new System.Drawing.Size(276, 24);
            this.rdoSelect.StyleController = this.layoutControl1;
            this.rdoSelect.TabIndex = 10;
            this.rdoSelect.SelectedIndexChanged += new System.EventHandler(this.rdoSelect_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(244, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 22);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(137, 136);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(93, 22);
            this.btnOK.StyleController = this.layoutControl1;
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.lcINV,
            this.lcFR,
            this.lcTO,
            this.lcON});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(358, 170);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnOK;
            this.layoutControlItem5.Location = new System.Drawing.Point(125, 124);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(97, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnCancel;
            this.layoutControlItem6.Location = new System.Drawing.Point(232, 124);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(106, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(222, 124);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(10, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 124);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(125, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.rdoSelect;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(338, 28);
            this.layoutControlItem1.Text = "By:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(55, 13);
            // 
            // lcINV
            // 
            this.lcINV.Control = this.txtINV;
            this.lcINV.Location = new System.Drawing.Point(0, 28);
            this.lcINV.Name = "lcINV";
            this.lcINV.Size = new System.Drawing.Size(338, 24);
            this.lcINV.Text = "Invoice No:";
            this.lcINV.TextSize = new System.Drawing.Size(55, 13);
            this.lcINV.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lcFR
            // 
            this.lcFR.Control = this.dtpFR;
            this.lcFR.Location = new System.Drawing.Point(0, 76);
            this.lcFR.Name = "lcFR";
            this.lcFR.Size = new System.Drawing.Size(338, 24);
            this.lcFR.Text = "From:";
            this.lcFR.TextSize = new System.Drawing.Size(55, 13);
            this.lcFR.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lcTO
            // 
            this.lcTO.Control = this.dtpTO;
            this.lcTO.Location = new System.Drawing.Point(0, 100);
            this.lcTO.Name = "lcTO";
            this.lcTO.Size = new System.Drawing.Size(338, 24);
            this.lcTO.Text = "To:";
            this.lcTO.TextSize = new System.Drawing.Size(55, 13);
            this.lcTO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lcON
            // 
            this.lcON.Control = this.dtpON;
            this.lcON.Location = new System.Drawing.Point(0, 52);
            this.lcON.Name = "lcON";
            this.lcON.Size = new System.Drawing.Size(338, 24);
            this.lcON.Text = "On:";
            this.lcON.TextSize = new System.Drawing.Size(55, 13);
            // 
            // frmDateRangeSelector
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(358, 170);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDateRangeSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpON.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpON.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTO.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFR.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtINV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcINV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcFR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcTO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcON)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.RadioGroup rdoSelect;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit dtpON;
        private DevExpress.XtraEditors.DateEdit dtpTO;
        private DevExpress.XtraEditors.DateEdit dtpFR;
        private DevExpress.XtraEditors.TextEdit txtINV;
        private DevExpress.XtraLayout.LayoutControlItem lcINV;
        private DevExpress.XtraLayout.LayoutControlItem lcFR;
        private DevExpress.XtraLayout.LayoutControlItem lcTO;
        private DevExpress.XtraLayout.LayoutControlItem lcON;
    }
}