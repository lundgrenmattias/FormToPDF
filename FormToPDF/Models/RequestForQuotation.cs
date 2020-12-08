using System;

namespace FormToPDF.Models
{
    public class RequestForQuotation
    {
        public RequestForQuotation()
        {
            Created = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public Decimal YearlyRevenue { get; set; }
        public AmountOfInsurance AmountOfInsurance { get; set; }
        public Decimal EstimatedPremium { get; set; }
    }
}
