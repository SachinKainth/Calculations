using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Calculations;
using FluentAssertions;

namespace CalculationsTests
{
    internal class Common
    {
        public static string GetFilePath(string fileName)
        {
            var executableLocation =
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(executableLocation, $"Files\\{fileName}");
            return filePath;
        }

        public static void CheckFrequencies(IList<FrequencyBand> frequencyBands, params int[] frequencies)
        {
            frequencyBands.Count.Should().Be(10);
            frequencyBands[0].Should().Be(new FrequencyBand(0, 10, frequencies[0]));
            frequencyBands[1].Should().Be(new FrequencyBand(10, 20, frequencies[1]));
            frequencyBands[2].Should().Be(new FrequencyBand(20, 30, frequencies[2]));
            frequencyBands[3].Should().Be(new FrequencyBand(30, 40, frequencies[3]));
            frequencyBands[4].Should().Be(new FrequencyBand(40, 50, frequencies[4]));
            frequencyBands[5].Should().Be(new FrequencyBand(50, 60, frequencies[5]));
            frequencyBands[6].Should().Be(new FrequencyBand(60, 70, frequencies[6]));
            frequencyBands[7].Should().Be(new FrequencyBand(70, 80, frequencies[7]));
            frequencyBands[8].Should().Be(new FrequencyBand(80, 90, frequencies[8]));
            frequencyBands[9].Should().Be(new FrequencyBand(90, 100, frequencies[9]));
        }
    }
}
