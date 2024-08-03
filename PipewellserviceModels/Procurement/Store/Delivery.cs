using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Procurement.Store
{

    public class StoreDeliveryView
    {
        public List<StoreDelivery> Delivery { get; set; }
        public int ID { get; set; }
        public int TotalRecords { get; set; }
    }
    public class StoreDeliveryViewSQL
    {
        public DataTable Delivery { get; set; }
        public int ID { get; set; }
        public StoreDeliveryViewSQL()
        {
            Delivery = new DataTable();

        }
    }
    public class StoreDelivery
    {
        public int ID { get; set; }
        public int DeliveryNumber { get; set; }
        public int MRID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string WorkOrderID { get; set; }
        public string Customer { get; set; }
        public int ReceivedBy { get; set; }
        public string Remarks { get; set; }
        public int RecordCreatedBy { get; set; }
        public DateTime RecordDateCreated { get; set; }
        public int TotalRecords { get; set; }
        public string ReceivedByName { get; set; }
    }
    public class DeliveryItem : Purchase.PurchaseOrderManagementItem
    {

    }


    public class StoreDeliveryParam : PagingDTO
    {
        public int ReceivedBy { get; set; }
        public int DeliveryNumber { get; set; }
        public int MaterialRequestNumber { get; set; }
        public string WorkOrderNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

