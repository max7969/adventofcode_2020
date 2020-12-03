using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day3
{
    public class Day3
    {
        public long Compute(string filePath, IEnumerable<Slope> slopes)
        {
            long result = 1;
            foreach (var slope in slopes)
            {
                var lines = FileReader.GetFileContent(filePath).ToList();
                long countTree = 0;
                int pos = 0;
                for (int i = 0; i < lines.Count(); i += slope.Bottom)
                {
                    var tabLine = lines[i].ToList().Select(x => x.ToString()).ToList();
                    countTree = countTree + (tabLine[pos % tabLine.Count()] == "#" ? 1 : 0);
                    pos = pos + slope.Right;
                }


                result = result * countTree;
            }

            return result;
        }

        public class Slope
        {
            public int Right { get; set; }
            public int Bottom { get; set; }
        }
    }
}
