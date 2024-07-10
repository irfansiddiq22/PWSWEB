using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Procurement
{
    public class MaterialRequestDB
    {
        public DataTable MaterialRequest { get; set; }
        public DataTable MaterialRequestItem { get; set; }
        public MaterialRequestDB()
        {
            MaterialRequestItem = new DataTable();
            MaterialRequest = new DataTable();
        }
    }
    public class MaterialRequestDetail
    {
        public MaterialRequest Request { get; set; }
        public List< MaterialRequestItem> Items { get; set; }

    }
    public class MaterialRequest
    {
        public int ID { get; set; }
        public int RequestedBy { get; set; }
        public string RequestedByName { get; set; }
        public DateTime RequestDate { get; set; }
        public string Remarks { get; set; }
        public int ApprovalStatus { get; set; }
        public string FileName { get; set; }
        public int RequestType { get; set; }
        public int RecordCreatedBy { get; set; }
        public string RecordCreatedByName { get; set; }
        public int ApprovedBy { get; set; }
        public string ApprovedByName { get; set; }
        public string ApprovalRemarks { get; set; }
        public string ApprovalDate { get; set; }
        public ApprovalStatus ApprovalStatus1 { get; set; }
        public string ApprovalStatusName
        {
            get
            {
                string Status = "";
                switch (ApprovalStatus1)
                {
                    case Common.ApprovalStatus.Approved:
                        Status= "Approved";
                        break;
                    case Common.ApprovalStatus.NotApproved:
                        Status= "Not Approved";
                        break;
                    default:
                        Status = "Pending";
                        break;
                }
                return Status;
            }
        }


        public int Total { get; set; }
        public int RowNumber { get; set; }
        

    }
    public class MaterialRequestItem
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public float? UnitCost { get; set; }
        public float? Amount { get {
                if (UnitCost == null) return 0;
                return Quantity * UnitCost;
            } }

    }
    public class MaterialRequestResult
    {
        public int ID { get; set; }
        public int ApprovalID { get; set; }
    }
    public class MaterialRequestMailDetail
    {
        public DateTime RequestDate { get; set; }
        public string Remarks { get; set; }
        public string RequestType { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public int ID { get; set; }
        public string Notes { get; set; }
    }
}
