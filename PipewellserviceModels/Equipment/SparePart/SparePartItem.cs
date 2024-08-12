using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Equipment.SparePart
{
    public class SparePartItem
    {
        
        public int ID { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public string Application { get; set; }
        public string Alternatives { get; set; }
        public float PurchasePrice { get; set; }
        public float SalesPrice { get; set; }
        public int ReOrderLimit { get; set; }
        public string Notes { get; set; }
        public bool InventoryPart { get; set; }
        public string PartGroup { get; set; }
        public string Location { get; set; }
        public DateTime RecordDateCreated { get; set; }

        public int RecordCreatdBy { get; set; }

    }
    public class SparePartItemParam
    {
        public string PartNumber { get; set; }
        public string Application { get; set; }
        public string PartName { get; set; }
    }
}
