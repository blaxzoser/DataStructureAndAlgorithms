using NUnit.Framework;
using Samples.algorithms;

namespace Test.algorithms
{
    public class BubbleSortTest
    {
        private BubbleSort _bubblesort;
        [SetUp]
        public void SetUp() 
        {
            _bubblesort = new BubbleSort();
        }

        [Test]
        public void Sort() 
        {
            int[] array = { 5, 1, 4, 2, 8 };
            int[] sorted = _bubblesort.Sort(array);

            Assert.AreEqual(1, sorted[0]);
            Assert.AreEqual(2, sorted[1]);
            Assert.AreEqual(4, sorted[2]);
            Assert.AreEqual(5, sorted[3]);
            Assert.AreEqual(8, sorted[4]);
        }

        [Test]
        public void SortRefactor()
        {
            int[] array = { 5, 1, 4, 2, 8 };
            int[] sorted = _bubblesort.SortRefactor(array);

            Assert.AreEqual(1, sorted[0]);
            Assert.AreEqual(2, sorted[1]);
            Assert.AreEqual(4, sorted[2]);
            Assert.AreEqual(5, sorted[3]);
            Assert.AreEqual(8, sorted[4]);
        }
    }
}
