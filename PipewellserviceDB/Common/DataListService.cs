using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB.Common
{
    public class DataListService : DataServices
    {


        public async Task<DataTable> CountryList()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcCountryList", CommandType.StoredProcedure);
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
    }
}
