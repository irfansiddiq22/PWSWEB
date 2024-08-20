using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Equipment
{
    public class EquipmentQuote
    {
        
        
            public int ID { get; set; }
            public int SupplierID { get; set; }
            public int PaymentTerm { get; set; }
            public float Discount { get; set; }
            public DateTime QuoteDate { get; set; }
            public string QuoteID { get; set; }
            public string RFQNumber { get; set; }
            public bool Accepted { get; set; }
            public bool Delivered { get; set; }
            public string CustomerNotes { get; set; }
            public bool CreditAllowed { get; set; }
            public string Remarks { get; set; }
            public int RecordCreatedBy { get; set; }
            public DateTime RecordDateCreated { get; set; }
        public List<EquipmentQuoteItem> Items { get; set; }
        

    }
    public class EquipmentQuoteList: EquipmentQuote
    {
        public string SupplierName { get; set; }
        public string RecordCreatedByName { get; set; }
        public int Total { get; set; }
    }
    public class EquipmentQuoteParam :PagingDTO{
        public int SupplierID { get; set; }
        public string QuoteID { get; set; }
        public string RFQNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
    public class EquipmentQuoteItem
    {
        public int ID { get; set; }
        public int QuoteID { get; set; }
        public int SparePartItemID { get; set; }
        public string PartName { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }

        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public string Availability { get; set; }
        public string Notes { get; set; }
    }
    public class EquipmentQuoteSQL
    {
        public DataTable Detail { get; set; }
        public DataTable Items { get; set; }
        public EquipmentQuoteSQL()
        {
            Detail = new DataTable();
            Items = new DataTable();
        }
    }
}
