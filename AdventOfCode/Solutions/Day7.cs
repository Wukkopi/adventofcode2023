using System.Reflection.Emit;
using System.Runtime.ExceptionServices;

namespace AdventOfCode.Solutions
{
    public class Day7 : Day<long>
    {
        private readonly struct Hand : IComparable<Hand>
        {
            public readonly string Label;
            public readonly long Bet;
            
            private readonly List<int> cardAmounts = new List<int>();
            private readonly bool jokers;

            private static readonly List<char> numbers = new List<char>() { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };
            private static readonly List<char> jokerNumbers = new List<char>() { 'A', 'K', 'Q', 'T', '9', '8', '7', '6', '5', '4', '3', '2', 'J' };

            public Hand (string label, long bet, bool jokers)
            {
                Label = label;
                Bet = bet;
                this.jokers = jokers;

                var buckets = new Dictionary<char, int>();

                var jCount = 0;
                foreach (var c in label)
                {
                    if (jokers && c == 'J')
                    {
                        jCount++;
                        continue;
                    }
                    if (buckets.ContainsKey(c))
                    {
                        buckets[c]++;
                        continue;
                    }
                    buckets[c] = 1;
                }

                if (jokers && buckets.Count == 0)
                {
                    buckets['J'] = 0;
                }
                
                cardAmounts.AddRange(buckets.Values);
                cardAmounts.Sort();
                cardAmounts.Reverse();

                cardAmounts[0] += jCount;
            }

            public int CompareTo(Hand other)
            {
                if (this.cardAmounts.Count != other.cardAmounts.Count)
                {
                    return this.cardAmounts.Count < other.cardAmounts.Count ? -1 : 1;
                }

                for (var i = 0; i < this.cardAmounts.Count; i++)
                {
                    if (this.cardAmounts[i] != other.cardAmounts[i])
                    {
                        return this.cardAmounts[i] > other.cardAmounts[i] ? -1 : 1;
                    }
                }

                for (var i = 0; i < this.Label.Length; i++)
                {
                    var order = this.jokers ? jokerNumbers : numbers;
                    var li = order.IndexOf(this.Label[i]);
                    var ri = order.IndexOf(other.Label[i]);
                    if (li != ri)
                    {
                        return li < ri ? -1 : 1;
                    }
                }
                return 0;
            }
        }


        public Day7(string[] input) : base(input)
        {
        }

        protected override long SolvePart1()
        {
            var hands = new List<Hand>();
            foreach(var line in input)
            {
                var split = line.Split(' ');
                hands.Add(new Hand(split[0], long.Parse(split[1]), false));
            }

            hands.Sort();
            hands.Reverse();

            var result = 0L;

            for(var i = 0; i < hands.Count; i++)
            {
                result += (i + 1) * hands[i].Bet;
            }
            return result;
        }

        protected override long SolvePart2()
        {
            var hands = new List<Hand>();
            foreach (var line in input)
            {
                var split = line.Split(' ');
                hands.Add(new Hand(split[0], long.Parse(split[1]), true));
            }

            hands.Sort();
            hands.Reverse();

            var result = 0L;

            for (var i = 0; i < hands.Count; i++)
            {
                result += (i + 1) * hands[i].Bet;
            }
            return result;
        }
    }
}