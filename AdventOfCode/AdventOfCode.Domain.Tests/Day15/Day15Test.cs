using FluentAssertions;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day15
{
    public class Day15Test
    {
        private ITestOutputHelper _output;

        public Day15Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day15/Resources/test.txt";
            Day15 day = new Day15();

            // Act
            long result = day.Compute(filePath, 2020);

            // Assert
            result.Should().Be(436);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day15/Resources/input.txt";
            Day15 day = new Day15();

            // Act
            var result = day.Compute(filePath, 2020);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day15/Resources/test.txt";
            Day15 day = new Day15();

            // Act
            long result = day.Compute(filePath, 30000000);

            // Assert
            result.Should().Be(175594);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day15/Resources/input.txt";
            Day15 day = new Day15();

            // Act
            var result = day.Compute(filePath, 30000000);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
