using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Procurement.Store
{
    public class ItemUnit
    {
        public string Unit { get; set; }
    }
    public class Item
    {
        public int ID { get; set; }
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Unit { get; set; }
        public int OpeningStock { get; set; }
        public int ReOrderLimit { get; set; }
        public string Packing { get; set; }

        public string Location { get; set; }
        public string PartNumber { get; set; }
        public string Image { get; set; }
        public bool StockItem { get; set; }
        public bool CreticalItem { get; set; }
        public bool Active { get; set; }
        public bool Tengible { get; set; }

        public int Total { get; set; }
        public int NextCode { get; set; }
    }

}
