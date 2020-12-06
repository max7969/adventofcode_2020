using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day2
{
    public class Day2
    {
        public enum Policy
        {
            Count,
            Position
        }

        public int Compute(string filePath, Policy policy)
        {
            var lines = FileReader.GetFileContent(filePath);

            if (policy == Policy.Count)
            {
                return ExtractRules(lines).Count(x => x.IsPasswordValidCount());
            }
            else
            {
                return ExtractRules(lines).Count(x => x.IsPasswordValidPosition());
            }
        }

        private IEnumerable<Rule> ExtractRules(IEnumerable<string> lines)
        {
            List<Rule> rules = new List<Rule>();
            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                rules.Add(new Rule()
                {
                    Min = int.Parse(parts[0].Split('-')[0]),
                    Max = int.Parse(parts[0].Split('-')[1]),
                    Letter = parts[1].Split(':')[0],
                    Password = parts[2]
                });
            }
            return rules;
        }

        public class Rule
        {
            public int Min { get; set; }
            public int Max { get; set; }
            public string Letter { get; set; }
            public string Password { get; set; }

            public bool IsPasswordValidCount()
            {
                var splitPassword = Password.ToList().Select(x => x.ToString()).ToList();
                return splitPassword.Contains(Letter) 
                       && splitPassword.GroupBy(x => x)
                           .Where(x => x.Key == Letter)
                           .All(x => x.Count() >= Min && x.Count() <= Max);
            }

            public bool IsPasswordValidPosition()
            {
                var splitPassword = Password.ToList().Select(x => x.ToString()).ToList();
                return (new List<string> {splitPassword[Min - 1], splitPassword[Max - 1]}).Count(x => x == Letter) == 1;
            }
        }
    }
}
