using NUnit.Framework;
using TrainingAlgorithms.algorithms.medium;

namespace TestTrainingAlgorithms.algorithms.medium
{
    public class LongestUniqueWordsTest
    {
        LongestUniqueWords longestUniqueWords;

        [SetUp]
        public void Setup()
        {
            longestUniqueWords = new LongestUniqueWords();
        }

        [TestCase("the cat the dog", 3)]
        [TestCase("go go go", 1)]
        [TestCase("a b c a b c b b", 3)]
        [TestCase("one two two three four", 3)]
        [TestCase("red blue blue red", 2)]
        [TestCase("I like it", 3)]
        [TestCase("The the", 2)]
        [TestCase("hello", 1)]
        [TestCase("", 0)]
        public void ShouldGetLengthOfLongestUniqueWordRun(string sentence, int output)
        {
            Assert.AreEqual(output, longestUniqueWords.LengthOfLongest(sentence));
        }

        [Test]
        public void ShouldReturnZeroWhenSentenceIsNull()
        {
            Assert.AreEqual(0, longestUniqueWords.LengthOfLongest(null));
        }
    }
}
