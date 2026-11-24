using NUnit.Framework;
using TrainingAlgorithms.algorithms.medium;

namespace TestTrainingAlgorithms.algorithms.medium
{
    public class MaximumSumDistinctSubarrayOfLengthKTest
    {
        MaximumSumDistinctSubarrayOfLengthK maximumSumDistinct;

        [SetUp]
        public void Setup()
        {
            maximumSumDistinct = new MaximumSumDistinctSubarrayOfLengthK();
        }

        [TestCase(new[] { 1, 5, 4, 2, 9, 9, 9 }, 3, 15)]
        [TestCase(new[] { 4, 4, 4 }, 3, 0)]
        [TestCase(new[] { 1, 2, 1, 3, 4 }, 3, 8)]
        [TestCase(new[] { 9, 9, 1, 2, 3 }, 2, 10)]
        [TestCase(new[] { 1, 1, 1, 7, 8, 9 }, 3, 24)]
        [TestCase(new[] { 3, 1, 2 }, 1, 3)]
        [TestCase(new[] { 1, 2, 3, 4 }, 4, 10)]
        [TestCase(new[] { 5, 2, 1, 2, 5, 2, 1, 2, 5 }, 3, 8)]
        [TestCase(new[] { 1, 2 }, 3, 0)]
        [TestCase(new int[0], 2, 0)]
        public void ShouldGetMaximumSumOfDistinctSubarrayOfLengthK(int[] numbers, int k, int output)
        {
            Assert.AreEqual(output, maximumSumDistinct.MaxSum(numbers, k));
        }

        [Test]
        public void ShouldReturnZeroWhenNumbersIsNull()
        {
            Assert.AreEqual(0, maximumSumDistinct.MaxSum(null, 2));
        }
    }
}
