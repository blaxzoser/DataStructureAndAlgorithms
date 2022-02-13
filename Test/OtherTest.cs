using NUnit.Framework;
using Samples.questions.arraysAndStrings;
using Samples.questions.lambdas;

namespace Test
{

    public class OtherTest
    {

        [Test]
        public void TestParangram()
        {
            Assert.AreEqual(true, Parangram.IsPangram("The quick brown fox jumps over the lazy dog."));
        }

        [Test]
        public void TestParangramWithLambdas()
        {
            Assert.AreEqual(true, Parangram.IsParangramLambdas("The quick brown fox jumps over the lazy dog."));
        }

        [Test]
        public void TestArrayDiff()
        {
            Assert.AreEqual(new int[] { 2 }, Kata.ArrayDiff(new int[] { 1, 2 }, new int[] { 1 }));
            Assert.AreEqual(new int[] { 2 }, Kata.ArrayDiff(new int[] { 1, 2 }, new int[] { 1 }));
            Assert.AreEqual(new int[] { 2, 2 }, Kata.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { 1 }));         
            Assert.AreEqual(new int[] { 1 }, Kata.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { 2 }));
            Assert.AreEqual(new int[] { 1, 2, 2 }, Kata.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { }));
            Assert.AreEqual(new int[] { }, Kata.ArrayDiff(new int[] { }, new int[] { 1, 2 }));          
        }

        [Test]
        public void TestArrayDiffLambdas()
        {
            Assert.AreEqual(new int[] { 2 }, Kata.ArrayDiffLambdasFail(new int[] { 1, 2 }, new int[] { 1 }));
            //Assert.AreEqual(new int[] { 2, 2 }, Kata.ArrayDiffLambdasFail(new int[] { 1, 2, 2 }, new int[] { 1 }));
            Assert.AreEqual(new int[] { 1 }, Kata.ArrayDiffLambdasFail(new int[] { 1, 2, 2 }, new int[] { 2 }));
            Assert.AreEqual(new int[] { 1, 2, 2 }, Kata.ArrayDiffLambdasFail(new int[] { 1, 2, 2 }, new int[] { }));
            Assert.AreEqual(new int[] { }, Kata.ArrayDiffLambdasFail(new int[] { }, new int[] { 1, 2 }));
            Assert.AreEqual(new int[] { 3 }, Kata.ArrayDiffLambdasFail(new int[] { 1, 2, 3 }, new int[] { 1, 2 }));
        }

        [Test]
        public void TestArrayDiffGoodLambdas()
        {
            Assert.AreEqual(new int[] { 2 }, Kata.ArrayDiffLambdasGood(new int[] { 1, 2 }, new int[] { 1 }));
            Assert.AreEqual(new int[] { 2, 2 }, Kata.ArrayDiffLambdasGood(new int[] { 1, 2, 2 }, new int[] { 1 }));
            Assert.AreEqual(new int[] { 1 }, Kata.ArrayDiffLambdasGood(new int[] { 1, 2, 2 }, new int[] { 2 }));
            Assert.AreEqual(new int[] { 1, 2, 2 }, Kata.ArrayDiffLambdasGood(new int[] { 1, 2, 2 }, new int[] { }));
            Assert.AreEqual(new int[] { }, Kata.ArrayDiffLambdasGood(new int[] { }, new int[] { 1, 2 }));
            Assert.AreEqual(new int[] { 3 }, Kata.ArrayDiffLambdasGood(new int[] { 1, 2, 3 }, new int[] { 1, 2 }));
        }

    }
}
