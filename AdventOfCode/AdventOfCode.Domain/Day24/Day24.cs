using AdventOfCode.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace AdventOfCode.Domain.Day24
{
    public class Day24

    {
        public long Compute(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath);
            Dictionary<string, Tile> tiles = ReadInitialState(lines);

            return tiles.Count(x => x.Value.FlipCount % 2 == 1);
        }

        public long Compute2(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath);
            Dictionary<string, Tile> tiles = ReadInitialState(lines);

            for (int i = 0; i < 100; i++)
            {
                var keysToRemove = tiles.Where(x => x.Value.FlipCount % 2 == 0).Select(x => x.Key).ToList();
                keysToRemove.ForEach(x => tiles.Remove(x));

                foreach (var tile in tiles.Select(x => x.Value).ToList())
                {
                    var neighbours = tile.GetNeighbours();
                    foreach(var neighbour in neighbours)
                    {
                        if (!tiles.ContainsKey($"{neighbour.X};{neighbour.Y}"))
                        {
                            tiles.Add($"{neighbour.X};{neighbour.Y}", new Tile
                            {
                                X = neighbour.X,
                                Y = neighbour.Y,
                                FlipCount = 0
                            });
                        }
                    }
                }

                var copyTiles = new Dictionary<string, Tile>(tiles.Select(x => new KeyValuePair<string, Tile>(x.Key, new Tile { X = x.Value.X, Y = x.Value.Y, FlipCount = x.Value.FlipCount })).ToList());
                foreach (var tile in tiles.Values)
                {
                    var neighbours = new List<Tile>();
                    foreach (var nCoord in tile.GetNeighbours())
                    {
                        if (copyTiles.TryGetValue($"{nCoord.X};{nCoord.Y}", out Tile n))
                        {
                            neighbours.Add(n);
                        }
                    }
                    if (tile.FlipCount % 2 == 0 && neighbours.Count(x => x.FlipCount % 2 == 1) == 2)
                    {
                        tile.FlipCount += 1;
                    }
                    if (tile.FlipCount % 2 == 1 && (neighbours.Count(x => x.FlipCount % 2 == 1) == 0
                        || neighbours.Count(x => x.FlipCount % 2 == 1) > 2))
                    {
                        tile.FlipCount += 1;
                    }
                }
            }


            return tiles.Count(x => x.Value.FlipCount % 2 == 1);
        }

        private static Dictionary<string, Tile> ReadInitialState(IEnumerable<string> lines)
        {
            Dictionary<string, Tile> tiles = new Dictionary<string, Tile>();
            foreach (var line in lines)
            {
                var countSw = Regex.Matches(line, "sw").Count;
                var countSe = Regex.Matches(line, "se").Count;
                var countNw = Regex.Matches(line, "nw").Count;
                var countNe = Regex.Matches(line, "ne").Count;
                var countE = Regex.Matches(line, "e").Count - countSe - countNe;
                var countW = Regex.Matches(line, "w").Count - countNw - countSw;

                var x = countE * 2 + countNe + countSe - countW * 2 - countSw - countNw;
                var y = countNw + countNe - countSe - countSw;
                string key = string.Concat(x, ";", y);

                if (tiles.ContainsKey(key))
                {
                    tiles[key].FlipCount++;
                }
                else
                {
                    tiles[key] = new Tile
                    {
                        X = x,
                        Y = y,
                        FlipCount = 1
                    };
                }
            }

            return tiles;
        }

        public class Tile
        {
            public long X { get; set; }
            public long Y { get; set; }
            public long FlipCount { get; set; }

            public List<(long X, long Y)> GetNeighbours()
            {
                return new List<(long X, long Y)>
                {
                    (X - 2, Y),
                    (X + 2, Y),
                    (X + 1, Y - 1),
                    (X + 1, Y + 1),
                    (X - 1, Y - 1),
                    (X - 1, Y + 1)
                };
            }
        }
    }
}
