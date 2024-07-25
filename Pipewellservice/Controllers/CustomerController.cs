using Newtonsoft.Json;
using Pipewellservice.App_Start;
using Pipewellservice.Helper;
using PipewellserviceJson.Customer;
using PipewellserviceModels.Common;
using PipewellserviceModels.Customer;

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
    public class CustomerController : Controller
{
        private string Parent = JsonConvert.SerializeObject(new { URL = "/Procurement/home", Title = "Procurement" });
       public CustomerJson json = new CustomerJson();
        public async Task<ActionResult> registration()
        {
            ViewBag.Title = "";
            ViewBag.Parent = null;
            ViewBag.RECAPTCHA = ConfigurationManager.AppSettings["RECAPTCHA"];

            ViewBag.Name = await AppData.CompanyName();
            return View();
        }
        public async Task<JsonResult> SaveRegistration(CustomerRegistrationDTO dto)
        {
            int result = await json.SaveRegistration(dto );
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
        public async Task<JsonResult> UploadRegistrationFiles(int ID)
        {
            HttpPostedFileBase CRFile, ZakatFile, VATFile;
            CRFile = Request.Files["CRFile"];
            ZakatFile = Request.Files["ZakatFile"];
            VATFile = Request.Files["VATFile"];

            RegistrationFile file = new RegistrationFile();
            if (CRFile != null)
            {
                file.CRFile = CRFile.FileName;
                file.CRFileID = Path.GetExtension(CRFile.FileName);
                file.CRFileID = $"CR-File{file.CRFileID}";

                await FileHelper.SaveFile(CRFile, file.CRFileID, ID, DirectoryNames.CustomerRegistration);
            }

            if (ZakatFile != null)
            {
                file.ZakatFile = ZakatFile.FileName;
                file.ZakatFileID = Path.GetExtension(ZakatFile.FileName);
                file.ZakatFileID = $"Zakat-File{file.ZakatFileID}";
                await FileHelper.SaveFile(ZakatFile, file.ZakatFileID, ID, DirectoryNames.CustomerRegistration);
            }

            if (VATFile != null)
            {
                file.VATFile = VATFile.FileName;
                file.VATFileID = Path.GetExtension(VATFile.FileName);
                file.VATFileID = $"VAT-File{file.VATFileID}";
                await FileHelper.SaveFile(VATFile, file.VATFileID, ID, DirectoryNames.CustomerRegistration);
            }

            

            bool result = await json.SaveRegistrationFiles(ID, file);


            return new JsonResult
            {
                Data = new { Result = result },
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };


        }
    }
}