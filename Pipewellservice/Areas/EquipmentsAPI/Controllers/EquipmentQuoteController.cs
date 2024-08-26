using Pipewellservice.Helper;
using PipewellserviceJson.Equipment;
using PipewellserviceModels.Common;
using PipewellserviceModels.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Areas.EquipmentsAPI.Controllers
{
    public class EquipmentQuoteController : BaseController
    {

        private EquipmentQuoteJson json = new EquipmentQuoteJson();
        [Authorization(Pages.SparePartEquipmentQuotation, 1, CanDelete.Ignore)]
        public async Task<JsonResult> SaveQuote(EquipmentQuote quote)
        {
            quote.RecordCreatedBy = SessionHelper.UserID;
            return new JsonResult()
            {
                Data = new
                {
                    ID = await json.SaveQuote(quote)
                },
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
        [Authorization(Pages.SparePartEquipmentQuotation, 1, CanDelete.Ignore)]
        public async Task<JsonResult> List(EquipmentQuoteParam item)
        {

            return new JsonResult()
            {
                Data = await json.List(item),
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
        [Authorization(Pages.SparePartEquipmentQuotation, 1, CanDelete.Ignore)]
        public async Task<JsonResult> Detail(int ID)
        {

            return new JsonResult()
            {
                Data = await json.QuoteDetail(ID),
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
        [Authorization(Pages.SparePartEquipmentQuotation, 1, CanDelete.Ignore)]
        public async Task<JsonResult> DetailByID(int QuoteID)
        {

            return new JsonResult()
            {
                Data = await json.QuoteDetailByID(QuoteID),
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
        [Authorization(Pages.SparePartEquipmentQuotation, 1, CanDelete.Ignore)]
        public async Task<JsonResult> QuoteIDList(string QuoteID)
        {

            return new JsonResult()
            {
                Data = await json.QuoteIDList(QuoteID),
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }



        [Authorization(Pages.SparePartEquipmentCollection, 1, CanDelete.Ignore)]
        public async Task<JsonResult> SaveCollectQuote(EquipmentQuoteCollection quote)
        {
            quote.RecordCreatedBy = SessionHelper.UserID;
            return new JsonResult()
            {
                Data = new
                {
                    ID = await json.SaveCollectQuote(quote)
                },
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }

        [Authorization(Pages.SparePartEquipmentCollection, 1, CanDelete.Ignore)]
        public async Task<JsonResult> QuoteCollectionList(EquipmentQuoteParam param)
        {

            return new JsonResult()
            {
                Data = await json.QuoteCollectionList(param),
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
        [Authorization(Pages.SparePartEquipmentQuotation, 1, CanDelete.Ignore)]
        public async Task<JsonResult> QuoteCollectionDetail(int ID)
        {

            return new JsonResult()
            {
                Data = await json.QuoteCollectionDetail(ID),
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }

    }
}