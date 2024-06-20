using Newtonsoft.Json;
using Pipewellservice.Helper;
using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Controllers
{
    public class ProcurementController : BaseController
    {
        // GET: Employee
        private string Parent = JsonConvert.SerializeObject(new { URL = "/Procurement/home", Title = "Procurement" });
        public ProcurementController()
        {
            if (SessionHelper.UserGroup() == (int)UserGroups.Employee)
            {
                Parent = "";
            }
        }


        [Authorization]
        public ActionResult Home()
        {
            ViewBag.Title = "Procurement";
            ViewBag.Parent = null;
            return View();
        }


        [Authorization(Pages.ProcurementStoreItemManagement)]
        [Route("Procurement/Store/ItemManagement")]
        public ActionResult ItemManagement()
        {
            ViewBag.Title = "Item Management";
            ViewBag.Parent = Parent;
            return View();
        }
    }
}