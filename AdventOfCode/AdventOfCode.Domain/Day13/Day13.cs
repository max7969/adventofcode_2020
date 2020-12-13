using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day13
{
    public class Day13
    {
        public long Compute(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();
            var timestamp = long.Parse(lines[0]);
            var buses = lines[1].Split(",").Where(x => x != "x").Select(x => long.Parse(x));
            var bus = buses.Select(x => new { number = x, wait = x - (timestamp % x) }).OrderBy(x => x.wait).First();
            return bus.number * bus.wait;
        }

        public long Compute2(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();
            var buses = lines[1].Split(",").Select(x => x != "x" ? long.Parse(x) : 1).ToList();
            long step = 1;
            long timestamp = 0;

            for (int i = 1; i <= buses.Count; i++)
            {
                var busRange = buses.GetRange(0, i);
                while (busRange.Where(x => x != 1).Any(x => (timestamp + busRange.IndexOf(x)) % x != 0))
                {
                    timestamp += step;
                }

                step = busRange.Aggregate((a, b) => a * b);

                if (buses.Where(x => x != 1).All(x => x - (timestamp % x) == buses.IndexOf(x) + 1))
                {
                    break;
                }
            }

            return timestamp;
        }
    }
}
