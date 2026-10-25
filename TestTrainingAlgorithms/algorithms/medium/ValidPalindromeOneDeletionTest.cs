using NUnit.Framework;
using TrainingAlgorithms.algorithms.medium;

namespace TestTrainingAlgorithms.algorithms.medium
{
    public class ValidPalindromeOneDeletionTest
    {
        ValidPalindromeOneDeletion validPalindrome;

        [SetUp]
        public void Setup()
        {
            validPalindrome = new ValidPalindromeOneDeletion();
        }

        [TestCase("aba", true)]
        [TestCase("abca", true)]
        [TestCase("cbbcc", true)]
        [TestCase("deeee", true)]
        [TestCase("eeeed", true)]
        [TestCase("ab", true)]
        [TestCase("a", true)]
        [TestCase("", true)]
        [TestCase("abc", false)]
        [TestCase("abcda", false)]
        public void ShouldCheckPalindromeWithOneDeletion(string input, bool output)
        {
            Assert.AreEqual(output, validPalindrome.CanBePalindrome(input));
        }

        [Test]
        public void ShouldReturnFalseWhenInputIsNull()
        {
            Assert.IsFalse(validPalindrome.CanBePalindrome(null));
        }
    }
}
