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
    public class AuthController : Controller
    {
        AuthUserJson json = new AuthUserJson();
        // GET: Auth
        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<JsonResult> ProcessLogin(UserAuth user)
        {
            return new JsonResult
            {
                Data = await json.ProcessLogin(user),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }
    }
}