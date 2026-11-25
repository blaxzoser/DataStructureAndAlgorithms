using NUnit.Framework;
using TrainingAlgorithms.algorithms.medium;

namespace TestTrainingAlgorithms.algorithms.medium
{
    public class LongestUniqueSubstringTest
    {
        LongestUniqueSubstring longestUniqueSubstring;

        [SetUp]
        public void Setup()
        {
            longestUniqueSubstring = new LongestUniqueSubstring();
        }

        [TestCase("abcabcbb", "abc")]
        [TestCase("bbbbb", "b")]
        [TestCase("pwwkew", "wke")]
        [TestCase("abba", "ab")]
        [TestCase("dvdf", "vdf")]
        [TestCase("aab", "ab")]
        [TestCase("abcdef", "abcdef")]
        [TestCase(" ", " ")]
        [TestCase("", "")]
        public void ShouldFindLongestUniqueSubstring(string text, string output)
        {
            Assert.AreEqual(output, longestUniqueSubstring.Find(text));
        }

        [Test]
        public void ShouldReturnEmptyWhenTextIsNull()
        {
            Assert.AreEqual("", longestUniqueSubstring.Find(null));
        }
    }
}
