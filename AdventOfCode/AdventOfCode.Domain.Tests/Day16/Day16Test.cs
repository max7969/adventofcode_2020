using FluentAssertions;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day16
{
    public class Day16Test
    {
        private ITestOutputHelper _output;

        public Day16Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day16/Resources/test.txt";
            Day16 day = new Day16();

            // Act
            long result = day.Compute(filePath);

            // Assert
            result.Should().Be(71);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day16/Resources/input.txt";
            Day16 day = new Day16();

            // Act
            var result = day.Compute(filePath);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day16/Resources/test2.txt";
            Day16 day = new Day16();

            // Act
            long result = day.Compute2(filePath, "a");

            // Assert
            result.Should().Be(12 * 13);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day16/Resources/input.txt";
            Day16 day = new Day16();

            // Act
            var result = day.Compute2(filePath, "departure");

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
