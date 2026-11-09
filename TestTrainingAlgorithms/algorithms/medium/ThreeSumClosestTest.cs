using System;
using NUnit.Framework;
using TrainingAlgorithms.algorithms.medium;

namespace TestTrainingAlgorithms.algorithms.medium
{
    public class ThreeSumClosestTest
    {
        ThreeSumClosest threeSumClosest;

        [SetUp]
        public void Setup()
        {
            threeSumClosest = new ThreeSumClosest();
        }

        [TestCase(new[] { -1, 2, 1, -4 }, 1, 2)]
        [TestCase(new[] { 0, 0, 0 }, 1, 0)]
        [TestCase(new[] { 0, 2, 1, -3 }, 1, 0)]
        [TestCase(new[] { 1, 2, 3 }, 100, 6)]
        [TestCase(new[] { -5, -4, -3 }, 0, -12)]
        [TestCase(new[] { 1, 1, 1, 0 }, 3, 3)]
        [TestCase(new[] { 1, 1, 1, 0 }, -100, 2)]
        [TestCase(new[] { -1, 0, 1, 1, 55 }, 3, 2)]
        [TestCase(new[] { 4, 0, 5, -5, 3, 3, 0, -4, -5 }, -2, -2)]
        [TestCase(new[] { 1, 1, -1, -1, 3 }, -1, -1)]
        [TestCase(new[] { -1, 0, 1, 2, -1, -4 }, 0, 0)]
        public void ShouldReturnTheSumClosestToTheTarget(int[] numbers, int target, int output)
        {
            Assert.AreEqual(output, threeSumClosest.FindClosestSum(numbers, target));
        }

        [TestCase(new[] { 0, 1 })]
        [TestCase(new int[0])]
        [TestCase(null)]
        public void ShouldThrowWhenThereAreFewerThanThreeNumbers(int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => threeSumClosest.FindClosestSum(numbers, 1));
        }
    }
}
