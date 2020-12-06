using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day4
{
    public class Day4
    {

        public int Compute(string filePath, bool fullValidation)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();
            var passports = ReadPassports(lines).ToList();
            return passports.Count(x => fullValidation ? x.ContainsMandatoryFields && x.IsFullyValid : x.ContainsMandatoryFields);
        }

        private static IEnumerable<Passport> ReadPassports(List<string> lines)
        {
            var passports = new List<Passport>();

            var actualPassport = new Passport();
            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    passports.Add(actualPassport);
                    actualPassport = new Passport();
                }
                else
                {
                    foreach (var element in line.Split(' '))
                    {
                        var attribute = element.Split(':');
                        actualPassport.Attributes.Add(attribute[0], attribute[1]);
                    }
                }
            }
            passports.Add(actualPassport);
            return passports;
        }

        public class Passport
        {
            private readonly Dictionary<string, Func<string, bool>> mandatoryFields = new Dictionary<string, Func<string, bool>>
            {
                { "byr", (value) => int.TryParse(value, out int val) && val >= 1920 && val <= 2002 },
                { "iyr", (value) => int.TryParse(value, out int val) && val >= 2010 && val <= 2020 },
                { "eyr", (value) => int.TryParse(value, out int val) && val >= 2020 && val <= 2030 },
                { "hgt", (value) => Regex.Match(value, "^(1([5-8]{1}[0-9]{1}|9[0-3]{1})cm|(59|6[0-9]|7[0-6])in)$").Success },
                { "hcl", (value) => Regex.Match(value, "^#[0-9a-f]{6}$").Success },
                { "ecl", (value) => Regex.Match(value, "^(amb|blu|brn|gry|grn|hzl|oth)$").Success },
                { "pid", (value) => Regex.Match(value, "^[0-9]{9}$").Success }
            };

            public Dictionary<string, string> Attributes { get; set; }

            public Passport()
            {
                Attributes = new Dictionary<string, string>();
            }

            public bool ContainsMandatoryFields =>
                mandatoryFields.All(x => Attributes.ContainsKey(x.Key));

            public bool IsFullyValid =>
                mandatoryFields.All(x => x.Value(Attributes[x.Key]));
        }
    }
}
