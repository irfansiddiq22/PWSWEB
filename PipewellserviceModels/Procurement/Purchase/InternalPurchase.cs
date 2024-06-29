using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Procurement.Purchase
{
    public class InternalPurchaseRequestDB
    {
        public DataTable InternalPurchase { get; set; }
        public DataTable InternalPurchaseRequestItem { get; set; }
        public InternalPurchaseRequestDB()
        {
            InternalPurchaseRequestItem = new DataTable();
            InternalPurchase = new DataTable();
        }
    }
    public class InternalPurchaseRequestDetail
    {
        public InternalPurchaseRequest Request { get; set; }
        public List<InternalPurchaseRequestItem> Items { get; set; }

    }
    public class InternalPurchaseRequest
    {
        public int ID { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Remarks { get; set; }
        public int RequestType { get; set; }
        public string QuotationNumber { get; set; }
        public int DeliveryType { get; set; }
        public int PaymentType { get; set; }
        public int RequestedBy { get; set; }
        public string RequestedByName { get; set; }

        public DateTime RequestDate { get; set; }
        public DateTime RequestSignDate { get; set; }
        public string FileName { get; set; }
        public string FileID { get; set; }
        public string MaintRequestNumber { get; set; }
        public DateTime RecordDate { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }
        public int RecordCreatedBy { get; set; }
        public int Total { get; set; }
    }

    public class InternalPurchaseRequestItem : MaterialRequestItem
    {
        public int RequestID { get; set; }
        public string PartNumber { get; set; }
        public bool MSDS { get; set; }

    }
    public class InternalPurchaseRequestResult
    {
        public int ID { get; set; }
        public int ApprovalID { get; set; }
    }
    public class InternalPurchaseMailDetail : MaterialRequestMailDetail
    {
        public int RequestID { get; set; }
        public string PartNumber { get; set; }
        public bool MSDS { get; set; }
        public string SupplierName { get; set; }
        public string QuotationNumber { get; set; }
        public string MaintRequestNumber { get; set; }
        public int DeliveryType { get; set; }
        public string DeliveryTypeName
        {
            get
            {
                switch (DeliveryType)
                {
                    case 1:
                        return "Emergency";
                    case 2:
                        return "Urgent";
                    case 3:
                        return "Normal";
                    default:
                        return "";

                }
            }
        }
        public int PaymentType { get; set; }
        public string PaymentTypeName
        {
            get
            {
                switch (PaymentType )
                {
                    case 1:
                        return "Cash";
                    case 2:
                        return "Credit";
                    case 3:
                        return "Check";
                    case 4:
                        return "AFT";
                    default:
                        return "";

                }
            }
        }
    }
}


