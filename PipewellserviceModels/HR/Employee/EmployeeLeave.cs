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
        public int PriorityLevelID { get; set; }
        public string PriorityLevelName { get; set; }
        public string ColorCode { get; set; }
        public int Status { get; set; }
    }
    public class LeaveRequestLog : EmployeeLeave
    {

        public int PendingApprovals {private get; set; }
        public int ApprovedApprovals { private get; set; }
        public int RejectApprovals { private get; set; }
        public string LeaveStatus
        {
            get
            {
                if (RejectApprovals > 0) return "Rejected";
                else if (PendingApprovals == 0 && ApprovedApprovals>0) return "Approved";
                else   return "InProcess";

            }
        }

    }
    public class ApprovalRequestResultDB
    {
        public int ID { get; set; }
        public bool Result { get; set; }
        public DataTable Request { get; set; }
        public DataTable Employees { get; set; }
        public DataTable Status { get; set; }
        public DataTable EmailTemplate { get; set; }
        public ApprovalRequestResultDB()
        {
            Request = new DataTable();
            Employees = new DataTable();
            Status = new DataTable();
            EmailTemplate = new DataTable();
        }

    }

    public class ApprovalRequestResult
    {
        public int ID { get; set; }
        public bool Result { get; set; }
        public List<object> Request { get; set; }
        public List<RequestApprover> Employees { get; set; }
        public List<EmailTemplate> EmailTemplate { get; set; }


    }
}
