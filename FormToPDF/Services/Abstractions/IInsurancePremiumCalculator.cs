using FormToPDF.Models;

namespace FormToPDF.Services
{
    public interface IInsurancePremiumCalculator
    {
        PremiumCalculation CalculateYearlyPremium(decimal yearlyRevenue, AmountOfInsurance amountOfInsurance);
    }
}
