using Pipewellservice.Helper;
using PipewellserviceJson.Auth;
using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Controllers
{
    public class AuthController : BaseController
    {
        AuthUserJson json = new AuthUserJson();
        // GET: Auth
        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<JsonResult> ProcessLogin(UserAuth user)
        {
            var result = await json.ProcessLogin(user);
            if (result.ID > 0)
            {
                SessionHelper.SetUserSession(result);
            }
            return new JsonResult
            {
                Data = (result.ID>0),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }
        public async Task<JsonResult> Identity()
        {
            return new JsonResult
            {
                Data = SessionHelper.UserSession(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}