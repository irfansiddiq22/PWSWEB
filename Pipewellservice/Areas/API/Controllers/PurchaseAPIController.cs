using Pipewellservice.Helper;
using PipewellserviceJson.HR.Employee;
using PipewellserviceJson.Procurement.Purchase;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using PipewellserviceModels.Procurement.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Areas.API.Controllers
{
    public class PurchaseAPIController : BaseController
    {
        private PurchaseJson json = new PurchaseJson();
        public async Task<JsonResult> GetPurchaseRequestList(DateParam date, PagingDTO paging, int RequestType)
        {
            var result = await json.GetPurchaseRequestList(date, paging, RequestType);
            return new JsonResult
            {
                Data = new { Data = result, TotalRecord = result.Count > 0 ? result[0].Total : 0 },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> GetPurchaseRequestDetail(int ID)
        {
            var result = await json.GetPurchaseRequestDetail(ID);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> AddPurchaseRequest(InternalPurchaseRequest request, List<InternalPurchaseRequestItem> Items)
        {
            request.RecordCreatedBy = SessionHelper.UserID();

            var result = await json.AddPurchaseRequest(request, Items);
            if (result.ApprovalID > 0)
            {
                ApprovalRequestResult model = new ApprovalRequestResult();
                ApprovalHelper helper = new ApprovalHelper();
                model = await (new EmployeeJson()).ApproveRequest(0, new PendingApproval() { ID = result.ApprovalID, Remarks = "", Status = ApprovalStatus.Temp });
                if (model.Result)
                {
                    await helper.ProcessRequest(ApprovalTypes.InternalPurchaseRequest, model, true);
                }
            }
            return new JsonResult
            {
                Data = result.ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [Authorization(Pages.ProcurementMaterialRequest, 1, 2)]
        public async Task<JsonResult> UpdateMaterialRequestFile(int ID)
        {


            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                bool result = await FileHelper.SaveFile(Request.Files[0], ID, 0, DirectoryNames.MaterialRequest);
                string FileID = $"{ID}{Path.GetExtension(file.FileName)}";

                if (result)
                {

                    return new JsonResult
                    {
                        Data = new ResultDTO() { ID = ID, Status = true, Message = "file uploaded" },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
            }


            return new JsonResult
            {
                Data = new ResultDTO() { ID = ID, Status = false, Message = "No file to upload" },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };


        }


    }
}