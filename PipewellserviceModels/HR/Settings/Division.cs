using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Settings
{
    public class Division
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DataChangeLog log { get; set; }
        public int SupervisorID { get; set; }
        public int ParentDivision { get; set; }
        public string ParentDivisionName { get; set; }
        public string SupervisorName { get; set; }
    }
    public class Position
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DataChangeLog log { get; set; }
    }
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DataChangeLog log { get; set; }
    }
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string Nationality { get; set; }
        public string ArabicNationality{ get; set; }
        public DataChangeLog log { get; set; }
    }
    public class Nationality
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DataChangeLog log { get; set; }
    }
    public class SponsorCompany
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DataChangeLog log { get; set; }
        public int CRNumber { get; set; }
    }
    public class WorkInOutTime
    {
        public DataChangeLog log { get; set; }
        public int ID { get; set; }
        public int StartHour { get; set; }
        public int StartMin { get; set; }
        public int EndHour { get; set; }
        public int EndMin { get; set; }
        public int MarginIn { get; set; }
        public int MarginOut { get; set; }
        public string Time
        {
            get
            {
                return $"{StartHour.ToString("00")}:{StartMin.ToString("00")} - {EndHour.ToString("00")}:{EndMin.ToString("00")}";
            }
        }
    }

    public class EmployeeWorkSchedule
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime RecordDate { get; set; }
        public int EmployeeID { get; set; }
        public int FridayTime { get; set; }
        public int SaturdayTime { get; set; }
        public int SundayTime { get; set; }
        public int MondayTime { get; set; }
        public int TuesdayTime { get; set; }
        public int WednesdayTime { get; set; }
        public int ThursdayTime { get; set; }
    }
}
