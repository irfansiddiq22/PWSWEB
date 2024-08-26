using Pipewellservice.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PipewellserviceModels.Common;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Pipewellservice.Controllers
{
    public class EquipmentsController : Controller
    {
        // GET: Equipments
        private string Parent = JsonConvert.SerializeObject(new { URL = "/Equipments/home", Title = "Equipments" });
        public ActionResult Home()
        {

            ViewBag.Title = "Equipments";
            ViewBag.Parent = null;
            return View();
        }
        [Authorization(Pages.SpareParts)]
        public ActionResult SpareParts()
        {
            ViewBag.Title = "Spare Parts List";
            ViewBag.Parent = Parent;
            return  View("_PartialSpareParts");
        }

        [Authorization(Pages.SparePartEquipmentQuotation)]
        public ActionResult Quotation()
        {
            ViewBag.Title = "Quotation";
            ViewBag.Parent = Parent;
            return View("quotation");
        }

        [Authorization(Pages.SparePartEquipmentOrderForm)]
        public ActionResult PurchaseOrderForm()
        {
            ViewBag.Title = "Purchase Order Form";
            ViewBag.Parent = Parent;
            return View("PurchaseOrderForm");
        }

        [Authorization(Pages.SparePartEquipmentCollection)]
        public ActionResult OrderCollection()
        {
            ViewBag.Title = "Quote Order Collection";
            ViewBag.Parent = Parent;
            return View("OrderCollection");
        }

        
    }
}