using FormToPDF.Models;
using System;

namespace FormToPDF.Services
{
    public class StandardInsurancePremiumCalculator : IInsurancePremiumCalculator
    {
        public PremiumCalculation CalculateYearlyPremium(decimal yearlyRevenue, AmountOfInsurance amountOfInsurance)
        {
            var yearlyRevenueInThosands = yearlyRevenue / 1000m;

            var basePremium = CalculateBasePremium(yearlyRevenueInThosands);

            return new PremiumCalculation(ApplyAdjustment(basePremium, amountOfInsurance));
        }
        private static decimal ApplyAdjustment(decimal basePremium, AmountOfInsurance amountOfInsurance)
        {
            return basePremium * CalculateAdjustmentForAmountOfInsurance(amountOfInsurance);
        }

        private static decimal CalculateBasePremium(decimal yearlyRevenueInThosands)
        {
            if (yearlyRevenueInThosands < 1100)
            {
                return 2000;
            }

            if (yearlyRevenueInThosands < 2501)
            {
                return 100 + (yearlyRevenueInThosands * 2.6m);
            }

            if (yearlyRevenueInThosands < 5001)
            {
                return 1100 + (yearlyRevenueInThosands * 2.1m);
            }

            if (yearlyRevenueInThosands < 8001)
            {
                return 2200 + (yearlyRevenueInThosands * 1.9m);
            }

            if (yearlyRevenueInThosands < 12001)
            {
                return 3500 + (yearlyRevenueInThosands * 1.7m);
            }

            if (yearlyRevenueInThosands < 15001)
            {
                return 5600 + (yearlyRevenueInThosands * 1.4m);
            }

            if (yearlyRevenueInThosands < 20001)
            {
                return 9000 + (yearlyRevenueInThosands * 1.2m);
            }

            if (yearlyRevenueInThosands < 300001)
            {
                return 15000 + (yearlyRevenueInThosands * 1.1m);
            }

            if (yearlyRevenueInThosands < 40001)
            {
                return 18000 + (yearlyRevenueInThosands * 0.9m);
            }

            return 0;
        }

        private static decimal CalculateAdjustmentForAmountOfInsurance(AmountOfInsurance amountOfInsurance)
        {
                switch (amountOfInsurance)
                {
                case AmountOfInsurance.One:
                    return 1.1m;
                case AmountOfInsurance.Two:
                    return 1.2m;
                case AmountOfInsurance.Three:
                    return 1.3m;
                case AmountOfInsurance.Four:
                    return 1.4m;
                case AmountOfInsurance.Five:
                    return 1.5m;
                default:
                    throw new ArgumentException(nameof(amountOfInsurance),
                        $"Unexpected enum value for AmountOfInsurance {amountOfInsurance.GetType()}");
                }
        }
    }
}


