using FluentAssertions;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day18
{
    public class Day18Test
    {
        private ITestOutputHelper _output;

        public Day18Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day18/Resources/test.txt";
            Day18 day = new Day18();

            // Act
            long result = day.Compute(filePath, false);

            // Assert
            result.Should().Be(51);
        }

        [Fact]
        public void Test2Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day18/Resources/test2.txt";
            Day18 day = new Day18();

            // Act
            long result = day.Compute(filePath, false);

            // Assert
            result.Should().Be(13632);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day18/Resources/input.txt";
            Day18 day = new Day18();

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
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day18/Resources/test.txt";
            Day18 day = new Day18();

            // Act
            long result = day.Compute(filePath, true);

            // Assert
            result.Should().Be(51);
        }

        [Fact]
        public void Test2Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day18/Resources/test2.txt";
            Day18 day = new Day18();

            // Act
            long result = day.Compute(filePath, true);

            // Assert
            result.Should().Be(23340);
        }

        [Fact]
        public void Test3Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day18/Resources/test3.txt";
            Day18 day = new Day18();

            // Act
            long result = day.Compute(filePath, true);

            // Assert
            result.Should().Be(669060);
        }

        [Fact]
        public void Test4Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day18/Resources/test4.txt";
            Day18 day = new Day18();

            // Act
            long result = day.Compute(filePath, true);

            // Assert
            result.Should().Be(1445);
        }

        [Fact]
        public void Test5Part2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day18/Resources/test5.txt";
            Day18 day = new Day18();

            // Act
            long result = day.Compute(filePath, true);

            // Assert
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day18/Resources/input.txt";
            Day18 day = new Day18();

            // Act
            var result = day.Compute(filePath, true);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
