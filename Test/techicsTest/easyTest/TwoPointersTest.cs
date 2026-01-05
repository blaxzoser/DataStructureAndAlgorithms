using NUnit.Framework;
using Samples.technics.basic;

namespace Test.techicsTest.easyTest
{
    public class TwoPointersTest
    {
        TwoPointers twoPointers;
        [SetUp]
        public void Setup()
        {
            twoPointers = new TwoPointers();
        }

        [Test]
        public void ShouldSimpleTestWithPalindrome()
        {
            string input = "anitalavalatina";
            bool output = true;

            Assert.AreEqual(twoPointers.IsPalindrome(input), output);
        }

        [Test]
        public void ShouldSimpleTestWithNonPalindrome()
        {
            string input = "hello";
            bool output = false;

            Assert.AreEqual(twoPointers.IsPalindrome(input), output);
        }


        [Test]
        public void ShouldSimpleTestWithSumPairEqualToTarget()
        {
            int[] input = new int[] { 10, 20, 35, 50 };
            int target = 70;
            bool output = true;

            Assert.AreEqual(twoPointers.IsSumPairEqualToTarget(input, target), output);
        }

        [Test]
        public void ShouldSimpleTestWithNoSumPairEqualToTarget()
        {
            int[] input = new int[] { 10, 20, 30 };
            int target = 70;
            bool output = false;
            Assert.AreEqual(twoPointers.IsSumPairEqualToTarget(input, target), output);
        }
    }
}
