﻿using PipewellserviceDB.Common;
using PipewellserviceModels.Common;
using PipewellserviceModels.Home;
using PipewellserviceModels.HR.Employee;
using PipewellserviceModels.HR.Settings;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB.HR.Employee
{
    public class EmployeeService : DataServices
    {

        public async Task<DataTable> CodeName(int EmployeeID)
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "Proc_EmployeeCodeName", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID });
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<DataTable> FamilyCodeName(int EmployeeID)
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "Proc_EmployeeFamilyCodeName", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID });
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<bool> SaveLog(DataChangeLog log)
        {
            return await this.LogUpdate(log);
        }
        ////////----------------------------------------------------------------------

        public async Task<DataTable> CertificateList(int EmployeeID, string Name)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = Name };
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeCertificateList", CommandType.StoredProcedure, collSP);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<int> UpdateCertificate(EmployeeCertificate certificate)
        {
            try
            {

                SqlParameter[] collSP = new SqlParameter[10];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = certificate.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = certificate.Name };
                collSP[2] = new SqlParameter { ParameterName = "@EmployeeID", Value = certificate.EmployeeID };
                collSP[3] = new SqlParameter { ParameterName = "@IssueDate", Value = certificate.IssueDate };
                collSP[4] = new SqlParameter { ParameterName = "@ExpiryDate", Value = certificate.ExpiryDate };
                collSP[5] = new SqlParameter { ParameterName = "@Remarks", Value = StringHelper.NullToString(certificate.Remarks) };
                collSP[6] = new SqlParameter { ParameterName = "@OnShore", Value = certificate.OnShore };
                collSP[7] = new SqlParameter { ParameterName = "@FileName", Value = certificate.FileName };
                collSP[8] = new SqlParameter { ParameterName = "@FileID", Value = certificate.FileID };
                collSP[9] = new SqlParameter { ParameterName = "@RecordUpdatedBy", Value = certificate.RecordUpdatedBy };
                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcUpdateEmployeeCertificate", CommandType.StoredProcedure, collSP);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public async Task<bool> RemoveCertificate(DeleteDTO delete)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = delete.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = delete.Name };
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcDeleteEmployeeCertificate", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        ///////////////////-------------------------------------------------
        ///

        public async Task<DataTable> AssetList(int EmployeeID)
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeAssetList", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID });
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<int> UpdateAsset(EmployeeAsset asset)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[8];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = asset.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = asset.Name };
                collSP[2] = new SqlParameter { ParameterName = "@EmployeeID", Value = asset.EmployeeID };
                collSP[3] = new SqlParameter { ParameterName = "@IssueDate", Value = asset.IssueDate };
                collSP[4] = new SqlParameter { ParameterName = "@Remarks", Value = asset.Remarks };
                collSP[5] = new SqlParameter { ParameterName = "@FileName", Value = asset.FileName };
                collSP[6] = new SqlParameter { ParameterName = "@FileID", Value = asset.FileID };
                collSP[7] = new SqlParameter { ParameterName = "@RecordUpdatedBy", Value = asset.RecordUpdatedBy };
                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcUpdateEmployeeAsset", CommandType.StoredProcedure, collSP);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public async Task<bool> RemoveAsset(DeleteDTO delete)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = delete.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = delete.Name };
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcDeleteEmployeeAsset", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////



        public async Task<DataTable> ContractList()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeContractList", CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<DataTable> UpdateContract(EmployeeContract contract)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[4];
                collSP[0] = new SqlParameter { ParameterName = "@EmployeeID", Value = contract.EmployeeID };
                collSP[1] = new SqlParameter { ParameterName = "@FileName", Value = contract.FileName };
                collSP[2] = new SqlParameter { ParameterName = "@FileID", Value = $"{contract.EmployeeID}{contract.FileID}" };
                collSP[3] = new SqlParameter { ParameterName = "@RecordUpdatedBy", Value = contract.RecordUpdatedBy };
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcUpdateEmployeeContract", CommandType.StoredProcedure, collSP);
                return await ContractList();
            }
            catch (Exception e)
            {
                return null;
            }

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<DataTable> EmployeeIDTypeList()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeIDTypeList", CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<DataTable> EmployeeIDFileList(int EmployeeID, string Name)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = Name };
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeIDList", CommandType.StoredProcedure, collSP);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<int> UpdateEmployeeIDFile(EmployeeIDFile file)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[10];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = file.ID };
                collSP[1] = new SqlParameter { ParameterName = "@EmployeeID", Value = file.EmployeeID };
                collSP[2] = new SqlParameter { ParameterName = "@Description", Value = file.Description };
                collSP[3] = new SqlParameter { ParameterName = "@IDNumber", Value = file.IDNumber };
                collSP[4] = new SqlParameter { ParameterName = "@IssueDate", Value = file.IssueDate };
                collSP[5] = new SqlParameter { ParameterName = "@ExpiryDate", Value = file.ExpiryDate };
                collSP[6] = new SqlParameter { ParameterName = "@Remarks", Value = StringHelper.NullToString(file.Remarks) };
                collSP[7] = new SqlParameter { ParameterName = "@FileName", Value = file.FileName };
                collSP[8] = new SqlParameter { ParameterName = "@FileID", Value = file.FileID };
                collSP[9] = new SqlParameter { ParameterName = "@RecordUpdatedBy", Value = file.RecordUpdatedBy };
                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcUpdateEmployeeID", CommandType.StoredProcedure, collSP);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public async Task<bool> RemoveEmployeeIDFile(DeleteDTO delete)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = delete.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = delete.Name };
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcDeleteEmployeeID", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        ///////////////////-------------------------------------------------
        public async Task<DataTable> EmployeeFamilyIDFileList(int EmployeeID)
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeFamilyIDList", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID });
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<int> UpdateEmployeeFamilyIDFile(EmployeeFamilyIDFile file)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[12];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = file.ID };
                collSP[1] = new SqlParameter { ParameterName = "@EmployeeID", Value = file.EmployeeID };
                collSP[2] = new SqlParameter { ParameterName = "@Relation", Value = file.Relation };
                collSP[3] = new SqlParameter { ParameterName = "@Description", Value = file.Description };
                collSP[4] = new SqlParameter { ParameterName = "@IDNumber", Value = file.IDNumber };
                collSP[5] = new SqlParameter { ParameterName = "@IssueDate", Value = file.IssueDate };
                collSP[6] = new SqlParameter { ParameterName = "@ExpiryDate", Value = file.ExpiryDate };
                collSP[7] = new SqlParameter { ParameterName = "@Remarks", Value = file.Remarks };
                collSP[8] = new SqlParameter { ParameterName = "@FileName", Value = file.FileName };
                collSP[9] = new SqlParameter { ParameterName = "@FileID", Value = file.FileID };
                collSP[10] = new SqlParameter { ParameterName = "@RecordUpdatedBy", Value = file.RecordUpdatedBy };
                collSP[11] = new SqlParameter { ParameterName = "@Name", Value = file.Name };
                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcUpdateEmployeeFamilyID", CommandType.StoredProcedure, collSP);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public async Task<bool> RemoveEmployeeFamilyIDFile(DeleteDTO delete)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = delete.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = delete.Name };
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcDeleteEmployeeFamilyID", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        ///////////////////-------------------------------------------------

        public async Task<DataTable> EmployeeRelationList()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeFamilyRelationList", CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<DataTable> EmployeeFamilyList(int EmployeeID)
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeFamilyList", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID });
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<int> UpdateEmployeeFamily(EmployeeFamily family)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[14];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = family.ID };
                collSP[1] = new SqlParameter { ParameterName = "@EmployeeID", Value = family.EmployeeID };
                collSP[2] = new SqlParameter { ParameterName = "@Name", Value = family.Name };
                collSP[3] = new SqlParameter { ParameterName = "@Relation", Value = family.Relation };
                collSP[4] = new SqlParameter { ParameterName = "@DateOfBirth", Value = family.DateOfBirth };
                collSP[5] = new SqlParameter { ParameterName = "@PassportNumber", Value = family.PassportNumber };
                collSP[6] = new SqlParameter { ParameterName = "@PassportIssueDate", Value = family.PassportIssueDate };
                collSP[7] = new SqlParameter { ParameterName = "@PassportExpiryDate", Value = family.PassportExpiryDate };
                collSP[8] = new SqlParameter { ParameterName = "@IqamaNumber", Value = family.IqamaNumber };
                collSP[9] = new SqlParameter { ParameterName = "@LocalPhoneNumber", Value = family.LocalPhoneNumber };
                collSP[10] = new SqlParameter { ParameterName = "@HomePhoneNumber", Value = family.HomePhoneNumber };
                collSP[11] = new SqlParameter { ParameterName = "@FileID", Value = family.FileID };
                collSP[12] = new SqlParameter { ParameterName = "@FileName", Value = family.FileName };
                collSP[13] = new SqlParameter { ParameterName = "@RecordUpdatedBy", Value = family.RecordUpdatedBy };

                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcUpdateEmployeeFamily", CommandType.StoredProcedure, collSP);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public async Task<bool> RemoveEmployeeFamily(DeleteDTO delete)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = delete.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = delete.Name };
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcDeleteEmployeeFamilyMember", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        ///////////////////-------------------------------------------------


        public async Task<DataTable> EmployeeList()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeList", CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<DataTable> EmployeeDetail(int EmployeeID)
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeDetail", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID });
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<EmployeeDataSql> EmployeeDataList()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeDataList", CommandType.StoredProcedure);
                EmployeeDataSql model = new EmployeeDataSql();
                model.Department.Load(result);
                model.Division.Load(result);
                model.Position.Load(result);
                //   model.Supervisior.Load(result);
                model.Sponsor.Load(result);
                model.WorkTime.Load(result);
                model.Nationality.Load(result);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<ResultDTO> UpdateEmployee(EmployeeData employee)
        {

            try
            {
                SqlParameter[] collSP = new SqlParameter[50];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = employee.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = employee.Name };
                collSP[2] = new SqlParameter { ParameterName = "@ArabicName", Value = employee.ArabicName };
                collSP[3] = new SqlParameter { ParameterName = "@SupervisorID", Value = employee.SupervisorID };
                collSP[4] = new SqlParameter { ParameterName = "@EmailAddress", Value = employee.EmailAddress };
                collSP[5] = new SqlParameter { ParameterName = "@NationalityID", Value = employee.NationalityID };
                collSP[6] = new SqlParameter { ParameterName = "@PositionID", Value = employee.PositionID };
                collSP[7] = new SqlParameter { ParameterName = "@DivisionID", Value = employee.DivisionID };
                collSP[8] = new SqlParameter { ParameterName = "@Religion", Value = employee.Religion };
                collSP[9] = new SqlParameter { ParameterName = "@Gender", Value = employee.Gender };

                collSP[10] = new SqlParameter { ParameterName = "@MartialStatus", Value = employee.MartialStatus };
                collSP[11] = new SqlParameter { ParameterName = "@PhoneNumber", Value = employee.PhoneNumber };
                collSP[12] = new SqlParameter { ParameterName = "@HomePhoneNumber", Value = employee.HomePhoneNumber };
                collSP[13] = new SqlParameter { ParameterName = "@Address", Value = employee.Address };
                collSP[14] = new SqlParameter { ParameterName = "@Location", Value = employee.Location };
                collSP[15] = new SqlParameter { ParameterName = "@Grade", Value = employee.Grade };
                collSP[16] = new SqlParameter { ParameterName = "@JobStatus", Value = employee.JobStatus };
                collSP[17] = new SqlParameter { ParameterName = "@Remarks", Value = employee.Remarks };
                collSP[18] = new SqlParameter { ParameterName = "@GOSI", Value = employee.GOSI };
                collSP[19] = new SqlParameter { ParameterName = "@SocialInsuranceNo", Value = employee.SocialInsuranceNo };
                collSP[20] = new SqlParameter { ParameterName = "@LabourCode", Value = employee.LabourCode };
                collSP[21] = new SqlParameter { ParameterName = "@SponsorID", Value = employee.SponsorID };
                collSP[22] = new SqlParameter { ParameterName = "@HiringSource", Value = employee.HiringSource };
                collSP[23] = new SqlParameter { ParameterName = "@HiringCost", Value = employee.HiringCost };
                collSP[24] = new SqlParameter { ParameterName = "@HiringDate", Value = employee.HiringDate };
                collSP[25] = new SqlParameter { ParameterName = "@LastJoinDate", Value = employee.LastJoinDate };
                collSP[26] = new SqlParameter { ParameterName = "@VacationRotation", Value = employee.VacationRotation };
                collSP[27] = new SqlParameter { ParameterName = "@NextVacation", Value = employee.NextVacation };
                collSP[28] = new SqlParameter { ParameterName = "@DataOfBirth", Value = employee.DataOfBirth };
                collSP[29] = new SqlParameter { ParameterName = "@JobTimingID", Value = employee.JobTimingID };
                collSP[30] = new SqlParameter { ParameterName = "@DeductSalary", Value = employee.DeductSalary };
                collSP[31] = new SqlParameter { ParameterName = "@FileName", Value = employee.FileName };
                collSP[32] = new SqlParameter { ParameterName = "@FileID", Value = employee.FileID };
                collSP[33] = new SqlParameter { ParameterName = "@RecordUpdatedBy", Value = employee.RecordUpdatedBy };

                collSP[34] = new SqlParameter { ParameterName = "@SocialInsuranceClass", Value = employee.SocialInsuranceClass };
                collSP[35] = new SqlParameter { ParameterName = "@ContractType", Value = employee.ContractType };
                collSP[36] = new SqlParameter { ParameterName = "@NoOfDependent", Value = employee.NoOfDependent };
                collSP[37] = new SqlParameter { ParameterName = "@AnnualTicket", Value = employee.AnnualTicket };
                collSP[38] = new SqlParameter { ParameterName = "@JobLeftDate", Value = employee.JobLeftDate };
                collSP[39] = new SqlParameter { ParameterName = "@VendorID", Value = employee.VendorID };

                collSP[40] = new SqlParameter { ParameterName = "@IqamaNumber", Value = employee.Iqama };
                collSP[41] = new SqlParameter { ParameterName = "@IqamaIssueDate", Value = employee.IqamaIssueDate };
                collSP[42] = new SqlParameter { ParameterName = "@IqamaExpiryDate", Value = employee.IqamaExpiryDate };

                collSP[43] = new SqlParameter { ParameterName = "@QiwaContract", Value = employee.QiwaContract };
                collSP[44] = new SqlParameter { ParameterName = "@IqamaProfession", Value = employee.IqamaProfession };
                collSP[45] = new SqlParameter { ParameterName = "@EmergencyContactNumber", Value = employee.EmergencyContactNumber };
                collSP[46] = new SqlParameter { ParameterName = "@EmergencyContactRelation", Value = employee.EmergencyContactRelation };
                collSP[47] = new SqlParameter { ParameterName = "@AccommodationRequired", Value = employee.AccommodationRequired };
                collSP[48] = new SqlParameter { ParameterName = "@IBAN", Value = employee.IBAN };
                collSP[49] = new SqlParameter { ParameterName = "@VacationDestination", Value = employee.VacationDestination ?? (object)DBNull.Value };

                

                var Result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcUpdateEmployee", CommandType.StoredProcedure, collSP);
                return new ResultDTO() { ID = Convert.ToInt32(Result), Status = true, Message = "Record Added" };
            }
            catch (Exception e)
            {
                return new ResultDTO() { ID = 0, Status = false, Message = e.Message };
            }

        }

        public async Task<ResultDTO> UpdateEmployeePicture(int EmployeeID, string FileName, string FileID)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = EmployeeID };
                collSP[1] = new SqlParameter { ParameterName = "@FileName", Value = FileName };
                collSP[2] = new SqlParameter { ParameterName = "@FileID", Value = FileID };
                SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcUpdateEmployeePicture", CommandType.StoredProcedure, collSP);
                return new ResultDTO() { ID = EmployeeID, Status = true, Message = "Employee Picture Updated" };
            }
            catch (Exception e)
            {
                return new ResultDTO() { ID = EmployeeID, Status = false, Message = e.Message };
            }
        }
        ///////////////////-------------------------------------------------


        public async Task<DataTable> EmployeeWarningList(EmployeeWarningDTO dTO)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@EmployeeID", Value = dTO.EmployeeID };
                collSP[1] = new SqlParameter { ParameterName = "@StartDate", Value = dTO.StartDate };
                collSP[2] = new SqlParameter { ParameterName = "@EndDate", Value = dTO.EndDate };
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeWarningList", CommandType.StoredProcedure, collSP);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<DataTable> EmployeeWarningDetail(int ID)
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcWarningDetail", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<int> UpdateEmployeeWarning(EmployeeWarning dTO)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[23];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = dTO.ID };
                collSP[1] = new SqlParameter { ParameterName = "@EmployeeID", Value = dTO.EmployeeID };
                collSP[2] = new SqlParameter { ParameterName = "@WarningDate", Value = dTO.WarningDate };
                collSP[3] = new SqlParameter { ParameterName = "@WarningType", Value = dTO.WarningType };

                collSP[4] = new SqlParameter { ParameterName = "@Written", Value = dTO.Written };
                collSP[5] = new SqlParameter { ParameterName = "@Tardiness", Value = dTO.Tardiness };
                collSP[6] = new SqlParameter { ParameterName = "@Absenteeism", Value = dTO.Absenteeism };
                collSP[7] = new SqlParameter { ParameterName = "@Violation", Value = dTO.Violation };
                collSP[8] = new SqlParameter { ParameterName = "@Substandard", Value = dTO.Substandard };
                collSP[9] = new SqlParameter { ParameterName = "@Policies", Value = dTO.Policies };
                collSP[10] = new SqlParameter { ParameterName = "@Rudeness", Value = dTO.Rudeness };
                collSP[11] = new SqlParameter { ParameterName = "@Other", Value = dTO.Other };
                collSP[12] = new SqlParameter { ParameterName = "@OtherDetail", Value = dTO.OtherDetail };
                collSP[13] = new SqlParameter { ParameterName = "@Infraction", Value = dTO.Infraction };
                collSP[14] = new SqlParameter { ParameterName = "@Improvement", Value = dTO.Improvement };
                collSP[15] = new SqlParameter { ParameterName = "@Consequences", Value = dTO.Consequences };

                collSP[16] = new SqlParameter { ParameterName = "@DivisionID1", Value = dTO.ApprovalDivisionID1 };
                collSP[17] = new SqlParameter { ParameterName = "@DivisionID2", Value = dTO.ApprovalDivisionID2 };
                collSP[18] = new SqlParameter { ParameterName = "@DivisionID3", Value = dTO.ApprovalDivisionID3 };

                collSP[19] = new SqlParameter { ParameterName = "@FileName", Value = dTO.FileName };
                collSP[20] = new SqlParameter { ParameterName = "@FileID", Value = dTO.FileID };
                collSP[21] = new SqlParameter { ParameterName = "@PreparedBy", Value = dTO.RecordAddedBy };
                collSP[22] = new SqlParameter { ParameterName = "@RecordCreatedBy", Value = dTO.RecordCreatedBy };

                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcUpdateEmployeeWarning", CommandType.StoredProcedure, collSP);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        ///////////////////-------------------------------------------------


        public async Task<EmployeeClearanceDB> EmployeeClearanceList(int EmployeeID)
        {
            try
            {

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeClearanceList", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID });
                EmployeeClearanceDB model = new EmployeeClearanceDB();
                model.Clearance.Load(result);
                model.Approvals.Load(result);
                model.Assets.Load(result);
                result.Close();
                return model;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<int> UpdateEmployeeClearance(EmployeeClearance dTO)
        {
            try
            {
                StringBuilder Assets = new StringBuilder();
                StringBuilder Approvals = new StringBuilder();
                Assets.AppendLine("<NewDataSet>");
                if (dTO.Assets != null && dTO.Assets.Count > 0)
                {
                    foreach (ClearanceAsset a in dTO.Assets)
                    {
                        Assets.AppendLine($"<Table1><AssetID>{a.AssetID}</AssetID></Table1>");
                    }
                }
                Assets.AppendLine("</NewDataSet>");

                Approvals.AppendLine("<NewDataSet>");
                if (dTO.Approvals != null && dTO.Approvals.Count > 0)
                {
                    foreach (EmployeeApproval a in dTO.Approvals)
                    {
                        Approvals.AppendLine($"<Table1><DivisionID>{a.DivisionID}</DivisionID></Table1>");
                    }
                }
                Approvals.AppendLine("</NewDataSet>");

                SqlParameter[] collSP = new SqlParameter[10];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = dTO.ID };
                collSP[1] = new SqlParameter { ParameterName = "@EmployeeID", Value = dTO.EmployeeID };
                collSP[2] = new SqlParameter { ParameterName = "@ClearanceDate", Value = dTO.ClearanceDate };
                collSP[3] = new SqlParameter { ParameterName = "@ContactNumber", Value = dTO.ContactNumber };

                collSP[4] = new SqlParameter { ParameterName = "@Handover", Value = dTO.Handover };
                collSP[5] = new SqlParameter { ParameterName = "@LastWorkingDate", Value = dTO.LastWorkingDate };
                collSP[6] = new SqlParameter { ParameterName = "@Preparedby", Value = dTO.Preparedby };
                collSP[7] = new SqlParameter { ParameterName = "@Assets", Value = Assets.ToString() };
                collSP[8] = new SqlParameter { ParameterName = "@Approvals", Value = Approvals.ToString() };
                collSP[9] = new SqlParameter { ParameterName = "@RecordCreatedBy", Value = dTO.RecordCreatedBy };

                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcUpdateEmployeeClearance", CommandType.StoredProcedure, collSP);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        ///////////////////-------------------------------------------------
        public async Task<EmployeeVacationDB> EmployeeVacationList(EmployeeVacationParam param)
        {
            try
            {

                SqlParameter[] collSP = new SqlParameter[4];
                collSP[0] = new SqlParameter { ParameterName = "@EmployeeID", Value = param.EmployeeID };
                collSP[1] = new SqlParameter { ParameterName = "@StartDate", Value = param.StartDate };
                collSP[2] = new SqlParameter { ParameterName = "@EndDate", Value = param.EndDate };
                collSP[3] = new SqlParameter { ParameterName = "@Emergency", Value = param.EmergencyOnly };

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeVacationList", CommandType.StoredProcedure, collSP);
                EmployeeVacationDB model = new EmployeeVacationDB();
                model.Vacation.Load(result);
                model.Approvals.Load(result);
                model.Assets.Load(result);
                result.Close();
                return model;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<int> UpdateEmployeeVacation(EmployeeVacation dTO)
        {
            try
            {
                StringBuilder Assets = new StringBuilder();
                StringBuilder Approvals = new StringBuilder();
                Assets.AppendLine("<NewDataSet>");
                if (dTO.Assets != null && dTO.Assets.Count > 0)
                {
                    foreach (VacationAsset a in dTO.Assets)
                    {
                        Assets.AppendLine($"<Table1><AssetID>{a.AssetID}</AssetID></Table1>");
                    }
                }
                Assets.AppendLine("</NewDataSet>");

                Approvals.AppendLine("<NewDataSet>");
                if (dTO.Approvals != null && dTO.Approvals.Count > 0)
                {
                    foreach (EmployeeApproval a in dTO.Approvals)
                    {
                        Approvals.AppendLine($"<Table1><DivisionID>{a.DivisionID}</DivisionID></Table1>");
                    }
                }
                Approvals.AppendLine("</NewDataSet>");

                SqlParameter[] parameters = new SqlParameter[28];
                parameters[0] = new SqlParameter { ParameterName = "@ID", Value = dTO.ID };
                parameters[1] = new SqlParameter { ParameterName = "@EmployeeID", Value = dTO.EmployeeID };
                parameters[2] = new SqlParameter { ParameterName = "@RecordDate", Value = dTO.RecordDate };
                parameters[3] = new SqlParameter { ParameterName = "@WithPay", Value = dTO.WithPay };
                parameters[4] = new SqlParameter { ParameterName = "@WithoutPay", Value = dTO.WithOutPay };
                parameters[5] = new SqlParameter { ParameterName = "@Approved", Value = dTO.Approved };
                parameters[6] = new SqlParameter { ParameterName = "@Destination", Value = dTO.Destination };
                parameters[7] = new SqlParameter { ParameterName = "@DepartDate", Value = dTO.DepartDate };
                parameters[8] = new SqlParameter { ParameterName = "@ReturnDate", Value = dTO.ReturnDate };
                parameters[9] = new SqlParameter { ParameterName = "@Dues", Value = dTO.Dues };
                parameters[10] = new SqlParameter { ParameterName = "@Duration", Value = dTO.Duration };
                parameters[11] = new SqlParameter { ParameterName = "@MonthsEarly", Value = dTO.MonthsEarly };
                parameters[12] = new SqlParameter { ParameterName = "@Reason", Value = dTO.Reason };
                parameters[13] = new SqlParameter { ParameterName = "@Remarks", Value = dTO.Remarks };
                parameters[14] = new SqlParameter { ParameterName = "@Emergency", Value = dTO.Emergency };
                parameters[15] = new SqlParameter { ParameterName = "@VacationDue", Value = dTO.VacationDue };
                parameters[16] = new SqlParameter { ParameterName = "@TravelOrder", Value = dTO.TravelOrder };
                parameters[17] = new SqlParameter { ParameterName = "@Ticket", Value = dTO.Ticket };
                parameters[18] = new SqlParameter { ParameterName = "@IqamaRenewal", Value = dTO.IqamaRenewal };
                parameters[19] = new SqlParameter { ParameterName = "@EntryExitVisa", Value = dTO.EntryExitVisa };
                parameters[20] = new SqlParameter { ParameterName = "@Contact", Value = dTO.Contact };
                parameters[21] = new SqlParameter { ParameterName = "@HandOver", Value = dTO.HandOver };
                parameters[22] = new SqlParameter { ParameterName = "@LastWorkingDate", Value = dTO.LastWorkingDate };
                parameters[23] = new SqlParameter { ParameterName = "@FinalDepartDate", Value = dTO.FinalDepartDate };
                parameters[24] = new SqlParameter { ParameterName = "@PreparedBy", Value = dTO.PreparedBy };
                parameters[25] = new SqlParameter { ParameterName = "@RecordCreatedBy", Value = dTO.RecordCreatedBy };
                parameters[26] = new SqlParameter { ParameterName = "@Assets", Value = Assets.ToString() };
                parameters[27] = new SqlParameter { ParameterName = "@Approvals", Value = Approvals.ToString() };





                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcUpdateEmployeeVacation", CommandType.StoredProcedure, parameters);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public async Task<bool> DeleteEmployeeVacation(int ID, int UserID)
        {
            try
            {

                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = ID };
                collSP[1] = new SqlParameter { ParameterName = "@UserID", Value = UserID };


                await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcDeleteEmployeeVacation", CommandType.StoredProcedure, collSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        ///////////////////-------------------------------------------------


        public async Task<EmployeeInquiryDB> EmployeeInquiryList(EmployeeInquiryParam param)
        {
            try
            {

                SqlParameter[] collSP = new SqlParameter[12];
                collSP[0] = new SqlParameter { ParameterName = "@EmployeeID", Value = param.EmployeeID };
                collSP[1] = new SqlParameter { ParameterName = "@StartDate", Value = param.StartDate };
                collSP[2] = new SqlParameter { ParameterName = "@EndDate", Value = param.EndDate };
                collSP[3] = new SqlParameter { ParameterName = "@Personal", Value = param.PersonalInquiry };
                collSP[4] = new SqlParameter { ParameterName = "@General", Value = param.GeneralInquiry };
                collSP[5] = new SqlParameter { ParameterName = "@Loan", Value = param.LoanInquiry };
                collSP[6] = new SqlParameter { ParameterName = "@PageNumber", Value = param.PageNumber };
                collSP[7] = new SqlParameter { ParameterName = "@PageSize", Value = param.pageSize };

                collSP[8] = new SqlParameter { ParameterName = "@SalaryCertificate", Value = param.SalaryCertificate };
                collSP[9] = new SqlParameter { ParameterName = "@MissPunch", Value = param.MissPunch };
                collSP[10] = new SqlParameter { ParameterName = "@Resignation", Value = param.Resignation };
                collSP[11] = new SqlParameter { ParameterName = "@UserID", Value = param.UserID };

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeInquiryList", CommandType.StoredProcedure, collSP);
                EmployeeInquiryDB model = new EmployeeInquiryDB();
                model.Inquiry.Load(result);
                result.Close();
                return model;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<EmployeeInquiryDB> EmployeeInquiryDetail(int ID)
        {
            try
            {

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeInquiryDetail", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                EmployeeInquiryDB model = new EmployeeInquiryDB();
                model.Inquiry.Load(result);
                model.Approvals.Load(result);
                result.Close();
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<DataTable> EmployeeInquiryReportDetail(int ID)
        {

            var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeInquiryReport", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
            EmployeeInquiryDB model = new EmployeeInquiryDB();
            model.Inquiry.Load(result);
            return model.Inquiry;

        }
        public async Task<int> UpdateEmployeeInquiry(EmployeeInquiry dTO)
        {
            try
            {
                StringBuilder Approvals = new StringBuilder();

                Approvals.AppendLine("<NewDataSet>");
                if (dTO.Approvals != null && dTO.Approvals.Count > 0)
                {
                    foreach (EmployeeApproval a in dTO.Approvals)
                    {
                        
                        Approvals.AppendLine($"<Table1><DivisionID>{a.DivisionID}</DivisionID></Table1>");
                    }
                }
                Approvals.AppendLine("</NewDataSet>");

                SqlParameter[] collSP = new SqlParameter[16];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = dTO.ID };
                collSP[1] = new SqlParameter { ParameterName = "@EmployeeID", Value = dTO.EmployeeID };
                collSP[2] = new SqlParameter { ParameterName = "@InquiryDate", Value = dTO.InquiryDate };
                collSP[3] = new SqlParameter { ParameterName = "@Remarks", Value = dTO.Remarks };
                collSP[4] = new SqlParameter { ParameterName = "@PersonalInquiry", Value = dTO.PersonalInquiry };
                collSP[5] = new SqlParameter { ParameterName = "@GeneralInquiry", Value = dTO.GeneralInquiry };
                collSP[6] = new SqlParameter { ParameterName = "@LoanInquiry", Value = dTO.LoanInquiry };
                collSP[7] = new SqlParameter { ParameterName = "@Preparedby", Value = dTO.Preparedby };
                collSP[8] = new SqlParameter { ParameterName = "@UserName", Value = dTO.UserName };
                collSP[9] = new SqlParameter { ParameterName = "@RecordCreatedBy", Value = dTO.RecordCreatedBy };
                collSP[10] = new SqlParameter { ParameterName = "@PriorityLevelID", Value = dTO.PriorityLevelID };
                collSP[11] = new SqlParameter { ParameterName = "@Approvals", Value = Approvals.ToString() };

                collSP[12] = new SqlParameter { ParameterName = "@Resignation", Value = dTO.Resignation };
                collSP[13] = new SqlParameter { ParameterName = "@SalaryCertificate", Value = dTO.SalaryCertificate };
                collSP[14] = new SqlParameter { ParameterName = "@MissPunch", Value = dTO.MissPunch };
                collSP[15] = new SqlParameter { ParameterName = "@LastWorkingDate", Value = dTO.LastWorkingDate };

                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcUpdateEmployeeInquiry", CommandType.StoredProcedure, collSP);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public async Task<bool> UpdateEmployeeInquiryFile(int ID, string FileName, string FileID)
        {

            SqlParameter[] collSP = new SqlParameter[3];
            collSP[0] = new SqlParameter { ParameterName = "@ID", Value = ID };
            collSP[1] = new SqlParameter { ParameterName = "@FileName", Value = FileName };
            collSP[2] = new SqlParameter { ParameterName = "@FileID", Value = FileID };
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcUpdateEmployeeInquiryFile", CommandType.StoredProcedure, collSP);
            return true;
        }

        public async Task<DataTable> Supervisors()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcSupervisors", CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<DataTable> ApprovalList(int ID, bool Declined)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@EmployeeID", Value = ID };
                collSP[1] = new SqlParameter { ParameterName = "@Declined", Value = Declined };

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcApprovalList", CommandType.StoredProcedure, collSP);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<ApprovalRequestResultDB> ApproveRequest(int SupervisorID, PendingApproval p)
        {
            SqlParameter[] collSP = new SqlParameter[3];

            collSP = new SqlParameter[5];
            collSP[0] = new SqlParameter { ParameterName = "@ID", Value = p.ID };
            collSP[1] = new SqlParameter { ParameterName = "@Remarks", Value = p.Remarks };
            collSP[2] = new SqlParameter { ParameterName = "@ApprovalStatus", Value = (int)p.Status };
            collSP[3] = new SqlParameter { ParameterName = "@SupervisorID", Value = SupervisorID };
            collSP[4] = new SqlParameter { ParameterName = "@Status", Value = 0, DbType = DbType.Int16, Direction = ParameterDirection.ReturnValue };
            var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcUpdateEmployeeApprovalRequest", CommandType.StoredProcedure, collSP);
            ApprovalRequestResultDB model = new ApprovalRequestResultDB();
            model.Result = false;
            DataTable status = new DataTable();
            status.Load(result);
            if (status.Rows.Count > 0)
            {
                model.Result = Convert.ToBoolean(status.Rows[0]["Status"]);
                if (model.Result)
                {
                    model.Request.Load(result);
                    model.Employees.Load(result);
                    model.EmailTemplate.Load(result);
                }
            }



            return model;
        }

        public async Task<ApprovalRequestResultDB> GetApproveRequestDetail(int ID)
        {
            SqlParameter[] collSP = new SqlParameter[3];

            collSP = new SqlParameter[2];
            collSP[0] = new SqlParameter { ParameterName = "@ID", Value = ID };

            collSP[1] = new SqlParameter { ParameterName = "@Status", Value = 0, DbType = DbType.Int16, Direction = ParameterDirection.ReturnValue };
            var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetEmployeeApprovalRequestDetail", CommandType.StoredProcedure, collSP);
            ApprovalRequestResultDB model = new ApprovalRequestResultDB();
            model.Result = false;
            DataTable status = new DataTable();
            status.Load(result);
            if (status.Rows.Count > 0)
            {
                model.Result = Convert.ToBoolean(status.Rows[0]["Status"]);
                if (model.Result)
                {
                    model.Request.Load(result);
                    model.Employees.Load(result);
                    model.EmailTemplate.Load(result);
                }
            }



            return model;
        }
        public async Task<bool> UpdateRequestStatus(int ID, ApprovalTypes type, ApprovalStatus status)
        {
            SqlParameter[] collSP = new SqlParameter[3];


            collSP[0] = new SqlParameter { ParameterName = "@ID", Value = ID };
            collSP[1] = new SqlParameter { ParameterName = "@Type", Value = (int)type };
            collSP[2] = new SqlParameter { ParameterName = "@ApprovalStatus", Value = (int)status };
            SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcUpdateEmployeeRequestStatus", CommandType.StoredProcedure, collSP);
            return true;

        }
        public async Task<DataTable> VendorList()
        {
            try
            {

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeVendorList", CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<int> UpdateVendor(Vendor dTO)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[22];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = dTO.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = dTO.Name };
                collSP[2] = new SqlParameter { ParameterName = "@CSR", Value = dTO.CSR };
                collSP[3] = new SqlParameter { ParameterName = "@Contact", Value = dTO.Contact };
                collSP[4] = new SqlParameter { ParameterName = "@EmergencyContact", Value = dTO.EmergencyContact };
                collSP[5] = new SqlParameter { ParameterName = "@Address", Value = dTO.Address };
                collSP[6] = new SqlParameter { ParameterName = "@EmailAddress", Value = dTO.EmailAddress };
                collSP[7] = new SqlParameter { ParameterName = "@WorkScope", Value = dTO.WorkScope };
                collSP[8] = new SqlParameter { ParameterName = "@HourlyPrice", Value = dTO.HourlyPrice };
                collSP[9] = new SqlParameter { ParameterName = "@WorkHours", Value = dTO.WorkHours };
                collSP[10] = new SqlParameter { ParameterName = "@OverTimeHourlyPrice", Value = dTO.OverTimeHourlyPrice };
                collSP[11] = new SqlParameter { ParameterName = "@MinWorkHours", Value = dTO.MinWorkHours };
                collSP[12] = new SqlParameter { ParameterName = "@Accommodation", Value = dTO.Accommodation };
                collSP[13] = new SqlParameter { ParameterName = "@Food", Value = dTO.Food };
                collSP[14] = new SqlParameter { ParameterName = "@Transport", Value = dTO.Transport };
                collSP[15] = new SqlParameter { ParameterName = "@AjeerProvided", Value = dTO.AjeerProvided };
                collSP[16] = new SqlParameter { ParameterName = "@AjeerType", Value = dTO.AjeerType };
                collSP[17] = new SqlParameter { ParameterName = "@AjeerSaudization", Value = dTO.AjeerSaudization };
                collSP[18] = new SqlParameter { ParameterName = "@PWSCR", Value =   dTO.PWSCR };
                collSP[19] = new SqlParameter { ParameterName = "@Remarks", Value = dTO.Remarks };
                collSP[20] = new SqlParameter { ParameterName = "@RecordAddedBy", Value = dTO.RecordAddedBy };
                collSP[21] = new SqlParameter { ParameterName = "@ContractNumber", Value = dTO.ContractNumber };

                return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "ProcUpdateEmployeeVendor", CommandType.StoredProcedure, collSP);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public async Task<DataTable> UpdateSponsor(SponsorCompany dTO)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = dTO.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = dTO.Name };
                collSP[2] = new SqlParameter { ParameterName = "@CRNumber", Value = dTO.CRNumber };

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcUpdateSponsorList", CommandType.StoredProcedure, collSP);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<bool> UpdateLocation(Location dto)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = dto.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = dto.Name };
                SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcAdddUpdateLocation", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /////////////////////////////////////////////////////////////////

        public async Task<EmployeeJoiningDB> EmployeeJoining(DateParam param)
        {
            try
            {

                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@EmployeeID", Value = param.EmployeeID };
                collSP[1] = new SqlParameter { ParameterName = "@StartDate", Value = param.StartDate.ToString("MM/dd/yyyy") };
                collSP[2] = new SqlParameter { ParameterName = "@EndDate", Value = param.EndDate.ToString("MM/dd/yyyy") };
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeJoiningList", CommandType.StoredProcedure, collSP);
                EmployeeJoiningDB dt = new EmployeeJoiningDB();
                dt.Joining.Load(result);
                dt.Approvals.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }


        public async Task<int> UpdateEmployeeJoining(EmployeeJoining record)
        {
            try
            {
                StringBuilder Approvals = new StringBuilder();
                Approvals.AppendLine("<NewDataSet>");
                if (record.Approvals != null && record.Approvals.Count > 0)
                {
                    foreach (EmployeeApproval a in record.Approvals)
                    {
                        Approvals.AppendLine($"<Table1><DivisionID>{a.DivisionID}</DivisionID></Table1>");
                    }
                }
                Approvals.AppendLine("</NewDataSet>");


                SqlParameter[] parameters = new SqlParameter[10];
                parameters[0] = new SqlParameter { ParameterName = "@ID", Value = record.ID };
                parameters[1] = new SqlParameter { ParameterName = "@EmployeeID", Value = record.EmployeeID };
                parameters[2] = new SqlParameter { ParameterName = "@RecordDate", Value = record.RecordDate };
                parameters[3] = new SqlParameter { ParameterName = "@LastDepartDate", Value = record.LastDepartDate };
                parameters[4] = new SqlParameter { ParameterName = "@JoiningDate", Value = record.JoiningDate };
                parameters[5] = new SqlParameter { ParameterName = "@NextDepartDate", Value = record.NextDepartDate };
                parameters[6] = new SqlParameter { ParameterName = "@Remarks", Value = record.Remarks };
                parameters[7] = new SqlParameter { ParameterName = "@PreparedBy", Value = record.PreparedBy };
                parameters[8] = new SqlParameter { ParameterName = "@RecordCreatedBy", Value = record.RecordCreatedBy };
                parameters[9] = new SqlParameter { ParameterName = "@Approvals", Value = Approvals.ToString() };



                return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "ProcUpdateEmployeeJoining", CommandType.StoredProcedure, parameters);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public async Task<ResultDTO> UpdateEmployeeJoiningSheet(int EmployeeID, string FileName, string FileID)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = EmployeeID };
                collSP[1] = new SqlParameter { ParameterName = "@FileName", Value = FileName };
                collSP[2] = new SqlParameter { ParameterName = "@FileID", Value = FileID };
                SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcUpdateEmployeeJoiningSheet", CommandType.StoredProcedure, collSP);
                return new ResultDTO() { ID = EmployeeID, Status = true, Message = "Employee Joining Sheet Updated" };
            }
            catch (Exception e)
            {
                return new ResultDTO() { ID = EmployeeID, Status = false, Message = e.Message };
            }
        }


        public async Task<bool> DeleteEmployeeJoining(int ID, int EmployeeID)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = ID };
                collSP[1] = new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID };
                SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcRemoveEmployeeJoining", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /////////////////////////////////////////////////////////////////

        public async Task<EmployeeJoiningDB> EmployeeShortLeaves(DateParam param)
        {
            try
            {

                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@EmployeeID", Value = param.EmployeeID };
                collSP[1] = new SqlParameter { ParameterName = "@StartDate", Value = (param.StartDate.Year == 1 ? "" : param.StartDate.ToString("MM/dd/yyyy")) };
                collSP[2] = new SqlParameter { ParameterName = "@EndDate", Value = (param.EndDate.Year == 1 ? "" : param.EndDate.ToString("MM/dd/yyyy")) };
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeShortLeaveList", CommandType.StoredProcedure, collSP);
                EmployeeJoiningDB dt = new EmployeeJoiningDB();
                dt.Joining.Load(result);
                dt.Approvals.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }


        public async Task<int> UpdateEmployeeShortLeave(EmployeeShortLeave record)
        {
            try
            {
                StringBuilder Approvals = new StringBuilder();
                Approvals.AppendLine("<NewDataSet>");
                if (record.Approvals != null && record.Approvals.Count > 0)
                {
                    foreach (EmployeeApproval a in record.Approvals)
                    {
                        Approvals.AppendLine($"<Table1><DivisionID>{a.DivisionID}</DivisionID></Table1>");
                    }
                }
                Approvals.AppendLine("</NewDataSet>");


                SqlParameter[] parameters = new SqlParameter[6];
                parameters[0] = new SqlParameter { ParameterName = "@ID", Value = record.ID };
                parameters[1] = new SqlParameter { ParameterName = "@EmployeeID", Value = record.EmployeeID };
                parameters[2] = new SqlParameter { ParameterName = "@RecordDate", Value = Convert.ToDateTime(record.RecordDate.ToShortDateString() + " " + record.LeaveTime) };
                parameters[3] = new SqlParameter { ParameterName = "@Remarks", Value = record.Remarks };
                parameters[4] = new SqlParameter { ParameterName = "@RecordCreatedBy", Value = record.RecordCreatedBy };
                parameters[5] = new SqlParameter { ParameterName = "@Approvals", Value = Approvals.ToString() };

                return (int)SqlHelper.ExecuteScalar(this.ConnectionString, "ProcUpdateEmployeeShortLeave", CommandType.StoredProcedure, parameters);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public async Task<ResultDTO> UpdateEmployeeShortLeaveSheet(int EmployeeID, string FileName, string FileID)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = EmployeeID };
                collSP[1] = new SqlParameter { ParameterName = "@FileName", Value = FileName };
                collSP[2] = new SqlParameter { ParameterName = "@FileID", Value = FileID };
                SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcUpdateEmployeeShortLeaveSheet", CommandType.StoredProcedure, collSP);
                return new ResultDTO() { ID = EmployeeID, Status = true, Message = "Employee Short Leave Sheet Updated" };
            }
            catch (Exception e)
            {
                return new ResultDTO() { ID = EmployeeID, Status = false, Message = e.Message };
            }
        }

        public async Task<bool> DeleteEmployeeShortLeave(int ID, int EmployeeID)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = ID };
                collSP[1] = new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID };
                SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcRemoveEmployeeShortLeave", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<DataTable> EmployeeLeaveRequest(DateParam param)
        {

            SqlParameter[] collSP = new SqlParameter[3];
            collSP[0] = new SqlParameter { ParameterName = "@EmployeeID", Value = param.EmployeeID };
            collSP[1] = new SqlParameter { ParameterName = "@StartDate", Value = (param.StartDate.Year == 1 ? "" : param.StartDate.ToString("MM/dd/yyyy")) };
            collSP[2] = new SqlParameter { ParameterName = "@EndDate", Value = (param.EndDate.Year == 1 ? "" : param.EndDate.ToString("MM/dd/yyyy")) };

            var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeLeaveRequests", CommandType.StoredProcedure, collSP);
            DataTable data = new DataTable();
            data.Load(result);
            return data;
        }
        public async Task<DataTable> EmployeeLeaveStats(int EmployeeID)
        {

            var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcCalculateEmployeeAnnualLeaves", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID });
            DataTable data = new DataTable();
            data.Load(result);
            return data;
        }
        public async Task<ApprovalRequestResultDB> NewLeaveRequest(EmployeeLeave record)
        {


            SqlParameter[] parameters = new SqlParameter[10];
            parameters[0] = new SqlParameter { ParameterName = "@ID", Value = 0, Direction = ParameterDirection.InputOutput };
            parameters[1] = new SqlParameter { ParameterName = "@EmployeeID", Value = record.EmployeeID };
            parameters[2] = new SqlParameter { ParameterName = "@StartDate", Value = record.StartDate };
            parameters[3] = new SqlParameter { ParameterName = "@EndDate", Value = record.EndDate };
            parameters[4] = new SqlParameter { ParameterName = "@LeaveType", Value = record.LeaveType };
            parameters[5] = new SqlParameter { ParameterName = "@Remarks", Value = StringHelper.NullToString(record.Remarks) };
            parameters[6] = new SqlParameter { ParameterName = "@RecordCreatedBy", Value = record.RecordCreatedBy };
            parameters[7] = new SqlParameter { ParameterName = "@Status", Value = 0, Direction = ParameterDirection.InputOutput };
            parameters[8] = new SqlParameter { ParameterName = "@PriorityLevelID", Value = record.PriorityLevelID };
            parameters[9] = new SqlParameter { ParameterName = "@NeedTicket", Value = record.NeedTicket };



            var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcAddNewLeaveRequest", CommandType.StoredProcedure, parameters);
            ApprovalRequestResultDB model = new ApprovalRequestResultDB();

            model.Result = true;
            model.ID = Convert.ToInt32(parameters[7].Value);
            model.Employees.Load(result);
            model.EmailTemplate.Load(result);
            model.Status.Load(result);
            if (model.Status.Rows.Count > 0)
            {
                model.Result = Convert.ToBoolean(model.Status.Rows[0]["Status"]);
                model.ID = Convert.ToInt32(model.Status.Rows[0]["ID"]);
            }

            return model;
        }
        public async Task<EmployeeLeaveNotificationSQL> GetLeaveNotificationRequest()
        {


            var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetEmployeeVactionNotificationData", CommandType.StoredProcedure);
            EmployeeLeaveNotificationSQL data = new EmployeeLeaveNotificationSQL();
            data.Leaves.Load(result);
            data.HRManager.Load(result);
            data.EmailTemplate.Load(result);
            return data;
        }
        public async Task<bool> MarkLeaveNotificationRequestSent(int LeaveID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcUpdateEmployeeLeaveNotificationSent", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = LeaveID });
                return true;
            }catch (Exception e)
            {
                return false;
            }
        }
        public async Task<ResultDTO> UpdateEmployeeLeaveSheet(int EmployeeID, string FileName, string FileID)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = EmployeeID };
                collSP[1] = new SqlParameter { ParameterName = "@FileName", Value = FileName };
                collSP[2] = new SqlParameter { ParameterName = "@FileID", Value = FileID };
                SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcUpdateEmployeeLeaveSheet", CommandType.StoredProcedure, collSP);
                return new ResultDTO() { ID = EmployeeID, Status = true, Message = "Employee Leave Sheet Updated" };
            }
            catch (Exception e)
            {
                return new ResultDTO() { ID = EmployeeID, Status = false, Message = e.Message };
            }
        }

        public async Task<DataTable> HRManager()
        {

            var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetHRManager", CommandType.StoredProcedure);
            DataTable data = new DataTable();
            data.Load(result);
            return data;
        }
        public async Task<DataTable> EmployeeWorkTimeList(int EmployeeID, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID };
                collSP[1] = new SqlParameter { ParameterName = "@StartDate", Value = StartDate };
                collSP[2] = new SqlParameter { ParameterName = "@EndDate", Value = EndDate };

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcListEmployeeWorkTimeSchedule", CommandType.StoredProcedure, collSP);
                DataTable model = new DataTable();
                model.Load(result);
                result.Close();
                return model;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<bool> UpdateEmployeeWorkSchedule(EmployeeWorkSchedule employeeWork)
        {
            try
            {

                SqlParameter[] collSP = new SqlParameter[9];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = employeeWork.ID };
                collSP[1] = new SqlParameter { ParameterName = "@FridayTime", Value = employeeWork.FridayTime };
                collSP[2] = new SqlParameter { ParameterName = "@SaturdayTime", Value = employeeWork.SaturdayTime };

                collSP[3] = new SqlParameter { ParameterName = "@SundayTime", Value = employeeWork.SundayTime };
                collSP[4] = new SqlParameter { ParameterName = "@MondayTime", Value = employeeWork.MondayTime };

                collSP[5] = new SqlParameter { ParameterName = "@TuesdayTime", Value = employeeWork.TuesdayTime };
                collSP[6] = new SqlParameter { ParameterName = "@WednesdayTime", Value = employeeWork.WednesdayTime };
                collSP[7] = new SqlParameter { ParameterName = "@ThursdayTime", Value = employeeWork.ThursdayTime };
                collSP[8] = new SqlParameter { ParameterName = "@EmployeeID", Value = employeeWork.EmployeeID };

                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcUpdateEmployeeWorkTimeSchedule", CommandType.StoredProcedure, collSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<DataTable> ExpiringIDData(ExpistingIDParam param)
        {

            SqlParameter[] collSP = new SqlParameter[3];
            collSP[0] = new SqlParameter { ParameterName = "@StartDate", Value = param.StartDate };
            collSP[1] = new SqlParameter { ParameterName = "@EndDate", Value = param.EndDate };
            collSP[2] = new SqlParameter { ParameterName = "@FileType", Value = param.FileType };

            var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeExpiringID", CommandType.StoredProcedure, collSP);
            DataTable data = new DataTable();
            data.Load(result);
            return data;
        }


        public async Task<DataTable> EmployeeAttendenceInOut(DateParam param)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@StartDate", Value = param.StartDate.ToString("MM/dd/yyyy") };
                collSP[1] = new SqlParameter { ParameterName = "@EndDate", Value = param.EndDate.ToString("MM/dd/yyyy") };
                collSP[2] = new SqlParameter { ParameterName = "@EmployeeID", Value = param.EmployeeID };

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeInOutActivity", CommandType.StoredProcedure, collSP);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<DataTable> EmployeeAttendenceDetail(DateParam param)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@StartDate", Value = param.StartDate.ToString("MM/dd/yyyy") };
                collSP[1] = new SqlParameter { ParameterName = "@EndDate", Value = param.EndDate.ToString("MM/dd/yyyy") };
                collSP[2] = new SqlParameter { ParameterName = "@EmployeeID", Value = param.EmployeeID };

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeAttendenceReport", CommandType.StoredProcedure, collSP);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<DataTable> EmployeeAttendenceSummary(DateParam param)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@StartDate", Value = param.StartDate.ToString("MM/dd/yyyy") };
                collSP[1] = new SqlParameter { ParameterName = "@EndDate", Value = param.EndDate.ToString("MM/dd/yyyy") };
                collSP[2] = new SqlParameter { ParameterName = "@EmployeeID", Value = param.EmployeeID };

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcEmployeeAttendenceReportSummary", CommandType.StoredProcedure, collSP);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<DataTable> EmployeeCVData(EmployeeCVParam param)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[7];
                collSP[0] = new SqlParameter { ParameterName = "@Name", Value = param.Name };
                collSP[1] = new SqlParameter { ParameterName = "@EmployeeNumber", Value = param.EmployeeNumber };
                collSP[2] = new SqlParameter { ParameterName = "@PassportNumber", Value = param.PassportNumber };
                collSP[3] = new SqlParameter { ParameterName = "@AramcoID", Value = param.EmployeeNumber };
                collSP[4] = new SqlParameter { ParameterName = "@Nationality", Value = param.Nationality };
                collSP[5] = new SqlParameter { ParameterName = "@PageNumber", Value = param.PageNumber };
                collSP[6] = new SqlParameter { ParameterName = "@PageSize", Value = param.pageSize };

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcListEmployeePersonalData", CommandType.StoredProcedure, collSP);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<PersonalDataSQL> EmployeeCVData(int ID)
        {
            try
            {
                
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetEmployeePersonalData", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                PersonalDataSQL dt = new PersonalDataSQL();
                dt.Detail.Load(result);
                dt.WorkExperience.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        

    }


}
