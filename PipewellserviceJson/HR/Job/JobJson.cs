using PipewellserviceDB.HR;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Job;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.HR.Job
{
    public class JobJson
    {
        JobService service = new JobService();
        public async Task<List<JobOffer>> JobOfferList()
        {
            var Data = await service.JobOfferList();
            List<JobOffer> result = await JsonHelper.Convert<List<JobOffer>, DataTable>(Data);
            return result;
        }

        public async Task<bool> DeleteJobOffer(DeleteDTO delete)
        {
            return await service.DeleteJobOffer(delete);
        }
        public async Task<int> UpdateJobOffer(JobOffer job)
        {
            return await service.UpdateJobOffer(job);
        }

        public async Task<List<JobContract>> JobContractList()
        {
            var Data = await service.JobContractList();
            List<JobContract> result = await JsonHelper.Convert<List<JobContract>, DataTable>(Data);
            return result;
        }

        public async Task<bool> DeleteJobContract(DeleteDTO delete)
        {
            return await service.DeleteJobContract(delete);
        }
        public async Task<int> UpdateJobContract(JobContract  job)
        {
            return await service.UpdateJobContract(job);
        }

    }
}
