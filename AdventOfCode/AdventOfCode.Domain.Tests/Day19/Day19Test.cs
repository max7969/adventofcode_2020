using FluentAssertions;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day19
{
    public class Day19Test
    {
        private ITestOutputHelper _output;

        public Day19Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day19/Resources/test.txt";
            Day19 day = new Day19();

            // Act
            long result = day.Compute(filePath, false);

            // Assert
            result.Should().Be(2);
        }

        [Fact]
        public void Test2Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day19/Resources/test2.txt";
            Day19 day = new Day19();

            // Act
            long result = day.Compute(filePath, false);

            // Assert
            result.Should().Be(3);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day19/Resources/input.txt";
            Day19 day = new Day19();

            // Act
            var result = day.Compute(filePath, false);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day19/Resources/test2.txt";
            Day19 day = new Day19();

            // Act
            long result = day.Compute(filePath, true);

            // Assert
            result.Should().Be(12);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day19/Resources/input.txt";
            Day19 day = new Day19();

            // Act
            var result = day.Compute(filePath, true);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
