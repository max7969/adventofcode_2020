using AdventOfCode.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace AdventOfCode.Domain.Day21
{
    public class Day21
    {
        public long Compute(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath);

            var foods = ReadInput(lines);
            var allergensDic = ExtractAllergensDic(foods);

            allergensDic.Select(x => x);

            return foods.SelectMany(x => x.Ingredients).Count();
        }

        public string Compute2(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath);

            var foods = ReadInput(lines);
            var allergensDic = ExtractAllergensDic(foods);


            return string.Join(",", allergensDic.OrderBy(x => x.Key).Select(x => x.Value).ToList());
        }


        private static Dictionary<string, string> ExtractAllergensDic(List<Food> foods)
        {
            Dictionary<string, string> allergensDic = new Dictionary<string, string>();
            var allergens = foods.SelectMany(x => x.Allergens).ToHashSet();
            while (allergensDic.Count != allergens.Count)
            {
                foreach (var allergen in allergens.Where(x => !allergensDic.ContainsKey(x)))
                {
                    var matchingIngredients = foods.Where(x => x.Allergens.Contains(allergen)).Select(x => x.Ingredients)
                        .Aggregate((a, b) => a.Intersect(b).ToList()).ToList();
                    if (matchingIngredients.Count == 1)
                    {
                        allergensDic.Add(allergen, matchingIngredients[0]);
                        foreach (var food in foods)
                        {
                            food.Ingredients.Remove(matchingIngredients[0]);
                        }
                    }
                }
            }

            return allergensDic;
        }

        private static List<Food> ReadInput(IEnumerable<string> lines)
        {
            return lines.Select(x => Regex.Match(x, "^([a-z ]*) \\(contains ([a-z, ]*)\\)$")).Select(match =>
            {
                return new Food
                {
                    Ingredients = match.Groups[1].ToString().Split(" ").ToList(),
                    Allergens = match.Groups[2].ToString().Split(", ").ToList()
                };
            }).ToList();
        }

        public class Food
        {
            public List<string> Ingredients { get; set; }
            public List<string> Allergens { get; set; }

        }
    }
}
