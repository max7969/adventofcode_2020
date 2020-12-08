using AdventOfCode.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain.Day8
{
    public class Day8
    {
        public int Compute(string filePath)
        {

            var lines = FileReader.GetFileContent(filePath).ToList();

            var program = ReadProgram(lines);
            return ExecuteUntilSecondTime(program).accumulator;
        }

        public int Compute2(string filePath)
        {

            var lines = FileReader.GetFileContent(filePath).ToList();

            var program = ReadProgram(lines);

            return program.Where(x => x.Operation != "acc")
                .Select(x => ExecuteUntilSecondTime(program, program.IndexOf(x)))
                .Single(x => x.endProperly).accumulator;
        }

        private Dictionary<string, (Func<int, int, int> nextIndex, Func<int, int, int> accIncrement)> Rules = 
            new Dictionary<string, (Func<int, int, int> nextIndex, Func<int, int, int> accIncrement)>
        {
            { "nop", ((x, y) => x + 1, (x, y) => x) },
            { "jmp", ((x, y) => x + y, (x, y) => x) },
            { "acc", ((x, y) => x + 1, (x, y) => x + y)}
        };

        private (int accumulator, bool endProperly) ExecuteUntilSecondTime(List<Node> program, int switchIndex = -1)
        {
            program.ForEach(x => x.CountExecution = 0);
            int accumulator = 0;
            int index = 0;
            Node actual = program[index];
            bool endProperly = false;
            while (actual.CountExecution == 0)
            {
                var operation = index == switchIndex ? (actual.Operation == "nop" ? "jmp" : "nop") : actual.Operation;
                endProperly = Rules[operation].nextIndex(index, actual.Value) == program.Count;
                index = Rules[operation].nextIndex(index, actual.Value) % program.Count;
                accumulator = Rules[operation].accIncrement(accumulator, actual.Value);
                actual.CountExecution++;
                actual = program[index];
            }

            return (accumulator, endProperly);
        }

        private static List<Node> ReadProgram(List<string> lines)
        {
            List<Node> nodes = new Node[lines.Count()].Select(x => new Node()).ToList();
            for (int i = 0; i < lines.Count(); i++)
            {
                nodes[i].Operation = lines[i].Split(' ')[0];
                nodes[i].Value = int.Parse(lines[i].Split(' ')[1]);
                nodes[i].Previous = i == 0 ? nodes[lines.Count() - 1] : nodes[i - 1];
                nodes[i].Next = i == lines.Count - 1 ? nodes[0] : nodes[i + 1];
            }

            return nodes;
        }

        public class Node
        {
            public string Operation { get; set; }
            public int CountExecution { get; set; }
            public int Value { get; set; }
            public Node Previous { get; set; }
            public Node Next { get; set; }
            public object Clone()
            {
                return new Node
                {
                    CountExecution = CountExecution, Operation = Operation, Value = Value, Previous = Previous,
                    Next = Next
                };
            }
        }
    }
}
