using PipewellserviceModels.Common;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB
{
    public class DataServices
    {
        protected string ConnectionString { get; set; }
        public DataServices()
        {
            this.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public async Task<bool> LogUpdate(DataChangeLog dataChange)
        {
            
            try
            {
                if (dataChange.DataUpdated == null || dataChange.DataUpdated.Count == 0) return true;
                SqlParameter[] collSP = new SqlParameter[5];
                collSP[0] = new SqlParameter { ParameterName = "@UserName", Value = dataChange.UserName };
                collSP[1] = new SqlParameter { ParameterName = "@Form", Value = dataChange.Form };
                collSP[2] = new SqlParameter { ParameterName = "@RecordID", Value = dataChange.RecordID };
                collSP[3] = new SqlParameter { ParameterName = "@Activity", Value = dataChange.RecordID == 0 ?1:2 };
                collSP[4] = new SqlParameter { ParameterName = "@DataUpdated", Value = dataChange.Data };
                var result = await SqlHelper.ExecuteNonQueryAsync(this.ConnectionString, "ProcLogDataChange", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false; ;
            }

        }
        
    }
}

