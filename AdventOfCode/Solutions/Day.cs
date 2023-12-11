using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions
{
    public abstract class Day
    {
        protected readonly string[] input;
        public Day(string[] input)
        {
            this.input = input;
        }

        public int Part1 => SolvePart1();
        public int Part2 => SolvePart2();

        protected abstract int SolvePart1();
        protected abstract int SolvePart2();
    }
}
