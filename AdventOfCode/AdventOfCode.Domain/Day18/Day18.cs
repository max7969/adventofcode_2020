using AdventOfCode.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace AdventOfCode.Domain.Day18
{
    public class Day18
    {
        public long Compute(string filePath, bool evaluateStrangely) 
        {
            var operations = FileReader.GetFileContent(filePath).ToArray();

            var test = operations.Select(operation => Calculate(operation, evaluateStrangely)).ToList();

            return operations.Sum(operation => Calculate(operation, evaluateStrangely));
        }

        public long Calculate(string operation, bool evaluateStrangely)
        {
            if (operation.Contains("("))
            {
                var matches = Regex.Matches(operation, "\\(([0-9 +*]*)\\)");
                foreach (Match match in matches)
                {
                    operation = operation.Replace(match.Value, Calculate(match.Groups[1].ToString(), evaluateStrangely).ToString());
                }

                return Calculate(operation, evaluateStrangely);
            }
            return evaluateStrangely ? EvaluateStrangely(operation) : Evaluate(operation);
        }

        private long Evaluate(string operation)
        {
            var operationTab = operation.Split(" ");
            long result = long.Parse(operationTab[0]);
            for (int i = 1; i < operationTab.Length - 1; i = i + 2)
            {
                result = operationTab[i] == "*"
                    ? result * long.Parse(operationTab[i + 1])
                    : result + long.Parse(operationTab[i + 1]);
            }

            return result;
        }

        private long EvaluateStrangely(string operation)
        {
            DataTable dataTable = new DataTable();
            MatchCollection matches;
            do
            {
                matches = Regex.Matches(operation, "([0-9]+ \\+ [0-9]+)");
                foreach (Match match in matches)
                {
                    var reg = new Regex(Regex.Escape(match.Value));
                    operation = reg.Replace(operation, dataTable.Compute(match.Value, "").ToString(), 1);
                }

            } while (matches.Any());

            return operation.Split(" * ").Select(x => long.Parse(x)).Aggregate((a, b) => a * b);
        }
    }
}
