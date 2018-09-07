using System;
using Calculations;
using FluentAssertions;
using NUnit.Framework;

namespace CalculationsTests.UnitTests
{
    [TestFixture]
    class NumbersServiceTests
    {
        [Test]
        public void ReadNumbers_InvalidFilePath_ThrowsException()
        {
            var filePath = Common.GetFilePath("non-existant file.csv");
            var numbersService = new NumbersService(filePath);

            Action act = () => numbersService.ReadNumbers();

            act.Should().Throw<ArgumentException>()
                .WithMessage($"The file {filePath} is invalid.");
        }
        
        [Test]
        public void ReadNumbers_InvalidFileContents_ThrowsException()
        {
            var filePath = Common.GetFilePath("invalid file.csv");
            var numbersService = new NumbersService(filePath);

            Action act = () => numbersService.ReadNumbers();

            act.Should().Throw<CorruptFileException>()
                .WithMessage($"The file {filePath} contains invalid data.");
        }

        [Test]
        public void ReadNumbers_ValidFile_ReturnsNumbers()
        {
            var filePath = Common.GetFilePath("valid file.csv");
            var numbersService = new NumbersService(filePath);

            var numbers = numbersService.ReadNumbers();

            numbers.Count.Should().Be(1000);
        }
    }
}
