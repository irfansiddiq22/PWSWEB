using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Equipment
{
    public class EquipmentQuoteCollection
    {
        public int ID { get; set; }
        public int QuoteID { get; set; }
        public string DocumentCode { get; set; }
        public DateTime RecordDate { get; set; }
        public int ReceivedBy { get; set; }
        public float Freight { get; set; }
        public float VAT { get; set; }
        public float Discount { get; set; }
        public float Total { get; set; }
        public string Remarks { get; set; }
        public int RecordCreatedBy { get; set; }
        public DateTime RecordDateCreated { get; set; }

        public List<EquipQuoteCollectionItems> Items { get; set; }
    }
    public class EquipQuoteCollectionItems
    {

        public int ID { get; set; }
        public int QuoteOrderID { get; set; }
        public int SparePartItemID { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public string Notes { get; set; }

        public string PartNumber { get; set;}
        public string PartName { get; set; }
    }

    public class EquipmentQuoteCollectionList : EquipmentQuoteCollection
    {
        public string SupplierName { get; set; }
        public string RecordCreatedByName { get; set; }
        public string RFQNumber { get; set; }
        public string PaymentTerm { get; set; }
        public string CustomerNotes { get; set; }
        public int TotalRecord { get; set; }
    }
}
