using Pipewellservice.Helper;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace Pipewellservice.Reports
{

    public partial class rpEmployeeInquiry : GrapeCity.ActiveReports.SectionReport
    {
        public rpEmployeeInquiry()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpEmployeeInquiry));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.TextBox7 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtHeaderCompany = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Picture = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.txtHeaderArabic = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Picture5 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.TextBox13 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox14 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox15 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label16 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label17 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label15 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Shape4 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtFooter1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFooter3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Shape1 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line10 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line11 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.TextBox8 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox9 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox10 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox11 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox16 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Picture2 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.Picture3 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.Picture4 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.Line12 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox24 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox12 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Picture1 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.TextBox17 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label18 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label19 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label20 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.chkPersonal = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.chkLoan = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.chkGeneral = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Label21 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox18 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Picture6 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.TextBox19 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderArabic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFooter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFooter3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.TextBox7});
            this.Detail.Height = 0.1875F;
            this.Detail.Name = "Detail";
            // 
            // TextBox7
            // 
            this.TextBox7.DataField = "Remarks";
            this.TextBox7.Height = 0.1875F;
            this.TextBox7.Left = 0.2F;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt";
            this.TextBox7.Text = null;
            this.TextBox7.Top = 0F;
            this.TextBox7.Width = 7.375F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.TextBox1,
            this.Label,
            this.txtHeaderCompany,
            this.Picture,
            this.txtHeaderArabic,
            this.Label2,
            this.Label3,
            this.Label4,
            this.Label6,
            this.Label7,
            this.Label8,
            this.TextBox,
            this.TextBox2,
            this.TextBox3,
            this.TextBox4,
            this.TextBox6,
            this.TextBox5,
            this.Label5,
            this.Label9,
            this.Label1,
            this.Picture5});
            this.PageHeader.Height = 3.177083F;
            this.PageHeader.Name = "PageHeader";
            // 
            // TextBox1
            // 
            this.TextBox1.DataField = "=System.DateTime.Now";
            this.TextBox1.Height = 0.2F;
            this.TextBox1.Left = 1.25F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat");
            this.TextBox1.Style = "color: Black; font-size: 8.25pt; vertical-align: bottom";
            this.TextBox1.Text = "TextBox1";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 1.3125F;
            // 
            // Label
            // 
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0.06250024F;
            this.Label.Name = "Label";
            this.Label.Style = "color: Black; font-size: 8.25pt; font-weight: bold; vertical-align: bottom";
            this.Label.Text = "Print Date and Time";
            this.Label.Top = 0F;
            this.Label.Width = 1.125F;
            // 
            // txtHeaderCompany
            // 
            this.txtHeaderCompany.Height = 0.3125F;
            this.txtHeaderCompany.Left = 2.384186E-07F;
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
            this.Picture.HyperLink = null;
            this.Picture.ImageData = ((System.IO.Stream)(resources.GetObject("Picture.ImageData")));
            this.Picture.Left = 3.25F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch;
            this.Picture.Top = 0F;
            this.Picture.Width = 1.0625F;
            // 
            // txtHeaderArabic
            // 
            this.txtHeaderArabic.Height = 0.375F;
            this.txtHeaderArabic.Left = 4.21875F;
            this.txtHeaderArabic.Name = "txtHeaderArabic";
            this.txtHeaderArabic.Style = "color: Black; font-family: Arabic Typesetting; font-size: 21.75pt; font-weight: b" +
    "old; text-align: center; ddo-char-set: 0";
            this.txtHeaderArabic.Text = null;
            this.txtHeaderArabic.Top = 0.3125F;
            this.txtHeaderArabic.Width = 3.375F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0.5004995F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: right";
            this.Label2.Text = "Employee Name:";
            this.Label2.Top = 1.703125F;
            this.Label2.Width = 1.125F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0.5004995F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: right";
            this.Label3.Text = "Employee ID:";
            this.Label3.Top = 1.89625F;
            this.Label3.Width = 1.125F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 0.5004995F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: right";
            this.Label4.Text = "Phone:";
            this.Label4.Top = 2.1F;
            this.Label4.Width = 1.125F;
            // 
            // Label6
            // 
            this.Label6.Height = 0.2F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 0.5004995F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: right";
            this.Label6.Text = "Date Requested:";
            this.Label6.Top = 1.484375F;
            this.Label6.Width = 1.125F;
            // 
            // Label7
            // 
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = null;
            this.Label7.Left = 0.7504995F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: right";
            this.Label7.Text = "Department:";
            this.Label7.Top = 2.521875F;
            this.Label7.Width = 0.875F;
            // 
            // Label8
            // 
            this.Label8.Height = 0.2F;
            this.Label8.HyperLink = null;
            this.Label8.Left = 0.7504995F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: right";
            this.Label8.Text = "Position:";
            this.Label8.Top = 2.318125F;
            this.Label8.Width = 0.875F;
            // 
            // TextBox
            // 
            this.TextBox.DataField = "EmployeeName";
            this.TextBox.Height = 0.2F;
            this.TextBox.Left = 1.6875F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "color: Black";
            this.TextBox.Text = null;
            this.TextBox.Top = 1.703125F;
            this.TextBox.Width = 3.6875F;
            // 
            // TextBox2
            // 
            this.TextBox2.DataField = "EmployeeID";
            this.TextBox2.Height = 0.2F;
            this.TextBox2.Left = 1.6875F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Style = "color: Black";
            this.TextBox2.Text = null;
            this.TextBox2.Top = 1.89625F;
            this.TextBox2.Width = 2.375F;
            // 
            // TextBox3
            // 
            this.TextBox3.DataField = "PhoneNumber";
            this.TextBox3.Height = 0.2F;
            this.TextBox3.Left = 1.6885F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Style = "color: Black";
            this.TextBox3.Text = null;
            this.TextBox3.Top = 2.1F;
            this.TextBox3.Width = 3.6865F;
            // 
            // TextBox4
            // 
            this.TextBox4.DataField = "InquiryDate";
            this.TextBox4.Height = 0.2F;
            this.TextBox4.Left = 1.6875F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "color: Black";
            this.TextBox4.Text = null;
            this.TextBox4.Top = 1.484375F;
            this.TextBox4.Width = 3.0625F;
            // 
            // TextBox6
            // 
            this.TextBox6.DataField = "Division";
            this.TextBox6.Height = 0.2F;
            this.TextBox6.Left = 1.6875F;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.Style = "color: Black";
            this.TextBox6.Text = null;
            this.TextBox6.Top = 2.521875F;
            this.TextBox6.Width = 3.75F;
            // 
            // TextBox5
            // 
            this.TextBox5.DataField = "Position";
            this.TextBox5.Height = 0.2F;
            this.TextBox5.Left = 1.688499F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Style = "color: Black";
            this.TextBox5.Text = null;
            this.TextBox5.Top = 2.318125F;
            this.TextBox5.Width = 3.749002F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 0.06200024F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "background-color: Black; color: White; font-size: 9.75pt; font-weight: bold; text" +
    "-align: center";
            this.Label5.Text = "Employee Information";
            this.Label5.Top = 1.265625F;
            this.Label5.Width = 7.5005F;
            // 
            // Label9
            // 
            this.Label9.Height = 0.2F;
            this.Label9.HyperLink = null;
            this.Label9.Left = 0.06200024F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "background-color: Black; color: White; font-size: 9.75pt; font-weight: bold; text" +
    "-align: center";
            this.Label9.Text = "Inquiry Details";
            this.Label9.Top = 2.953125F;
            this.Label9.Width = 7.5005F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 2F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "color: Black; font-family: Book Antiqua; font-size: 12pt; font-weight: bold; text" +
    "-align: center; text-decoration: underline; ddo-char-set: 1";
            this.Label1.Text = "E M P L O Y E E   I N Q U I R Y   F O R M ";
            this.Label1.Top = 1F;
            this.Label1.Width = 3.625F;
            // 
            // Picture5
            // 
            this.Picture5.DataField = "EmpImg";
            this.Picture5.Height = 1.375F;
            this.Picture5.HyperLink = null;
            this.Picture5.ImageData = null;
            this.Picture5.Left = 5.875F;
            this.Picture5.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture5.Name = "Picture5";
            this.Picture5.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch;
            this.Picture5.Top = 1.5F;
            this.Picture5.Width = 1.375F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.TextBox13,
            this.TextBox14,
            this.TextBox15,
            this.Label16,
            this.Label17,
            this.Label14,
            this.Label15,
            this.Shape4,
            this.txtFooter1,
            this.txtFooter3,
            this.Shape1,
            this.Label10,
            this.Label11,
            this.Label12,
            this.Line1,
            this.Line3,
            this.Line4,
            this.Line10,
            this.Line11,
            this.TextBox8,
            this.TextBox9,
            this.TextBox10,
            this.TextBox11,
            this.TextBox16,
            this.Picture2,
            this.Picture3,
            this.Picture4,
            this.Line12,
            this.Label13,
            this.TextBox24,
            this.TextBox12,
            this.Picture1,
            this.TextBox17,
            this.Label18,
            this.Label19,
            this.Label20,
            this.chkPersonal,
            this.chkLoan,
            this.chkGeneral,
            this.Line2,
            this.Label21,
            this.TextBox18,
            this.Picture6,
            this.TextBox19});
            this.PageFooter.Height = 4.304375F;
            this.PageFooter.Name = "PageFooter";
            // 
            // TextBox13
            // 
            this.TextBox13.DataField = "ApprovalRemarks1";
            this.TextBox13.Height = 0.4375F;
            this.TextBox13.Left = 0.48125F;
            this.TextBox13.Name = "TextBox13";
            this.TextBox13.Style = "color: Black; font-family: Book Antiqua; font-size: 12pt; font-style: italic; fon" +
    "t-weight: bold; ddo-char-set: 1";
            this.TextBox13.Text = null;
            this.TextBox13.Top = 0F;
            this.TextBox13.Visible = false;
            this.TextBox13.Width = 7.1875F;
            // 
            // TextBox14
            // 
            this.TextBox14.DataField = "ApprovalRemarks2";
            this.TextBox14.Height = 0.4375F;
            this.TextBox14.Left = 0.48125F;
            this.TextBox14.Name = "TextBox14";
            this.TextBox14.Style = "color: Black; font-family: Book Antiqua; font-size: 12pt; font-style: italic; fon" +
    "t-weight: bold; ddo-char-set: 1";
            this.TextBox14.Text = null;
            this.TextBox14.Top = 0.421875F;
            this.TextBox14.Visible = false;
            this.TextBox14.Width = 7.1875F;
            // 
            // TextBox15
            // 
            this.TextBox15.DataField = "ApprovalRemarks3";
            this.TextBox15.Height = 0.4375F;
            this.TextBox15.Left = 0.48125F;
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.Style = "color: Black; font-family: Book Antiqua; font-size: 12pt; font-style: italic; fon" +
    "t-weight: bold; ddo-char-set: 1";
            this.TextBox15.Text = null;
            this.TextBox15.Top = 0.890625F;
            this.TextBox15.Visible = false;
            this.TextBox15.Width = 7.1875F;
            // 
            // Label16
            // 
            this.Label16.Height = 0.125F;
            this.Label16.HyperLink = null;
            this.Label16.Left = 0.10625F;
            this.Label16.Name = "Label16";
            this.Label16.Style = "color: Black; font-family: Book Antiqua; font-size: 7pt; font-weight: bold; text-" +
    "align: left; ddo-char-set: 1";
            this.Label16.Text = "* Note2";
            this.Label16.Top = 0.484375F;
            this.Label16.Visible = false;
            this.Label16.Width = 0.375F;
            // 
            // Label17
            // 
            this.Label17.Height = 0.125F;
            this.Label17.HyperLink = null;
            this.Label17.Left = 0.10625F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "color: Black; font-family: Book Antiqua; font-size: 7pt; font-weight: bold; text-" +
    "align: left; ddo-char-set: 1";
            this.Label17.Text = "* Note3";
            this.Label17.Top = 0.921875F;
            this.Label17.Visible = false;
            this.Label17.Width = 0.375F;
            // 
            // Label14
            // 
            this.Label14.Height = 0.125F;
            this.Label14.HyperLink = null;
            this.Label14.Left = 0.10625F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "color: Black; font-family: Book Antiqua; font-size: 7pt; font-weight: bold; text-" +
    "align: left; ddo-char-set: 1";
            this.Label14.Text = "* Note1";
            this.Label14.Top = 0.03020833F;
            this.Label14.Visible = false;
            this.Label14.Width = 0.375F;
            // 
            // Label15
            // 
            this.Label15.Height = 0.2F;
            this.Label15.HyperLink = null;
            this.Label15.Left = 0.153F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "background-color: Black; color: White; font-size: 9.75pt; font-weight: bold; text" +
    "-align: center";
            this.Label15.Text = "For Human Resource Use Only";
            this.Label15.Top = 1.328F;
            this.Label15.Width = 7.5155F;
            // 
            // Shape4
            // 
            this.Shape4.BackColor = System.Drawing.Color.White;
            this.Shape4.Height = 0.01041663F;
            this.Shape4.Left = 0.03212571F;
            this.Shape4.Name = "Shape4";
            this.Shape4.RoundingRadius = 9.999999F;
            this.Shape4.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect;
            this.Shape4.Top = 3.544375F;
            this.Shape4.Width = 7.75F;
            // 
            // txtFooter1
            // 
            this.txtFooter1.Height = 0.1875F;
            this.txtFooter1.Left = 0.09412571F;
            this.txtFooter1.Name = "txtFooter1";
            this.txtFooter1.Style = "color: Black; font-family: Book Antiqua; font-size: 8.25pt; text-align: center; d" +
    "do-char-set: 1";
            this.txtFooter1.Text = "C.R. 2050022534 - P.O. Box 2010 Dammam 31451 – Saudi Arabia – Telex: 803 505 QAHB" +
    "RO SJ. – Fax: 8593772 – Tel: 8592286/8594716";
            this.txtFooter1.Top = 3.606875F;
            this.txtFooter1.Width = 7.469F;
            // 
            // txtFooter3
            // 
            this.txtFooter3.Height = 0.1875F;
            this.txtFooter3.Left = 0.1101257F;
            this.txtFooter3.Name = "txtFooter3";
            this.txtFooter3.Style = "color: Black; font-family: Book Antiqua; font-size: 8.25pt; text-align: center";
            this.txtFooter3.Text = "Web: http://www.pwsinspection.com        E-mail: info@pipewellservices.com";
            this.txtFooter3.Top = 3.741875F;
            this.txtFooter3.Width = 7.484F;
            // 
            // Shape1
            // 
            this.Shape1.Height = 1.787F;
            this.Shape1.Left = 0.07912571F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 1.569875F;
            this.Shape1.Width = 7.515F;
            // 
            // Label10
            // 
            this.Label10.Height = 0.2560001F;
            this.Label10.HyperLink = null;
            this.Label10.Left = 6.189126F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: bold; te" +
    "xt-align: center; ddo-char-set: 0";
            this.Label10.Text = "Prepared By";
            this.Label10.Top = 1.589875F;
            this.Label10.Width = 1.374F;
            // 
            // Label11
            // 
            this.Label11.DataField = "ApprovalPosition3";
            this.Label11.Height = 0.2560001F;
            this.Label11.HyperLink = null;
            this.Label11.Left = 3.048126F;
            this.Label11.Name = "Label11";
            this.Label11.ShrinkToFit = true;
            this.Label11.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: bold; te" +
    "xt-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.Label11.Text = "Approved";
            this.Label11.Top = 1.589875F;
            this.Label11.Width = 1.469F;
            // 
            // Label12
            // 
            this.Label12.DataField = "ApprovalPosition2";
            this.Label12.Height = 0.2560001F;
            this.Label12.HyperLink = null;
            this.Label12.Left = 1.594126F;
            this.Label12.Name = "Label12";
            this.Label12.ShrinkToFit = true;
            this.Label12.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: bold; te" +
    "xt-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.Label12.Text = "Approved";
            this.Label12.Top = 1.589875F;
            this.Label12.Width = 1.469F;
            // 
            // Line1
            // 
            this.Line1.Height = 0F;
            this.Line1.Left = 0.07912571F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 2.278875F;
            this.Line1.Width = 7.5145F;
            this.Line1.X1 = 0.07912571F;
            this.Line1.X2 = 7.593626F;
            this.Line1.Y1 = 2.278875F;
            this.Line1.Y2 = 2.278875F;
            // 
            // Line3
            // 
            this.Line3.Height = 0F;
            this.Line3.Left = 0.07912571F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 2.981875F;
            this.Line3.Width = 7.5145F;
            this.Line3.X1 = 0.07912571F;
            this.Line3.X2 = 7.593626F;
            this.Line3.Y1 = 2.981875F;
            this.Line3.Y2 = 2.981875F;
            // 
            // Line4
            // 
            this.Line4.Height = 1.787F;
            this.Line4.Left = 3.079125F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 1.569875F;
            this.Line4.Width = 9.536743E-07F;
            this.Line4.X1 = 3.079126F;
            this.Line4.X2 = 3.079125F;
            this.Line4.Y1 = 1.569875F;
            this.Line4.Y2 = 3.356875F;
            // 
            // Line10
            // 
            this.Line10.Height = 1.787F;
            this.Line10.Left = 6.111126F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 1.569875F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 6.111126F;
            this.Line10.X2 = 6.111126F;
            this.Line10.Y1 = 1.569875F;
            this.Line10.Y2 = 3.356875F;
            // 
            // Line11
            // 
            this.Line11.Height = 0F;
            this.Line11.Left = 0.07912571F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 1.856875F;
            this.Line11.Width = 7.5155F;
            this.Line11.X1 = 0.07912571F;
            this.Line11.X2 = 7.594626F;
            this.Line11.Y1 = 1.856875F;
            this.Line11.Y2 = 1.856875F;
            // 
            // TextBox8
            // 
            this.TextBox8.DataField = "ApprovedBy2Name";
            this.TextBox8.Height = 0.4375F;
            this.TextBox8.Left = 1.610374F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat");
            this.TextBox8.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox8.Text = null;
            this.TextBox8.Top = 1.856875F;
            this.TextBox8.Width = 1.4375F;
            // 
            // TextBox9
            // 
            this.TextBox9.DataField = "ApprovedBy3Name";
            this.TextBox9.Height = 0.4375F;
            this.TextBox9.Left = 3.09475F;
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat");
            this.TextBox9.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox9.Text = null;
            this.TextBox9.Top = 1.856875F;
            this.TextBox9.Width = 1.3125F;
            // 
            // TextBox10
            // 
            this.TextBox10.DataField = "PreparedBy";
            this.TextBox10.Height = 0.4375F;
            this.TextBox10.Left = 6.189126F;
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat");
            this.TextBox10.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox10.Text = null;
            this.TextBox10.Top = 1.856875F;
            this.TextBox10.Width = 1.375F;
            // 
            // TextBox11
            // 
            this.TextBox11.DataField = "ApprovalDate2";
            this.TextBox11.Height = 0.1875F;
            this.TextBox11.Left = 1.641624F;
            this.TextBox11.Name = "TextBox11";
            this.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat");
            this.TextBox11.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox11.Text = null;
            this.TextBox11.Top = 3.106875F;
            this.TextBox11.Width = 1.375F;
            // 
            // TextBox16
            // 
            this.TextBox16.DataField = "ApprovedDate4";
            this.TextBox16.Height = 0.1875F;
            this.TextBox16.Left = 6.251125F;
            this.TextBox16.Name = "TextBox16";
            this.TextBox16.OutputFormat = resources.GetString("TextBox16.OutputFormat");
            this.TextBox16.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox16.Text = null;
            this.TextBox16.Top = 3.106875F;
            this.TextBox16.Width = 1.3125F;
            // 
            // Picture2
            // 
            this.Picture2.Height = 0.6424999F;
            this.Picture2.HyperLink = null;
            this.Picture2.ImageData = null;
            this.Picture2.Left = 1.625999F;
            this.Picture2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture2.Name = "Picture2";
            this.Picture2.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch;
            this.Picture2.Top = 2.31F;
            this.Picture2.Width = 1.4375F;
            // 
            // Picture3
            // 
            this.Picture3.Height = 0.6424999F;
            this.Picture3.HyperLink = null;
            this.Picture3.ImageData = null;
            this.Picture3.Left = 3.126F;
            this.Picture3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture3.Name = "Picture3";
            this.Picture3.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch;
            this.Picture3.Top = 2.31F;
            this.Picture3.Width = 1.25F;
            // 
            // Picture4
            // 
            this.Picture4.Height = 0.5799999F;
            this.Picture4.HyperLink = null;
            this.Picture4.ImageData = null;
            this.Picture4.Left = 6.230125F;
            this.Picture4.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture4.Name = "Picture4";
            this.Picture4.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch;
            this.Picture4.Top = 2.325875F;
            this.Picture4.Width = 1.3125F;
            // 
            // Line12
            // 
            this.Line12.Height = 1.79F;
            this.Line12.Left = 1.579124F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 1.569875F;
            this.Line12.Width = 2.026558E-06F;
            this.Line12.X1 = 1.579126F;
            this.Line12.X2 = 1.579124F;
            this.Line12.Y1 = 1.569875F;
            this.Line12.Y2 = 3.359875F;
            // 
            // Label13
            // 
            this.Label13.DataField = "ApprovalPosition1";
            this.Label13.Height = 0.2560001F;
            this.Label13.HyperLink = null;
            this.Label13.Left = 0.1101257F;
            this.Label13.Name = "Label13";
            this.Label13.ShrinkToFit = true;
            this.Label13.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: bold; te" +
    "xt-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.Label13.Text = "Approved ";
            this.Label13.Top = 1.589875F;
            this.Label13.Width = 1.469F;
            // 
            // TextBox24
            // 
            this.TextBox24.DataField = "ApprovalDate1";
            this.TextBox24.Height = 0.1875F;
            this.TextBox24.Left = 0.1416256F;
            this.TextBox24.Name = "TextBox24";
            this.TextBox24.OutputFormat = resources.GetString("TextBox24.OutputFormat");
            this.TextBox24.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox24.Text = null;
            this.TextBox24.Top = 3.106875F;
            this.TextBox24.Width = 1.375F;
            // 
            // TextBox12
            // 
            this.TextBox12.DataField = "ApprovalDate3";
            this.TextBox12.Height = 0.1875F;
            this.TextBox12.Left = 3.141625F;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat");
            this.TextBox12.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox12.Text = null;
            this.TextBox12.Top = 3.106875F;
            this.TextBox12.Width = 1.25F;
            // 
            // Picture1
            // 
            this.Picture1.Height = 0.6424999F;
            this.Picture1.HyperLink = null;
            this.Picture1.ImageData = null;
            this.Picture1.Left = 0.1103757F;
            this.Picture1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture1.Name = "Picture1";
            this.Picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch;
            this.Picture1.Top = 2.294375F;
            this.Picture1.Width = 1.4375F;
            // 
            // TextBox17
            // 
            this.TextBox17.DataField = "ApprovedBy1Name";
            this.TextBox17.Height = 0.4375F;
            this.TextBox17.Left = 0.1103757F;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox17.Text = null;
            this.TextBox17.Top = 1.856875F;
            this.TextBox17.Width = 1.4375F;
            // 
            // Label18
            // 
            this.Label18.Height = 0.125F;
            this.Label18.HyperLink = null;
            this.Label18.Left = 1.235126F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "font-family: Book Antiqua; font-size: 6.75pt; font-weight: bold; text-align: left" +
    "; ddo-char-set: 0";
            this.Label18.Text = "* Note1";
            this.Label18.Top = 1.731875F;
            this.Label18.Width = 0.375F;
            // 
            // Label19
            // 
            this.Label19.Height = 0.125F;
            this.Label19.HyperLink = null;
            this.Label19.Left = 2.704126F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "font-family: Book Antiqua; font-size: 6.75pt; font-weight: bold; text-align: left" +
    "; ddo-char-set: 0";
            this.Label19.Text = "* Note2";
            this.Label19.Top = 1.731875F;
            this.Label19.Width = 0.375F;
            // 
            // Label20
            // 
            this.Label20.Height = 0.125F;
            this.Label20.HyperLink = null;
            this.Label20.Left = 4.157125F;
            this.Label20.Name = "Label20";
            this.Label20.Style = "font-family: Book Antiqua; font-size: 6.75pt; font-weight: bold; text-align: left" +
    "; ddo-char-set: 0";
            this.Label20.Text = "* Note3";
            this.Label20.Top = 1.731875F;
            this.Label20.Width = 0.375F;
            // 
            // chkPersonal
            // 
            this.chkPersonal.DataField = "chkPersonal";
            this.chkPersonal.Height = 0.2F;
            this.chkPersonal.Left = 6.251125F;
            this.chkPersonal.Name = "chkPersonal";
            this.chkPersonal.Style = "color: Black";
            this.chkPersonal.Text = null;
            this.chkPersonal.Top = 2.231875F;
            this.chkPersonal.Visible = false;
            this.chkPersonal.Width = 1.3125F;
            // 
            // chkLoan
            // 
            this.chkLoan.DataField = "chkLoan";
            this.chkLoan.Height = 0.2F;
            this.chkLoan.Left = 6.251125F;
            this.chkLoan.Name = "chkLoan";
            this.chkLoan.Style = "color: Black";
            this.chkLoan.Text = null;
            this.chkLoan.Top = 2.494375F;
            this.chkLoan.Visible = false;
            this.chkLoan.Width = 1.3125F;
            // 
            // chkGeneral
            // 
            this.chkGeneral.DataField = "chkGeneral";
            this.chkGeneral.Height = 0.2F;
            this.chkGeneral.Left = 6.251125F;
            this.chkGeneral.Name = "chkGeneral";
            this.chkGeneral.Style = "color: Black";
            this.chkGeneral.Text = null;
            this.chkGeneral.Top = 2.756875F;
            this.chkGeneral.Visible = false;
            this.chkGeneral.Width = 1.3125F;
            // 
            // Line2
            // 
            this.Line2.Height = 1.787F;
            this.Line2.Left = 4.504126F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 1.569875F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 4.504126F;
            this.Line2.X2 = 4.504126F;
            this.Line2.Y1 = 1.569875F;
            this.Line2.Y2 = 3.356875F;
            // 
            // Label21
            // 
            this.Label21.DataField = "ApprovalPosition4";
            this.Label21.Height = 0.2560001F;
            this.Label21.HyperLink = null;
            this.Label21.Left = 4.602125F;
            this.Label21.Name = "Label21";
            this.Label21.ShrinkToFit = true;
            this.Label21.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: bold; te" +
    "xt-align: center; ddo-char-set: 0; ddo-shrink-to-fit: true";
            this.Label21.Text = "Approved";
            this.Label21.Top = 1.589875F;
            this.Label21.Width = 1.469F;
            // 
            // TextBox18
            // 
            this.TextBox18.DataField = "ApprovedBy4Name";
            this.TextBox18.Height = 0.4375F;
            this.TextBox18.Left = 4.678126F;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat");
            this.TextBox18.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox18.Text = null;
            this.TextBox18.Top = 1.856875F;
            this.TextBox18.Width = 1.3125F;
            // 
            // Picture6
            // 
            this.Picture6.Height = 0.6424999F;
            this.Picture6.HyperLink = null;
            this.Picture6.ImageData = null;
            this.Picture6.Left = 4.657125F;
            this.Picture6.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture6.Name = "Picture6";
            this.Picture6.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch;
            this.Picture6.Top = 2.314875F;
            this.Picture6.Width = 1.25F;
            // 
            // TextBox19
            // 
            this.TextBox19.DataField = "ApprovalDate4";
            this.TextBox19.Height = 0.1875F;
            this.TextBox19.Left = 4.741126F;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.OutputFormat = resources.GetString("TextBox19.OutputFormat");
            this.TextBox19.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox19.Text = null;
            this.TextBox19.Top = 3.106875F;
            this.TextBox19.Width = 1.25F;
            // 
            // rpEmployeeInquiry
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.698792F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; color: Black; font-style: inherit; font-variant: inherit; f" +
            "ont-weight: bold; font-size: 16pt; font-size-adjust: inherit; font-stretch: inhe" +
            "rit", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; co" +
            "lor: Black", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; color: Bl" +
            "ack", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rpEmployeeInquiry_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderArabic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFooter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFooter3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPersonal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        private GrapeCity.ActiveReports.SectionReportModel.Detail Detail;
        private GrapeCity.ActiveReports.SectionReportModel.PageHeader PageHeader;
        private GrapeCity.ActiveReports.SectionReportModel.PageFooter PageFooter;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox7;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox1;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtHeaderCompany;
        private GrapeCity.ActiveReports.SectionReportModel.Picture Picture;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtHeaderArabic;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label2;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label3;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label4;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label6;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label7;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label8;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox3;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox6;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox5;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label5;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label9;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label1;
        private GrapeCity.ActiveReports.SectionReportModel.Picture Picture5;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox13;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox14;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox15;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label16;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label17;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label14;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label15;
        private GrapeCity.ActiveReports.SectionReportModel.Shape Shape4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtFooter3;
        private GrapeCity.ActiveReports.SectionReportModel.Shape Shape1;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label10;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label11;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label12;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line1;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line3;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line4;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line10;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line11;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox8;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox9;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox10;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox11;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox16;
        private GrapeCity.ActiveReports.SectionReportModel.Picture Picture2;
        private GrapeCity.ActiveReports.SectionReportModel.Picture Picture3;
        private GrapeCity.ActiveReports.SectionReportModel.Picture Picture4;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line12;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label13;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox24;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox12;
        private GrapeCity.ActiveReports.SectionReportModel.Picture Picture1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox17;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label18;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label19;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label20;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox chkPersonal;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox chkLoan;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox chkGeneral;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line2;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label21;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox18;
        private GrapeCity.ActiveReports.SectionReportModel.Picture Picture6;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox19;

        private void rpEmployeeInquiry_ReportStart(object sender, System.EventArgs e)
        {
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
                }catch(Exception ex) { }
            }
        }
    }
}