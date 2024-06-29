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
        [Authorization(Pages.ProcurementMaterialRequest)]
        
        public ActionResult MaterialRequest()
        {
            ViewBag.Title = "Material Request ";
            ViewBag.Parent = Parent;
            return View();
        }

        [Authorization(Pages.InternalPurchaseRequest)]
        [Route("Procurement/Purchase/PurchaseRequest")]
        public ActionResult PurchaseRequest()
        {
            ViewBag.Title = "Internal Purchase Request";
            ViewBag.Parent = Parent;
            return View("InternalPurchaseRequest");
        }


        [Authorization(Pages.InternalPurchaseRequest)]
        
        public ActionResult PurchaseOrderManagment()
        {
            ViewBag.Title = "Purchase Order Management";
            ViewBag.Parent = Parent;
            return View("PurchaseOrderManagement");
        }


    }
}