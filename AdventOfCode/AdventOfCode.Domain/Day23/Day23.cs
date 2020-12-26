using AdventOfCode.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace AdventOfCode.Domain.Day23
{
    public class Day23
    {
        public string Compute(string filePath, int moves)
        {
            var line = FileReader.GetFileContent(filePath).ToList()[0];

            var cups = line.ToCharArray().Select(x => int.Parse(x.ToString())).ToList();

            var nodes = CreateNodes(cups).ToDictionary(x => x.Value);

            PlayCrabs(moves, nodes);

            string result = "";
            Node printcursor = nodes.Values.Single(x => x.Value == 1).Next;

            while (printcursor.Value != 1)
            {
                result += printcursor.Value;
                printcursor = printcursor.Next;
            }

            return result;
        }

        public long Compute2(string filePath, int moves)
        {
            var line = FileReader.GetFileContent(filePath).ToList()[0];

            var cups = line.ToCharArray().Select(x => int.Parse(x.ToString())).ToList();

            cups.AddRange(Enumerable.Range(10, 1000000 - 9).ToList());


            var nodes = CreateNodes(cups).ToDictionary(x => x.Value);

            PlayCrabs(moves, nodes);
            
            return nodes[1].Next.Value * nodes[1].Next.Next.Value;
        }

        private static List<Node> CreateNodes(List<int> cups)
        {
            List<Node> nodes = new List<Node>();
            foreach (var cup in cups)
            {
                nodes.Add(new Node()
                {
                    Value = cup
                });
            }

            nodes[0].Previous = nodes[nodes.Count - 1];
            nodes[nodes.Count - 1].Next = nodes[0];
            for (int i = 1; i < nodes.Count - 1; i++)
            {
                nodes[i - 1].Next = nodes[i];
                nodes[i].Previous = nodes[i - 1];
                nodes[i + 1].Previous = nodes[i];
                nodes[i].Next = nodes[i + 1];
            }

            return nodes;
        }

        private static void PlayCrabs(int moves, Dictionary<long, Node> nodes)
        {
            Node current = nodes.First().Value;

            List<long> fourMaxValues = nodes.Keys.OrderByDescending(x => x).ToList().GetRange(0, 4);

            for (int i = 0; i < moves; i++)
            {
                Node cutStart = current.Next;
                Node cutStop = current.Next.Next.Next;
                current.Next = current.Next.Next.Next.Next;
                current.Next.Previous = current;

                long searchValue = current.Value - 1;
                Node selected = null;
                Node cursor = current.Next;
                Node max = cursor;

                List<long> cutValues = new List<long>();
                cutValues.Add(cutStart.Value);
                cutValues.Add(cutStart.Next.Value);
                cutValues.Add(cutStop.Value);

                long maxAvailable = fourMaxValues.Where(x => !cutValues.Contains(x)).Max();

                List<long> searchedValues = new List<long>();
                for (long j=0; j<4;j++)
                {
                    if (searchValue - j > 0)
                    {
                        searchedValues.Add(searchValue - j);
                    }
                }
                List<long> selectedIndexes = searchedValues.Where(x => !cutValues.Contains(x)).ToList();

                if (!selectedIndexes.Any())
                {
                    selected = nodes[maxAvailable];
                } else
                {
                    selected = nodes[selectedIndexes.Max()];
                }

                selected.Next.Previous = cutStop;
                cutStop.Next = selected.Next;
                selected.Next = cutStart;
                cutStart.Previous = selected;

                current = current.Next;
            }
        }

        public class Node
        {
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public long Value { get; set; }
        }
    }
}
