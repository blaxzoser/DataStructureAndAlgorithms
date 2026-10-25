using NUnit.Framework;
using TrainingAlgorithms.algorithms.easy;

namespace TestTrainingAlgorithms.algorithms.easy
{
    public class ValidAnagramTest
    {
        ValidAnagram validAnagram;

        [SetUp]
        public void Setup()
        {
            validAnagram = new ValidAnagram();
        }

        [TestCase("anagram", "nagaram", true)]
        [TestCase("listen", "silent", true)]
        [TestCase("a b", "b a", true)]
        [TestCase("", "", true)]
        [TestCase("rat", "car", false)]
        [TestCase("aacc", "ccac", false)]
        [TestCase("ab", "abc", false)]
        [TestCase("Ab", "ab", false)]
        public void ShouldCheckAnagram(string first, string second, bool output)
        {
            Assert.AreEqual(output, validAnagram.IsAnagram(first, second));
        }

        [TestCase(null, "a")]
        [TestCase("a", null)]
        [TestCase(null, null)]
        public void ShouldReturnFalseWhenAnyInputIsNull(string first, string second)
        {
            Assert.IsFalse(validAnagram.IsAnagram(first, second));
        }
    }
}
