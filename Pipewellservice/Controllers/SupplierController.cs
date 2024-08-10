using Newtonsoft.Json;
using Pipewellservice.App_Start;
using Pipewellservice.Helper;
using Pipewellservice.Reports;
using PipewellserviceJson.SupplierJson;
using PipewellserviceModels.Account;
using PipewellserviceModels.Common;
using PipewellserviceModels.Supplier;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Controllers
{
    public class SupplierController : Controller
    {
        private string Parent = JsonConvert.SerializeObject(new { URL = "/Sales/home", Title = "Sales" });
        public SupplierJson json = new SupplierJson();
        public async Task<ActionResult> registration()
        {
            ViewBag.Title = "";
            ViewBag.Parent = null;
            ViewBag.RECAPTCHA = ConfigurationManager.AppSettings["RECAPTCHA"];

            ViewBag.Name = await AppData.CompanyName();
            return View();
        }
        public async Task<JsonResult> SaveRegistration(SupplierAssesment assesment)
        {
            int result = await json.SaveRegistration(assesment);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }

        public async Task<JsonResult> UploadRegistrationFiles(int ID)
        {
            HttpPostedFileBase CRFile, ZakatFile, ChamberMemberShipFile, QualityManagementCertificateFile, MajorCustomerFile, ProductionFile, QualityControlFile, NationalAddressFile;
            CRFile = Request.Files["CRFile"];
            ZakatFile = Request.Files["ZakatFile"];
            ChamberMemberShipFile = Request.Files["ChamberMemberShipFile"];
            QualityManagementCertificateFile = Request.Files["QualityManagementCertificateFile"];
            MajorCustomerFile = Request.Files["MajorCustomerFile"];
            ProductionFile = Request.Files["ProductionFile"];
            QualityControlFile = Request.Files["QualityControlFile"];
            NationalAddressFile = Request.Files["NationalAddressFile"];

            RegistrationFile file = new RegistrationFile();
            if (CRFile != null)
            {
                file.CRFile = CRFile.FileName;
                file.CRFileID = Path.GetExtension(CRFile.FileName);
                file.CRFileID = $"CR-File{file.CRFileID}";

                await FileHelper.SaveFile(CRFile, file.CRFileID, ID, DirectoryNames.SupplierAssesment);
            }

            if (ZakatFile != null)
            {
                file.ZakatFile = ZakatFile.FileName;
                file.ZakatFileID = Path.GetExtension(ZakatFile.FileName);
                file.ZakatFileID = $"Zakat-File{file.ZakatFileID}";
                await FileHelper.SaveFile(ZakatFile, file.ZakatFileID, ID, DirectoryNames.SupplierAssesment);
            }

            if (ChamberMemberShipFile != null)
            {
                file.ChamberMemberShipFile = ChamberMemberShipFile.FileName;
                file.ChamberMemberShipFileID = Path.GetExtension(ChamberMemberShipFile.FileName);
                file.ChamberMemberShipFileID = $"Chamber-MemberShip-File{file.ChamberMemberShipFileID}";
                await FileHelper.SaveFile(ChamberMemberShipFile, file.ChamberMemberShipFileID, ID, DirectoryNames.SupplierAssesment);
            }

            if (QualityManagementCertificateFile != null)
            {
                file.QualityManagementCertificateFile = QualityManagementCertificateFile.FileName;
                file.QualityManagementCertificateFileID = Path.GetExtension(QualityManagementCertificateFile.FileName);
                file.QualityManagementCertificateFileID = $"Quality-Management-Certificate{file.QualityManagementCertificateFileID}";
                await FileHelper.SaveFile(QualityManagementCertificateFile, file.QualityManagementCertificateFileID, ID, DirectoryNames.SupplierAssesment);
            }

            if (MajorCustomerFile != null)
            {
                file.MajorCustomerFile = MajorCustomerFile.FileName;
                file.MajorCustomerFileID = Path.GetExtension(MajorCustomerFile.FileName);
                file.MajorCustomerFileID = $"Major-Customers{file.MajorCustomerFile}";
                await FileHelper.SaveFile(MajorCustomerFile, file.MajorCustomerFileID, ID, DirectoryNames.SupplierAssesment);
            }

            if (ProductionFile != null)
            {
                file.ProductionFile = ProductionFile.FileName;
                file.ProductionFileID = Path.GetExtension(ProductionFile.FileName);
                file.ProductionFileID = $"Production-Facilities{file.ProductionFileID}";
                await FileHelper.SaveFile(ProductionFile, file.ProductionFileID, ID, DirectoryNames.SupplierAssesment);
            }

            if (QualityControlFile != null)
            {
                file.QualityControlFile = QualityControlFile.FileName;
                file.QualityControlFileID = Path.GetExtension(QualityControlFile.FileName);
                file.QualityControlFileID = $"Quality-Control-Facilities{file.QualityControlFile}";
                await FileHelper.SaveFile(QualityControlFile, file.QualityControlFileID, ID, DirectoryNames.SupplierAssesment);
            }

            if (NationalAddressFile != null)
            {
                file.NationalAddressFile = NationalAddressFile.FileName;
                file.NationalAddressFileID = Path.GetExtension(NationalAddressFile.FileName);
                file.NationalAddressFileID = $"Nation-Address-File{file.NationalAddressFileID}";
                await FileHelper.SaveFile(QualityControlFile, file.NationalAddressFileID, ID, DirectoryNames.SupplierAssesment);
            }

            bool result = await json.SaveRegistrationFiles(ID, file);


            return new JsonResult
            {
                Data = new { Result = result },
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };


        }
        public async Task<JsonResult> ReadFileData()
        {
            HttpPostedFileBase file = Request.Files[0];
            try
            {
                string BasePath = Config.ResourcesDirectory;
                if (!BasePath.EndsWith(@"\"))
                {
                    BasePath = BasePath + "\\";
                }
                BasePath = Server.MapPath("~/Resources/");
                BasePath = BasePath + "Temp\\";
                DirectoryInfo tempDir = new DirectoryInfo(BasePath);

                if (!tempDir.Exists)
                {
                    tempDir.Create();
                }

                if (file.FileName.ToLower().EndsWith("csv"))
                {
                    BasePath = $"{BasePath}{Guid.NewGuid().ToString()}.csv";
                }
                else if (file.FileName.ToLower().EndsWith("xls"))
                {
                    BasePath = $"{BasePath}{Guid.NewGuid().ToString()}.xls";

                }
                else if (file.FileName.ToLower().EndsWith("xlsx"))
                {
                    BasePath = $"{BasePath}{Guid.NewGuid().ToString()}.xlsx";

                }

                file.SaveAs(BasePath);
                List<FileData> FileData = new List<FileData>();
                int RowIndex = 0;
                if (file.FileName.ToLower().EndsWith("csv"))
                {
                    var lines = System.IO.File.ReadLines(BasePath);

                    foreach (string line in lines)
                    {
                        RowIndex++;
                        FileData Data = new FileData();
                        Data.RowIndex = RowIndex;
                        Data.Data = StringHelper.SplitCSV(line);
                        FileData.Add(Data);

                    }

                }
                else
                {
                    ExcelHelper helper = new ExcelHelper();
                    var lines = helper.ReadFile(BasePath);

                    foreach (string line in lines)
                    {
                        RowIndex++;
                        FileData Data = new FileData();
                        Data.RowIndex = RowIndex;
                        Data.Data = line.Split('\t');
                        FileData.Add(Data);

                    }


                }


                return new JsonResult
                {
                    Data = new { Result = true, Data = FileData },
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };
            }
            catch (Exception e)
            {
                return new JsonResult
                {
                    Data = new { Result = false },
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };

            }
        }


        [Authorization(Pages.SupplierAssessment)]
        public ActionResult List()
        {
            ViewBag.Title = "Supplier Assessment";
            ViewBag.Parent = Parent;
            return View("_PartilSupplierAssessment");
        }

        public async Task<JsonResult> ListAssessment(SupplierAssessmentParam param)
        {
            return new JsonResult
            {
                Data = await json.SupplierAssessment(param),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<ActionResult> PrintAssessmentReport(int ID)
        {

            SupplierAssementDTO data = await json.SupplierAssessment(ID);


            rpSupplierAssessment report = new rpSupplierAssessment { DataSource = data.assessment, Document = { }, PageSettings = { Margins = { Bottom = 0.175F, Left = 0.175F, Right = 0.175F, Top = 0.175F }, Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait, PaperKind = System.Drawing.Printing.PaperKind.A4 } };
            report.UserData = data;
            ViewBag.ReportName = "Supplier Assessment Report";

            ViewBag.Report = report;
            return PartialView("~/Views/Employee/WebViewer.ascx");
        }


        [HttpGet]
        public async Task<ActionResult> SubmitQuote(string ID)
        {
            ViewBag.Name = await AppData.CompanyName();
            ViewBag.Message = "Sorry! you have no rights to access";
            ViewBag.Detail = null;
            ViewBag.ID = ID;
            if (ID == null || ID.Length != 36)
            {

                return View("Error");
            }
            else
            {

                QuoteRequest detil = await json.QuoteRequest(ID);
                if (!detil.Status)
                {
                    ViewBag.Message = "Sorry! you have provide a wrong url, please contact PWS for correct url to submit quote.";
                    return View("Error");
                }
                else
                {
                    ViewBag.Supplier = detil.Supplier.Name;
                    ViewBag.Detail = JsonConvert.SerializeObject(detil);
                }
            }

            return View();
        }
        [HttpPost]
        public async Task<JsonResult> SubmitQuote(string ID, int IPO)
        {
            Quote quote = JsonConvert.DeserializeObject<Quote>(Request["quote"]);

            int QuoteID = await json.SubmitQuote(ID, quote);

            if (Request.Files.Count > 0 && QuoteID > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                bool result = await FileHelper.SaveFile(Request.Files[0], IPO, IPO, DirectoryNames.SupplierQuote);
            }
            return new JsonResult
            {
                Data = QuoteID > 0,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}