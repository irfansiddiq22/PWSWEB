using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Job;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB.HR
{
    public class JobService:DataServices
    {

        public async Task<DataTable> JobOfferList()
        {

            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcListJobOffers", CommandType.StoredProcedure);
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
        public async Task<bool>DeleteJobOffer(DeleteDTO delete) 
        {
            
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = delete.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = delete.Name };
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcDeleteJobOffer", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public async Task<int> UpdateJobOffer(JobOffer job)
        {

            try
            {
                SqlParameter[] collSP = new SqlParameter[9];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = job.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = job.Name };
                collSP[2] = new SqlParameter { ParameterName = "@ArabicName", Value = job.ArabicName };
                collSP[3] = new SqlParameter { ParameterName = "@CountryID", Value = job.CountryID };
                collSP[4] = new SqlParameter { ParameterName = "@JobTitle", Value = job.JobTitle };
                collSP[5] = new SqlParameter { ParameterName = "@Basic", Value = job.Basic };

                collSP[6] = new SqlParameter { ParameterName = "@Transportation", Value = job.Transportation };
                collSP[7] = new SqlParameter { ParameterName = "@Period", Value = job.Period };
                collSP[8] = new SqlParameter { ParameterName = "@UserName", Value = job.UserName };

                var result =   SqlHelper.ExecuteScalar(this.ConnectionString, "ProcAddUpdateJobOffer", CommandType.StoredProcedure, collSP);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }

        }


        public async Task<DataTable> JobContractList()
        {

            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcListJobContracts", CommandType.StoredProcedure);
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
        public async Task<bool> DeleteJobContract(DeleteDTO delete)
        {

            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = delete.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = delete.Name };
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcDeleteJobContact", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public async Task<int> UpdateJobContract(JobContract job)
        {

            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter { ParameterName = "@ID", Value = job.ID },
                        new SqlParameter { ParameterName = "@Name", Value = job.Name },
                        new SqlParameter { ParameterName = "@ArabicName", Value = job.ArabicName },
                        new SqlParameter { ParameterName = "@CountryID", Value = job.CountryID },
                        new SqlParameter { ParameterName = "@JobTitle", Value = job.JobTitle },
                        new SqlParameter { ParameterName = "@IDNumber", Value = job.IDNumber },
                        new SqlParameter { ParameterName = "@EmailAddress", Value = job.EmailAddress },
                        new SqlParameter { ParameterName = "@MobileNumber", Value = job.MobileNumber },
                        new SqlParameter { ParameterName = "@Period", Value = job.Period },
                        new SqlParameter { ParameterName = "@Basic", Value = job.Basic },
                        new SqlParameter { ParameterName = "@Transportation", Value = job.Transportation },
                        new SqlParameter { ParameterName = "@UserName", Value = job.UserName },
                        
                    };

                var result =   SqlHelper.ExecuteScalar (this.ConnectionString, "ProcAddUpdateJobContract", CommandType.StoredProcedure, parameters);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
    }
}
