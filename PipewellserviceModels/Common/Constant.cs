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
    }
    public enum ParentEnums
    {
        WARNING_TYPES=1,
        APPROVAL_TYPES=2,
        APPOVALFORM_TYPES=3,
        RESOURCES=4,
        PAGES=5,
        LEAVE_TPES=6,
        CERTIFICATE_TYPES=7
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
        LeftJob = 2
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
        FirstWarning=1,
        SecondWarning=2,
        ThirdWarning=3
    }
    public enum WarningApprovalType {
        NotApproved=0,
        Approved=1,
        Rejected=2,
        None=3



    }
    public enum Pages
    {
        Divisions = 1,
        Positions = 2,
        Departments = 3,
        Certificates = 4,
        Assets = 5,
        EmployeeID = 6,
        Family = 7,
        FamilyID = 8,
        Contract=9,
        EmployeeDetail=10,
        EmployeeWarning=11,
        EmployeeClearance = 12,
        EmployeeVacation = 13,
    }

    public enum DirectoryNames
    {
        
        EmployeePictures =1,
        EmployeeCertifications=2,
        EmployeeAssets=3,
        EmployeeIDs=4,
        EmployeeFamilyIDs=5,
        EmployeeFamily=6,
        EmployeeContract=7,
        EmployeeWarnings=8,
    }
    public enum ApprovalTypes
    {
        Clearance=1,
        Warning=2
    }
}
