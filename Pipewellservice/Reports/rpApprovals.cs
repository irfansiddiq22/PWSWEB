using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Pipewellservice.Reports
{
    /// <summary>
    /// Summary description for rpApprovals.
    /// </summary>
    public partial class rpApprovals : GrapeCity.ActiveReports.SectionReport
    {

        public rpApprovals()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void rpApprovals_ReportStart(object sender, EventArgs e)
        {
            /*DataTable data = (DataTable) this.DataSource;
            this.Picture1.Image = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(new MemoryStream(data[0].ApprovalSign1)));*/
            
        }

        private void detail_Format(object sender, EventArgs e)
        {
            //this.Signature
            
        }
    }
}
