using FluentAssertions;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day8
{
    public class Day8Test
    {
        private ITestOutputHelper _output;
        public Day8Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day8/Resources/test.txt";
            Day8 day = new Day8();

            // Act
            var result = day.Compute(filePath);

            // Assert
            result.Should().Be(5);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day8/Resources/input.txt";
            Day8 day = new Day8();

            // Act
            var result = day.Compute(filePath);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day8/Resources/test.txt";
            Day8 day = new Day8();

            // Act
            var result = day.Compute2(filePath);

            // Assert
            result.Should().Be(8);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day8/Resources/input.txt";
            Day8 day = new Day8();

            // Act
            var result = day.Compute2(filePath);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
