namespace AdventOfCode.Solutions
{
    public class Day5 : Day<long>
    {
        public class Map
        {
            public readonly struct Entry
            {
                public readonly long DestRangeStart;
                public readonly long SourceRangeStart;
                public readonly long RangeLength;

                public Entry(long destRangeStart, long sourceRangeStart, long rangeLength)
                {
                    DestRangeStart = destRangeStart;
                    SourceRangeStart = sourceRangeStart;
                    RangeLength = rangeLength;
                }
            }
            private readonly List<Entry> entries = new List<Entry>();
            public void AddEntry(Entry entry)
            {
                entries.Add(entry);
            }

            public long GetDestination(long source)
            {
                foreach(var entry in entries)
                {
                    if (source >= entry.SourceRangeStart &&
                        source < entry.SourceRangeStart + entry.RangeLength)
                        return source + (entry.DestRangeStart - entry.SourceRangeStart);
                }
                return source;
            }
        }

        private readonly string[] sequence = new string[] {
            "seed-to-soil",
            "soil-to-fertilizer",
            "fertilizer-to-water",
            "water-to-light",
            "light-to-temperature",
            "temperature-to-humidity",
            "humidity-to-location"
        };

        public Day5(string[] input) : base(input) { }

        protected override long SolvePart1()
        {
            var maps = parseMaps(false, out var seeds);

            var smallestLocation = long.MaxValue;
            foreach(var seed in seeds)
            {
                var destination = seed;
                foreach(var s in sequence)
                {
                    destination = maps[s].GetDestination(destination);
                }

                smallestLocation = destination < smallestLocation ? destination : smallestLocation;
            }
            return smallestLocation;
        }

        protected override long SolvePart2()
        {
            var maps = parseMaps(true, out var seeds);

            var l = seeds.Length;

            var smallestLocation = long.MaxValue;
            Parallel.ForEach(seeds, seed =>
            {
                if (--l % 100000 == 0)
                {
                    Console.WriteLine(l);
                }
                var destination = seed;
                foreach (var s in sequence)
                {
                    destination = maps[s].GetDestination(destination);
                }

                smallestLocation = destination < smallestLocation ? destination : smallestLocation;
            });
            return smallestLocation;
        }


        private Dictionary<string, Map> parseMaps(bool rangeSeeds, out long[] seeds)
        {
            var result = new Dictionary<string, Map>();
            seeds = null;

            Map map = null;
            foreach (var line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                if (line.StartsWith("seeds:"))
                {
                    var seedList = line.Split(':')[1].Trim().Split(' ').Select(long.Parse).ToArray();
                    if (!rangeSeeds)
                    {
                        seeds = seedList;
                        continue;
                    }

                    var listOfSeeds = new List<long>();
                    for(var i = 0; i < seedList.Length; i += 2)
                    {
                        var s = seedList[i];
                        var c = seedList[i + 1];
                        while(c-- >= 0)
                        {
                            listOfSeeds.Add(s + c);
                        }
                    }
                    seeds = listOfSeeds.ToArray();
                    continue;
                }
                if (line.EndsWith("map:"))
                {
                    var name = line.Split(' ')[0];
                    map = new Map();
                    result.Add(name, map);
                    continue;
                }

                var entry = line.Split(' ').Select(long.Parse).ToArray();
                map.AddEntry(new Map.Entry(entry[0], entry[1], entry[2]));
            }

            return result;
        }
    }
}