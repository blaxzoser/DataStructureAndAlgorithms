using NUnit.Framework;
using TrainingAlgorithms.algorithms.easy;

namespace TestTrainingAlgorithms.algorithms.easy
{
    public class ReverseVowelsTest
    {
        ReverseVowels reverseVowels;

        [SetUp]
        public void Setup()
        {
            reverseVowels = new ReverseVowels();
        }

        [TestCase("hello", "holle")]
        [TestCase("leetcode", "leotcede")]
        [TestCase("IceCreAm", "AceCreIm")]
        [TestCase("aA", "Aa")]
        [TestCase("a.b,e", "e.b,a")]
        [TestCase("bcd", "bcd")]
        [TestCase("a", "a")]
        [TestCase("", "")]
        public void ShouldReverseOnlyVowels(string input, string output)
        {
            Assert.AreEqual(output, reverseVowels.Reverse(input));
        }

        [Test]
        public void ShouldReturnNullWhenInputIsNull()
        {
            Assert.IsNull(reverseVowels.Reverse(null));
        }
    }
}
