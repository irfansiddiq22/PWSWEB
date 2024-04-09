using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Common
{
   public class MergeField
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public string culture { get; set; }
        public MergeField(string field,string value)
        {
            Field = field;
            Value = value;
        }
    }
}
