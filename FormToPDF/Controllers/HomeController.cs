using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FormToPDF.Models;
using System.Threading.Tasks;
using System;
using FormToPDF.Facades;

namespace FormToPDF.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRequestForQuotationsFacade _rfqFacade;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IRequestForQuotationsFacade requestForQuotationsFacade, 
            ILogger<HomeController> logger)
        {
            _rfqFacade = requestForQuotationsFacade;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOffer(RequestForQuotation rfq)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", rfq);
            }

            try
            {
                await _rfqFacade.CreateAndSend(rfq);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw;
            }

            return View("Confirmation");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
