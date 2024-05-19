using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pipewellservice.Helper
{
  public  class EmailHelper
    {
        public async Task<bool> SendEmail(EmailDTO email)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //MailMessage mail = new MailMessage("service.eng2@pipewellservices.com", email.To, email.Subject, email.Body);
            MailMessage mail = new MailMessage("notifications.pws@gmail.com", email.To, email.Subject, email.Body);
            mail.IsBodyHtml = true;
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com", 587);
            //SmtpClient smtpServer = new SmtpClient("smtp.office365.com", 587);
            if(email.Attachment!=null && email.Attachment != "")
            {
                mail.Attachments.Add(new Attachment( email.Attachment));
            }
            smtpServer.EnableSsl =  true;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new NetworkCredential("notifications.pws@gmail.com",  Config.SMTPPassword );
           // smtpServer.Credentials = new NetworkCredential("service.eng2@pipewellservices.com", "W!451462604975ud");
            try
            {
                // Send the email
                smtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> SendEmail(EmailDTO email,List<MergeField> mergeFields )
        {
            
            foreach (MergeField field in mergeFields)
            {
                email.Body = Regex.Replace(email.Body,$"#{field.Field}#", StringHelper.NullToString ( field.Value), RegexOptions.IgnoreCase);
            }
            return await SendEmail(email);
        }
    }
}
