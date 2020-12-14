using System.IO;
using System.Reflection;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day14
{
    public class Day14Test
    {
        private ITestOutputHelper _output;

        public Day14Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day14/Resources/test.txt";
            Day14 day = new Day14();

            // Act
            long result = day.Compute(filePath, true);

            // Assert
            result.Should().Be(165);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day14/Resources/input.txt";
            Day14 day = new Day14();

            // Act
            var result = day.Compute(filePath, true);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day14/Resources/test2.txt";
            Day14 day = new Day14();

            // Act
            long result = day.Compute(filePath, false);

            // Assert
            result.Should().Be(208);
        }
        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day14/Resources/input.txt";
            Day14 day = new Day14();

            // Act
            var result = day.Compute(filePath, false);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
