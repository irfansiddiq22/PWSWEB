using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Procurement.Store
{
    public class StoreReceivingView
    {
        public List<StoreReceiving> Receivings { get; set; }
        public int ID { get; set; }
        public int TotalRecords { get; set; }
    }
    public class StoreReceivingViewSQL
    {
        public DataTable Receivings { get; set; }
        public int ID { get; set; }
        public StoreReceivingViewSQL()
        {
            Receivings = new DataTable();

        }
    }
    public class StoreReceiving
    {

        public int ID { get; set; }
        public int PurchaseOrderID { get; set; }
        public int ReceivingNumber { get; set; }
        public int IPRID { get; set; }
        public DateTime RecordDate { get; set; }
        public string Remarks { get; set; }
        public string VendorInvoice { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Notes { get; set; }
        public DateTime NoteDate { get; set; }
        public string InvoiceFileName { get; set; }
        public string InvoiceFileID { get; set; }
        public bool NonC { get; set; }
        public string FileName { get; set; }
        public string FileID { get; set; }
        private  bool InvPaid { get; set; }
        public DateTime ReceiveDate { get; set; }
        public int RecordCreatedBy { get; set; }
        public DateTime RecordDateCreated { get; set; }
        public int TotalRecords { get; set; }
    }
    public class ReceivingItem : Purchase.PurchaseOrderManagementItem
    {
        public int ReceivingQuantity { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

    public class StoreReceivingParam: PagingDTO
    {
        public int SupplierID { get; set; }
        public int ReceivingNumber { get; set; }
        public int PurchaseOrderNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
