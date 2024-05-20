using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
  public   class EmployeeShortLeave: RecordLog
    {
        public string Remarks { get; set; }
        public string LeaveTime { get; set; }
        public List<EmployeeApproval> Approvals { get; set; }


    }

    public class EmployeeShortLeaveListView
    {
        public List<EmployeeShortLeave> Leaves { get; set; }
        public List<EmployeeApproval> Approvals { get; set; }
    }
}
