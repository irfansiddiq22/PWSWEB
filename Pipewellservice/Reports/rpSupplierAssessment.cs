using System;

using GrapeCity.ActiveReports.SectionReportModel;
using PipewellserviceModels.Supplier;

namespace Pipewellservice.Reports
{
    /// <summary>
    /// Summary description for rpSupplierAssessment.
    /// </summary>
    public partial class rpSupplierAssessment : GrapeCity.ActiveReports.SectionReport
    {

        public rpSupplierAssessment()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void detail_Format(object sender, EventArgs e)
        {

        }

        private void rpSupplierAssessment_ReportStart(object sender, EventArgs e)
        {

            SupplierAssementDTO data = (SupplierAssementDTO)this.UserData;

            SubReport Items = this.SupplierItems;
            Items.Report = new rptSupplierItems { DataSource = data.supplierItems, Document = { }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };
            SubReport Customers = this.SupplierCustomers;
            Customers.Report = new rptSupplierCustomers { DataSource = data.supplierCustomers, Document = { }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };

            SubReport Production = this.SupplierProductions;
            Production.Report = new rptSupplierProduction { DataSource = data.supplierProductions, Document = { }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };


            SubReport QualityControl = this.SupplierQualiityControl;
            QualityControl.Report = new rptSupplierQualityControl { DataSource = data.supplierQualityControls, Document = { }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };


            SubReport PWS = this.rpPWSSupplierAssessmentInternal;
            PWS.Report = new rpPWSSupplierAssessmentInternal { DataSource = null, Document = { }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };
        }
    }
}
