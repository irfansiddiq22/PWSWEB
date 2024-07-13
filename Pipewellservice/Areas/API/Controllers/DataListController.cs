using Pipewellservice.App_Start;
using PipewellserviceJson.Common;
using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Areas.API.Controllers
{
    public class DataListController : Controller
    {
        DataListJson json = new DataListJson();
        public async Task<JsonResult> CertificeTypes()
        {
            return new JsonResult
            {
                Data = AppData.Constants.FindAll(x => x.ParentID == (int)ParentEnums.CERTIFICATE_TYPES),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> CountryList()
        {
            return new JsonResult
            {
                Data = await json.CountryList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        /// <summary>
        /// with division
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> Supervisors()
        {
            return new JsonResult
            {
                Data = await json.Supervisors(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        /*

        /// <summary>
        /// With/With out dision
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> SupervisorList()
        {
            return new JsonResult
            {
                Data = await json.SupervisorList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        */

        public async Task<JsonResult> SponsorList()
        {
            return new JsonResult
            {
                Data = await json.SponsorList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> LeaveTypes()
        {
            return new JsonResult
            {
                Data = AppData.Constants.FindAll(x => x.ParentID == (int)ParentEnums.LEAVE_TPES),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<JsonResult> JobStatus()
        {
            return new JsonResult
            {
                Data = AppData.Constants.FindAll(x => x.ParentID == (int)ParentEnums.JOB_STATUS),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<JsonResult> PriorityLevels()
        {
            return new JsonResult
            {
                Data = await json.PriorityLevels(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<JsonResult> ProcurementRequestType()
        {
            return new JsonResult
            {
                Data = AppData.Constants.FindAll(x => x.ParentID == (int)ParentEnums.MATERIAL_REQUEST_TYPES),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> SupplierList()
        {

            if (Session["Suppliers"] != null)
            {
                return new JsonResult
                {
                    Data = Session["Suppliers"],
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                var result = await json.SupplierList();
                Session["Suppliers"] = result;
                return new JsonResult
                {
                    Data = result,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

            
        }



    }
}