using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace MVC_Sepet.Utils
{
    public class MailSender
    {
        public static void SendEmail(string email, string subject, string message)
        {
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress("yzl3156yzl@gmail.com", "YZL3156");
            sender.To.Add(email);
            sender.Subject = subject;
            sender.Body = message;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("yzl3156yzl@gmail.com", "Yzl3156--");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            smtp.Send(sender);
        }
    }
}