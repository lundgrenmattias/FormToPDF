using FormToPDF.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormToPDF.Services.Abstractions
{
    public interface IMailerService
    {
        Task Send(MailAddress recipient, string subject, string body, IEnumerable<Attachment> attachments);
    }
}
