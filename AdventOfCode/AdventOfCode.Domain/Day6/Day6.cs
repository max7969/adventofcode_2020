using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day6
{
    public class Day6
    {
        public int Compute(string filePath, bool allAnsweredYes)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();
            var groups = ReadGroups(lines).ToList();

            if (allAnsweredYes)
            {
                return groups
                    .Select(x => x.Peoples.SelectMany(y => y)
                        .GroupBy(y => y)
                        .Where(y => x.Peoples.Count == y.Count()))
                    .Sum(x => x.Count());

            }
            return groups
                .Select(x => x.Peoples.SelectMany(x => x).ToHashSet())
                .Sum(x => x.Count());
        }

        private static IEnumerable<Group> ReadGroups(List<string> lines)
        {
            var groups = new List<Group>();

            var actualGroup = new Group();
            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    groups.Add(actualGroup);
                    actualGroup = new Group();
                }
                else
                {
                    actualGroup.Peoples.Add(line.ToCharArray());
                }
            }
            groups.Add(actualGroup);
            return groups;
        }

        public class Group
        {
            public List<IEnumerable<char>> Peoples { get; set; }

            public Group()
            {
                Peoples = new List<IEnumerable<char>>();
            }
        }
    }
}
