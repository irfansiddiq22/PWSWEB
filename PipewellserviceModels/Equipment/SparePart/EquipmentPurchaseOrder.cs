using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Equipment.SparePart
{
    public class EquipmentPurchaseOrderParam : PagingDTO
    {
        public int SupplierID { get; set; }
        public string OrderID { get; set; }
        public string PONO { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class EquipmentPurchaseOrderListSql
    {
        public DataTable List { get; set; }
        public int ID { get; set; }
        public EquipmentPurchaseOrderListSql()
        {
            List = new DataTable();
            ID = 0; 
        }
    }
    public class EquipmentPurchaseOrder
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int SupplierID { get; set; }
        
        public int Status { get; set; }
        public DateTime OrderDate { get; set; }
        public string PONO { get; set; }
        public string BackOrderTo { get; set; }
        public string PaymentTerms { get; set; }
        public string ShipmentMethod { get; set; }
        public string ShippingInstructions { get; set; }
        public int DocumentRequired { get; set; }
        public string NotifyInstructions { get; set; }
        public int RecordCreatedBy { get; set; }
        public DateTime RecordDateCreated { get; set; }

        public List<EquipmentPurchaseOrderItem> Items { get; set; }

    }
    public class EquipmentPurchaseOrderSQL
    {
        public DataTable Detail { get; set; }
        public DataTable Items { get; set; }
        public EquipmentPurchaseOrderSQL()
        {
            Detail = new DataTable();
            Items = new DataTable();
        }

    }
    public class EquipmentPurchaseOrderListView
    {
        public List<EquipmentPurchaseOrderList> List { get; set; }
        public int ID { get; set; }
    }
    public class EquipmentPurchaseOrderList : EquipmentPurchaseOrder
    {
        public string SupplierName { get; set; }
        public int Total { get; set; }
        public string RecordCreatedByName { get; set; }
    }
    public class EquipmentPurchaseOrderItem : SparePartItem
    {
        public int SparePartItemID { get; set; }
        public string Description { get; set; }
        public string ShippingMethod { get; set; }
        public string OrderID { get; set; }
        public float UnitPrice { get; set; }
        public int CurrencyID { get; set; }
        
        public string Currency { get; set; }
        public bool Received { get; set; }
        public int Quantity { get; set; }
    }

    public class EquipmentPurchaseOrderDataListSql
    {
        public DataTable ShipmentMethods { get; set; }
        public DataTable ShippingInstructions { get; set; }
        public DataTable NotifyInstructions { get; set; }
        public DataTable Currency { get; set; }
        public DataTable ItemShipmentMethods { get; set; }
       public EquipmentPurchaseOrderDataListSql()
        {
            ShipmentMethods = new DataTable();
            ShippingInstructions = new DataTable();
            NotifyInstructions = new DataTable();
            Currency = new DataTable();
            ItemShipmentMethods = new DataTable();
        }
    }
    public class EquipmentPurchaseOrderDataList
    {
        public string Value { get; set; }
    }
    public class EquipmentPurchaseOrderDataLists
    {

        public List<EquipmentPurchaseOrderDataList> ShipmentMethods { get; set; }
        public List<EquipmentPurchaseOrderDataList> ShippingInstructions { get; set; }
        public List<EquipmentPurchaseOrderDataList> NotifyInstructions { get; set; }
        public List<EquipmentPurchaseOrderDataList> Currency { get; set; }
        public List<EquipmentPurchaseOrderDataList> ItemShipmentMethods { get; set; }
    }
}
