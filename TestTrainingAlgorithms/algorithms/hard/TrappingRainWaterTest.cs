using NUnit.Framework;
using TrainingAlgorithms.algorithms.hard;

namespace TestTrainingAlgorithms.algorithms.hard
{
    public class TrappingRainWaterTest
    {
        TrappingRainWater rainWater;

        [SetUp]
        public void Setup()
        {
            rainWater = new TrappingRainWater();
        }

        [TestCase(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
        [TestCase(new[] { 4, 2, 0, 3, 2, 5 }, 9)]
        [TestCase(new[] { 2, 0, 2 }, 2)]
        [TestCase(new[] { 5, 4, 1, 2 }, 1)]
        [TestCase(new[] { 1, 2, 3 }, 0)]
        [TestCase(new[] { 3, 2, 1 }, 0)]
        [TestCase(new[] { 5 }, 0)]
        [TestCase(new int[0], 0)]
        public void ShouldGetTrappedWater(int[] heights, int output)
        {
            Assert.AreEqual(output, rainWater.Trap(heights));
        }

        [Test]
        public void ShouldReturnZeroWhenInputIsNull()
        {
            Assert.AreEqual(0, rainWater.Trap(null));
        }
    }
}
