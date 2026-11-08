using NUnit.Framework;
using TrainingAlgorithms.algorithms.easy;

namespace TestTrainingAlgorithms.algorithms.easy
{
    public class AssignCookiesTest
    {
        AssignCookies assignCookies;

        [SetUp]
        public void Setup()
        {
            assignCookies = new AssignCookies();
        }

        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 1 }, 1)]
        [TestCase(new[] { 1, 2 }, new[] { 1, 2, 3 }, 2)]
        [TestCase(new[] { 10, 9, 8, 7 }, new[] { 5, 6, 7, 8 }, 2)]
        [TestCase(new[] { 3, 1, 2 }, new[] { 2, 1, 3 }, 3)]
        [TestCase(new[] { 1, 1, 1 }, new[] { 5 }, 1)]
        [TestCase(new[] { 1, 2, 3 }, new[] { 3 }, 1)]
        [TestCase(new[] { 2 }, new[] { 1 }, 0)]
        [TestCase(new int[0], new[] { 1, 2 }, 0)]
        [TestCase(new[] { 1, 2 }, new int[0], 0)]
        public void ShouldReturnMaxHappyChildren(int[] greed, int[] cookies, int output)
        {
            Assert.AreEqual(output, assignCookies.MaxContentChildren(greed, cookies));
        }

        [TestCase(null, new[] { 1 })]
        [TestCase(new[] { 1 }, null)]
        public void ShouldReturnZeroWhenAnyInputIsNull(int[] greed, int[] cookies)
        {
            Assert.AreEqual(0, assignCookies.MaxContentChildren(greed, cookies));
        }
    }
}
