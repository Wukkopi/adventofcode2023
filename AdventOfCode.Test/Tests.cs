namespace AdventOfCode.Test
{
    public class Tests
    {

        [Test]
        public void TestDay1()
        {
            var input = new string[] { "asv23v43", "2vdv3", "123", "alxkjdone" }; // 23 + 23 + 13 + 11 = 70
            var result = Day1.Part1(input);
            Assert.That(result, Is.EqualTo(70));
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

            var result = Day2.Part1(input);
            Assert.That(result, Is.EqualTo(2286));
        }

    }
}