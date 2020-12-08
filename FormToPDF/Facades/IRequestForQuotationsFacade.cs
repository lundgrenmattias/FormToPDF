using FormToPDF.Models;
using System.Threading.Tasks;

namespace FormToPDF.Facades
{
    public interface IRequestForQuotationsFacade
    {
        Task CreateAndSend(RequestForQuotation requestForQuotation);
    }
}
