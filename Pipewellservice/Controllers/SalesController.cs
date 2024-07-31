using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        private string Parent = JsonConvert.SerializeObject(new { URL = "/Sales/home", Title = "Sales" });
        public ActionResult Home()
        {
            ViewBag.Title = "Sales";
            ViewBag.Parent = null;
            return View();
        }
    }
}