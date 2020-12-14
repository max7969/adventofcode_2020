using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day14
{
    public class Day14
    {
        public long Compute(string filePath, bool simpleMode)
        {
            var lines = FileReader.GetFileContent(filePath);

            var mask = new List<string>();
            var memory = new Dictionary<long, long>();

            foreach (var line in lines)
            {
                var lineSplit = line.Split(" = ");
                if (lineSplit[0] == "mask")
                {
                    mask = lineSplit[1].ToCharArray().Select(x => x.ToString()).ToList();
                }
                else
                {
                    var value = long.Parse(lineSplit[1]);
                    var memoryKey = long.Parse(Regex.Match(lineSplit[0], "^mem\\[([0-9]*)\\]$").Groups[1].ToString());

                    var actions = simpleMode ? GetSimpleAction(mask, memoryKey, value) : GetMultipleActions(mask, memoryKey, value);
                    foreach (var action in actions)
                    {
                        memory[action.Key] = action.Value;
                    }
                }
            }

            return memory.Values.Sum();
        }

        public Dictionary<long, long> GetSimpleAction(List<string> mask, long key, long value)
        {
            return new Dictionary<long, long>
            {
                { key, Operate(mask, LongInBaseTwoWithLeadingZeros(mask.Count, value)) }
            };
        }

        public Dictionary<long, long> GetMultipleActions(List<string> mask, long key, long value)
        {
            return new Dictionary<long, long>(GenerateKeys(mask, LongInBaseTwoWithLeadingZeros(mask.Count, key))
                .Select(x => new KeyValuePair<long, long>(x, value)));
        }

        private List<string> LongInBaseTwoWithLeadingZeros(int byteCount, long value)
        {
            var binaryValue = Convert.ToString(value, 2).ToCharArray().Select(x => x.ToString()).ToList();
            var leadingZeros = new int[byteCount - binaryValue.Count].Select(x => x.ToString()).ToList();
            leadingZeros.AddRange(binaryValue);
            return leadingZeros;
        }

        private List<long> GenerateKeys(List<string> mask, List<string> key)
        {
            List<long> keys = new List<long>();
            List<string> result = new List<string>();
            for (int i = 0; i < mask.Count; i++)
            {
                result.Add(mask[i] == "X" ? "X" : mask[i] == "0" ? key[i] : "1");
            }

            long max = Convert.ToInt64(string.Concat(new int[result.Count(x => x == "X")].Select(x => "1")), 2);
            for (long i = 0; i <= max; i++)
            {
                var copyResult = result.Select(x => x.Clone().ToString()).ToList();
                var binaryValue = LongInBaseTwoWithLeadingZeros(copyResult.Count(x => x == "X"), i);

                for (int j = 0; j < binaryValue.Count(); j++)
                {
                    copyResult[copyResult.IndexOf("X")] = binaryValue[j];
                }
                keys.Add(Convert.ToInt64(string.Concat(copyResult), 2));
            }

            return keys;
        }  

        private long Operate(List<string> mask, List<string> value)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < mask.Count; i++)
            {
                result.Add(mask[i] != "X" ? mask[i] : value[i]);
            }
            return Convert.ToInt64(string.Concat(result), 2);
        }
    }
}
