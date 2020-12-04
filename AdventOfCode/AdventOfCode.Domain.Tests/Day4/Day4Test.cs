using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day4
{
    public class Day4Test
    {
        private ITestOutputHelper _output;
        public Day4Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day4/Resources/test.txt";
            Day4 day = new Day4();

            // Act
            var result = day.Compute(filePath, false);

            // Assert
            result.Should().Be(2);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day4/Resources/input.txt";
            Day4 day = new Day4();

            // Act
            var result = day.Compute(filePath, false);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day4/Resources/test2.txt";
            Day4 day = new Day4();

            // Act
            var result = day.Compute(filePath, true);

            // Assert
            result.Should().Be(4);
        }

        [Fact]
        public void Test2Part2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day4/Resources/test3.txt";
            Day4 day = new Day4();

            // Act
            var result = day.Compute(filePath, true);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day4/Resources/input.txt";
            Day4 day = new Day4();

            // Act
            var result = day.Compute(filePath, true);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
