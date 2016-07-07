using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace SPV.WebMVC.Helper
{
    public class MailHelper
    {
        public static void SendMail(string mailFrom, string passwordMailFrom, string mailTo, string subject, string body, bool isBodyHtml, MailPriority priority)
        {
            try
            {
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.To.Add(new MailAddress(mailTo));
                    mailMessage.From = new MailAddress(mailFrom);
                    mailMessage.Subject = 
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = isBodyHtml;
                    mailMessage.Priority = MailPriority.Normal;

                    using (var smtp = new SmtpClient())
                    {
                        smtp.Host = ConfigurationManager.AppSettings.Get("Host");
                        smtp.Credentials = new NetworkCredential(mailFrom, passwordMailFrom);
                        smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Port"));
                        smtp.EnableSsl = true;

                        smtp.Send(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}