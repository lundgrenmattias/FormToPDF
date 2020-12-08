using FormToPDF.Models;
using System.IO;

namespace FormToPDF.Services.Abstractions
{
    public interface IRfqPdfGenerator
    {
        public Stream Generate(RequestForQuotation rfq);
    }
}
