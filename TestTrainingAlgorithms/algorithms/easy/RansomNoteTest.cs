using NUnit.Framework;
using TrainingAlgorithms.algorithms.easy;

namespace TestTrainingAlgorithms.algorithms.easy
{
    public class RansomNoteTest
    {
        RansomNote ransomNote;

        [SetUp]
        public void Setup()
        {
            ransomNote = new RansomNote();
        }

        [TestCase("aa", "aab", true)]
        [TestCase("abc", "cbaxyz", true)]
        [TestCase("", "anything", true)]
        [TestCase("", "", true)]
        [TestCase("a", "b", false)]
        [TestCase("aa", "ab", false)]
        [TestCase("Aa", "aa", false)]
        [TestCase("a", "", false)]
        public void ShouldCheckIfNoteCanBeConstructed(string note, string magazine, bool output)
        {
            Assert.AreEqual(output, ransomNote.CanConstruct(note, magazine));
        }

        [TestCase(null, "a")]
        [TestCase("a", null)]
        public void ShouldReturnFalseWhenAnyInputIsNull(string note, string magazine)
        {
            Assert.IsFalse(ransomNote.CanConstruct(note, magazine));
        }
    }
}
