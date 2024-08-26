using NUnit.Framework;
using Samples.questions.arraysAndStrings;
using Samples.questions.interviews;
using Samples.questions.lambdas;
using Samples.questions.recursive;

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

        [Test]
        public void TestStringMerge()
        {
            Assert.IsFalse(StringMerger.IsMergeOldFashon("codewars", "code", "wasr"), "codewars can be created from code and wars");
            Assert.IsTrue(StringMerger.IsMergeOldFashon("codewars", "cdwr", "oeas"), "codewars can be created from cdwr and oeas");
            Assert.IsFalse(StringMerger.IsMergeOldFashon("codewars", "cod", "wars"), "Codewars are not codwars");
        }


        [Test]
        public void TestStringMergeWithRecursive()
        {
            Assert.IsFalse(StringMerger.IsMerge("codewars", "code", "wasr"), "codewars can be created from code and wars");
            Assert.IsTrue(StringMerger.IsMerge("codewars", "cdwr", "oeas"), "codewars can be created from cdwr and oeas");
            Assert.IsFalse(StringMerger.IsMerge("codewars", "cod", "wars"), "Codewars are not codwars");
        }

        [Test]
        public void TestRecursivePrint()
        {
            Assert.AreEqual(string.Empty, StringMerger.ForRecursive("abcd"));
        }

        [Test]
        public void TestBalance()
        {
            Assert.IsTrue(Balance.IsBalance("{}"));
            Assert.IsTrue(Balance.IsBalance("{()}"));
            Assert.IsTrue(Balance.IsBalance("{()()()}"));

            Assert.IsFalse(Balance.IsBalance("{"));
            Assert.IsFalse(Balance.IsBalance("{]"));
            Assert.IsFalse(Balance.IsBalance("{{]}"));
            Assert.IsFalse(Balance.IsBalance("{((({})}"));
        }

        [Test]
        public void TestCompress()
        {
            Assert.AreEqual("a3b2c1",Compressor.Compress("aaabbc"));
        }

        [Test]
        public void Tests1()
        {
            Assert.AreEqual(5, Kata.FindInt(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));
        }


        [Test]
        public void Tests3()
        {
            Assert.AreEqual(2, Kata.FindInt(new[] { 1, 1, 2 }));
        }

        [Test]
        public void Tests1InterviewStringDuplicates()
        {
            Assert.AreEqual("Luis Pntado", StringDuplicates.RemoveDuplicates("Luis Pintado"));
        }

        [Test]
        public void TestPalindromes()
        {
            Assert.IsTrue(Palindrome.IsPalindromeDetector("abba"));
            Assert.IsTrue(Palindrome.IsPalindromeDetector("mom"));
            Assert.IsTrue(Palindrome.IsPalindromeDetector("dad"));

            Assert.IsFalse(Palindrome.IsPalindromeDetector("rush"));
            Assert.IsFalse(Palindrome.IsPalindromeDetector("yes"));
        }

        [Test]
        public void TestPalindromePerformance()
        {
            Assert.IsTrue(Palindrome.IsPalindromeRefactor("abba"));
            Assert.IsTrue(Palindrome.IsPalindromeRefactor("mom"));
            Assert.IsTrue(Palindrome.IsPalindromeRefactor("dad"));

            Assert.IsFalse(Palindrome.IsPalindromeRefactor("rush"));
            Assert.IsFalse(Palindrome.IsPalindromeRefactor("yes"));
        }

        [Test]
        public void TestPalindromePerformanceWithLambdas()
        {
            Assert.IsTrue(Palindrome.IsPalindromeLambda("abba"));
            Assert.IsTrue(Palindrome.IsPalindromeLambda("mom"));
            Assert.IsTrue(Palindrome.IsPalindromeLambda("dad"));

            Assert.IsFalse(Palindrome.IsPalindromeLambda("rush"));
            Assert.IsFalse(Palindrome.IsPalindromeLambda("yes"));
        }
    }
}
