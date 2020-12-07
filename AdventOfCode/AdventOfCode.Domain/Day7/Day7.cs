using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day7
{
    public class Day7
    {
        public int Compute(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();
            var bags = GetBags(lines);

            return CanContains("shiny gold", bags.ToList());
        }
        public int Compute2(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();
            var bags = GetBags(lines);

            return CountBags("shiny gold", bags.ToList(), 1) - 1;
        }

        private int CanContains(string bagName, List<Bag> bags)
        {
            HashSet<string> allBags = new HashSet<string>();
            List<string> newBags = new List<string> { bagName };
            do
            {
                newBags = bags
                    .Where(x => x.Content.Keys.Any(y => newBags.Contains(y)))
                    .Select(x => x.Name).ToList();
                allBags.UnionWith(newBags);
            } while (newBags.Any());
            return allBags.Count();
        }

        private int CountBags(string bagName, List<Bag> bags, int quantity)
        {
            var actualBag = bags.Single(x => x.Name == bagName);
            if (!actualBag.Content.Any())
            {
                return quantity;
            }
            return actualBag.Content.Keys
                .Select(x => quantity * CountBags(x, bags, actualBag.Content[x]))
                .Sum() + quantity;
        }

        private IEnumerable<Bag> GetBags(List<string> lines)
        {
            List<Bag> bags = new List<Bag>();
            foreach (var line in lines)
            {
                var match = Regex.Match(line, "^([\\w\\s]*)( bags contain ){1}([\\w\\s,]*).$");
                Bag bag = new Bag(match.Groups[1].Value);
                var groups = Regex.Matches(match.Groups[3].ToString(), "(([0-9]+)([\\w\\s]+)*bag)");
                foreach (Match x in groups)
                {
                    bag.Content.Add(x.Groups[3].ToString().Trim(), int.Parse(x.Groups[2].ToString().Trim()));
                }
                bags.Add(bag);
            }

            return bags;
        }

        public class Bag
        {
            public string Name { get; set; }
            public Dictionary<string, int> Content { get; private set; }

            public Bag(string name)
            {
                Name = name;
                Content = new Dictionary<string, int>();
            }
        }
    }
}
