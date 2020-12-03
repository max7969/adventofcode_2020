using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Domain.Day3
{
    public class Day3Test
    {
        private ITestOutputHelper _output;
        public Day3Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1Part1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day3/Resources/test.txt";
            Day3 day = new Day3();

            // Act
            var result = day.Compute(filePath, new List<Day3.Slope> {new Day3.Slope {Right = 3, Bottom = 1}});

            // Assert
            result.Should().Be(7);
        }

        [Fact]
        public void SolutionPart1()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day3/Resources/input.txt";
            Day3 day = new Day3();

            // Act
            var result = day.Compute(filePath, new List<Day3.Slope> { new Day3.Slope { Right = 3, Bottom = 1 } });

            // Result
            _output.WriteLine(result.ToString());
        }

        [Fact]
        public void Test1Part2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day3/Resources/test.txt";
            Day3 day = new Day3();

            // Act
            var result = day.Compute(filePath, new List<Day3.Slope>
            {
                new Day3.Slope { Right = 3, Bottom = 1 },
                new Day3.Slope { Right = 1, Bottom = 1 },
                new Day3.Slope { Right = 5, Bottom = 1 },
                new Day3.Slope { Right = 7, Bottom = 1 },
                new Day3.Slope { Right = 1, Bottom = 2 }
            });

            // Assert
            result.Should().Be(336);
        }

        [Fact]
        public void SolutionPart2()
        {
            // Arrange 
            string filePath = $"{new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName}/Day3/Resources/input.txt";
            Day3 day = new Day3();

            // Act
            var result = day.Compute(filePath, new List<Day3.Slope>
            {
                new Day3.Slope { Right = 3, Bottom = 1 },
                new Day3.Slope { Right = 1, Bottom = 1 },
                new Day3.Slope { Right = 5, Bottom = 1 },
                new Day3.Slope { Right = 7, Bottom = 1 },
                new Day3.Slope { Right = 1, Bottom = 2 }
            });

            // Result
            _output.WriteLine(result.ToString());
        }
    }
}
