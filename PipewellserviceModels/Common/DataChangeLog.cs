using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Common
{
    public class DataChangeLog
    {
        public Pages Form { get; set; }
        public string UserName { get; set; }
        public int RecordID { get; set; }
        public List<DataField> DataUpdated { get; set; }
        public string Data
        {
            get
            {
                return JsonConvert.SerializeObject(DataUpdated);
            }
        }
    }
    public class DataField
    {
        public string Field { get; set; }
        public FieldData Data
        {
            get; set;

        }
        public class FieldData
        {
            public string Old { get; set; }
            public string New { get; set; }
        }
    }
}
