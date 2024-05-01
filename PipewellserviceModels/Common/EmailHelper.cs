using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Common
{
  public  class EmailHelper
    {
        public async Task<bool> SendEmail(EmailDTO email)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage(email.From, email.To, email.Subject, email.Body);
            SmtpClient smtpServer = new SmtpClient("smtp.office365.com");
            smtpServer.Port = 587; // Port for SMTP

            // Enable SSL
            smtpServer.EnableSsl = true;

            // Set the credentials
            smtpServer.Credentials = new NetworkCredential("no-reply@pipewellservices.com", "Tof28006");

            try
            {
                // Send the email
                smtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
