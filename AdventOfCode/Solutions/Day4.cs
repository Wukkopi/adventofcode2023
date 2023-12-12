namespace AdventOfCode.Solutions
{
    public class Day4 : Day<int>
    {
        public Day4(string[] input) : base(input) { }
        protected override int SolvePart1()
        {
            var result = 0;
            foreach (var card in input)
            {
                ParseCard(card, out var _, out var left, out var right);
                var sameNumbers = left.Intersect(right).Count();

                if (sameNumbers > 0)
                {
                    result += 1 << sameNumbers - 1;
                }
            }
            return result;
        }

        protected override int SolvePart2()
        {
            var result = 0;
            var sparePile = new Stack<string>(input);
            while (sparePile.Count > 0)
            {
                result++;
                ParseCard(sparePile.Pop(), out var cardId, out var left, out var right);
                var cardsWon = left.Intersect(right).Count();
                for (var j = 0; j < cardsWon; j++)
                {
                    sparePile.Push(input[cardId + j]);
                }
            }
            return result;
        }

        private void ParseCard(string input, out int cardId, out List<string> left, out List<string> right)
        {
            var split = input.Split(':');
            cardId = int.Parse(split[0].Substring(5));

            var numbersPart = split[1];
            var numbers = numbersPart.Split('|');

            left = numbers[0].Split(' ').ToList();
            right = numbers[1].Split(' ').ToList();

            left.RemoveAll(string.IsNullOrEmpty);
            right.RemoveAll(string.IsNullOrEmpty);
        }
    }
}
