using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Account
{
    public class Supplier
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }
    public class SuplierContact
    {
        public string ContactPerson { get; set; }
        public string ContactEmailAddress { get; set; }
        public string RequestID { get; set; }
    }
}
