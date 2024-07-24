using Newtonsoft.Json;
using Pipewellservice.App_Start;
using Pipewellservice.Helper;
using PipewellserviceJson.Common;
using PipewellserviceJson.Home;
using PipewellserviceJson.HR.Setting;
using PipewellserviceModels.Common;
using PipewellserviceModels.Home;
using PipewellserviceModels.User;
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
    public class HomeController : Controller
    {
        [Authorization]

        public ActionResult Index()
        {
            ViewBag.Title = "";
            ViewBag.Parent = null;
            return View();
        }
        public ActionResult Profile()
        {
            ViewBag.Title = "My Profile";
            ViewBag.Parent = null;// JsonConvert.SerializeObject(new { URL = "/home", Title = "Home" }); ;
            return View();
        }
        public async Task <JsonResult> UpdateProfile(User user)
        {
            user.ID = new SessionHelper().UserID();
            return new JsonResult
            {
                Data = await (new SettingJson()).UpdateProfile(user),
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }

        public async Task<ActionResult> PersonalDetail()
        {
            ViewBag.Title = "";
            ViewBag.Parent = null;
            ViewBag.RECAPTCHA = ConfigurationManager.AppSettings["RECAPTCHA"];
            ViewBag.Name = await AppData.CompanyName();
            ViewBag.Countries = await (new DataListJson()).CountryList();
            return View();
        }
        public async Task<JsonResult> SavePersonalDetails(PersonalDetail PersonalDetail, List<PersonalWorkExperience> WorkExperience)
        {


            bool result = await (new HomeJson()).SavePersonalDetails(PersonalDetail, WorkExperience);
            string EmailBody = $"Dear {PersonalDetail.Name}, <br> Thank you for using self service to update CV data with our system. <br><br>Best regards!<br><br>{await AppData.CompanyName()}";
            if (result)

            {
                EmailHelper email = new EmailHelper();
                await email.SendEmail(new EmailDTO() { To = PersonalDetail.EmailAddress, From = "no-reply@pipewellservices.com", Subject = "CV DATA has been received", Body = EmailBody });

            }

            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }

        public async Task<JsonResult> SaveSupplierAssesment(SupplierAssesment assesment)
        {
            int result = await (new HomeJson()).SaveSupplierAssesment(assesment);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
        public async Task<ActionResult> SupplierAssesment()
        {
            ViewBag.Title = "";
            ViewBag.Parent = null;
            ViewBag.RECAPTCHA = ConfigurationManager.AppSettings["RECAPTCHA"];

            ViewBag.Name = await AppData.CompanyName();
            return View("_SupplierAssesment");
        }


        public async Task<JsonResult> UploadSupplierAssessmentFiles(int ID)
        {
            HttpPostedFileBase CRFile, ZakatFile, ChamberMemberShipFile, QualityManagementCertificateFile, MajorCustomerFile, ProductionFile, QualityControlFile, NationalAddressFile;
            CRFile = Request.Files["CRFile"];
            ZakatFile = Request.Files["ZakatFile"];
            ChamberMemberShipFile = Request.Files["ChamberMemberShipFile"];
            QualityManagementCertificateFile = Request.Files["QualityManagementCertificateFile"];
            MajorCustomerFile = Request.Files["MajorCustomerFile"];
            ProductionFile = Request.Files["ProductionFile"];
            QualityControlFile = Request.Files["QualityControlFile"];
            NationalAddressFile= Request.Files["NationalAddressFile"];

            AssessmentFile file = new AssessmentFile();
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

            bool result = await (new HomeJson()).SaveSupplierAssesmentFiles(ID,file);


            return new JsonResult
            {
                Data = new { Result = result },
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };


        }
        public async Task<JsonResult> UploadSupplierDataFile()
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



        public ActionResult AccessDenied()
        {

            ViewBag.Title = "";
            ViewBag.Parent = null;
            return View();
        }
    }
}