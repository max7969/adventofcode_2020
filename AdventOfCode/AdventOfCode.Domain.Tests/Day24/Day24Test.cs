using FluentAssertions;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day24
{
    public class Day24Test
    {
        private ITestOutputHelper _output;

        public Day24Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day24/Resources/test.txt";
            Day24 day = new Day24();

            // Act
            long result = day.Compute(filePath);

            // Assert
            result.Should().Be(10);
        }


        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day24/Resources/input.txt";
            Day24 day = new Day24();

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
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day24/Resources/test.txt";
            Day24 day = new Day24();

            // Act
            long result = day.Compute2(filePath);

            // Assert
            result.Should().Be(2208);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day24/Resources/input.txt";
            Day24 day = new Day24();

            // Act
            var result = day.Compute2(filePath);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
