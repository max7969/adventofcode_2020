using FluentAssertions;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day13
{
    public class Day13Test
    {
        private ITestOutputHelper _output;

        public Day13Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day13/Resources/test.txt";
            Day13 day = new Day13();

            // Act
            long result = day.Compute(filePath);

            // Assert
            result.Should().Be(295);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day13/Resources/input.txt";
            Day13 day = new Day13();

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
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day13/Resources/test.txt";
            Day13 day = new Day13();

            // Act
            long result = day.Compute2(filePath);

            // Assert
            result.Should().Be(1068781);
        }

        [Fact]
        public void Test2Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day13/Resources/test2.txt";
            Day13 day = new Day13();

            // Act
            long result = day.Compute2(filePath);

            // Assert
            result.Should().Be(3417);
        }

        [Fact]
        public void Test3Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day13/Resources/test3.txt";
            Day13 day = new Day13();

            // Act
            long result = day.Compute2(filePath);

            // Assert
            result.Should().Be(1202161486);
        }

        [Fact]
        public void Test4Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day13/Resources/test4.txt";
            Day13 day = new Day13();

            // Act
            long result = day.Compute2(filePath);

            // Assert
            result.Should().Be(754018);
        }

        [Fact]
        public void Test5Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day13/Resources/test5.txt";
            Day13 day = new Day13();

            // Act
            long result = day.Compute2(filePath);

            // Assert
            result.Should().Be(779210);
        }

        [Fact]
        public void Test6Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day13/Resources/test6.txt";
            Day13 day = new Day13();

            // Act
            long result = day.Compute2(filePath);

            // Assert
            result.Should().Be(1261476);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day13/Resources/input.txt";
            Day13 day = new Day13();

            // Act
            var result = day.Compute2(filePath);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
