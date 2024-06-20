using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Common
{
    public class Constant
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int ParentID { get; set; }
        public int SubParentID { get; set; }
    }
    public enum ParentEnums
    {
        WARNING_TYPES = 1,
        APPROVAL_TYPES = 2,
        APPOVALFORM_TYPES = 3,
        RESOURCES = 4,
        PAGES = 5,
        LEAVE_TPES = 6,
        CERTIFICATE_TYPES = 7,
        DocTemplates = 10,
        REPORTHEADER = 11,
        PAGEGROUPS = 12,
        USERGRPOUPS = 13,
        JOB_STATUS = 14,
        EMAIL_TEMPLATE_TYPES = 15
    }
    public enum UserGroups
    {
        none = 0,
        Admin = 1,
        Employee = 2
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }
    public enum MartialStatus
    {
        None = 0,
        Married = 1,
        Single = 2,
        Divorced = 3,
        Widowed = 4

    }
    public enum Religion
    {
        Muslim = 1,
        NonMuslim = 2
    }
    public enum JobStatus
    {
        None = 0,
        OnJob = 1,
        LeftJob = 2,
        OnVaction = 3,
        Terminated = 4,
        Transfered = 5
    }
    public enum HiringSource
    {
        None = 0,
        Direct = 1,
        InDirect = 2,
        Agency = 3
    }
    public enum SocialInsuranceClass
    {
        None = 0,
        A = 1,
        B = 2,
        C = 3,
        D = 4


    }
    public enum ContractType
    {
        None = 0,
        Family = 1,
        Single = 2
    }
    public enum WarningTypes
    {
        FirstWarning = 1,
        SecondWarning = 2,
        ThirdWarning = 3
    }
    public enum ApprovalStatus
    {
        NotApproved = 0,
        Approved = 1,
        Declined = 2,
        New = 3,
        Ready = 4,
        Pending = 5,
        Requested = 6,
        NoAction=7
    }
    public enum ApprovalTypes
    {
        Clearance = 1,
        Inquiry = 2,
        Warning = 3,

        Vacation = 4,
        Joining = 5,
        ShortLeave = 6,
        Leaves = 7


    }
    public enum PageGroups
    {
        HR = 1,
        HRSetting = 2,
        Setting = 3,
        Procurement=4,
        ProcurementStore=5

    }
    public enum ReportTypes
    {
        EmployeeAttendenceInOut = 1,
        EmployeeAttendenceDetail = 2,
        EmployeeAttendenceSummary = 3,
        EmployeeWarning = 11,
        EmployeeInquiry = 16,

    }
    
    public enum Pages
    {
        None = 0,
        Divisions = 1,
        Positions = 2,
        Departments = 3,
        Certificates = 4,
        Assets = 5,
        EmployeeID = 6,
        Family = 7,
        FamilyID = 8,
        Contract = 9,
        EmployeeDetail = 10,
        EmployeeWarning = 11,
        EmployeeClearance = 12,
        EmployeeVacation = 13,

        JobOffers = 14,
        JobContracts = 15,
        EmployeeInquiry = 16,
        Users = 17,
        Permissions = 18,
        Vendor = 19,
        Joining = 20,
        ShortLeave = 21,
        LeaveRequest = 22,
        Approvals = 23,
        Accommodation = 24,
        WorkTime = 25,
        EmployeeWorkTiming = 26,
        AttendenceReport = 27,
        ProcurementStoreItemManagement=28

    }

    public enum DirectoryNames
    {

        EmployeePictures = 1,
        EmployeeCertifications = 2,
        EmployeeAssets = 3,
        EmployeeIDs = 4,
        EmployeeFamilyIDs = 5,
        EmployeeFamily = 6,
        EmployeeContract = 7,
        EmployeeWarnings = 8,
        EmployeeJobOffer = 9,
        EmployeeJobContract = 10,
        Templates = 11,
        EmployeeInquiry = 12,
        EmployeeJoining = 13,
        EmployeeShortLeave = 14,
        Leaves = 15
    }

    public enum DocTemplates
    {
        JobOffer = 1,
        Contract = 2
    }
    public enum SupervisorTypes
    {
        Supervisor = 1,
        HRManager = 2
    }
    public enum PriorityTimeUnit
    {
        Hour = 1,
        Day = 2
    }
}
