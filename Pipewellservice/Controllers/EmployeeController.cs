using GrapeCity.ActiveReports.SectionReportModel;
using Newtonsoft.Json;
using Pipewellservice.Helper;
using Pipewellservice.Reports;
using PipewellserviceDB.HR.Employee;
using PipewellserviceJson;
using PipewellserviceJson.HR.Employee;
using PipewellserviceModels.Common;
using PipewellserviceModels.Home;
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
    public class EmployeeController : BaseController
    {
        // GET: Employee
        private string Parent = JsonConvert.SerializeObject(new { URL = "/Employee/home", Title = "Human Resources" });
        public EmployeeController()
        {
            if (SessionHelper.UserGroup() == (int)UserGroups.Employee)
            {
                Parent = "";
            }
        }
        [Authorization]
        public ActionResult Home()
        {
            ViewBag.Title = "Human Resources";
            ViewBag.Parent = null;
            return View();
        }
        [Authorization(Pages.EmployeeDetail)]
        public ActionResult Index()
        {
            ViewBag.Title = "Employee List";
            ViewBag.Parent = Parent;
            return View();
        }
        [Authorization(Pages.Certificates)]
        public ActionResult Certificate()
        {
            ViewBag.Title = "Employee Certificates";
            ViewBag.Parent = Parent;
            return View("_PartialCertificate");
        }
        [Authorization(Pages.Assets)]
        public ActionResult Asset()
        {
            ViewBag.Title = "Assets with Employee";
            ViewBag.Parent = Parent;
            return View("_PartialAsset");
        }
        [Authorization(Pages.Family)]
        public ActionResult Family()
        {
            ViewBag.Title = "Employee Family";
            ViewBag.Parent = Parent;
            return View("_PartialFamily");
        }
        [Authorization(Pages.EmployeeID)]
        public ActionResult ID()
        {
            ViewBag.Title = "Employee ID";
            ViewBag.Parent = Parent;
            return View("_PartialID");
        }
        [Authorization(Pages.FamilyID)]
        public ActionResult FamilyID()
        {
            ViewBag.Title = "Employee Family ID";
            ViewBag.Parent = Parent;
            return View("_PartialFamilyID");
        }
        [Authorization(Pages.Contract)]
        public ActionResult Contract()
        {
            ViewBag.Title = "Employee Contracts";
            ViewBag.Parent = Parent;
            return View("_PartialContract");
        }
        [Authorization(Pages.JobOffers)]
        public ActionResult JobOffer()
        {
            ViewBag.Title = "Job Offer";
            ViewBag.Parent = Parent;
            return View("_PartialJobOffer");
        }
        [Authorization(Pages.JobContracts)]
        public ActionResult JobContract()
        {
            ViewBag.Title = "Job Contracts";
            ViewBag.Parent = Parent;
            return View("_PartialJobContract");
        }


        [Authorization(Pages.EmployeeCV)]
        public ActionResult EmployeeCV()
        {
            ViewBag.Title = "Job CV Data Capture";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeCV");
        }

        [Authorization(Pages.SupplierAssessment)]
        public ActionResult SupplierAssessment()
        {
            ViewBag.Title = "Supplier Assessment";
            ViewBag.Parent = Parent;
            return View("_PartilSupplierAssessment");
        }



        [Authorization(Pages.EmployeeWarning)]
        public ActionResult Warning()
        {
            ViewBag.Title = "Employee warning ";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeWarning");
        }
        [Authorization(Pages.EmployeeClearance)]
        public ActionResult Clearance()
        {
            ViewBag.Title = "Employee Warning Notices";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeClearance");
        }
        [Authorization(Pages.EmployeeVacation)]
        public ActionResult Vacation()
        {
            ViewBag.Title = "Employee Vactions";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeVacation");
        }
        [Authorization(Pages.Accommodation)]
        public ActionResult Accommodation()
        {
            ViewBag.Title = "Employee Accommodation";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeAccommodation");
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
        [Authorization(Pages.LeaveRequest)]
        public ActionResult LeaveRequest()
        {

            ViewBag.Title = "Employee Leave Request";
            ViewBag.Parent = Parent;
            if (SessionHelper.UserGroup() == 2)
                return View("_PartialEmployeeLeaves");
            else
                return View("_PartialEmployeeLeavesHr");

        }
        [Authorization(Pages.EmployeeInquiry)]
        public ActionResult Inquiry()
        {
            ViewBag.Title = "Employee Request Form";
            ViewBag.Parent = Parent;
            if (SessionHelper.UserGroup() == 2)
                return View("_PartialEmployeeInquiry");
            else
                return View("_PartialEmployeeInquiryHr");
        }

        [Authorization(Pages.EmployeeWorkTiming)]
        public ActionResult workschedule()
        {
            ViewBag.Title = "Employee Work Schedule";
            ViewBag.Parent = Parent;
            return View("_PartialWorkSchedule");
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
            if (SessionHelper.UserGroup() == 2)
                return View("_PartialEmployeeShortLeave");
            else
                return View("_PartialEmployeeShortLeaveHR");
        }
        public ActionResult ExpiringID()
        {
            ViewBag.Title = "Employee Expiring ID";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeExpID");
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
        [Authorization(Pages.Positions)]
        public ActionResult Setting()
        {
            ViewBag.Title = "Settings";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeSetting");
        }
        [Authorization(Pages.AttendenceReport)]
        public ActionResult AttendenceReport()
        {
            ViewBag.Title = "Attendence Report";
            ViewBag.Parent = Parent;
            return View("_PartialEmployeeAttendenceReport");
        }



        public ActionResult Sponsors()
        {
            ViewBag.Title = "Employee Sponor";
            ViewBag.Parent = Parent;
            return View("_PartialSponsor");
        }
        public async Task<ActionResult> PrintReport(int ID, ReportTypes ReportID)
        {
            EmployeeService service = new EmployeeService();
            object report = null;
            object data = null;
            switch (ReportID)
            {
                case ReportTypes.EmployeeWarning:

                    data = await JsonHelper.Convert<List<EmployeeWarningReport>, DataTable>(await service.EmployeeWarningDetail(ID));
                    report = new rpEmployeeWarning { DataSource = data, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 }, };
                    ViewBag.ReportName = "Warning Notice";
                    break;

                case ReportTypes.EmployeeInquiry:
                    data = await JsonHelper.Convert<List<EmployeeInquiryReport>, DataTable>(await service.EmployeeInquiryReportDetail(ID));

                    report = new rpEmployeeInquiry { DataSource = data, Document = { CacheToDisk = true }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };
                    ViewBag.ReportName = "Employee Request";

                    break;





            }


            ViewBag.Report = report;
            return PartialView("WebViewer");
        }

        public async Task<ActionResult> PrintAttendenceReport(int ID, ReportTypes ReportID, DateTime StartDate, DateTime EndDate)
        {
            EmployeeService service = new EmployeeService();
            object report = null;
            object data = null;
            switch (ReportID)
            {



                case ReportTypes.EmployeeAttendenceInOut:
                    data = await JsonHelper.Convert<List<EmployeeAttendenceInOut>, DataTable>(await service.EmployeeAttendenceInOut(new DateParam() { EmployeeID = ID, StartDate = StartDate, EndDate = EndDate }));
                    report = new rpEmployeeAttendenceInOut { DataSource = data, Document = { }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };
                    ViewBag.ReportName = "Employee Attendence InOut";
                    ((rpEmployeeAttendenceInOut)report).Parameters.Add(new Parameter() { Key = "DateRange", Value = $"{StartDate.ToString("dd/MM/yyyy")}-{EndDate.ToString("dd/MM/yyyy")}" });
                    break;

                case ReportTypes.EmployeeAttendenceDetail:
                    data = await service.EmployeeAttendenceDetail(new DateParam() { EmployeeID = ID, StartDate = StartDate, EndDate = EndDate });
                    report = new rptAttendanceDetail { DataSource = data, Document = { }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };
                    ((rptAttendanceDetail)report).Parameters.Add(new Parameter() { Key = "DateRange", Value = $"{StartDate.ToString("dd/MM/yyyy")}-{EndDate.ToString("dd/MM/yyyy")}" });
                    ViewBag.ReportName = "Employee Attendence Detail";

                    break;

                case ReportTypes.EmployeeAttendenceSummary:

                    data = await service.EmployeeAttendenceSummary(new DateParam() { EmployeeID = ID, StartDate = StartDate, EndDate = EndDate });
                    report = new rpEmployeeAttendenceSummary { DataSource = data, Document = { }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };
                    ((rpEmployeeAttendenceSummary)report).Parameters.Add(new Parameter() { Key = "DateRange", Value = $"{StartDate.ToString("dd/MM/yyyy")}-{EndDate.ToString("dd/MM/yyyy")}" });
                    ViewBag.ReportName = "Employee Attendence Summary";

                    break;



            }


            ViewBag.Report = report;
            return PartialView("WebViewer");
        }
        
        public async Task<ActionResult> PrintSupplierAssessmentReport(int ID)
        {

            SupplierAssementDTO data = await (new EmployeeJson()).SupplierAssessment(ID);


            rpSupplierAssessment report = new rpSupplierAssessment { DataSource = data.assessment, Document = { }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };
            report.UserData = data;
            ViewBag.ReportName = "Supplier Assessment Report";

            ViewBag.Report = report;
            return PartialView("WebViewer");
        }

    }
}