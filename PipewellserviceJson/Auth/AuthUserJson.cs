using PipewellserviceDB.Auth;
using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.Auth
{
   public class AuthUserJson
    {

        AuthService service = new AuthService();
        public async Task<bool> ProcessLogin(UserAuth user)
        {
            return await  service.ProcessLogin(user);
        }
    }
}
