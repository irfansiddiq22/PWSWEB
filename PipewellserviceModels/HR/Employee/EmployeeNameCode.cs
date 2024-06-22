using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
    public class EmployeeNameCode
    {
        public int ID { get; set; }
        [JsonProperty("LabourCode")]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public int DivisionID { get; set; }
    }
}
