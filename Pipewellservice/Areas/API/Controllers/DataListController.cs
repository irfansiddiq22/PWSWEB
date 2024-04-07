using Pipewellservice.App_Start;
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

        public async Task<JsonResult> CertificeTypes()
        {
            return new JsonResult
            {
                Data = AppData.Constants.FindAll(x => x.ParentID == (int)ParentEnums.CERTIFICATE_TYPES),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

    }
}