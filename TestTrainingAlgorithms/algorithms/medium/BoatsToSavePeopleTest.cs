using NUnit.Framework;
using TrainingAlgorithms.algorithms.medium;

namespace TestTrainingAlgorithms.algorithms.medium
{
    public class BoatsToSavePeopleTest
    {
        BoatsToSavePeople boatsToSavePeople;

        [SetUp]
        public void Setup()
        {
            boatsToSavePeople = new BoatsToSavePeople();
        }

        [TestCase(new[] { 1, 2 }, 3, 1)]
        [TestCase(new[] { 3, 2, 2, 1 }, 3, 3)]
        [TestCase(new[] { 3, 5, 3, 4 }, 5, 4)]
        [TestCase(new[] { 5, 1, 4, 2 }, 6, 2)]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, 3)]
        [TestCase(new[] { 2, 2 }, 6, 1)]
        [TestCase(new[] { 3, 3, 3 }, 3, 3)]
        [TestCase(new[] { 1 }, 3, 1)]
        [TestCase(new int[0], 3, 0)]
        public void ShouldReturnMinimumBoats(int[] weights, int limit, int output)
        {
            Assert.AreEqual(output, boatsToSavePeople.MinBoats(weights, limit));
        }

        [Test]
        public void ShouldReturnZeroWhenWeightsIsNull()
        {
            Assert.AreEqual(0, boatsToSavePeople.MinBoats(null, 3));
        }
    }
}
