using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
   public  class EmployeeVacation
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime RecordDate { get; set; }
        public string WithPay { get; set; }
        public string WithOutPay { get; set; }
        public string Approved { get; set; }
        public string Destination { get; set; }
        public DateTime DepartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal? Dues { get; set; }
        public string Duration { get; set; }
        public int MonthsEarly { get; set; }
        public string Reason { get; set; }
        public string Remarks { get; set; }
        public bool Emergency { get; set; }
        public bool VacationDue { get; set; }
        public bool TravelOrder { get; set; }
        public bool Ticket { get; set; }
        public bool IqamaRenewal { get; set; }
        public bool EntryExitVisa { get; set; }
        public string Contact { get; set; }
        public string HandOver { get; set; }
        public DateTime? LastWorkingDate { get; set; }
        public DateTime? FinalDepartDate { get; set; }
        public string PreparedBy { get; set; }
        public int RecordCreatedBy { get; set; }
        public DateTime RecordDateAdded { get; set; }

        public int VacationRotation { get; set; }
        public DateTime? ExpiryDate { get; set; }


        public string Division { get; set; }
        public int DivisionID { get; set; }

        public int PositionID { get; set; }
        public string Position { get; set; }


        public int NationalityID { get; set; }
        public string Nationality { get; set; }

        public List<VacationAsset> Assets { get; set; }
        public List<EmployeeApproval> Approvals { get; set; }

    }
    public class VacationAsset
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ClearanceID { get; set; }
        public int EmployeeID { get; set; }
        public int AssetID { get; set; }
    }
    public class EmployeeVacationParam
    {
        public int EmployeeID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool EmergencyOnly { get; set; }

    }
    public class EmployeeVacationDB
    {
        public DataTable Vacation { get; set; }
        public DataTable Approvals { get; set; }
        public DataTable Assets { get; set; }

        public EmployeeVacationDB()
        {
            Vacation = new DataTable();
            Approvals = new DataTable();
            Assets = new DataTable();
        }
    }
    public class EmployeeVacationListView
    {
        public List<EmployeeVacation> Vacation { get; set; }
        public List<VacationAsset> Assets { get; set; }
        public List<EmployeeApproval> Approvals { get; set; }
    }

}
