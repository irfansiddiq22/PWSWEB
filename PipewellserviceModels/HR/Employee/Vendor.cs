using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
    
    public class Vendor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CSR { get; set; }
        public string Contact { get; set; }
        public string EmergencyContact { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string WorkScope { get; set; }
        public decimal? HourlyPrice { get; set; }
        public int WorkHours { get; set; }
        public decimal? OverTimeHourlyPrice { get; set; }
        public int MinWorkHours { get; set; }
        public int Accommodation { get; set; }
        public int Food { get; set; }
        public int Transport { get; set; }
        public int AjeerProvided { get; set; }
        public int AjeerType { get; set; }
        public int AjeerSaudization { get; set; }
        public string PWSCR { get; set; }
        public string Remarks { get; set; }
        public DateTime? RecordDateAdded { get; set; }
        public int? RecordAddedBy { get; set; }
        public DateTime? RecordDateUpdated { get; set; }
        public int? RecordUpdatedBy { get; set; }
    }

}
