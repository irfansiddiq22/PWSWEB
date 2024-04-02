using PipewellserviceModels.Common;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB.Auth
{
    public class AuthService:DataServices
    {
        public async Task<bool> ProcessLogin(UserAuth user)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@UserName", Value = user.UserName };
                collSP[1] = new SqlParameter { ParameterName = "@Password", Value = user.Password };
                var result =  SqlHelper.ExecuteScalar(this.ConnectionString, "ProcProcessLogin", CommandType.StoredProcedure, collSP);
                
                return Convert.ToInt16(result)==1;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
