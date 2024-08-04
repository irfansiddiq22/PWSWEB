using Newtonsoft.Json;
using Pipewellservice.Helper;
using PipewellserviceJson.Home;
using PipewellserviceJson.HR.Employee;
using PipewellserviceJson.Procurement;
using PipewellserviceJson.Procurement.Store;
using PipewellserviceModels.Common;
using PipewellserviceModels.Home;
using PipewellserviceModels.HR.Employee;
using PipewellserviceModels.Procurement;
using PipewellserviceModels.Procurement.Store;

using System;
using System.Collections.Generic;
using System.IO;
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
                Data = new { Data = result, TotalRecord = result.Count > 0 ? result[0].Total : 0, NextCode = result.Count > 0 ? result[0].NextCode : 0 },
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
            var result = await itemJson.AddStoreItem(item, SessionHelper.UserID());
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.ProcurementStoreItemManagement, 1, 2)]
        public async Task<JsonResult> UpdateItemFile(int ID)
        {


            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                bool result = await FileHelper.SaveFile(Request.Files[0], ID, ID, DirectoryNames.StoreItems);
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



        public async Task<JsonResult> GetMatrialRequestList(DateParam date, PagingDTO paging, int RequestType)
        {
            var result = await json.GetMatrialRequestList(date, paging, RequestType);
            return new JsonResult
            {
                Data = new { Data = result, TotalRecord = result.Count > 0 ? result[0].Total : 0 },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> GetOutofStockMatrialRequest(PagingDTO paging)
        {
            var result = await json.GetOutofStockMatrialRequest(paging);
            return new JsonResult
            {
                Data = new { Data = result, TotalRecord = result.Count > 0 ? result[0].Total : 0 },
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
        public async Task<JsonResult> GetMatrialRequestItems(int ID)
        {
            var result = await json.GetMatrialRequestItems(ID);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<JsonResult> GetMatrialRequestDeliveryItems(int ID)
        {
            var result = await json.GetMatrialRequestDeliveryItems(ID);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        

        public async Task<JsonResult> FindMatrialRequestNumber(string ID)
        {
            var result = await json.FindMatrialRequestNumber(ID);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        

        public async Task<JsonResult> AddMaterialRequest(MaterialRequest request, List<MaterialRequestItem> Items)
        {
            request.RecordCreatedBy = SessionHelper.UserID();

            var result = await json.AddMaterialRequest(request, Items);
            if (result.ApprovalID > 0)
            {
                ApprovalRequestResult model = new ApprovalRequestResult();
                ApprovalHelper helper = new ApprovalHelper();
                model = await (new EmployeeJson()).ApproveRequest(0, new PendingApproval() { ID = result.ApprovalID, Remarks = "", Status = ApprovalStatus.Temp });
                if (model.Result)
                {
                    await helper.ProcessRequest(ApprovalTypes.MaterialRequest, model, true);
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

        [Authorization(Pages.StoreReceiving, 1, 2)]
        public async Task<JsonResult> AddStoreReceiving(StoreReceiving dto, List<ReceivingItem> items)
        {
           // StoreReceiving dto = JsonConvert.DeserializeObject<StoreReceiving>(Request["dto"]);
            //List<ReceivingItem> items = JsonConvert.DeserializeObject<List<ReceivingItem>>(Request["items"]);
            

            dto.RecordCreatedBy = SessionHelper.UserID();
            var result = await itemJson.AddStoreReceiving(dto, items);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [Authorization(Pages.StoreReceiving)]
        public async Task<JsonResult> StoreReceivingList(StoreReceivingParam param)
        {
            
            var result = await itemJson.StoreReceivingList(param);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }



        [Authorization(Pages.StoreDelivery , 1, 2)]
        public async Task<JsonResult> AddStoreDelivery(StoreDelivery dto, List<DeliveryItem> items)
        {
            // StoreReceiving dto = JsonConvert.DeserializeObject<StoreReceiving>(Request["dto"]);
            //List<ReceivingItem> items = JsonConvert.DeserializeObject<List<ReceivingItem>>(Request["items"]);


            dto.RecordCreatedBy = SessionHelper.UserID();
            var result = await itemJson.AddStoreDelivery(dto, items);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [Authorization(Pages.StoreDelivery)]
        public async Task<JsonResult> StoreDeliveryList(StoreDeliveryParam param)
        {

            var result = await itemJson.StoreDeliveryList(param);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }






    }
}