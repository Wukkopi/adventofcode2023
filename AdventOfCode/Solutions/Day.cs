using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions
{
    public abstract class Day<T>
    {
        protected readonly string[] input;
        public Day(string[] input)
        {
            this.input = input;
        }

        public T Part1 => SolvePart1();
        public T Part2 => SolvePart2();

        protected abstract T SolvePart1();
        protected abstract T SolvePart2();
    }
}
