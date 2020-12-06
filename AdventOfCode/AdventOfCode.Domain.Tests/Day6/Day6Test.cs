using System.IO;
using System.Reflection;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day6
{
    public class Day6Test
    {
        private ITestOutputHelper _output;
        public Day6Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day6/Resources/test.txt";
            Day6 day = new Day6();

            // Act
            var result = day.Compute(filePath, false);

            // Assert
            result.Should().Be(11);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day6/Resources/input.txt";
            Day6 day = new Day6();

            // Act
            var result = day.Compute(filePath, false);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day6/Resources/test.txt";
            Day6 day = new Day6();

            // Act
            var result = day.Compute(filePath, true);

            // Assert
            result.Should().Be(6);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day6/Resources/input.txt";
            Day6 day = new Day6();

            // Act
            var result = day.Compute(filePath, true);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
