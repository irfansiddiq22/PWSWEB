using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
    public class EmployeeReferenceData
    {
        public int SupervisorID { get; set; }
        public int? NationalityID { get; set; }
        public int? PositionID { get; set; }
        public int? DivisionID { get; set; }

        public int? VacationRotation { get; set; }
        public DateTime? IqmaExpiryDate { get; set; }
        public DateTime? IqamaIssueDate { get; set; }
        
    }
    public class Supervisor
    {
        public int ID { get; set; }
        public int DivisionID { get; set; }
        public string Name { get; set; }
    }
    public class EmployeeIDView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string New { get; set; }
    }
    public class EmployeeListView : EmployeeData
    {
        public string SponsorCompany { get; set; }
        public string Division { get; set; }
        public string Position { get; set; }
        public string Supervisor { get; set; }

        public string IqamaFileName { get; set; }
        public string IqamaFileID { get; set; }

        public string Passport { get; set; }
        public DateTime? IqamaExpiryDate { get; set; }
        public DateTime? PassportExpiryDate { get; set; }
        public string CurrentJobStatus
        {
            get
            {
                if (JobStatus == Common.JobStatus.LeftJob)
                    return "Left the job";
                else if (JobStatus == Common.JobStatus.OnJob)
                    return "On the job";
                else
                    return "";
            }
        }
    }
    public class EmployeeData : EmployeeReferenceData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string LabourCode { get; set; }
        public string EmailAddress { get; set; }
        public string Nationality { get; set; }
        public Religion? Religion { get; set; }
        public Gender? Gender { get; set; }
        public MartialStatus? MartialStatus { get; set; }
        public int AnnualTicket { get; set; }
        public string PhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Grade { get; set; }
        public JobStatus? JobStatus { get; set; }
        public string Remarks { get; set; }
        public string GOSI { get; set; }
        public string SocialInsuranceNo { get; set; }
        public SocialInsuranceClass SocialInsuranceClass { get; set; }
        public int? SponsorID { get; set; }
        public int? VendorID { get; set; }
        public ContractType ContractType { get; set; }
        public int NoOfDependent { get; set; }
        public HiringSource? HiringSource { get; set; }
        public string HiringCost { get; set; }
        public DateTime? HiringDate { get; set; }
        public DateTime? LastJoinDate { get; set; }
        public DateTime? LastVacation { get; set; }
        public DateTime? NextVacation { get; set; }
        public DateTime? DataOfBirth { get; set; }
        public DateTime? JobLeftDate { get; set; }
        public int? JobTimingID { get; set; }
        public bool ShowInAttendence { get; set; }
        public bool DeductSalary { get; set; }
        public string FileName { get; set; }
        public string FileID { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string Iqama { get; set; }
        public int PermissionGroupID { get; set; }

        public int QiwaContract { get; set; }
        public string IqamaProfession { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string EmergencyContactRelation { get; set; }
        public bool AccommodationRequired { get; set; }
        public string IBAN { get; set; }
    }
    public class EmployeeContract
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string Nationality { get; set; }
        public DateTime RecordDateUpdated { get; set; }
        public string FileID { get; set; }
        public string FileName { get; set; }
        public string RecordUpdatedBy { get; set; }
    }

    public class EmployeeDataSql
    {
        public DataTable Department { get; set; }
        public DataTable Division { get; set; }
        public DataTable Position { get; set; }
        public DataTable Supervisior { get; set; }
        public DataTable Sponsor { get; set; }
        public DataTable Nationality { get; set; }
        public DataTable WorkTime { get; set; }
        public EmployeeDataSql()
        {
            Department = new DataTable();
            Division = new DataTable();
            Position = new DataTable();
            Supervisior = new DataTable();
            Sponsor = new DataTable();
            WorkTime = new DataTable();
            Nationality = new DataTable();
        }
    }
    public class EmployeeListData
    {
        public List<Department> departments { get; set; }
        public List<Division> divisions { get; set; }
        public List<Position> positions { get; set; }
        public List<EmployeeIDView> supervisior { get; set; }
        public List<SponsorCompany> sponsors { get; set; }
        public List<WorkInOutTime> worktime { get; set; }
        public List<Nationality> nationalities { get; set; }
    }
}
