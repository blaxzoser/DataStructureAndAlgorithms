using NUnit.Framework;
using TrainingAlgorithms.algorithms.medium;

namespace TestTrainingAlgorithms.algorithms.medium
{
    public class LongestUniqueNumbersTest
    {
        LongestUniqueNumbers longestUniqueNumbers;

        [SetUp]
        public void Setup()
        {
            longestUniqueNumbers = new LongestUniqueNumbers();
        }

        [TestCase(new[] { 1, 2, 3, 1, 2, 3, 2, 2 }, 3)]
        [TestCase(new[] { 2, 2, 2, 2 }, 1)]
        [TestCase(new[] { 1, 2, 2, 3, 4, 5 }, 4)]
        [TestCase(new[] { 1, 2, 1, 3 }, 3)]
        [TestCase(new[] { 3, 1, 4, 1, 5, 9, 2 }, 5)]
        [TestCase(new[] { 4, 1, 1, 4 }, 2)]
        [TestCase(new[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new[] { 7 }, 1)]
        [TestCase(new int[0], 0)]
        public void ShouldGetLengthOfLongestUniqueRun(int[] numbers, int output)
        {
            Assert.AreEqual(output, longestUniqueNumbers.LengthOfLongest(numbers));
        }

        [Test]
        public void ShouldReturnZeroWhenNumbersIsNull()
        {
            Assert.AreEqual(0, longestUniqueNumbers.LengthOfLongest(null));
        }
    }
}
