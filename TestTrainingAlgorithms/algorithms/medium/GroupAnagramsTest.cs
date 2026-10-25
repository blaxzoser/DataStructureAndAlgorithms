using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TrainingAlgorithms.algorithms.medium;

namespace TestTrainingAlgorithms.algorithms.medium
{
    public class GroupAnagramsTest
    {
        GroupAnagrams groupAnagrams;

        [SetUp]
        public void Setup()
        {
            groupAnagrams = new GroupAnagrams();
        }

        // Groups can come in any order, and the words inside a group too.
        // Expected groups are written as "word,word|word" and compared after sorting.
        [TestCase(new[] { "eat", "tea", "tan", "ate", "nat", "bat" }, "ate,eat,tea|bat|nat,tan")]
        [TestCase(new[] { "abc", "bca", "cab", "xyz" }, "abc,bca,cab|xyz")]
        [TestCase(new[] { "ab", "ba", "Ab" }, "Ab|ab,ba")]
        [TestCase(new[] { "a" }, "a")]
        [TestCase(new[] { "" }, "")]
        public void ShouldGroupAnagrams(string[] words, string output)
        {
            Assert.AreEqual(output, Normalize(groupAnagrams.Group(words)));
        }

        [Test]
        public void ShouldReturnOneGroupWithEmptyWord()
        {
            var groups = groupAnagrams.Group(new[] { "" });
            Assert.AreEqual(1, groups.Count);
        }

        [Test]
        public void ShouldReturnEmptyWhenInputIsEmpty()
        {
            Assert.IsEmpty(groupAnagrams.Group(new string[0]));
        }

        [Test]
        public void ShouldReturnEmptyWhenInputIsNull()
        {
            Assert.IsEmpty(groupAnagrams.Group(null));
        }

        private static string Normalize(IList<IList<string>> groups)
        {
            var sortedGroups = groups
                .Select(g => string.Join(",", g.OrderBy(w => w, StringComparer.Ordinal)))
                .OrderBy(g => g, StringComparer.Ordinal);
            return string.Join("|", sortedGroups);
        }
    }
}
