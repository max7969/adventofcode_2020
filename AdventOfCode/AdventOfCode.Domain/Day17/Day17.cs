using AdventOfCode.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain.Day17
{
    public class Day17
    {
        public long Compute(string filePath, int dimensions)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();

            List<Cube> cubes = new List<Cube>();

            for (int i = 0; i < lines.Count(); i++)
            {
                for (int j = 0; j < lines[i].ToCharArray().Length; j++)
                {
                    cubes.Add(new Cube {X = j, Y = i, Z = 0, W = 0, Value = lines[i][j]});
                }
            }

            for (int cycle = 0; cycle < 6; cycle++)
            {
                List<Cube> newLayer = ExtendLayer(cubes, dimensions);

                foreach (var cube in newLayer)
                {
                    var neighbours = GetNeighbours(cube, cubes);
                    if (cube.Value == '#' &&
                        (neighbours.Count(x => x == '#') != 2 && neighbours.Count(x => x == '#') != 3))
                    {
                        cube.Value = '.';
                    }

                    if (cube.Value == '.' &&
                        neighbours.Count(x => x == '#') == 3)
                    {
                        cube.Value = '#';
                    }
                }

                cubes = newLayer;
            }

            return cubes.Count(x => x.Value == '#');
        }

        private List<char> GetNeighbours(Cube target, List<Cube> cubes)
        {
            List<char> neighboursValue = new List<char>();
            neighboursValue.AddRange(
                cubes.Where(x => 
                        Math.Abs(target.X - x.X) <= 1 
                        && Math.Abs(target.Y - x.Y) <= 1 
                        && Math.Abs(target.Z - x.Z) <= 1 
                        && Math.Abs(target.W - x.W) <= 1)
                    .Select(x => x.Value));
            neighboursValue.Remove(target.Value);
            return neighboursValue;
        }

        private List<Cube> ExtendLayer(List<Cube> initial, int dimensions)
        {
            Dictionary<string, Cube> newCubes = new Dictionary<string, Cube>();
            int minX = initial.Min(x => x.X);
            int maxX = initial.Max(x => x.X);
            int minY = initial.Min(x => x.Y);
            int maxY = initial.Max(x => x.Y);
            int minZ = initial.Min(x => x.Z);
            int maxZ = initial.Max(x => x.Z);
            int minW = dimensions == 4 ? initial.Min(x => x.W) : 1;
            int maxW = dimensions == 4 ? initial.Max(x => x.W) : -1;
            
            for (int k = minZ - 1; k <= maxZ + 1; k++)
            {
                for (int i = minY - 1; i <= maxY + 1; i++)
                {
                    for (int j = minX - 1; j <= maxX + 1; j++)
                    {
                        for (int l = minW - 1; l <= maxW + 1; l++)
                        {
                            var newCube = new Cube {X = j, Y = i, Z = k, W = l, Value = '.'};
                            newCubes.Add(newCube.Coordinates, newCube);
                        }
                    }
                }
            }

            foreach (var coordinate in initial.Where(x => x.Value == '#').Select(x => x.Coordinates))
            {
                newCubes[coordinate].Value = '#';
            }
            return newCubes.Values.ToList();
        }

        public class Cube
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
            public int W { get; set; }
            public char Value { get; set; }
            public string Coordinates => $"{X},{Y},{Z},{W}";
        }
    }
}
