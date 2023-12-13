namespace AdventOfCode.Solutions
{
    public class Day6 : Day<long>
    {
        private readonly struct Race
        {
            public readonly long Duration;
            public readonly long Record;

            public Race(long duration, long record)
            {
                Duration = duration;
                Record = record;
            }

            public long WaysToWin => MaxHoldToWin() - MinHoldToWin() + 1;

            private long MinHoldToWin()
            {
                for (var i = 0; i <= Duration; i++)
                {
                    if (i * (Duration - i) > Record)
                    {
                        return i;
                    }
                }
                return -1;
            }
            private long MaxHoldToWin()
            {
                for (var i = Duration; i >= 0; i--)
                {
                    if (i * (Duration - i) > Record)
                    {
                        return i;
                    }
                }
                return -1;

            }

        }
        public Day6(string[] input) : base(input) { }

        protected override long SolvePart1()
        {
            var races = parseRaces();
            var result = 1l;
            foreach(var race in races)
            {
                result *= race.WaysToWin;
            }
            return result;
        }

        protected override long SolvePart2()
        {
            var time = long.Parse(input[0].Substring(5).Replace(" ", ""));
            var record = long.Parse(input[1].Substring(9).Replace(" ", ""));
            return new Race(time, record).WaysToWin;
        }

        private List<Race> parseRaces()
        {
            var result = new List<Race>();

            var timesList = input[0].Substring(5).Split(' ').ToList();
            timesList.RemoveAll(string.IsNullOrEmpty);
            var times = timesList.Select(long.Parse).ToArray();

            var recordsList = input[1].Substring(9).Split(' ').ToList();
            recordsList.RemoveAll(string.IsNullOrEmpty);
            var records = recordsList.Select(long.Parse).ToArray();

            for (var i = 0;i < times.Length;i++)
            {
                result.Add(new Race(times[i], records[i]));
            }
            return result;
        }


    }
}