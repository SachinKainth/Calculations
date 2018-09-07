using System.Collections.Generic;
using Calculations;
using FluentAssertions;
using NUnit.Framework;

namespace CalculationsTests.IntegrationTests
{
    [TestFixture]
    class IntegrationTests
    {
        private NumbersService _numbersService;
        private IList<decimal> _numbers;
        private CalculationsService _calculationsService;

        [SetUp]
        public void Setup()
        {
            _calculationsService = new CalculationsService();

            var filePath = Common.GetFilePath("valid file.csv");
            _numbersService = new NumbersService(filePath);

            _numbers = _numbersService.ReadNumbers();
        }

        [Test]
        public void WhenIReadTheFileAndCalculateTheMean_ReturnsMean()
        {
            _calculationsService.Mean(_numbers).Should().Be(50.34472412237m);
        }

        [Test]
        public void WhenIReadTheFileAndCalculateTheStandardDeviation_ReturnsStandardDeviation()
        {
            _calculationsService.StandardDeviation(_numbers).Should().Be(28.799326861806445300971660547m);
        }

        [Test]
        public void WhenIReadTheFileAndCalculateTheFrequencies_ReturnsFrequencies()
        {
            var frequencyBands = _calculationsService.Frequencies(_numbers);
            Common.CheckFrequencies(frequencyBands, 94, 107, 99, 94, 96, 101, 109, 101, 100, 99);
        }
    }
}
