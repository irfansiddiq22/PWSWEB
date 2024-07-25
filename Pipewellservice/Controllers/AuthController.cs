using Newtonsoft.Json;
using Pipewellservice.Helper;
using PipewellserviceJson;
using PipewellserviceJson.Auth;
using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Pipewellservice.Controllers
{
    public class AuthController : BaseController
    {
        AuthUserJson json = new AuthUserJson();
        // GET: Auth
        public async Task<ActionResult> Index()
        {
            if(!new CookieHelper().CheckCookie())
                return View();
            return RedirectToAction("Index", "Home");


        }

        public async Task<JsonResult> ProcessLogin(UserAuth user)
        {
            Session["EmployeeCode"] = null;
            var result = await json.ProcessLogin(user);
            if (result.ID > 0)
            {
                FormsAuthentication.SetAuthCookie(new EncryptionHelper().Encrypt(user.UserName + "`" + user.Password), user.RememberMe);
                
                SessionHelper.SetUserSession(result);

            }
            return new JsonResult
            {
                Data = (result.ID > 0),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }
        public async Task<JsonResult> VerifyOTP(OTP otp)
        {
            var result = await json.VerifyOTP(otp);
            if (result.ID > 0)
            {
                Session["EmployeeCode"] = null;
                SessionHelper.SetUserSession(result);
            }
            return new JsonResult
            {
                Data = (result.ID > 0),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> TestOTP(string EmailAddress)
        {

            EmailHelper email = new EmailHelper();
            var status = await email.SendEmail(new EmailDTO() { To = EmailAddress, From = "no-reply@pipewellservices.com", Subject = "PWS WEB TEST", Body = "TEST email server" });
            return new JsonResult
            {
                Data = status,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }
        public async Task<JsonResult> GenerateOTP(string EmailAddress)
        {
            string OTPPassword = StringHelper.GenerateOTP();
            var result = await json.SaveOTP(new OTP() { EmailAddress = EmailAddress, OTPPassword = OTPPassword });
            var OTPSuccess = false;
            if (result != "")
            {
                OTPSuccess = true;
                EmailHelper email = new EmailHelper();
                await email.SendEmail(new EmailDTO() { To = EmailAddress, From = "notifications.pws@gmail.com", Subject = "OTP to accees PWS WEB", Body = $"Dear {result}. <br/><br/> Use this OPT to access PWS web panel {OTPPassword}. This OPT will expire in next 10 minutes. <br> Ignore this email if you did not generate this OTP. <br/> thanks. " });
            }
            return new JsonResult
            {
                Data = OTPSuccess,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }
        public async Task<JsonResult> Identity()
        {
            return new JsonResult
            {
                Data = SessionHelper.UserSession(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<ActionResult> Logout()
        {
            FormsAuthentication.SignOut();

            SessionHelper h = new SessionHelper();
            h.LogOut();
            
            return RedirectToAction("Index");
        }
    }
}