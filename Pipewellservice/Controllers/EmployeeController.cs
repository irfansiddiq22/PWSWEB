using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            return View();
        }
        public ActionResult Certificate()
        {
            return View("_PartialCertificate");
        }
        public ActionResult Asset()
        {
            return View("_PartialAsset");
        }
        public ActionResult Family()
        {
            return View("_PartialFamily");
        }
        public ActionResult ID()
        {
            return View("_PartialID");
        }
        public ActionResult FamilyID()
        {
            return View("_PartialFamilyID");
        }
        public ActionResult Contract()
        {
            return View("_PartialContract");
        }
        public ActionResult Warning()
        {
            return View("_PartialEmployeeWarning");
        }
    }
}