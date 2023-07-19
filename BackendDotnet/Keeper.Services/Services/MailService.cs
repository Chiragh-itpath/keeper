using Keeper.Context.Model;
using Keeper.Services.Services.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Keeper.Repos.Repositories;
using Keeper.Services.Interfaces;

namespace Keeper.Services.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly IUserService _userService;
        public MailService(IOptions<MailSettings> mailSettings,IUserService userService)
        {
            _mailSettings = mailSettings.Value;
            _userService = userService;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            foreach (string multiemailid in mailRequest.ToEmail)
            {
                var data= await _userService.GetByEmailAsync(multiemailid);
                email.To.Add(MailboxAddress.Parse(multiemailid));
                email.Subject = "Inviting You on Keeper";
                var builder = new BodyBuilder();
                string href = $"http://localhost:5173/verification/{(int)mailRequest.Type}/{data.Id}/{mailRequest.TypeId}";
                builder.HtmlBody = $"<div style=\"font-family: Helvetica,Arial,sans-serif;min-width:1000px;overflow:auto;line-height:2\">\r\n  <div style=\"margin:50px auto;width:70%;padding:20px 0\">\r\n    <div style=\"border-bottom:1px solid #eee\">\r\n      <a href=\"\" style=\"font-size:1.4em;color: #4DB6AC;text-decoration:none;font-weight:600\">Keeper</a>\r\n    </div>\r\n    <p style=\"font-size:1.1em\">Hello There,</p>\r\n    <p>You are invited on Keeper.please appreciate these opportunity and confirm Your response.</p>\r\n   <a href='{href}'> <h4 style=\"background: #4DB6AC;margin: 0 auto;width: max-content;padding: 0 20px;color: #fff;border-radius: 4px;\">Confirm</h4></a>\r\n    <p style=\"font-size:0.9em;\">Regards,<br />Keeper Team</p>\r\n    <hr style=\"border:none;border-top:1px solid #eee\" />\r\n    <div style=\"float:right;padding:8px 0;color:#aaa;font-size:0.8em;line-height:1;font-weight:300\">\r\n      <p>SMS</p>\r\n      <p>Ahmedabad</p>\r\n      <p>India</p>\r\n    </div>\r\n  </div>\r\n</div>";
                email.Body = builder.ToMessageBody();
                SmtpClient smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
           
        }
    }
}
