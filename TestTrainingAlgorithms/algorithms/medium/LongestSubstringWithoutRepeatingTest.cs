using NUnit.Framework;
using TrainingAlgorithms.algorithms.medium;

namespace TestTrainingAlgorithms.algorithms.medium
{
    public class LongestSubstringWithoutRepeatingTest
    {
        LongestSubstringWithoutRepeating longestSubstring;

        [SetUp]
        public void Setup()
        {
            longestSubstring = new LongestSubstringWithoutRepeating();
        }

        [TestCase("abcabcbb", 3)]
        [TestCase("bbbbb", 1)]
        [TestCase("pwwkew", 3)]
        [TestCase("abba", 2)]
        [TestCase("dvdf", 3)]
        [TestCase("au", 2)]
        [TestCase(" ", 1)]
        [TestCase("abcdef", 6)]
        [TestCase("", 0)]
        public void ShouldGetLengthOfLongestSubstring(string input, int output)
        {
            Assert.AreEqual(output, longestSubstring.LengthOfLongest(input));
        }

        [Test]
        public void ShouldReturnZeroWhenInputIsNull()
        {
            Assert.AreEqual(0, longestSubstring.LengthOfLongest(null));
        }
    }
}
