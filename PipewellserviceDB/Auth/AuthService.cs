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
        public async Task<UserAuthSQL> ProcessLogin(UserAuth user)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@UserName", Value = user.UserName };
                collSP[1] = new SqlParameter { ParameterName = "@Password", Value = user.Password };

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcProcessLogin", CommandType.StoredProcedure, collSP);
                UserAuthSQL model = new UserAuthSQL();
                model.User.Load(result);
                model.Permissions.Load(result);
                result.Close();

                
                return model;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
