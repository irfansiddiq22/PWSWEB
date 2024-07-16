using Pipewellservice.Helper;
using PipewellserviceJson.Common;
using PipewellserviceJson.Home;
using PipewellserviceModels.Common;
using PipewellserviceModels.Home;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        public async Task<ActionResult> PersonalDetail()
        {
            ViewBag.Title = "";
            ViewBag.Parent = null;
            ViewBag.RECAPTCHA = ConfigurationManager.AppSettings["RECAPTCHA"];
            ViewBag.Countries = await (new DataListJson()).CountryList();
            return View();
        }
        public async Task<JsonResult> SavePersonalDetails(PersonalDetail PersonalDetail, List<PersonalWorkExperience> WorkExperience)
        {
            bool result = await (new HomeJson()).SavePersonalDetails(PersonalDetail, WorkExperience);
            string EmailBody = $"Dear {PersonalDetail.Name}, <br> Thank you for using self service to update CV data with our systemm. <br><br>Best regards!<br><br>Pipe & Well O. & M. Services Co.";
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



        public ActionResult AccessDenied()
        {

            ViewBag.Title = "";
            ViewBag.Parent = null;
            return View();
        }
    }
}