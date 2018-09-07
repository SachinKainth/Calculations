using System.Collections.Generic;
using Calculations;
using FluentAssertions;
using NUnit.Framework;

namespace CalculationsTests.UnitTests
{
    [TestFixture]
    class CalculationsServiceTests
    {
        private CalculationsService _calculationsService;

        [SetUp]
        public void Setup()
        {
            _calculationsService = new CalculationsService();
        }

        [Test]
        public void Mean_WhenEmptyList_ReturnsZero()
        {
            _calculationsService.Mean(new List<decimal>()).Should().Be(0);
        }

        [Test]
        public void Mean_WhenNonEmptyList_ReturnsMean()
        {
            _calculationsService.Mean(new List<decimal>
            {
                23.54m, 98.32m, 18.11m, 45.64m
            }).Should().Be(46.4025m);
        }

        [Test]
        public void StandardDeviation_WhenEmptyList_ReturnsZero()
        {
            _calculationsService.StandardDeviation(new List<decimal>()).Should().Be(0m);
        }

        [Test]
        public void StandardDeviation_WhenNonEmptyList_ReturnsStandardDeviation()
        {
            _calculationsService.StandardDeviation(new List<decimal>
            {
                23.54m, 98.32m, 18.11m, 45.64m
            }).Should().Be(31.698452939378603055566248494m);
        }

        [Test]
        public void Frequencies_WhenEmptyList_ReturnsZeroForAllBands()
        {
            var frequencyBands = _calculationsService.Frequencies(new List<decimal>());

            Common.CheckFrequencies(frequencyBands, 0,0,0,0,0,0,0,0,0,0);
        }

        [Test]
        public void Frequencies_WhenNonEmptyList_ReturnsCorrectFrequenciesForAllBands()
        {
            var frequencyBands = _calculationsService.Frequencies(new List<decimal>
            {
                23.54m, 98.32m, 18.11m, 45.64m, 21.33m
            });

            Common.CheckFrequencies(frequencyBands, 0, 1, 2, 0, 1, 0, 0, 0, 0, 1);
        }

        [Test]
        public void Frequencies_WhenNumbersOnBandBoundaries_ReturnsCorrectFrequenciesForAllBands()
        {
            var frequencyBands = _calculationsService.Frequencies(new List<decimal>
            {
                0m, 10m, 80m, 40m, 30m, 70m, 10m
            });

            Common.CheckFrequencies(frequencyBands, 1, 2, 0, 1, 1, 0, 0, 1, 1, 0);
        }

        [Test]
        public void Frequencies_WhenWeMatchToTheHighestBand_MatchesToTheHighestBand()
        {
            var frequencyBands = _calculationsService.Frequencies(new List<decimal>
            {
                100m, 100m
            });

            Common.CheckFrequencies(frequencyBands, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2);
        }
    }
}
