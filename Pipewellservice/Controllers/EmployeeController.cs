using Newtonsoft.Json;
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
        private string Parent = JsonConvert.SerializeObject(new {URL="/Employee/home",Title= "Human resources" });
        public ActionResult Home()
        {
            ViewBag.Title = "Human resources";
            ViewBag.Parent = null;
            return View();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Employee list";
            ViewBag.Parent = Parent;
            return View();
        }
        public ActionResult Certificate()
        {
            ViewBag.Title = "Employee certificates";
            ViewBag.Parent = Parent;
            return View("_PartialCertificate");
        }
        public ActionResult Asset()
        {
            ViewBag.Title = "Compant assets with employee";
            ViewBag.Parent = Parent;
            return View("_PartialAsset");
        }
        public ActionResult Family()
        {
            ViewBag.Title = "Employee family";
            ViewBag.Parent = Parent;
            return View("_PartialFamily");
        }
        public ActionResult ID()
        {
            ViewBag.Title = "Employee ID";
            ViewBag.Parent = Parent;
            return View("_PartialID");
        }
        public ActionResult FamilyID()
        {
            ViewBag.Title = "Employee family ID";
            ViewBag.Parent = Parent;
            return View("_PartialFamilyID");
        }
        public ActionResult Contract()
        {
            ViewBag.Title = "Employee contracts";
            ViewBag.Parent = Parent;
            return View("_PartialContract");
        }
        public ActionResult Warning()
        {
            return View("_PartialEmployeeWarning");
        }
        public ActionResult Clearance()
        {
            ViewBag.Title = "Employee warning notices";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeClearance");
        }
        public ActionResult Vacation()
        {
            ViewBag.Title = "Employee vactions";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeVacation");
        }
        public ActionResult Joining()
        {
            ViewBag.Title = "Employee joining";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeJoining");
        }
        public ActionResult Visitor()
        {
            ViewBag.Title = "Company visitorss";
            ViewBag.Parent = Parent;
            return View("_PartialCompanyVistor");
        }

        public ActionResult Travel()
        {
            ViewBag.Title = "Employee travel";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeTravel");
        }
        public ActionResult CompanyTravel()
        {
            ViewBag.Title = "Company travel";
            ViewBag.Parent = Parent;
            return View("_PartialCompanyTravel");
        }
        public ActionResult TravelRequest()
        {
            ViewBag.Title = "Employee travel request";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeTravelRequest");
        }
        public ActionResult LeaveRequest()
        {
            ViewBag.Title = "Employee leave request";
            ViewBag.Parent = Parent;

            return View("_PartialEmployeeLeaveRequet");
        }
        public ActionResult Inquiry()
        {
            ViewBag.Title = "Employee inquiry form";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeInquiry");
        }
        public ActionResult Passport()
        {
            ViewBag.Title = "Employee passport";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeePassport");
        }
        public ActionResult TempEmployee()
        {
            ViewBag.Title = "Temporary employee ";
            ViewBag.Parent = Parent;
            return View("_PartialTempEmployee");
        }
        public ActionResult ShortLeave()
        {
            ViewBag.Title = "Employee short leave";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeShortLeave");
        }
        public ActionResult FormHandover()
        {
            ViewBag.Title = "Employee passport and iqama handover";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeHandover");
        }

        public ActionResult Evaluation()
        {
            ViewBag.Title = "Employee evaluation";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeEvaluation");
        }
        public ActionResult Setting()
        {
            ViewBag.Title = "Setting";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeSetting");
        }

    }
}