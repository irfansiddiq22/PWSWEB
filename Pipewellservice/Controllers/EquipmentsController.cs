using Pipewellservice.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PipewellserviceModels.Common;
using System.Web.Mvc;
using Newtonsoft.Json;
using Pipewellservice.Reports;
using PipewellserviceJson.Equipment;

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


        public async Task<ActionResult> PrintReport(int ID)
        {


            rptEquipmentQuote report = null;
            var data2 = await (new EquipmentQuoteJson()).QuotePrintDetail(ID);

            report = new rptEquipmentQuote { DataSource = data2.Items, Document = { }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };
            report.UserData = data2;
            ViewBag.ReportName = "Equipment Quote Request";


            ViewBag.Report = report;
            return PartialView("~/Views/Employee/WebViewer.ascx");

            //var data = json.QuoteDetail(ID);
            /*
            report = new rp { DataSource = data, Document = { }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };
            ViewBag.ReportName = "Employee Attendence InOut";
            ((rpEmployeeAttendenceInOut)report).Parameters.Add(new Parameter() { Key = "DateRange", Value = $"{StartDate.ToString("dd/MM/yyyy")}-{EndDate.ToString("dd/MM/yyyy")}" });



            ViewBag.Report = report;*/
            return PartialView("~/Views/Employee/WebViewer.ascx");
        }
    }
}