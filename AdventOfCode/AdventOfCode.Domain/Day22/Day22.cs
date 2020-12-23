using AdventOfCode.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace AdventOfCode.Domain.Day22
{
    public class Day22
    {
        public long Compute(string filePath, bool subGameMode)
        {
            var lines = FileReader.GetFileContent(filePath);
            List<Queue<long>> players = new List<Queue<long>>();
            foreach (var line in lines)
            {
                if (line.Contains("Player"))
                {
                    players.Add(new Queue<long>());
                }
                else if (!string.IsNullOrEmpty(line))
                {
                    players.Last().Enqueue(long.Parse(line));
                }
            }
            int cardCount = players.SelectMany(x => x).Count();
            int winnerIndex = PlayGame(players, subGameMode);
            return players[winnerIndex].Select((x, y) => x * (cardCount - y)).Sum();
        }

        private static int PlayGame(List<Queue<long>> players, bool subGameMode)
        {
            HashSet<string> turns = new HashSet<string>();
            while (players.All(x => x.Any()))
            {
                string actualTurn = string.Join(",", players[0]) + ":" + string.Join(",", players[1]);
                if (turns.Contains(actualTurn))
                {
                    return 0;
                }
                turns.Add(actualTurn);
                List<(long card, Queue<long> queue)> cardsToAdd = players.Select(x => (card: x.Peek(), queue: x)).ToList();

                if (subGameMode && cardsToAdd.All(x => x.queue.Count > x.card))
                {
                    int winnerIndex = PlayGame(players.Select(x => new Queue<long>(x.Where((y, z) => z >= 1 && z <= x.Peek()).ToList())).ToList(), true);
                    players[winnerIndex].Enqueue(cardsToAdd[winnerIndex].card);
                    players[winnerIndex].Enqueue(cardsToAdd[(winnerIndex + 1) % 2].card);
                }
                else
                {
                    players.Single(y => y.Contains(cardsToAdd.Max(x => x.card))).Enqueue(cardsToAdd.Max(x => x.card));
                    players.Single(y => y.Contains(cardsToAdd.Max(x => x.card))).Enqueue(cardsToAdd.Min(x => x.card));
                }
                players.ForEach(x => x.Dequeue());
            }

            return players.IndexOf(players.Single(x => x.Any()));
        }
    }
}
