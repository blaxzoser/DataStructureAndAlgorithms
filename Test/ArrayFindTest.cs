using NUnit.Framework;
using Samples.questions.lambdas;

namespace Test
{

    public class ArrayFindTest
    {
        ArrayFind arrayFind;

        [SetUp]
        public void Setup()
        {
            arrayFind = new ArrayFind();
        }

        [Test]
        public void TestFindSmallestIntApproachSimple()
        {
            int[] array = { 5, 3, 2, 4, 1 };
            int result = arrayFind.FindSmallestIntApproachSimple(array);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestFindSmallestIntApproachLinq()
        {
            int[] array = { 5, 3, 2, 4, 1 };
            int result = arrayFind.FindSmallestIntApproachLinq(array);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestFindSmallestIntApproachLoop()
        {
            int[] array = { 5, 3, 2, 4, 1 };
            int result = arrayFind.FindSmallestIntApproachLoop(array);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestFindLargestIntApproachLoop()
        {
            int[] array = { 5, 3, 2, 4, 1 };
            int result = arrayFind.FindLargestIntApproachLoop(array);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void TestFindSecondLarge()
        {
            int[] array = { 5, 3, 2, 4, 1 };
            int result = arrayFind.FindSecondLargestNumberWithLoop(array);
            Assert.AreEqual(4, result);
        }
    }
}
