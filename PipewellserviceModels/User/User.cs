﻿using PipewellserviceModels.HR.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.User
{
    
   public class User
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int GroupID { get; set; }
        public int PermissionGroupID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
        public string EmailAddress { get; set; }
        public bool Status { get; set; }
        public bool ApprovalRequests { get; set; }
        public string Position { get; set; }
        public List<PagePermisson> Permissions { get; set; }
        public List<EmployeeSupervisor> Supervisors { get; set; }
        public bool SelfService { get; set; }
    }
}
