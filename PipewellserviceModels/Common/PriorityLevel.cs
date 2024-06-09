using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Common
{
    public class PriorityLevel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TimeLimit { get; set; }
        public PriorityTimeUnit TimeUnit { get; set; }
        public string ColorCode { get; set; }

    }
}
