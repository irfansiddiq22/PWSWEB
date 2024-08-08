using GrapeCity.ActiveReports.SectionReportModel;
using Newtonsoft.Json;
using Pipewellservice.Helper;
using Pipewellservice.Reports;
using PipewellserviceDB.Procurement.Purchase;
using PipewellserviceJson;
using PipewellserviceJson.Home;
using PipewellserviceJson.Procurement.Purchase;
using PipewellserviceModels.Common;
using PipewellserviceModels.Home;
using PipewellserviceModels.Procurement.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
            ViewBag.OutOfStockMaterialRequests = (new PurchaseService()).OutOfStockMaterialRequests();
            ViewBag.PedingIPORequstforQuote = (new PurchaseService()).PendingIPORequestForQuote();
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

        [Authorization(Pages.StoreReceiving)]
        [Route("Procurement/Store/Receiving")]
        public ActionResult Receiving()
        {
            ViewBag.Title = "Store Receiving";
            ViewBag.Parent = Parent;
            return View();
        }
        [Authorization(Pages.StoreDelivery)]
        [Route("Procurement/Store/Delivery")]
        public ActionResult Delivery()
        {
            ViewBag.Title = "Store Delivery";
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
            ViewBag.OutOfStockMaterialRequests = (new PurchaseService()).OutOfStockMaterialRequests();
            ViewBag.Parent = Parent;
            return View("InternalPurchaseRequest");
        }


        [Authorization(Pages.PurchaseOrderManagment)]

        public ActionResult PurchaseOrderManagment()
        {
            ViewBag.Title = "Purchase Order Management";
            ViewBag.Parent = Parent;
            return View("PurchaseOrderManagement");
        }
        [Authorization(Pages.RequestforQuote)]

        public ActionResult RequestForQuote()
        {
            ViewBag.Title = "Request for Quote";
            ViewBag.Parent = Parent;
            return View("RequestForQuote");
        }

        public async Task<ActionResult> PrintInternalPurchaseRequest(int ID)
        {
            rpInternalPurchase report = null;
           var  data2 = await ( new PurchaseService()).GetPurchaseRequestDetail(ID);
            report = new rpInternalPurchase { DataSource = data2.InternalPurchaseRequestItem, Document = { }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };
            report.UserData = (await JsonHelper.Convert<List<InternalPurchaseRequest>, DataTable>(data2.InternalPurchase)).FirstOrDefault();
            ViewBag.ReportName = "Internal Purchase Request";
            

            ViewBag.Report = report;
            return PartialView("~/Views/Employee/WebViewer.ascx");
        }
        public async Task<ActionResult> PrintPurchaseOrderRequest(int ID)
        {
            rpPurchaseOrderMgt report = null;
            var data2 = await (new PurchaseOrderManagementService()).GetPurchaseOrderDetail(ID);
            report = new rpPurchaseOrderMgt { DataSource = data2.OrderItem, Document = { }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };
            report.UserData = data2;//s (await JsonHelper.Convert<List<PurchaseOrderManagement>, DataTable>(data2.PurchaseOrder)).FirstOrDefault();
            ViewBag.ReportName = "Purchase Order Management";


            ViewBag.Report = report;
            return PartialView("~/Views/Employee/WebViewer.ascx");
        }



        



    }
}