using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day5
{
    public class Day5
    {
        public int Compute(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();
            return ReadBoardingPass(lines).Max();
        }

        public int Compute2(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();
            var elements = ReadBoardingPass(lines);

            var filtered = elements
                .Where(x => !elements.Contains(x + 1) || !elements.Contains(x - 1))
                .OrderBy(x => x).ToList();

            return filtered[1] + 1;
        }

        private IEnumerable<int> ReadBoardingPass(IEnumerable<string> lines)
        {
            return lines.Select(x =>
                Convert.ToInt32(
                    x.Replace("B", "1")
                        .Replace("F", "0")
                        .Replace("R", "1")
                        .Replace("L", "0"), 2));
        }
    }
}
