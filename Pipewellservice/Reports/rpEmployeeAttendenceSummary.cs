using Pipewellservice.App_Start;
using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;


public partial class rpEmployeeAttendenceSummary : GrapeCity.ActiveReports.SectionReport
{
    public rpEmployeeAttendenceSummary()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpEmployeeAttendenceSummary));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.Shape1 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.TextBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.lblSr = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox12 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox9 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox10 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox8 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox11 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox15 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox14 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line46 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.textBox13 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line36 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line35 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line34 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line32 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line31 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line25 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.textBox7 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line11 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line10 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line7 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line18 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line12 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line9 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.lbl2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label17 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label15 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label16 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label18 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line5 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line38 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line30 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line29 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line28 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line24 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line23 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line22 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line21 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line15 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line6 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line16 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line14 = new GrapeCity.ActiveReports.SectionReportModel.Line();
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
            this.line13 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line19 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.Line17 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderArabic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape1,
            this.TextBox3,
            this.TextBox2,
            this.lblSr,
            this.textBox12,
            this.textBox9,
            this.TextBox4,
            this.TextBox1,
            this.textBox5,
            this.textBox10,
            this.textBox8,
            this.textBox11,
            this.textBox6,
            this.textBox15,
            this.textBox14,
            this.line46,
            this.textBox13,
            this.line36,
            this.line35,
            this.line34,
            this.line32,
            this.line31,
            this.line25,
            this.textBox7,
            this.line11,
            this.line10,
            this.line7,
            this.Line18,
            this.Line12,
            this.Line9,
            this.line3,
            this.Line17});
            this.Detail.Height = 0.1845278F;
            this.Detail.Name = "Detail";
            // 
            // Shape1
            // 
            this.Shape1.Height = 0.1875F;
            this.Shape1.Left = 0F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 0F;
            this.Shape1.Width = 8.569F;
            // 
            // TextBox3
            // 
            this.TextBox3.DataField = "Absent";
            this.TextBox3.Height = 0.1875F;
            this.TextBox3.Left = 2.562F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Style = "color: Black; text-align: center";
            this.TextBox3.Tag = "";
            this.TextBox3.Text = "0";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 0.4120002F;
            // 
            // TextBox2
            // 
            this.TextBox2.DataField = "EmployeeName";
            this.TextBox2.Height = 0.1875F;
            this.TextBox2.Left = 0.5F;
            this.TextBox2.MultiLine = false;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.ShrinkToFit = true;
            this.TextBox2.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: left; white-spa" +
    "ce: nowrap; ddo-shrink-to-fit: true";
            this.TextBox2.Text = "0";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 1.588F;
            // 
            // lblSr
            // 
            this.lblSr.DataField = "EmployeeID";
            this.lblSr.Height = 0.1875F;
            this.lblSr.Left = 0.03125F;
            this.lblSr.Name = "lblSr";
            this.lblSr.ShrinkToFit = true;
            this.lblSr.Style = "color: Black; text-align: left; ddo-shrink-to-fit: true";
            this.lblSr.Tag = "";
            this.lblSr.Text = "0";
            this.lblSr.Top = 0F;
            this.lblSr.Width = 0.45275F;
            // 
            // textBox12
            // 
            this.textBox12.DataField = "Marriage";
            this.textBox12.Height = 0.1875F;
            this.textBox12.Left = 6.532F;
            this.textBox12.Name = "textBox12";
            this.textBox12.Style = "color: Black; text-align: center";
            this.textBox12.Tag = "";
            this.textBox12.Text = "0";
            this.textBox12.Top = 0F;
            this.textBox12.Width = 0.5180001F;
            // 
            // textBox9
            // 
            this.textBox9.DataField = "[Emergency Leave]";
            this.textBox9.Height = 0.1875F;
            this.textBox9.Left = 5.001F;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "color: Black; text-align: center";
            this.textBox9.Tag = "";
            this.textBox9.Text = "0";
            this.textBox9.Top = 0F;
            this.textBox9.Width = 0.5F;
            // 
            // TextBox4
            // 
            this.TextBox4.DataField = "[Weekly Off]";
            this.TextBox4.Height = 0.1875F;
            this.TextBox4.Left = 3F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Style = "color: Black; text-align: center";
            this.TextBox4.Tag = "";
            this.TextBox4.Text = "0";
            this.TextBox4.Top = 0F;
            this.TextBox4.Width = 0.5309999F;
            // 
            // TextBox1
            // 
            this.TextBox1.DataField = "Present";
            this.TextBox1.Height = 0.1875F;
            this.TextBox1.Left = 2.088F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "color: Black; text-align: center";
            this.TextBox1.Tag = "";
            this.TextBox1.Text = "0";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 0.474F;
            // 
            // textBox5
            // 
            this.textBox5.DataField = "[Bereavement Leave]";
            this.textBox5.Height = 0.1875F;
            this.textBox5.Left = 4.47F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "color: Black; text-align: center";
            this.textBox5.Tag = "";
            this.textBox5.Text = "0";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.5305004F;
            // 
            // textBox10
            // 
            this.textBox10.DataField = "[Exam Leave]";
            this.textBox10.Height = 0.1875F;
            this.textBox10.Left = 5.501F;
            this.textBox10.Name = "textBox10";
            this.textBox10.Style = "color: Black; text-align: center";
            this.textBox10.Tag = "";
            this.textBox10.Text = "0";
            this.textBox10.Top = 1.192093E-07F;
            this.textBox10.Width = 0.3300004F;
            // 
            // textBox8
            // 
            this.textBox8.DataField = "[Hajj Leave]";
            this.textBox8.Height = 0.1875F;
            this.textBox8.Left = 5.831F;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "color: Black; text-align: center";
            this.textBox8.Tag = "";
            this.textBox8.Text = "0";
            this.textBox8.Top = 0F;
            this.textBox8.Width = 0.277F;
            // 
            // textBox11
            // 
            this.textBox11.DataField = "[Paternity Leave]";
            this.textBox11.Height = 0.1875F;
            this.textBox11.Left = 7.598001F;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "color: Black; text-align: center";
            this.textBox11.Tag = "";
            this.textBox11.Text = "0";
            this.textBox11.Top = 0F;
            this.textBox11.Width = 0.5190005F;
            // 
            // textBox6
            // 
            this.textBox6.DataField = "[Annual Leave]";
            this.textBox6.Height = 0.1875F;
            this.textBox6.Left = 3.594501F;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "color: Black; text-align: center";
            this.textBox6.Tag = "";
            this.textBox6.Text = "0";
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.4074993F;
            // 
            // textBox15
            // 
            this.textBox15.DataField = "[Unpaid Leave]";
            this.textBox15.Height = 0.1875F;
            this.textBox15.Left = 8.117001F;
            this.textBox15.Name = "textBox15";
            this.textBox15.Style = "color: Black; text-align: center";
            this.textBox15.Tag = "";
            this.textBox15.Text = "0";
            this.textBox15.Top = 0F;
            this.textBox15.Width = 0.4375F;
            // 
            // textBox14
            // 
            this.textBox14.DataField = "[Umrah Leave]";
            this.textBox14.Height = 0.1875F;
            this.textBox14.Left = 6.108F;
            this.textBox14.Name = "textBox14";
            this.textBox14.Style = "color: Black; text-align: center";
            this.textBox14.Tag = "";
            this.textBox14.Text = "0";
            this.textBox14.Top = 0F;
            this.textBox14.Width = 0.4375F;
            // 
            // line46
            // 
            this.line46.Height = 0.17F;
            this.line46.Left = 8.117001F;
            this.line46.LineWeight = 1F;
            this.line46.Name = "line46";
            this.line46.Top = 0.002999976F;
            this.line46.Width = 0F;
            this.line46.X1 = 8.117001F;
            this.line46.X2 = 8.117001F;
            this.line46.Y1 = 0.173F;
            this.line46.Y2 = 0.002999976F;
            // 
            // textBox13
            // 
            this.textBox13.DataField = "[Maternity Leave]";
            this.textBox13.Height = 0.1875F;
            this.textBox13.Left = 7.05F;
            this.textBox13.Name = "textBox13";
            this.textBox13.Style = "color: Black; text-align: center";
            this.textBox13.Tag = "";
            this.textBox13.Text = "0";
            this.textBox13.Top = 0F;
            this.textBox13.Width = 0.5380001F;
            // 
            // line36
            // 
            this.line36.Height = 0.17F;
            this.line36.Left = 7.588F;
            this.line36.LineWeight = 1F;
            this.line36.Name = "line36";
            this.line36.Top = 0.002999976F;
            this.line36.Width = 0F;
            this.line36.X1 = 7.588F;
            this.line36.X2 = 7.588F;
            this.line36.Y1 = 0.173F;
            this.line36.Y2 = 0.002999976F;
            // 
            // line35
            // 
            this.line35.Height = 0.17F;
            this.line35.Left = 7.050001F;
            this.line35.LineWeight = 1F;
            this.line35.Name = "line35";
            this.line35.Top = 0.002999976F;
            this.line35.Width = 0F;
            this.line35.X1 = 7.050001F;
            this.line35.X2 = 7.050001F;
            this.line35.Y1 = 0.173F;
            this.line35.Y2 = 0.002999976F;
            // 
            // line34
            // 
            this.line34.Height = 0.17F;
            this.line34.Left = 6.108F;
            this.line34.LineWeight = 1F;
            this.line34.Name = "line34";
            this.line34.Top = 0.002999976F;
            this.line34.Width = 0F;
            this.line34.X1 = 6.108F;
            this.line34.X2 = 6.108F;
            this.line34.Y1 = 0.173F;
            this.line34.Y2 = 0.002999976F;
            // 
            // line32
            // 
            this.line32.Height = 0.17F;
            this.line32.Left = 5.831F;
            this.line32.LineWeight = 1F;
            this.line32.Name = "line32";
            this.line32.Top = 0.002999976F;
            this.line32.Width = 0F;
            this.line32.X1 = 5.831F;
            this.line32.X2 = 5.831F;
            this.line32.Y1 = 0.173F;
            this.line32.Y2 = 0.002999976F;
            // 
            // line31
            // 
            this.line31.Height = 0.17F;
            this.line31.Left = 5.501F;
            this.line31.LineWeight = 1F;
            this.line31.Name = "line31";
            this.line31.Top = 0.002999976F;
            this.line31.Width = 0F;
            this.line31.X1 = 5.501F;
            this.line31.X2 = 5.501F;
            this.line31.Y1 = 0.173F;
            this.line31.Y2 = 0.002999976F;
            // 
            // line25
            // 
            this.line25.Height = 0.17F;
            this.line25.Left = 5.001F;
            this.line25.LineWeight = 1F;
            this.line25.Name = "line25";
            this.line25.Top = 0.002999976F;
            this.line25.Width = 0F;
            this.line25.X1 = 5.001F;
            this.line25.X2 = 5.001F;
            this.line25.Y1 = 0.173F;
            this.line25.Y2 = 0.002999976F;
            // 
            // textBox7
            // 
            this.textBox7.DataField = "[Athletic Leave]";
            this.textBox7.Height = 0.1875F;
            this.textBox7.Left = 4.002F;
            this.textBox7.Name = "textBox7";
            this.textBox7.Style = "color: Black; text-align: center";
            this.textBox7.Tag = "";
            this.textBox7.Text = "0";
            this.textBox7.Top = 0F;
            this.textBox7.Width = 0.4679999F;
            // 
            // line11
            // 
            this.line11.Height = 0.17F;
            this.line11.Left = 4.47F;
            this.line11.LineWeight = 1F;
            this.line11.Name = "line11";
            this.line11.Top = 0.002999976F;
            this.line11.Width = 0F;
            this.line11.X1 = 4.47F;
            this.line11.X2 = 4.47F;
            this.line11.Y1 = 0.173F;
            this.line11.Y2 = 0.002999976F;
            // 
            // line10
            // 
            this.line10.Height = 0.17F;
            this.line10.Left = 4.002F;
            this.line10.LineWeight = 1F;
            this.line10.Name = "line10";
            this.line10.Top = 0.002999976F;
            this.line10.Width = 0F;
            this.line10.X1 = 4.002F;
            this.line10.X2 = 4.002F;
            this.line10.Y1 = 0.173F;
            this.line10.Y2 = 0.002999976F;
            // 
            // line7
            // 
            this.line7.Height = 0.17F;
            this.line7.Left = 3.594F;
            this.line7.LineWeight = 1F;
            this.line7.Name = "line7";
            this.line7.Top = 0.002999976F;
            this.line7.Width = 0F;
            this.line7.X1 = 3.594F;
            this.line7.X2 = 3.594F;
            this.line7.Y1 = 0.173F;
            this.line7.Y2 = 0.002999976F;
            // 
            // Line18
            // 
            this.Line18.Height = 0.17F;
            this.Line18.Left = 2.984F;
            this.Line18.LineWeight = 1F;
            this.Line18.Name = "Line18";
            this.Line18.Top = 0.002999976F;
            this.Line18.Width = 0F;
            this.Line18.X1 = 2.984F;
            this.Line18.X2 = 2.984F;
            this.Line18.Y1 = 0.173F;
            this.Line18.Y2 = 0.002999976F;
            // 
            // Line12
            // 
            this.Line12.Height = 0.17F;
            this.Line12.Left = 2.562F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 0.002999976F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 2.562F;
            this.Line12.X2 = 2.562F;
            this.Line12.Y1 = 0.173F;
            this.Line12.Y2 = 0.002999976F;
            // 
            // Line9
            // 
            this.Line9.Height = 0.17F;
            this.Line9.Left = 0.484375F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0.015625F;
            this.Line9.Width = 0F;
            this.Line9.X1 = 0.484375F;
            this.Line9.X2 = 0.484375F;
            this.Line9.Y1 = 0.185625F;
            this.Line9.Y2 = 0.015625F;
            // 
            // line3
            // 
            this.line3.Height = 0.17F;
            this.line3.Left = 2.088F;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0.002999976F;
            this.line3.Width = 0F;
            this.line3.X1 = 2.088F;
            this.line3.X2 = 2.088F;
            this.line3.Y1 = 0.173F;
            this.line3.Y2 = 0.002999976F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.lbl2,
            this.Label3,
            this.Label2,
            this.Label4,
            this.label6,
            this.label7,
            this.label11,
            this.label12,
            this.label8,
            this.label10,
            this.label9,
            this.label17,
            this.label15,
            this.label16,
            this.label18,
            this.label13,
            this.line5,
            this.line38,
            this.line30,
            this.line29,
            this.line28,
            this.line24,
            this.line23,
            this.line22,
            this.line21,
            this.line15,
            this.line6,
            this.line4,
            this.Line1,
            this.Line16,
            this.Line14,
            this.Shape2,
            this.Shape,
            this.Label5,
            this.TextBox,
            this.Label,
            this.txtHeaderCompany,
            this.Picture,
            this.txtHeaderArabic,
            this.Label1,
            this.txtPeriod,
            this.line13,
            this.line2,
            this.line19});
            this.PageHeader.Height = 1.660069F;
            this.PageHeader.Name = "PageHeader";
            // 
            // lbl2
            // 
            this.lbl2.Height = 0.2700001F;
            this.lbl2.HyperLink = null;
            this.lbl2.Left = 0.499999F;
            this.lbl2.Name = "lbl2";
            this.lbl2.Style = "color: Black; font-family: Book Antiqua; font-size: 8pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.lbl2.Text = "Employee Name";
            this.lbl2.Top = 1.397F;
            this.lbl2.Width = 1.588F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.2700001F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0.06249905F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "color: Black; font-family: Book Antiqua; font-size: 8pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.Label3.Text = "Code";
            this.Label3.Top = 1.397F;
            this.Label3.Width = 0.5F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2700001F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 2.088F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "color: Black; font-family: Arial Rounded MT Bold; font-size: 8pt; font-weight: no" +
    "rmal; text-align: center; ddo-char-set: 1; ddo-font-vertical: none";
            this.Label2.Text = "Present";
            this.Label2.Top = 1.397F;
            this.Label2.Width = 0.474F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.2700001F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 2.562F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "color: Black; font-family: Arial Rounded MT Bold; font-size: 8pt; font-weight: no" +
    "rmal; text-align: center; ddo-char-set: 1";
            this.Label4.Text = "Absent";
            this.Label4.Top = 1.397F;
            this.Label4.Width = 0.4120002F;
            // 
            // label6
            // 
            this.label6.Height = 0.2700001F;
            this.label6.HyperLink = null;
            this.label6.Left = 3F;
            this.label6.Name = "label6";
            this.label6.Style = "color: Black; font-family: Arial Rounded MT Bold; font-size: 8pt; font-weight: no" +
    "rmal; text-align: center; ddo-char-set: 1; ddo-font-vertical: none";
            this.label6.Text = "Weekly Off";
            this.label6.Top = 1.397F;
            this.label6.Width = 0.5935004F;
            // 
            // label7
            // 
            this.label7.Height = 0.2700001F;
            this.label7.HyperLink = null;
            this.label7.Left = 3.594501F;
            this.label7.Name = "label7";
            this.label7.Style = "color: Black; font-family: Arial Rounded MT Bold; font-size: 8pt; font-weight: no" +
    "rmal; text-align: center; ddo-char-set: 1";
            this.label7.Text = "Annual Leave";
            this.label7.Top = 1.397F;
            this.label7.Width = 0.4074993F;
            // 
            // label11
            // 
            this.label11.Height = 0.2700001F;
            this.label11.HyperLink = null;
            this.label11.Left = 4.002F;
            this.label11.Name = "label11";
            this.label11.Style = "color: Black; font-family: Arial Rounded MT Bold; font-size: 8pt; font-weight: no" +
    "rmal; text-align: center; ddo-char-set: 1; ddo-font-vertical: none";
            this.label11.Text = "Athletic Leave";
            this.label11.Top = 1.397F;
            this.label11.Width = 0.4679999F;
            // 
            // label12
            // 
            this.label12.Height = 0.2700001F;
            this.label12.HyperLink = null;
            this.label12.Left = 4.469501F;
            this.label12.Name = "label12";
            this.label12.Style = "color: Black; font-family: Arial Rounded MT Bold; font-size: 8pt; font-weight: no" +
    "rmal; text-align: center; ddo-char-set: 1";
            this.label12.Text = "Bereavement";
            this.label12.Top = 1.397F;
            this.label12.Width = 0.5305004F;
            // 
            // label8
            // 
            this.label8.Height = 0.2700001F;
            this.label8.HyperLink = null;
            this.label8.Left = 5.001F;
            this.label8.Name = "label8";
            this.label8.Style = "color: Black; font-family: Arial Rounded MT Bold; font-size: 8pt; font-weight: no" +
    "rmal; text-align: center; ddo-char-set: 1; ddo-font-vertical: none";
            this.label8.Text = "Emerg..";
            this.label8.Top = 1.397F;
            this.label8.Width = 0.5F;
            // 
            // label10
            // 
            this.label10.Height = 0.2700001F;
            this.label10.HyperLink = null;
            this.label10.Left = 5.501F;
            this.label10.Name = "label10";
            this.label10.Style = "color: Black; font-family: Arial Rounded MT Bold; font-size: 8pt; font-weight: no" +
    "rmal; text-align: center; ddo-char-set: 1";
            this.label10.Text = "Exam";
            this.label10.Top = 1.397F;
            this.label10.Width = 0.3300004F;
            // 
            // label9
            // 
            this.label9.Height = 0.2700001F;
            this.label9.HyperLink = null;
            this.label9.Left = 5.831F;
            this.label9.Name = "label9";
            this.label9.Style = "color: Black; font-family: Arial Rounded MT Bold; font-size: 8pt; font-weight: no" +
    "rmal; text-align: center; ddo-char-set: 1";
            this.label9.Text = "Hajj";
            this.label9.Top = 1.397F;
            this.label9.Width = 0.277F;
            // 
            // label17
            // 
            this.label17.Height = 0.2700001F;
            this.label17.HyperLink = null;
            this.label17.Left = 6.108F;
            this.label17.Name = "label17";
            this.label17.Style = "color: Black; font-family: Arial Rounded MT Bold; font-size: 8pt; font-weight: no" +
    "rmal; text-align: center; ddo-char-set: 1; ddo-font-vertical: none";
            this.label17.Text = "Umrah";
            this.label17.Top = 1.397F;
            this.label17.Width = 0.4375F;
            // 
            // label15
            // 
            this.label15.Height = 0.2700001F;
            this.label15.HyperLink = null;
            this.label15.Left = 6.532F;
            this.label15.Name = "label15";
            this.label15.Style = "color: Black; font-family: Arial Rounded MT Bold; font-size: 8pt; font-weight: no" +
    "rmal; text-align: center; ddo-char-set: 1; ddo-font-vertical: none";
            this.label15.Text = "Marriage";
            this.label15.Top = 1.397F;
            this.label15.Width = 0.5180001F;
            // 
            // label16
            // 
            this.label16.Height = 0.2700001F;
            this.label16.HyperLink = null;
            this.label16.Left = 7.05F;
            this.label16.Name = "label16";
            this.label16.Style = "color: Black; font-family: Arial Rounded MT Bold; font-size: 8pt; font-weight: no" +
    "rmal; text-align: center; ddo-char-set: 1";
            this.label16.Text = "Maternity";
            this.label16.Top = 1.397F;
            this.label16.Width = 0.5380001F;
            // 
            // label18
            // 
            this.label18.Height = 0.2700001F;
            this.label18.HyperLink = null;
            this.label18.Left = 8.117001F;
            this.label18.Name = "label18";
            this.label18.Style = "color: Black; font-family: Arial Rounded MT Bold; font-size: 8pt; font-weight: no" +
    "rmal; text-align: center; ddo-char-set: 1";
            this.label18.Text = "Unpaid";
            this.label18.Top = 1.397F;
            this.label18.Width = 0.4680004F;
            // 
            // label13
            // 
            this.label13.Height = 0.2700001F;
            this.label13.HyperLink = null;
            this.label13.Left = 7.598001F;
            this.label13.Name = "label13";
            this.label13.Style = "color: Black; font-family: Arial Rounded MT Bold; font-size: 8pt; font-weight: no" +
    "rmal; text-align: center; ddo-char-set: 1; ddo-font-vertical: none";
            this.label13.Text = "Paternity";
            this.label13.Top = 1.397F;
            this.label13.Width = 0.5190005F;
            // 
            // line5
            // 
            this.line5.Height = 0.3080001F;
            this.line5.Left = 2.561626F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 1.359F;
            this.line5.Width = 0.0003740788F;
            this.line5.X1 = 2.562F;
            this.line5.X2 = 2.561626F;
            this.line5.Y1 = 1.667F;
            this.line5.Y2 = 1.359F;
            // 
            // line38
            // 
            this.line38.Height = 0.3080001F;
            this.line38.Left = 8.116627F;
            this.line38.LineWeight = 1F;
            this.line38.Name = "line38";
            this.line38.Top = 1.359F;
            this.line38.Width = 0.0003738403F;
            this.line38.X1 = 8.117001F;
            this.line38.X2 = 8.116627F;
            this.line38.Y1 = 1.667F;
            this.line38.Y2 = 1.359F;
            // 
            // line30
            // 
            this.line30.Height = 0.3080001F;
            this.line30.Left = 6.107625F;
            this.line30.LineWeight = 1F;
            this.line30.Name = "line30";
            this.line30.Top = 1.359F;
            this.line30.Width = 0.0003738403F;
            this.line30.X1 = 6.107999F;
            this.line30.X2 = 6.107625F;
            this.line30.Y1 = 1.667F;
            this.line30.Y2 = 1.359F;
            // 
            // line29
            // 
            this.line29.Height = 0.3080001F;
            this.line29.Left = 7.049626F;
            this.line29.LineWeight = 1F;
            this.line29.Name = "line29";
            this.line29.Top = 1.359F;
            this.line29.Width = 0.0003743172F;
            this.line29.X1 = 7.05F;
            this.line29.X2 = 7.049626F;
            this.line29.Y1 = 1.667F;
            this.line29.Y2 = 1.359F;
            // 
            // line28
            // 
            this.line28.Height = 0.3080001F;
            this.line28.Left = 7.587626F;
            this.line28.LineWeight = 1F;
            this.line28.Name = "line28";
            this.line28.Top = 1.359F;
            this.line28.Width = 0.0003728867F;
            this.line28.X1 = 7.587999F;
            this.line28.X2 = 7.587626F;
            this.line28.Y1 = 1.667F;
            this.line28.Y2 = 1.359F;
            // 
            // line24
            // 
            this.line24.Height = 0.3080001F;
            this.line24.Left = 6.532001F;
            this.line24.LineWeight = 1F;
            this.line24.Name = "line24";
            this.line24.Top = 1.359F;
            this.line24.Width = 0.0003738403F;
            this.line24.X1 = 6.532374F;
            this.line24.X2 = 6.532001F;
            this.line24.Y1 = 1.667F;
            this.line24.Y2 = 1.359F;
            // 
            // line23
            // 
            this.line23.Height = 0.3080001F;
            this.line23.Left = 4.001626F;
            this.line23.LineWeight = 1F;
            this.line23.Name = "line23";
            this.line23.Top = 1.359F;
            this.line23.Width = 0.0003738403F;
            this.line23.X1 = 4.002F;
            this.line23.X2 = 4.001626F;
            this.line23.Y1 = 1.667F;
            this.line23.Y2 = 1.359F;
            // 
            // line22
            // 
            this.line22.Height = 0.3080001F;
            this.line22.Left = 4.469626F;
            this.line22.LineWeight = 1F;
            this.line22.Name = "line22";
            this.line22.Top = 1.359F;
            this.line22.Width = 0.0003738403F;
            this.line22.X1 = 4.47F;
            this.line22.X2 = 4.469626F;
            this.line22.Y1 = 1.667F;
            this.line22.Y2 = 1.359F;
            // 
            // line21
            // 
            this.line21.Height = 0.3080001F;
            this.line21.Left = 5.000627F;
            this.line21.LineWeight = 1F;
            this.line21.Name = "line21";
            this.line21.Top = 1.359F;
            this.line21.Width = 0.0003728867F;
            this.line21.X1 = 5.001F;
            this.line21.X2 = 5.000627F;
            this.line21.Y1 = 1.667F;
            this.line21.Y2 = 1.359F;
            // 
            // line15
            // 
            this.line15.Height = 0.3080001F;
            this.line15.Left = 5.500627F;
            this.line15.LineWeight = 1F;
            this.line15.Name = "line15";
            this.line15.Top = 1.359F;
            this.line15.Width = 0.0003728867F;
            this.line15.X1 = 5.501F;
            this.line15.X2 = 5.500627F;
            this.line15.Y1 = 1.667F;
            this.line15.Y2 = 1.359F;
            // 
            // line6
            // 
            this.line6.Height = 0.3080001F;
            this.line6.Left = 5.830626F;
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 1.359F;
            this.line6.Width = 0.0003738403F;
            this.line6.X1 = 5.831F;
            this.line6.X2 = 5.830626F;
            this.line6.Y1 = 1.667F;
            this.line6.Y2 = 1.359F;
            // 
            // line4
            // 
            this.line4.Height = 0.3080001F;
            this.line4.Left = 3.593625F;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 1.359F;
            this.line4.Width = 0.0003738403F;
            this.line4.X1 = 3.593999F;
            this.line4.X2 = 3.593625F;
            this.line4.Y1 = 1.667F;
            this.line4.Y2 = 1.359F;
            // 
            // Line1
            // 
            this.Line1.Height = 0.3080001F;
            this.Line1.Left = 2.087626F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.359F;
            this.Line1.Width = 0.0003740788F;
            this.Line1.X1 = 2.088F;
            this.Line1.X2 = 2.087626F;
            this.Line1.Y1 = 1.667F;
            this.Line1.Y2 = 1.359F;
            // 
            // Line16
            // 
            this.Line16.Height = 0.3080001F;
            this.Line16.Left = 2.983626F;
            this.Line16.LineWeight = 1F;
            this.Line16.Name = "Line16";
            this.Line16.Top = 1.359F;
            this.Line16.Width = 0.0003740788F;
            this.Line16.X1 = 2.984F;
            this.Line16.X2 = 2.983626F;
            this.Line16.Y1 = 1.667F;
            this.Line16.Y2 = 1.359F;
            // 
            // Line14
            // 
            this.Line14.Height = 0.3080001F;
            this.Line14.Left = 0.4836261F;
            this.Line14.LineWeight = 1F;
            this.Line14.Name = "Line14";
            this.Line14.Top = 1.359F;
            this.Line14.Width = 0.0003738999F;
            this.Line14.X1 = 0.484F;
            this.Line14.X2 = 0.4836261F;
            this.Line14.Y1 = 1.667F;
            this.Line14.Y2 = 1.359F;
            // 
            // Shape2
            // 
            this.Shape2.BackColor = System.Drawing.Color.White;
            this.Shape2.Height = 0.01041663F;
            this.Shape2.Left = 0F;
            this.Shape2.Name = "Shape2";
            this.Shape2.RoundingRadius = 9.999999F;
            this.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect;
            this.Shape2.Top = 1.34F;
            this.Shape2.Width = 8.582001F;
            // 
            // Shape
            // 
            this.Shape.BackColor = System.Drawing.Color.White;
            this.Shape.Height = 0.01041663F;
            this.Shape.Left = 0F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.RoundRect;
            this.Shape.Top = 1.115F;
            this.Shape.Width = 8.582001F;
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
            this.Picture.Width = 0.9324999F;
            // 
            // txtHeaderArabic
            // 
            this.txtHeaderArabic.Height = 0.375F;
            this.txtHeaderArabic.Left = 4.375F;
            this.txtHeaderArabic.Name = "txtHeaderArabic";
            this.txtHeaderArabic.Style = "color: Black; font-family: Tajawal; font-size: 21.75pt; font-weight: bold; text-a" +
    "lign: center; ddo-char-set: 1";
            this.txtHeaderArabic.Text = null;
            this.txtHeaderArabic.Top = 0.3125F;
            this.txtHeaderArabic.Width = 4.18F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0.0625F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "color: Black; font-family: Book Antiqua; font-size: 12pt; font-weight: bold; text" +
    "-align: center; text-decoration: underline; ddo-char-set: 1";
            this.Label1.Text = "Monthly Attendance Report ";
            this.Label1.Top = 0.8125F;
            this.Label1.Width = 2.1875F;
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
            // line13
            // 
            this.line13.Height = 0.2F;
            this.line13.Left = 8.585F;
            this.line13.LineWeight = 1F;
            this.line13.Name = "line13";
            this.line13.Top = 1.359F;
            this.line13.Width = 0F;
            this.line13.X1 = 8.585F;
            this.line13.X2 = 8.585F;
            this.line13.Y1 = 1.559F;
            this.line13.Y2 = 1.359F;
            // 
            // line2
            // 
            this.line2.Height = 0.1900001F;
            this.line2.Left = 0F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 1.125F;
            this.line2.Width = 0F;
            this.line2.X1 = 0F;
            this.line2.X2 = 0F;
            this.line2.Y1 = 1.315F;
            this.line2.Y2 = 1.125F;
            // 
            // line19
            // 
            this.line19.Height = 0.3080001F;
            this.line19.Left = 0.001F;
            this.line19.LineWeight = 1F;
            this.line19.Name = "line19";
            this.line19.Top = 1.359F;
            this.line19.Width = 0F;
            this.line19.X1 = 0.001F;
            this.line19.X2 = 0.001F;
            this.line19.Y1 = 1.667F;
            this.line19.Y2 = 1.359F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0.2291667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // Line17
            // 
            this.Line17.Height = 0.17F;
            this.Line17.Left = 6.532001F;
            this.Line17.LineWeight = 1F;
            this.Line17.Name = "Line17";
            this.Line17.Top = 0.002999976F;
            this.Line17.Width = 0F;
            this.Line17.X1 = 6.532001F;
            this.Line17.X2 = 6.532001F;
            this.Line17.Y1 = 0.173F;
            this.Line17.Y2 = 0.002999976F;
            // 
            // rpEmployeeAttendenceSummary
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.582001F;
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
            this.ReportStart += new System.EventHandler(this.rpEmployeeAttendenceSummary_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeaderArabic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    private GrapeCity.ActiveReports.SectionReportModel.Detail Detail;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox2;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line9;
    private GrapeCity.ActiveReports.SectionReportModel.PageHeader PageHeader;
    private GrapeCity.ActiveReports.SectionReportModel.Label lbl2;
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
    private GrapeCity.ActiveReports.SectionReportModel.PageFooter PageFooter;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox1;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line12;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line18;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox3;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox4;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line16;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line1;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label2;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox5;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox6;
    private GrapeCity.ActiveReports.SectionReportModel.Line line7;
    private GrapeCity.ActiveReports.SectionReportModel.Line line10;
    private GrapeCity.ActiveReports.SectionReportModel.Line line11;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox7;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox8;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox9;
    private GrapeCity.ActiveReports.SectionReportModel.Line line25;
    private GrapeCity.ActiveReports.SectionReportModel.Line line31;
    private GrapeCity.ActiveReports.SectionReportModel.Line line32;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox10;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox11;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox12;
    private GrapeCity.ActiveReports.SectionReportModel.Line line34;
    private GrapeCity.ActiveReports.SectionReportModel.Line line35;
    private GrapeCity.ActiveReports.SectionReportModel.Line line36;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox13;
    private GrapeCity.ActiveReports.SectionReportModel.Line line46;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox14;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox15;
    private GrapeCity.ActiveReports.SectionReportModel.Line line4;
    private GrapeCity.ActiveReports.SectionReportModel.Label label7;
    private GrapeCity.ActiveReports.SectionReportModel.Line line6;
    private GrapeCity.ActiveReports.SectionReportModel.Line line15;
    private GrapeCity.ActiveReports.SectionReportModel.Label label10;
    private GrapeCity.ActiveReports.SectionReportModel.Line line21;
    private GrapeCity.ActiveReports.SectionReportModel.Line line22;
    private GrapeCity.ActiveReports.SectionReportModel.Line line23;
    private GrapeCity.ActiveReports.SectionReportModel.Label label11;
    private GrapeCity.ActiveReports.SectionReportModel.Label label12;
    private GrapeCity.ActiveReports.SectionReportModel.Line line24;
    private GrapeCity.ActiveReports.SectionReportModel.Label label9;
    private GrapeCity.ActiveReports.SectionReportModel.Label label13;
    private GrapeCity.ActiveReports.SectionReportModel.Line line28;
    private GrapeCity.ActiveReports.SectionReportModel.Line line29;
    private GrapeCity.ActiveReports.SectionReportModel.Line line30;
    private GrapeCity.ActiveReports.SectionReportModel.Label label15;
    private GrapeCity.ActiveReports.SectionReportModel.Label label16;
    private GrapeCity.ActiveReports.SectionReportModel.Label label17;
    private GrapeCity.ActiveReports.SectionReportModel.Line line13;
    private GrapeCity.ActiveReports.SectionReportModel.Line line38;
    private GrapeCity.ActiveReports.SectionReportModel.Label label18;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox lblSr;
    private GrapeCity.ActiveReports.SectionReportModel.Label label6;
    private GrapeCity.ActiveReports.SectionReportModel.Label label8;
    private GrapeCity.ActiveReports.SectionReportModel.Line line2;
    private GrapeCity.ActiveReports.SectionReportModel.Shape Shape2;
    private GrapeCity.ActiveReports.SectionReportModel.Shape Shape1;
    private GrapeCity.ActiveReports.SectionReportModel.Line line3;
    private GrapeCity.ActiveReports.SectionReportModel.Line line5;
    private GrapeCity.ActiveReports.SectionReportModel.Shape Shape;
    private GrapeCity.ActiveReports.SectionReportModel.Line line19;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line17;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label4;

    private void rpEmployeeAttendenceSummary_ReportStart(object sender, EventArgs e)
    {
        txtPeriod.Text = this.Parameters[0].Value;
        List<Constant> cont = AppData.Constants.FindAll(x => x.ParentID == (int)ParentEnums.REPORTHEADER);
        txtHeaderArabic.Text = cont.Find(x => x.Value == 5).Name;
        txtHeaderCompany.Text = cont.Find(x => x.Value == 4).Name;
    }
}