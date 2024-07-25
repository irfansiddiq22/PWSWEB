﻿using Newtonsoft.Json;
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

        
        //public async Task<ActionResult> SupplierAssesment()
        //{
        //    ViewBag.Title = "";
        //    ViewBag.Parent = null;
        //    ViewBag.RECAPTCHA = ConfigurationManager.AppSettings["RECAPTCHA"];

        //    ViewBag.Name = await AppData.CompanyName();
        //    return View("_SupplierAssesment");
        //}



        public ActionResult AccessDenied()
        {

            ViewBag.Title = "";
            ViewBag.Parent = null;
            return View();
        }
    }
}