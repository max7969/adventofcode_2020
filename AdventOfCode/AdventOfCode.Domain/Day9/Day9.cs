using System.Collections.Generic;
using System.Linq;
using System.Net;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day9
{
    public class Day9
    {
        public long Compute(string filePath, int size)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();

            List<long> elements = lines.Select(long.Parse).ToList();

            for (int i = size; i < elements.Count; i++)
            {
                var sublist = elements.GetRange(i - size >= 0 ? i - size : 0, i + size > elements.Count ? elements.Count - i : size);
                if (!IsCreatable(elements[i], sublist))
                {
                    return elements[i];
                }
            }

            return 0;
        }

        public long Compute2(string filePath, long weakness)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();
            List<long> elements = lines.Select(long.Parse).ToList();

            for (int size = 2; size <= elements.Count; size++)
            {
                var sublists = GetSubLists(elements, size);
                var uniqueSublist = sublists.SingleOrDefault(x => x.Sum() == weakness);
                if (uniqueSublist != null)
                {
                    return uniqueSublist.Min() + uniqueSublist.Max();
                }
            }
            return 0;
        }

        private List<List<long>> GetSubLists(List<long> elements, int size)
        {
            List<List<long>> sublist = new List<List<long>>();
            for (int i = 0; i < elements.Count - size; i++)
            {
                sublist.Add(elements.GetRange(i, size));
            }

            return sublist;
        } 

        private bool IsCreatable(long target, List<long> elements)
        {
            foreach (var element in elements)
            {
                foreach (var secondElement in elements)
                {
                    if (element + secondElement == target)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
