using FormToPDF.Models;
using FormToPDF.Services;
using NUnit.Framework;

namespace FormToPDF.Test
{
    public class StandardInsuranceCalculatorTests
    {
        IInsurancePremiumCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new StandardInsurancePremiumCalculator();
        }

        [TestCase(1000, 2200)]
        [TestCase(500000, 2200)]
        [TestCase(1100000, 3256)]
        [TestCase(2499000, 7257.14)]
        [TestCase(2501000, 6987.31)]
        [TestCase(4999000, 12757.69)]
        [TestCase(7999000, 19137.91)]
        [TestCase(8001000, 18811.87)]
        [TestCase(11999000, 26288.13)]
        [TestCase(14999000, 29258.46)]
        [TestCase(15001000, 29701.32)]
        [TestCase(19999000, 36298.68)]
        [TestCase(20001000, 40701.21)]
        [TestCase(29999000, 52798.79)]
        [TestCase(30001000, 52801.21)]
        [TestCase(39999000, 64898.79)]
        [TestCase(40000000, 64900)]
        public void GivenYearlyRevenue_WhenAmountOfInsuranceEqualsUnknown_ThenShouldCalculateCorrectly(decimal yearlyRevenue, decimal expectedPremium)
        {
            //arrange
            var amountOfInsurance = AmountOfInsurance.One;

            //act
            var actualPremium = _sut.CalculateYearlyPremium(yearlyRevenue, amountOfInsurance);

            //assert
            Assert.AreEqual(expectedPremium, actualPremium.YearlyPremium);
        }
    }
}