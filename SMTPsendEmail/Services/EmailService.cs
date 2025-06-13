using SMTPsendEmail.Models;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;

namespace SMTPsendEmail.Services
{
    public class EmailService
    {
        private readonly EmailSettings _settings;
        public EmailService(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }
        public void SendEmail(string toEmail, string subject, string body)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_settings.FromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mail.To.Add(toEmail);

            using var smtp = new SmtpClient(_settings.Host, _settings.Port)
            {
                Credentials = new NetworkCredential(_settings.Username, _settings.Password),
                EnableSsl = _settings.EnableSSL
            };
            smtp.Send(mail);
            //await smtp.SendMailAsync(mail);
        }
    }
}
