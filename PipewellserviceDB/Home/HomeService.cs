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


        public async Task<int> SaveSupplierAssesment(SupplierAssesment assesment)
        {
            try
            {
                StringBuilder items = new StringBuilder();
                StringBuilder customers = new StringBuilder();
                StringBuilder productions = new StringBuilder();
                StringBuilder qualtycontrol = new StringBuilder();
                items.AppendLine("<NewDataSet>");
                if (assesment.SupplierItems != null && assesment.SupplierItems.Count > 0)
                {
                    foreach (SupplierItem a in assesment.SupplierItems)
                    {
                        items.AppendLine($"<Table1><ItemName>{ StringHelper.ReplaceXmlChar( a.ItemServiceName)}</ItemName></Table1>");
                    }
                }
                items.AppendLine("</NewDataSet>");


                customers.AppendLine("<NewDataSet>");
                if (assesment.SupplierCustomers != null && assesment.SupplierCustomers.Count > 0)
                {
                    foreach (SupplierCustomer a in assesment.SupplierCustomers)
                    {
                        customers.AppendLine($"<Table1><CustomerName>{ StringHelper.ReplaceXmlChar(a.CustomerName)}</CustomerName><ItemServiceName>{ StringHelper.ReplaceXmlChar(a.ItemServiceName)}</ItemServiceName><TurnOver>{ StringHelper.ReplaceXmlChar(a.TurnOver)}</TurnOver></Table1>");
                    }
                }
                customers.AppendLine("</NewDataSet>");
                productions.AppendLine("<NewDataSet>");
                if (assesment.SupplierProductionFacilities != null && assesment.SupplierProductionFacilities.Count > 0)
                {
                    foreach (SupplierProductionFacility a in assesment.SupplierProductionFacilities)
                    {
                        productions.AppendLine($"<Table1><MachineName>{ StringHelper.ReplaceXmlChar(a.MachineName)}</MachineName><Model>{ StringHelper.ReplaceXmlChar(a.Model)}</Model><NoOfMachines>{ StringHelper.ReplaceXmlChar(a.NoOfMachines)}</NoOfMachines></Table1>");
                    }
                }
                productions.AppendLine("</NewDataSet>");

                qualtycontrol.AppendLine("<NewDataSet>");
                if (assesment.SupplierQualityControlFacilities != null && assesment.SupplierQualityControlFacilities.Count > 0)
                {
                    foreach (SupplierQualityControlFacility a in assesment.SupplierQualityControlFacilities)
                    {
                        qualtycontrol.AppendLine($"<Table1><EquipmentDescription>{ StringHelper.ReplaceXmlChar(a.EquipmentDescription)}</EquipmentDescription><Range>{ StringHelper.ReplaceXmlChar(a.Range)}</Range><Quantity>{ StringHelper.ReplaceXmlChar(a.Quantity)}</Quantity></Table1>");
                    }
                }
                qualtycontrol.AppendLine("</NewDataSet>");


                SqlParameter[] parameters = new SqlParameter[60];
                parameters[0] = new SqlParameter { ParameterName = "@ID", Value = assesment.ID };
                parameters[1] = new SqlParameter { ParameterName = "@Assessment", Value = assesment.Assessment };
                parameters[2] = new SqlParameter { ParameterName = "@RecordDate", Value = assesment.RecordDate };
                parameters[3] = new SqlParameter { ParameterName = "@CompanyName", Value =StringHelper.NullToString( assesment.CompanyName) };
                parameters[4] = new SqlParameter { ParameterName = "@PoBox", Value = StringHelper.NullToString(assesment.PoBox) };
                parameters[5] = new SqlParameter { ParameterName = "@PostalCode", Value = StringHelper.NullToString( assesment.PostalCode) };
                parameters[6] = new SqlParameter { ParameterName = "@Street", Value = StringHelper.NullToString( assesment.Street )};
                parameters[7] = new SqlParameter { ParameterName = "@City", Value = StringHelper.NullToString( assesment.City )};
                parameters[8] = new SqlParameter { ParameterName = "@Region", Value = StringHelper.NullToString( assesment.Region )};
                parameters[9] = new SqlParameter { ParameterName = "@Country", Value = StringHelper.NullToString( assesment.Country )};
                parameters[10] = new SqlParameter { ParameterName = "@Website", Value = StringHelper.NullToString( assesment.Website )};
                parameters[11] = new SqlParameter { ParameterName = "@GeneralEmailAddress", Value = StringHelper.NullToString( assesment.GeneralEmailAddress )};
                parameters[12] = new SqlParameter { ParameterName = "@PhoneNumber", Value = StringHelper.NullToString( assesment.PhoneNumber )};
                parameters[13] = new SqlParameter { ParameterName = "@FaxNumber", Value = StringHelper.NullToString( assesment.FaxNumber )};
                parameters[14] = new SqlParameter { ParameterName = "@CRNumber", Value = StringHelper.NullToString( assesment.CRNumber )};
                parameters[15] = new SqlParameter { ParameterName = "@CRExpiryDate", Value = StringHelper.NullToString( assesment.CRExpiryDate )};
                parameters[16] = new SqlParameter { ParameterName = "@CRFile", Value = StringHelper.NullToString( assesment.CRFile )};
                parameters[17] = new SqlParameter { ParameterName = "@ZakatNumber", Value = StringHelper.NullToString( assesment.ZakatNumber )};
                parameters[18] = new SqlParameter { ParameterName = "@ZakatExpiryDate", Value = StringHelper.NullToString( assesment.ZakatExpiryDate )};
                parameters[19] = new SqlParameter { ParameterName = "@ZakatFile", Value = StringHelper.NullToString( assesment.ZakatFile )};
                parameters[20] = new SqlParameter { ParameterName = "@VATRegNumber", Value = StringHelper.NullToString( assesment.VATRegNumber )};
                parameters[21] = new SqlParameter { ParameterName = "@ChamberMemberShip", Value = StringHelper.NullToString( assesment.ChamberMemberShip )};
                parameters[22] = new SqlParameter { ParameterName = "@MemberShipDate", Value = StringHelper.NullToString( assesment.MemberShipDate )};
                parameters[23] = new SqlParameter { ParameterName = "@Local", Value = StringHelper.NullToString( assesment.Local )};
                parameters[24] = new SqlParameter { ParameterName = "@CompanyType", Value = StringHelper.NullToString( assesment.CompanyType )};
                parameters[25] = new SqlParameter { ParameterName = "@ContractServiceProvider", Value = StringHelper.NullToString( assesment.ContractServiceProvider )};
                parameters[26] = new SqlParameter { ParameterName = "@ScopeOfServices", Value = StringHelper.NullToString( assesment.ScopeOfServices )};
                parameters[27] = new SqlParameter { ParameterName = "@ScopeOfProducts", Value = StringHelper.NullToString( assesment.ScopeOfProducts )};
                parameters[28] = new SqlParameter { ParameterName = "@CompanyBusinessEntityType", Value = StringHelper.NullToString( assesment.CompanyBusinessEntityType )};
                parameters[29] = new SqlParameter { ParameterName = "@BankAcctNumber", Value = StringHelper.NullToString( assesment.BankAcctNumber )};
                parameters[30] = new SqlParameter { ParameterName = "@BankName", Value = StringHelper.NullToString( assesment.BankName )};
                parameters[31] = new SqlParameter { ParameterName = "@BeneficiaryBankAddress", Value = StringHelper.NullToString( assesment.BeneficiaryBankAddress )};
                parameters[32] = new SqlParameter { ParameterName = "@SwiftCode", Value = StringHelper.NullToString( assesment.SwiftCode )};
                parameters[33] = new SqlParameter { ParameterName = "@BankSortcode", Value = StringHelper.NullToString( assesment.BankSortcode )};
                parameters[34] = new SqlParameter { ParameterName = "@IBAN", Value = StringHelper.NullToString( assesment.IBAN )};
                parameters[35] = new SqlParameter { ParameterName = "@BankContactMobileNumber", Value = StringHelper.NullToString( assesment.BankContactMobileNumber )};
                parameters[36] = new SqlParameter { ParameterName = "@BankContactEmailAddress", Value = StringHelper.NullToString( assesment.BankContactEmailAddress )};
                parameters[37] = new SqlParameter { ParameterName = "@ComanyManagerName", Value = StringHelper.NullToString( assesment.ComanyManagerName )};
                parameters[38] = new SqlParameter { ParameterName = "@ManagerTitle", Value = StringHelper.NullToString( assesment.ManagerTitle )};
                parameters[39] = new SqlParameter { ParameterName = "@ManagerMobileNumber", Value = StringHelper.NullToString( assesment.ManagerMobileNumber )};
                parameters[40] = new SqlParameter { ParameterName = "@ManagerFaxNumber", Value = StringHelper.NullToString( assesment.ManagerFaxNumber )};
                parameters[41] = new SqlParameter { ParameterName = "@ManagerEmailAddress", Value = StringHelper.NullToString( assesment.ManagerEmailAddress )};
                parameters[42] = new SqlParameter { ParameterName = "@CompanyQRName", Value = StringHelper.NullToString( assesment.CompanyQRName )};
                parameters[43] = new SqlParameter { ParameterName = "@QRTitle", Value = StringHelper.NullToString( assesment.QRTitle )};
                parameters[44] = new SqlParameter { ParameterName = "@QRMobileNumber", Value = StringHelper.NullToString( assesment.QRMobileNumber )};
                parameters[45] = new SqlParameter { ParameterName = "@QRFaxNumber", Value = StringHelper.NullToString( assesment.QRFaxNumber )};
                parameters[46] = new SqlParameter { ParameterName = "@QREmailAddress", Value = StringHelper.NullToString( assesment.QREmailAddress )};
                parameters[47] = new SqlParameter { ParameterName = "@QualityManagementCertificate", Value = StringHelper.NullToString( assesment.QualityManagementCertificateFile )};
                parameters[48] = new SqlParameter { ParameterName = "@ISO9001Certificate", Value = StringHelper.NullToString( assesment.ISO9001Certificate )};
                parameters[49] = new SqlParameter { ParameterName = "@APISpecQ1Certificate", Value = StringHelper.NullToString( assesment.APISpecQ1Certificate )};
                parameters[50] = new SqlParameter { ParameterName = "@APISpecQ2Certificate", Value = StringHelper.NullToString( assesment.APISpecQ2Certificate )};
                parameters[51] = new SqlParameter { ParameterName = "@QMSCertificate", Value = StringHelper.NullToString( assesment.QMSCertificate )};
                parameters[52] = new SqlParameter { ParameterName = "@QMSCertificateNotes", Value = StringHelper.NullToString( assesment.QMSCertificateNotes )};
                parameters[53] = new SqlParameter { ParameterName = "@CurrentTurnOver", Value = StringHelper.NullToString( assesment.CurrentTurnOver )};
                parameters[54] = new SqlParameter { ParameterName = "@PurchaseTypeCritical", Value = StringHelper.NullToString( assesment.PurchaseTypeCritical )};
                parameters[55] = new SqlParameter { ParameterName = "@DirectEmployees", Value = StringHelper.NullToString( assesment.DirectEmployees )};
                parameters[56] = new SqlParameter { ParameterName = "@IndirectEmployees", Value = StringHelper.NullToString( assesment.IndirectEmployees )};
                parameters[57] = new SqlParameter { ParameterName = "@TechnicalEmployees", Value = StringHelper.NullToString( assesment.TechnicalEmployees )};
                parameters[58] = new SqlParameter { ParameterName = "@OtherEmployees", Value = StringHelper.NullToString( assesment.OtherEmployees )};
                parameters[59] = new SqlParameter { ParameterName = "@NationalAddress", Value = StringHelper.NullToString(assesment.NationalAddress) };
                int ID=Convert.ToInt32(  SqlHelper.ExecuteScalar(ConnectionString, "ProcAddOrUpdateSupplierAssesment", CommandType.StoredProcedure, parameters));
                try
                {
                    parameters = new SqlParameter[5];
                    parameters[0] = new SqlParameter { ParameterName = "@ID", Value = ID };
                    parameters[1] = new SqlParameter { ParameterName = "@Customers", Value = customers.ToString() };
                    parameters[2] = new SqlParameter { ParameterName = "@items", Value = items.ToString() };
                    parameters[3] = new SqlParameter { ParameterName = "@production", Value = productions.ToString() };
                    parameters[4] = new SqlParameter { ParameterName = "@qualitycontrol", Value = qualtycontrol.ToString() };

                    SqlHelper.ExecuteNonQuery(ConnectionString, "ProcAddOrUpdateSupplierAssesmentData", CommandType.StoredProcedure, parameters);
                }catch(Exception e) { }
                return ID;
               
            }catch(Exception e)
            {
                return 0;
            }
        }
        public async Task<bool> SaveSupplierAssesmentFiles(int ID,AssessmentFile assesmentFile)
        {

            try
            {
                SqlParameter[] parameters = new SqlParameter[17];
                parameters[0] = new SqlParameter { ParameterName = "@ID", Value = ID };
                parameters[1] = new SqlParameter { ParameterName = "@CRFile", Value = assesmentFile.CRFile };
                parameters[2] = new SqlParameter { ParameterName = "@CRFileID", Value = assesmentFile.CRFileID };
                parameters[3] = new SqlParameter { ParameterName = "@ZakatFile", Value = StringHelper.NullToString(assesmentFile.ZakatFile) };
                parameters[4] = new SqlParameter { ParameterName = "@ZakatFileID", Value = StringHelper.NullToString(assesmentFile.ZakatFileID) };
                parameters[5] = new SqlParameter { ParameterName = "@ChamberMemberShipFile", Value = StringHelper.NullToString(assesmentFile.ChamberMemberShipFile) };
                parameters[6] = new SqlParameter { ParameterName = "@ChamberMemberShipFileID", Value = StringHelper.NullToString(assesmentFile.ChamberMemberShipFileID) };
                parameters[7] = new SqlParameter { ParameterName = "@QualityManagementCertificateFile", Value = StringHelper.NullToString(assesmentFile.QualityManagementCertificateFile) };
                parameters[8] = new SqlParameter { ParameterName = "@QualityManagementCertificateFileID", Value = StringHelper.NullToString(assesmentFile.QualityManagementCertificateFileID) };
                parameters[9] = new SqlParameter { ParameterName = "@MajorCustomerFile", Value = StringHelper.NullToString(assesmentFile.MajorCustomerFile) };

                parameters[10] = new SqlParameter { ParameterName = "@MajorCustomerFileID", Value = StringHelper.NullToString(assesmentFile.MajorCustomerFileID) };
                parameters[11] = new SqlParameter { ParameterName = "@ProductionFile", Value = StringHelper.NullToString(assesmentFile.ProductionFile) };
                parameters[12] = new SqlParameter { ParameterName = "@ProductionFileID", Value = StringHelper.NullToString(assesmentFile.ProductionFileID) };

                parameters[13] = new SqlParameter { ParameterName = "@QualityControlFile", Value = StringHelper.NullToString(assesmentFile.QualityControlFile) };
                parameters[14] = new SqlParameter { ParameterName = "@QualityControlFileID", Value = StringHelper.NullToString(assesmentFile.QualityControlFileID) };

                parameters[15] = new SqlParameter { ParameterName = "@NationalAddressFile", Value = StringHelper.NullToString(assesmentFile.NationalAddressFile) };
                parameters[16] = new SqlParameter { ParameterName = "@NationalAddressFileID", Value = StringHelper.NullToString(assesmentFile.NationalAddressFileID) };
                SqlHelper.ExecuteScalar(ConnectionString, "ProcAddOrUpdateSupplierAssessmentFiles", CommandType.StoredProcedure, parameters);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
    
}
