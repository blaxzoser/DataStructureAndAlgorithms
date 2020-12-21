using NUnit.Framework;
using Samples.algorithms;

namespace Test.algorithms
{
    public class RecursionTest
    {
        private Recursion _recursion;

        [SetUp]
        public void SetUp()
        {
            _recursion = new Recursion();
        }

        [Test]
        public void StrinpLeadingZeros() 
        {
            Assert.AreEqual("1", _recursion.StringZeros("0001"));
            Assert.AreEqual("11", _recursion.StringZeros("0011"));
            Assert.AreEqual("1989", _recursion.StringZeros("00001989"));
            Assert.AreEqual("VOD", _recursion.StringZeros("VOD"));

        }

        [Test]
        public void StringZerosRefactor()
        {
            Assert.AreEqual("1", _recursion.StringZerosRefactor("0001"));
            Assert.AreEqual("11", _recursion.StringZerosRefactor("0011"));
            Assert.AreEqual("1989", _recursion.StringZerosRefactor("00001989"));
            Assert.AreEqual("VOD", _recursion.StringZerosRefactor("VOD"));

        }
    }
}
