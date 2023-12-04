using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day1
    {
        public static int getCalibrationValue(string[] input)
        {
            var result = 0;
            foreach(var line in input)
            {
                var values = new char[2];
                foreach(var c in line)
                {
                    if (char.IsDigit(c))
                    {
                        values[0] = values[0] == 0 ? c : values[0];
                        values[1] = c;
                    }
                }
                result += values[0] != 0 ? int.Parse(string.Concat(values)) : 0;
            }
            return result;
        }
    }
}
