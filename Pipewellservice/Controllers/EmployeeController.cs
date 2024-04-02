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
        public ActionResult Home()
        {
            ViewBag.Title = "Home";
            return View();
        }
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
        public ActionResult Clearance()
        {
            return View("_PartialEmployeeClearance");
        }
        public ActionResult Vacation()
        {
            return View("_PartialEmployeeVacation");
        }
        public ActionResult Joining()
        {
            return View("_PartialEmployeeJoining");
        }
        public ActionResult Visitor()
        {
            return View("_PartialCompanyVistor");
        }

        public ActionResult Travel()
        {
            return View("_PartialEmployeeTravel");
        }
        public ActionResult CompanyTravel()
        {
            return View("_PartialCompanyTravel");
        }
        public ActionResult TravelRequest()
        {
            return View("_PartialEmployeeTravelRequest");
        }
        public ActionResult LeaveRequest()
        {
            return View("_PartialEmployeeLeaveRequet");
        }
        public ActionResult Inquiry()
        {
            return View("_PartialEmployeeInquiry");
        }
        public ActionResult Passport()
        {
            return View("_PartialEmployeePassport");
        }
        public ActionResult TempEmployee()
        {
            return View("_PartialTempEmployee");
        }
        public ActionResult ShortLeave()
        {
            return View("_PartialEmployeeShortLeave");
        }
        public ActionResult FormHandover()
        {
            return View("_PartialEmployeeHandover");
        }

        public ActionResult Evaluation()
        {
            return View("_PartialEmployeeEvaluation");
        }



    }
}