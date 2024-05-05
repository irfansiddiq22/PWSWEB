using PipewellserviceDB.Common;
using PipewellserviceModels.HR.Employee;
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
        public async Task<List<SponsorCompany>> SponsorList()
        {
            DataTable result = await service.SponsorList();
            return await JsonHelper.Convert<List<SponsorCompany>, DataTable>(result);
        }
        public async Task<List<LeaveType>> LeaveTypes()
        {
            DataTable result = await service.LeaveTypes();
            return await JsonHelper.Convert<List<LeaveType>, DataTable>(result);
        }
        public async Task<List<Supervisor>> Supervisors()
        {
            return await JsonHelper.Convert<List<Supervisor>, DataTable>(await service.Supervisors());
        }
        public async Task<List<Supervisor>> SupervisorList()
        {
            return await JsonHelper.Convert<List<Supervisor>, DataTable>(await service.SupervisorList());
        }

        
    }
}
