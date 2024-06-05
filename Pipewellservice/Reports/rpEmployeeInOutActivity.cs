using Pipewellservice.Helper;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace Pipewellservice.Reports
{

    public partial class rpEmployeeInOutActivity : GrapeCity.ActiveReports.SectionReport
    {
        public rpEmployeeInOutActivity()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpEmployeeInOutActivity));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.txtabsent = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtin = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtout = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtMissPunch = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtREmarks = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtDeduct = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox9 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtStatus = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.lblCompName = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Shape2 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtHeaderCompany = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Picture = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.txtHeaderArabic = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtPeriod = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.GroupHeader2 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.GroupFooter2 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lbl2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtSF = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtse = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtm15 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtm30 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtm45 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtem30 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtem45 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtem15 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtTID = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.TextBox8 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox7 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtDe = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtabsent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMissPunch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtREmarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCompName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderArabic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtm15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtm30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtm45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtem45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.txtabsent,
            this.TextBox3,
            this.txtin,
            this.txtout,
            this.txtMissPunch,
            this.txtREmarks,
            this.TextBox5,
            this.TextBox6,
            this.txtDeduct,
            this.TextBox9,
            this.txtStatus});
            this.Detail.Height = 0.2F;
            this.Detail.Name = "Detail";
            // 
            // txtabsent
            // 
            this.txtabsent.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtabsent.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtabsent.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtabsent.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtabsent.DataField = "absent";
            this.txtabsent.Height = 0.2F;
            this.txtabsent.Left = 0F;
            this.txtabsent.Name = "txtabsent";
            this.txtabsent.Style = "color: Black; font-size: 8pt; text-align: center; vertical-align: middle; ddo-cha" +
    "r-set: 1";
            this.txtabsent.Text = null;
            this.txtabsent.Top = 0F;
            this.txtabsent.Visible = false;
            this.txtabsent.Width = 0.59375F;
            // 
            // TextBox3
            // 
            this.TextBox3.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox3.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox3.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox3.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox3.DataField = "RecordDate";
            this.TextBox3.Height = 0.2F;
            this.TextBox3.Left = 0.0625F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.ShrinkToFit = true;
            this.TextBox3.Style = "color: Black; font-size: 8pt; text-align: center; vertical-align: middle; ddo-cha" +
    "r-set: 1; ddo-shrink-to-fit: true";
            this.TextBox3.Text = "TextBox1";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 0.6242501F;
            // 
            // txtin
            // 
            this.txtin.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtin.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtin.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtin.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtin.DataField = "CheckInTime";
            this.txtin.Height = 0.2F;
            this.txtin.Left = 0.96875F;
            this.txtin.Name = "txtin";
            this.txtin.ShrinkToFit = true;
            this.txtin.Style = "color: Black; font-size: 8pt; text-align: center; vertical-align: middle; ddo-cha" +
    "r-set: 1; ddo-shrink-to-fit: true";
            this.txtin.Text = "TextBox1";
            this.txtin.Top = 0F;
            this.txtin.Width = 0.59375F;
            // 
            // txtout
            // 
            this.txtout.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtout.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtout.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtout.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtout.DataField = "CheckOutTime";
            this.txtout.Height = 0.2F;
            this.txtout.Left = 1.5625F;
            this.txtout.Name = "txtout";
            this.txtout.ShrinkToFit = true;
            this.txtout.Style = "color: Black; font-size: 8pt; text-align: center; vertical-align: middle; ddo-cha" +
    "r-set: 1; ddo-shrink-to-fit: true";
            this.txtout.Text = "TextBox1";
            this.txtout.Top = 0F;
            this.txtout.Width = 0.59375F;
            // 
            // txtMissPunch
            // 
            this.txtMissPunch.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtMissPunch.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtMissPunch.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtMissPunch.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtMissPunch.Height = 0.2F;
            this.txtMissPunch.Left = 2.59375F;
            this.txtMissPunch.Name = "txtMissPunch";
            this.txtMissPunch.ShrinkToFit = true;
            this.txtMissPunch.Style = "color: Black; font-size: 8pt; text-align: center; vertical-align: middle; ddo-cha" +
    "r-set: 1; ddo-shrink-to-fit: true";
            this.txtMissPunch.Text = null;
            this.txtMissPunch.Top = 0F;
            this.txtMissPunch.Width = 1.09375F;
            // 
            // txtREmarks
            // 
            this.txtREmarks.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtREmarks.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtREmarks.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtREmarks.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtREmarks.DataField = "remarks";
            this.txtREmarks.Height = 0.2F;
            this.txtREmarks.Left = 3.96875F;
            this.txtREmarks.Name = "txtREmarks";
            this.txtREmarks.ShrinkToFit = true;
            this.txtREmarks.Style = "color: Black; font-size: 8pt; text-align: left; vertical-align: middle; ddo-char-" +
    "set: 1; ddo-shrink-to-fit: true";
            this.txtREmarks.Text = null;
            this.txtREmarks.Top = 0F;
            this.txtREmarks.Width = 3.84375F;
            // 
            // TextBox5
            // 
            this.TextBox5.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox5.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox5.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox5.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox5.DataField = "Supervisor";
            this.TextBox5.Height = 0.2F;
            this.TextBox5.Left = 6.6875F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Style = "color: Black; font-size: 8pt; text-align: left; vertical-align: middle; ddo-char-" +
    "set: 1";
            this.TextBox5.Text = "TextBox1";
            this.TextBox5.Top = 0F;
            this.TextBox5.Visible = false;
            this.TextBox5.Width = 1.09375F;
            // 
            // TextBox6
            // 
            this.TextBox6.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox6.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox6.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox6.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox6.DataField = "EmployeeWorkedTime";
            this.TextBox6.Height = 0.2F;
            this.TextBox6.Left = 2.15625F;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.ShrinkToFit = true;
            this.TextBox6.Style = "color: Black; font-size: 8pt; text-align: center; vertical-align: middle; ddo-cha" +
    "r-set: 1; ddo-shrink-to-fit: true";
            this.TextBox6.Text = "TextBox1";
            this.TextBox6.Top = 0F;
            this.TextBox6.Width = 0.421875F;
            // 
            // txtDeduct
            // 
            this.txtDeduct.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtDeduct.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtDeduct.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtDeduct.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.txtDeduct.Height = 0.2F;
            this.txtDeduct.Left = 3.6875F;
            this.txtDeduct.Name = "txtDeduct";
            this.txtDeduct.Style = "color: Black; font-size: 8pt; text-align: center; vertical-align: middle; ddo-cha" +
    "r-set: 1";
            this.txtDeduct.Text = null;
            this.txtDeduct.Top = 0F;
            this.txtDeduct.Width = 0.28125F;
            // 
            // TextBox9
            // 
            this.TextBox9.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox9.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox9.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox9.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox9.DataField = "WorkingDay";
            this.TextBox9.Height = 0.2F;
            this.TextBox9.Left = 0.687F;
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat");
            this.TextBox9.ShrinkToFit = true;
            this.TextBox9.Style = "color: Black; font-size: 8pt; text-align: center; vertical-align: middle; ddo-cha" +
    "r-set: 1; ddo-shrink-to-fit: true";
            this.TextBox9.Text = null;
            this.TextBox9.Top = 0F;
            this.TextBox9.Width = 0.28175F;
            // 
            // txtStatus
            // 
            this.txtStatus.DataField = "Status";
            this.txtStatus.Height = 0.1979167F;
            this.txtStatus.Left = 7.371F;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Style = "color: Black";
            this.txtStatus.Text = "TextBox4";
            this.txtStatus.Top = 0.001999974F;
            this.txtStatus.Visible = false;
            this.txtStatus.Width = 0.4410005F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.lblCompName,
            this.Shape2,
            this.Shape,
            this.Label5,
            this.TextBox,
            this.Label,
            this.txtHeaderCompany,
            this.Picture,
            this.txtHeaderArabic,
            this.Label1,
            this.txtPeriod});
            this.PageHeader.Height = 1.375F;
            this.PageHeader.Name = "PageHeader";
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
            // Shape2
            // 
            this.Shape2.BackColor = System.Drawing.Color.White;
            this.Shape2.Height = 0.01041663F;
            this.Shape2.Left = 0F;
            this.Shape2.Name = "Shape2";
            this.Shape2.RoundingRadius = 9.999999F;
            this.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect;
            this.Shape2.Top = 1.348958F;
            this.Shape2.Width = 7.875F;
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
            this.Shape.Width = 7.875F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.1875F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 0.0625F;
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
            this.txtHeaderArabic.Left = 4.375F;
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
            this.Label1.Left = 0.0625F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "color: Black; font-family: Book Antiqua; font-size: 12pt; font-weight: bold; text" +
    "-align: left; text-decoration: underline; ddo-char-set: 1";
            this.Label1.Text = "Employee Fingerprint In/Out Detail";
            this.Label1.Top = 0.8125F;
            this.Label1.Width = 3.4375F;
            // 
            // txtPeriod
            // 
            this.txtPeriod.Height = 0.2F;
            this.txtPeriod.Left = 0.84375F;
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: bold; te" +
    "xt-align: left; ddo-char-set: 1";
            this.txtPeriod.Text = null;
            this.txtPeriod.Top = 1.125F;
            this.txtPeriod.Width = 3.96875F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.DataField = "div";
            this.GroupHeader2.Height = 0F;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Height = 0F;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Label4,
            this.lbl2,
            this.Label3,
            this.Label2,
            this.Label7,
            this.Label6,
            this.TextBox2,
            this.TextBox1,
            this.Label8,
            this.Label9,
            this.Label10,
            this.Label12,
            this.Label14,
            this.txtSF,
            this.txtse,
            this.txtm15,
            this.txtm30,
            this.txtm45,
            this.txtem30,
            this.txtem45,
            this.txtem15,
            this.txtTID});
            this.GroupHeader1.DataField = "emp_no";
            this.GroupHeader1.Height = 0.6701389F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // Label4
            // 
            this.Label4.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label4.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label4.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label4.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 0.96875F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center";
            this.Label4.Text = "IN";
            this.Label4.Top = 0.4375F;
            this.Label4.Width = 0.59375F;
            // 
            // lbl2
            // 
            this.lbl2.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.lbl2.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.lbl2.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.lbl2.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.lbl2.Height = 0.2F;
            this.lbl2.HyperLink = null;
            this.lbl2.Left = 0.0666666F;
            this.lbl2.Name = "lbl2";
            this.lbl2.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.lbl2.Text = "Employee Name";
            this.lbl2.Top = 0F;
            this.lbl2.Width = 1.1875F;
            // 
            // Label3
            // 
            this.Label3.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label3.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label3.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label3.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0.0625F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.Label3.Text = "Code";
            this.Label3.Top = 0.1875F;
            this.Label3.Width = 1.1875F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label2.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label2.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label2.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0.0625F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center";
            this.Label2.Text = "Date";
            this.Label2.Top = 0.4375F;
            this.Label2.Width = 0.6245F;
            // 
            // Label7
            // 
            this.Label7.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label7.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label7.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label7.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = null;
            this.Label7.Left = 2.59375F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; ddo-char-set: 1";
            this.Label7.Text = "M.P";
            this.Label7.Top = 0.4375F;
            this.Label7.Width = 1.09375F;
            // 
            // Label6
            // 
            this.Label6.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label6.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label6.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label6.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label6.Height = 0.2F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 1.5625F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center";
            this.Label6.Text = "Out";
            this.Label6.Top = 0.4375F;
            this.Label6.Width = 0.59375F;
            // 
            // TextBox2
            // 
            this.TextBox2.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox2.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox2.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox2.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox2.DataField = "EmpName";
            this.TextBox2.Height = 0.2F;
            this.TextBox2.Left = 1.254167F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Style = "color: Black";
            this.TextBox2.Text = null;
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 5.4375F;
            // 
            // TextBox1
            // 
            this.TextBox1.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox1.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox1.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox1.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.TextBox1.DataField = "EmpID";
            this.TextBox1.Height = 0.2F;
            this.TextBox1.Left = 1.25F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "color: Black";
            this.TextBox1.Text = null;
            this.TextBox1.Top = 0.1875F;
            this.TextBox1.Width = 5.4375F;
            // 
            // Label8
            // 
            this.Label8.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label8.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label8.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label8.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label8.Height = 0.2F;
            this.Label8.HyperLink = null;
            this.Label8.Left = 3.96875F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; ddo-char-set: 1";
            this.Label8.Text = "Remarks";
            this.Label8.Top = 0.4375F;
            this.Label8.Width = 3.84375F;
            // 
            // Label9
            // 
            this.Label9.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label9.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label9.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label9.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label9.Height = 0.2F;
            this.Label9.HyperLink = null;
            this.Label9.Left = 6.6875F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center";
            this.Label9.Text = "Supervisor";
            this.Label9.Top = 0.4375F;
            this.Label9.Visible = false;
            this.Label9.Width = 1.09375F;
            // 
            // Label10
            // 
            this.Label10.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label10.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label10.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label10.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label10.Height = 0.2F;
            this.Label10.HyperLink = null;
            this.Label10.Left = 2.15625F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center";
            this.Label10.Text = "T.W.T";
            this.Label10.Top = 0.4375F;
            this.Label10.Width = 0.421875F;
            // 
            // Label12
            // 
            this.Label12.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label12.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label12.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label12.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label12.Height = 0.2F;
            this.Label12.HyperLink = null;
            this.Label12.Left = 3.6875F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; ddo-char-set: 1";
            this.Label12.Text = "Ded.";
            this.Label12.Top = 0.4375F;
            this.Label12.Width = 0.28125F;
            // 
            // Label14
            // 
            this.Label14.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label14.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label14.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label14.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label14.Height = 0.2F;
            this.Label14.HyperLink = null;
            this.Label14.Left = 0.687F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center";
            this.Label14.Text = "Day";
            this.Label14.Top = 0.4375F;
            this.Label14.Width = 0.28175F;
            // 
            // txtSF
            // 
            this.txtSF.DataField = "sf";
            this.txtSF.DistinctField = "";
            this.txtSF.Height = 0.2F;
            this.txtSF.Left = 6.817F;
            this.txtSF.Name = "txtSF";
            this.txtSF.Style = "color: Black";
            this.txtSF.SummaryGroup = "";
            this.txtSF.Text = "txtsf";
            this.txtSF.Top = 0.042F;
            this.txtSF.Visible = false;
            this.txtSF.Width = 1F;
            // 
            // txtse
            // 
            this.txtse.DataField = "se";
            this.txtse.DistinctField = "";
            this.txtse.Height = 0.2F;
            this.txtse.Left = 6.816F;
            this.txtse.Name = "txtse";
            this.txtse.Style = "color: Black";
            this.txtse.SummaryGroup = "";
            this.txtse.Text = "txtse";
            this.txtse.Top = 0.237F;
            this.txtse.Visible = false;
            this.txtse.Width = 1F;
            // 
            // txtm15
            // 
            this.txtm15.DataField = "m15";
            this.txtm15.DistinctField = "";
            this.txtm15.Height = 0.2F;
            this.txtm15.Left = 2.624F;
            this.txtm15.Name = "txtm15";
            this.txtm15.Style = "color: Black";
            this.txtm15.SummaryGroup = "";
            this.txtm15.Text = "m15";
            this.txtm15.Top = 0.187F;
            this.txtm15.Visible = false;
            this.txtm15.Width = 1F;
            // 
            // txtm30
            // 
            this.txtm30.DataField = "m30";
            this.txtm30.DistinctField = "";
            this.txtm30.Height = 0.2F;
            this.txtm30.Left = 5.636F;
            this.txtm30.Name = "txtm30";
            this.txtm30.Style = "color: Black";
            this.txtm30.SummaryGroup = "";
            this.txtm30.Text = "m30";
            this.txtm30.Top = 0.208F;
            this.txtm30.Visible = false;
            this.txtm30.Width = 1F;
            // 
            // txtm45
            // 
            this.txtm45.DataField = "m45";
            this.txtm45.DistinctField = "";
            this.txtm45.Height = 0.2F;
            this.txtm45.Left = 5.728F;
            this.txtm45.Name = "txtm45";
            this.txtm45.Style = "color: Black";
            this.txtm45.SummaryGroup = "";
            this.txtm45.Text = "m45";
            this.txtm45.Top = 0F;
            this.txtm45.Visible = false;
            this.txtm45.Width = 1F;
            // 
            // txtem30
            // 
            this.txtem30.DataField = "em30";
            this.txtem30.DistinctField = "";
            this.txtem30.Height = 0.2F;
            this.txtem30.Left = 2.524F;
            this.txtem30.Name = "txtem30";
            this.txtem30.Style = "color: Black";
            this.txtem30.SummaryGroup = "";
            this.txtem30.Text = "em30";
            this.txtem30.Top = 0.01199999F;
            this.txtem30.Visible = false;
            this.txtem30.Width = 1F;
            // 
            // txtem45
            // 
            this.txtem45.DataField = "em45";
            this.txtem45.DistinctField = "";
            this.txtem45.Height = 0.2F;
            this.txtem45.Left = 4.645F;
            this.txtem45.Name = "txtem45";
            this.txtem45.Style = "color: Black";
            this.txtem45.SummaryGroup = "";
            this.txtem45.Text = "em45";
            this.txtem45.Top = 0F;
            this.txtem45.Visible = false;
            this.txtem45.Width = 1F;
            // 
            // txtem15
            // 
            this.txtem15.DataField = "em15";
            this.txtem15.DistinctField = "";
            this.txtem15.Height = 0.2F;
            this.txtem15.Left = 3.574F;
            this.txtem15.Name = "txtem15";
            this.txtem15.Style = "color: Black";
            this.txtem15.SummaryGroup = "";
            this.txtem15.Text = "em15";
            this.txtem15.Top = 0F;
            this.txtem15.Visible = false;
            this.txtem15.Width = 1F;
            // 
            // txtTID
            // 
            this.txtTID.DataField = "TID";
            this.txtTID.DistinctField = "";
            this.txtTID.Height = 0.2F;
            this.txtTID.Left = 1.474F;
            this.txtTID.Name = "txtTID";
            this.txtTID.Style = "color: Black";
            this.txtTID.SummaryGroup = "";
            this.txtTID.Text = "txtTID";
            this.txtTID.Top = 0F;
            this.txtTID.Visible = false;
            this.txtTID.Width = 1F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.TextBox8,
            this.TextBox7,
            this.Label11,
            this.Label13,
            this.txtDe});
            this.GroupFooter1.Height = 0.217F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.NewPage = GrapeCity.ActiveReports.SectionReportModel.NewPage.After;
            // 
            // TextBox8
            // 
            this.TextBox8.DataField = "TTWH";
            this.TextBox8.Height = 0.2F;
            this.TextBox8.Left = 1.875F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Style = "color: Black";
            this.TextBox8.Text = null;
            this.TextBox8.Top = 0F;
            this.TextBox8.Width = 4.24F;
            // 
            // TextBox7
            // 
            this.TextBox7.DataField = "TTW";
            this.TextBox7.Height = 0.2F;
            this.TextBox7.Left = 1.875F;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.Style = "color: Black";
            this.TextBox7.Text = null;
            this.TextBox7.Top = 0.017F;
            this.TextBox7.Width = 2.3125F;
            // 
            // Label11
            // 
            this.Label11.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label11.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label11.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label11.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label11.Height = 0.2F;
            this.Label11.HyperLink = null;
            this.Label11.Left = 0.65625F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center; ddo-font-vertical: none";
            this.Label11.Text = "Total Working:";
            this.Label11.Top = 0F;
            this.Label11.Width = 1.183333F;
            // 
            // Label13
            // 
            this.Label13.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label13.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label13.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label13.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.Solid;
            this.Label13.Height = 0.2F;
            this.Label13.HyperLink = null;
            this.Label13.Left = 6.1875F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; text-" +
    "align: center";
            this.Label13.Text = "Total Deduction:";
            this.Label13.Top = 0F;
            this.Label13.Width = 1F;
            // 
            // txtDe
            // 
            this.txtDe.DataField = "TTW";
            this.txtDe.Height = 0.2F;
            this.txtDe.Left = 7.203125F;
            this.txtDe.Name = "txtDe";
            this.txtDe.Style = "color: Black; font-size: 10pt; font-style: italic; font-weight: bold; ddo-char-se" +
    "t: 1";
            this.txtDe.Text = null;
            this.txtDe.Top = 0F;
            this.txtDe.Width = 0.6875F;
            // 
            // rpEmployeeInOutActivity
            // 
            this.MasterReport = false;
            this.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.864583F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader2);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter1);
            this.Sections.Add(this.GroupFooter2);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.txtabsent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMissPunch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtREmarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCompName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderArabic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtm15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtm30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtm45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtem45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        private GrapeCity.ActiveReports.SectionReportModel.Detail Detail;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtabsent;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox3;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtin;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtout;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtMissPunch;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtREmarks;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox5;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox6;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtDeduct;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox9;
        private GrapeCity.ActiveReports.SectionReportModel.PageHeader PageHeader;
        private GrapeCity.ActiveReports.SectionReportModel.Label lblCompName;
        private GrapeCity.ActiveReports.SectionReportModel.Shape Shape2;
        private GrapeCity.ActiveReports.SectionReportModel.Shape Shape;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label5;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtHeaderCompany;
        private GrapeCity.ActiveReports.SectionReportModel.Picture Picture;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtHeaderArabic;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtPeriod;
        private GrapeCity.ActiveReports.SectionReportModel.PageFooter PageFooter;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader GroupHeader2;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter GroupFooter2;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader GroupHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label4;
        private GrapeCity.ActiveReports.SectionReportModel.Label lbl2;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label3;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label2;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label7;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label6;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox1;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label8;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label9;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label10;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label12;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label14;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter GroupFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox8;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox7;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label11;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label13;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtDe;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtSF;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtse;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtm15;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtm30;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtm45;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtem30;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtem45;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtem15;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtTID;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox txtStatus;
    
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
        }
    
}