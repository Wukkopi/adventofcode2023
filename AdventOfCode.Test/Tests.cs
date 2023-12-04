namespace AdventOfCode.Test
{
    public class Tests
    {
        private string[] _day1Input;
        [SetUp]
        public void SetUp()
        {
            _day1Input = new string[] { "asv23v43", "2vdv3", "123", "alxkjd" }; // 23 + 23 + 13 + 0 = 59
        }

        [Test]
        [TestCase(ExpectedResult = 59)]
        public int TestDay1()
        {
            return Day1.getCalibrationValue(_day1Input);
        }
    }
}