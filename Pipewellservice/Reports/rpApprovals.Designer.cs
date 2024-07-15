namespace Pipewellservice.Reports
{
    /// <summary>
    /// Summary description for rpApprovals.
    /// </summary>
    partial class rpApprovals
    {
        private GrapeCity.ActiveReports.SectionReportModel.PageHeader pageHeader;
        private GrapeCity.ActiveReports.SectionReportModel.Detail detail;
        private GrapeCity.ActiveReports.SectionReportModel.PageFooter pageFooter;

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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rpApprovals));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.TextBox15 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox9 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label25 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox17 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0.01041667F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Visible = false;
            // 
            // detail
            // 
            this.detail.ColumnCount = 4;
            this.detail.ColumnDirection = GrapeCity.ActiveReports.SectionReportModel.ColumnDirection.AcrossDown;
            this.detail.ColumnSpacing = 0.2F;
            this.detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.TextBox15,
            this.TextBox9,
            this.Label25,
            this.TextBox17});
            this.detail.Height = 1.128417F;
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            // 
            // TextBox15
            // 
            this.TextBox15.DataField = "ApprovalDate";
            this.TextBox15.Height = 0.1875F;
            this.TextBox15.Left = 0.03999996F;
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.OutputFormat = resources.GetString("TextBox15.OutputFormat");
            this.TextBox15.ShrinkToFit = true;
            this.TextBox15.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: normal; tex" +
    "t-align: center; ddo-shrink-to-fit: true";
            this.TextBox15.Text = null;
            this.TextBox15.Top = 0.85F;
            this.TextBox15.Width = 1.564F;
            // 
            // TextBox9
            // 
            this.TextBox9.DataField = "Remarks";
            this.TextBox9.Height = 0.297F;
            this.TextBox9.Left = 0.03999996F;
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.Style = "color: Black; font-family: Book Antiqua; font-size: 9pt; font-weight: normal; tex" +
    "t-align: center";
            this.TextBox9.Text = null;
            this.TextBox9.Top = 0.522F;
            this.TextBox9.Width = 1.721F;
            // 
            // Label25
            // 
            this.Label25.DataField = "ApprovalPosition";
            this.Label25.Height = 0.2F;
            this.Label25.HyperLink = null;
            this.Label25.Left = 0.03999996F;
            this.Label25.Name = "Label25";
            this.Label25.Style = "color: Black; font-family: Book Antiqua; font-size: 9.75pt; font-weight: bold; te" +
    "xt-align: center; ddo-char-set: 0";
            this.Label25.Text = "";
            this.Label25.Top = -8.881784E-16F;
            this.Label25.Width = 1.721F;
            // 
            // TextBox17
            // 
            this.TextBox17.DataField = "Name";
            this.TextBox17.Height = 0.2320001F;
            this.TextBox17.Left = 0.04F;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "color: Black; font-size: 9.75pt; font-weight: normal; text-align: center";
            this.TextBox17.Text = null;
            this.TextBox17.Top = 0.221F;
            this.TextBox17.Width = 1.721F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.1875F;
            this.pageFooter.Name = "pageFooter";
            this.pageFooter.Visible = false;
            // 
            // rpApprovals
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.729167F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rpApprovals_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox15;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox9;
        private GrapeCity.ActiveReports.SectionReportModel.Label Label25;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox TextBox17;
    }
}
