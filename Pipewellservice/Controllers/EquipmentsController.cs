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
    }
}