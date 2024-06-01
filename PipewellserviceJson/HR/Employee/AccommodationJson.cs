using PipewellserviceDB.HR.Employee;
using PipewellserviceModels.HR.Employee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.HR.Employee
{
    public class AccommodationJson
    {
        private AccommodationService service = new AccommodationService();
        public async Task<BuildingView> ListBuilding()
        {
            BuildingDB db = await service.ListBuilding();
            BuildingView model = new BuildingView();
            model.Buildings=await JsonHelper.Convert<List<Building>, DataTable>(db.Buildings);
            model.Appartments = await JsonHelper.Convert<List<Appartment>, DataTable>(db.Appartments);
            model.Rooms = await JsonHelper.Convert<List<RoomBed>, DataTable>(db.Rooms);
            return model;
        }

        public async Task<int> AddBuilding(Building building)
        {
            return await service.AddBuilding(building);
        }
        public async Task<int> AddFloor(int ID)
        {
            return await service.AddFloor(ID);
        }
        public async Task<int> AddAppartment(Appartment appt)
        {
            return await service.AddAppartment(appt);
        }

        public async Task<bool> AssignRoomBeds(List<RoomBed> beds,int UserID, bool AramcoRoom)
        {
            return await service.AssignRoomBeds(beds, UserID, AramcoRoom);
        }
        public async Task<bool> AssignAppartmentPlan(Appartment appertment, List<RoomBed> beds)
        {
            return await service.AssignAppartmentPlan(appertment,beds);
        }
        public async Task<bool> LeaveRoom(int EmployeeID)
        {
            return await service.LeaveRoom(EmployeeID);
        }
        public async Task<bool> SwapRoom(int EmployeeID,int EmployeeID2)
        {
            return await service.SwapRoom(EmployeeID, EmployeeID2);
        }

    }
}
