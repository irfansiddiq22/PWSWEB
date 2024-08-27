using Pipewellservice.Helper;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using GrapeCity.ActiveReports;
using Pipewellservice.App_Start;
using PipewellserviceModels.Equipment;

namespace Pipewellservice.Reports
{

    public partial class rptEquipmentQuote : GrapeCity.ActiveReports.SectionReport
    {
        public rptEquipmentQuote()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptEquipmentQuote));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox7 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox8 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.lblRowIndex = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.lblCompName = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtHeaderCompany = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Picture = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.txtHeaderArabic = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtDate = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.textBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtSupplier = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.txtRFQ = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox14 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox15 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtQuoteDate = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label15 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label16 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCompName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderArabic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuoteDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.lblRowIndex});
            this.Detail.Height = 0.2F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // textBox2
            // 
            this.textBox2.DataField = "PartNumber";
            this.textBox2.Height = 0.2F;
            this.textBox2.Left = 0.6440001F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "color: Black; font-size: 8.25pt; text-justify: auto; vertical-align: bottom";
            this.textBox2.SummaryGroup = "";
            this.textBox2.Text = null;
            this.textBox2.Top = 0F;
            this.textBox2.Width = 1.246F;
            // 
            // textBox3
            // 
            this.textBox3.DataField = "PartName";
            this.textBox3.DistinctField = "";
            this.textBox3.Height = 0.2F;
            this.textBox3.Left = 1.9F;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "color: Black; font-size: 8.25pt; vertical-align: bottom";
            this.textBox3.SummaryGroup = "";
            this.textBox3.Text = "PartName";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 1.475F;
            // 
            // textBox4
            // 
            this.textBox4.DataField = "Description";
            this.textBox4.DistinctField = "";
            this.textBox4.Height = 0.2F;
            this.textBox4.Left = 3.375F;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "color: Black; font-size: 8.25pt; text-align: center; vertical-align: bottom";
            this.textBox4.SummaryGroup = "";
            this.textBox4.Text = "Description";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 2.608F;
            // 
            // textBox6
            // 
            this.textBox6.DataField = "Quantity";
            this.textBox6.DistinctField = "";
            this.textBox6.Height = 0.2F;
            this.textBox6.Left = 5.983F;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "color: Black; font-size: 8.25pt; text-align: center; vertical-align: bottom";
            this.textBox6.SummaryGroup = "";
            this.textBox6.Text = null;
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.4520003F;
            // 
            // textBox7
            // 
            this.textBox7.DataField = "UnitPrice";
            this.textBox7.DistinctField = "";
            this.textBox7.Height = 0.2F;
            this.textBox7.Left = 6.478F;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "color: Black; font-size: 8.25pt; text-align: center; vertical-align: bottom";
            this.textBox7.SummaryGroup = "";
            this.textBox7.Text = null;
            this.textBox7.Top = 0F;
            this.textBox7.Width = 0.7699997F;
            // 
            // textBox8
            // 
            this.textBox8.DataField = "=UnitPrice*Quantity";
            this.textBox8.DistinctField = "";
            this.textBox8.Height = 0.2F;
            this.textBox8.Left = 7.247999F;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "color: Black; font-size: 8.25pt; text-align: center; vertical-align: bottom";
            this.textBox8.SummaryGroup = "";
            this.textBox8.Text = "TextBox1";
            this.textBox8.Top = 0F;
            this.textBox8.Width = 1.231F;
            // 
            // lblRowIndex
            // 
            this.lblRowIndex.DataField = "";
            this.lblRowIndex.Height = 0.2F;
            this.lblRowIndex.HyperLink = null;
            this.lblRowIndex.Left = 0.067F;
            this.lblRowIndex.Name = "lblRowIndex";
            this.lblRowIndex.Style = "color: Black; text-align: center; vertical-align: bottom";
            this.lblRowIndex.Text = "";
            this.lblRowIndex.Top = 0F;
            this.lblRowIndex.Width = 0.587F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.lblCompName,
            this.Label,
            this.txtHeaderCompany,
            this.Picture,
            this.txtHeaderArabic,
            this.Label1,
            this.txtDate,
            this.line1,
            this.line2,
            this.textBox5,
            this.txtSupplier,
            this.line3,
            this.txtRFQ,
            this.textBox14,
            this.textBox15,
            this.txtQuoteDate,
            this.line4,
            this.label5,
            this.label8,
            this.label13,
            this.label15,
            this.label16,
            this.label2,
            this.label3});
            this.PageHeader.Height = 2.427083F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // lblCompName
            // 
            this.lblCompName.Height = 0.875F;
            this.lblCompName.HyperLink = null;
            this.lblCompName.Left = 8.822917F;
            this.lblCompName.Name = "lblCompName";
            this.lblCompName.Style = "color: Black; font-size: 8.25pt; font-weight: bold";
            this.lblCompName.Text = "";
            this.lblCompName.Top = 0F;
            this.lblCompName.Width = 3.9375F;
            // 
            // Label
            // 
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0.0625F;
            this.Label.Name = "Label";
            this.Label.Style = "color: Black; font-size: 8.25pt; font-weight: bold; vertical-align: bottom";
            this.Label.Text = "Print Date and Time";
            this.Label.Top = 0F;
            this.Label.Width = 1.125F;
            // 
            // txtHeaderCompany
            // 
            this.txtHeaderCompany.Height = 0.3125F;
            this.txtHeaderCompany.Left = 0.0625F;
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
            this.Picture.Left = 3.375F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch;
            this.Picture.Top = 0F;
            this.Picture.Width = 1.0625F;
            // 
            // txtHeaderArabic
            // 
            this.txtHeaderArabic.Height = 0.375F;
            this.txtHeaderArabic.Left = 4.469F;
            this.txtHeaderArabic.Name = "txtHeaderArabic";
            this.txtHeaderArabic.ShrinkToFit = true;
            this.txtHeaderArabic.Style = "color: Black; font-family: Tajawal; font-size: 21.75pt; font-weight: bold; text-a" +
    "lign: center; ddo-char-set: 1; ddo-shrink-to-fit: true";
            this.txtHeaderArabic.Text = null;
            this.txtHeaderArabic.Top = 0.312F;
            this.txtHeaderArabic.Width = 3.959001F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 2.3F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "color: Black; font-family: Book Antiqua; font-size: 12pt; font-weight: bold; text" +
    "-align: center; text-decoration: underline; ddo-char-set: 1";
            this.Label1.Text = "QUOTATION";
            this.Label1.Top = 1.03F;
            this.Label1.Width = 3.4375F;
            // 
            // txtDate
            // 
            this.txtDate.DataField = "";
            this.txtDate.DistinctField = "";
            this.txtDate.Height = 0.2F;
            this.txtDate.Left = 1.187F;
            this.txtDate.Name = "txtDate";
            this.txtDate.OutputFormat = resources.GetString("txtDate.OutputFormat");
            this.txtDate.Style = "color: Black; font-size: 8.25pt; vertical-align: bottom";
            this.txtDate.SummaryGroup = "";
            this.txtDate.Text = "TextBox1";
            this.txtDate.Top = 0F;
            this.txtDate.Width = 1.3125F;
            // 
            // line1
            // 
            this.line1.Height = 0F;
            this.line1.Left = 2.384186E-07F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 1.28F;
            this.line1.Width = 8.5F;
            this.line1.X1 = 2.384186E-07F;
            this.line1.X2 = 8.5F;
            this.line1.Y1 = 1.28F;
            this.line1.Y2 = 1.28F;
            // 
            // line2
            // 
            this.line2.Height = 0F;
            this.line2.Left = 2.384186E-07F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 1.025F;
            this.line2.Width = 8.5F;
            this.line2.X1 = 2.384186E-07F;
            this.line2.X2 = 8.5F;
            this.line2.Y1 = 1.025F;
            this.line2.Y2 = 1.025F;
            // 
            // textBox5
            // 
            this.textBox5.DistinctField = "";
            this.textBox5.Height = 0.2F;
            this.textBox5.Left = 0.06700015F;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "color: Black; font-size: 8.25pt; font-weight: bold; vertical-align: bottom";
            this.textBox5.SummaryGroup = "";
            this.textBox5.Text = "Attn:";
            this.textBox5.Top = 1.352F;
            this.textBox5.Width = 0.6200001F;
            // 
            // txtSupplier
            // 
            this.txtSupplier.DistinctField = "";
            this.txtSupplier.Height = 0.189F;
            this.txtSupplier.Left = 0.687F;
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Style = "color: Black";
            this.txtSupplier.SummaryGroup = "";
            this.txtSupplier.Text = "textBox10";
            this.txtSupplier.Top = 1.352F;
            this.txtSupplier.Width = 2.983F;
            // 
            // line3
            // 
            this.line3.Height = 0.75F;
            this.line3.Left = 4F;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 1.28F;
            this.line3.Width = 0F;
            this.line3.X1 = 4F;
            this.line3.X2 = 4F;
            this.line3.Y1 = 1.28F;
            this.line3.Y2 = 2.03F;
            // 
            // txtRFQ
            // 
            this.txtRFQ.DistinctField = "";
            this.txtRFQ.Height = 0.189F;
            this.txtRFQ.Left = 4.900001F;
            this.txtRFQ.Name = "txtRFQ";
            this.txtRFQ.Style = "color: Black";
            this.txtRFQ.SummaryGroup = "";
            this.txtRFQ.Text = null;
            this.txtRFQ.Top = 1.352F;
            this.txtRFQ.Width = 2.983F;
            // 
            // textBox14
            // 
            this.textBox14.DistinctField = "";
            this.textBox14.Height = 0.2F;
            this.textBox14.Left = 4.05F;
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
            this.textBox14.Style = "color: Black; font-size: 8.25pt; font-weight: bold; vertical-align: bottom";
            this.textBox14.SummaryGroup = "";
            this.textBox14.Text = "RFQ No.";
            this.textBox14.Top = 1.352F;
            this.textBox14.Width = 0.6200001F;
            // 
            // textBox15
            // 
            this.textBox15.DistinctField = "";
            this.textBox15.Height = 0.2F;
            this.textBox15.Left = 4.05F;
            this.textBox15.Name = "textBox15";
            this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
            this.textBox15.Style = "color: Black; font-size: 8.25pt; font-weight: bold; vertical-align: bottom";
            this.textBox15.SummaryGroup = "";
            this.textBox15.Text = "Date:";
            this.textBox15.Top = 1.581F;
            this.textBox15.Width = 0.6200001F;
            // 
            // txtQuoteDate
            // 
            this.txtQuoteDate.DistinctField = "";
            this.txtQuoteDate.Height = 0.189F;
            this.txtQuoteDate.Left = 4.9F;
            this.txtQuoteDate.Name = "txtQuoteDate";
            this.txtQuoteDate.OutputFormat = resources.GetString("txtQuoteDate.OutputFormat");
            this.txtQuoteDate.Style = "color: Black";
            this.txtQuoteDate.SummaryGroup = "";
            this.txtQuoteDate.Text = "textBox10";
            this.txtQuoteDate.Top = 1.581F;
            this.txtQuoteDate.Width = 2.983F;
            // 
            // line4
            // 
            this.line4.Height = 0F;
            this.line4.Left = 0F;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 2.049F;
            this.line4.Width = 8.5F;
            this.line4.X1 = 0F;
            this.line4.X2 = 8.5F;
            this.line4.Y1 = 2.049F;
            this.line4.Y2 = 2.049F;
            // 
            // label5
            // 
            this.label5.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label5.Height = 0.2F;
            this.label5.HyperLink = null;
            this.label5.Left = 0.02F;
            this.label5.Name = "label5";
            this.label5.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center";
            this.label5.Text = "Sr#";
            this.label5.Top = 2.227F;
            this.label5.Width = 0.6245F;
            // 
            // label8
            // 
            this.label8.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label8.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label8.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label8.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label8.Height = 0.2F;
            this.label8.HyperLink = null;
            this.label8.Left = 3.375F;
            this.label8.Name = "label8";
            this.label8.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; ddo-char-set: 1";
            this.label8.Text = "Description";
            this.label8.Top = 2.227F;
            this.label8.Width = 2.608F;
            // 
            // label13
            // 
            this.label13.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label13.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label13.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label13.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label13.Height = 0.2F;
            this.label13.HyperLink = null;
            this.label13.Left = 5.983F;
            this.label13.Name = "label13";
            this.label13.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center";
            this.label13.Text = "Qty";
            this.label13.Top = 2.227F;
            this.label13.Width = 0.4520003F;
            // 
            // label15
            // 
            this.label15.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label15.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label15.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label15.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label15.Height = 0.2F;
            this.label15.HyperLink = null;
            this.label15.Left = 6.478F;
            this.label15.Name = "label15";
            this.label15.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center";
            this.label15.Text = "Unit Price";
            this.label15.Top = 2.227F;
            this.label15.Width = 0.7699997F;
            // 
            // label16
            // 
            this.label16.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label16.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label16.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label16.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label16.Height = 0.2F;
            this.label16.HyperLink = null;
            this.label16.Left = 7.247999F;
            this.label16.Name = "label16";
            this.label16.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center";
            this.label16.Text = "Total Amount";
            this.label16.Top = 2.227F;
            this.label16.Width = 1.231F;
            // 
            // label2
            // 
            this.label2.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label2.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label2.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label2.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label2.Height = 0.2F;
            this.label2.HyperLink = null;
            this.label2.Left = 0.6440001F;
            this.label2.Name = "label2";
            this.label2.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center";
            this.label2.Text = "Item No\t";
            this.label2.Top = 2.227F;
            this.label2.Width = 1.246F;
            // 
            // label3
            // 
            this.label3.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label3.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label3.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label3.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.label3.Height = 0.2F;
            this.label3.HyperLink = null;
            this.label3.Left = 1.9F;
            this.label3.Name = "label3";
            this.label3.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center";
            this.label3.Text = "Item Name";
            this.label3.Top = 2.227F;
            this.label3.Width = 1.475F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0.2916667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // rptEquipmentQuote
            // 
            this.MasterReport = false;
            this.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.489F;
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
            this.ReportStart += new System.EventHandler(this.rpEmployeeAttendenceInOut_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCompName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderArabic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuoteDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        private GrapeCity.ActiveReports.SectionReportModel.Detail Detail;
            private GrapeCity.ActiveReports.SectionReportModel.PageHeader PageHeader;
            private GrapeCity.ActiveReports.SectionReportModel.Label lblCompName;
            private GrapeCity.ActiveReports.SectionReportModel.Label Label;
            private GrapeCity.ActiveReports.SectionReportModel.TextBox txtHeaderCompany;
            private GrapeCity.ActiveReports.SectionReportModel.Picture Picture;
            private GrapeCity.ActiveReports.SectionReportModel.TextBox txtHeaderArabic;
            private GrapeCity.ActiveReports.SectionReportModel.Label Label1;
            private GrapeCity.ActiveReports.SectionReportModel.PageFooter PageFooter;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtDate;
        private GrapeCity.ActiveReports.SectionReportModel.Line line1;
        private GrapeCity.ActiveReports.SectionReportModel.Line line2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtSupplier;
        private GrapeCity.ActiveReports.SectionReportModel.Line line3;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtRFQ;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox14;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox15;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtQuoteDate;
        private GrapeCity.ActiveReports.SectionReportModel.Line line4;
        private GrapeCity.ActiveReports.SectionReportModel.Label label5;
        private GrapeCity.ActiveReports.SectionReportModel.Label label8;
        private GrapeCity.ActiveReports.SectionReportModel.Label label13;
        private GrapeCity.ActiveReports.SectionReportModel.Label label15;
        private GrapeCity.ActiveReports.SectionReportModel.Label label16;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox3;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox6;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox7;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox8;
        private GrapeCity.ActiveReports.SectionReportModel.Label label2;
        private GrapeCity.ActiveReports.SectionReportModel.Label label3;
        private GrapeCity.ActiveReports.SectionReportModel.Label lblRowIndex;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox5;

            private void rpEmployeeInquiry_ReportStart(object sender, System.EventArgs e)
        {
          /*  TextBox1.Text = System.DateTime.Now.ToString();
            //this.Document.CacheToDisk = true;
            List<EmployeeInquiryReport> data = (List<EmployeeInquiryReport>)this.DataSource;
            if (data.Count > 0)
            {
                try
                {
                    if (data[0].ApprovalSign1 != null)
                        this.Picture1.Image = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(new MemoryStream(data[0].ApprovalSign1)));
                    if (data[0].ApprovalSign2 != null)
                        this.Picture2.Image = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(new MemoryStream(data[0].ApprovalSign2)));
                    if (data[0].ApprovalSign3 != null)
                        this.Picture3.Image = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(new MemoryStream(data[0].ApprovalSign3)));
                    if (data[0].ApprovalSign4 != null)
                        this.Picture4.Image = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(new MemoryStream(data[0].ApprovalSign4)));
                    if (data[0].EmployeePicture != null)
                    {
                        string File = FileHelper.GetFile1(data[0].EmployeePicture, data[0].EmployeeID, DirectoryNames.EmployeePictures); ;
                        this.Picture5.Image = new System.Drawing.Bitmap(System.Drawing.Image.FromFile(File));
                    }
                }catch(Exception ex) { }*/
            }
        int count = 0;

        private void rpEmployeeAttendenceInOut_ReportStart(object sender, EventArgs e)
        {
            txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
           
            List<Constant> cont = AppData.Constants.FindAll(x => x.ParentID == (int)ParentEnums.REPORTHEADER);
            txtHeaderArabic.Text = cont.Find(x => x.Value == 5).Name;
            txtHeaderCompany.Text = cont.Find(x => x.Value == 4).Name;
            count = 0;
            EquipmentQuoteList data =(EquipmentQuoteList) this.UserData;
            txtSupplier.Text = data.Supplier;
            txtRFQ.Text = data.RFQNumber;
            txtQuoteDate.Text = data.QuoteDate.ToString("dd/MM/yyyy");

        }

        private void PageHeader_Format(object sender, EventArgs e)
        {
            
        }

        private void Detail_Format(object sender, EventArgs e)
        {
            count++;
            lblRowIndex.Text = count.ToString();
        }
    }
    
}