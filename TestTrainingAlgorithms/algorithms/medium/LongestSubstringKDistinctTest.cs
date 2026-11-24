using NUnit.Framework;
using TrainingAlgorithms.algorithms.medium;

namespace TestTrainingAlgorithms.algorithms.medium
{
    public class LongestSubstringKDistinctTest
    {
        LongestSubstringKDistinct longestSubstringKDistinct;

        [SetUp]
        public void Setup()
        {
            longestSubstringKDistinct = new LongestSubstringKDistinct();
        }

        [TestCase("eceba", 2, 3)]
        [TestCase("aa", 1, 2)]
        [TestCase("abaccc", 2, 4)]
        [TestCase("aabbcc", 1, 2)]
        [TestCase("aabbcc", 2, 4)]
        [TestCase("aabacbebebe", 3, 7)]
        [TestCase("abc", 5, 3)]
        [TestCase("abc", 0, 0)]
        [TestCase("aA", 1, 1)]
        [TestCase("", 2, 0)]
        public void ShouldGetLengthOfLongestSubstringWithKDistinct(string text, int k, int output)
        {
            Assert.AreEqual(output, longestSubstringKDistinct.LengthOfLongest(text, k));
        }

        [Test]
        public void ShouldReturnZeroWhenTextIsNull()
        {
            Assert.AreEqual(0, longestSubstringKDistinct.LengthOfLongest(null, 2));
        }
    }
}
