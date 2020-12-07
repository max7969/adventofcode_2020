using System.IO;
using System.Reflection;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day7
{
    public class Day7Test
    {
        private ITestOutputHelper _output;
        public Day7Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day7/Resources/test.txt";
            Day7 day = new Day7();

            // Act
            var result = day.Compute(filePath);

            // Assert
            result.Should().Be(4);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day7/Resources/input.txt";
            Day7 day = new Day7();

            // Act
            var result = day.Compute(filePath);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day7/Resources/test.txt";
            Day7 day = new Day7();

            // Act
            var result = day.Compute2(filePath);

            // Assert
            result.Should().Be(32);
        }

        [Fact]
        public void Test2Part2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day7/Resources/test2.txt";
            Day7 day = new Day7();

            // Act
            var result = day.Compute2(filePath);

            // Assert
            result.Should().Be(126);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day7/Resources/input.txt";
            Day7 day = new Day7();

            // Act
            var result = day.Compute2(filePath);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
