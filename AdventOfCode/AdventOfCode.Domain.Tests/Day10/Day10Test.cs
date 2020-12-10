using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day10
{
    public class Day10Test
    {
        private ITestOutputHelper _output;
        public Day10Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day10/Resources/test.txt";
            Day10 day = new Day10();

            // Act
            int result = day.Compute(filePath);

            // Assert
            result.Should().Be(22 * 10);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day10/Resources/input.txt";
            Day10 day = new Day10();

            // Act
            var result = day.Compute(filePath);

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day10/Resources/test.txt";
            Day10 day = new Day10();

            // Act
            long result = day.Compute2(filePath);

            // Assert
            result.Should().Be(19208);
        }

        [Fact]
        public void Test2Part2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day10/Resources/test2.txt";
            Day10 day = new Day10();

            // Act
            long result = day.Compute2(filePath);

            // Assert
            result.Should().Be(8);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day10/Resources/input.txt";
            Day10 day = new Day10();

            // Act
            var result = day.Compute2(filePath);

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
