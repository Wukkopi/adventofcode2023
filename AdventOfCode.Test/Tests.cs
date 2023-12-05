namespace AdventOfCode.Test
{
    public class Tests
    {
        private string[] _day1Input;
        [SetUp]
        public void SetUp()
        {
            _day1Input = new string[] { "asv23v43", "2vdv3", "123", "alxkjdone" }; // 23 + 23 + 13 + 11 = 70
        }

        [Test]
        [TestCase(ExpectedResult = 70)]
        public int TestDay1()
        {
            return Day1.Part1(_day1Input);
        }
    }
}