using FbSoft_MediatrHandling.Entities;
using FbSoft_MediatrHandling.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
using System.Net.Mail;

namespace FbSoft_Backend.Email
{
    public class MailService : IMailService
    {
        private MailSettings _emailSettings;
        public MailService(IOptions<MailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public bool SendMail(EmailDTO data)
        {
            using(var emailMessage = new MimeMessage())
            {
                MailboxAddress emailFrom = new MailboxAddress(_emailSettings.SenderEmail, _emailSettings.SenderEmail);
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress(data.EmailToName, data.EmailToId);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = data.EmailSubject;

                BodyBuilder bodybuilder = new BodyBuilder();
                bodybuilder.TextBody = data.EmailBody;

                emailMessage.Body = bodybuilder.ToMessageBody();

                using (var mailClient = new SmtpClient(_emailSettings.Server, _emailSettings.Port))
                {

                    mailClient.EnableSsl = true;
                    mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    mailClient.UseDefaultCredentials = false;
                    mailClient.Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.Password);
                    mailClient.Send(emailMessage.From.ToString(), emailMessage.To.ToString(), emailMessage.Subject, emailMessage.Body.ToString());
                }
            }
            return true;
        }
    }
}
