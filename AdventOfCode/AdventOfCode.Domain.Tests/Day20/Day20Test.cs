using FluentAssertions;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day20
{
    public class Day20Test
    {
        private ITestOutputHelper _output;

        public Day20Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day20/Resources/test.txt";
            Day20 day = new Day20();

            // Act
            long result = day.Compute(filePath);

            // Assert
            result.Should().Be(20899048083289);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day20/Resources/input.txt";
            Day20 day = new Day20();

            // Act
            var result = day.Compute(filePath);

            // Result
            _output.WriteLine(result.ToString());
        }

        //[Fact]
        //public void Test1Part2()
        //{
        //    // Arrange 
        //    string filePath =
        //        $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day20/Resources/test2.txt";
        //    Day20 day = new Day20();

        //    // Act
        //    long result = day.Compute(filePath, true);

        //    // Assert
        //    result.Should().Be(12);
        //}

        //[Fact]
        //public void SolutionPart2()
        //{
        //    // Arrange 
        //    string filePath =
        //        $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day20/Resources/input.txt";
        //    Day20 day = new Day20();

        //    // Act
        //    var result = day.Compute(filePath, true);

        //    // Result
        //    _output.WriteLine(result.ToString());
        //}
    }
}
