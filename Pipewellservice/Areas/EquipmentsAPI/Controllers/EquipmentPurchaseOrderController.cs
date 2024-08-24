using Pipewellservice.Helper;
using PipewellserviceJson.Equipment;
using PipewellserviceModels.Common;
using PipewellserviceModels.Equipment.SparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Areas.EquipmentsAPI.Controllers
{
    public class EquipmentPurchaseOrderController : BaseController
    {

        private EquipmentPurchaseOrderJson json = new EquipmentPurchaseOrderJson();
        [Authorization(Pages.SparePartEquipmentOrderForm, 1, CanDelete.Ignore)]
        public async Task<JsonResult> SaveOrder(EquipmentPurchaseOrder order)
        {
            order.RecordCreatedBy = SessionHelper.UserID;
            return new JsonResult()
            {
                Data = new
                {
                    ID = await json.SaveOrder(order)
                },
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
        [Authorization(Pages.SparePartEquipmentOrderForm, 1, CanDelete.Ignore)]
        public async Task<JsonResult> List(EquipmentPurchaseOrderParam param)
        {
            return new JsonResult()
            {
                Data = await json.List(param),
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
        [Authorization(Pages.SparePartEquipmentOrderForm, 1, CanDelete.Ignore)]
        public async Task<JsonResult> Detail(int ID)
        {
            return new JsonResult()
            {
                Data = await json.OrderDetail(ID),
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
        [Authorization(Pages.SparePartEquipmentOrderForm, 1, CanDelete.Ignore)]
        public async Task<JsonResult> OrderListData()
        {
            return new JsonResult()
            {
                Data = await json.OrderListData(),
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
    }
}