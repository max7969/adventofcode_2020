using FluentAssertions;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day22
{
    public class Day22Test
    {
        private ITestOutputHelper _output;

        public Day22Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day22/Resources/test.txt";
            Day22 day = new Day22();

            // Act
            long result = day.Compute(filePath, false);

            // Assert
            result.Should().Be(306);
        }


        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day22/Resources/input.txt";
            Day22 day = new Day22();

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
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day22/Resources/test.txt";
            Day22 day = new Day22();

            // Act
            long result = day.Compute(filePath, true);

            // Assert
            result.Should().Be(291);
        }


        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day22/Resources/input.txt";
            Day22 day = new Day22();

            // Act
            var result = day.Compute(filePath, true);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
