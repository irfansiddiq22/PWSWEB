using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Home
{
    public class PersonalDetail
    {
        public int ID { get; set; }
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string AramcoID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string EducationQualification { get; set; }
        public string Languages { get; set; }
        public string PersonalQualification { get; set; }
        public string OtherTraining  { get; set; }
        public string OtherCourses { get; set; }
        public string SafetyTrainingCourses { get; set; }
        public int TotalRecords { get; set; }
    }
    public class PersonalWorkExperience
    {
        public string Duration { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Designation { get; set; }
        public string JobNature { get; set; }
        public string Notes { get; set; }
    }
    public class EmployeeCVParam
    {
        public string Name { get; set; }
        public string EmployeeNumber { get; set; }
        public string PassportNumber { get; set; }
        public string AramcoID { get; set; }
        public string Nationality { get; set; }
        public int PageNumber { get; set; }
        public int pageSize { get; set; }
    }
    public class PersonalDataSQL
    {
        public DataTable Detail { get; set; }
        public DataTable WorkExperience { get; set; }
        public PersonalDataSQL()
        {
            Detail = new DataTable();
            WorkExperience = new DataTable();
        }
    }
    public class EmployeeCV
    {
        public PersonalDetail Detail { get; set; }
        public List<PersonalWorkExperience> WorkExperience { get; set; }
    }
         
}

