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
        // GET: Auth
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}