using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;


public partial class rptAttendanceDetail : GrapeCity.ActiveReports.SectionReport
{
    public rptAttendanceDetail()
    {
        InitializeComponent();
    }

    // Form overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
        base.Dispose(disposing);
    }

    // NOTE: The following procedure is required by the ActiveReports Designer
    // It can be modified using the ActiveReports Designer.
    // Do not modify it using the code editor.
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptAttendanceDetail));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.Shape1 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.d31Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d30Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d29Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d26Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.d18Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d15Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d28Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d27Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d25Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d22Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d24Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d23Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d21Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d20Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d19Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d17Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d16Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d14Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d13Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d12Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d11Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d10Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d9Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d8Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d7Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d6Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d5Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d4Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d3Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d2Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d1Data = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblSr = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line9 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line7 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line8 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line10 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line11 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line12 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line13 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line18 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line19 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line38 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line39 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line40 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line41 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line42 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line43 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line44 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line45 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line46 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line47 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line48 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line49 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line50 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line51 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line52 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line53 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line54 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line55 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line56 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line57 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line58 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line59 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.Shape3 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.lbl2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Shape2 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtHeaderCompany = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Picture = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.txtHeaderArabic = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtPeriod = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line14 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.d1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line26 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.d11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line27 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.d12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d16 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d17 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d18 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d19 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d20 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d21 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d23 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d24 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d26 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d22 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d25 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d27 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d28 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d29 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d30 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line84 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line85 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line86 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line87 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line88 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line89 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.d31 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.d15 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line5 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line6 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line15 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line16 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line17 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line20 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line21 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line22 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line23 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line24 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line25 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line28 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line29 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line30 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line31 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line32 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line33 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line34 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line35 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line36 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line37 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.Label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label15 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label16 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label17 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label18 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label19 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label43 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label44 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            ((System.ComponentModel.ISupportInitialize)(this.d31Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d30Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d29Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d26Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d18Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d15Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d28Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d27Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d25Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d22Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d24Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d23Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d21Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d20Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d19Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d17Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d16Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d14Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d13Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d12Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d11Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d10Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d9Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d8Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d7Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d6Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d5Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d4Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d3Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d2Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d1Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderArabic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape1,
            this.d31Data,
            this.d30Data,
            this.d29Data,
            this.d26Data,
            this.TextBox2,
            this.d18Data,
            this.d15Data,
            this.d28Data,
            this.d27Data,
            this.d25Data,
            this.d22Data,
            this.d24Data,
            this.d23Data,
            this.d21Data,
            this.d20Data,
            this.d19Data,
            this.d17Data,
            this.d16Data,
            this.d14Data,
            this.d13Data,
            this.d12Data,
            this.d11Data,
            this.d10Data,
            this.d9Data,
            this.d8Data,
            this.d7Data,
            this.d6Data,
            this.d5Data,
            this.d4Data,
            this.d3Data,
            this.d2Data,
            this.d1Data,
            this.lblSr,
            this.Line9,
            this.Line,
            this.Line2,
            this.Line7,
            this.Line8,
            this.Line10,
            this.Line11,
            this.Line12,
            this.Line13,
            this.Line18,
            this.Line19,
            this.Line38,
            this.Line39,
            this.Line40,
            this.Line41,
            this.Line42,
            this.Line43,
            this.Line44,
            this.Line45,
            this.Line46,
            this.Line47,
            this.Line48,
            this.Line49,
            this.Line50,
            this.Line51,
            this.Line52,
            this.Line53,
            this.Line54,
            this.Line55,
            this.Line56,
            this.Line57,
            this.Line58,
            this.Line59});
            this.Detail.Height = 0.2076389F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            // 
            // Shape1
            // 
            this.Shape1.Height = 0.171875F;
            this.Shape1.Left = 0F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 0F;
            this.Shape1.Width = 9.34375F;
            // 
            // d31Data
            // 
            this.d31Data.DataField = "d31";
            this.d31Data.Height = 0.2F;
            this.d31Data.HyperLink = null;
            this.d31Data.Left = 9.125F;
            this.d31Data.Name = "d31Data";
            this.d31Data.ShrinkToFit = true;
            this.d31Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d31Data.Text = " ";
            this.d31Data.Top = -0.016F;
            this.d31Data.Width = 0.21875F;
            // 
            // d30Data
            // 
            this.d30Data.DataField = "d30";
            this.d30Data.Height = 0.2F;
            this.d30Data.HyperLink = null;
            this.d30Data.Left = 8.906F;
            this.d30Data.Name = "d30Data";
            this.d30Data.ShrinkToFit = true;
            this.d30Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d30Data.Text = " ";
            this.d30Data.Top = -0.016F;
            this.d30Data.Width = 0.21875F;
            // 
            // d29Data
            // 
            this.d29Data.DataField = "d29";
            this.d29Data.Height = 0.2F;
            this.d29Data.HyperLink = null;
            this.d29Data.Left = 8.688F;
            this.d29Data.Name = "d29Data";
            this.d29Data.ShrinkToFit = true;
            this.d29Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d29Data.Text = " ";
            this.d29Data.Top = -0.016F;
            this.d29Data.Width = 0.21875F;
            // 
            // d26Data
            // 
            this.d26Data.DataField = "d26";
            this.d26Data.Height = 0.2F;
            this.d26Data.HyperLink = null;
            this.d26Data.Left = 8.031F;
            this.d26Data.Name = "d26Data";
            this.d26Data.ShrinkToFit = true;
            this.d26Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d26Data.Text = " ";
            this.d26Data.Top = -0.016F;
            this.d26Data.Width = 0.21875F;
            // 
            // TextBox2
            // 
            this.TextBox2.DataField = "EmployeeName";
            this.TextBox2.Height = 0.2F;
            this.TextBox2.Left = 0.516F;
            this.TextBox2.MultiLine = false;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: normal; tex" +
    "t-align: left; vertical-align: bottom; white-space: nowrap; ddo-char-set: 1";
            this.TextBox2.Text = "0";
            this.TextBox2.Top = -0.016F;
            this.TextBox2.Width = 2.03125F;
            // 
            // d18Data
            // 
            this.d18Data.DataField = "d18";
            this.d18Data.Height = 0.2F;
            this.d18Data.HyperLink = null;
            this.d18Data.Left = 6.281001F;
            this.d18Data.Name = "d18Data";
            this.d18Data.ShrinkToFit = true;
            this.d18Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d18Data.Text = " ";
            this.d18Data.Top = -0.016F;
            this.d18Data.Width = 0.21875F;
            // 
            // d15Data
            // 
            this.d15Data.DataField = "d15";
            this.d15Data.Height = 0.2F;
            this.d15Data.HyperLink = null;
            this.d15Data.Left = 5.625F;
            this.d15Data.Name = "d15Data";
            this.d15Data.ShrinkToFit = true;
            this.d15Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d15Data.Text = " ";
            this.d15Data.Top = -0.016F;
            this.d15Data.Width = 0.21875F;
            // 
            // d28Data
            // 
            this.d28Data.DataField = "d28";
            this.d28Data.Height = 0.2F;
            this.d28Data.HyperLink = null;
            this.d28Data.Left = 8.469F;
            this.d28Data.Name = "d28Data";
            this.d28Data.ShrinkToFit = true;
            this.d28Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d28Data.Text = " ";
            this.d28Data.Top = -0.016F;
            this.d28Data.Width = 0.21875F;
            // 
            // d27Data
            // 
            this.d27Data.DataField = "d27";
            this.d27Data.Height = 0.2F;
            this.d27Data.HyperLink = null;
            this.d27Data.Left = 8.25F;
            this.d27Data.Name = "d27Data";
            this.d27Data.ShrinkToFit = true;
            this.d27Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d27Data.Text = " ";
            this.d27Data.Top = -0.016F;
            this.d27Data.Width = 0.21875F;
            // 
            // d25Data
            // 
            this.d25Data.DataField = "d25";
            this.d25Data.Height = 0.2F;
            this.d25Data.HyperLink = null;
            this.d25Data.Left = 7.813F;
            this.d25Data.Name = "d25Data";
            this.d25Data.ShrinkToFit = true;
            this.d25Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d25Data.Text = " ";
            this.d25Data.Top = -0.016F;
            this.d25Data.Width = 0.2187495F;
            // 
            // d22Data
            // 
            this.d22Data.DataField = "d22";
            this.d22Data.Height = 0.2F;
            this.d22Data.HyperLink = null;
            this.d22Data.Left = 7.156F;
            this.d22Data.Name = "d22Data";
            this.d22Data.ShrinkToFit = true;
            this.d22Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d22Data.Text = " ";
            this.d22Data.Top = -0.016F;
            this.d22Data.Width = 0.21875F;
            // 
            // d24Data
            // 
            this.d24Data.DataField = "d24";
            this.d24Data.Height = 0.2F;
            this.d24Data.HyperLink = null;
            this.d24Data.Left = 7.594F;
            this.d24Data.Name = "d24Data";
            this.d24Data.ShrinkToFit = true;
            this.d24Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d24Data.Text = " ";
            this.d24Data.Top = -0.016F;
            this.d24Data.Width = 0.21875F;
            // 
            // d23Data
            // 
            this.d23Data.DataField = "d23";
            this.d23Data.Height = 0.2F;
            this.d23Data.HyperLink = null;
            this.d23Data.Left = 7.375F;
            this.d23Data.Name = "d23Data";
            this.d23Data.ShrinkToFit = true;
            this.d23Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d23Data.Text = " ";
            this.d23Data.Top = -0.016F;
            this.d23Data.Width = 0.21875F;
            // 
            // d21Data
            // 
            this.d21Data.DataField = "d21";
            this.d21Data.Height = 0.2F;
            this.d21Data.HyperLink = null;
            this.d21Data.Left = 6.938001F;
            this.d21Data.Name = "d21Data";
            this.d21Data.ShrinkToFit = true;
            this.d21Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d21Data.Text = " ";
            this.d21Data.Top = -0.016F;
            this.d21Data.Width = 0.21875F;
            // 
            // d20Data
            // 
            this.d20Data.DataField = "d20";
            this.d20Data.Height = 0.2F;
            this.d20Data.HyperLink = null;
            this.d20Data.Left = 6.718999F;
            this.d20Data.Name = "d20Data";
            this.d20Data.ShrinkToFit = true;
            this.d20Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d20Data.Text = " ";
            this.d20Data.Top = -0.016F;
            this.d20Data.Width = 0.21875F;
            // 
            // d19Data
            // 
            this.d19Data.DataField = "d19";
            this.d19Data.Height = 0.2F;
            this.d19Data.HyperLink = null;
            this.d19Data.Left = 6.5F;
            this.d19Data.Name = "d19Data";
            this.d19Data.ShrinkToFit = true;
            this.d19Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d19Data.Text = " ";
            this.d19Data.Top = -0.016F;
            this.d19Data.Width = 0.21875F;
            // 
            // d17Data
            // 
            this.d17Data.DataField = "d17";
            this.d17Data.Height = 0.2F;
            this.d17Data.HyperLink = null;
            this.d17Data.Left = 6.063001F;
            this.d17Data.Name = "d17Data";
            this.d17Data.ShrinkToFit = true;
            this.d17Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d17Data.Text = " ";
            this.d17Data.Top = -0.016F;
            this.d17Data.Width = 0.21875F;
            // 
            // d16Data
            // 
            this.d16Data.DataField = "d16";
            this.d16Data.Height = 0.2F;
            this.d16Data.HyperLink = null;
            this.d16Data.Left = 5.843999F;
            this.d16Data.Name = "d16Data";
            this.d16Data.ShrinkToFit = true;
            this.d16Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d16Data.Text = " ";
            this.d16Data.Top = -0.016F;
            this.d16Data.Width = 0.21875F;
            // 
            // d14Data
            // 
            this.d14Data.DataField = "d14";
            this.d14Data.Height = 0.2F;
            this.d14Data.HyperLink = null;
            this.d14Data.Left = 5.406F;
            this.d14Data.Name = "d14Data";
            this.d14Data.ShrinkToFit = true;
            this.d14Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d14Data.Text = " ";
            this.d14Data.Top = -0.016F;
            this.d14Data.Width = 0.21875F;
            // 
            // d13Data
            // 
            this.d13Data.DataField = "d13";
            this.d13Data.Height = 0.2F;
            this.d13Data.HyperLink = null;
            this.d13Data.Left = 5.188F;
            this.d13Data.Name = "d13Data";
            this.d13Data.ShrinkToFit = true;
            this.d13Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d13Data.Text = " ";
            this.d13Data.Top = -0.016F;
            this.d13Data.Width = 0.21875F;
            // 
            // d12Data
            // 
            this.d12Data.DataField = "d12";
            this.d12Data.Height = 0.2F;
            this.d12Data.HyperLink = null;
            this.d12Data.Left = 4.969F;
            this.d12Data.Name = "d12Data";
            this.d12Data.ShrinkToFit = true;
            this.d12Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d12Data.Text = " ";
            this.d12Data.Top = -0.016F;
            this.d12Data.Width = 0.21875F;
            // 
            // d11Data
            // 
            this.d11Data.DataField = "d11";
            this.d11Data.Height = 0.2F;
            this.d11Data.HyperLink = null;
            this.d11Data.Left = 4.75F;
            this.d11Data.Name = "d11Data";
            this.d11Data.ShrinkToFit = true;
            this.d11Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d11Data.Text = " ";
            this.d11Data.Top = -0.016F;
            this.d11Data.Width = 0.21875F;
            // 
            // d10Data
            // 
            this.d10Data.DataField = "d10";
            this.d10Data.Height = 0.2F;
            this.d10Data.HyperLink = null;
            this.d10Data.Left = 4.547F;
            this.d10Data.Name = "d10Data";
            this.d10Data.ShrinkToFit = true;
            this.d10Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d10Data.Text = " ";
            this.d10Data.Top = -0.016F;
            this.d10Data.Width = 0.21875F;
            // 
            // d9Data
            // 
            this.d9Data.DataField = "d9";
            this.d9Data.Height = 0.2F;
            this.d9Data.HyperLink = null;
            this.d9Data.Left = 4.328F;
            this.d9Data.Name = "d9Data";
            this.d9Data.ShrinkToFit = true;
            this.d9Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d9Data.Text = " ";
            this.d9Data.Top = -0.016F;
            this.d9Data.Width = 0.21875F;
            // 
            // d8Data
            // 
            this.d8Data.DataField = "d8";
            this.d8Data.Height = 0.2F;
            this.d8Data.HyperLink = null;
            this.d8Data.Left = 4.109F;
            this.d8Data.Name = "d8Data";
            this.d8Data.ShrinkToFit = true;
            this.d8Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d8Data.Text = " ";
            this.d8Data.Top = -0.016F;
            this.d8Data.Width = 0.21875F;
            // 
            // d7Data
            // 
            this.d7Data.DataField = "d7";
            this.d7Data.Height = 0.2F;
            this.d7Data.HyperLink = null;
            this.d7Data.Left = 3.891F;
            this.d7Data.Name = "d7Data";
            this.d7Data.ShrinkToFit = true;
            this.d7Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d7Data.Text = " ";
            this.d7Data.Top = -0.016F;
            this.d7Data.Width = 0.21875F;
            // 
            // d6Data
            // 
            this.d6Data.DataField = "d6";
            this.d6Data.Height = 0.2F;
            this.d6Data.HyperLink = null;
            this.d6Data.Left = 3.672F;
            this.d6Data.Name = "d6Data";
            this.d6Data.ShrinkToFit = true;
            this.d6Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d6Data.Text = " ";
            this.d6Data.Top = -0.016F;
            this.d6Data.Width = 0.21875F;
            // 
            // d5Data
            // 
            this.d5Data.DataField = "d5";
            this.d5Data.Height = 0.2F;
            this.d5Data.HyperLink = null;
            this.d5Data.Left = 3.453F;
            this.d5Data.Name = "d5Data";
            this.d5Data.ShrinkToFit = true;
            this.d5Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d5Data.Text = " ";
            this.d5Data.Top = -0.016F;
            this.d5Data.Width = 0.21875F;
            // 
            // d4Data
            // 
            this.d4Data.DataField = "d4";
            this.d4Data.Height = 0.2F;
            this.d4Data.HyperLink = null;
            this.d4Data.Left = 3.234F;
            this.d4Data.Name = "d4Data";
            this.d4Data.ShrinkToFit = true;
            this.d4Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d4Data.Text = " ";
            this.d4Data.Top = -0.016F;
            this.d4Data.Width = 0.21875F;
            // 
            // d3Data
            // 
            this.d3Data.DataField = "d3";
            this.d3Data.Height = 0.2F;
            this.d3Data.HyperLink = null;
            this.d3Data.Left = 3.016F;
            this.d3Data.Name = "d3Data";
            this.d3Data.ShrinkToFit = true;
            this.d3Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d3Data.Text = " ";
            this.d3Data.Top = -0.016F;
            this.d3Data.Width = 0.21875F;
            // 
            // d2Data
            // 
            this.d2Data.DataField = "d2";
            this.d2Data.Height = 0.2F;
            this.d2Data.HyperLink = null;
            this.d2Data.Left = 2.797F;
            this.d2Data.Name = "d2Data";
            this.d2Data.ShrinkToFit = true;
            this.d2Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d2Data.Text = " ";
            this.d2Data.Top = -0.016F;
            this.d2Data.Width = 0.21875F;
            // 
            // d1Data
            // 
            this.d1Data.DataField = "d1";
            this.d1Data.Height = 0.2F;
            this.d1Data.HyperLink = null;
            this.d1Data.Left = 2.578F;
            this.d1Data.Name = "d1Data";
            this.d1Data.ShrinkToFit = true;
            this.d1Data.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: normal; " +
    "text-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.d1Data.Text = "";
            this.d1Data.Top = -0.016F;
            this.d1Data.Width = 0.21875F;
            // 
            // lblSr
            // 
            this.lblSr.DataField = "EmployeeID";
            this.lblSr.Height = 0.2F;
            this.lblSr.Left = 0.03175F;
            this.lblSr.Name = "lblSr";
            this.lblSr.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; text-align: left; ddo-ch" +
    "ar-set: 1";
            this.lblSr.Tag = "";
            this.lblSr.Text = "0";
            this.lblSr.Top = -0.016F;
            this.lblSr.Width = 0.46875F;
            // 
            // Line9
            // 
            this.Line9.Height = 0.17F;
            this.Line9.Left = 0.484375F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0F;
            this.Line9.Width = 0F;
            this.Line9.X1 = 0.484375F;
            this.Line9.X2 = 0.484375F;
            this.Line9.Y1 = 0.17F;
            this.Line9.Y2 = 0F;
            // 
            // Line
            // 
            this.Line.Height = 0.17F;
            this.Line.Left = 2.78125F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0F;
            this.Line.Width = 0F;
            this.Line.X1 = 2.78125F;
            this.Line.X2 = 2.78125F;
            this.Line.Y1 = 0.17F;
            this.Line.Y2 = 0F;
            // 
            // Line2
            // 
            this.Line2.Height = 0.17F;
            this.Line2.Left = 2.5625F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 2.5625F;
            this.Line2.X2 = 2.5625F;
            this.Line2.Y1 = 0.17F;
            this.Line2.Y2 = 0F;
            // 
            // Line7
            // 
            this.Line7.Height = 0.17F;
            this.Line7.Left = 3.21875F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 0F;
            this.Line7.Width = 0F;
            this.Line7.X1 = 3.21875F;
            this.Line7.X2 = 3.21875F;
            this.Line7.Y1 = 0.17F;
            this.Line7.Y2 = 0F;
            // 
            // Line8
            // 
            this.Line8.Height = 0.17F;
            this.Line8.Left = 3F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 0F;
            this.Line8.Width = 0F;
            this.Line8.X1 = 3F;
            this.Line8.X2 = 3F;
            this.Line8.Y1 = 0.17F;
            this.Line8.Y2 = 0F;
            // 
            // Line10
            // 
            this.Line10.Height = 0.17F;
            this.Line10.Left = 4.09375F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 0F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 4.09375F;
            this.Line10.X2 = 4.09375F;
            this.Line10.Y1 = 0.17F;
            this.Line10.Y2 = 0F;
            // 
            // Line11
            // 
            this.Line11.Height = 0.17F;
            this.Line11.Left = 3.875F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 0F;
            this.Line11.Width = 0F;
            this.Line11.X1 = 3.875F;
            this.Line11.X2 = 3.875F;
            this.Line11.Y1 = 0.17F;
            this.Line11.Y2 = 0F;
            // 
            // Line12
            // 
            this.Line12.Height = 0.17F;
            this.Line12.Left = 3.65625F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 0F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 3.65625F;
            this.Line12.X2 = 3.65625F;
            this.Line12.Y1 = 0.17F;
            this.Line12.Y2 = 0F;
            // 
            // Line13
            // 
            this.Line13.Height = 0.17F;
            this.Line13.Left = 3.4375F;
            this.Line13.LineWeight = 1F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 0F;
            this.Line13.Width = 0F;
            this.Line13.X1 = 3.4375F;
            this.Line13.X2 = 3.4375F;
            this.Line13.Y1 = 0.17F;
            this.Line13.Y2 = 0F;
            // 
            // Line18
            // 
            this.Line18.Height = 0.17F;
            this.Line18.Left = 5.84375F;
            this.Line18.LineWeight = 1F;
            this.Line18.Name = "Line18";
            this.Line18.Top = 0F;
            this.Line18.Width = 0F;
            this.Line18.X1 = 5.84375F;
            this.Line18.X2 = 5.84375F;
            this.Line18.Y1 = 0.17F;
            this.Line18.Y2 = 0F;
            // 
            // Line19
            // 
            this.Line19.Height = 0.17F;
            this.Line19.Left = 5.625F;
            this.Line19.LineWeight = 1F;
            this.Line19.Name = "Line19";
            this.Line19.Top = 0F;
            this.Line19.Width = 0F;
            this.Line19.X1 = 5.625F;
            this.Line19.X2 = 5.625F;
            this.Line19.Y1 = 0.17F;
            this.Line19.Y2 = 0F;
            // 
            // Line38
            // 
            this.Line38.Height = 0.17F;
            this.Line38.Left = 5.40625F;
            this.Line38.LineWeight = 1F;
            this.Line38.Name = "Line38";
            this.Line38.Top = 0F;
            this.Line38.Width = 0F;
            this.Line38.X1 = 5.40625F;
            this.Line38.X2 = 5.40625F;
            this.Line38.Y1 = 0.17F;
            this.Line38.Y2 = 0F;
            // 
            // Line39
            // 
            this.Line39.Height = 0.17F;
            this.Line39.Left = 5.1875F;
            this.Line39.LineWeight = 1F;
            this.Line39.Name = "Line39";
            this.Line39.Top = 0F;
            this.Line39.Width = 0F;
            this.Line39.X1 = 5.1875F;
            this.Line39.X2 = 5.1875F;
            this.Line39.Y1 = 0.17F;
            this.Line39.Y2 = 0F;
            // 
            // Line40
            // 
            this.Line40.Height = 0.17F;
            this.Line40.Left = 4.96875F;
            this.Line40.LineWeight = 1F;
            this.Line40.Name = "Line40";
            this.Line40.Top = 0F;
            this.Line40.Width = 0F;
            this.Line40.X1 = 4.96875F;
            this.Line40.X2 = 4.96875F;
            this.Line40.Y1 = 0.17F;
            this.Line40.Y2 = 0F;
            // 
            // Line41
            // 
            this.Line41.Height = 0.17F;
            this.Line41.Left = 4.75F;
            this.Line41.LineWeight = 1F;
            this.Line41.Name = "Line41";
            this.Line41.Top = 0F;
            this.Line41.Width = 0F;
            this.Line41.X1 = 4.75F;
            this.Line41.X2 = 4.75F;
            this.Line41.Y1 = 0.17F;
            this.Line41.Y2 = 0F;
            // 
            // Line42
            // 
            this.Line42.Height = 0.17F;
            this.Line42.Left = 4.53125F;
            this.Line42.LineWeight = 1F;
            this.Line42.Name = "Line42";
            this.Line42.Top = 0F;
            this.Line42.Width = 0F;
            this.Line42.X1 = 4.53125F;
            this.Line42.X2 = 4.53125F;
            this.Line42.Y1 = 0.17F;
            this.Line42.Y2 = 0F;
            // 
            // Line43
            // 
            this.Line43.Height = 0.17F;
            this.Line43.Left = 4.3125F;
            this.Line43.LineWeight = 1F;
            this.Line43.Name = "Line43";
            this.Line43.Top = 0F;
            this.Line43.Width = 0F;
            this.Line43.X1 = 4.3125F;
            this.Line43.X2 = 4.3125F;
            this.Line43.Y1 = 0.17F;
            this.Line43.Y2 = 0F;
            // 
            // Line44
            // 
            this.Line44.Height = 0.17F;
            this.Line44.Left = 9.34375F;
            this.Line44.LineWeight = 1F;
            this.Line44.Name = "Line44";
            this.Line44.Top = 0F;
            this.Line44.Width = 0F;
            this.Line44.X1 = 9.34375F;
            this.Line44.X2 = 9.34375F;
            this.Line44.Y1 = 0.17F;
            this.Line44.Y2 = 0F;
            // 
            // Line45
            // 
            this.Line45.Height = 0.17F;
            this.Line45.Left = 9.125F;
            this.Line45.LineWeight = 1F;
            this.Line45.Name = "Line45";
            this.Line45.Top = 0F;
            this.Line45.Width = 0F;
            this.Line45.X1 = 9.125F;
            this.Line45.X2 = 9.125F;
            this.Line45.Y1 = 0.17F;
            this.Line45.Y2 = 0F;
            // 
            // Line46
            // 
            this.Line46.Height = 0.17F;
            this.Line46.Left = 8.90625F;
            this.Line46.LineWeight = 1F;
            this.Line46.Name = "Line46";
            this.Line46.Top = 0F;
            this.Line46.Width = 0F;
            this.Line46.X1 = 8.90625F;
            this.Line46.X2 = 8.90625F;
            this.Line46.Y1 = 0.17F;
            this.Line46.Y2 = 0F;
            // 
            // Line47
            // 
            this.Line47.Height = 0.17F;
            this.Line47.Left = 8.6875F;
            this.Line47.LineWeight = 1F;
            this.Line47.Name = "Line47";
            this.Line47.Top = 0F;
            this.Line47.Width = 0F;
            this.Line47.X1 = 8.6875F;
            this.Line47.X2 = 8.6875F;
            this.Line47.Y1 = 0.17F;
            this.Line47.Y2 = 0F;
            // 
            // Line48
            // 
            this.Line48.Height = 0.17F;
            this.Line48.Left = 8.46875F;
            this.Line48.LineWeight = 1F;
            this.Line48.Name = "Line48";
            this.Line48.Top = 0F;
            this.Line48.Width = 0F;
            this.Line48.X1 = 8.46875F;
            this.Line48.X2 = 8.46875F;
            this.Line48.Y1 = 0.17F;
            this.Line48.Y2 = 0F;
            // 
            // Line49
            // 
            this.Line49.Height = 0.17F;
            this.Line49.Left = 8.25F;
            this.Line49.LineWeight = 1F;
            this.Line49.Name = "Line49";
            this.Line49.Top = 0F;
            this.Line49.Width = 0F;
            this.Line49.X1 = 8.25F;
            this.Line49.X2 = 8.25F;
            this.Line49.Y1 = 0.17F;
            this.Line49.Y2 = 0F;
            // 
            // Line50
            // 
            this.Line50.Height = 0.17F;
            this.Line50.Left = 8.03125F;
            this.Line50.LineWeight = 1F;
            this.Line50.Name = "Line50";
            this.Line50.Top = 0F;
            this.Line50.Width = 0F;
            this.Line50.X1 = 8.03125F;
            this.Line50.X2 = 8.03125F;
            this.Line50.Y1 = 0.17F;
            this.Line50.Y2 = 0F;
            // 
            // Line51
            // 
            this.Line51.Height = 0.17F;
            this.Line51.Left = 7.8125F;
            this.Line51.LineWeight = 1F;
            this.Line51.Name = "Line51";
            this.Line51.Top = 0F;
            this.Line51.Width = 0F;
            this.Line51.X1 = 7.8125F;
            this.Line51.X2 = 7.8125F;
            this.Line51.Y1 = 0.17F;
            this.Line51.Y2 = 0F;
            // 
            // Line52
            // 
            this.Line52.Height = 0.17F;
            this.Line52.Left = 7.59375F;
            this.Line52.LineWeight = 1F;
            this.Line52.Name = "Line52";
            this.Line52.Top = 0F;
            this.Line52.Width = 0F;
            this.Line52.X1 = 7.59375F;
            this.Line52.X2 = 7.59375F;
            this.Line52.Y1 = 0.17F;
            this.Line52.Y2 = 0F;
            // 
            // Line53
            // 
            this.Line53.Height = 0.17F;
            this.Line53.Left = 7.375F;
            this.Line53.LineWeight = 1F;
            this.Line53.Name = "Line53";
            this.Line53.Top = 0F;
            this.Line53.Width = 0F;
            this.Line53.X1 = 7.375F;
            this.Line53.X2 = 7.375F;
            this.Line53.Y1 = 0.17F;
            this.Line53.Y2 = 0F;
            // 
            // Line54
            // 
            this.Line54.Height = 0.17F;
            this.Line54.Left = 7.15625F;
            this.Line54.LineWeight = 1F;
            this.Line54.Name = "Line54";
            this.Line54.Top = 0F;
            this.Line54.Width = 0F;
            this.Line54.X1 = 7.15625F;
            this.Line54.X2 = 7.15625F;
            this.Line54.Y1 = 0.17F;
            this.Line54.Y2 = 0F;
            // 
            // Line55
            // 
            this.Line55.Height = 0.17F;
            this.Line55.Left = 6.9375F;
            this.Line55.LineWeight = 1F;
            this.Line55.Name = "Line55";
            this.Line55.Top = 0F;
            this.Line55.Width = 0F;
            this.Line55.X1 = 6.9375F;
            this.Line55.X2 = 6.9375F;
            this.Line55.Y1 = 0.17F;
            this.Line55.Y2 = 0F;
            // 
            // Line56
            // 
            this.Line56.Height = 0.17F;
            this.Line56.Left = 6.71875F;
            this.Line56.LineWeight = 1F;
            this.Line56.Name = "Line56";
            this.Line56.Top = 0F;
            this.Line56.Width = 0F;
            this.Line56.X1 = 6.71875F;
            this.Line56.X2 = 6.71875F;
            this.Line56.Y1 = 0.17F;
            this.Line56.Y2 = 0F;
            // 
            // Line57
            // 
            this.Line57.Height = 0.17F;
            this.Line57.Left = 6.5F;
            this.Line57.LineWeight = 1F;
            this.Line57.Name = "Line57";
            this.Line57.Top = 0F;
            this.Line57.Width = 0F;
            this.Line57.X1 = 6.5F;
            this.Line57.X2 = 6.5F;
            this.Line57.Y1 = 0.17F;
            this.Line57.Y2 = 0F;
            // 
            // Line58
            // 
            this.Line58.Height = 0.17F;
            this.Line58.Left = 6.28125F;
            this.Line58.LineWeight = 1F;
            this.Line58.Name = "Line58";
            this.Line58.Top = 0F;
            this.Line58.Width = 0F;
            this.Line58.X1 = 6.28125F;
            this.Line58.X2 = 6.28125F;
            this.Line58.Y1 = 0.17F;
            this.Line58.Y2 = 0F;
            // 
            // Line59
            // 
            this.Line59.Height = 0.17F;
            this.Line59.Left = 6.0625F;
            this.Line59.LineWeight = 1F;
            this.Line59.Name = "Line59";
            this.Line59.Top = 0F;
            this.Line59.Width = 0F;
            this.Line59.X1 = 6.0625F;
            this.Line59.X2 = 6.0625F;
            this.Line59.Y1 = 0.17F;
            this.Line59.Y2 = 0F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape3,
            this.lbl2,
            this.Shape2,
            this.Shape,
            this.Label5,
            this.TextBox,
            this.Label,
            this.txtHeaderCompany,
            this.Picture,
            this.txtHeaderArabic,
            this.Label1,
            this.Label3,
            this.txtPeriod,
            this.Line14,
            this.d1,
            this.d2,
            this.d3,
            this.d4,
            this.d5,
            this.d6,
            this.d7,
            this.d8,
            this.d9,
            this.d10,
            this.Line26,
            this.d11,
            this.Line27,
            this.d12,
            this.d13,
            this.d14,
            this.d16,
            this.d17,
            this.d18,
            this.d19,
            this.d20,
            this.d21,
            this.d23,
            this.d24,
            this.d26,
            this.d22,
            this.d25,
            this.d27,
            this.d28,
            this.d29,
            this.d30,
            this.Line84,
            this.Line85,
            this.Line86,
            this.Line87,
            this.Line88,
            this.Line89,
            this.d31,
            this.d15,
            this.Line1,
            this.Line3,
            this.Line4,
            this.Line5,
            this.Line6,
            this.Line15,
            this.Line16,
            this.Line17,
            this.Line20,
            this.Line21,
            this.Line22,
            this.Line23,
            this.Line24,
            this.Line25,
            this.Line28,
            this.Line29,
            this.Line30,
            this.Line31,
            this.Line32,
            this.Line33,
            this.Line34,
            this.Line35,
            this.Line36,
            this.Line37});
            this.PageHeader.Height = 1.634722F;
            this.PageHeader.Name = "PageHeader";
            // 
            // Shape3
            // 
            this.Shape3.Height = 0.25F;
            this.Shape3.Left = 0F;
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect;
            this.Shape3.Top = 1.40625F;
            this.Shape3.Width = 9.34375F;
            // 
            // lbl2
            // 
            this.lbl2.Height = 0.2F;
            this.lbl2.HyperLink = null;
            this.lbl2.Left = 0.625F;
            this.lbl2.Name = "lbl2";
            this.lbl2.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.lbl2.Text = "Employee Name";
            this.lbl2.Top = 1.4375F;
            this.lbl2.Width = 1.5F;
            // 
            // Shape2
            // 
            this.Shape2.BackColor = System.Drawing.Color.White;
            this.Shape2.Height = 0.01041663F;
            this.Shape2.Left = 0F;
            this.Shape2.Name = "Shape2";
            this.Shape2.RoundingRadius = 9.999999F;
            this.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect;
            this.Shape2.Top = 1.348958F;
            this.Shape2.Width = 9.9375F;
            // 
            // Shape
            // 
            this.Shape.BackColor = System.Drawing.Color.White;
            this.Shape.Height = 0.01041663F;
            this.Shape.Left = 0F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect;
            this.Shape.Top = 1.0625F;
            this.Shape.Width = 9.9375F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.1875F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 0F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: bold; te" +
    "xt-align: left; ddo-char-set: 0";
            this.Label5.Text = "Duration:";
            this.Label5.Top = 1.125F;
            this.Label5.Width = 0.6875F;
            // 
            // TextBox
            // 
            this.TextBox.DataField = "=System.DateTime.Now";
            this.TextBox.Height = 0.2F;
            this.TextBox.Left = 1.25F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "color: Black; font-size: 8.25pt; vertical-align: bottom";
            this.TextBox.Text = "TextBox1";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 1.3125F;
            // 
            // Label
            // 
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "color: Black; font-size: 8.25pt; font-weight: bold; vertical-align: bottom";
            this.Label.Text = "Print Date and Time";
            this.Label.Top = 0F;
            this.Label.Width = 1.125F;
            // 
            // txtHeaderCompany
            // 
            this.txtHeaderCompany.Height = 0.3125F;
            this.txtHeaderCompany.Left = 0F;
            this.txtHeaderCompany.Name = "txtHeaderCompany";
            this.txtHeaderCompany.Style = "color: Black; font-family: Book Antiqua; font-size: 14.25pt; font-weight: bold; t" +
    "ext-align: left; ddo-char-set: 0";
            this.txtHeaderCompany.Text = null;
            this.txtHeaderCompany.Top = 0.3125F;
            this.txtHeaderCompany.Width = 3.375F;
            // 
            // Picture
            // 
            this.Picture.Height = 1F;
            this.Picture.ImageData = ((System.IO.Stream)(resources.GetObject("Picture.ImageData")));
            this.Picture.Left = 4.375F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch;
            this.Picture.Top = 0F;
            this.Picture.Width = 1.0625F;
            // 
            // txtHeaderArabic
            // 
            this.txtHeaderArabic.Height = 0.375F;
            this.txtHeaderArabic.Left = 6.3125F;
            this.txtHeaderArabic.Name = "txtHeaderArabic";
            this.txtHeaderArabic.Style = "color: Black; font-family: Arabic Typesetting; font-size: 21.75pt; font-weight: b" +
    "old; text-align: center; ddo-char-set: 0";
            this.txtHeaderArabic.Text = null;
            this.txtHeaderArabic.Top = 0.3125F;
            this.txtHeaderArabic.Width = 3.625F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "color: Black; font-family: Book Antiqua; font-size: 12pt; font-weight: bold; text" +
    "-align: left; text-decoration: underline; ddo-char-set: 1";
            this.Label1.Text = "Monthly Attendance Detail Report ";
            this.Label1.Top = 0.8125F;
            this.Label1.Width = 3.25F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0.0625F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.Label3.Text = "Code";
            this.Label3.Top = 1.4375F;
            this.Label3.Width = 0.5F;
            // 
            // txtPeriod
            // 
            this.txtPeriod.Height = 0.2F;
            this.txtPeriod.Left = 0.71875F;
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: bold; te" +
    "xt-align: left; ddo-char-set: 1";
            this.txtPeriod.Text = null;
            this.txtPeriod.Top = 1.125F;
            this.txtPeriod.Width = 3.96875F;
            // 
            // Line14
            // 
            this.Line14.Height = 0.25F;
            this.Line14.Left = 0.484375F;
            this.Line14.LineWeight = 1F;
            this.Line14.Name = "Line14";
            this.Line14.Top = 1.40625F;
            this.Line14.Width = 0F;
            this.Line14.X1 = 0.484375F;
            this.Line14.X2 = 0.484375F;
            this.Line14.Y1 = 1.65625F;
            this.Line14.Y2 = 1.40625F;
            // 
            // d1
            // 
            this.d1.DataField = "  ";
            this.d1.Height = 0.2625F;
            this.d1.HyperLink = null;
            this.d1.Left = 2.5625F;
            this.d1.Name = "d1";
            this.d1.ShrinkToFit = true;
            this.d1.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; white-space: nowrap; ddo-char-set: 1; ddo" +
    "-shrink-to-fit: true";
            this.d1.Text = "";
            this.d1.Top = 1.4F;
            this.d1.Width = 0.21875F;
            // 
            // d2
            // 
            this.d2.DataField = "  ";
            this.d2.Height = 0.2625F;
            this.d2.HyperLink = null;
            this.d2.Left = 2.78125F;
            this.d2.Name = "d2";
            this.d2.ShrinkToFit = true;
            this.d2.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-char-set: 1; ddo-shrink-to-fit: true";
            this.d2.Text = "";
            this.d2.Top = 1.4F;
            this.d2.Width = 0.21875F;
            // 
            // d3
            // 
            this.d3.DataField = "  ";
            this.d3.Height = 0.2625F;
            this.d3.HyperLink = null;
            this.d3.Left = 3F;
            this.d3.Name = "d3";
            this.d3.ShrinkToFit = true;
            this.d3.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-char-set: 1; ddo-shrink-to-fit: true";
            this.d3.Text = "";
            this.d3.Top = 1.4F;
            this.d3.Width = 0.21875F;
            // 
            // d4
            // 
            this.d4.DataField = "  ";
            this.d4.Height = 0.2625F;
            this.d4.HyperLink = null;
            this.d4.Left = 3.21875F;
            this.d4.Name = "d4";
            this.d4.ShrinkToFit = true;
            this.d4.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d4.Text = "";
            this.d4.Top = 1.4F;
            this.d4.Width = 0.21875F;
            // 
            // d5
            // 
            this.d5.DataField = "  ";
            this.d5.Height = 0.2625F;
            this.d5.HyperLink = null;
            this.d5.Left = 3.4375F;
            this.d5.Name = "d5";
            this.d5.ShrinkToFit = true;
            this.d5.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d5.Text = " ";
            this.d5.Top = 1.4F;
            this.d5.Width = 0.21875F;
            // 
            // d6
            // 
            this.d6.DataField = "  ";
            this.d6.Height = 0.2625F;
            this.d6.HyperLink = null;
            this.d6.Left = 3.65625F;
            this.d6.Name = "d6";
            this.d6.ShrinkToFit = true;
            this.d6.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d6.Text = " ";
            this.d6.Top = 1.4F;
            this.d6.Width = 0.21875F;
            // 
            // d7
            // 
            this.d7.DataField = "  ";
            this.d7.Height = 0.2625F;
            this.d7.HyperLink = null;
            this.d7.Left = 3.875F;
            this.d7.Name = "d7";
            this.d7.ShrinkToFit = true;
            this.d7.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d7.Text = "";
            this.d7.Top = 1.4F;
            this.d7.Width = 0.21875F;
            // 
            // d8
            // 
            this.d8.DataField = "  ";
            this.d8.Height = 0.2625F;
            this.d8.HyperLink = null;
            this.d8.Left = 4.09375F;
            this.d8.Name = "d8";
            this.d8.ShrinkToFit = true;
            this.d8.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d8.Text = " ";
            this.d8.Top = 1.4F;
            this.d8.Width = 0.21875F;
            // 
            // d9
            // 
            this.d9.DataField = "  ";
            this.d9.Height = 0.2625F;
            this.d9.HyperLink = null;
            this.d9.Left = 4.3125F;
            this.d9.Name = "d9";
            this.d9.ShrinkToFit = true;
            this.d9.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d9.Text = " ";
            this.d9.Top = 1.4F;
            this.d9.Width = 0.21875F;
            // 
            // d10
            // 
            this.d10.DataField = "  ";
            this.d10.Height = 0.2625F;
            this.d10.HyperLink = null;
            this.d10.Left = 4.53125F;
            this.d10.Name = "d10";
            this.d10.ShrinkToFit = true;
            this.d10.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d10.Text = " ";
            this.d10.Top = 1.4F;
            this.d10.Width = 0.21875F;
            // 
            // Line26
            // 
            this.Line26.Height = 0.25F;
            this.Line26.Left = 2.78125F;
            this.Line26.LineWeight = 1F;
            this.Line26.Name = "Line26";
            this.Line26.Top = 1.40625F;
            this.Line26.Width = 0F;
            this.Line26.X1 = 2.78125F;
            this.Line26.X2 = 2.78125F;
            this.Line26.Y1 = 1.65625F;
            this.Line26.Y2 = 1.40625F;
            // 
            // d11
            // 
            this.d11.DataField = "  ";
            this.d11.Height = 0.2625F;
            this.d11.HyperLink = null;
            this.d11.Left = 4.75F;
            this.d11.Name = "d11";
            this.d11.ShrinkToFit = true;
            this.d11.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d11.Text = " ";
            this.d11.Top = 1.4F;
            this.d11.Width = 0.21875F;
            // 
            // Line27
            // 
            this.Line27.Height = 0.25F;
            this.Line27.Left = 2.5625F;
            this.Line27.LineWeight = 1F;
            this.Line27.Name = "Line27";
            this.Line27.Top = 1.40625F;
            this.Line27.Width = 0F;
            this.Line27.X1 = 2.5625F;
            this.Line27.X2 = 2.5625F;
            this.Line27.Y1 = 1.65625F;
            this.Line27.Y2 = 1.40625F;
            // 
            // d12
            // 
            this.d12.DataField = "  ";
            this.d12.Height = 0.2625F;
            this.d12.HyperLink = null;
            this.d12.Left = 4.96875F;
            this.d12.Name = "d12";
            this.d12.ShrinkToFit = true;
            this.d12.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d12.Text = " ";
            this.d12.Top = 1.4F;
            this.d12.Width = 0.21875F;
            // 
            // d13
            // 
            this.d13.DataField = "  ";
            this.d13.Height = 0.2625F;
            this.d13.HyperLink = null;
            this.d13.Left = 5.1875F;
            this.d13.Name = "d13";
            this.d13.ShrinkToFit = true;
            this.d13.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d13.Text = "";
            this.d13.Top = 1.4F;
            this.d13.Width = 0.21875F;
            // 
            // d14
            // 
            this.d14.DataField = "  ";
            this.d14.Height = 0.2625F;
            this.d14.HyperLink = null;
            this.d14.Left = 5.40625F;
            this.d14.Name = "d14";
            this.d14.ShrinkToFit = true;
            this.d14.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d14.Text = " ";
            this.d14.Top = 1.4F;
            this.d14.Width = 0.21875F;
            // 
            // d16
            // 
            this.d16.DataField = "  ";
            this.d16.Height = 0.2625F;
            this.d16.HyperLink = null;
            this.d16.Left = 5.84375F;
            this.d16.Name = "d16";
            this.d16.ShrinkToFit = true;
            this.d16.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d16.Text = " ";
            this.d16.Top = 1.4F;
            this.d16.Width = 0.21875F;
            // 
            // d17
            // 
            this.d17.DataField = "  ";
            this.d17.Height = 0.2625F;
            this.d17.HyperLink = null;
            this.d17.Left = 6.0625F;
            this.d17.Name = "d17";
            this.d17.ShrinkToFit = true;
            this.d17.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d17.Text = " ";
            this.d17.Top = 1.4F;
            this.d17.Width = 0.21875F;
            // 
            // d18
            // 
            this.d18.DataField = "  ";
            this.d18.Height = 0.2625F;
            this.d18.HyperLink = null;
            this.d18.Left = 6.28125F;
            this.d18.Name = "d18";
            this.d18.ShrinkToFit = true;
            this.d18.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d18.Text = " ";
            this.d18.Top = 1.4F;
            this.d18.Width = 0.21875F;
            // 
            // d19
            // 
            this.d19.DataField = "  ";
            this.d19.Height = 0.2625F;
            this.d19.HyperLink = null;
            this.d19.Left = 6.5F;
            this.d19.Name = "d19";
            this.d19.ShrinkToFit = true;
            this.d19.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d19.Text = " ";
            this.d19.Top = 1.4F;
            this.d19.Width = 0.21875F;
            // 
            // d20
            // 
            this.d20.DataField = "  ";
            this.d20.Height = 0.2625F;
            this.d20.HyperLink = null;
            this.d20.Left = 6.71875F;
            this.d20.Name = "d20";
            this.d20.ShrinkToFit = true;
            this.d20.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d20.Text = " ";
            this.d20.Top = 1.4F;
            this.d20.Width = 0.21875F;
            // 
            // d21
            // 
            this.d21.DataField = "  ";
            this.d21.Height = 0.2625F;
            this.d21.HyperLink = null;
            this.d21.Left = 6.9375F;
            this.d21.Name = "d21";
            this.d21.ShrinkToFit = true;
            this.d21.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d21.Text = " ";
            this.d21.Top = 1.4F;
            this.d21.Width = 0.21875F;
            // 
            // d23
            // 
            this.d23.DataField = "  ";
            this.d23.Height = 0.2625F;
            this.d23.HyperLink = null;
            this.d23.Left = 7.375F;
            this.d23.Name = "d23";
            this.d23.ShrinkToFit = true;
            this.d23.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d23.Text = " ";
            this.d23.Top = 1.4F;
            this.d23.Width = 0.21875F;
            // 
            // d24
            // 
            this.d24.DataField = "  ";
            this.d24.Height = 0.2625F;
            this.d24.HyperLink = null;
            this.d24.Left = 7.59375F;
            this.d24.Name = "d24";
            this.d24.ShrinkToFit = true;
            this.d24.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d24.Text = " ";
            this.d24.Top = 1.4F;
            this.d24.Width = 0.21875F;
            // 
            // d26
            // 
            this.d26.DataField = "  ";
            this.d26.Height = 0.2625F;
            this.d26.HyperLink = null;
            this.d26.Left = 8.03125F;
            this.d26.Name = "d26";
            this.d26.ShrinkToFit = true;
            this.d26.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d26.Text = " ";
            this.d26.Top = 1.4F;
            this.d26.Width = 0.21875F;
            // 
            // d22
            // 
            this.d22.DataField = "  ";
            this.d22.Height = 0.2625F;
            this.d22.HyperLink = null;
            this.d22.Left = 7.15625F;
            this.d22.Name = "d22";
            this.d22.ShrinkToFit = true;
            this.d22.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d22.Text = " ";
            this.d22.Top = 1.4F;
            this.d22.Width = 0.21875F;
            // 
            // d25
            // 
            this.d25.DataField = "  ";
            this.d25.Height = 0.2625F;
            this.d25.HyperLink = null;
            this.d25.Left = 7.8125F;
            this.d25.Name = "d25";
            this.d25.ShrinkToFit = true;
            this.d25.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d25.Text = " ";
            this.d25.Top = 1.4F;
            this.d25.Width = 0.21875F;
            // 
            // d27
            // 
            this.d27.DataField = "  ";
            this.d27.Height = 0.2625F;
            this.d27.HyperLink = null;
            this.d27.Left = 8.25F;
            this.d27.Name = "d27";
            this.d27.ShrinkToFit = true;
            this.d27.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d27.Text = " ";
            this.d27.Top = 1.4F;
            this.d27.Width = 0.21875F;
            // 
            // d28
            // 
            this.d28.DataField = "  ";
            this.d28.Height = 0.2625F;
            this.d28.HyperLink = null;
            this.d28.Left = 8.46875F;
            this.d28.Name = "d28";
            this.d28.ShrinkToFit = true;
            this.d28.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d28.Text = " ";
            this.d28.Top = 1.4F;
            this.d28.Width = 0.21875F;
            // 
            // d29
            // 
            this.d29.DataField = "  ";
            this.d29.Height = 0.2625F;
            this.d29.HyperLink = null;
            this.d29.Left = 8.6875F;
            this.d29.Name = "d29";
            this.d29.ShrinkToFit = true;
            this.d29.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d29.Text = " ";
            this.d29.Top = 1.4F;
            this.d29.Width = 0.21875F;
            // 
            // d30
            // 
            this.d30.DataField = "  ";
            this.d30.Height = 0.2625F;
            this.d30.HyperLink = null;
            this.d30.Left = 8.90625F;
            this.d30.Name = "d30";
            this.d30.ShrinkToFit = true;
            this.d30.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d30.Text = " ";
            this.d30.Top = 1.4F;
            this.d30.Width = 0.21875F;
            // 
            // Line84
            // 
            this.Line84.Height = 0.25F;
            this.Line84.Left = 3.21875F;
            this.Line84.LineWeight = 1F;
            this.Line84.Name = "Line84";
            this.Line84.Top = 1.40625F;
            this.Line84.Width = 0F;
            this.Line84.X1 = 3.21875F;
            this.Line84.X2 = 3.21875F;
            this.Line84.Y1 = 1.65625F;
            this.Line84.Y2 = 1.40625F;
            // 
            // Line85
            // 
            this.Line85.Height = 0.25F;
            this.Line85.Left = 3F;
            this.Line85.LineWeight = 1F;
            this.Line85.Name = "Line85";
            this.Line85.Top = 1.40625F;
            this.Line85.Width = 0F;
            this.Line85.X1 = 3F;
            this.Line85.X2 = 3F;
            this.Line85.Y1 = 1.65625F;
            this.Line85.Y2 = 1.40625F;
            // 
            // Line86
            // 
            this.Line86.Height = 0.25F;
            this.Line86.Left = 4.09375F;
            this.Line86.LineWeight = 1F;
            this.Line86.Name = "Line86";
            this.Line86.Top = 1.40625F;
            this.Line86.Width = 0F;
            this.Line86.X1 = 4.09375F;
            this.Line86.X2 = 4.09375F;
            this.Line86.Y1 = 1.65625F;
            this.Line86.Y2 = 1.40625F;
            // 
            // Line87
            // 
            this.Line87.Height = 0.25F;
            this.Line87.Left = 3.875F;
            this.Line87.LineWeight = 1F;
            this.Line87.Name = "Line87";
            this.Line87.Top = 1.40625F;
            this.Line87.Width = 0F;
            this.Line87.X1 = 3.875F;
            this.Line87.X2 = 3.875F;
            this.Line87.Y1 = 1.65625F;
            this.Line87.Y2 = 1.40625F;
            // 
            // Line88
            // 
            this.Line88.Height = 0.25F;
            this.Line88.Left = 3.65625F;
            this.Line88.LineWeight = 1F;
            this.Line88.Name = "Line88";
            this.Line88.Top = 1.40625F;
            this.Line88.Width = 0F;
            this.Line88.X1 = 3.65625F;
            this.Line88.X2 = 3.65625F;
            this.Line88.Y1 = 1.65625F;
            this.Line88.Y2 = 1.40625F;
            // 
            // Line89
            // 
            this.Line89.Height = 0.25F;
            this.Line89.Left = 3.4375F;
            this.Line89.LineWeight = 1F;
            this.Line89.Name = "Line89";
            this.Line89.Top = 1.40625F;
            this.Line89.Width = 0F;
            this.Line89.X1 = 3.4375F;
            this.Line89.X2 = 3.4375F;
            this.Line89.Y1 = 1.65625F;
            this.Line89.Y2 = 1.40625F;
            // 
            // d31
            // 
            this.d31.DataField = "  ";
            this.d31.Height = 0.2625F;
            this.d31.HyperLink = null;
            this.d31.Left = 9.125F;
            this.d31.Name = "d31";
            this.d31.ShrinkToFit = true;
            this.d31.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-char-set: 1; ddo-shrink-to-fit: true";
            this.d31.Text = " ";
            this.d31.Top = 1.4F;
            this.d31.Width = 0.21875F;
            // 
            // d15
            // 
            this.d15.DataField = "  ";
            this.d15.Height = 0.2625F;
            this.d15.HyperLink = null;
            this.d15.Left = 5.625F;
            this.d15.Name = "d15";
            this.d15.ShrinkToFit = true;
            this.d15.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; vertical-align: middle; ddo-shrink-to-fit: true";
            this.d15.Text = " ";
            this.d15.Top = 1.4F;
            this.d15.Width = 0.21875F;
            // 
            // Line1
            // 
            this.Line1.Height = 0.25F;
            this.Line1.Left = 5.84375F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.40625F;
            this.Line1.Width = 0F;
            this.Line1.X1 = 5.84375F;
            this.Line1.X2 = 5.84375F;
            this.Line1.Y1 = 1.65625F;
            this.Line1.Y2 = 1.40625F;
            // 
            // Line3
            // 
            this.Line3.Height = 0.25F;
            this.Line3.Left = 5.625F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 1.40625F;
            this.Line3.Width = 0F;
            this.Line3.X1 = 5.625F;
            this.Line3.X2 = 5.625F;
            this.Line3.Y1 = 1.65625F;
            this.Line3.Y2 = 1.40625F;
            // 
            // Line4
            // 
            this.Line4.Height = 0.25F;
            this.Line4.Left = 5.40625F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 1.40625F;
            this.Line4.Width = 0F;
            this.Line4.X1 = 5.40625F;
            this.Line4.X2 = 5.40625F;
            this.Line4.Y1 = 1.65625F;
            this.Line4.Y2 = 1.40625F;
            // 
            // Line5
            // 
            this.Line5.Height = 0.25F;
            this.Line5.Left = 5.1875F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 1.40625F;
            this.Line5.Width = 0F;
            this.Line5.X1 = 5.1875F;
            this.Line5.X2 = 5.1875F;
            this.Line5.Y1 = 1.65625F;
            this.Line5.Y2 = 1.40625F;
            // 
            // Line6
            // 
            this.Line6.Height = 0.25F;
            this.Line6.Left = 4.96875F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 1.40625F;
            this.Line6.Width = 0F;
            this.Line6.X1 = 4.96875F;
            this.Line6.X2 = 4.96875F;
            this.Line6.Y1 = 1.65625F;
            this.Line6.Y2 = 1.40625F;
            // 
            // Line15
            // 
            this.Line15.Height = 0.25F;
            this.Line15.Left = 4.75F;
            this.Line15.LineWeight = 1F;
            this.Line15.Name = "Line15";
            this.Line15.Top = 1.40625F;
            this.Line15.Width = 0F;
            this.Line15.X1 = 4.75F;
            this.Line15.X2 = 4.75F;
            this.Line15.Y1 = 1.65625F;
            this.Line15.Y2 = 1.40625F;
            // 
            // Line16
            // 
            this.Line16.Height = 0.25F;
            this.Line16.Left = 4.53125F;
            this.Line16.LineWeight = 1F;
            this.Line16.Name = "Line16";
            this.Line16.Top = 1.40625F;
            this.Line16.Width = 0F;
            this.Line16.X1 = 4.53125F;
            this.Line16.X2 = 4.53125F;
            this.Line16.Y1 = 1.65625F;
            this.Line16.Y2 = 1.40625F;
            // 
            // Line17
            // 
            this.Line17.Height = 0.25F;
            this.Line17.Left = 4.3125F;
            this.Line17.LineWeight = 1F;
            this.Line17.Name = "Line17";
            this.Line17.Top = 1.40625F;
            this.Line17.Width = 0F;
            this.Line17.X1 = 4.3125F;
            this.Line17.X2 = 4.3125F;
            this.Line17.Y1 = 1.65625F;
            this.Line17.Y2 = 1.40625F;
            // 
            // Line20
            // 
            this.Line20.Height = 0.25F;
            this.Line20.Left = 9.34375F;
            this.Line20.LineWeight = 1F;
            this.Line20.Name = "Line20";
            this.Line20.Top = 1.421875F;
            this.Line20.Width = 0F;
            this.Line20.X1 = 9.34375F;
            this.Line20.X2 = 9.34375F;
            this.Line20.Y1 = 1.671875F;
            this.Line20.Y2 = 1.421875F;
            // 
            // Line21
            // 
            this.Line21.Height = 0.25F;
            this.Line21.Left = 9.125F;
            this.Line21.LineWeight = 1F;
            this.Line21.Name = "Line21";
            this.Line21.Top = 1.40625F;
            this.Line21.Width = 0F;
            this.Line21.X1 = 9.125F;
            this.Line21.X2 = 9.125F;
            this.Line21.Y1 = 1.65625F;
            this.Line21.Y2 = 1.40625F;
            // 
            // Line22
            // 
            this.Line22.Height = 0.25F;
            this.Line22.Left = 8.90625F;
            this.Line22.LineWeight = 1F;
            this.Line22.Name = "Line22";
            this.Line22.Top = 1.40625F;
            this.Line22.Width = 0F;
            this.Line22.X1 = 8.90625F;
            this.Line22.X2 = 8.90625F;
            this.Line22.Y1 = 1.65625F;
            this.Line22.Y2 = 1.40625F;
            // 
            // Line23
            // 
            this.Line23.Height = 0.25F;
            this.Line23.Left = 8.6875F;
            this.Line23.LineWeight = 1F;
            this.Line23.Name = "Line23";
            this.Line23.Top = 1.40625F;
            this.Line23.Width = 0F;
            this.Line23.X1 = 8.6875F;
            this.Line23.X2 = 8.6875F;
            this.Line23.Y1 = 1.65625F;
            this.Line23.Y2 = 1.40625F;
            // 
            // Line24
            // 
            this.Line24.Height = 0.25F;
            this.Line24.Left = 8.46875F;
            this.Line24.LineWeight = 1F;
            this.Line24.Name = "Line24";
            this.Line24.Top = 1.40625F;
            this.Line24.Width = 0F;
            this.Line24.X1 = 8.46875F;
            this.Line24.X2 = 8.46875F;
            this.Line24.Y1 = 1.65625F;
            this.Line24.Y2 = 1.40625F;
            // 
            // Line25
            // 
            this.Line25.Height = 0.25F;
            this.Line25.Left = 8.25F;
            this.Line25.LineWeight = 1F;
            this.Line25.Name = "Line25";
            this.Line25.Top = 1.40625F;
            this.Line25.Width = 0F;
            this.Line25.X1 = 8.25F;
            this.Line25.X2 = 8.25F;
            this.Line25.Y1 = 1.65625F;
            this.Line25.Y2 = 1.40625F;
            // 
            // Line28
            // 
            this.Line28.Height = 0.25F;
            this.Line28.Left = 8.03125F;
            this.Line28.LineWeight = 1F;
            this.Line28.Name = "Line28";
            this.Line28.Top = 1.40625F;
            this.Line28.Width = 0F;
            this.Line28.X1 = 8.03125F;
            this.Line28.X2 = 8.03125F;
            this.Line28.Y1 = 1.65625F;
            this.Line28.Y2 = 1.40625F;
            // 
            // Line29
            // 
            this.Line29.Height = 0.25F;
            this.Line29.Left = 7.8125F;
            this.Line29.LineWeight = 1F;
            this.Line29.Name = "Line29";
            this.Line29.Top = 1.40625F;
            this.Line29.Width = 0F;
            this.Line29.X1 = 7.8125F;
            this.Line29.X2 = 7.8125F;
            this.Line29.Y1 = 1.65625F;
            this.Line29.Y2 = 1.40625F;
            // 
            // Line30
            // 
            this.Line30.Height = 0.25F;
            this.Line30.Left = 7.59375F;
            this.Line30.LineWeight = 1F;
            this.Line30.Name = "Line30";
            this.Line30.Top = 1.40625F;
            this.Line30.Width = 0F;
            this.Line30.X1 = 7.59375F;
            this.Line30.X2 = 7.59375F;
            this.Line30.Y1 = 1.65625F;
            this.Line30.Y2 = 1.40625F;
            // 
            // Line31
            // 
            this.Line31.Height = 0.25F;
            this.Line31.Left = 7.375F;
            this.Line31.LineWeight = 1F;
            this.Line31.Name = "Line31";
            this.Line31.Top = 1.40625F;
            this.Line31.Width = 0F;
            this.Line31.X1 = 7.375F;
            this.Line31.X2 = 7.375F;
            this.Line31.Y1 = 1.65625F;
            this.Line31.Y2 = 1.40625F;
            // 
            // Line32
            // 
            this.Line32.Height = 0.25F;
            this.Line32.Left = 7.15625F;
            this.Line32.LineWeight = 1F;
            this.Line32.Name = "Line32";
            this.Line32.Top = 1.40625F;
            this.Line32.Width = 0F;
            this.Line32.X1 = 7.15625F;
            this.Line32.X2 = 7.15625F;
            this.Line32.Y1 = 1.65625F;
            this.Line32.Y2 = 1.40625F;
            // 
            // Line33
            // 
            this.Line33.Height = 0.25F;
            this.Line33.Left = 6.9375F;
            this.Line33.LineWeight = 1F;
            this.Line33.Name = "Line33";
            this.Line33.Top = 1.40625F;
            this.Line33.Width = 0F;
            this.Line33.X1 = 6.9375F;
            this.Line33.X2 = 6.9375F;
            this.Line33.Y1 = 1.65625F;
            this.Line33.Y2 = 1.40625F;
            // 
            // Line34
            // 
            this.Line34.Height = 0.25F;
            this.Line34.Left = 6.71875F;
            this.Line34.LineWeight = 1F;
            this.Line34.Name = "Line34";
            this.Line34.Top = 1.40625F;
            this.Line34.Width = 0F;
            this.Line34.X1 = 6.71875F;
            this.Line34.X2 = 6.71875F;
            this.Line34.Y1 = 1.65625F;
            this.Line34.Y2 = 1.40625F;
            // 
            // Line35
            // 
            this.Line35.Height = 0.25F;
            this.Line35.Left = 6.5F;
            this.Line35.LineWeight = 1F;
            this.Line35.Name = "Line35";
            this.Line35.Top = 1.40625F;
            this.Line35.Width = 0F;
            this.Line35.X1 = 6.5F;
            this.Line35.X2 = 6.5F;
            this.Line35.Y1 = 1.65625F;
            this.Line35.Y2 = 1.40625F;
            // 
            // Line36
            // 
            this.Line36.Height = 0.25F;
            this.Line36.Left = 6.28125F;
            this.Line36.LineWeight = 1F;
            this.Line36.Name = "Line36";
            this.Line36.Top = 1.40625F;
            this.Line36.Width = 0F;
            this.Line36.X1 = 6.28125F;
            this.Line36.X2 = 6.28125F;
            this.Line36.Y1 = 1.65625F;
            this.Line36.Y2 = 1.40625F;
            // 
            // Line37
            // 
            this.Line37.Height = 0.25F;
            this.Line37.Left = 6.0625F;
            this.Line37.LineWeight = 1F;
            this.Line37.Name = "Line37";
            this.Line37.Top = 1.40625F;
            this.Line37.Width = 0F;
            this.Line37.X1 = 6.0625F;
            this.Line37.X2 = 6.0625F;
            this.Line37.Y1 = 1.65625F;
            this.Line37.Y2 = 1.40625F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Label11,
            this.Label13,
            this.Label14,
            this.Label15,
            this.Label16,
            this.Label17,
            this.Label18,
            this.Label19,
            this.Label43,
            this.Label44});
            this.PageFooter.Height = 0.2F;
            this.PageFooter.Name = "PageFooter";
            // 
            // Label11
            // 
            this.Label11.Height = 0.2F;
            this.Label11.HyperLink = null;
            this.Label11.Left = 0F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "font-family: Book Antiqua; font-size: 9pt; font-weight: bold";
            this.Label11.Text = "Present: P";
            this.Label11.Top = 0F;
            this.Label11.Width = 0.625F;
            // 
            // Label13
            // 
            this.Label13.Height = 0.2F;
            this.Label13.HyperLink = null;
            this.Label13.Left = 0.671875F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.Label13.Text = "Absent: A";
            this.Label13.Top = 0F;
            this.Label13.Width = 0.65625F;
            // 
            // Label14
            // 
            this.Label14.Height = 0.2F;
            this.Label14.HyperLink = null;
            this.Label14.Left = 1.390625F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.Label14.Text = "Off Day: O";
            this.Label14.Top = 0F;
            this.Label14.Width = 0.75F;
            // 
            // Label15
            // 
            this.Label15.Height = 0.2F;
            this.Label15.HyperLink = null;
            this.Label15.Left = 2.1875F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.Label15.Text = "Rig: R";
            this.Label15.Top = 0F;
            this.Label15.Width = 0.4375F;
            // 
            // Label16
            // 
            this.Label16.Height = 0.2F;
            this.Label16.HyperLink = null;
            this.Label16.Left = 2.6875F;
            this.Label16.Name = "Label16";
            this.Label16.Style = "font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.Label16.Text = "Sick Leave: S";
            this.Label16.Top = 0F;
            this.Label16.Width = 0.875F;
            // 
            // Label17
            // 
            this.Label17.Height = 0.2F;
            this.Label17.HyperLink = null;
            this.Label17.Left = 3.5625F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.Label17.Text = "Umrah/Hajj: U";
            this.Label17.Top = 0F;
            this.Label17.Width = 0.875F;
            // 
            // Label18
            // 
            this.Label18.Height = 0.2F;
            this.Label18.HyperLink = null;
            this.Label18.Left = 4.5F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.Label18.Text = "Vacations: V";
            this.Label18.Top = 0F;
            this.Label18.Width = 0.8125F;
            // 
            // Label19
            // 
            this.Label19.Height = 0.2F;
            this.Label19.HyperLink = null;
            this.Label19.Left = 5.3125F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.Label19.Text = "Holidays: H";
            this.Label19.Top = 0F;
            this.Label19.Width = 0.8125F;
            // 
            // Label43
            // 
            this.Label43.Height = 0.2F;
            this.Label43.HyperLink = null;
            this.Label43.Left = 6.1875F;
            this.Label43.Name = "Label43";
            this.Label43.Style = "font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.Label43.Text = "Paid Vacation Leave: L";
            this.Label43.Top = 0F;
            this.Label43.Width = 1.5F;
            // 
            // Label44
            // 
            this.Label44.Height = 0.2F;
            this.Label44.HyperLink = null;
            this.Label44.Left = 7.75F;
            this.Label44.Name = "Label44";
            this.Label44.Style = "font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.Label44.Text = "Sick Leave(GOSI): I";
            this.Label44.Top = 0F;
            this.Label44.Width = 1.625F;
            // 
            // rptAttendanceDetail
            // 
            this.MasterReport = false;
            this.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 9.989583F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rptAttendanceDetail_ReportStart_1);
            ((System.ComponentModel.ISupportInitialize)(this.d31Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d30Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d29Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d26Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d18Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d15Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d28Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d27Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d25Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d22Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d24Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d23Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d21Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d20Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d19Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d17Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d16Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d14Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d13Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d12Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d11Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d10Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d9Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d8Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d7Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d6Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d5Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d4Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d3Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d2Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d1Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderArabic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    private GrapeCity.ActiveReports.SectionReportModel.Detail Detail;
    private GrapeCity.ActiveReports.SectionReportModel.Shape Shape1;
    private GrapeCity.ActiveReports.SectionReportModel.Label d31Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d30Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d29Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d26Data;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox2;
    private GrapeCity.ActiveReports.SectionReportModel.Label d18Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d15Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d28Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d27Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d25Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d22Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d24Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d23Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d21Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d20Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d19Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d17Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d16Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d14Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d13Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d12Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d11Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d10Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d9Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d8Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d7Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d6Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d5Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d4Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d3Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d2Data;
    private GrapeCity.ActiveReports.SectionReportModel.Label d1Data;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox lblSr;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line9;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line2;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line7;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line8;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line10;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line11;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line12;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line13;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line18;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line19;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line38;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line39;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line40;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line41;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line42;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line43;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line44;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line45;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line46;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line47;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line48;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line49;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line50;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line51;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line52;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line53;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line54;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line55;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line56;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line57;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line58;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line59;
    private GrapeCity.ActiveReports.SectionReportModel.PageHeader PageHeader;
    private GrapeCity.ActiveReports.SectionReportModel.Shape Shape3;
    private GrapeCity.ActiveReports.SectionReportModel.Label lbl2;
    private GrapeCity.ActiveReports.SectionReportModel.Shape Shape2;
    private GrapeCity.ActiveReports.SectionReportModel.Shape Shape;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label5;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox txtHeaderCompany;
    private GrapeCity.ActiveReports.SectionReportModel.Picture Picture;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox txtHeaderArabic;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label1;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label3;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox txtPeriod;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line14;
    private GrapeCity.ActiveReports.SectionReportModel.Label d1;
    private GrapeCity.ActiveReports.SectionReportModel.Label d2;
    private GrapeCity.ActiveReports.SectionReportModel.Label d3;
    private GrapeCity.ActiveReports.SectionReportModel.Label d4;
    private GrapeCity.ActiveReports.SectionReportModel.Label d5;
    private GrapeCity.ActiveReports.SectionReportModel.Label d6;
    private GrapeCity.ActiveReports.SectionReportModel.Label d7;
    private GrapeCity.ActiveReports.SectionReportModel.Label d8;
    private GrapeCity.ActiveReports.SectionReportModel.Label d9;
    private GrapeCity.ActiveReports.SectionReportModel.Label d10;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line26;
    private GrapeCity.ActiveReports.SectionReportModel.Label d11;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line27;
    private GrapeCity.ActiveReports.SectionReportModel.Label d12;
    private GrapeCity.ActiveReports.SectionReportModel.Label d13;
    private GrapeCity.ActiveReports.SectionReportModel.Label d14;
    private GrapeCity.ActiveReports.SectionReportModel.Label d16;
    private GrapeCity.ActiveReports.SectionReportModel.Label d17;
    private GrapeCity.ActiveReports.SectionReportModel.Label d18;
    private GrapeCity.ActiveReports.SectionReportModel.Label d19;
    private GrapeCity.ActiveReports.SectionReportModel.Label d20;
    private GrapeCity.ActiveReports.SectionReportModel.Label d21;
    private GrapeCity.ActiveReports.SectionReportModel.Label d23;
    private GrapeCity.ActiveReports.SectionReportModel.Label d24;
    private GrapeCity.ActiveReports.SectionReportModel.Label d26;
    private GrapeCity.ActiveReports.SectionReportModel.Label d22;
    private GrapeCity.ActiveReports.SectionReportModel.Label d25;
    private GrapeCity.ActiveReports.SectionReportModel.Label d27;
    private GrapeCity.ActiveReports.SectionReportModel.Label d28;
    private GrapeCity.ActiveReports.SectionReportModel.Label d29;
    private GrapeCity.ActiveReports.SectionReportModel.Label d30;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line84;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line85;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line86;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line87;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line88;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line89;
    private GrapeCity.ActiveReports.SectionReportModel.Label d31;
    private GrapeCity.ActiveReports.SectionReportModel.Label d15;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line1;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line3;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line4;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line5;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line6;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line15;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line16;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line17;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line20;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line21;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line22;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line23;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line24;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line25;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line28;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line29;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line30;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line31;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line32;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line33;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line34;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line35;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line36;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line37;
    private GrapeCity.ActiveReports.SectionReportModel.PageFooter PageFooter;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label11;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label13;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label14;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label15;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label16;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label17;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label18;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label19;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label43;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label44;
    

    private void rptAttendanceDetail_ReportStart_1(object sender, EventArgs e)
    {
        txtPeriod.Text = this.Parameters[0].Value;
        DataTable data = (DataTable)this.DataSource;
        if (data.Rows.Count > 0)
        {
            try
            {
                int Index = 0;
                foreach (DataColumn col in data.Columns)
                {
                    switch (Index)
                    {
                        case 2:
                            d1.Text = col.ColumnName;
                            d1Data.DataField = col.ColumnName;
                            break;

                        case 3:
                            d2.Text = col.ColumnName;
                            d2Data.DataField = col.ColumnName;
                            break;
                        case 4:
                            d3.Text = col.ColumnName;
                            d3Data.DataField = col.ColumnName;
                            break;
                        case 5:
                            d4.Text = col.ColumnName;
                            d4Data.DataField = col.ColumnName;
                            break;
                        case 6:
                            d5.Text = col.ColumnName;
                            d5Data.DataField = col.ColumnName;
                            break;
                        case 7:
                            d6.Text = col.ColumnName;
                            d6Data.DataField = col.ColumnName;
                            break;
                        case 8:
                            d7.Text = col.ColumnName;
                            d7Data.DataField = col.ColumnName;
                            break;
                        case 9:
                            d8.Text = col.ColumnName;
                            d8Data.DataField = col.ColumnName;
                            break;
                        case 10:
                            d9.Text = col.ColumnName;
                            d9Data.DataField = col.ColumnName;
                            break;
                        case 11:
                            d10.Text = col.ColumnName;
                            d10Data.DataField = col.ColumnName;
                            break;
                        case 12:
                            d11.Text = col.ColumnName;
                            d11Data.DataField = col.ColumnName;
                            break;
                        case 13:
                            d12.Text = col.ColumnName;
                            d12Data.DataField = col.ColumnName;
                            break;
                        case 14:
                            d13.Text = col.ColumnName;
                            d13Data.DataField = col.ColumnName;
                            break;
                        case 15:
                            d14.Text = col.ColumnName;
                            d14Data.DataField = col.ColumnName;
                            break;
                        case 16:
                            d15.Text = col.ColumnName;
                            d15Data.DataField = col.ColumnName;
                            break;
                        case 17:
                            d16.Text = col.ColumnName;
                            d16Data.DataField = col.ColumnName;
                            break;
                        case 18:
                            d17.Text = col.ColumnName;
                            d17Data.DataField = col.ColumnName;
                            break;
                        case 19:
                            d18.Text = col.ColumnName;
                            d18Data.DataField = col.ColumnName;
                            break;
                        case 20:
                            d19.Text = col.ColumnName;
                            d19Data.DataField = col.ColumnName;
                            break;
                        case 21:
                            d20.Text = col.ColumnName;
                            d20Data.DataField = col.ColumnName;
                            break;
                        case 22:
                            d21.Text = col.ColumnName;
                            d21Data.DataField = col.ColumnName;
                            break;
                        case 23:
                            d22.Text = col.ColumnName;
                            d22Data.DataField = col.ColumnName;
                            break;
                        case 24:
                            d23.Text = col.ColumnName;
                            d23Data.DataField = col.ColumnName;
                            break;
                        case 25:
                            d24.Text = col.ColumnName;
                            d24Data.DataField = col.ColumnName;
                            break;
                        case 26:
                            d25.Text = col.ColumnName;
                            d25Data.DataField = col.ColumnName;
                            break;
                        case 27:
                            d26.Text = col.ColumnName;
                            d26Data.DataField = col.ColumnName;
                            break;
                        case 28:
                            d27.Text = col.ColumnName;
                            d27Data.DataField = col.ColumnName;
                            break;
                        case 29:
                            d28.Text = col.ColumnName;
                            d28Data.DataField = col.ColumnName;
                            break;
                        case 30:
                            d29.Text = col.ColumnName;
                            d29Data.DataField = col.ColumnName;
                            break;
                        case 31:
                            d30.Text = col.ColumnName;
                            d30Data.DataField = col.ColumnName;
                            break;
                        case 32:
                            d31.Text = col.ColumnName;
                            d31Data.DataField = col.ColumnName;
                            break;


                    }
                    Index++;
                }
            }
            catch (Exception ex) { }
        }
    }
}