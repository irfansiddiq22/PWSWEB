using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
    public class EmployeeClearanceDB
    {
        public DataTable Clearance { get; set; }
        public DataTable Approvals { get; set; }
        public DataTable Assets { get; set; }

        public EmployeeClearanceDB()
        {
            Clearance = new DataTable();
            Approvals = new DataTable();
            Assets = new DataTable();
        }
    }
    public class EmployeeClearanceListView {
        public List <EmployeeClearance> Clearance { get; set; }
        public List<ClearanceAsset> Assets { get; set; }
        public List<EmployeeApproval> Approvals { get; set; }
    }

    public class EmployeeClearance
    {


        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? ClearanceDate { get; set; }
        public string ContactNumber { get; set; }
        public string Handover { get; set; }
        public DateTime? LastWorkingDate { get; set; }
        public string Preparedby { get; set; }
        public DateTime RecordDateAdded { get; set; }
        public string RecordAddedby { get; set; }
        public List<ClearanceAsset> Assets { get; set; }
        public List<EmployeeApproval> Approvals { get; set; }

        public string Division { get; set; }
        public int DivisionID { get; set; }

        public int PositionID { get; set; }
        public string Position { get; set; }


        public int NationalityID { get; set; }
        public string Nationality { get; set; }
    }

    public class ClearanceAsset
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ClearanceID { get; set; }
        public int EmployeeID { get; set; }
        
        public int AssetID { get; set; }
    }

    public class InquiryParam
    {
        public int EmployeeID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        
    }
}
