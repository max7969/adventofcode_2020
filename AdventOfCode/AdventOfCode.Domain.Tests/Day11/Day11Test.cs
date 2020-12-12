using FluentAssertions;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day11
{
    public class Day11Test
    {
        private ITestOutputHelper _output;
        public Day11Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day11/Resources/test.txt";
            Day11 day = new Day11();

            // Act
            int result = day.Compute(filePath, true, 4);

            // Assert
            result.Should().Be(37);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day11/Resources/input.txt";
            Day11 day = new Day11();

            // Act
            var result = day.Compute(filePath, true, 4);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day11/Resources/test.txt";
            Day11 day = new Day11();

            // Act
            int result = day.Compute(filePath, false, 5);

            // Assert
            result.Should().Be(26);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day11/Resources/input.txt";
            Day11 day = new Day11();

            // Act
            var result = day.Compute(filePath, false, 5);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
