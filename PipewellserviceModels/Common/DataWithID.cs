using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Common
{
    public class DataListWithID
    {
        public DataTable List { get; set; }
        public int ID { get; set; }
        public DataListWithID()
        {
            List = new DataTable();
            ID = 0;
        }
    }
}
