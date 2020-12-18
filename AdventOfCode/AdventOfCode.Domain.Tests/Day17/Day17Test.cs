using FluentAssertions;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day17
{
    public class Day17Test
    {
        private ITestOutputHelper _output;

        public Day17Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day17/Resources/test.txt";
            Day17 day = new Day17();

            // Act
            long result = day.Compute(filePath, 3);

            // Assert
            result.Should().Be(112);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day17/Resources/input.txt";
            Day17 day = new Day17();

            // Act
            var result = day.Compute(filePath, 3);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day17/Resources/test.txt";
            Day17 day = new Day17();

            // Act
            long result = day.Compute(filePath, 4);

            // Assert
            result.Should().Be(848);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day17/Resources/input.txt";
            Day17 day = new Day17();

            // Act
            var result = day.Compute(filePath, 4);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
