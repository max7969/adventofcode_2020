using AdventOfCode.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace AdventOfCode.Domain.Day19
{
    public class Day19
    {
        public long Compute(string filePath, bool evaluateStrangely)
        {
            var lines = FileReader.GetFileContent(filePath);
            var enumerator = lines.GetEnumerator();
            enumerator.MoveNext();
            Dictionary<long, Rule> rules = new Dictionary<long, Rule>();
            while (enumerator.Current != string.Empty)
            {
                var line = enumerator.Current;
                if (line == "8: 42" && evaluateStrangely)
                {
                    line = "8: 42 | 42 8";
                }

                if (line == "11: 42 31" && evaluateStrangely)
                {
                    line = "11: 42 31 | 42 11 31";
                }

                var match = Regex.Match(line, "([0-9]+): ([0-9a-z |\"]*)");
                var idRule = long.Parse(match.Groups[1].ToString());
                rules.Add(idRule, new Rule { Value = match.Groups[2].ToString().Replace("\"", "") });
                if (!Regex.Match(match.Groups[2].ToString(), "[0-9]+").Success)
                {
                    rules[idRule].IsFinal = true;
                }
                enumerator.MoveNext();
            }

            while (rules.Any(x => !x.Value.IsFinal))
            {
                var notFinals = rules.Where(y => !y.Value.IsFinal).ToList();
                var finals = rules.Where(y => y.Value.IsFinal).ToList();
                foreach (var notFinal in notFinals)
                {
                    foreach (var final in finals)
                    {
                        var regex1 = new Regex($" {final.Key} ");
                        var regex2 = new Regex($"^{final.Key} ");
                        var regex3 = new Regex($" {final.Key}$");
                        var regex4 = new Regex($"^{final.Key}$");
                        var replacement = final.Value.Value.Length == 1
                            ? final.Value.Value
                            : string.Concat("(", final.Value.Value, ")");

                        rules[notFinal.Key].Value = regex1.Replace(notFinal.Value.Value, $" {replacement} ");
                        rules[notFinal.Key].Value = regex2.Replace(notFinal.Value.Value, $"{replacement} ");
                        rules[notFinal.Key].Value = regex3.Replace(notFinal.Value.Value, $" {replacement}");
                        rules[notFinal.Key].Value = regex4.Replace(notFinal.Value.Value, $"{replacement}");
                    }

                    if (!Regex.Match(rules[notFinal.Key].Value, "[0-9]+").Success)
                    {
                        rules[notFinal.Key].IsFinal = true;
                    }
                    else
                    {
                        var matches = Regex.Matches(rules[notFinal.Key].Value, "([0-9]+)");
                        if (matches.Count == 1 && matches[0].Groups[0].ToString() == notFinal.Key.ToString())
                        {
                            if (notFinal.Value.Value.Length > 50000)
                            {
                                rules[notFinal.Key].Value = rules[notFinal.Key].Value.Replace(notFinal.Key.ToString(), "");
                                rules[notFinal.Key].IsFinal = true;
                            }
                            else
                            {
                                rules[notFinal.Key].Value = rules[notFinal.Key].Value.Replace(notFinal.Key.ToString(), string.Concat("(", rules[notFinal.Key].Value, ")"));
                            }
                        }
                    }
                }
            }

            var finalRegex = new Regex($"^{rules[0].Value.Replace(" ", "")}$");

            int countMatch = 0;

            while (enumerator.MoveNext())
            {
                countMatch = finalRegex.Match(enumerator.Current).Success ? countMatch + 1 : countMatch;
            }

            return countMatch;
        }

        public class Rule
        {
            public string Value { get; set; }
            public bool IsFinal { get; set; }
        }
    }
}
