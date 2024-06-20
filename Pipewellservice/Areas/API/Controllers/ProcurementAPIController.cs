using Pipewellservice.Helper;
using PipewellserviceJson.Procurement.Store;
using PipewellserviceModels.Common;
using PipewellserviceModels.Procurement.Store;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Areas.API.Controllers
{
    public class ProcurementAPIController : BaseController
    {
        private StoreItemJson itemJson = new StoreItemJson();
        public async Task<JsonResult> GetStoreItemUnit()
        {
            var result = await itemJson.GetStoreItemUnit();
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> GetStoreItemList(PagingDTO paging, string Name)
        {
            var result = await itemJson.GetStoreItemList(paging, Name);
            return new JsonResult
            {
                Data = new { Data = result, TotalRecord = result.Count > 0 ? result[0].Total : 0, NextCode= result.Count > 0 ? result[0].NextCode : 0 },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> AddStoreItem(Item item)
        {
            var result = await itemJson.AddStoreItem(item,SessionHelper.UserID());
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}