using Portfolio.Core.LogicAbstractions;
using Portfolio.Data.Configurations;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Portfolio.BusinessLogic.MainPage.SendContactingMail
{
    public class SendContactingMailCommand : Logic<SendContactingMailRequest, SendContactingMailResult>
    {
        private SmtpConfiguration SmtpConfiguration { get; }

        public SendContactingMailCommand(SmtpConfiguration smtpConfiguration)
        {
            SmtpConfiguration = smtpConfiguration;
        }

        protected override async Task<SendContactingMailResult> Execute(SendContactingMailRequest request)
        {
            var emailMessage = new MailMessage
            {
                To =
                {
                    new MailAddress(SmtpConfiguration.Address)
                },
                From = new MailAddress(request.Email),
                Subject = request.Name + " - " + request.Subject,
                Body = request.Details,
                IsBodyHtml = true
            };

            using (var smtp = new SmtpClient
            {
                Credentials = new NetworkCredential
                {
                    UserName = SmtpConfiguration.Username,
                    Password = SmtpConfiguration.Password
                },
                Host = SmtpConfiguration.Host,
                Port = SmtpConfiguration.Port,
                EnableSsl = SmtpConfiguration.EnableSsl
            })
            {
                await smtp.SendMailAsync(emailMessage);
                return new SendContactingMailResult();
            }
        }
    }
}
