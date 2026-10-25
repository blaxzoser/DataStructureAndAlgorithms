using NUnit.Framework;
using TrainingAlgorithms.algorithms.easy;

namespace TestTrainingAlgorithms.algorithms.easy
{
    public class UniqueCharactersTest
    {
        UniqueCharacters uniqueCharacters;

        [SetUp]
        public void Setup()
        {
            uniqueCharacters = new UniqueCharacters();
        }

        // ------------------------------ IsUnique ------------------------------

        [TestCase("abcde", true)]
        [TestCase("aA", true)]
        [TestCase("a!b@c#", true)]
        [TestCase("a", true)]
        [TestCase("", true)]
        [TestCase("hello", false)]
        [TestCase("a b c", false)]
        [TestCase("abcda", false)]
        [TestCase("abbc", false)]
        public void ShouldCheckUniqueCharacters(string input, bool output)
        {
            Assert.AreEqual(output, uniqueCharacters.IsUnique(input));
        }

        [Test]
        public void ShouldReturnFalseWhenInputIsNull()
        {
            Assert.IsFalse(uniqueCharacters.IsUnique(null));
        }

        // ------------------------ IsUniqueNoExtraSpace ------------------------

        [TestCase("abcde", true)]
        [TestCase("aA", true)]
        [TestCase("a!b@c#", true)]
        [TestCase("a", true)]
        [TestCase("", true)]
        [TestCase("hello", false)]
        [TestCase("a b c", false)]
        [TestCase("abcda", false)]
        [TestCase("abbc", false)]
        public void ShouldCheckUniqueCharactersNoExtraSpace(string input, bool output)
        {
            Assert.AreEqual(output, uniqueCharacters.IsUniqueNoExtraSpace(input));
        }

        [Test]
        public void ShouldReturnFalseWhenInputIsNullNoExtraSpace()
        {
            Assert.IsFalse(uniqueCharacters.IsUniqueNoExtraSpace(null));
        }
    }
}
