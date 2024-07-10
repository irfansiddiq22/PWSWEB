using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Pipewellservice.App_Start;
using Pipewellservice.Helper;
using PipewellserviceModels.Common;

using PipewellserviceModels.Procurement.Purchase;
namespace Pipewellservice.Reports
{
    /// <summary>
    /// Summary description for rpPurchaseOrderMgt.
    /// </summary>
    public partial class rpPurchaseOrderMgt : GrapeCity.ActiveReports.SectionReport
    {

        public rpPurchaseOrderMgt()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }
        private void rpPurchaseOrderMgt_ReportStart(object sender, System.EventArgs e)
        {
            List<Constant> cont = AppData.Constants.FindAll(x => x.ParentID == (int)ParentEnums.REPORTHEADER);
            txtHeaderArabic.Text = cont.Find(x => x.Value == 5).Name;
            txtHeaderCompany.Text = cont.Find(x => x.Value == 4).Name;
            TextBox1.Text = System.DateTime.Now.ToString();

            OrderPurchaseManagement request = (OrderPurchaseManagement)this.UserData;
            ID.Text = request.ID.ToString();
            QuotationNumber.Text = request.QuotationNumber;
            InternalPurchaseOrderNumber.Text = request.InternalPurchaseOrderNumber.ToString();
            
            SupplierName.Text = request.SupplierName;
            SupplierCode.Text = request.SupplierCode;
            Attn.Text = request.Attn;
            SupplierVAT.Text = request.SupplierVAT;

            SupplierAddress.Text = request.SupplierAddress;
            OrderDate.Text = request.RecordDate.ToString("dd-MMM-yyyy");
            RequiredDate.Text = request.RequiredDate.ToString("dd-MMM-yyyy");

             
            chkCash.Checked = (request.PaymentType == 1);
            chkCredit.Checked = (request.PaymentType == 2);
            chkCheck.Checked = (request.PaymentType == 3);
            chkAFT.Checked = (request.PaymentType == 4);

            chkEmergency.Checked = (request.DeliveryType == 1);
            chkUrgent.Checked = (request.DeliveryType == 2);
            chkNormal.Checked = (request.DeliveryType == 3);
            Remarks.Text = request.Remarks;
            Approval1.Text = request.ApprovedByName;

            chkCalYes.Checked = request.Calibration == true;
            chkCalNo.Checked = request.Calibration == false;
            WarrantyPeriod.Text = request.WarrantyPeriod;

            chkCerYes.Checked = request.Certification == true;
            chkCerNo.Checked = request.Certification == false;

            Freight.Text = $"{request.Freight.ToString("0.00")} { request.Currency }";
            Discount.Text = $"{request.Discount.ToString("0.00")} { request.Currency }";
            VAT.Text = $"{request.VAT.ToString("0.00")} { request.Currency }";
            NetTotal.Text = $"{request.Total.ToString("0.00")} { request.Currency }";
            Total.Text = $"{(request.Total-request.VAT + request.Discount- request.Freight).ToString("0.00")} { request.Currency }";
            RequestedByName.Text = request.RequestedByName;
            RequestedDate.Text = request.RequiredDate.ToString("MM/dd/yyyy");
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
    }
}
