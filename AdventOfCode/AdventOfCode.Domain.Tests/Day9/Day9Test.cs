using System.IO;
using System.Reflection;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day9
{
    public class Day9Test
    {
        private ITestOutputHelper _output;
        public Day9Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day9/Resources/test.txt";
            Day9 day = new Day9();

            // Act
            var result = day.Compute(filePath, 5);

            // Assert
            result.Should().Be(127);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day9/Resources/input.txt";
            Day9 day = new Day9();

            // Act
            var result = day.Compute(filePath, 25);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day9/Resources/test.txt";
            Day9 day = new Day9();

            // Act
            var result = day.Compute2(filePath, 127);

            // Assert
            result.Should().Be(62);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day9/Resources/input.txt";
            Day9 day = new Day9();

            // Act
            var result = day.Compute2(filePath, day.Compute(filePath, 25));

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
