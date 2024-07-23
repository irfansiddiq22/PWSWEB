namespace Pipewellservice.Reports
{
    /// <summary>
    /// Summary description for rptSupplierProduction.
    /// </summary>
    partial class rptSupplierProduction
    {
        private GrapeCity.ActiveReports.SectionReportModel.PageHeader pageHeader;
        private GrapeCity.ActiveReports.SectionReportModel.Detail detail;
        private GrapeCity.ActiveReports.SectionReportModel.PageFooter pageFooter;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader groupHeader;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter groupFooter;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rptSupplierProduction));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.groupHeader = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.textBox79 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.crossSectionLine1 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.crossSectionLine3 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            this.groupFooter = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.textBox94 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.crossSectionLine2 = new GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine();
            ((System.ComponentModel.ISupportInitialize)(this.textBox79)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox94)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            // 
            // groupHeader
            // 
            this.groupHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.textBox79,
            this.line2,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.crossSectionLine1,
            this.crossSectionLine3,
            this.crossSectionLine2});
            this.groupHeader.Height = 0.2569444F;
            this.groupHeader.Name = "groupHeader";
            // 
            // textBox79
            // 
            this.textBox79.Height = 0.23F;
            this.textBox79.Left = 0.1F;
            this.textBox79.Name = "textBox79";
            this.textBox79.Style = "color: Black; font-family: Book Antiqua; font-size: 8.75pt; font-weight: bold; te" +
    "xt-align: left; ddo-char-set: 1";
            this.textBox79.Text = "SN";
            this.textBox79.Top = 0F;
            this.textBox79.Width = 0.88F;
            // 
            // line2
            // 
            this.line2.Height = 0F;
            this.line2.Left = 0F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0.25F;
            this.line2.Width = 8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 8F;
            this.line2.Y1 = 0.25F;
            this.line2.Y2 = 0.25F;
            // 
            // textBox1
            // 
            this.textBox1.Height = 0.23F;
            this.textBox1.Left = 1.03F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "color: Black; font-family: Book Antiqua; font-size: 8.75pt; font-weight: bold; te" +
    "xt-align: left; ddo-char-set: 1";
            this.textBox1.Text = "Machine/Facility Name & Specification";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 2.8F;
            // 
            // textBox2
            // 
            this.textBox2.Height = 0.23F;
            this.textBox2.Left = 4.4F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "color: Black; font-family: Book Antiqua; font-size: 8.75pt; font-weight: bold; te" +
    "xt-align: left; ddo-char-set: 1";
            this.textBox2.Text = "Make & Model";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.9F;
            // 
            // textBox3
            // 
            this.textBox3.Height = 0.23F;
            this.textBox3.Left = 6.5F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "color: Black; font-family: Book Antiqua; font-size: 8.75pt; font-weight: bold; te" +
    "xt-align: left; ddo-char-set: 1";
            this.textBox3.Text = "No. of machine";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 1.1F;
            // 
            // crossSectionLine1
            // 
            this.crossSectionLine1.Bottom = 0F;
            this.crossSectionLine1.Left = 6F;
            this.crossSectionLine1.LineWeight = 1F;
            this.crossSectionLine1.Name = "crossSectionLine1";
            this.crossSectionLine1.Top = 0F;
            // 
            // crossSectionLine3
            // 
            this.crossSectionLine3.Bottom = 0.0008333341F;
            this.crossSectionLine3.Left = 1F;
            this.crossSectionLine3.LineWeight = 1F;
            this.crossSectionLine3.Name = "crossSectionLine3";
            this.crossSectionLine3.Top = 0F;
            // 
            // groupFooter
            // 
            this.groupFooter.Height = 0F;
            this.groupFooter.Name = "groupFooter";
            // 
            // detail
            // 
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.textBox94,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.line1});
            this.detail.Height = 0.2916666F;
            this.detail.Name = "detail";
            // 
            // textBox94
            // 
            this.textBox94.DataField = "RowNumber";
            this.textBox94.Height = 0.24F;
            this.textBox94.Left = 0.1F;
            this.textBox94.Name = "textBox94";
            this.textBox94.Text = null;
            this.textBox94.Top = 0.01041664F;
            this.textBox94.Width = 0.9F;
            // 
            // textBox4
            // 
            this.textBox4.DataField = "MachineName";
            this.textBox4.Height = 0.24F;
            this.textBox4.Left = 1.03F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Text = "MachineName";
            this.textBox4.Top = 0.01041664F;
            this.textBox4.Width = 2.8F;
            // 
            // textBox5
            // 
            this.textBox5.DataField = "Model";
            this.textBox5.Height = 0.24F;
            this.textBox5.Left = 4.1F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Text = "Model";
            this.textBox5.Top = 0.01F;
            this.textBox5.Width = 1.772999F;
            // 
            // textBox6
            // 
            this.textBox6.DataField = "NoOfMachines";
            this.textBox6.Height = 0.24F;
            this.textBox6.Left = 6.100001F;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "text-align: center";
            this.textBox6.Text = "NoOfMachines";
            this.textBox6.Top = 0.01041664F;
            this.textBox6.Width = 1.772999F;
            // 
            // line1
            // 
            this.line1.Height = 0F;
            this.line1.Left = 0F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.28125F;
            this.line1.Width = 8F;
            this.line1.X1 = 0F;
            this.line1.X2 = 8F;
            this.line1.Y1 = 0.28125F;
            this.line1.Y2 = 0.28125F;
            // 
            // pageFooter
            // 
            this.pageFooter.Name = "pageFooter";
            // 
            // crossSectionLine2
            // 
            this.crossSectionLine2.Bottom = 0.0008333341F;
            this.crossSectionLine2.Left = 4F;
            this.crossSectionLine2.LineWeight = 1F;
            this.crossSectionLine2.Name = "crossSectionLine2";
            this.crossSectionLine2.Top = 0F;
            // 
            // rptSupplierProduction
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0.25F;
            this.PageSettings.Margins.Right = 0.25F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.textBox79)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox94)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox79;
        private GrapeCity.ActiveReports.SectionReportModel.Line line2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox2;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox3;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine1;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine3;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox94;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox4;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox5;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox6;
        private GrapeCity.ActiveReports.SectionReportModel.Line line1;
        private GrapeCity.ActiveReports.SectionReportModel.CrossSectionLine crossSectionLine2;
    }
}
