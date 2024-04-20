using Pipewellservice.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Controllers
{
    public class HomeController : Controller
    {
        [Authorization]
        public ActionResult Index()
        {
            ViewBag.Title = "";
            ViewBag.Parent = null;
            return View();
        }
         
        public ActionResult AccessDenied()
        {

            ViewBag.Title = "";
            ViewBag.Parent = null;
            return View();
        }
    }
}