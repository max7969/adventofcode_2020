using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day16
{
    public class Day16
    {
        public long Compute(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath);

            var input = ReadInput(lines);

            int sum = 0;
            var allRules = input.fields.SelectMany(x => x.Rules);
            foreach (var ticket in input.otherTickets)
            {
                sum += ticket.Values.Where(x => !allRules.Any(rule => rule.IsValid(x))).Sum();
            }
            return sum;
        }

        public long Compute2(string filePath, string fieldFilter)
        {
            var lines = FileReader.GetFileContent(filePath);

            var input = ReadInput(lines);

            var allRules = input.fields.SelectMany(x => x.Rules);

            var validTickets = input.otherTickets
                .Where(ticket => ticket.Values
                    .All(x => allRules.Any(rule => rule.IsValid(x))))
                .ToList();

            var fieldIndexes = ComputeFieldIndexes(input, validTickets);

            var selectedFieldsIndex =
                fieldIndexes.Where(x => x.Key.Name.Contains(fieldFilter)).Select(x => x.Value).ToList();

            long result = 1;
            foreach (var index in selectedFieldsIndex)
            {
                result = result * input.myTicket.Values[(int)index];
            }

            return result;
        }

        private static Dictionary<Field, long> ComputeFieldIndexes((List<Field> fields, Ticket myTicket, List<Ticket> otherTickets) input,
            List<Ticket> validTickets)
        {
            Dictionary<Field, long> fieldIndexes = new Dictionary<Field, long>();
            List<List<int>> fieldValues = new List<List<int>>();
            for (int i = 0; i < input.myTicket.Values.Count; i++)
            {
                fieldValues.Add(validTickets.Select(x => x.Values[i]).ToList());
            }

            var copyFieldValues = fieldValues.Select(x => new List<int>(x)).ToList();

            while (input.fields.Any(f => !f.Assigned))
            {
                foreach (var inputField in input.fields.Where(f => !f.Assigned))
                {
                    var matching = fieldValues.Where(x => x.All(y => inputField.Rules.Any(r => r.IsValid(y))));
                    if (matching.Count() == 1)
                    {
                        inputField.Assigned = true;
                        fieldIndexes.Add(inputField, copyFieldValues.FindIndex(x => x.All(y => matching.Single().Contains(y))));
                        fieldValues.Remove(matching.Single());
                    }
                }
            }

            return fieldIndexes;
        }

        private (List<Field> fields, Ticket myTicket, List<Ticket> otherTickets) ReadInput(IEnumerable<string> lines)
        {
            List<Field> fields = new List<Field>();
            Ticket myTicket = new Ticket();
            List<Ticket> otherTickets = new List<Ticket>();
            bool firstTicket = true;
            foreach (var line in lines)
            {
                var matchField = Regex.Match(line, "^([a-z ]*): ([0-9]*)-([0-9]*) or ([0-9]*)-([0-9]*)$");
                var matchTicketValues = Regex.Matches(line, "[0-9]+");
                if (matchField.Success)
                {
                    fields.Add(new Field
                    {
                        Name = matchField.Groups[1].ToString(),
                        Rules = new List<Rule>
                        {
                            new Rule { Start = int.Parse(matchField.Groups[2].ToString()), End = int.Parse(matchField.Groups[3].ToString()) },
                            new Rule { Start = int.Parse(matchField.Groups[4].ToString()), End = int.Parse(matchField.Groups[5].ToString()) }
                        }
                    });
                }
                else if (matchTicketValues.Any())
                {
                    if (firstTicket)
                    {
                        myTicket.Values = matchTicketValues.Select(x => int.Parse(x.Value)).ToList();
                        firstTicket = false;
                    }
                    else
                    {
                        otherTickets.Add(new Ticket { Values = matchTicketValues.Select(x => int.Parse(x.Value)).ToList() });
                    }
                }
            }

            return (fields, myTicket, otherTickets);
        }

        public class Ticket
        {
            public List<int> Values { get; set; }
        }

        public class Field
        {
            public string Name { get; set; }
            public List<Rule> Rules { get; set; }
            public bool Assigned { get; set; }

            public Field()
            {
                Rules = new List<Rule>();
            }
        }

        public class Rule
        {
            public int Start { get; set; }
            public int End { get; set; }
            public bool IsValid(int value) => value >= Start && value <= End;

        }
    }
}
