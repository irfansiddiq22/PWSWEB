using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace Pipewellservice.Reports
{

    public partial class rpEmployeeWarning : GrapeCity.ActiveReports.SectionReport
    {
        public rpEmployeeWarning()
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rpEmployeeWarning));
            GrapeCity.ActiveReports.SectionReportModel.Label Label16;
            Label16 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.Shape4 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtFooter1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFooter3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
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
            this.chkFirst = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkSecond = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkFinal = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkWritten = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkVerbal = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox7 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line35 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.chkTardiness = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkAbsenteeism = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkViolation = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkSubstandard = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkPolicies = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkRudeness = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkOther = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.Label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.RichTextBox = new GrapeCity.ActiveReports.SectionReportModel.RichTextBox();
            this.RichTextBox1 = new GrapeCity.ActiveReports.SectionReportModel.RichTextBox();
            this.RichTextBox2 = new GrapeCity.ActiveReports.SectionReportModel.RichTextBox();
            this.Label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label15 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox8 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label17 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Label19 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label21 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox11 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox12 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox13 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Shape1 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label25 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label26 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label27 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line5 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line6 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line7 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line10 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line11 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.TextBox14 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox15 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox16 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox17 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox18 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Picture3 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.Picture5 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.Picture6 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.Line12 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Label28 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox24 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox19 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Picture7 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.TextBox20 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label29 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label30 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label31 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label18 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label20 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label22 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(Label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFooter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFooter3)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.chkFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWritten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVerbal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTardiness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbsenteeism)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViolation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSubstandard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPolicies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRudeness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Label16
            // 
            Label16.Height = 0.2F;
            Label16.HyperLink = null;
            Label16.Left = 0.4375F;
            Label16.Name = "Label16";
            Label16.Style = "color: Black; font-size: 8.25pt; font-style: italic; font-weight: normal; text-al" +
    "ign: left";
            Label16.Text = "Employee Signature";
            Label16.Top = 6.4375F;
            Label16.Width = 1.375F;
            // 
            // Detail
            // 
            this.Detail.Height = 0F;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape4,
            this.txtFooter1,
            this.txtFooter3});
            this.PageFooter.Height = 0.3493056F;
            this.PageFooter.Name = "PageFooter";
            // 
            // Shape4
            // 
            this.Shape4.BackColor = System.Drawing.Color.White;
            this.Shape4.Height = 0.01041663F;
            this.Shape4.Left = 0F;
            this.Shape4.Name = "Shape4";
            this.Shape4.RoundingRadius = 9.999999F;
            this.Shape4.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect;
            this.Shape4.Top = 0F;
            this.Shape4.Width = 7.875F;
            // 
            // txtFooter1
            // 
            this.txtFooter1.Height = 0.1875F;
            this.txtFooter1.Left = 0.3125F;
            this.txtFooter1.Name = "txtFooter1";
            this.txtFooter1.Style = "color: Black; font-family: Book Antiqua; font-size: 8.25pt; text-align: center";
            this.txtFooter1.Text = "C.R. 2050022534 - P.O. Box 2010 Dammam 31451 – Saudi Arabia – Telex: 803 505 QAHB" +
    " RO SJ. – Fax: 8593772 – Tel: 8592286/8594716";
            this.txtFooter1.Top = 0.03125F;
            this.txtFooter1.Width = 7.1875F;
            // 
            // txtFooter3
            // 
            this.txtFooter3.Height = 0.1875F;
            this.txtFooter3.Left = 0.3125F;
            this.txtFooter3.Name = "txtFooter3";
            this.txtFooter3.Style = "color: Black; font-family: Book Antiqua; font-size: 8.25pt; text-align: center";
            this.txtFooter3.Text = "Web: http://www.pwsinspection.com        E-mail: info@pipewellservices.com";
            this.txtFooter3.Top = 0.1666666F;
            this.txtFooter3.Width = 7.1875F;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
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
            this.chkFirst,
            this.chkSecond,
            this.chkFinal,
            this.chkWritten,
            this.chkVerbal,
            this.Label1,
            this.TextBox7,
            this.Line35,
            this.Label10,
            this.chkTardiness,
            this.chkAbsenteeism,
            this.chkViolation,
            this.chkSubstandard,
            this.chkPolicies,
            this.chkRudeness,
            this.chkOther,
            this.Label11,
            this.Label13,
            this.Label14,
            this.RichTextBox,
            this.RichTextBox1,
            this.RichTextBox2,
            this.Label12,
            this.Label15,
            this.TextBox8,
            this.Label17,
            Label16,
            this.Line,
            this.Line2,
            this.Label19,
            this.Label21,
            this.TextBox11,
            this.TextBox12,
            this.TextBox13,
            this.Shape1,
            this.Label25,
            this.Label26,
            this.Label27,
            this.Line5,
            this.Line6,
            this.Line7,
            this.Line10,
            this.Line11,
            this.TextBox14,
            this.TextBox15,
            this.TextBox16,
            this.TextBox17,
            this.TextBox18,
            this.Picture3,
            this.Picture5,
            this.Picture6,
            this.Line12,
            this.Label28,
            this.TextBox24,
            this.TextBox19,
            this.Picture7,
            this.TextBox20,
            this.Label29,
            this.Label30,
            this.Label31,
            this.Label18,
            this.Label20,
            this.Label22});
            this.GroupHeader1.Height = 9.948611F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // TextBox1
            // 
            this.TextBox1.DataField = "=System.DateTime.Now";
            this.TextBox1.Height = 0.2F;
            this.TextBox1.Left = 1.1875F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "color: Black; font-size: 8.25pt; vertical-align: bottom";
            this.TextBox1.Text = "TextBox1";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 1.3125F;
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
            this.Picture.ImageData = null;
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
            this.txtHeaderArabic.Left = 4.25F;
            this.txtHeaderArabic.Name = "txtHeaderArabic";
            this.txtHeaderArabic.Style = "color: Black; font-family: Arabic Typesetting; font-size: 21.75pt; font-weight: b" +
    "old; text-align: center; ddo-char-set: 0";
            this.txtHeaderArabic.Text = null;
            this.txtHeaderArabic.Top = 0.3125F;
            this.txtHeaderArabic.Width = 3.4375F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0.4375F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: right";
            this.Label2.Text = "Employee Name:";
            this.Label2.Top = 1.453125F;
            this.Label2.Width = 1.125F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0.438F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: right";
            this.Label3.Text = "Employee ID:";
            this.Label3.Top = 1.64625F;
            this.Label3.Width = 1.125F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 0.438F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: right";
            this.Label4.Text = "Manager:";
            this.Label4.Top = 1.85F;
            this.Label4.Width = 1.125F;
            // 
            // Label6
            // 
            this.Label6.Height = 0.2F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 4.5625F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: right";
            this.Label6.Text = "Date:";
            this.Label6.Top = 1.453125F;
            this.Label6.Width = 0.875F;
            // 
            // Label7
            // 
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = null;
            this.Label7.Left = 4.563F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: right";
            this.Label7.Text = "Department:";
            this.Label7.Top = 1.85F;
            this.Label7.Width = 0.875F;
            // 
            // Label8
            // 
            this.Label8.Height = 0.2F;
            this.Label8.HyperLink = null;
            this.Label8.Left = 4.563F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: right";
            this.Label8.Text = "Job Title:";
            this.Label8.Top = 1.64625F;
            this.Label8.Width = 0.875F;
            // 
            // TextBox
            // 
            this.TextBox.DataField = "EmployeeName";
            this.TextBox.Height = 0.2F;
            this.TextBox.Left = 1.625F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "color: Black";
            this.TextBox.Text = null;
            this.TextBox.Top = 1.453125F;
            this.TextBox.Width = 2.8125F;
            // 
            // TextBox2
            // 
            this.TextBox2.DataField = "EmployeeID";
            this.TextBox2.Height = 0.2F;
            this.TextBox2.Left = 1.625F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Style = "color: Black";
            this.TextBox2.Text = null;
            this.TextBox2.Top = 1.64625F;
            this.TextBox2.Width = 1.5F;
            // 
            // TextBox3
            // 
            this.TextBox3.DataField = "Manager";
            this.TextBox3.Height = 0.2F;
            this.TextBox3.Left = 1.626F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Style = "color: Black";
            this.TextBox3.Text = null;
            this.TextBox3.Top = 1.85F;
            this.TextBox3.Width = 2.8125F;
            // 
            // TextBox4
            // 
            this.TextBox4.DataField = "WarningDate";
            this.TextBox4.Height = 0.2F;
            this.TextBox4.Left = 5.5F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "color: Black";
            this.TextBox4.Text = null;
            this.TextBox4.Top = 1.453125F;
            this.TextBox4.Width = 1.25F;
            // 
            // TextBox6
            // 
            this.TextBox6.DataField = "Division";
            this.TextBox6.Height = 0.2F;
            this.TextBox6.Left = 5.5F;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.Style = "color: Black";
            this.TextBox6.Text = null;
            this.TextBox6.Top = 1.85F;
            this.TextBox6.Width = 1.9375F;
            // 
            // TextBox5
            // 
            this.TextBox5.DataField = "Position";
            this.TextBox5.Height = 0.2F;
            this.TextBox5.Left = 5.501F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Style = "color: Black";
            this.TextBox5.Text = null;
            this.TextBox5.Top = 1.64625F;
            this.TextBox5.Width = 1.9375F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 0.125F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "background-color: Black; color: White; font-size: 9.75pt; font-weight: bold; text" +
    "-align: center";
            this.Label5.Text = "Employee Information";
            this.Label5.Top = 1.265625F;
            this.Label5.Width = 7.375F;
            // 
            // Label9
            // 
            this.Label9.Height = 0.2F;
            this.Label9.HyperLink = null;
            this.Label9.Left = 0.125F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "background-color: Black; color: White; font-size: 9.75pt; font-weight: bold; text" +
    "-align: center";
            this.Label9.Text = "Type Of Warning";
            this.Label9.Top = 2.0625F;
            this.Label9.Width = 7.375F;
            // 
            // chkFirst
            // 
            this.chkFirst.DataField = "FirstWarning";
            this.chkFirst.Height = 0.2F;
            this.chkFirst.Left = 0.375F;
            this.chkFirst.Name = "chkFirst";
            this.chkFirst.Style = "color: Black; font-family: Arial Narrow; font-size: 9.75pt; font-weight: bold";
            this.chkFirst.Text = "First Warning";
            this.chkFirst.Top = 2.265625F;
            this.chkFirst.Width = 1.125F;
            // 
            // chkSecond
            // 
            this.chkSecond.DataField = "SecondWarning";
            this.chkSecond.Height = 0.2F;
            this.chkSecond.Left = 1.75F;
            this.chkSecond.Name = "chkSecond";
            this.chkSecond.Style = "color: Black; font-family: Arial Narrow; font-size: 9.75pt; font-weight: bold";
            this.chkSecond.Text = "Second Warning";
            this.chkSecond.Top = 2.265625F;
            this.chkSecond.Width = 1.25F;
            // 
            // chkFinal
            // 
            this.chkFinal.DataField = "ThirdWarning";
            this.chkFinal.Height = 0.2F;
            this.chkFinal.Left = 3.25F;
            this.chkFinal.Name = "chkFinal";
            this.chkFinal.Style = "color: Black; font-family: Arial Narrow; font-size: 9.75pt; font-weight: bold";
            this.chkFinal.Text = "Final Warning";
            this.chkFinal.Top = 2.265625F;
            this.chkFinal.Width = 1.1875F;
            // 
            // chkWritten
            // 
            this.chkWritten.DataField = "Written";
            this.chkWritten.Height = 0.2F;
            this.chkWritten.Left = 5.375F;
            this.chkWritten.Name = "chkWritten";
            this.chkWritten.Style = "color: Black; font-family: Arial Narrow; font-size: 9.75pt; font-weight: bold";
            this.chkWritten.Text = "Written";
            this.chkWritten.Top = 2.265625F;
            this.chkWritten.Width = 0.625F;
            // 
            // chkVerbal
            // 
            this.chkVerbal.DataField = "=!Written";
            this.chkVerbal.Height = 0.2F;
            this.chkVerbal.Left = 6.125F;
            this.chkVerbal.Name = "chkVerbal";
            this.chkVerbal.Style = "color: Black; font-family: Arial Narrow; font-size: 9.75pt; font-weight: bold";
            this.chkVerbal.Text = "Verbal";
            this.chkVerbal.Top = 2.265625F;
            this.chkVerbal.Width = 0.625F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 1.9375F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "color: Black; font-family: Book Antiqua; font-size: 12pt; font-weight: bold; text" +
    "-align: center; text-decoration: underline; ddo-char-set: 1";
            this.Label1.Text = "E M P L O Y E E   W A R N I N G   N O T I C E";
            this.Label1.Top = 1F;
            this.Label1.Width = 3.625F;
            // 
            // TextBox7
            // 
            this.TextBox7.DataField = "OtherDetail";
            this.TextBox7.Height = 0.2F;
            this.TextBox7.Left = 1.4375F;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.Style = "color: Black";
            this.TextBox7.Text = null;
            this.TextBox7.Top = 3.05F;
            this.TextBox7.Width = 5.5F;
            // 
            // Line35
            // 
            this.Line35.Height = 0F;
            this.Line35.Left = 1.4375F;
            this.Line35.LineWeight = 1F;
            this.Line35.Name = "Line35";
            this.Line35.Top = 3.2375F;
            this.Line35.Width = 5.5F;
            this.Line35.X1 = 1.4375F;
            this.Line35.X2 = 6.9375F;
            this.Line35.Y1 = 3.2375F;
            this.Line35.Y2 = 3.2375F;
            // 
            // Label10
            // 
            this.Label10.Height = 0.2F;
            this.Label10.HyperLink = null;
            this.Label10.Left = 0.125F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "background-color: Black; color: White; font-size: 9.75pt; font-weight: bold; text" +
    "-align: center";
            this.Label10.Text = "Type Of Offense";
            this.Label10.Top = 2.5F;
            this.Label10.Width = 7.375F;
            // 
            // chkTardiness
            // 
            this.chkTardiness.DataField = "Tardiness";
            this.chkTardiness.Height = 0.2F;
            this.chkTardiness.Left = 0.8125F;
            this.chkTardiness.Name = "chkTardiness";
            this.chkTardiness.Style = "color: Black; font-family: Arial Narrow; font-size: 9.75pt; font-weight: bold";
            this.chkTardiness.Text = "Tardiness/Leaving Early";
            this.chkTardiness.Top = 2.70625F;
            this.chkTardiness.Width = 1.5F;
            // 
            // chkAbsenteeism
            // 
            this.chkAbsenteeism.DataField = "Absenteeism";
            this.chkAbsenteeism.Height = 0.2F;
            this.chkAbsenteeism.Left = 2.875F;
            this.chkAbsenteeism.Name = "chkAbsenteeism";
            this.chkAbsenteeism.Style = "color: Black; font-family: Arial Narrow; font-size: 9.75pt; font-weight: bold";
            this.chkAbsenteeism.Text = "Absenteeism";
            this.chkAbsenteeism.Top = 2.70625F;
            this.chkAbsenteeism.Width = 0.875F;
            // 
            // chkViolation
            // 
            this.chkViolation.DataField = "Violation";
            this.chkViolation.Height = 0.2F;
            this.chkViolation.Left = 2.875F;
            this.chkViolation.Name = "chkViolation";
            this.chkViolation.Style = "color: Black; font-family: Arial Narrow; font-size: 9.75pt; font-weight: bold";
            this.chkViolation.Text = "Violation of Safety Rules";
            this.chkViolation.Top = 2.878125F;
            this.chkViolation.Width = 1.5F;
            // 
            // chkSubstandard
            // 
            this.chkSubstandard.DataField = "Substandard";
            this.chkSubstandard.Height = 0.2F;
            this.chkSubstandard.Left = 0.8125F;
            this.chkSubstandard.Name = "chkSubstandard";
            this.chkSubstandard.Style = "color: Black; font-family: Arial Narrow; font-size: 9.75pt; font-weight: bold";
            this.chkSubstandard.Text = "Substandard Work";
            this.chkSubstandard.Top = 2.878125F;
            this.chkSubstandard.Width = 1.1875F;
            // 
            // chkPolicies
            // 
            this.chkPolicies.DataField = "Policies";
            this.chkPolicies.Height = 0.2F;
            this.chkPolicies.Left = 4.875F;
            this.chkPolicies.Name = "chkPolicies";
            this.chkPolicies.Style = "color: Black; font-family: Arial Narrow; font-size: 9.75pt; font-weight: bold";
            this.chkPolicies.Text = "Violation of Company Policies";
            this.chkPolicies.Top = 2.70625F;
            this.chkPolicies.Width = 1.8125F;
            // 
            // chkRudeness
            // 
            this.chkRudeness.DataField = "Rudeness";
            this.chkRudeness.Height = 0.2F;
            this.chkRudeness.Left = 4.875F;
            this.chkRudeness.Name = "chkRudeness";
            this.chkRudeness.Style = "color: Black; font-family: Arial Narrow; font-size: 9.75pt; font-weight: bold";
            this.chkRudeness.Text = "Rudeness to Customers/Coworkers";
            this.chkRudeness.Top = 2.878125F;
            this.chkRudeness.Width = 2.0625F;
            // 
            // chkOther
            // 
            this.chkOther.DataField = "Other";
            this.chkOther.Height = 0.2F;
            this.chkOther.Left = 0.8125F;
            this.chkOther.Name = "chkOther";
            this.chkOther.Style = "color: Black; font-family: Arial Narrow; font-size: 9.75pt; font-weight: bold";
            this.chkOther.Text = "Other:";
            this.chkOther.Top = 3.05F;
            this.chkOther.Width = 0.5625F;
            // 
            // Label11
            // 
            this.Label11.Height = 0.2F;
            this.Label11.HyperLink = null;
            this.Label11.Left = 0.125F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "background-color: Black; color: White; font-size: 9.75pt; font-weight: bold; text" +
    "-align: center";
            this.Label11.Text = "Details";
            this.Label11.Top = 3.28125F;
            this.Label11.Width = 7.375F;
            // 
            // Label13
            // 
            this.Label13.Height = 0.2F;
            this.Label13.HyperLink = null;
            this.Label13.Left = 0.125F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: left";
            this.Label13.Text = "Plan for Improvement:";
            this.Label13.Top = 4.08125F;
            this.Label13.Width = 2.5F;
            // 
            // Label14
            // 
            this.Label14.Height = 0.2F;
            this.Label14.HyperLink = null;
            this.Label14.Left = 0.125F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: left";
            this.Label14.Text = "Consequences of Further Infractions:";
            this.Label14.Top = 4.65625F;
            this.Label14.Width = 2.5F;
            // 
            // RichTextBox
            // 
            this.RichTextBox.AutoReplaceFields = true;
            this.RichTextBox.DataField = "Infraction";
            this.RichTextBox.Font = new System.Drawing.Font("Arial", 10F);
            this.RichTextBox.Height = 0.375F;
            this.RichTextBox.Left = 0.125F;
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.RTF = resources.GetString("RichTextBox.RTF");
            this.RichTextBox.Top = 3.69375F;
            this.RichTextBox.Width = 7.375F;
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.AutoReplaceFields = true;
            this.RichTextBox1.DataField = "Improvement";
            this.RichTextBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.RichTextBox1.Height = 0.375F;
            this.RichTextBox1.Left = 0.125F;
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.RTF = resources.GetString("RichTextBox1.RTF");
            this.RichTextBox1.Top = 4.25625F;
            this.RichTextBox1.Width = 7.375F;
            // 
            // RichTextBox2
            // 
            this.RichTextBox2.AutoReplaceFields = true;
            this.RichTextBox2.DataField = "Consequences";
            this.RichTextBox2.Font = new System.Drawing.Font("Arial", 10F);
            this.RichTextBox2.Height = 0.375F;
            this.RichTextBox2.Left = 0.125F;
            this.RichTextBox2.Name = "RichTextBox2";
            this.RichTextBox2.RTF = resources.GetString("RichTextBox2.RTF");
            this.RichTextBox2.Top = 4.88125F;
            this.RichTextBox2.Width = 7.375F;
            // 
            // Label12
            // 
            this.Label12.Height = 0.2F;
            this.Label12.HyperLink = null;
            this.Label12.Left = 0.125F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "color: Black; font-size: 9.75pt; font-weight: bold; text-align: left";
            this.Label12.Text = "Description of Infraction:";
            this.Label12.Top = 3.50625F;
            this.Label12.Width = 2.5F;
            // 
            // Label15
            // 
            this.Label15.Height = 0.2F;
            this.Label15.HyperLink = null;
            this.Label15.Left = 0.125F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "background-color: Black; color: White; font-size: 9.75pt; font-weight: bold; text" +
    "-align: center";
            this.Label15.Text = "Acknowledgement of Receipt of Warning";
            this.Label15.Top = 5.35625F;
            this.Label15.Width = 7.375F;
            // 
            // TextBox8
            // 
            this.TextBox8.Height = 0.5F;
            this.TextBox8.Left = 0.125F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Style = "color: Black; font-size: 9.75pt; font-style: italic";
            this.TextBox8.Text = null;
            this.TextBox8.Top = 5.63125F;
            this.TextBox8.Width = 7.375F;
            // 
            // Label17
            // 
            this.Label17.Height = 0.2F;
            this.Label17.HyperLink = null;
            this.Label17.Left = 5.1875F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "color: Black; font-size: 8.25pt; font-style: italic; font-weight: normal; text-al" +
    "ign: left";
            this.Label17.Text = "Date";
            this.Label17.Top = 6.4375F;
            this.Label17.Width = 0.3125F;
            // 
            // Line
            // 
            this.Line.Height = 0F;
            this.Line.Left = 0.375F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 6.4375F;
            this.Line.Width = 6.625F;
            this.Line.X1 = 0.375F;
            this.Line.X2 = 7F;
            this.Line.Y1 = 6.4375F;
            this.Line.Y2 = 6.4375F;
            // 
            // Line2
            // 
            this.Line2.Height = 0F;
            this.Line2.Left = 0.375F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 6.875F;
            this.Line2.Width = 6.625F;
            this.Line2.X1 = 0.375F;
            this.Line2.X2 = 7F;
            this.Line2.Y1 = 6.875F;
            this.Line2.Y2 = 6.875F;
            // 
            // Label19
            // 
            this.Label19.Height = 0.2F;
            this.Label19.HyperLink = null;
            this.Label19.Left = 0.46925F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "color: Black; font-size: 8.25pt; font-style: italic; font-weight: normal; text-al" +
    "ign: left";
            this.Label19.Text = "Witness Signature (if employee understands warning but refuses to sign)";
            this.Label19.Top = 6.8875F;
            this.Label19.Width = 3.75F;
            // 
            // Label21
            // 
            this.Label21.Height = 0.2F;
            this.Label21.HyperLink = null;
            this.Label21.Left = 5.1875F;
            this.Label21.Name = "Label21";
            this.Label21.Style = "color: Black; font-size: 8.25pt; font-style: italic; font-weight: normal; text-al" +
    "ign: left";
            this.Label21.Text = "Date";
            this.Label21.Top = 6.8875F;
            this.Label21.Width = 0.3125F;
            // 
            // TextBox11
            // 
            this.TextBox11.DataField = "ApprovedRemarks1";
            this.TextBox11.Height = 0.375F;
            this.TextBox11.Left = 0.5F;
            this.TextBox11.Name = "TextBox11";
            this.TextBox11.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-style: italic; ddo-" +
    "char-set: 1";
            this.TextBox11.Text = "TextBox11";
            this.TextBox11.Top = 7.125F;
            this.TextBox11.Width = 7.0625F;
            // 
            // TextBox12
            // 
            this.TextBox12.DataField = "ApprovedRemarks2";
            this.TextBox12.Height = 0.375F;
            this.TextBox12.Left = 0.5F;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-style: italic; ddo-" +
    "char-set: 1";
            this.TextBox12.Text = "TextBox11";
            this.TextBox12.Top = 7.5F;
            this.TextBox12.Width = 7.0625F;
            // 
            // TextBox13
            // 
            this.TextBox13.DataField = "ApprovedRemarks3";
            this.TextBox13.Height = 0.325F;
            this.TextBox13.Left = 0.5F;
            this.TextBox13.Name = "TextBox13";
            this.TextBox13.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-style: italic; ddo-" +
    "char-set: 1";
            this.TextBox13.Text = "TextBox11";
            this.TextBox13.Top = 7.875F;
            this.TextBox13.Width = 7.0625F;
            // 
            // Shape1
            // 
            this.Shape1.Height = 1.75F;
            this.Shape1.Left = 0.875F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 8.1875F;
            this.Shape1.Width = 5.8125F;
            // 
            // Label25
            // 
            this.Label25.DataField = "SignManager4";
            this.Label25.Height = 0.2F;
            this.Label25.HyperLink = null;
            this.Label25.Left = 5.3125F;
            this.Label25.Name = "Label25";
            this.Label25.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: bold; te" +
    "xt-align: center; ddo-char-set: 0";
            this.Label25.Text = "Prepared By";
            this.Label25.Top = 8.25F;
            this.Label25.Width = 1.291667F;
            // 
            // Label26
            // 
            this.Label26.DataField = "SignManager3";
            this.Label26.Height = 0.2F;
            this.Label26.HyperLink = null;
            this.Label26.Left = 3.9375F;
            this.Label26.Name = "Label26";
            this.Label26.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: bold; te" +
    "xt-align: center; ddo-char-set: 0";
            this.Label26.Text = "Approved";
            this.Label26.Top = 8.25F;
            this.Label26.Width = 1.229167F;
            // 
            // Label27
            // 
            this.Label27.DataField = "SignManager2";
            this.Label27.Height = 0.2F;
            this.Label27.HyperLink = null;
            this.Label27.Left = 2.453125F;
            this.Label27.Name = "Label27";
            this.Label27.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: bold; te" +
    "xt-align: center; ddo-char-set: 0";
            this.Label27.Text = "Approved";
            this.Label27.Top = 8.25F;
            this.Label27.Width = 1.296875F;
            // 
            // Line5
            // 
            this.Line5.Height = 0F;
            this.Line5.Left = 0.875F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 8.859375F;
            this.Line5.Width = 5.8125F;
            this.Line5.X1 = 0.875F;
            this.Line5.X2 = 6.6875F;
            this.Line5.Y1 = 8.859375F;
            this.Line5.Y2 = 8.859375F;
            // 
            // Line6
            // 
            this.Line6.Height = 0F;
            this.Line6.Left = 0.875F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 9.5625F;
            this.Line6.Width = 5.8125F;
            this.Line6.X1 = 0.875F;
            this.Line6.X2 = 6.6875F;
            this.Line6.Y1 = 9.5625F;
            this.Line6.Y2 = 9.5625F;
            // 
            // Line7
            // 
            this.Line7.Height = 1.75F;
            this.Line7.Left = 3.875F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 8.1875F;
            this.Line7.Width = 0F;
            this.Line7.X1 = 3.875F;
            this.Line7.X2 = 3.875F;
            this.Line7.Y1 = 8.1875F;
            this.Line7.Y2 = 9.9375F;
            // 
            // Line10
            // 
            this.Line10.Height = 1.75F;
            this.Line10.Left = 5.25F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 8.1875F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 5.25F;
            this.Line10.X2 = 5.25F;
            this.Line10.Y1 = 8.1875F;
            this.Line10.Y2 = 9.9375F;
            // 
            // Line11
            // 
            this.Line11.Height = 0F;
            this.Line11.Left = 0.875F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 8.4375F;
            this.Line11.Width = 5.8125F;
            this.Line11.X1 = 0.875F;
            this.Line11.X2 = 6.6875F;
            this.Line11.Y1 = 8.4375F;
            this.Line11.Y2 = 8.4375F;
            // 
            // TextBox14
            // 
            this.TextBox14.DataField = "ApprovedBy2Name";
            this.TextBox14.Height = 0.4375F;
            this.TextBox14.Left = 2.40625F;
            this.TextBox14.Name = "TextBox14";
            this.TextBox14.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox14.Text = null;
            this.TextBox14.Top = 8.4375F;
            this.TextBox14.Width = 1.4375F;
            // 
            // TextBox15
            // 
            this.TextBox15.DataField = "ApprovedBy3Name";
            this.TextBox15.Height = 0.4375F;
            this.TextBox15.Left = 3.890625F;
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox15.Text = null;
            this.TextBox15.Top = 8.4375F;
            this.TextBox15.Width = 1.3125F;
            // 
            // TextBox16
            // 
            this.TextBox16.DataField = "PreparedBy";
            this.TextBox16.Height = 0.4375F;
            this.TextBox16.Left = 5.28125F;
            this.TextBox16.Name = "TextBox16";
            this.TextBox16.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox16.Text = null;
            this.TextBox16.Top = 8.4375F;
            this.TextBox16.Width = 1.375F;
            // 
            // TextBox17
            // 
            this.TextBox17.DataField = "ApprovedDate2";
            this.TextBox17.Height = 0.1875F;
            this.TextBox17.Left = 2.4375F;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox17.Text = null;
            this.TextBox17.Top = 9.6875F;
            this.TextBox17.Width = 1.375F;
            // 
            // TextBox18
            // 
            this.TextBox18.DataField = "ApprovedDate4";
            this.TextBox18.Height = 0.1875F;
            this.TextBox18.Left = 5.3125F;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox18.Text = null;
            this.TextBox18.Top = 9.6875F;
            this.TextBox18.Width = 1.3125F;
            // 
            // Picture3
            // 
            this.Picture3.DataField = "Signature2";
            this.Picture3.Height = 0.6425F;
            this.Picture3.ImageData = null;
            this.Picture3.Left = 2.421875F;
            this.Picture3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture3.Name = "Picture3";
            this.Picture3.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch;
            this.Picture3.Top = 8.890625F;
            this.Picture3.Width = 1.4375F;
            // 
            // Picture5
            // 
            this.Picture5.DataField = "Signature3";
            this.Picture5.Height = 0.6425F;
            this.Picture5.ImageData = null;
            this.Picture5.Left = 3.921875F;
            this.Picture5.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture5.Name = "Picture5";
            this.Picture5.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch;
            this.Picture5.Top = 8.890625F;
            this.Picture5.Width = 1.25F;
            // 
            // Picture6
            // 
            this.Picture6.DataField = "Signature4";
            this.Picture6.Height = 0.58F;
            this.Picture6.ImageData = null;
            this.Picture6.Left = 5.3125F;
            this.Picture6.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture6.Name = "Picture6";
            this.Picture6.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch;
            this.Picture6.Top = 8.90625F;
            this.Picture6.Width = 1.3125F;
            // 
            // Line12
            // 
            this.Line12.Height = 1.75F;
            this.Line12.Left = 2.375F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 8.1875F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 2.375F;
            this.Line12.X2 = 2.375F;
            this.Line12.Y1 = 8.1875F;
            this.Line12.Y2 = 9.9375F;
            // 
            // Label28
            // 
            this.Label28.DataField = "SignManager1";
            this.Label28.Height = 0.2F;
            this.Label28.HyperLink = null;
            this.Label28.Left = 0.953125F;
            this.Label28.Name = "Label28";
            this.Label28.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: bold; te" +
    "xt-align: center; ddo-char-set: 0";
            this.Label28.Text = "";
            this.Label28.Top = 8.2625F;
            this.Label28.Width = 1.296875F;
            // 
            // TextBox24
            // 
            this.TextBox24.DataField = "ApprovedDate1";
            this.TextBox24.Height = 0.1875F;
            this.TextBox24.Left = 0.9375F;
            this.TextBox24.Name = "TextBox24";
            this.TextBox24.OutputFormat = resources.GetString("TextBox24.OutputFormat");
            this.TextBox24.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox24.Text = null;
            this.TextBox24.Top = 9.6875F;
            this.TextBox24.Width = 1.375F;
            // 
            // TextBox19
            // 
            this.TextBox19.DataField = "ApprovedDate3";
            this.TextBox19.Height = 0.1875F;
            this.TextBox19.Left = 3.9375F;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.OutputFormat = resources.GetString("TextBox19.OutputFormat");
            this.TextBox19.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox19.Text = null;
            this.TextBox19.Top = 9.6875F;
            this.TextBox19.Width = 1.25F;
            // 
            // Picture7
            // 
            this.Picture7.DataField = "Signature1";
            this.Picture7.Height = 0.6425F;
            this.Picture7.ImageData = null;
            this.Picture7.Left = 0.90625F;
            this.Picture7.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture7.Name = "Picture7";
            this.Picture7.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Stretch;
            this.Picture7.Top = 8.875F;
            this.Picture7.Width = 1.4375F;
            // 
            // TextBox20
            // 
            this.TextBox20.DataField = "ApprovedBy1Name";
            this.TextBox20.Height = 0.4375F;
            this.TextBox20.Left = 0.90625F;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox20.Text = null;
            this.TextBox20.Top = 8.4375F;
            this.TextBox20.Width = 1.4375F;
            // 
            // Label29
            // 
            this.Label29.Height = 0.125F;
            this.Label29.HyperLink = null;
            this.Label29.Left = 2.03125F;
            this.Label29.Name = "Label29";
            this.Label29.Style = "color: Black; font-family: Book Antiqua; font-size: 6.75pt; font-weight: bold; te" +
    "xt-align: left; ddo-char-set: 0";
            this.Label29.Text = "* Note1";
            this.Label29.Top = 8.3125F;
            this.Label29.Width = 0.375F;
            // 
            // Label30
            // 
            this.Label30.Height = 0.125F;
            this.Label30.HyperLink = null;
            this.Label30.Left = 3.5F;
            this.Label30.Name = "Label30";
            this.Label30.Style = "color: Black; font-family: Book Antiqua; font-size: 6.75pt; font-weight: bold; te" +
    "xt-align: left; ddo-char-set: 0";
            this.Label30.Text = "* Note2";
            this.Label30.Top = 8.3125F;
            this.Label30.Width = 0.375F;
            // 
            // Label31
            // 
            this.Label31.Height = 0.125F;
            this.Label31.HyperLink = null;
            this.Label31.Left = 4.875F;
            this.Label31.Name = "Label31";
            this.Label31.Style = "color: Black; font-family: Book Antiqua; font-size: 6.75pt; font-weight: bold; te" +
    "xt-align: left; ddo-char-set: 0";
            this.Label31.Text = "* Note3";
            this.Label31.Top = 8.3125F;
            this.Label31.Width = 0.375F;
            // 
            // Label18
            // 
            this.Label18.Height = 0.125F;
            this.Label18.HyperLink = null;
            this.Label18.Left = 0.0625F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "color: Black; font-family: Book Antiqua; font-size: 7pt; font-weight: bold; text-" +
    "align: left; ddo-char-set: 1";
            this.Label18.Text = "* Note1";
            this.Label18.Top = 7.25F;
            this.Label18.Visible = false;
            this.Label18.Width = 0.375F;
            // 
            // Label20
            // 
            this.Label20.Height = 0.125F;
            this.Label20.HyperLink = null;
            this.Label20.Left = 0.0625F;
            this.Label20.Name = "Label20";
            this.Label20.Style = "color: Black; font-family: Book Antiqua; font-size: 7pt; font-weight: bold; text-" +
    "align: left; ddo-char-set: 1";
            this.Label20.Text = "* Note2";
            this.Label20.Top = 7.5625F;
            this.Label20.Visible = false;
            this.Label20.Width = 0.4375F;
            // 
            // Label22
            // 
            this.Label22.Height = 0.125F;
            this.Label22.HyperLink = null;
            this.Label22.Left = 0.0625F;
            this.Label22.Name = "Label22";
            this.Label22.Style = "color: Black; font-family: Book Antiqua; font-size: 7pt; font-weight: bold; text-" +
    "align: left; ddo-char-set: 1";
            this.Label22.Text = "* Note3";
            this.Label22.Top = 7.90625F;
            this.Label22.Visible = false;
            this.Label22.Width = 0.375F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Height = 0F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // rpEmployeeWarning
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.775F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter1);
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
            ((System.ComponentModel.ISupportInitialize)(Label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFooter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFooter3)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.chkFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWritten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVerbal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTardiness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbsenteeism)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViolation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSubstandard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPolicies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRudeness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        private GrapeCity.ActiveReports.SectionReportModel.Detail Detail;
        private GrapeCity.ActiveReports.SectionReportModel.PageHeader PageHeader;
        private GrapeCity.ActiveReports.SectionReportModel.PageFooter PageFooter;
        private GrapeCity.ActiveReports.SectionReportModel.Shape Shape4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtFooter3;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader GroupHeader1;
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
        private GrapeCity.ActiveReports.SectionReportModel.CheckBox chkFirst;
        private GrapeCity.ActiveReports.SectionReportModel.CheckBox chkSecond;
        private GrapeCity.ActiveReports.SectionReportModel.CheckBox chkFinal;
        private GrapeCity.ActiveReports.SectionReportModel.CheckBox chkWritten;
        private GrapeCity.ActiveReports.SectionReportModel.CheckBox chkVerbal;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox7;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line35;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label10;
        private GrapeCity.ActiveReports.SectionReportModel.CheckBox chkTardiness;
        private GrapeCity.ActiveReports.SectionReportModel.CheckBox chkAbsenteeism;
        private GrapeCity.ActiveReports.SectionReportModel.CheckBox chkViolation;
        private GrapeCity.ActiveReports.SectionReportModel.CheckBox chkSubstandard;
        private GrapeCity.ActiveReports.SectionReportModel.CheckBox chkPolicies;
        private GrapeCity.ActiveReports.SectionReportModel.CheckBox chkRudeness;
        private GrapeCity.ActiveReports.SectionReportModel.CheckBox chkOther;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label11;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label13;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label14;
        private GrapeCity.ActiveReports.SectionReportModel.RichTextBox RichTextBox;
        private GrapeCity.ActiveReports.SectionReportModel.RichTextBox RichTextBox1;
        private GrapeCity.ActiveReports.SectionReportModel.RichTextBox RichTextBox2;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label12;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label15;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox8;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label17;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line2;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label19;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label21;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox11;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox12;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox13;
        private GrapeCity.ActiveReports.SectionReportModel.Shape Shape1;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label25;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label26;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label27;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line5;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line6;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line7;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line10;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line11;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox14;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox15;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox16;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox17;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox18;
        private GrapeCity.ActiveReports.SectionReportModel.Picture Picture3;
        private GrapeCity.ActiveReports.SectionReportModel.Picture Picture5;
        private GrapeCity.ActiveReports.SectionReportModel.Picture Picture6;
        private GrapeCity.ActiveReports.SectionReportModel.Line Line12;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label28;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox24;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox19;
        private GrapeCity.ActiveReports.SectionReportModel.Picture Picture7;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox20;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label29;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label30;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label31;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label18;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label20;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label22;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter GroupFooter1;
    }
}