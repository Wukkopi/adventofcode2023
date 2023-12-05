﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day2
    {
        public readonly struct DiceCollection
        {
            public readonly int Red;
            public readonly int Green;
            public readonly int Blue;
            public readonly int Power => Red * Green * Blue;
            public DiceCollection(int red = 0, int green = 0, int blue = 0)
            {
                Red = red;
                Green = green;
                Blue = blue;
            }

            public static bool operator < (DiceCollection a, DiceCollection b)
            {
                return a.Red < b.Red || a.Green < b.Green || a.Blue < b.Blue;
            }
            public static bool operator > (DiceCollection a, DiceCollection b)
            {
                return !(a < b);
            }
            public static DiceCollection Max(DiceCollection a, DiceCollection b)
            {
                return new DiceCollection(Math.Max(a.Red, b.Red), Math.Max(a.Green, b.Green), Math.Max(a.Blue, b.Blue));
            }
        }

        public static int Part1(string[] input)
        {
            var entries = new Dictionary<string, int>();
            var result = 0;

            for (var i = 0; i < input.Length; i++)
            {
                var records = input[i].Substring(input[i].IndexOf(':') + 1).Split(';');
                var minimumDice = new DiceCollection();
                foreach(var record in records)
                {
                    entries.Clear();
                    foreach (var dice in record.Split(','))
                    {
                        var entry = dice.Trim().Split(' ');
                        entries.Add(entry[1], int.Parse(entry[0]));
                    }
                    var hand = new DiceCollection(entries.GetValueOrDefault("red"), entries.GetValueOrDefault("green"), entries.GetValueOrDefault("blue"));
                    minimumDice = DiceCollection.Max(hand, minimumDice);
                }

                result += minimumDice.Power;
                
            }
            return result;
        }
    }
}
