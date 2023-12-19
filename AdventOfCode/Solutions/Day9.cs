using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static AdventOfCode.Solutions.Day9;

namespace AdventOfCode.Solutions
{
    public class Day9 : Day<long>
    {
        public class Sequence
        {
            public List<long> History {  get; private set; }
            public bool IsZero => History.Count == 0 || History.All(x => x == 0);
            public Sequence(string input)
            {
                History = Regex.Matches(input, @"(-?\d+)").Select(x => long.Parse(x.Value)).ToList();
            }
            public Sequence(long[] input)
            {
                History = new List<long>(input);
            }

            public Sequence GetSubSequence()
            {
                var deltas = new long[History.Count - 1];
                for (var i = 0; i < deltas.Length; i++)
                {
                    deltas[i] = History[i + 1] - History[i];
                }

                return new Sequence(deltas);
            }

            public void ExtrapolateWith(Sequence s, bool end)
            {
                if (s.History.Count == 0)
                {
                    if (end)
                        History.Add(History.Last());
                    else
                        History.Insert(0, History.First());
                }
                else
                {
                    if (end)
                        History.Add(History.Last() + s.History.Last());
                    else
                        History.Insert(0, History.First() - s.History.First());
                }
            }
        }

        public Day9(string[] input) : base(input)
        {
        }

        private Stack<Sequence> getSequenceStack(string input)
        {
            var stack = new Stack<Sequence>();
            var sequence = new Sequence(input);
            stack.Push(sequence);
            while (!(sequence = sequence.GetSubSequence()).IsZero)
            {
                stack.Push(sequence);
            }
            return stack;
        }

        protected override long SolvePart1()
        {
            var result = 0L;
            foreach(var line in input)
            {
                var stack = getSequenceStack(line);
                var sequence = new Sequence("0");

                while(stack.TryPop(out var s))
                {
                    s.ExtrapolateWith(sequence, true);
                    sequence = s;
                }
                result += sequence.History.Last();
            }
            return result;
        }

        protected override long SolvePart2()
        {
            var result = 0L;
            foreach (var line in input)
            {
                var stack = getSequenceStack(line);
                var sequence = new Sequence("0");

                while (stack.TryPop(out var s))
                {
                    s.ExtrapolateWith(sequence, false);
                    sequence = s;
                }
                result += sequence.History.First();
            }
            return result;
        }
    }
}
