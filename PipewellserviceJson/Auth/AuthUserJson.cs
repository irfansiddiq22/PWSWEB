using PipewellserviceDB.Auth;
using PipewellserviceModels.Common;
using PipewellserviceModels.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.Auth
{
    public class AuthUserJson
    {

        AuthService service = new AuthService();
        public async Task<User> ProcessLogin(UserAuth user)
        {
            UserAuthSQL result = await service.ProcessLogin(user);
            User model = new User { ID = 0 };
            if (result != null)
                model = (await JsonHelper.Convert<List<User>, DataTable>(result.User)).FirstOrDefault();
            if (model.ID > 0)
            {
                model.Permissions = await JsonHelper.Convert<List<PagePermisson>, DataTable>(result.Permissions);
            }
            return model;
        }
    }
}
