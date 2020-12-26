using FluentAssertions;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day25
{
    public class Day25Test
    {
        private ITestOutputHelper _output;

        public Day25Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day25/Resources/test.txt";
            Day25 day = new Day25();

            // Act
            long result = day.Compute(filePath);

            // Assert
            result.Should().Be(14897079);
        }


        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day25/Resources/input.txt";
            Day25 day = new Day25();

            // Act
            var result = day.Compute(filePath);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
