using PipewellserviceModels.HR.Employee;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB.HR.Employee
{
    public class AccommodationService : DataServices
    {

        public async Task<BuildingDB> ListBuilding()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcListBuilding", CommandType.StoredProcedure);
                BuildingDB dt = new BuildingDB();
                dt.Buildings.Load(result);
                dt.Appartments.Load(result);
                dt.Rooms.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<int> AddBuilding(Building building)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = building.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Name", Value = building.Name };
                collSP[2] = new SqlParameter { ParameterName = "@NoOfFloor", Value = building.NoOfFloor };
                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcSaveBuilding", CommandType.StoredProcedure, collSP);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public async Task<int> AddFloor(int ID)
        {
            try
            {
                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcSaveBuildingFloor", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public async Task<int> AddAppartment(Appartment appt)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[4];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = appt.ID };
                collSP[1] = new SqlParameter { ParameterName = "@BuildingID", Value = appt.BuildingID };
                collSP[2] = new SqlParameter { ParameterName = "@FloorNumber", Value = appt.FloorNumber };
                collSP[3] = new SqlParameter { ParameterName = "@AppartmentNumber", Value = appt.AppartmentNumber };
                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcSaveBuildingAppartment", CommandType.StoredProcedure, collSP);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public async Task<bool> AssignRoomBeds(List<RoomBed> beds,int UserID, bool Aramco)
        {
            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<Dataset>");
                foreach (RoomBed bed in beds)
                {
                    xml.Append($"<Bed><AppartmentID>{bed.AppartmentID}</AppartmentID><RoomNumber>{bed.RoomNumber}</RoomNumber><BedNumber>{bed.BedNumber}</BedNumber><EmployeeID>{bed.EmployeeID}</EmployeeID></Bed>");

                }
                xml.Append("</Dataset>");


                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@Xml", Value = xml.ToString() };
                collSP[1] = new SqlParameter { ParameterName = "@UserID", Value = UserID };
                collSP[2] = new SqlParameter { ParameterName = "@AramcoRoom", Value = Aramco };

                var result = SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcSaveBuildingRoom", CommandType.StoredProcedure, collSP);
                
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
        public async Task<bool> AssignAppartmentPlan(Appartment appertment, List<RoomBed> beds)
        {
            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<Dataset>");
                foreach (RoomBed bed in beds)
                {
                    xml.Append($"<Bed><RoomNumber>{bed.RoomNumber}</RoomNumber><BedNumber>{bed.BedNumber}</BedNumber><EmployeeID>{bed.EmployeeID}</EmployeeID></Bed>");

                }
                xml.Append("</Dataset>");

                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@Xml", Value = xml.ToString() };
                collSP[1] = new SqlParameter { ParameterName = "@BuildingID", Value = appertment.BuildingID };
                collSP[2] = new SqlParameter { ParameterName = "@FloorNumber", Value = appertment.FloorNumber };

                var result = SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcSaveBuildingAppartmentPlan", CommandType.StoredProcedure, collSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> LeaveRoom(int EmployeeID)
        {
            try
            {
                var result = SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcLeaveEmployeeRoom", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID });
                return true;
            }
            catch (Exception e)
            {
                return false ;
            }
        }
        public async Task<bool> SwapRoom(int EmployeeID,int EmployeeID2)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID };
                collSP[1] = new SqlParameter { ParameterName = "@EmployeeID2", Value = EmployeeID2 };
                var result = SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcSwapEmployeeRoom", CommandType.StoredProcedure, collSP);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
