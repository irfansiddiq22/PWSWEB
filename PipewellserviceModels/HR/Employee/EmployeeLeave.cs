using PipewellserviceModels.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
    public class EmployeeLeave
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int LeaveType { get; set; }
        public string LeaveTypeName { get; set; }
        public string Remarks { get; set; }
        public string FileID { get; set; }
        public string FileName { get; set; }
        public int RecordCreatedBy { get; set; }
    }
    public class LeaveRequestResultDB
    {
        public int ID { get; set; }
        public bool Result { get; set; }
        public DataTable Employees { get; set; }
        public DataTable EmailTemplate { get; set; }
        public LeaveRequestResultDB()
        {
            Employees = new DataTable();
            EmailTemplate = new DataTable();
        }

    }

    public class LeaveRequestResult
    {
        public int ID { get; set; }
        public bool Result { get; set; }
        public List<RequestApprover> Employees { get; set; }
        public List<EmailTemplate> EmailTemplate { get; set; }
        

    }
}
