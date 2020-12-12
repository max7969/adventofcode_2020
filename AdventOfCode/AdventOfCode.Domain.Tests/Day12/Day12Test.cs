using System.IO;
using System.Reflection;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day12
{
    public class Day12Test
    {
        private ITestOutputHelper _output;
        public Day12Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day12/Resources/test.txt";
            Day12 day = new Day12();

            // Act
            int result = day.Compute(filePath, false);

            // Assert
            result.Should().Be(25);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day12/Resources/input.txt";
            Day12 day = new Day12();

            // Act
            var result = day.Compute(filePath, false);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day12/Resources/test.txt";
            Day12 day = new Day12();

            // Act
            int result = day.Compute(filePath, true);

            // Assert
            result.Should().Be(286);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day12/Resources/input.txt";
            Day12 day = new Day12();

            // Act
            var result = day.Compute(filePath, true);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
