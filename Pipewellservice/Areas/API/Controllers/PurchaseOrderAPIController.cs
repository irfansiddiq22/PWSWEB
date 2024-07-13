using Pipewellservice.Helper;
using PipewellserviceJson.HR.Employee;
using PipewellserviceJson.Procurement.Purchase;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using PipewellserviceModels.Procurement.Purchase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Areas.API.Controllers
{
    public class PurchaseOrderAPIController : BaseController
    {
        private OrderPurchaseManagmentJson json = new OrderPurchaseManagmentJson();
        [Authorization(Pages.OrderPurchaseManagment)]
        public async Task<JsonResult> GetOrderPurchaseRequestList(DateParam date, PagingDTO paging, PurchaseOrderParam param)
        {
            var result = await json.GetOrderPurchaseRequestList(date, paging,param);
            return new JsonResult
            {
                Data = new { Data = result, TotalRecord = result.Count > 0 ? result[0].TotalRecord : 0 },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.OrderPurchaseManagment)]
        public async Task<JsonResult> GetOrderPurchaseRequestDetail(int ID)
        {
            var result = await json.GetOrderPurchaseRequestDetail(ID);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.OrderPurchaseManagment, 1, 2)]
        public async Task<JsonResult> AddOrderPurchaseManagmentData(OrderPurchaseManagement request, List<EmployeeApproval> approvals, List<OrderPurchaseManagementItem> Items)
        {
            request.RecordCreatedBy = SessionHelper.UserID();

            var result = await json.AddOrderPurchaseManagmentData(request, approvals, Items);
            if (result.ApprovalID > 0)
            {
                ApprovalRequestResult model = new ApprovalRequestResult();
                ApprovalHelper helper = new ApprovalHelper();
                model = await (new EmployeeJson()).ApproveRequest(0, new PendingApproval() { ID = result.ApprovalID, Remarks = "", Status = ApprovalStatus.Temp });
                if (model.Result)
                {
                    await helper.ProcessRequest(ApprovalTypes.OrderPurchaseManagement, model, true);
                }
            }
            return new JsonResult
            {
                Data = result.ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<JsonResult> GetInterPurchaseOrderNumber(string IPO)
        {

            var result = await json.GetInterPurchaseOrderNumber(IPO);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.OrderPurchaseManagment)]
        public async Task<JsonResult> GetSupplierItemRate(int ID,int ItemID)
        {

            var result = await json.GetSupplierItemRate(ID,ItemID);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        /*
        [Authorization(Pages.InternalPurchaseRequest, 1, 2)]
        public async Task<JsonResult> UpdatePurchaseRequestFile(int ID)
        {


            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                bool result = await FileHelper.SaveFile(Request.Files[0], ID, 0, DirectoryNames.PurchaseRequest);
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
        */

    }
}