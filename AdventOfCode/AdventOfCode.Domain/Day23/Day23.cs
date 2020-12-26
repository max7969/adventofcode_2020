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

            var nodes = CreateNodes(cups);

            PlayCrabs(moves, nodes);

            string result = "";
            Node printcursor = nodes.Single(x => x.Value == 1).Next;

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

            cups.AddRange(Enumerable.Range(10, 1000000).ToList());

            var nodes = CreateNodes(cups);

            PlayCrabs(moves, nodes);
            
            return nodes.Single(x => x.Value == 1).Next.Value * nodes.Single(x => x.Value == 1).Next.Next.Value;
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

        private static void PlayCrabs(int moves, List<Node> nodes)
        {
            Node current = nodes[0];
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
                while (selected == null)
                {
                    max = cursor.Value > max.Value ? cursor : max;

                    if (cursor == current)
                    {
                        searchValue = searchValue - 1;
                    }

                    if (cursor.Value == searchValue)
                    {
                        selected = cursor;
                    }
                    else if (searchValue <= -1)
                    {
                        selected = max;
                    }

                    cursor = cursor.Next;
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
