using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
    public class Accommodation
    {
    }
    public class BuildingDB
    {
        public DataTable Buildings { get; set; }
        public DataTable Appartments { get; set; }
        public DataTable Rooms { get; set; }
        public BuildingDB()
        {
            Buildings = new DataTable();
            Appartments = new DataTable();
            Rooms = new DataTable();
        }
    }
    public class BuildingView {
        public List<Building> Buildings { get; set; }
        public List<Appartment> Appartments { get; set; }
        public List<RoomBed> Rooms { get; set; }
    }

    public class Building
    {
        public int ID { get; set; }
        public int NoOfFloor { get; set; }
        public string Name { get; set; }
    }

    public class Appartment
    {
        public int ID { get; set; }
        public int BuildingID { get; set; }
        public int FloorNumber { get; set; }
        public int AppartmentNumber { get; set; }
        public int NoOfRoom { get; set; }
    }
    public class RoomBed
    {
        public int AppartmentID { get; set; }
        public int RoomNumber { get; set; }
        public int BedNumber { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Position { get; set; }
        public string Division { get; set; }
        public string Nationality { get; set; }
        public bool AramcoRoom { get; set; }
    }

    
}
