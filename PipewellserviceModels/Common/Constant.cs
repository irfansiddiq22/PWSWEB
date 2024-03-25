using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Common
{
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
        Contract=9
    }

    public enum DirectoryNames
    {
        EmployeeCertifications,
        EmployeeAssets,
        EmployeeIDs,
        EmployeeFamilyIDs,
        EmployeeFamily,
        EmployeeContract,
    }
}
