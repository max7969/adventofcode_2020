using System.IO;
using System.Reflection;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day2
{
    public class Day2Test
    {
        private ITestOutputHelper _output;
        public Day2Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day2/Resources/test.txt";
            Day2 day = new Day2();

            // Act
            int result = day.Compute(filePath, Day2.Policy.Count);

            // Assert
            result.Should().Be(2);
        }
        
        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day2/Resources/input.txt";
            Day2 day = new Day2();

            // Act
            int result = day.Compute(filePath, Day2.Policy.Count);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day2/Resources/test.txt";
            Day2 day = new Day2();

            // Act
            int result = day.Compute(filePath, Day2.Policy.Position);

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day2/Resources/input.txt";
            Day2 day = new Day2();

            // Act
            int result = day.Compute(filePath, Day2.Policy.Position);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
