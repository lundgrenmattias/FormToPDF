using FormToPDF.Models;
using FormToPDF.Models.Extensions;
using FormToPDF.Services;
using FormToPDF.Services.Abstractions;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FormToPDF.Facades
{
    public class DefaultRequestForQuotationFacade : IRequestForQuotationsFacade
    {
        private readonly IMailerService _mailerService;
        private readonly IRfqPdfGenerator _rfqPdfGenerator;
        private readonly SmtpConfiguration _smtpConfiguration;

        public DefaultRequestForQuotationFacade(IMailerService mailerService,
            IRfqPdfGenerator rfqPdfGenerator,
            IOptions<SmtpConfiguration> smtpConfiguration)
        {
            _mailerService = mailerService;
            _rfqPdfGenerator = rfqPdfGenerator;
            _smtpConfiguration = smtpConfiguration.Value;
        }

        public Task CreateAndSend(RequestForQuotation request)
        {
            var rfqPdf = _rfqPdfGenerator.Generate(request);

            var rfqAttachment = new Attachment(
                $"{MailResources.ProposalPrefix}-{request.CompanyName.WithFallback(MailResources.EmptyCompanyNameFilename)}.pdf",
                rfqPdf);
            var body = GenerateMailBody(request, _smtpConfiguration.Auditor);

            return _mailerService.Send(
            new MailAddress(request.ContactPerson, request.Email),
            MailResources.Subject,
            body,
            new[] { rfqAttachment });
        }

        private void CreateCopyToFileSystem(Stream rfqPdf)
        {
            using var fileStream = File.Create($@"C:\repos\FormToPDF\FormToPDF\wwwroot\documents\RFQ-{DateTime.Now:MM/dd/yyyy}.pdf");
            rfqPdf.Seek(0, SeekOrigin.Begin);
            rfqPdf.CopyTo(fileStream);
            rfqPdf.Seek(0, SeekOrigin.Begin);
        }

        private static string GenerateMailBody(RequestForQuotation request, string auditor)
        {
            var firstName = request.ContactPerson.GetFirstName() == string.Empty
                ? string.Empty
                : $"{request.ContactPerson.GetFirstName()}";

            return string.Format(MailResources.BodyTemplate, firstName, auditor);
        }
    }
}
