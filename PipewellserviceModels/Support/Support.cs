using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Support
{
    public class SupportTicket
    {
        public string Name { get; set; }
        public string Problem { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
    }
}
