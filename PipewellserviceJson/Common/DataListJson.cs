using PipewellserviceDB.Common;
using PipewellserviceModels.HR.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.Common
{
   public class DataListJson
    {

        DataListService service = new DataListService();
        public async Task<List<Country>> CountryList()
        {
            var Data = await service.CountryList();
            return await JsonHelper.Convert<List<Country>, DataTable>(Data);
        }

    }
}
