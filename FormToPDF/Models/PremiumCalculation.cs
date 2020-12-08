namespace FormToPDF.Models
{
    public class PremiumCalculation
    {
        public decimal YearlyPremium { get; set; }
        public decimal MonthlyPremium { get; set; }
        public string Comment { get; set; }

        public PremiumCalculation(decimal yearlyPremium, string comment = default)
        {
            YearlyPremium = yearlyPremium;

            if(YearlyPremium > 0)
            {
                MonthlyPremium = YearlyPremium / 12m;
            }

            Comment = comment ?? string.Empty;
        }
    }
}
