using FormToPDF.Models;
using FormToPDF.Models.Extensions;
using FormToPDF.Services.Abstractions;
using GemBox.Document;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.IO;

namespace FormToPDF.Services
{
    public class GemBoxRfqPdfGenerator : IRfqPdfGenerator
    {
        private readonly IInsurancePremiumCalculator _premiumCalculator;
        private DocumentModel _document;
        private SpecialCharacter _lineBreak;
        private string _fileName;

        public GemBoxRfqPdfGenerator(IInsurancePremiumCalculator premiumCalculator)
        {
            _premiumCalculator = premiumCalculator;
        }

        public Stream Generate(RequestForQuotation rfq)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            _fileName = rfq.CompanyName;

            CreateDocument();

            var documentBody = new Section(_document);
            _document.Sections.Add(documentBody);

            var introduction = CreateIntroduction(rfq);
            var rfqDetails = CreateRfqDetails(rfq);
            var ending = CreateEnding();

            documentBody.Blocks.Add(introduction);
            documentBody.Blocks.Add(rfqDetails);
            documentBody.Blocks.Add(ending);

            var stream = new MemoryStream();
            _document.Save(stream, SaveOptions.PdfDefault);
            return stream;
        }

        private void CreateDocument()
        {
            _document = new DocumentModel
            {
                DefaultCharacterFormat =
                {
                    Size = 12,
                    FontColor = new Color(0, 54, 107)
                }
            };

            _lineBreak = new SpecialCharacter(_document, SpecialCharacterType.LineBreak);
        }

        private Paragraph CreateIntroduction(RequestForQuotation rfq)
        {
            var firstName = rfq.ContactPerson.GetFirstName();
            firstName = firstName.Length > 0 ? " " + firstName : "";

            return new Paragraph(
                _document,
                new Run(_document, $"{rfq.CompanyName}"),
                _lineBreak,
                new Run(_document, $"{rfq.Address}"),
                _lineBreak.Clone(),
                new Run(_document, $"{rfq.City}"),
                _lineBreak.Clone(),
                _lineBreak.Clone(),
                _lineBreak.Clone(),
                _lineBreak.Clone(),
                new Run(_document, $"Hello{firstName},"),
                _lineBreak.Clone(),
                _lineBreak.Clone(),
                new Run(_document,
                    "This is sample output from FormToPDF.")
            );
        }

        private Paragraph CreateRfqDetails(RequestForQuotation rfq)
        {
            var premium = _premiumCalculator.CalculateYearlyPremium(rfq.YearlyRevenue, rfq.AmountOfInsurance);

            return new Paragraph(
                _document,
                new Run(_document, $"Information provided by the customer:"),
                _lineBreak.Clone(),
                _lineBreak.Clone(),
                new Run(_document, $"RFQ Created: {rfq.Created.ToString("d", DateTimeFormatInfo.InvariantInfo)}"),
                _lineBreak.Clone(),
                new Run(_document, $"Company Name: {rfq.CompanyName}"),
                _lineBreak.Clone(),
                new Run(_document, $"Email: {rfq.Email}"),
                _lineBreak.Clone(),
                new Run(_document, $"Annual revenue: {rfq.YearlyRevenue}"),
                _lineBreak.Clone(),
                new Run(_document, $"Amount of Insurance: {rfq.AmountOfInsurance}"),
                _lineBreak.Clone(),
                _lineBreak.Clone(),
                new Run(_document, $"Estimated yearly premium: {GetPremium(premium)}"),
                _lineBreak.Clone());
        }

        private Paragraph CreateEnding()
        {
            return new Paragraph(
                _document,
                new Run(_document, "Best,"),
                _lineBreak.Clone(),
                _lineBreak.Clone(),
                new Run(_document, "Mattias Lundgren"),
                _lineBreak.Clone(),
                new Run(_document, "mattias@mattiaslundgren.com"));
        }

        private string GetPremium(PremiumCalculation calculation)
        {
            return calculation.YearlyPremium == 0
                ? calculation.Comment
                : calculation.YearlyPremium.ToString(CultureInfo.CurrentCulture);
        }
    }
}
