using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
    public class EmployeeAttendenceInOut
    {
        public DateTime RecordDate { get; set; }
        public string WorkingDay { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public string EmployeeWorkedTime { get; set; }
        public string DayWorkingTime { get; set; }
        public int? DeductMin { get; set; }
        public string LeaveType { get; set; }

        public string Remarks { get; set; }
        public int   WarningCount { get; set; }
        public string ReportRemarks
        {
            get
            {
                if (Remarks != null && Remarks != "")
                    return Remarks;
                else if (WarningCount>0 && WarningCount<3)
                {
                    DeductMin = 0;


                    return $"Warning # {WarningCount}";
                }
                else
                  return  "";

            }
        }
        public string OnRig { get; set; }
        public string Description
        {
            get
            {
                if (DayWorkingTime == "00:00" && LeaveType==null)
                    return "Off";
                else if (OnRig != "")
                    return OnRig;
                else if (CheckInTime != null && CheckInTime == CheckOutTime)
                    return "";
                else if (EmployeeWorkedTime == "00:00")
                    return LeaveType == null ? "Absent" : LeaveType;
                else
                    return "";

            }
        }
    }
}
