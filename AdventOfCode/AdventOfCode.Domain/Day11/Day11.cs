using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day11
{
    public class Day11
    {
        public int Compute(string filePath, bool simpleNeighboursMode, int maxOccupied)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();
            var grid = ExtractGrid(lines);

            var nextGrid = grid.Select(x => x.Select(y => y).ToList()).ToList();
            bool change;
            do
            {
                change = false;
                grid = nextGrid.Select(x => x.Select(y => y).ToList()).ToList();

                for (int y = 0; y < grid.Count; y++)
                {
                    for (int x = 0; x < grid[0].Count; x++)
                    {
                        var neighbours = simpleNeighboursMode
                            ? SelectNeighbours(x, y, grid)
                            : SelectVisualNeighbours(x, y, grid);
                        if (neighbours.Count(e => e == "#") == 0 && nextGrid[y][x] == "L")
                        {
                            nextGrid[y][x] = "#";
                            change = true;
                        }
                        else if (neighbours.Count(e => e == "#") >= maxOccupied && nextGrid[y][x] == "#")
                        {
                            nextGrid[y][x] = "L";
                            change = true;
                        }
                    }
                }
            } while (change);

            return grid.SelectMany(line => line).Count(x => x == "#");
        }

        private List<string> SelectVisualNeighbours(int x, int y, List<List<string>> grid)
        {
            return new List<string>
            {
                GetFirstSeat(0, -1, x, y, grid),
                GetFirstSeat(1, -1, x, y, grid),
                GetFirstSeat(1, 0, x, y, grid),
                GetFirstSeat(1, 1, x, y, grid),
                GetFirstSeat(0, 1, x, y, grid),
                GetFirstSeat(-1, 1, x, y, grid),
                GetFirstSeat(-1, 0, x, y, grid),
                GetFirstSeat(-1, -1, x, y, grid)
            };
        }


        private string GetFirstSeat(int dirX, int dirY, int x, int y, List<List<string>> grid)
        {
            int sY = y + dirY;
            int sX = x + dirX;

            while (sY >= 0 && sY <= grid.Count -1 && sX >= 0 && sX <= grid[0].Count - 1)
            {
                if ((grid[sY][sX] == "L" || grid[sY][sX] == "#"))
                {
                    return grid[sY][sX];
                }
                sX += dirX;
                sY += dirY;
            }
            return ".";
        }

        private List<string> SelectNeighbours(int x, int y, List<List<string>> grid)
        {
            List<string> neighbours = new List<string>();
            for (int sY = (y > 0 ? y - 1 : 0); sY <= (y < grid.Count - 1 ? y + 1 : grid.Count - 1); sY++)
            {
                for (int sX = (x > 0 ? x - 1 : 0); sX <= (x < grid[0].Count - 1 ? x + 1 : grid[0].Count - 1); sX++)
                {
                    if (sX != x || sY != y)
                    {
                        neighbours.Add(grid[sY][sX]);
                    }
                }
            }
            return neighbours;
        }

        private static List<List<string>> ExtractGrid(List<string> lines)
        {
            List<List<string>> grid = lines.Select(x => x.ToCharArray().Select(x => x.ToString()).ToList()).ToList();
            return grid;
        }
    }
}
