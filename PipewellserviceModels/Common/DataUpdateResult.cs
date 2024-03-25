using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Common
{
    public class DataUpdateResult
    {
        public int ID { get; set; }
        public DataTable Data { get; set; }
    }
    public class UpdateResult
    {
        public int ID { get; set; }
        public void  SetData<Y>(Y input)
        {
            Data = input;
        }
        public object Data { get; private set; }
        
    }
}
