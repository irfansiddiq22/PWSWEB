using PipewellserviceDB.Common;
using PipewellserviceModels.Home;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB.Home
{
    public class HomeService : DataServices
    {

        public async Task<bool> SavePersonalDetails(PersonalDetail PersonalDetail, List<PersonalWorkExperience> WorkExperience)
        {
            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<NewDataSet>");
                
                if (WorkExperience!=null){
                    foreach (PersonalWorkExperience exp in WorkExperience)
                    {

                        
                        xml.Append($"<Table1><CompanyName>{StringHelper.ReplaceXmlChar( exp.CompanyName)}</CompanyName><StartDate>{exp.StartDate.ToString()}</StartDate><EndDate>{exp.EndDate.ToString()}</EndDate><Designation>{StringHelper.ReplaceXmlChar(exp.Designation) }</Designation><JobNature>{StringHelper.ReplaceXmlChar(exp.JobNature) }</JobNature><Notes>{StringHelper.ReplaceXmlChar(exp.Notes) }</Notes></Table1>");
                     
                    }
                }
                xml.Append("</NewDataSet>");

                SqlParameter[] collSP = new SqlParameter[14];
                collSP[0] = new SqlParameter { ParameterName = "@EmployeeNumber", Value = PersonalDetail.EmployeeNumber };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = PersonalDetail.Name };
                collSP[2] = new SqlParameter { ParameterName = "@PassportNumber", Value = StringHelper.NullToString( PersonalDetail.PassportNumber) };
                collSP[3] = new SqlParameter { ParameterName = "@AramcoID", Value = StringHelper.NullToString(PersonalDetail.AramcoID) };

                collSP[4] = new SqlParameter { ParameterName = "@DateOfBirth", Value = PersonalDetail.DateOfBirth };
                collSP[5] = new SqlParameter { ParameterName = "@Nationality", Value = PersonalDetail.Nationality };
                collSP[6] = new SqlParameter { ParameterName = "@EducationQualification", Value = StringHelper.NullToString(PersonalDetail.EducationQualification) };
                collSP[7] = new SqlParameter { ParameterName = "@Languages", Value = StringHelper.NullToString(PersonalDetail.Languages) };
                collSP[8] = new SqlParameter { ParameterName = "@PersonalQualification", Value = StringHelper.NullToString(PersonalDetail.PersonalQualification) };
                collSP[9] = new SqlParameter { ParameterName = "@OtherTraining", Value = StringHelper.NullToString(PersonalDetail.OtherTraining) };
                collSP[10] = new SqlParameter { ParameterName = "@OtherCourses", Value = StringHelper.NullToString(PersonalDetail.OtherCourses) };
                collSP[11] = new SqlParameter { ParameterName = "@SafetyTrainingCourses", Value = StringHelper.NullToString(PersonalDetail.SafetyTrainingCourses) };
                collSP[12] = new SqlParameter { ParameterName = "@EmailAddress", Value = StringHelper.NullToString(PersonalDetail.EmailAddress) };
                
                collSP[13] = new SqlParameter { ParameterName = "@WorkExperience", Value = xml.ToString() };
               
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcSavePersonalDetail", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }

}
