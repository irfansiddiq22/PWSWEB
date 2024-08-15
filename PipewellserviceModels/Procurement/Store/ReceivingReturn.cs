using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Procurement.Store
{


    public class StoreReceivingReturnView
    {
        public List<StoreReceivingReturn> Receivings { get; set; }
        public int ID { get; set; }
        public int TotalRecords { get; set; }
    }
    

    public class StoreReceivingReturn: StoreReceiving
    {
        public DateTime ReceivingDate { get; set; }
        public string RecordCreatedByName { get; set; }
        public int ReceivingID { get; set; }
        public int ReturnedBy { get; set; }
        public DateTime ReturnDate { get; set; }
    }
    public class ReceivingReturnItem: ReceivingItem {
        public int ReturnQuantity { get; set; }
        public int ReceivingReturnID { get; set; }
    }
    public class StoreReceivingReturnParam : StoreReceivingParam
    {

    }
}
