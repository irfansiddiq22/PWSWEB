using Pipewellservice.Helper;
using PipewellserviceJson.Equipment.SparePart;
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
    public class SpacePartItemController : BaseController
    {

        private SparePartItemJson json = new SparePartItemJson();
        [Authorization(PipewellserviceModels.Common.Pages.SpareParts,1, CanDelete.Ignore)]
        public async Task<JsonResult> SaveItem(SparePartItem item)
        {
            item.RecordCreatdBy = SessionHelper.UserID;
            return new JsonResult()
                { Data= new {
                    ID = await json.SaveItem(item) },JsonRequestBehavior=JsonRequestBehavior.DenyGet };
        }
        public async Task<JsonResult> List(SparePartItem item)
        {
            item.RecordCreatdBy = SessionHelper.UserID;
            return new JsonResult()
            {
                Data = new
                {
                    ID = await json.SaveItem(item)
                },
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
    }
}