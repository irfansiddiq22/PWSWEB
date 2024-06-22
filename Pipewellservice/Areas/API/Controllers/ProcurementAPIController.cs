using Pipewellservice.Helper;
using PipewellserviceJson.HR.Employee;
using PipewellserviceJson.Procurement;
using PipewellserviceJson.Procurement.Store;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using PipewellserviceModels.Procurement;
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
        private ProcurementJson json = new ProcurementJson();
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
        public async Task<JsonResult> FindStoreItem(string Name)
        {
            var result = await itemJson.FindStoreItem(Name);
            return new JsonResult
            {
                Data = result,
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


        public async Task<JsonResult> GetMatrialRequestList(DateParam date, PagingDTO paging, int RequestType)
        {
            var result = await json.GetMatrialRequestList(date,paging, RequestType);
            return new JsonResult
            {
                Data = new { Data = result, TotalRecord = result.Count > 0 ? result[0].Total : 0},
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> GetMatrialRequestDetail(int ID)
        {
            var result = await json.GetMatrialRequestDetail(ID);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> AddMaterialRequest(MaterialRequest request,List<MaterialRequestItem> Items)
        {
            request.RecordCreatedBy = SessionHelper.EmployeeID();

            var result = await json.AddMaterialRequest(request, Items);
            if (request.ID == 0 && result.ApprovalID>0)
            {
                ApprovalRequestResult model = new ApprovalRequestResult();
                ApprovalHelper helper = new ApprovalHelper();
                model = await (new  EmployeeJson()).ApproveRequest(0, new PendingApproval() {ID=result.ApprovalID, Remarks="", Status= ApprovalStatus.Temp });
                if (model.Result )
                {
                    await helper.ProcessRequest(ApprovalTypes.MaterialRequest, model);
                }
            }
            return new JsonResult
            {
                Data = new { Data = result.ID},
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        
    }
}