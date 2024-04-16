using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{

    public class EmployeeWarningDTO
    {
        public int EmployeeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class EmployeeWarningReport: EmployeeWarning {
        public Byte[] ApprovalSign1 { get; set; }
        public Byte[] ApprovalSign2 { get; set; }
        public Byte[] ApprovalSign3 { get; set; }
        public string ApprovalPosition1 { get; set; }
        public string ApprovalPosition2 { get; set; }
        public string ApprovalPosition3 { get; set; }


    }
    public class EmployeeWarning
    {
        public string EmployeeName { get; set; }
        public string Division { get; set; }
        public string Position { get; set; }
        public int? DivisionID { get; set; }
        public int? PositionID { get; set; }
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime WarningDate { get; set; }
        public WarningTypes WarningType { get; set; }
        public string WarningTypeName { get { return WarningType.ToString(); } }
        public bool FirstWarning { get { return WarningType == WarningTypes.FirstWarning;  } }
        public bool SecondWarning { get { return WarningType == WarningTypes.SecondWarning ; } }
        public bool ThirdWarning { get { return WarningType == WarningTypes.ThirdWarning ; } }
        public bool Written { get; set; }
        public bool Tardiness { get; set; }
        public bool Absenteeism { get; set; }
        public bool Violation { get; set; }
        public bool Substandard { get; set; }
        public bool Policies { get; set; }
        public bool Rudeness { get; set; }
        public bool Other { get; set; }
        public string OtherDetail { get; set; }
        public string Infraction { get; set; }

        public string Improvement { get; set; }
        public string Consequences { get; set; }
        public int ApprovedBy1 { get; set; }
        public int ApprovedBy2 { get; set; }
        public int ApprovedBy3 { get; set; }

        public string ApprovedBy1Name { get; set; }
        public string ApprovedBy2Name { get; set; }
        public string ApprovedBy3Name { get; set; }
        public WarningApprovalType Approved1 { get; set; }
        public WarningApprovalType Approved2 { get; set; }
        public WarningApprovalType Approved3 { get; set; }
        public string Approved1Name { get { return Approved1.ToString(); } }
        public string Approved2Name { get { return Approved2.ToString(); } }
        public string Approved3Name { get { return Approved3.ToString(); } }
        public DateTime? ApprovedDate1 { get; set; }
        public DateTime? ApprovedDate2 { get; set; }
        public DateTime? ApprovedDate3 { get; set; }

        public string ApprovalRemarks1 { get; set; }
        public string ApprovalRemarks2 { get; set; }
        public string ApprovalRemarks3 { get; set; }
        public string FileName { get; set; }
        public string FileID { get; set; }
        public string PreparedBy { get; set; }
        public DateTime RecordDateAdded { get; set; }
        public string RecordAddedBy { get; set; }
    }
}
