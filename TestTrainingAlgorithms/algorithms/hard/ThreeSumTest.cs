using NUnit.Framework;
using TrainingAlgorithms.algorithms.hard;

namespace TestTrainingAlgorithms.algorithms.hard
{
    public class ThreeSumTest
    {
        ThreeSum threeSum;

        [SetUp]
        public void Setup()
        {
            threeSum = new ThreeSum();
        }

        [TestCase(new[] { 1, 1, -2 }, 1)]
        [TestCase(new[] { 1, 12, -1, 5, 4 }, 0)]
        [TestCase(new[] { -1, 0, 1, 2, -1, -4 }, 2)]
        [TestCase(new[] { -4, -1, -1, 0, 1, 2 }, 2)]
        [TestCase(new[] { -2, 0, 1, 1, 2 }, 2)]
        [TestCase(new[] { 0, 0, 0 }, 1)]
        [TestCase(new[] { 0, 0, 0, 0 }, 1)]
        [TestCase(new[] { -2, -2, 0, 0, 2, 2 }, 1)]
        [TestCase(new[] { -1, -1, -1, 2, 2 }, 1)]
        [TestCase(new[] { 3, -1, -2, -1, 2, 0, 1 }, 4)]
        [TestCase(new[] { 1, 2, 3 }, 0)]
        [TestCase(new[] { -1, -2, -3 }, 0)]
        [TestCase(new[] { 0, 1 }, 0)]
        [TestCase(new int[0], 0)]
        public void ShouldCountTripletsThatSumToZero(int[] numbers, int output)
        {
            Assert.AreEqual(output, threeSum.CountTriplets(numbers));
        }

        [Test]
        public void ShouldReturnZeroWhenInputIsNull()
        {
            Assert.AreEqual(0, threeSum.CountTriplets(null));
        }
    }
}
