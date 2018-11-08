using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsManagment.Data.Services
{
    class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // convert IdentityMessage to a MailMessage
            var email =
               new MailMessage(new MailAddress("noreply@mydomain.com", "(do not reply)"),
               new MailAddress(message.Destination))
               {
                   Subject = message.Subject,
                   Body = message.Body,
                   IsBodyHtml = true
               };

            using (var client = new SmtpClient()) // SmtpClient configuration comes from config file
            {
                return client.SendMailAsync(email);
            }
        }
    }
}
