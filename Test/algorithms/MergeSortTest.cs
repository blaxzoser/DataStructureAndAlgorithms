using NUnit.Framework;
using Samples.algorithms;


namespace Test.algorithms
{
    public class MergeSortTest
    {

        private MergeSort _mergeSort;

        [SetUp]
        public void SetUp() 
        {
            _mergeSort = new MergeSort();
        }

        [Test]
        public void Sort()
        {

            //           l                  r
            int[] arr = { 4, 7, 14, 1, 3, 9, 17 };

            int l = 0;              // left pointer
            int r = arr.Length - 1; // right pointer

            _mergeSort.Sort(arr, l, r);

            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(3, arr[1]);
            Assert.AreEqual(4, arr[2]);
            Assert.AreEqual(7, arr[3]);
            Assert.AreEqual(9, arr[4]);
            Assert.AreEqual(14, arr[5]);
            Assert.AreEqual(17, arr[6]);

           
            _mergeSort.PrintArray(arr);
        }


    }
}
