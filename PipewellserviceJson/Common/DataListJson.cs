using PipewellserviceDB.Common;
using PipewellserviceModels.Account;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using PipewellserviceModels.HR.Settings;
using PipewellserviceModels.Setting;
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
        public async Task<List<Location>> LocationList()
        {
            DataTable result = await service.LocationList();
            return await JsonHelper.Convert<List<Location>, DataTable>(result);
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
       /* public async Task<List<Supervisor>> SupervisorList()
        {
            return await JsonHelper.Convert<List<Supervisor>, DataTable>(await service.SupervisorList());
        }*/
        public async Task<List<EmailTemplate>> EmplyeeRequestTemplates()
        {
            return await JsonHelper.Convert<List<EmailTemplate>, DataTable>(await service.EmployeeRequestEmailTemplates());
        }
        public async Task<List<EmailTemplate>> EmployeeShortLeaveRequestEmailTemplates()
        {
            return await JsonHelper.Convert<List<EmailTemplate>, DataTable>(await service.EmployeeShortLeaveRequestEmailTemplates());
        }

        public async Task<List<PriorityLevel>> PriorityLevels()
        {
            DataTable result = await service.PriorityLevels();
            return await JsonHelper.Convert<List<PriorityLevel>, DataTable>(result);
        }


        public async Task<List<Supplier>> SupplierList()
        {
            DataTable result = await service.SupplierList();
            return await JsonHelper.Convert<List<Supplier>, DataTable>(result);
        }

    }
}
