using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day3 : Day
    {
        public Day3(string[] input) : base(input) { }
        protected override int SolvePart1()
        {
            var result = 0;
            for (var y = 0; y < input.Length; y++)
            {
                for (var x = 0; x < input[y].Length; x++)
                {
                    if (tryFindNumber(input[y], x, out var number, out var digits))
                    {
                        var left = Math.Max(x - 1, 0);
                        var right = Math.Min(digits + 1 + (x > 0 ? 1 : 0), input[y].Length - left);
                        x += digits;
                        if (containsSymbols(input[Math.Max(y - 1, 0)].Substring(left, right)) ||
                            containsSymbols(input[y].Substring(left, right)) ||
                            containsSymbols(input[Math.Min(y + 1, input.Length - 1)].Substring(left, right)))
                        {
                            result += number;
                        }
                    }
                }
            }
            return result;
        }

        protected override int SolvePart2()
        {
            var result = 0;
            var adjacentNumbers = new List<int>();
            for (var y = 0; y < input.Length; y++)
            {
                for (var x = 0; x < input[y].Length; x++)
                {
                    if (input[y][x] == '*')
                    {
                        adjacentNumbers.Clear();

                        if (y > 0)
                        {
                            adjacentNumbers.AddRange(findAdjacentNumbers(input[y - 1], x));
                        }
                        if (y < input.Length - 1)
                        {
                            adjacentNumbers.AddRange(findAdjacentNumbers(input[y + 1], x));
                        }
                        adjacentNumbers.AddRange(findAdjacentNumbers(input[y], x));

                        if (adjacentNumbers.Count == 2)
                        {
                            result += adjacentNumbers[0] * adjacentNumbers[1];
                        }
                    }
                }
            }
            return result;
        }

        private static bool tryFindNumber(string input, int index, out int number, out int digits)
        {
            digits = 0;
            number = 0;
            while (index < input.Length && char.IsDigit(input[index]))
            {
                digits++;
                index++;
            }
            if (digits == 0)
            {
                return false;
            }
            number = int.Parse(input.Substring(index - digits, digits));
            return true;
        }

        private static bool containsSymbols(string input)
        {
            return input.Trim(new char[] { '.', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }).Length > 0;
        }

        private static List<int> findAdjacentNumbers (string input, int gearIndex)
        {
            var result = new List<int>();
            for (var i = 0; i < input.Length; i++)
            {
                if (tryFindNumber(input, i, out var number, out var digits))
                {
                    if (gearIndex <= i + digits &&
                        gearIndex >= i - 1)
                        result.Add(number);
                    i += digits;
                }
            }
            return result;
        }
    }
}
