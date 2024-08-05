using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Pipewellservice.App_Start;
using Pipewellservice.Helper;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using PipewellserviceModels.Procurement.Purchase;
using System.IO;

namespace Pipewellservice.Reports
{
    /// <summary>
    /// Summary description for rpInternalPurchase.
    /// </summary>
    public partial class rpInternalPurchase : GrapeCity.ActiveReports.SectionReport
    {

        public rpInternalPurchase()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void rpInternalPurchase_ReportStart(object sender, System.EventArgs e)
        {
            List<Constant> cont = AppData.Constants.FindAll(x => x.ParentID == (int)ParentEnums.REPORTHEADER);
            txtHeaderArabic.Text = cont.Find(x => x.Value == 5).Name;
            txtHeaderCompany.Text = cont.Find(x => x.Value == 4).Name;
            txtFooter1.Text= cont.Find(x => x.Value == 1).Name;
            txtFooter3.Text = cont.Find(x => x.Value == 3).Name;
            TextBox1.Text = System.DateTime.Now.ToString();
            
            InternalPurchaseRequest request = (InternalPurchaseRequest)this.UserData;
            ID.Text = request.ID.ToString();
            QuotationNumber.Text = request.QuotationNumber;
            SupplierName.Text = request.SupplierName;
            SupplierAddress.Text = request.SupplierAddress;
            chkService.Checked = (request.RequestType == 1);
            chkMaintenanceRoom.Checked = (request.RequestType == 2);
            chkMaintenanceOffice.Checked = (request.RequestType == 3);
            chkMaintenanceOperation.Checked = (request.RequestType == 4);
            chkConsumables.Checked = (request.RequestType == 5);
            chkPermanent.Checked = (request.RequestType == 6);

            chkCash.Checked = (request.PaymentType == 1);
            chkCredit.Checked = (request.PaymentType == 2);
            chkCheck.Checked = (request.PaymentType == 3);
            chkAFT.Checked = (request.PaymentType == 4);

            chkEmergency.Checked = (request.DeliveryType == 1);
            chkUrgent.Checked = (request.DeliveryType == 2);
            chkNormal.Checked = (request.DeliveryType == 3);
            Remarks.Text = request.Remarks;
            Approval1.Text = request.ApprovedByName;

            MaintRequestNumber.Text = request.MaintRequestNumber;
            RequestedByName.Text = request.RequestedByName;
            RequestedDate.Text = request.RequestSignDate.ToString("MM/dd/yyyy");
            //this.Document.CacheToDisk = true;
            /*
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
                    
                }
                catch (Exception ex) { }
            }*/
        }

        private void Detail_Format(object sender, EventArgs e)
        {

        }
    }
}
