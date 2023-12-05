using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day1
    {
        private static readonly string[] digits = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        public static int Part1(string[] input)
        {
            var result = 0;
            foreach(var line in input)
            {
                var values = new char[2];
                for(var i = 0; i < line.Length; i++)
                {
                    var digit = '-';
                    if (char.IsDigit(line[i]))
                    {
                        digit = line[i];
                    }
                    else if (Part2(line, i, out var number))
                    {
                        digit = number;
                    }
                    else
                    {
                        continue;
                    }
                    values[0] = values[0] == 0 ? digit : values[0];
                    values[1] = digit;
                }
                result += values[0] != 0 ? int.Parse(string.Concat(values)) : 0;
            }
            return result;
        }

        private static bool Part2(string input, int index, out char digit)
        {
            digit = '-';
            var testInput = input.Substring(index);
            for (var i = 0; i < digits.Length; i++)
            {
                if (testInput.StartsWith(digits[i]))
                {
                    digit = char.Parse(i.ToString());
                    return true;
                }
            }
            return false;
        }
    }
}
