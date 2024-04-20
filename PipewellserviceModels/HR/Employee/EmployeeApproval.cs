using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
    public class EmployeeApproval
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int RecordID { get; set; }
        public ApprovalTypes RecordType { get; set; }
        public int ApprovalBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string Remarks { get; set; }

    }
    public class PendingApproval
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int RecordID { get; set; }
        public ApprovalTypes RecordType { get; set; }
        public int ApprovalBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string Remarks { get; set; }
        public ApprovalStatus Status { get; set; }
        public string ApprovalForm { get; set; }
        public int PageID { get; set; }
        public string PreparedBy { get; set; }

        public DateTime RecordDate { get; set; }

        public int EmployeeID { get; set; }

        public string FileID { get; set; }
        public string FileName { get; set; }


    }
}
