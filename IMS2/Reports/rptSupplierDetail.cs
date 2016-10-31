using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rptSupplierDetail
/// </summary>
public class rptSupplierDetail : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRPictureBox xrPictureBox1;
    private XRLabel xrLabel1;
    private XRPictureBox xrPictureBox2;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    public XRLabel lbHDR;
    private PageHeaderBand PageHeader;
    public GroupHeaderBand GroupHeader1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    public XRTableCell lbSNM;
    public XRTableCell lbADR;
    public XRTableCell lbPHN;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell1;
    public XRTableCell lbTDT;
    public XRTableCell lbREF;
    public XRTableCell lbDBT;
    public XRTableCell lbCDT;
    public XRTableCell lbBAL;
    private XRTableCell xrTableCell11;
    private GroupFooterBand GroupFooter1;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell15;
    public XRTableCell lbTDR;
    public XRTableCell lbTCR;
    public XRTableCell lbTBL;
    private ReportFooterBand ReportFooter;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell12;
    public XRTableCell lbGDR;
    public XRTableCell lbGCR;
    public XRTableCell lbGBL;
    private XRControlStyle ProductData;
    private XRControlStyle OddStyle;
    private XRControlStyle GroupHeader;
    private XRControlStyle ProductHeader;
    private XRControlStyle SupplierTitle;
    private XRControlStyle EvenStyle;
    private XRControlStyle SupplierInfo;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rptSupplierDetail()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

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

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptSupplierDetail));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbTDT = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbREF = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbDBT = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbCDT = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbBAL = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbHDR = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbSNM = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbADR = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbPHN = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbTDR = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbTCR = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbTBL = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbGDR = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbGCR = new DevExpress.XtraReports.UI.XRTableCell();
            this.lbGBL = new DevExpress.XtraReports.UI.XRTableCell();
            this.ProductData = new DevExpress.XtraReports.UI.XRControlStyle();
            this.OddStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupHeader = new DevExpress.XtraReports.UI.XRControlStyle();
            this.ProductHeader = new DevExpress.XtraReports.UI.XRControlStyle();
            this.SupplierTitle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.EvenStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.SupplierInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.Detail.EvenStyleName = "EvenStyle";
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.OddStyleName = "OddStyle";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable3
            // 
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(18.70832F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(708.2916F, 25F);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.lbTDT,
            this.lbREF,
            this.lbDBT,
            this.lbCDT,
            this.lbBAL});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.xrTableCell1.StylePriority.UsePadding = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell1.Summary = xrSummary1;
            this.xrTableCell1.Text = "Sl. No";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell1.Weight = 0.41550688732533958D;
            // 
            // lbTDT
            // 
            this.lbTDT.Name = "lbTDT";
            this.lbTDT.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.lbTDT.StylePriority.UsePadding = false;
            this.lbTDT.StylePriority.UseTextAlignment = false;
            this.lbTDT.Text = "lbTDT";
            this.lbTDT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lbTDT.Weight = 0.84068504866583649D;
            // 
            // lbREF
            // 
            this.lbREF.Name = "lbREF";
            this.lbREF.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.lbREF.StylePriority.UsePadding = false;
            this.lbREF.StylePriority.UseTextAlignment = false;
            this.lbREF.Text = "lbREF";
            this.lbREF.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lbREF.Weight = 2.2024824746976424D;
            // 
            // lbDBT
            // 
            this.lbDBT.Name = "lbDBT";
            this.lbDBT.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.lbDBT.StylePriority.UsePadding = false;
            this.lbDBT.StylePriority.UseTextAlignment = false;
            this.lbDBT.Text = "lbDBT";
            this.lbDBT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lbDBT.Weight = 0.84710900371833731D;
            // 
            // lbCDT
            // 
            this.lbCDT.Name = "lbCDT";
            this.lbCDT.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.lbCDT.StylePriority.UsePadding = false;
            this.lbCDT.StylePriority.UseTextAlignment = false;
            this.lbCDT.Text = "lbCDT";
            this.lbCDT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lbCDT.Weight = 0.84710822816715714D;
            // 
            // lbBAL
            // 
            this.lbBAL.Name = "lbBAL";
            this.lbBAL.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.lbBAL.StylePriority.UsePadding = false;
            this.lbBAL.StylePriority.UseTextAlignment = false;
            this.lbBAL.Text = "lbBAL";
            this.lbBAL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.lbBAL.Weight = 0.84710835742568713D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 50F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 50F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1,
            this.xrLabel1,
            this.xrPictureBox2,
            this.xrLabel2,
            this.xrLabel3,
            this.lbHDR});
            this.ReportHeader.HeightF = 100F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(100F, 100F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(100F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(527F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "KV MART";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPictureBox2
            // 
            this.xrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(627F, 0F);
            this.xrPictureBox2.Name = "xrPictureBox2";
            this.xrPictureBox2.SizeF = new System.Drawing.SizeF(100F, 100F);
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(100F, 23F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(527.0001F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Chanmari, Aizawl";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(100F, 46F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(526.9999F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Phone No: 0389 2347341";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbHDR
            // 
            this.lbHDR.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbHDR.LocationFloat = new DevExpress.Utils.PointFloat(100F, 68.99999F);
            this.lbHDR.Name = "lbHDR";
            this.lbHDR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbHDR.SizeF = new System.Drawing.SizeF(526.9999F, 31.00001F);
            this.lbHDR.StylePriority.UseFont = false;
            this.lbHDR.StylePriority.UseTextAlignment = false;
            this.lbHDR.Text = "SUPLIER DETAIL REPORT";
            this.lbHDR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.PageHeader.HeightF = 25F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.StyleName = "ProductHeader";
            // 
            // xrTable2
            // 
            this.xrTable2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(25.01666F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(701.9833F, 25F);
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Text = "Sl. No";
            this.xrTableCell10.Weight = 0.36586072753167226D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "Trans. Date";
            this.xrTableCell5.Weight = 0.84948990653902845D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "Reference";
            this.xrTableCell6.Weight = 2.2255508053296102D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Text = "Debit";
            this.xrTableCell7.Weight = 0.85598107897292719D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "Credit";
            this.xrTableCell8.Weight = 0.85598107897292719D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Text = "Balance";
            this.xrTableCell9.Weight = 0.85598094836057992D;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.GroupHeader1.HeightF = 25F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.StyleName = "SupplierInfo";
            // 
            // xrTable1
            // 
            this.xrTable1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.xrTable1.ForeColor = System.Drawing.Color.LightCyan;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(726.9999F, 25F);
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseForeColor = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell11,
            this.lbSNM,
            this.lbADR,
            this.lbPHN});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.Text = "Supplier:";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell11.Weight = 0.42883144345113866D;
            // 
            // lbSNM
            // 
            this.lbSNM.Name = "lbSNM";
            this.lbSNM.StylePriority.UseTextAlignment = false;
            this.lbSNM.Text = "Supplier Name";
            this.lbSNM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lbSNM.Weight = 1.4906839238065213D;
            // 
            // lbADR
            // 
            this.lbADR.Name = "lbADR";
            this.lbADR.StylePriority.UseTextAlignment = false;
            this.lbADR.Text = "Address";
            this.lbADR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lbADR.Weight = 2.0488478186710721D;
            // 
            // lbPHN
            // 
            this.lbPHN.Name = "lbPHN";
            this.lbPHN.StylePriority.UseTextAlignment = false;
            this.lbPHN.Text = "Phone";
            this.lbPHN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lbPHN.Weight = 0.68477753946736875D;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
            this.GroupFooter1.HeightF = 25F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.StyleName = "SupplierInfo";
            // 
            // xrTable4
            // 
            this.xrTable4.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTable4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable4.SizeF = new System.Drawing.SizeF(727F, 25F);
            this.xrTable4.StylePriority.UseBorders = false;
            this.xrTable4.StylePriority.UseFont = false;
            this.xrTable4.StylePriority.UsePadding = false;
            this.xrTable4.StylePriority.UseTextAlignment = false;
            this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell15,
            this.lbTDR,
            this.lbTCR,
            this.lbTBL});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Text = "SUB-TOTAL: ";
            this.xrTableCell15.Weight = 4.2708331298828126D;
            // 
            // lbTDR
            // 
            this.lbTDR.Name = "lbTDR";
            this.lbTDR.Text = "lbTDR";
            this.lbTDR.Weight = 1D;
            // 
            // lbTCR
            // 
            this.lbTCR.Name = "lbTCR";
            this.lbTCR.Text = "lbTCR";
            this.lbTCR.Weight = 1D;
            // 
            // lbTBL
            // 
            this.lbTBL.Name = "lbTBL";
            this.lbTBL.Text = "lbTBL";
            this.lbTBL.Weight = 1D;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable5});
            this.ReportFooter.HeightF = 25F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.StyleName = "ProductHeader";
            // 
            // xrTable5
            // 
            this.xrTable5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
            this.xrTable5.SizeF = new System.Drawing.SizeF(727F, 25F);
            this.xrTable5.StylePriority.UseFont = false;
            this.xrTable5.StylePriority.UsePadding = false;
            this.xrTable5.StylePriority.UseTextAlignment = false;
            this.xrTable5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell12,
            this.lbGDR,
            this.lbGCR,
            this.lbGBL});
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Text = "GRAND-TOTAL: ";
            this.xrTableCell12.Weight = 4.2708331298828126D;
            // 
            // lbGDR
            // 
            this.lbGDR.Name = "lbGDR";
            this.lbGDR.Text = "lbTDR";
            this.lbGDR.Weight = 1D;
            // 
            // lbGCR
            // 
            this.lbGCR.Name = "lbGCR";
            this.lbGCR.Text = "lbTCR";
            this.lbGCR.Weight = 1D;
            // 
            // lbGBL
            // 
            this.lbGBL.Name = "lbGBL";
            this.lbGBL.Text = "lbTBL";
            this.lbGBL.Weight = 1D;
            // 
            // ProductData
            // 
            this.ProductData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.ProductData.BorderColor = System.Drawing.Color.White;
            this.ProductData.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.ProductData.BorderWidth = 1F;
            this.ProductData.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ProductData.ForeColor = System.Drawing.Color.Black;
            this.ProductData.Name = "ProductData";
            // 
            // OddStyle
            // 
            this.OddStyle.BackColor = System.Drawing.Color.Transparent;
            this.OddStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(205)))), ((int)(((byte)(162)))));
            this.OddStyle.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.OddStyle.BorderWidth = 1F;
            this.OddStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.OddStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OddStyle.Name = "OddStyle";
            // 
            // GroupHeader
            // 
            this.GroupHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.GroupHeader.BorderColor = System.Drawing.Color.White;
            this.GroupHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.GroupHeader.BorderWidth = 1F;
            this.GroupHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GroupHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(139)))), ((int)(((byte)(139)))));
            this.GroupHeader.Name = "GroupHeader";
            // 
            // ProductHeader
            // 
            this.ProductHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(132)))), ((int)(((byte)(213)))));
            this.ProductHeader.BorderColor = System.Drawing.Color.White;
            this.ProductHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.ProductHeader.BorderWidth = 1F;
            this.ProductHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ProductHeader.ForeColor = System.Drawing.Color.White;
            this.ProductHeader.Name = "ProductHeader";
            // 
            // SupplierTitle
            // 
            this.SupplierTitle.BackColor = System.Drawing.Color.Transparent;
            this.SupplierTitle.BorderColor = System.Drawing.Color.Empty;
            this.SupplierTitle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.SupplierTitle.BorderWidth = 1F;
            this.SupplierTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.SupplierTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.SupplierTitle.Name = "SupplierTitle";
            // 
            // EvenStyle
            // 
            this.EvenStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(196)))));
            this.EvenStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(205)))), ((int)(((byte)(162)))));
            this.EvenStyle.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.EvenStyle.BorderWidth = 1F;
            this.EvenStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.EvenStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EvenStyle.Name = "EvenStyle";
            // 
            // SupplierInfo
            // 
            this.SupplierInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(132)))), ((int)(((byte)(213)))));
            this.SupplierInfo.BorderColor = System.Drawing.Color.White;
            this.SupplierInfo.BorderWidth = 1F;
            this.SupplierInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.SupplierInfo.ForeColor = System.Drawing.Color.White;
            this.SupplierInfo.Name = "SupplierInfo";
            this.SupplierInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(7, 0, 0, 0, 100F);
            // 
            // rptSupplierDetail
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.GroupHeader1,
            this.GroupFooter1,
            this.ReportFooter});
            this.DisplayName = "Supplier Detail Report";
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.ProductData,
            this.OddStyle,
            this.GroupHeader,
            this.ProductHeader,
            this.SupplierTitle,
            this.EvenStyle,
            this.SupplierInfo});
            this.Version = "15.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
