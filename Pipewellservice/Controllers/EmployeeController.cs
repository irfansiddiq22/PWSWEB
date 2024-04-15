﻿using Newtonsoft.Json;
using Pipewellservice.Reports;
using PipewellserviceDB.HR.Employee;
using PipewellserviceJson;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private string Parent = JsonConvert.SerializeObject(new {URL="/Employee/home",Title= "Human Resources" });
        public ActionResult Home()
        {
            ViewBag.Title = "Human Resources";
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
            ViewBag.Title = "Employee Certificates";
            ViewBag.Parent = Parent;
            return View("_PartialCertificate");
        }
        public ActionResult Asset()
        {
            ViewBag.Title = "Assets with Employee";
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
            ViewBag.Title = "Employee Contracts";
            ViewBag.Parent = Parent;
            return View("_PartialContract");
        }
        public ActionResult JobOffer()
        {
            ViewBag.Title = "Job Offer";
            ViewBag.Parent = Parent;
            return View("_PartialJobOffer");
        }
        public ActionResult JobContract()
        {
            ViewBag.Title = "Job Contracts";
            ViewBag.Parent = Parent;
            return View("_PartialJobContract");
        }

        
        public ActionResult Warning()
        {
            ViewBag.Title = "Employee warning ";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeWarning");
        }
        public ActionResult Clearance()
        {
            ViewBag.Title = "Employee Warning Notices";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeClearance");
        }
        public ActionResult Vacation()
        {
            ViewBag.Title = "Employee Vactions";
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
            ViewBag.Title = "Company Visitorss";
            ViewBag.Parent = Parent;
            return View("_PartialCompanyVistor");
        }

        public ActionResult Travel()
        {
            ViewBag.Title = "Employee Travel";
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
            ViewBag.Title = "Employee Passport & Iqama Handover";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeHandover");
        }

        public ActionResult Evaluation()
        {
            ViewBag.Title = "Employee Evaluation";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeEvaluation");
        }
        public ActionResult Setting()
        {
            ViewBag.Title = "Settings";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeSetting");
        }
        public async Task<ActionResult> PrintReport(int ID, Pages ReportID)
        {
            object report = null;
            switch (ReportID)
            {
                case Pages.EmployeeWarning:
                    EmployeeService service = new EmployeeService();
                    var data = await JsonHelper.Convert<List<EmployeeWarning>, DataTable>(await service.EmployeeWarningDetail(495));
                    report = new rpEmployeeWarning { DataSource = data, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait }, };
                    break;
                  
                    /*_reportdata = Repository.GetDetails(reportdesc.Id);
                    report = new PageReport(new FileInfo(Server.MapPath("~/Reports/OrderDetailsReport.rdlx")));
                    ((PageReport)(report)).Document.LocateDataSource += Document_LocateDataSource;*/

                    
            }

            
            ViewBag.Report = report;
            return PartialView("WebViewer");
        }

    }
}