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
            model.Rooms = await JsonHelper.Convert<List<Room>, DataTable>(db.Rooms);
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
        
    }
}
