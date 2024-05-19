using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Common
{
   public class UserAuth
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UserAuthSQL
    {
        public DataTable User { get; set; }
        public DataTable Permissions { get; set; }
        public DataTable Supervisor { get; set; }
        public UserAuthSQL()
        {
            User = new DataTable();
            Permissions = new DataTable();
            Supervisor = new DataTable();

        }
    }
    public class OTP
    {
        public string EmailAddress { get; set; }
        public string OTPPassword { get; set; }
    }
}
