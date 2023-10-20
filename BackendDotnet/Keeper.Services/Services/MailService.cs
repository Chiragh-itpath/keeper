using Keeper.Common.Enums;
using Keeper.Common.OtherModels;
using Keeper.Context.Model;
using Keeper.Services.Services.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Text;

namespace Keeper.Services.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(MailModel mail)
        {
            MimeMessage email = new()
            {
                Sender = MailboxAddress.Parse(_mailSettings.Mail),
                Subject = mail.Subject,
                Body = MessageBodyHelper(mail.Category,mail.Subject,mail.From,mail.Message)
            };
            email.To.Add(MailboxAddress.Parse(mail.To));
            using var client = new SmtpClient();
            client.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            client.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await client.SendAsync(email);
            client.Disconnect(true);
        }
        private static MimeEntity MessageBodyHelper(MailCategory category,string subject = "", string from = "keeper@yopmail.com", string extra = "")
        {
            StringBuilder messageBody = new();
            messageBody.Append("<div style=\"font-family: Helvetica, Arial, sans-serif; min-width: 1000px;overflow: auto;line-height: 2;\">");
            messageBody.Append("<div style=\"margin: 50px auto; width: 70%; padding: 20px 0\">");
            messageBody.Append("<div style=\"border-bottom: 1px solid #eee\">");
            messageBody.Append("<a href=\"http://localhost:5173/\" target=\"_blank\"  ");
            messageBody.Append("style=\"font-size: 1.4em; color: #4db6ac;text-decoration: none; font-weight: 600;\">Keeper</a></div>");
            messageBody.Append("<p style=\"text-align: center; font-size: 30px;\">");
            messageBody.Append($"<b>{subject}</b></p>");
            if (category == MailCategory.SendInvitation)
            {

                messageBody.Append($"<p> <a style=\"color: #4db6ac;\" href=\"mailto:{from}\">{from} &nbsp</a>");
                messageBody.Append("has invited you to collaborate on");
                messageBody.Append($"<span style=\"color: #4db6ac\"> {extra} </span> </p> ");
                messageBody.Append("<p>Please Check your notification on &nbsp");
                messageBody.Append("<a href=\"http://localhost:5173/\" target=\"_blank\" style=\"color: #4db6ac;\" >Site</a></p>");
            }
            if (category == MailCategory.AcceptInvitation)
            {
                messageBody.Append($"<p> <a style=\"color: #4db6ac;\" href=\"mailto:{from}\">{from}</a>&nbsp;has Accepted your Invitation </p>");
            }
            if(category == MailCategory.RejectInvitation)
            {
                messageBody.Append($"<p> <a style=\"color: #4db6ac;\" href=\"mailto:{from}\">{from}</a>has Rejected your Invitation </p>");
            }
            if(category == MailCategory.OTP)
            {
                messageBody.Append("<p>Here is you verification code please copy it and verify your Email</p>");
                messageBody.Append("<p style=\"background:#5ddbcd;text-align:center;min-height:50px;");
                messageBody.Append("display:flex;justify-content:center;align-items:center;\">");
                messageBody.Append($"<span> Code:<b> {extra}</b></span></p>");
            }
            messageBody.Append("<hr style=\"border: none; border-top: 1px solid #eee\" />");
            messageBody.Append("<div style=\"float: right; padding: 8px 0; color: #aaa; font-size: 0.8em; line-height: 1; font-weight: 300;\">");
            messageBody.Append("<p>Ahmedabad</p> <p>India</p>");
            messageBody.Append("</div></div></div>");
            var messageBodyBuilder = new BodyBuilder
            {
                HtmlBody = messageBody.ToString()
            };
            return messageBodyBuilder.ToMessageBody();
        }
    }
}
