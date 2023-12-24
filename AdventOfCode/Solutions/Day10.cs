using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static AdventOfCode.Solutions.Day9;

namespace AdventOfCode.Solutions
{
    public class Day10 : Day<long>
    {
        private readonly struct Point
        {
            public readonly int X;
            public readonly int Y;
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public Point North => new Point(X, Y - 1);
            public Point South => new Point(X, Y + 1);
            public Point West => new Point(X - 1, Y);
            public Point East => new Point(X + 1, Y);

            public static bool operator == (Point a, Point b)
            {
                return a.X == b.X && a.Y == b.Y;
            }
            public static bool operator != (Point a, Point b)
            {
                return !(a == b);
            }

            public string ToString()
            {
                return $"[{X}, {Y}]";
            }
            public Point FirstContact(List<Point> history)
            {
                var t = this;
                return history.Find(x => x == t.North || x == t.West || x == t.East || x == t.South);
            }

        }

        public Day10(string[] input) : base(input) { }

        private Point findStartPoint()
        {
            for (var y = 0; y < input.Length; y++)
            {
                for (var x = 0; x < input[y].Length; x++)
                {
                    if (input[y][x] == 'S')
                    {
                        return new Point(x, y);
                    }
                }
            }
            throw new Exception("START NOT FOUND");
        }

        private readonly char[] NorthPipes = new char[] { '|', '7', 'F', 'S' };
        private readonly char[] SouthPipes = new char[] { '|', 'J', 'L', 'S' };
        private readonly char[] WestPipes = new char[] { '-', 'L', 'F', 'S' };
        private readonly char[] EastPipes = new char[] { '-', '7', 'J', 'S' };
        

        private List<Point> findLoopFrom(Point start)
        {
            var loop = new List<Point>() { start };
            while(true)
            {
                var current = loop.Last();
                if (current.Y > 0 && !loop.Contains(current.North))
                {
                    if (SouthPipes.Contains(input[current.Y][current.X]) &&
                        NorthPipes.Contains(input[current.North.Y][current.X]))
                    {
                        loop.Add(current.North);
                        continue;
                    }
                }
                if (current.Y < input.Length - 1 && !loop.Contains(current.South))
                {
                    if (NorthPipes.Contains(input[current.Y][current.X]) &&
                        SouthPipes.Contains(input[current.South.Y][current.X]))
                    {
                        loop.Add(current.South);
                        continue;
                    }
                }
                if (current.X > 0 && !loop.Contains(current.West))
                {
                    if (EastPipes.Contains(input[current.Y][current.X]) &&
                        WestPipes.Contains(input[current.Y][current.West.X]))
                    {
                        loop.Add(current.West);
                        continue;
                    }
                }
                if (current.X < input[current.Y].Length - 1 && !loop.Contains(current.East))
                {
                    if (WestPipes.Contains(input[current.Y][current.X]) &&
                        EastPipes.Contains(input[current.Y][current.East.X]))
                    {
                        loop.Add(current.East);
                        continue;
                    }
                }
                break;
            }
            return loop;
        }

        protected override long SolvePart1()
        {
            var start = findStartPoint();
            var loop = findLoopFrom(start);

            return loop.Count / 2;
        }

        protected override long SolvePart2()
        {
            var result = 0;
            var start = findStartPoint();
            var fullLoop = findLoopFrom(start);

            for (var y = 0; y < input.Length; y++)
            {
                bool inLoop = false;
                bool inPipe = false;
                int direction = 0;
                var add = 0;
                for (var x = 0; x < input[y].Length; x++)
                {
                    if (fullLoop.Contains(new Point(x, y)))
                    {
                        var c = input[y][x];
                        if (NorthPipes.Contains(c) || SouthPipes.Contains(c))
                        {
                            if (c != '|')
                            {
                                inPipe = !inPipe;
                                if (inPipe)
                                {
                                    direction = c switch
                                    {
                                        'S' => SouthPipes.Contains(input[y + 1][x]) ? -1 : 1, // southern cell leads here
                                        _ => SouthPipes.Contains(c) ? 1 : -1, // this leads to north
                                    };
                                    continue;
                                }
                                if (direction == 1 && NorthPipes.Contains(c) &&
                                    (fullLoop.Contains(new Point(x, y + 1)) && SouthPipes.Contains(input[y + 1][x])) ||
                                    direction == -1 && SouthPipes.Contains(c) &&
                                    (fullLoop.Contains(new Point(x, y - 1)) && NorthPipes.Contains(input[y - 1][x])))
                                {
                                    if (inLoop)
                                    {
                                        result += add;
                                        add = 0;
                                    }
                                    inLoop = !inLoop;
                                }
                            }
                            else
                            {
                                if (inLoop)
                                {
                                    result += add;
                                    add = 0;
                                }
                                inLoop = !inLoop;
                            }
                        }
                    }
                    else if (inLoop)
                    {
                        add++;
                    }
                }
            }
            return result;
        }
    }
}
