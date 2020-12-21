﻿using FluentAssertions;
using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day21
{
    public class Day21Test
    {
        private ITestOutputHelper _output;

        public Day21Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day21/Resources/test.txt";
            Day21 day = new Day21();

            // Act
            long result = day.Compute(filePath);

            // Assert
            result.Should().Be(5);
        }


        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day21/Resources/input.txt";
            Day21 day = new Day21();

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
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day21/Resources/test.txt";
            Day21 day = new Day21();

            // Act
            string result = day.Compute2(filePath);

            // Assert
            result.Should().Be("mxmxvkd,sqjhc,fvjkl");
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath =
                $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day21/Resources/input.txt";
            Day21 day = new Day21();

            // Act
            var result = day.Compute2(filePath);

            // Result
            _output.WriteLine(result);
        }
    }
}
