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
        private string Parent = JsonConvert.SerializeObject(new {URL="/Employee/home",Title="Employee Managment"});
        public ActionResult Home()
        {
            ViewBag.Title = "Employee Management";
            ViewBag.Parent = null;
            return View();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Employee List";
            ViewBag.Parent = Parent;
            return View();
        }
        public ActionResult Certificate()
        {
            ViewBag.Title = "Employee Certificate";
            ViewBag.Parent = Parent;
            return View("_PartialCertificate");
        }
        public ActionResult Asset()
        {
            ViewBag.Title = "Employee Asset";
            ViewBag.Parent = Parent;
            return View("_PartialAsset");
        }
        public ActionResult Family()
        {
            ViewBag.Title = "Employee Family";
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
            ViewBag.Title = "Employee Family ID";
            ViewBag.Parent = Parent;
            return View("_PartialFamilyID");
        }
        public ActionResult Contract()
        {
            ViewBag.Title = "Employee Contract";
            ViewBag.Parent = Parent;
            return View("_PartialContract");
        }
        public ActionResult Warning()
        {
            return View("_PartialEmployeeWarning");
        }
        public ActionResult Clearance()
        {
            ViewBag.Title = "Employee Warning Notice";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeClearance");
        }
        public ActionResult Vacation()
        {
            ViewBag.Title = "Employee Vaction";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeVacation");
        }
        public ActionResult Joining()
        {
            ViewBag.Title = "Employee Joining";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeJoining");
        }
        public ActionResult Visitor()
        {
            ViewBag.Title = "Company Visitor";
            ViewBag.Parent = Parent;
            return View("_PartialCompanyVistor");
        }

        public ActionResult Travel()
        {
            ViewBag.Title = "Employee Trave";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeTravel");
        }
        public ActionResult CompanyTravel()
        {
            ViewBag.Title = "Company Travel";
            ViewBag.Parent = Parent;
            return View("_PartialCompanyTravel");
        }
        public ActionResult TravelRequest()
        {
            ViewBag.Title = "Employee Travel Request";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeTravelRequest");
        }
        public ActionResult LeaveRequest()
        {
            ViewBag.Title = "Employee Leave Request";
            ViewBag.Parent = Parent;

            return View("_PartialEmployeeLeaveRequet");
        }
        public ActionResult Inquiry()
        {
            ViewBag.Title = "Employee Inquiry Form";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeInquiry");
        }
        public ActionResult Passport()
        {
            ViewBag.Title = "Employee Passport";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeePassport");
        }
        public ActionResult TempEmployee()
        {
            ViewBag.Title = "Temporary Employee ";
            ViewBag.Parent = Parent;
            return View("_PartialTempEmployee");
        }
        public ActionResult ShortLeave()
        {
            ViewBag.Title = "Employee Short Leave";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeShortLeave");
        }
        public ActionResult FormHandover()
        {
            ViewBag.Title = "Employee Passport and Iqama Handover";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeHandover");
        }

        public ActionResult Evaluation()
        {
            ViewBag.Title = "Employee Evaluation";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeEvaluation");
        }



    }
}