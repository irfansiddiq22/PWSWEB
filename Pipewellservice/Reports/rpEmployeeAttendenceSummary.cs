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
            this.TextBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line9 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line8 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line12 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line18 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.TextBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line7 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line10 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line11 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.textBox7 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox8 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox9 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line25 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line31 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line32 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.textBox10 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox11 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox12 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line34 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line35 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line36 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line37 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.textBox13 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line46 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.textBox14 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line47 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.textBox15 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
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
            this.Line16 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line17 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line5 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line6 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line15 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line20 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line21 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line22 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line23 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line24 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line26 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line27 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line28 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line29 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line30 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label15 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label16 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label17 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line13 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line38 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line39 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label18 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.lblSr = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape1,
            this.textBox15,
            this.textBox14,
            this.line46,
            this.textBox13,
            this.line37,
            this.line36,
            this.line35,
            this.line34,
            this.textBox12,
            this.textBox11,
            this.line32,
            this.line31,
            this.line25,
            this.textBox9,
            this.textBox7,
            this.line11,
            this.line10,
            this.line7,
            this.textBox6,
            this.textBox5,
            this.TextBox4,
            this.TextBox3,
            this.Line18,
            this.Line12,
            this.Line8,
            this.TextBox1,
            this.Line9,
            this.TextBox2,
            this.lblSr,
            this.textBox8,
            this.textBox10,
            this.Line2,
            this.line47});
            this.Detail.Height = 0.1666667F;
            this.Detail.Name = "Detail";
            // 
            // Shape1
            // 
            this.Shape1.Height = 0.1875F;
            this.Shape1.Left = 0F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 0F;
            this.Shape1.Width = 9.053F;
            // 
            // TextBox2
            // 
            this.TextBox2.DataField = "EmployeeName";
            this.TextBox2.Height = 0.1875F;
            this.TextBox2.Left = 0.5F;
            this.TextBox2.MultiLine = false;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: left; white-spa" +
    "ce: nowrap";
            this.TextBox2.Text = "0";
            this.TextBox2.Top = -0.015625F;
            this.TextBox2.Width = 1.588F;
            // 
            // Line2
            // 
            this.Line2.Height = 0.125F;
            this.Line2.Left = 0F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0.046875F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 0F;
            this.Line2.Y1 = 0.171875F;
            this.Line2.Y2 = 0.046875F;
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
            // TextBox1
            // 
            this.TextBox1.DataField = "Present";
            this.TextBox1.Height = 0.1875F;
            this.TextBox1.Left = 2.218F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "color: Black; text-align: right";
            this.TextBox1.Tag = "";
            this.TextBox1.Text = "0";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 0.4375F;
            // 
            // Line8
            // 
            this.Line8.Height = 0.17F;
            this.Line8.Left = 2.187F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 0F;
            this.Line8.Width = 0F;
            this.Line8.X1 = 2.187F;
            this.Line8.X2 = 2.187F;
            this.Line8.Y1 = 0.17F;
            this.Line8.Y2 = 0F;
            // 
            // Line12
            // 
            this.Line12.Height = 0.17F;
            this.Line12.Left = 2.655F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 0F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 2.655F;
            this.Line12.X2 = 2.655F;
            this.Line12.Y1 = 0.17F;
            this.Line12.Y2 = 0F;
            // 
            // Line18
            // 
            this.Line18.Height = 0.17F;
            this.Line18.Left = 3.156F;
            this.Line18.LineWeight = 1F;
            this.Line18.Name = "Line18";
            this.Line18.Top = 0F;
            this.Line18.Width = 0F;
            this.Line18.X1 = 3.156F;
            this.Line18.X2 = 3.156F;
            this.Line18.Y1 = 0.17F;
            this.Line18.Y2 = 0F;
            // 
            // TextBox3
            // 
            this.TextBox3.DataField = "Absent";
            this.TextBox3.Height = 0.1875F;
            this.TextBox3.Left = 2.687F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Style = "color: Black; text-align: right";
            this.TextBox3.Tag = "";
            this.TextBox3.Text = "0";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 0.4375F;
            // 
            // TextBox4
            // 
            this.TextBox4.DataField = "[Weekly Off]";
            this.TextBox4.Height = 0.1875F;
            this.TextBox4.Left = 3.156F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Style = "color: Black; text-align: right";
            this.TextBox4.Tag = "";
            this.TextBox4.Text = "0";
            this.TextBox4.Top = 0F;
            this.TextBox4.Width = 0.4375F;
            // 
            // textBox5
            // 
            this.textBox5.DataField = "[Bereavement Leave]";
            this.textBox5.Height = 0.1875F;
            this.textBox5.Left = 4.5945F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "color: Black; text-align: right";
            this.textBox5.Tag = "";
            this.textBox5.Text = "0";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.4375F;
            // 
            // textBox6
            // 
            this.textBox6.DataField = "[Annual Leave]";
            this.textBox6.Height = 0.1875F;
            this.textBox6.Left = 3.656501F;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "color: Black; text-align: right";
            this.textBox6.Tag = "";
            this.textBox6.Text = "0";
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.4375F;
            // 
            // line7
            // 
            this.line7.Height = 0.17F;
            this.line7.Left = 3.6255F;
            this.line7.LineWeight = 1F;
            this.line7.Name = "line7";
            this.line7.Top = 0F;
            this.line7.Width = 0F;
            this.line7.X1 = 3.6255F;
            this.line7.X2 = 3.6255F;
            this.line7.Y1 = 0.17F;
            this.line7.Y2 = 0F;
            // 
            // line10
            // 
            this.line10.Height = 0.17F;
            this.line10.Left = 4.093501F;
            this.line10.LineWeight = 1F;
            this.line10.Name = "line10";
            this.line10.Top = 0F;
            this.line10.Width = 0F;
            this.line10.X1 = 4.093501F;
            this.line10.X2 = 4.093501F;
            this.line10.Y1 = 0.17F;
            this.line10.Y2 = 0F;
            // 
            // line11
            // 
            this.line11.Height = 0.17F;
            this.line11.Left = 4.5945F;
            this.line11.LineWeight = 1F;
            this.line11.Name = "line11";
            this.line11.Top = 0F;
            this.line11.Width = 0F;
            this.line11.X1 = 4.5945F;
            this.line11.X2 = 4.5945F;
            this.line11.Y1 = 0.17F;
            this.line11.Y2 = 0F;
            // 
            // textBox7
            // 
            this.textBox7.DataField = "[Athletic Leave]";
            this.textBox7.Height = 0.1875F;
            this.textBox7.Left = 4.1255F;
            this.textBox7.Name = "textBox7";
            this.textBox7.Style = "color: Black; text-align: right";
            this.textBox7.Tag = "";
            this.textBox7.Text = "0";
            this.textBox7.Top = 0F;
            this.textBox7.Width = 0.4375F;
            // 
            // textBox8
            // 
            this.textBox8.DataField = "[Hajj Leave]";
            this.textBox8.Height = 0.1875F;
            this.textBox8.Left = 6.156F;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "color: Black; text-align: right";
            this.textBox8.Tag = "";
            this.textBox8.Text = "0";
            this.textBox8.Top = 0F;
            this.textBox8.Width = 0.4375F;
            // 
            // textBox9
            // 
            this.textBox9.DataField = "[Emergency Leave]";
            this.textBox9.Height = 0.1875F;
            this.textBox9.Left = 5.156F;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "color: Black; text-align: right";
            this.textBox9.Tag = "";
            this.textBox9.Text = "0";
            this.textBox9.Top = 0F;
            this.textBox9.Width = 0.4375F;
            // 
            // line25
            // 
            this.line25.Height = 0.17F;
            this.line25.Left = 5.032F;
            this.line25.LineWeight = 1F;
            this.line25.Name = "line25";
            this.line25.Top = 0F;
            this.line25.Width = 0F;
            this.line25.X1 = 5.032F;
            this.line25.X2 = 5.032F;
            this.line25.Y1 = 0.17F;
            this.line25.Y2 = 0F;
            // 
            // line31
            // 
            this.line31.Height = 0.17F;
            this.line31.Left = 5.655001F;
            this.line31.LineWeight = 1F;
            this.line31.Name = "line31";
            this.line31.Top = 0F;
            this.line31.Width = 0F;
            this.line31.X1 = 5.655001F;
            this.line31.X2 = 5.655001F;
            this.line31.Y1 = 0.17F;
            this.line31.Y2 = 0F;
            // 
            // line32
            // 
            this.line32.Height = 0.17F;
            this.line32.Left = 6.156F;
            this.line32.LineWeight = 1F;
            this.line32.Name = "line32";
            this.line32.Top = 0F;
            this.line32.Width = 0F;
            this.line32.X1 = 6.156F;
            this.line32.X2 = 6.156F;
            this.line32.Y1 = 0.17F;
            this.line32.Y2 = 0F;
            // 
            // textBox10
            // 
            this.textBox10.DataField = "[Exam Leave]";
            this.textBox10.Height = 0.1875F;
            this.textBox10.Left = 5.687F;
            this.textBox10.Name = "textBox10";
            this.textBox10.Style = "color: Black; text-align: right";
            this.textBox10.Tag = "";
            this.textBox10.Text = "0";
            this.textBox10.Top = 0F;
            this.textBox10.Width = 0.4375F;
            // 
            // textBox11
            // 
            this.textBox11.DataField = "[Paternity Leave]";
            this.textBox11.Height = 0.1875F;
            this.textBox11.Left = 7.595F;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "color: Black; text-align: right";
            this.textBox11.Tag = "";
            this.textBox11.Text = "0";
            this.textBox11.Top = 0F;
            this.textBox11.Width = 0.4375F;
            // 
            // textBox12
            // 
            this.textBox12.DataField = "Marriage";
            this.textBox12.Height = 0.1875F;
            this.textBox12.Left = 6.657001F;
            this.textBox12.Name = "textBox12";
            this.textBox12.Style = "color: Black; text-align: right";
            this.textBox12.Tag = "";
            this.textBox12.Text = "0";
            this.textBox12.Top = 0F;
            this.textBox12.Width = 0.4375F;
            // 
            // line34
            // 
            this.line34.Height = 0.17F;
            this.line34.Left = 6.626F;
            this.line34.LineWeight = 1F;
            this.line34.Name = "line34";
            this.line34.Top = 0F;
            this.line34.Width = 0F;
            this.line34.X1 = 6.626F;
            this.line34.X2 = 6.626F;
            this.line34.Y1 = 0.17F;
            this.line34.Y2 = 0F;
            // 
            // line35
            // 
            this.line35.Height = 0.17F;
            this.line35.Left = 7.094001F;
            this.line35.LineWeight = 1F;
            this.line35.Name = "line35";
            this.line35.Top = 0F;
            this.line35.Width = 0F;
            this.line35.X1 = 7.094001F;
            this.line35.X2 = 7.094001F;
            this.line35.Y1 = 0.17F;
            this.line35.Y2 = 0F;
            // 
            // line36
            // 
            this.line36.Height = 0.17F;
            this.line36.Left = 7.595F;
            this.line36.LineWeight = 1F;
            this.line36.Name = "line36";
            this.line36.Top = 0F;
            this.line36.Width = 0F;
            this.line36.X1 = 7.595F;
            this.line36.X2 = 7.595F;
            this.line36.Y1 = 0.17F;
            this.line36.Y2 = 0F;
            // 
            // line37
            // 
            this.line37.Height = 0.17F;
            this.line37.Left = 8.095F;
            this.line37.LineWeight = 1F;
            this.line37.Name = "line37";
            this.line37.Top = 0F;
            this.line37.Width = 0F;
            this.line37.X1 = 8.095F;
            this.line37.X2 = 8.095F;
            this.line37.Y1 = 0.17F;
            this.line37.Y2 = 0F;
            // 
            // textBox13
            // 
            this.textBox13.DataField = "[Maternity Leave]";
            this.textBox13.Height = 0.1875F;
            this.textBox13.Left = 7.126F;
            this.textBox13.Name = "textBox13";
            this.textBox13.Style = "color: Black; text-align: right";
            this.textBox13.Tag = "";
            this.textBox13.Text = "0";
            this.textBox13.Top = 0F;
            this.textBox13.Width = 0.4375F;
            // 
            // line46
            // 
            this.line46.Height = 0.17F;
            this.line46.Left = 8.563001F;
            this.line46.LineWeight = 1F;
            this.line46.Name = "line46";
            this.line46.Top = 0.031F;
            this.line46.Width = 0F;
            this.line46.X1 = 8.563001F;
            this.line46.X2 = 8.563001F;
            this.line46.Y1 = 0.201F;
            this.line46.Y2 = 0.031F;
            // 
            // textBox14
            // 
            this.textBox14.DataField = "[Umrah Leave]";
            this.textBox14.Height = 0.1875F;
            this.textBox14.Left = 8.063001F;
            this.textBox14.Name = "textBox14";
            this.textBox14.Style = "color: Black; text-align: right";
            this.textBox14.Tag = "";
            this.textBox14.Text = "0";
            this.textBox14.Top = 0F;
            this.textBox14.Width = 0.4375F;
            // 
            // line47
            // 
            this.line47.Height = 0.17F;
            this.line47.Left = 9.095F;
            this.line47.LineWeight = 1F;
            this.line47.Name = "line47";
            this.line47.Top = 0F;
            this.line47.Width = 0F;
            this.line47.X1 = 9.095F;
            this.line47.X2 = 9.095F;
            this.line47.Y1 = 0.17F;
            this.line47.Y2 = 0F;
            // 
            // textBox15
            // 
            this.textBox15.DataField = "[Unpaid Leave]";
            this.textBox15.Height = 0.1875F;
            this.textBox15.Left = 8.595F;
            this.textBox15.Name = "textBox15";
            this.textBox15.Style = "color: Black; text-align: right";
            this.textBox15.Tag = "";
            this.textBox15.Text = "0";
            this.textBox15.Top = 0F;
            this.textBox15.Width = 0.4375F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
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
            this.Line16,
            this.Line17,
            this.Line1,
            this.Label2,
            this.Label4,
            this.line3,
            this.line4,
            this.line5,
            this.label6,
            this.label7,
            this.label8,
            this.line6,
            this.line15,
            this.line20,
            this.label10,
            this.line21,
            this.line22,
            this.line23,
            this.label11,
            this.label12,
            this.line24,
            this.label9,
            this.label13,
            this.line26,
            this.line27,
            this.line28,
            this.line29,
            this.line30,
            this.label15,
            this.label16,
            this.label17,
            this.line13,
            this.line38,
            this.line39,
            this.label18});
            this.PageHeader.Height = 1.610612F;
            this.PageHeader.Name = "PageHeader";
            // 
            // lbl2
            // 
            this.lbl2.Height = 0.2F;
            this.lbl2.HyperLink = null;
            this.lbl2.Left = 0.5F;
            this.lbl2.Name = "lbl2";
            this.lbl2.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.lbl2.Text = "Employee Name";
            this.lbl2.Top = 1.4375F;
            this.lbl2.Width = 1.588F;
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
            this.Shape2.Width = 9.032001F;
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
            this.Shape.Width = 9.032001F;
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
    "-align: center; text-decoration: underline; ddo-char-set: 1";
            this.Label1.Text = "Monthly Attendance Report ";
            this.Label1.Top = 0.8125F;
            this.Label1.Width = 2.1875F;
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
            this.txtPeriod.Left = 0.84375F;
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: bold; te" +
    "xt-align: left; ddo-char-set: 1";
            this.txtPeriod.Text = null;
            this.txtPeriod.Top = 1.125F;
            this.txtPeriod.Width = 3.96875F;
            // 
            // Line14
            // 
            this.Line14.Height = 0.2F;
            this.Line14.Left = 0.484375F;
            this.Line14.LineWeight = 1F;
            this.Line14.Name = "Line14";
            this.Line14.Top = 1.3875F;
            this.Line14.Width = 0F;
            this.Line14.X1 = 0.484375F;
            this.Line14.X2 = 0.484375F;
            this.Line14.Y1 = 1.5875F;
            this.Line14.Y2 = 1.3875F;
            // 
            // Line16
            // 
            this.Line16.Height = 0.2F;
            this.Line16.Left = 3.094F;
            this.Line16.LineWeight = 1F;
            this.Line16.Name = "Line16";
            this.Line16.Top = 1.3875F;
            this.Line16.Width = 0F;
            this.Line16.X1 = 3.094F;
            this.Line16.X2 = 3.094F;
            this.Line16.Y1 = 1.5875F;
            this.Line16.Y2 = 1.3875F;
            // 
            // Line17
            // 
            this.Line17.Height = 0.2F;
            this.Line17.Left = 2.594F;
            this.Line17.LineWeight = 1F;
            this.Line17.Name = "Line17";
            this.Line17.Top = 1.3875F;
            this.Line17.Width = 0F;
            this.Line17.X1 = 2.594F;
            this.Line17.X2 = 2.594F;
            this.Line17.Y1 = 1.5875F;
            this.Line17.Y2 = 1.3875F;
            // 
            // Line1
            // 
            this.Line1.Height = 0.2F;
            this.Line1.Left = 2.125F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.3875F;
            this.Line1.Width = 0F;
            this.Line1.X1 = 2.125F;
            this.Line1.X2 = 2.125F;
            this.Line1.Y1 = 1.5875F;
            this.Line1.Y2 = 1.3875F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 2.125F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-f" +
    "ont-vertical: none";
            this.Label2.Text = "Present";
            this.Label2.Top = 1.4375F;
            this.Label2.Width = 0.46875F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 2.625F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.Label4.Text = "Absent";
            this.Label4.Top = 1.4375F;
            this.Label4.Width = 0.46875F;
            // 
            // line3
            // 
            this.line3.Height = 0.2F;
            this.line3.Left = 4.094F;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 1.3875F;
            this.line3.Width = 0F;
            this.line3.X1 = 4.094F;
            this.line3.X2 = 4.094F;
            this.line3.Y1 = 1.5875F;
            this.line3.Y2 = 1.3875F;
            // 
            // line4
            // 
            this.line4.Height = 0.2F;
            this.line4.Left = 3.594F;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 1.3875F;
            this.line4.Width = 0F;
            this.line4.X1 = 3.594F;
            this.line4.X2 = 3.594F;
            this.line4.Y1 = 1.5875F;
            this.line4.Y2 = 1.3875F;
            // 
            // line5
            // 
            this.line5.Height = 0.2F;
            this.line5.Left = 3.125F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 1.3875F;
            this.line5.Width = 0F;
            this.line5.X1 = 3.125F;
            this.line5.X2 = 3.125F;
            this.line5.Y1 = 1.5875F;
            this.line5.Y2 = 1.3875F;
            // 
            // label6
            // 
            this.label6.Height = 0.2F;
            this.label6.HyperLink = null;
            this.label6.Left = 3.125F;
            this.label6.Name = "label6";
            this.label6.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-f" +
    "ont-vertical: none";
            this.label6.Text = "Weekly Off";
            this.label6.Top = 1.4375F;
            this.label6.Width = 0.46875F;
            // 
            // label7
            // 
            this.label7.Height = 0.2F;
            this.label7.HyperLink = null;
            this.label7.Left = 3.625F;
            this.label7.Name = "label7";
            this.label7.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.label7.Text = "Annual Leave";
            this.label7.Top = 1.4375F;
            this.label7.Width = 0.46875F;
            // 
            // label8
            // 
            this.label8.Height = 0.2F;
            this.label8.HyperLink = null;
            this.label8.Left = 5.094001F;
            this.label8.Name = "label8";
            this.label8.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-f" +
    "ont-vertical: none";
            this.label8.Text = "Emergency";
            this.label8.Top = 1.4375F;
            this.label8.Width = 0.46875F;
            // 
            // line6
            // 
            this.line6.Height = 0.2F;
            this.line6.Left = 6.063001F;
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 1.3875F;
            this.line6.Width = 0F;
            this.line6.X1 = 6.063001F;
            this.line6.X2 = 6.063001F;
            this.line6.Y1 = 1.5875F;
            this.line6.Y2 = 1.3875F;
            // 
            // line15
            // 
            this.line15.Height = 0.2F;
            this.line15.Left = 5.563001F;
            this.line15.LineWeight = 1F;
            this.line15.Name = "line15";
            this.line15.Top = 1.3875F;
            this.line15.Width = 0F;
            this.line15.X1 = 5.563001F;
            this.line15.X2 = 5.563001F;
            this.line15.Y1 = 1.5875F;
            this.line15.Y2 = 1.3875F;
            // 
            // line20
            // 
            this.line20.Height = 0.2F;
            this.line20.Left = 5.094001F;
            this.line20.LineWeight = 1F;
            this.line20.Name = "line20";
            this.line20.Top = 1.3875F;
            this.line20.Width = 0F;
            this.line20.X1 = 5.094001F;
            this.line20.X2 = 5.094001F;
            this.line20.Y1 = 1.5875F;
            this.line20.Y2 = 1.3875F;
            // 
            // label10
            // 
            this.label10.Height = 0.2F;
            this.label10.HyperLink = null;
            this.label10.Left = 5.594001F;
            this.label10.Name = "label10";
            this.label10.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.label10.Text = "Exam";
            this.label10.Top = 1.4375F;
            this.label10.Width = 0.46875F;
            // 
            // line21
            // 
            this.line21.Height = 0.2F;
            this.line21.Left = 5.063001F;
            this.line21.LineWeight = 1F;
            this.line21.Name = "line21";
            this.line21.Top = 1.3875F;
            this.line21.Width = 0F;
            this.line21.X1 = 5.063001F;
            this.line21.X2 = 5.063001F;
            this.line21.Y1 = 1.5875F;
            this.line21.Y2 = 1.3875F;
            // 
            // line22
            // 
            this.line22.Height = 0.2F;
            this.line22.Left = 4.563001F;
            this.line22.LineWeight = 1F;
            this.line22.Name = "line22";
            this.line22.Top = 1.3875F;
            this.line22.Width = 0F;
            this.line22.X1 = 4.563001F;
            this.line22.X2 = 4.563001F;
            this.line22.Y1 = 1.5875F;
            this.line22.Y2 = 1.3875F;
            // 
            // line23
            // 
            this.line23.Height = 0.2F;
            this.line23.Left = 4.094001F;
            this.line23.LineWeight = 1F;
            this.line23.Name = "line23";
            this.line23.Top = 1.3875F;
            this.line23.Width = 0F;
            this.line23.X1 = 4.094001F;
            this.line23.X2 = 4.094001F;
            this.line23.Y1 = 1.5875F;
            this.line23.Y2 = 1.3875F;
            // 
            // label11
            // 
            this.label11.Height = 0.2F;
            this.label11.HyperLink = null;
            this.label11.Left = 4.094001F;
            this.label11.Name = "label11";
            this.label11.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-f" +
    "ont-vertical: none";
            this.label11.Text = "Athletic Leave";
            this.label11.Top = 1.4375F;
            this.label11.Width = 0.46875F;
            // 
            // label12
            // 
            this.label12.Height = 0.2F;
            this.label12.HyperLink = null;
            this.label12.Left = 4.594001F;
            this.label12.Name = "label12";
            this.label12.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.label12.Text = "Bereavement";
            this.label12.Top = 1.4375F;
            this.label12.Width = 0.46875F;
            // 
            // line24
            // 
            this.line24.Height = 0.2F;
            this.line24.Left = 6.532001F;
            this.line24.LineWeight = 1F;
            this.line24.Name = "line24";
            this.line24.Top = 1.3875F;
            this.line24.Width = 0F;
            this.line24.X1 = 6.532001F;
            this.line24.X2 = 6.532001F;
            this.line24.Y1 = 1.5875F;
            this.line24.Y2 = 1.3875F;
            // 
            // label9
            // 
            this.label9.Height = 0.2F;
            this.label9.HyperLink = null;
            this.label9.Left = 6.063001F;
            this.label9.Name = "label9";
            this.label9.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.label9.Text = "Hajj";
            this.label9.Top = 1.4375F;
            this.label9.Width = 0.46875F;
            // 
            // label13
            // 
            this.label13.Height = 0.2F;
            this.label13.HyperLink = null;
            this.label13.Left = 7.532001F;
            this.label13.Name = "label13";
            this.label13.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-f" +
    "ont-vertical: none";
            this.label13.Text = "Paternity Leave";
            this.label13.Top = 1.4375F;
            this.label13.Width = 0.46875F;
            // 
            // line26
            // 
            this.line26.Height = 0.2F;
            this.line26.Left = 8.000999F;
            this.line26.LineWeight = 1F;
            this.line26.Name = "line26";
            this.line26.Top = 1.3875F;
            this.line26.Width = 0F;
            this.line26.X1 = 8.000999F;
            this.line26.X2 = 8.000999F;
            this.line26.Y1 = 1.5875F;
            this.line26.Y2 = 1.3875F;
            // 
            // line27
            // 
            this.line27.Height = 0.2F;
            this.line27.Left = 7.532001F;
            this.line27.LineWeight = 1F;
            this.line27.Name = "line27";
            this.line27.Top = 1.3875F;
            this.line27.Width = 0F;
            this.line27.X1 = 7.532001F;
            this.line27.X2 = 7.532001F;
            this.line27.Y1 = 1.5875F;
            this.line27.Y2 = 1.3875F;
            // 
            // line28
            // 
            this.line28.Height = 0.2F;
            this.line28.Left = 7.501F;
            this.line28.LineWeight = 1F;
            this.line28.Name = "line28";
            this.line28.Top = 1.3875F;
            this.line28.Width = 0F;
            this.line28.X1 = 7.501F;
            this.line28.X2 = 7.501F;
            this.line28.Y1 = 1.5875F;
            this.line28.Y2 = 1.3875F;
            // 
            // line29
            // 
            this.line29.Height = 0.2F;
            this.line29.Left = 7.001F;
            this.line29.LineWeight = 1F;
            this.line29.Name = "line29";
            this.line29.Top = 1.3875F;
            this.line29.Width = 0F;
            this.line29.X1 = 7.001F;
            this.line29.X2 = 7.001F;
            this.line29.Y1 = 1.5875F;
            this.line29.Y2 = 1.3875F;
            // 
            // line30
            // 
            this.line30.Height = 0.2F;
            this.line30.Left = 6.532001F;
            this.line30.LineWeight = 1F;
            this.line30.Name = "line30";
            this.line30.Top = 1.3875F;
            this.line30.Width = 0F;
            this.line30.X1 = 6.532001F;
            this.line30.X2 = 6.532001F;
            this.line30.Y1 = 1.5875F;
            this.line30.Y2 = 1.3875F;
            // 
            // label15
            // 
            this.label15.Height = 0.2F;
            this.label15.HyperLink = null;
            this.label15.Left = 6.532001F;
            this.label15.Name = "label15";
            this.label15.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-f" +
    "ont-vertical: none";
            this.label15.Text = "Marriage";
            this.label15.Top = 1.4375F;
            this.label15.Width = 0.46875F;
            // 
            // label16
            // 
            this.label16.Height = 0.2F;
            this.label16.HyperLink = null;
            this.label16.Left = 7.032001F;
            this.label16.Name = "label16";
            this.label16.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.label16.Text = "Maternity Leave";
            this.label16.Top = 1.4375F;
            this.label16.Width = 0.46875F;
            // 
            // label17
            // 
            this.label17.Height = 0.2F;
            this.label17.HyperLink = null;
            this.label17.Left = 8.033001F;
            this.label17.Name = "label17";
            this.label17.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-f" +
    "ont-vertical: none";
            this.label17.Text = "Umrah Leave";
            this.label17.Top = 1.4375F;
            this.label17.Width = 0.46875F;
            // 
            // line13
            // 
            this.line13.Height = 0.2F;
            this.line13.Left = 9.002001F;
            this.line13.LineWeight = 1F;
            this.line13.Name = "line13";
            this.line13.Top = 1.3875F;
            this.line13.Width = 0F;
            this.line13.X1 = 9.002001F;
            this.line13.X2 = 9.002001F;
            this.line13.Y1 = 1.5875F;
            this.line13.Y2 = 1.3875F;
            // 
            // line38
            // 
            this.line38.Height = 0.2F;
            this.line38.Left = 8.502001F;
            this.line38.LineWeight = 1F;
            this.line38.Name = "line38";
            this.line38.Top = 1.3875F;
            this.line38.Width = 0F;
            this.line38.X1 = 8.502001F;
            this.line38.X2 = 8.502001F;
            this.line38.Y1 = 1.5875F;
            this.line38.Y2 = 1.3875F;
            // 
            // line39
            // 
            this.line39.Height = 0.2F;
            this.line39.Left = 8.033001F;
            this.line39.LineWeight = 1F;
            this.line39.Name = "line39";
            this.line39.Top = 1.3875F;
            this.line39.Width = 0F;
            this.line39.X1 = 8.033001F;
            this.line39.X2 = 8.033001F;
            this.line39.Y1 = 1.5875F;
            this.line39.Y2 = 1.3875F;
            // 
            // label18
            // 
            this.label18.Height = 0.2F;
            this.label18.HyperLink = null;
            this.label18.Left = 8.533001F;
            this.label18.Name = "label18";
            this.label18.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: bold; ddo-c" +
    "har-set: 1";
            this.label18.Text = "Unpaid Leave";
            this.label18.Top = 1.4375F;
            this.label18.Width = 0.46875F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // lblSr
            // 
            this.lblSr.DataField = "EmployeeID";
            this.lblSr.Height = 0.1875F;
            this.lblSr.Left = 0.03125F;
            this.lblSr.Name = "lblSr";
            this.lblSr.Style = "color: Black; text-align: left";
            this.lblSr.Tag = "";
            this.lblSr.Text = "0";
            this.lblSr.Top = 0F;
            this.lblSr.Width = 0.375F;
            // 
            // rpEmployeeAttendenceSummary
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 9.05308F;
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
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    private GrapeCity.ActiveReports.SectionReportModel.Detail Detail;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox2;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line2;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line9;
    private GrapeCity.ActiveReports.SectionReportModel.PageHeader PageHeader;
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
    private GrapeCity.ActiveReports.SectionReportModel.PageFooter PageFooter;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox1;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line8;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line12;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line18;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox3;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox4;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line16;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line17;
    private GrapeCity.ActiveReports.SectionReportModel.Line Line1;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label2;
    private GrapeCity.ActiveReports.SectionReportModel.Shape Shape1;
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
    private GrapeCity.ActiveReports.SectionReportModel.Line line37;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox13;
    private GrapeCity.ActiveReports.SectionReportModel.Line line46;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox14;
    private GrapeCity.ActiveReports.SectionReportModel.Line line47;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox15;
    private GrapeCity.ActiveReports.SectionReportModel.Line line3;
    private GrapeCity.ActiveReports.SectionReportModel.Line line4;
    private GrapeCity.ActiveReports.SectionReportModel.Line line5;
    private GrapeCity.ActiveReports.SectionReportModel.Label label6;
    private GrapeCity.ActiveReports.SectionReportModel.Label label7;
    private GrapeCity.ActiveReports.SectionReportModel.Label label8;
    private GrapeCity.ActiveReports.SectionReportModel.Line line6;
    private GrapeCity.ActiveReports.SectionReportModel.Line line15;
    private GrapeCity.ActiveReports.SectionReportModel.Line line20;
    private GrapeCity.ActiveReports.SectionReportModel.Label label10;
    private GrapeCity.ActiveReports.SectionReportModel.Line line21;
    private GrapeCity.ActiveReports.SectionReportModel.Line line22;
    private GrapeCity.ActiveReports.SectionReportModel.Line line23;
    private GrapeCity.ActiveReports.SectionReportModel.Label label11;
    private GrapeCity.ActiveReports.SectionReportModel.Label label12;
    private GrapeCity.ActiveReports.SectionReportModel.Line line24;
    private GrapeCity.ActiveReports.SectionReportModel.Label label9;
    private GrapeCity.ActiveReports.SectionReportModel.Label label13;
    private GrapeCity.ActiveReports.SectionReportModel.Line line26;
    private GrapeCity.ActiveReports.SectionReportModel.Line line27;
    private GrapeCity.ActiveReports.SectionReportModel.Line line28;
    private GrapeCity.ActiveReports.SectionReportModel.Line line29;
    private GrapeCity.ActiveReports.SectionReportModel.Line line30;
    private GrapeCity.ActiveReports.SectionReportModel.Label label15;
    private GrapeCity.ActiveReports.SectionReportModel.Label label16;
    private GrapeCity.ActiveReports.SectionReportModel.Label label17;
    private GrapeCity.ActiveReports.SectionReportModel.Line line13;
    private GrapeCity.ActiveReports.SectionReportModel.Line line38;
    private GrapeCity.ActiveReports.SectionReportModel.Line line39;
    private GrapeCity.ActiveReports.SectionReportModel.Label label18;
    private GrapeCity.ActiveReports.SectionReportModel.TextBox lblSr;
    private GrapeCity.ActiveReports.SectionReportModel.Label Label4;


    
}