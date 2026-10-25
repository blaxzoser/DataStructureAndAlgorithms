using NUnit.Framework;
using TrainingAlgorithms.algorithms.medium;

namespace TestTrainingAlgorithms.algorithms.medium
{
    public class ContainerWithMostWaterTest
    {
        ContainerWithMostWater container;

        [SetUp]
        public void Setup()
        {
            container = new ContainerWithMostWater();
        }

        [TestCase(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        [TestCase(new[] { 1, 1 }, 1)]
        [TestCase(new[] { 4, 3, 2, 1, 4 }, 16)]
        [TestCase(new[] { 1, 2, 1 }, 2)]
        [TestCase(new[] { 1, 2, 4, 3 }, 4)]
        [TestCase(new[] { 5 }, 0)]
        [TestCase(new int[0], 0)]
        public void ShouldGetMaxArea(int[] heights, int output)
        {
            Assert.AreEqual(output, container.MaxArea(heights));
        }

        [Test]
        public void ShouldReturnZeroWhenInputIsNull()
        {
            Assert.AreEqual(0, container.MaxArea(null));
        }
    }
}
