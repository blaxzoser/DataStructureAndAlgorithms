using NUnit.Framework;
using Samples.questions.arraysAndStrings;

namespace Test.algorithms.questions
{
    public class ArraysAndStringsTest
    {
        private readonly UniqueCharacters uniqueCharacters;
        private readonly PermutationDetector permutationDetector;

        public ArraysAndStringsTest()
        {
            uniqueCharacters = new UniqueCharacters();
            permutationDetector = new PermutationDetector();
        }

        [Test]
        public void UniqueCharacters() 
        {
            Assert.IsTrue(uniqueCharacters.IsUnique("ab"));
            Assert.IsFalse(uniqueCharacters.IsUnique("aa"));
            Assert.IsTrue(uniqueCharacters.IsUnique("abcdefghijklmopqrtsuvwxyz"));
            Assert.IsFalse(uniqueCharacters.IsUnique("mama"));
        }

        [Test]
        public void UniqueCharactersRefactor()
        {
            Assert.IsTrue(uniqueCharacters.IsUniqueRefactor("ab"));
            Assert.IsFalse(uniqueCharacters.IsUniqueRefactor("aa"));
            Assert.IsTrue(uniqueCharacters.IsUniqueRefactor("abcdefghijklmopqrtsuvwxyz"));
            Assert.IsFalse(uniqueCharacters.IsUniqueRefactor("mama"));
        }

        [Test]
        public void PermutationTheOther() 
        {
            Assert.IsTrue(permutationDetector.IsPermutation("abc", "cba"));
            Assert.IsFalse(permutationDetector.IsPermutation("abc", "cbaa"));
            Assert.IsTrue(permutationDetector.IsPermutation("abc", "cab"));
            Assert.IsFalse(permutationDetector.IsPermutation("abc", "xyz"));
            Assert.IsFalse(permutationDetector.IsPermutation("abc", "aca"));
        }

        [Test]
        public void PermutationTheOtherRefactor()
        {
            Assert.IsTrue(permutationDetector.IsPermutationRefactor("abc", "cba"));
            Assert.IsFalse(permutationDetector.IsPermutationRefactor("abc", "cbaa"));
            Assert.IsTrue(permutationDetector.IsPermutationRefactor("abc", "cab"));
            Assert.IsFalse(permutationDetector.IsPermutationRefactor("abc", "xyz"));
            Assert.IsFalse(permutationDetector.IsPermutationRefactor("abc", "aca"));
        }
    }
}
