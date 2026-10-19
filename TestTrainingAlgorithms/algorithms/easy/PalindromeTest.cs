using NUnit.Framework;
using TrainingAlgorithms.algorithms.easy;

namespace TestTrainingAlgorithms.algorithms.easy
{
    public class PalindromeTest
    {
        Palindrome palindrome;

        [SetUp]
        public void Setup()
        {
            palindrome = new Palindrome();
        }

        // ---------------------------- IsPalindrome ----------------------------

        [TestCase("racecar", true)]
        [TestCase("anitalavalatina", true)]
        [TestCase("abba", true)]
        [TestCase("a", true)]
        [TestCase("", true)]
        [TestCase("hello", false)]
        [TestCase("ab", false)]
        [TestCase("Racecar", false)]
        public void ShouldCheckSimplePalindrome(string input, bool output)
        {
            Assert.AreEqual(output, palindrome.IsPalindrome(input));
        }

        [Test]
        public void ShouldReturnFalseWhenInputIsNull()
        {
            Assert.IsFalse(palindrome.IsPalindrome(null));
        }

        // -------------------------- IsValidPalindrome -------------------------

        [TestCase("A man, a plan, a canal: Panama", true)]
        [TestCase("Racecar", true)]
        [TestCase(" ", true)]
        [TestCase(".,", true)]
        [TestCase("No 'x' in Nixon", true)]
        [TestCase("race a car", false)]
        [TestCase("0P", false)]
        public void ShouldCheckValidPalindromeIgnoringCaseAndSymbols(string input, bool output)
        {
            Assert.AreEqual(output, palindrome.IsValidPalindrome(input));
        }

        // -------------------------- Sample1Refactor ---------------------------

        [TestCase("racecar", true)]
        [TestCase("anitalavalatina", true)]
        [TestCase("abba", true)]
        [TestCase("a", true)]
        [TestCase("", true)]
        [TestCase("hello", false)]
        [TestCase("ab", false)]
        [TestCase("Racecar", false)]
        public void ShouldCheckSimplePalindromeRefactor(string input, bool output)
        {
            Assert.AreEqual(output, palindrome.Sample1Refactor(input));
        }

        [Test]
        public void ShouldReturnFalseWhenInputIsNullRefactor()
        {
            Assert.IsFalse(palindrome.Sample1Refactor(null));
        }

        // -------------------------- Sample2Refactor ---------------------------

        [TestCase("A man, a plan, a canal: Panama", true)]
        [TestCase("Racecar", true)]
        [TestCase(" ", true)]
        [TestCase(".,", true)]
        [TestCase("No 'x' in Nixon", true)]
        [TestCase("race a car", false)]
        [TestCase("0P", false)]
        public void ShouldCheckValidPalindromeIgnoringCaseAndSymbolsRefactor(string input, bool output)
        {
            Assert.AreEqual(output, palindrome.Sample2Refactor(input));
        }

        [Test]
        public void ShouldReturnFalseWhenValidPalindromeInputIsNullRefactor()
        {
            Assert.IsFalse(palindrome.Sample2Refactor(null));
        }

        // ------------------------- IsPalindromeNumber -------------------------

        [TestCase(121, true)]
        [TestCase(1221, true)]
        [TestCase(12321, true)]
        [TestCase(0, true)]
        [TestCase(7, true)]
        [TestCase(-121, false)]
        [TestCase(10, false)]
        [TestCase(123, false)]
        public void ShouldCheckPalindromeNumber(int input, bool output)
        {
            Assert.AreEqual(output, palindrome.IsPalindromeNumber(input));
        }
    }
}
