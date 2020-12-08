using FormToPDF.Models;
using FormToPDF.Services.Abstractions;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormToPDF.Services
{
    public class MailkitMailerService : IMailerService
    {
        private readonly SmtpConfiguration _smtpOptions;

        public MailkitMailerService(IOptions<SmtpConfiguration> smtpOptions)
        {
            _smtpOptions = smtpOptions.Value;
        }

        public async Task Send(MailAddress recipient, string subject, string body, IEnumerable<Attachment> attachments)
        {
            var message = new MimeMessage
            {
                Subject = MailResources.Subject
            };

            message.From.Add(new MailboxAddress(MailResources.SenderName, _smtpOptions.Auditor));

            var builder = new BodyBuilder
            {
                TextBody = body
            };

            foreach (var attachment in attachments)
            {
                builder.Attachments.Add(attachment.FileName, attachment.Stream);
            }

            message.Body = builder.ToMessageBody();

            await SendToRequester(message, recipient);
        }

        private Task SendToRequester(MimeMessage message, MailAddress recipient)
        {
            message.To.Clear();
            message.To.Add(new MailboxAddress(recipient.Name, recipient.Address));

            return Send(message);
        }

        private async Task Send(MimeMessage message)
        {
            using var client = new SmtpClient();

            await client.ConnectAsync(_smtpOptions.Host, _smtpOptions.Port, _smtpOptions.UseSSL);
            await client.AuthenticateAsync(_smtpOptions.Credentials.Username, _smtpOptions.Credentials.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
