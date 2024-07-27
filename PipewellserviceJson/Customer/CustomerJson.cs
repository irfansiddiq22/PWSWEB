using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipewellserviceDB.Customer;
using PipewellserviceModels.Customer;

namespace PipewellserviceJson.Customer
{
    public class CustomerJson
    {
        CustomerService service = new CustomerService();
        public async Task<int> SaveRegistration(CustomerRegistrationDTO dto)
        {
            return await service.SaveRegistration(dto);
        }
        public async Task<bool> SaveRegistrationFiles(int ID, RegistrationFile assesmentFile)
        {
            return await service.SaveRegistrationFiles(ID, assesmentFile);

        }

        public async Task<List<CustomerList>> CustomerList(CustomerViewParam param)
        {
            return  await JsonHelper.Convert<List<CustomerList>,DataTable>(await service.CustomerList(param));
        }
    }
}
