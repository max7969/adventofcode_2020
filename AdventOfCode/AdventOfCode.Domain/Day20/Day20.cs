using AdventOfCode.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace AdventOfCode.Domain.Day20
{
    public class Day20
    {
        public long Compute(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();

            var tiles = ExtractTiles(lines);

            var dico = BuildPossibleMatchs(tiles);

            var corners = dico.Where(x => x.Value.Count == 2).Select(x => x.Key.Id).ToList();
            return corners.Aggregate((a,b) => a * b);
        }

        public long Compute2(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();
            var tiles = ExtractTiles(lines);
            var dico = BuildPossibleMatchs(tiles);

            List<List<Tile>> puzzle = new List<List<Tile>>();
            puzzle.Add(new List<Tile> { dico.FirstOrDefault(x => x.Value.Count == 2).Key });
            

            return 0;
        }

        private static Dictionary<Tile, List<Tile>> BuildPossibleMatchs(List<Tile> tiles)
        {
            Dictionary<Tile, List<Tile>> dico =
                new Dictionary<Tile, List<Tile>>();
            foreach (var tile in tiles)
            {
                var otherTile = tiles.Where(x => x.Id != tile.Id);
                var possibleMatch = otherTile.SelectMany(x => x.Borders).Intersect(tile.Borders).Count();
                dico.Add(tile, otherTile.Where(x => x.Borders.Intersect(tile.Borders).Any()).ToList());
            }

            return dico;
        }

        private static List<Tile> ExtractTiles(List<string> lines)
        {
            List<Tile> tiles = new List<Tile>();
            for (int i = 0; i < lines.Count(); i = i + 12)
            {
                Tile tile = new Tile(long.Parse(Regex.Match(lines[i], "Tile ([0-9]+):").Groups[1].ToString()));

                for (int j = i + 1; j < i + 11; j++)
                {
                    tile.Content.Add(lines[j].Select(x => x.ToString()).ToList());
                }

                tiles.Add(tile);
            }

            tiles.ForEach(t => t.InitBorders());
            return tiles;
        }

        public class Tile
        {
            public long Id { get; set; }
            public List<List<string>> Content { get; set; }
            public List<string> Borders { get; set; }

            public Tile(long id)
            {
                Id = id;
                Content = new List<List<string>>();
                Borders = new List<string>();
            }
            public void InitBorders()
            {
                List<string> firstBorder = new List<string>();
                List<string> secondBorder = new List<string>();
                List<string> thirdBorder = new List<string>();
                List<string> fourthBorder = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    firstBorder.Add(Content[0][i]);
                    secondBorder.Add(Content[9][i]);
                    thirdBorder.Add(Content[i][0]);
                    fourthBorder.Add(Content[i][9]);
                }

                Borders.Add(string.Concat(firstBorder));
                firstBorder.Reverse();
                Borders.Add(string.Concat(firstBorder));
                Borders.Add(string.Concat(secondBorder));
                secondBorder.Reverse();
                Borders.Add(string.Concat(secondBorder));
                Borders.Add(string.Concat(thirdBorder));
                thirdBorder.Reverse();
                Borders.Add(string.Concat(thirdBorder));
                Borders.Add(string.Concat(fourthBorder));
                fourthBorder.Reverse();
                Borders.Add(string.Concat(fourthBorder));
            }
        }
    }
}
