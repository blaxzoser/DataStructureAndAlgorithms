using NUnit.Framework;
using TrainingAlgorithms.algorithms.easy;

namespace TestTrainingAlgorithms.algorithms.easy
{
    public class ReverseOnlyLettersTest
    {
        ReverseOnlyLetters reverseOnlyLetters;

        [SetUp]
        public void Setup()
        {
            reverseOnlyLetters = new ReverseOnlyLetters();
        }

        [TestCase("ab-cd", "dc-ba")]
        [TestCase("a-bC-dEf-ghIj", "j-Ih-gfE-dCba")]
        [TestCase("Test1ng-Leet=code-Q!", "Qedo1ct-eeLg=ntse-T!")]
        [TestCase("abc", "cba")]
        [TestCase("a", "a")]
        [TestCase("123", "123")]
        [TestCase("-a-", "-a-")]
        [TestCase("!!ab", "!!ba")]
        [TestCase("", "")]
        public void ShouldReverseOnlyLetters(string input, string output)
        {
            Assert.AreEqual(output, reverseOnlyLetters.Reverse(input));
        }

        [Test]
        public void ShouldReturnNullWhenInputIsNull()
        {
            Assert.IsNull(reverseOnlyLetters.Reverse(null));
        }
    }
}
