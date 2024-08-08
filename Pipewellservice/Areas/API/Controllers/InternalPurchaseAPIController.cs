using Pipewellservice.Helper;
using PipewellserviceDB.Procurement.Purchase;
using PipewellserviceJson.HR.Employee;
using PipewellserviceJson.HR.Setting;
using PipewellserviceJson.Procurement.Purchase;
using PipewellserviceModels.Account;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using PipewellserviceModels.Procurement.Purchase;
using PipewellserviceModels.Setting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Areas.API.Controllers
{
    public class InternalPurchaseAPIController : BaseController
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
        public async Task<JsonResult> GetPurchaseRequestItems(int ID)
        {
            var result = await json.GetPurchaseRequestItems(ID);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        
        [Authorization(Pages.InternalPurchaseRequest, 1, 2)]
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
                Data =new { ID = result.ID, PendingStockIPR = (new PurchaseService()).OutOfStockMaterialRequests() },

                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

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



        public async Task<JsonResult> GetPedingRequestList( PagingDTO paging)
        {
            var result = await json.GetPedingRequestList( paging);
            return new JsonResult
            {
                Data = new { Data = result, TotalRecord = result.Count > 0 ? result[0].Total : 0 },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> SaveRequestForQuote(int IPO,string Suppliers, List<InternalPurchaseRequestItem> Items)
        {
            List<SuplierContact> suppliers = await json.SaveRequestForQuote(IPO, SessionHelper.UserID(), Suppliers);
            if (suppliers != null)
            {
                string items = "";
                List<MergeField> field = new List<MergeField>();

                var EmailTemplate = new EmailTemplate();
                EmailTemplate = await (new SettingJson()).GetEmailTemplate(2, ApprovalTypes.RFQ);
                foreach (SuplierContact suplier in suppliers)
                {
                    string EmailBody = EmailTemplate.Body;
                    items = "";
                    field.Add(new MergeField("SUPPLIER_NAME", suplier.ContactPerson));
                    foreach (InternalPurchaseRequestItem detail in Items)
                    {
                        items += $"<tr><td>{detail.ItemName}</td><td>{detail.Quantity}</td></tr>";

                    }

                    field.Add(new MergeField("ITEMS", items));

                    EmailHelper email = new EmailHelper();
                    await email.SendEmail(new EmailDTO() { To = suplier.ContactEmailAddress, From = "no-reply@pipewellservices.com", Subject = EmailTemplate.Subject, Body = EmailBody }, field);
                }


                return new JsonResult
                {
                    Data = true,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }else
                return new JsonResult
                {
                    Data = false,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
        }

        
    }
}