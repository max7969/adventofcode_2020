using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Markup;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day15
{
    public class Day15
    {
        public long Compute(string filePath, long max)
        {
            var starter = FileReader.GetFileContent(filePath).ToList()[0].Split(",").Select(x => long.Parse(x)).ToList();
            int count = 1;
            Dictionary<long, Turns> numbers = new Dictionary<long, Turns>(starter.Select(x => new KeyValuePair<long, Turns>(x, new Turns { First = count++ })));
            long previous = starter.Last();
            for (int i = starter.Count; i < max; i++)
            {
                previous = numbers[previous].First != null && numbers[previous].Second == null ? 0
                    : numbers[previous].First == numbers[previous].Second ? 1
                    : numbers[previous].Second - numbers[previous].First ?? -1;

                numbers[previous] = numbers.ContainsKey(previous) ? numbers[previous].Move(i + 1) : new Turns { First = i + 1 };
            }
            return previous;
        }

        public class Turns
        {
            public long? First { get; set; }
            public long? Second { get; set; }

            public Turns Move(long newTurn)
            {
                if (Second != null)
                {
                    First = Second;
                }
                Second = newTurn;
                return this;
            }
        }
    }
}
