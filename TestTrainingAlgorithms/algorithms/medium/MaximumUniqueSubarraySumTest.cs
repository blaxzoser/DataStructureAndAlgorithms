using NUnit.Framework;
using TrainingAlgorithms.algorithms.medium;

namespace TestTrainingAlgorithms.algorithms.medium
{
    public class MaximumUniqueSubarraySumTest
    {
        MaximumUniqueSubarraySum maximumUniqueSubarraySum;

        [SetUp]
        public void Setup()
        {
            maximumUniqueSubarraySum = new MaximumUniqueSubarraySum();
        }

        [TestCase(new[] { 4, 2, 4, 5, 6 }, 17)]
        [TestCase(new[] { 5, 2, 1, 2, 5, 2, 1, 2, 5 }, 8)]
        [TestCase(new[] { 1, 2, 3, 1, 9 }, 15)]
        [TestCase(new[] { 10, 1, 1, 2 }, 11)]
        [TestCase(new[] { 2, 1, 1, 2 }, 3)]
        [TestCase(new[] { 7, 7, 7 }, 7)]
        [TestCase(new[] { 1, 2, 3, 4 }, 10)]
        [TestCase(new[] { 5 }, 5)]
        [TestCase(new int[0], 0)]
        public void ShouldGetMaximumUniqueSubarraySum(int[] numbers, int output)
        {
            Assert.AreEqual(output, maximumUniqueSubarraySum.MaxSum(numbers));
        }

        [Test]
        public void ShouldReturnZeroWhenNumbersIsNull()
        {
            Assert.AreEqual(0, maximumUniqueSubarraySum.MaxSum(null));
        }
    }
}
