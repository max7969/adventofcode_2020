using FluentAssertions;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day23
{
    public class Day23Test
    {
        private ITestOutputHelper _output;

        public Day23Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day23/Resources/test.txt";
            Day23 day = new Day23();

            // Act
            var result = day.Compute(filePath, 10);

            // Assert
            result.Should().Be("92658374");
        }

        [Fact]
        public void Test2Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day23/Resources/test.txt";
            Day23 day = new Day23();

            // Act
            var result = day.Compute(filePath, 100);

            // Assert
            result.Should().Be("67384529");
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day23/Resources/input.txt";
            Day23 day = new Day23();

            // Act
            var result = day.Compute(filePath, 100);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day23/Resources/test.txt";
            Day23 day = new Day23();

            // Act
            long result = day.Compute2(filePath, 10000000);

            // Assert
            result.Should().Be(149245887792);
        }


        //[Fact]
        //public void SolutionPart2()
        //{
        //    // Arrange 
        //    string filePath =
        //        $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day23/Resources/input.txt";
        //    Day23 day = new Day23();

        //    // Act
        //    var result = day.Compute(filePath);

        //    // Result
        //    _output.WriteLine(result.ToString());
        //}
    }
}
