using NUnit.Framework;
using TrainingAlgorithms.algorithms.hard;

namespace TestTrainingAlgorithms.algorithms.hard
{
    public class ValidPalindromeSkipAndDeleteTest
    {
        ValidPalindromeSkipAndDelete validPalindrome;

        [SetUp]
        public void Setup()
        {
            validPalindrome = new ValidPalindromeSkipAndDelete();
        }

        [TestCase("A man, a plan, a canal: Panama", true)]
        [TestCase("race a car", true)]
        [TestCase("Ab, c a", true)]
        [TestCase("No lemon, no melons", true)]
        [TestCase(".,", true)]
        [TestCase("", true)]
        [TestCase("Tact, Coa", false)]
        [TestCase("a.b.c", false)]
        [TestCase("A, b, C, d", false)]
        public void ShouldCheckValidPalindromeWithOneDeletion(string input, bool output)
        {
            Assert.AreEqual(output, validPalindrome.CanBeValidPalindrome(input));
        }

        [Test]
        public void ShouldReturnFalseWhenInputIsNull()
        {
            Assert.IsFalse(validPalindrome.CanBeValidPalindrome(null));
        }
    }
}
