using System.Collections.Generic;
using System.Linq;

namespace Calculations
{
    public class CalculationsService
    {
        public decimal Mean(IList<decimal> data)
        {
            if (!data.Any())
            {
                return 0;
            }

            var total = 0m;
            foreach (var number in data)
            {
                total += number;
            }

            return total / data.Count;
        }

        public decimal StandardDeviation(IList<decimal> data)
        {
            if (!data.Any())
            {
                return 0;
            }

            var mean = Mean(data);
            var squareOfDifferencesFromMean = SquareOfDifferencesFromMean(data, mean);
            var variance = Mean(squareOfDifferencesFromMean);
            var squareRoot = SquareRoot(variance);

            return squareRoot;
        }

        public IList<FrequencyBand> Frequencies(IList<decimal> numbers)
        {
            var frequencyBands = new List<FrequencyBand>();

            InitialiseFrequencyBands(frequencyBands);
            CalculateFrequencies(numbers, frequencyBands);

            return frequencyBands;
        }

        private static void CalculateFrequencies(
            IEnumerable<decimal> numbers, IList<FrequencyBand> frequencyBands)
        {
            foreach (var number in numbers)
            {
                for (var i = 0; i < frequencyBands.Count; i++)
                {
                    var band = frequencyBands[i];
                    var isLastBand = i == frequencyBands.Count - 1;
                   
                    if (number >= band.LowerBand &&
                        (!isLastBand && number < band.HigherBand ||
                         isLastBand && number <= band.HigherBand))
                    {
                        frequencyBands[i] = new FrequencyBand(
                            band.LowerBand, band.HigherBand, band.Frequency + 1);
                    }
                }
            }
        }

        private static void InitialiseFrequencyBands(IList<FrequencyBand> frequencyBands)
        {
            const int bandSize = 10;

            for (var i = 0; i < 100; i += bandSize)
            {
                frequencyBands.Add(new FrequencyBand(i, i + bandSize, 0));
            }
        }

        private static decimal SquareRoot(decimal number)
        {
            var previousGuess = number / 2m;
            while (true)
            {
                var newGuess = (previousGuess + number / previousGuess) / 2m;
                if (newGuess == previousGuess) return newGuess;
                previousGuess = newGuess;
            }
        }

        private static IList<decimal> SquareOfDifferencesFromMean(IEnumerable<decimal> data, decimal mean)
        {
            var squareOfDifferences = new List<decimal>();

            foreach (var number in data)
            {
                var difference = number - mean;
                var squared = difference * difference;
                squareOfDifferences.Add(squared);
            }

            return squareOfDifferences;
        }
    }
}
