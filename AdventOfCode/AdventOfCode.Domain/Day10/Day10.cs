using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day10
{
    public class Day10
    {
        public int Compute(string filePath)
        {
            int countOne = 0;
            int countThree = 0;
            var lines = FileReader.GetFileContent(filePath);
            var values = lines.Select(int.Parse).ToList();
            values.Add(0);
            values.Add(values.Max() + 3);

            values = values.OrderBy(x => x).ToList();

            for (int i = 1; i < values.Count; i++)
            {
                countOne += values[i] - values[i - 1] == 1 ? 1 : 0;
                countThree += values[i] - values[i - 1] == 3 ? 1 : 0;
            }
            return countOne * countThree;
        }


        public long Compute2(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath);
            var values = lines.Select(int.Parse).OrderBy(x => x).ToList();
            values.Add(0);
            values.Add(values.Max() + 3);
            var pathTo = new Dictionary<int, List<int>>();
            for (int i = 0; i < values.Count; i++)
            {
                pathTo.Add(values[i], new List<int>());
                for (int j = 1; j <= 3; j++)
                {
                    if (values.Contains(values[i] + j))
                    {
                        pathTo[values[i]].Add(values[i] + j);
                    }
                }
            }

            var subGraphs = SplitInSubGraphs(pathTo, values);

            return subGraphs.Select(x => CountPathRecursive(x, x.Keys.Min())).Aggregate((a, b) => a * b);
        }

        private List<Dictionary<int, List<int>>> SplitInSubGraphs(Dictionary<int, List<int>> graph, List<int> values)
        {
            List<Dictionary<int, List<int>>> graphs = new List<Dictionary<int, List<int>>>();

            List<int> cuts = new List<int>();
            var allPath = graph.SelectMany(x => x.Value);
            foreach (var element in graph)
            {
                if (values.IndexOf(element.Key) < values.Count - 4)
                {
                    var nextValues = FindNextThreeValues(element.Key, values);
                    if (!nextValues.Any(x => allPath.Count(y => y == x) > 1))
                    {
                        cuts.Add(element.Key);
                    }
                }
            }

            foreach (var cut in cuts)
            {
                var subGraph = new Dictionary<int, List<int>>(graph.Where(x => x.Key <= cut));
                subGraph[cut] = new List<int>();
                foreach (var subGraphKey in subGraph.Keys)
                {
                    graph.Remove(subGraphKey);
                }
                graphs.Add(subGraph);
            }
            graphs.Add(graph);

            return graphs;
        }

        private List<int> FindNextThreeValues(int target, List<int> values)
        {
            return values.Where(x => x >= target).OrderBy(x => x).ToList().GetRange(0, 3);
        }

        private long CountPathRecursive(Dictionary<int, List<int>> pathTo, int i)
        {
            if (!pathTo[i].Any())
            {
                return 1;
            }
            else
            {
                return pathTo[i].Select(x => CountPathRecursive(pathTo, x)).Sum();
            }
        }
    }
}
