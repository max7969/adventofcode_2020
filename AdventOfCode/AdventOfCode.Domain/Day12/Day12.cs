using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day12
{
    public class Day12
    {
        private Dictionary<string, Direction> directions = new Dictionary<string, Direction>
        {
            { "E", new Direction { X = 1, Y = 0} },
            { "S", new Direction { X = 0, Y = -1} },
            { "W", new Direction { X = -1, Y = 0 } },
            { "N", new Direction { X = 0, Y = 1} },
            { "F", null }
        };

        private Dictionary<string, int> rotations = new Dictionary<string, int>
        {
            { "R", 1 },
            { "L", -1 }
        };

        public int Compute(string filePath, bool waypointMode)
        {
            var steps = FileReader.GetFileContent(filePath);
            Ship ship = new Ship();
            if (waypointMode)
            {
                Waypoint waypoint = new Waypoint {X = 10, Y = 1};
                WayPointMode(steps, ship, waypoint);
            }
            else
            {
                NormalMode(steps, ship);
            }

            return Math.Abs(ship.X) + Math.Abs(ship.Y);
        }

        private void WayPointMode(IEnumerable<string> steps, Ship ship, Waypoint waypoint)
        {
            foreach (var step in steps)
            {
                var stepCode = ReadStep(step);
                if (directions.ContainsKey(stepCode.op))
                {
                    if (directions[stepCode.op] == null)
                    {
                        ship.Move(stepCode.value, new Direction {X = waypoint.X, Y = waypoint.Y});
                    }
                    else
                    {
                        waypoint.Move(stepCode.value, directions[stepCode.op]);
                    }
                }
                else
                {
                    waypoint.Rotate(stepCode.value * rotations[stepCode.op]);
                }
            }
        }

        private void NormalMode(IEnumerable<string> steps, Ship ship)
        {
            foreach (var step in steps)
            {
                var stepCode = ReadStep(step);
                if (directions.Keys.Contains(stepCode.op))
                {
                    ship.Move(stepCode.value, directions[stepCode.op]);
                }
                else
                {
                    ship.Rotate(stepCode.value * rotations[stepCode.op]);
                }
            }
        }

        private (string op, int value) ReadStep(string step)
        {
            var groups = Regex.Match(step, "^([A-Z]{1})([0-9]*)$").Groups;
            return (groups[1].ToString(), int.Parse(groups[2].ToString()));
        }

        public class Waypoint : SpacialObject
        {
            public void Rotate(int angle)
            {
                var prevX = X;
                var prevY = Y;
                var rotation = (angle / 90) * (Math.PI / 2);
                X = prevX * (int) Math.Round(Math.Cos(rotation)) + prevY * (int) Math.Round(Math.Sin(rotation));
                Y = (-prevX * (int) Math.Round(Math.Sin(rotation))) + prevY * (int)Math.Round(Math.Cos(rotation));
            }
        }

        public class SpacialObject
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Direction Dir { get; set; }

            public void Move(int steps, Direction dir)
            {
                if (dir == null)
                {
                    dir = Dir;
                }
                X += dir.X * steps;
                Y += dir.Y * steps;
            }
        }

        public class Ship : SpacialObject
        {
            public double Angle { get; set; }

            public Ship()
            {
                X = 0;
                Y = 0;
                Dir = new Direction
                {
                    X = 1,
                    Y = 0
                };
                Angle = Math.PI / 2;
            }

            public void Rotate(int angle)
            {
                Angle += (angle / 90) * (Math.PI / 2);
                Dir.X = (int) Math.Round(Math.Sin(Angle));
                Dir.Y = (int) Math.Round(Math.Cos(Angle));
            }
        }

        public class Direction
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

    }
}
