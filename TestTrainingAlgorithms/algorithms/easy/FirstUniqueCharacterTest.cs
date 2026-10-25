using NUnit.Framework;
using TrainingAlgorithms.algorithms.easy;

namespace TestTrainingAlgorithms.algorithms.easy
{
    public class FirstUniqueCharacterTest
    {
        FirstUniqueCharacter firstUnique;

        [SetUp]
        public void Setup()
        {
            firstUnique = new FirstUniqueCharacter();
        }

        [TestCase("leetcode", 0)]
        [TestCase("loveleetcode", 2)]
        [TestCase("aabb", -1)]
        [TestCase("aAbB", 0)]
        [TestCase("aabbc", 4)]
        [TestCase("z", 0)]
        [TestCase("", -1)]
        public void ShouldFindFirstUniqueCharacterIndex(string input, int output)
        {
            Assert.AreEqual(output, firstUnique.FindIndex(input));
        }

        [Test]
        public void ShouldReturnMinusOneWhenInputIsNull()
        {
            Assert.AreEqual(-1, firstUnique.FindIndex(null));
        }
    }
}
