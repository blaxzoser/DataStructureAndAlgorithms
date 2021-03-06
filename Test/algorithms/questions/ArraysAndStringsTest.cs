using NUnit.Framework;
using Samples.questions.arraysAndStrings;

namespace Test.algorithms.questions
{
    public class ArraysAndStringsTest
    {
        private readonly UniqueCharacters uniqueCharacters;

        public ArraysAndStringsTest()
        {
            uniqueCharacters = new UniqueCharacters();
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

    }
}
