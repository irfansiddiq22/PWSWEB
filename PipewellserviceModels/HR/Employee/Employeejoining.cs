using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
   public class EmployeeJoining
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime LastDepartDate { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime NextDepartDate { get; set; }
        public string Remarks { get; set; }
        public string PreparedBy { get; set; }
        public int RecordCreatedBy { get; set; }
        public DateTime RecordDateCreated { get; set; }
        public bool RecordDeleted { get; set; }
        public DateTime RecordDateUpdated { get; set; }
        public string RecordDeletedBy { get; set; }

        public List<EmployeeApproval> Approvals { get; set; }

        public string Division { get; set; }
        public int DivisionID { get; set; }

        public int PositionID { get; set; }
        public string Position { get; set; }


        public int NationalityID { get; set; }
        public string Nationality { get; set; }
        public string EmployeeName { get; set; }
    }
    public class EmployeeJoiningDB
    {
        public DataTable Joining { get; set; }
        public DataTable Approvals { get; set; }

        public EmployeeJoiningDB()
        {
            Joining = new DataTable();
            Approvals = new DataTable();
        }
    }
    public class EmployeeJoiningListView
    {
        public List<EmployeeJoining> Joining { get; set; }
        public List<EmployeeApproval> Approvals { get; set; }
    }


}
