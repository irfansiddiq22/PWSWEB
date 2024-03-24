using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
    public class EmployeeFamily
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Relation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PassportNumber { get; set; }
        public DateTime PassportIssueDate { get; set; }
        public DateTime PassportExpiryDate { get; set; }
        public string IqamaNumber { get; set; }
        public string LocalPhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string FileID { get; set; }
        public string FileName { get; set; }

    }
    public class EmployeeRelation
    {
        public string Name { get; set; }
    }
}
