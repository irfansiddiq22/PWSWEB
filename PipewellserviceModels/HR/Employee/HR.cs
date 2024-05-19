using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
   public class HRManager
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string EmailAddress { get; set; }
    }

    public class EmployeeSupervisor: HRManager
    {
        public SupervisorTypes SupervisorType { get; set; }//1=Supervisor 2=HR
        public int DivisionID { get; set; }

    }
}
