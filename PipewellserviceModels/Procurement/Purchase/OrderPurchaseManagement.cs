using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Procurement.Purchase
{


    public class PurchaseOrderManagementDB
    {
        public DataTable PurchaseOrder { get; set; }
        public DataTable OrderItem { get; set; }
        public DataTable Approvals { get; set; }
        public PurchaseOrderManagementDB()
        {
            OrderItem = new DataTable();
            PurchaseOrder = new DataTable();
            Approvals = new DataTable();
        }
    }
    public class PurchaseOrderManagementDetail
    {
        public PurchaseOrderManagement Order { get; set; }
        public List<PurchaseOrderManagementItem> Items { get; set; }
        public List<EmployeeApproval> Approvals { get; set; }

    }


    public class PurchaseOrderManagement
    {
        public int ID { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string QuotationNumber { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierVAT { get; set; }
        public string Attn { get; set; }
        public DateTime RecordDate { get; set; }
        public int InternalPurchaseOrderNumber { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ContractPeriodFrom { get; set; }
        public DateTime ContractPeriodTo { get; set; }
        public int DeliveryType { get; set; }
        public int PaymentType { get; set; }
        public string WarrantyPeriod { get; set; }
        public bool LongTermContract { get; set; }
        public bool? Calibration { get; set; }
        public bool? Certification { get; set; }
        public string Remarks { get; set; }
        public string Currency { get; set; }
        public decimal Freight { get; set; }
        public decimal VAT { get; set; }
        public decimal Discount { get; set; }
        public decimal Total
        {
            get;set;
        }
        public bool ShowVatOnInvoice { get; set; }
        public int Status { get; set; }
        public int RequestedBy { get; set; }
        public string RequestedByName { get; set; }

        public DateTime RequestPerpDate { get; set; }
        public DateTime RequestDate { get; set; }
        public int DepartmentID { get; set; }
        public int RecordCreatedBy { get; set; }
        public string RecordCreatedByName { get; set; }
        public string ApprovedByName { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public bool RecordDeleted { get; set; }
        public DateTime RecordDateUpdated { get; set; }
        public int RecordUpdatedBy { get; set; }
        public ApprovalStatus ApprovalStatus1 { get; set; }
        public string ApprovalStatusName
        {
            get
            {
                string Status = "";
                switch (ApprovalStatus)
                {
                    case Common.ApprovalStatus.Approved:
                        Status = "Approved";
                        break;
                    case Common.ApprovalStatus.NotApproved:
                        Status = "Not Approved";
                        break;
                    default:
                        Status = "Pending";
                        break;
                }
                return Status;
            }
        }
        public int TotalRecord { get; set; }
    }

    public class PurchaseOrderNumber
    {
        public int ID { get; set; }
    }
public class PurchaseOrderManagementItem : InternalPurchaseRequestItem
    {
        
        public int OrderID { get; set; }
        public int SerialNumber { get; set; }
        //public float UnitCost { get; set; }
        //public float Amount { get
        //    {
        //        return UnitCost * Quantity;
        //    } }
    }
    public class PurchaseOrderParam
    {
       public string SupplierID { get; set;}
        public string ID { get; set; }
        public string RequestedBy { get; set; }
    }
    public class PurchaseOrderManagementResult : InternalPurchaseRequestResult
    {
    }
    public class PurchaseOrderManagementMailDetail : InternalPurchaseMailDetail
    {
        public int OrderID { get; set; }
        public float UnitCost { get; set; }
        
        public float Amount { get; set; }
        public int InternalPurchaseOrderNumber { get; set; }
        public string WarrantyPeriod { get; set; }
        public string Currency { get; set; }
        public float Freight { get; set; }
        public float VAT { get; set; }
        public float Discount { get; set; }
        public float Total { get; set; }
    }
    public class InterPurchaseOrderNumber
    {
        public int ID { get; set; }
    }
    public class SupplierItemRate
    {
        public string ItemName { get; set; }
        public float UnitCost { get; set; }
        public DateTime RequestDate { get; set; }
    }

}
