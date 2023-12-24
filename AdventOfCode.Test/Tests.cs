using AdventOfCode.Solutions;

namespace AdventOfCode.Test
{
    public class Tests
    {

        [Test]
        public void TestDay1()
        {
            var input = new string[] { "asv23v43", "2vdv3", "123", "alxkjdone" }; // 23 + 23 + 13 + 11 = 70
            var day = new Day1(input);

            Assert.That(day.Part1, Is.EqualTo(59));
            Assert.That(day.Part2, Is.EqualTo(70));
        }

        [Test]
        public void TestDay2()
        {
            var input = new string[] {
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
            };

            var day = new Day2(input);

            Assert.That(day.Part1, Is.EqualTo(8));
            Assert.That(day.Part2, Is.EqualTo(2286));
        }

        [Test]
        public void TestDay3()
        {
            var input = new string[]
            {
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598.."
            };

            var day = new Day3(input);
            Assert.That(day.Part1, Is.EqualTo(4361));
            Assert.That(day.Part2, Is.EqualTo(467835));
        }

        [Test]
        public void TestDay4()
        {
            var input = new string[]
            {
                "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
                "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
                "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
                "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
                "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
            };
            var day = new Day4(input);
            Assert.That(day.Part1, Is.EqualTo(13));
            Assert.That(day.Part2, Is.EqualTo(30));
        }

        [Test]
        public void TestDay5()
        {
            var input = new string[]
            {
                "seeds: 79 14 55 13",
                "",
                "seed-to-soil map:",
                "50 98 2",
                "52 50 48",
                "",
                "soil-to-fertilizer map:",
                "0 15 37",
                "37 52 2",
                "39 0 15",
                "",
                "fertilizer-to-water map:",
                "49 53 8",
                "0 11 42",
                "42 0 7",
                "57 7 4",
                "",
                "water-to-light map:",
                "88 18 7",
                "18 25 70",
                "",
                "light-to-temperature map:",
                "45 77 23",
                "81 45 19",
                "68 64 13",
                "",
                "temperature-to-humidity map:",
                "0 69 1",
                "1 0 69",
                "",
                "humidity-to-location map:",
                "60 56 37",
                "56 93 4"
            };
            var day = new Day5(input);
            Assert.That(day.Part1, Is.EqualTo(35));
            Assert.That(day.Part2, Is.EqualTo(46));
        }

        [Test]
        public void TestDay6()
        {
            var input = new string[]
            {
                "Time:      7  15   30",
                "Distance:  9  40  200"
            };
            var day = new Day6(input);
            Assert.That(day.Part1, Is.EqualTo(288));
            Assert.That(day.Part2, Is.EqualTo(71503));
        }

        [Test]
        public void TestDay7()
        {
            var input = new string[]
            {
                "32T3K 765",
                "T55J5 684",
                "KK677 28",
                "KTJJT 220",
                "QQQJA 483"
            };
            var day = new Day7(input);
            Assert.That(day.Part1, Is.EqualTo(6440));
            Assert.That(day.Part2, Is.EqualTo(5905));
        }

        [Test]
        public void TestDay8Part1()
        {
            var input = new string[]
            {
                "LLR",
                "",
                "AAA = (BBB, BBB)",
                "BBB = (AAA, ZZZ)",
                "ZZZ = (ZZZ, ZZZ)"
            };
            var day = new Day8(input);
            Assert.That(day.Part1, Is.EqualTo(6));
            //Assert.That(day.Part2, Is.EqualTo(5905));
        }
        [Test]
        public void TestDay8Part2()
        {
            var input = new string[]
            {
                "LR",
                "",
                "11A = (11B, XXX)",
                "11B = (XXX, 11Z)",
                "11Z = (11B, XXX)",
                "22A = (22B, XXX)",
                "22B = (22C, 22C)",
                "22C = (22Z, 22Z)",
                "22Z = (22B, 22B)",
                "XXX = (XXX, XXX)"
            };
            var day = new Day8(input);
            Assert.That(day.Part2, Is.EqualTo(6));
        }

        [Test]
        public void TestLCM()
        {
            Assert.That(Utility.LCM(new long[] {2, 3}), Is.EqualTo(6));
            Assert.That(Utility.LCM(new long[] {9, 12, 21}), Is.EqualTo(252));
            Assert.That(Utility.LCM(new long[] {9, 12, 21, 23, 400}), Is.EqualTo(579600));

        }

        [Test]
        public void TestDay9()
        {
            var input = new string[]
            {
                "0 3 6 9 12 15",
                "1 3 6 10 15 21",
                "10 13 16 21 30 45" 
            };
            var day = new Day9(input);
            Assert.That(day.Part1, Is.EqualTo(114));
            Assert.That(day.Part2, Is.EqualTo(2));
        }

        [Test]
        public void TestDay10Part1()
        {
            var input = new string[]
            {
                "..F7.",
                ".FJ|.",
                "SJ.L7",
                "|F--J",
                "LJ...",
            };
            var day = new Day10(input);
            Assert.That(day.Part1, Is.EqualTo(8));
        }

        [Test]
        public void TestDay10Part2()
        {
            var input = new string[]
            {
                "FF7---7F7F7F7F7F---7",
                "L|L----J||||||||F--J",
                "FL-7iiii||||||LJL-77",
                "F--JF--7||LJLJiF7FJ-",
                "L---JF-JLJiiiiFJLJJ7",
                "|F|F-JF---SiiiL7L|7|",
                "|FFJF7L7F-JF7iiL---7",
                "7-L-JL7||F7|L7F-7F7|",
                "L.L7LFJ|||||FJL7||LJ",
                "L7JLJL-JLJLJL--JLJ.L",
            };
            var day = new Day10(input);
            Assert.That(day.Part2, Is.EqualTo(14));
        }

        [Test]
        public void TestDay10Part2_2()
        {
            var input = new string[]
            {
                ".S-------7.",
                ".|F-----7|.",
                ".||.....||.",
                ".||.....||.",
                ".|L-7.F-J|.",
                ".|..|.|..|.",
                ".L--J.L--J.",
                "...........",
            };
            var day = new Day10(input);
            Assert.That(day.Part2, Is.EqualTo(4));
        }
    }
}