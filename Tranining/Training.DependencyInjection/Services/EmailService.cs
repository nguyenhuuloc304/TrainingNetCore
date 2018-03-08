using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Training.DependencyInjection.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string toEmail, string subject, string content)
        {
            string senderID = "bombivietnam@gmail.com";
            string senderPassword = "";
            //string result = "Email Sent Successfully";

            string body = "  has sent an email from " + toEmail;            
            body += content;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(toEmail);
                mail.From = new MailAddress(senderID);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential(senderID, senderPassword);
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {                
             
            }
        }
    }
}
