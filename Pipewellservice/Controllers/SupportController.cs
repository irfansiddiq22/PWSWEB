using Newtonsoft.Json;
using Pipewellservice.Helper;
using PipewellserviceModels.Common;
using PipewellserviceModels.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Controllers
{
    public class SupportController : BaseController
    {
        // GET: Support
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Submit()
        {
            SupportTicket ticket = JsonConvert.DeserializeObject<SupportTicket>(Request["report"]);
            string Body = $"Please review the following request ticket submitted by the user { SessionHelper.UserName } <br> Name:${ticket.Name} <br>Problem:{ticket.Problem}<br><br>";
            HttpPostedFileBase file=null;
            if (Request.Files.Count>0 )
            {
                 file = Request.Files[0];
                
            }
            EmailHelper email = new EmailHelper();
            bool result = await email.SendSupportEmail(file, (new EmailDTO() { To = "irfan_siddiq_21@yahoo.com", From = "no-reply@pipewellservices.com", Subject = "PWS WEB Support Ticket", Body = Body }));

            return new JsonResult
            {
                Data = true,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}