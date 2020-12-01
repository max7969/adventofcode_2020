using System;
using System.IO;
using System.Reflection;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day1
{
    public class Day1Test
    {
        private ITestOutputHelper _output;
        public Day1Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day1/Resources/test.txt";
            Day1 day = new Day1();

            // Act
            int result = day.Compute(filePath, 2);

            // Assert
            result.Should().Be(514579);
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day1/Resources/test.txt";
            Day1 day = new Day1();

            // Act
            int result = day.Compute(filePath, 3);

            // Assert
            result.Should().Be(241861950);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day1/Resources/input.txt";
            Day1 day = new Day1();

            // Act
            int result = day.Compute(filePath, 2);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day1/Resources/input.txt";
            Day1 day = new Day1();

            // Act
            int result = day.Compute(filePath, 3);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
