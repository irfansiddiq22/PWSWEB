using Pipewellservice.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PipewellserviceModels.Common;
using System.Threading.Tasks;
using PipewellserviceModels.HR.Employee;
using PipewellserviceJson.HR.Employee;

namespace Pipewellservice.Areas.API.Controllers
{
    [Authorization]
    public class AccommodationController : BaseController
    {
        private AccommodationJson json = new AccommodationJson();
        [Authorization(Pages.Accommodation, 1, 2)]
        public async Task<JsonResult> ListBuilding()
        {
            return new JsonResult
            {
                Data = await json.ListBuilding(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.Accommodation, 1, 2)]
        public async Task<JsonResult> AddBuilding(Building building)
        {

            int ID = await json.AddBuilding(building);

            return new JsonResult
            {
                Data = ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.Accommodation, 1, 2)]
        public async Task<JsonResult> AddFloor(int ID)
        {
            return new JsonResult
            {
                Data = await json.AddFloor(ID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [Authorization(Pages.Accommodation, 1, 2)]
        public async Task<JsonResult> AddAppartment(Appartment appt)
        {
            return new JsonResult
            {
                Data = await json.AddAppartment(appt),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        [Authorization(Pages.Accommodation, 1, 2)]
        public async Task<JsonResult> AssignRoomBeds(List<RoomBed> beds, bool AramcoRoom)
        {
            return new JsonResult
            {
                Data = await json.AssignRoomBeds(beds, SessionHelper.UserID, AramcoRoom),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [Authorization(Pages.Accommodation, 1, 2)]
        public async Task<JsonResult> AssignAppartmentPlan(Appartment appertment,List<RoomBed> beds)
        {
            return new JsonResult
            {
                Data = await json.AssignAppartmentPlan(appertment,beds),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.Accommodation, 1, 2)]
        public async Task<JsonResult> LeaveRoom(int EmployeeID)
        {
            return new JsonResult
            {
                Data = await json.LeaveRoom(EmployeeID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [Authorization(Pages.Accommodation, 1, 2)]
        public async Task<JsonResult> SwapRoom(int EmployeeID,int EmployeeID2)
        {
            return new JsonResult
            {
                Data = await json.SwapRoom(EmployeeID, EmployeeID2),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

    }

    
}