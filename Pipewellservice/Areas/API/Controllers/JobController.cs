using Pipewellservice.Helper;
using PipewellserviceJson.HR.Job;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Areas.API.Controllers
{
    public class JobController : BaseController
    {
        JobJson json = new JobJson();

        public async Task<JsonResult> JobOffers()
        {
            var result = await json.JobOfferList();
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> DeleteJobOffer(DeleteDTO delete)
        {
            return new JsonResult
            {
                Data = await json.DeleteJobOffer(delete),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> UpdateJobOffer(JobOffer job)
        {
            return new JsonResult
            {
                Data = await json.UpdateJobOffer(job),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        public async Task<JsonResult> JobContracts()
        {
            var result = await json.JobContractList();
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> DeleteJobContract(DeleteDTO delete)
        {
            return new JsonResult
            {
                Data = await json.DeleteJobContract(delete),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> UpdateJobContract(JobContract job)
        {
            return new JsonResult
            {
                Data = await json.UpdateJobContract(job),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}