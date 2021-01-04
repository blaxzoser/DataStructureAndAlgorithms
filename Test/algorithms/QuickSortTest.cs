using NUnit.Framework;
using Samples.algorithms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.algorithms
{
    public class QuickSortTest
    {
        private QuickSort _quickSort;

        [SetUp]
        public void SetUp() 
        {
            _quickSort = new QuickSort();
        }

        [Test]
        public void Sort()
        {
            int[] array = { 15, 3, 2, 1, 9, 5, 7, 8, 6 };

            int[] sorted = _quickSort.Sort(array);

            Assert.AreEqual(1, sorted[0]);
            Assert.AreEqual(2, sorted[1]);
            Assert.AreEqual(3, sorted[2]);
            Assert.AreEqual(5, sorted[3]);
            Assert.AreEqual(6, sorted[4]);
            Assert.AreEqual(7, sorted[5]);
            Assert.AreEqual(8, sorted[6]);
            Assert.AreEqual(9, sorted[7]);
            Assert.AreEqual(15, sorted[8]);

            _quickSort.PrettyPrint(sorted);
        }

    }
}
