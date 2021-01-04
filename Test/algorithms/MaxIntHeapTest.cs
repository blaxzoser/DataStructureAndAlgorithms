using NUnit.Framework; 
using Samples.algorithms;
using System.Diagnostics;


namespace Test.algorithms
{
    public class MaxIntHeapTest
    {
        private MaxIntHeap _maxHeap;


        [Test]
        public void ExtractMax()
        {
            _maxHeap = new MaxIntHeap();
            _maxHeap.Insert(42);
            _maxHeap.Insert(29);
            _maxHeap.Insert(18);
            //_maxHeap.Print();

            // Insert(35)
            _maxHeap.Insert(35);
            //_maxHeap.Print();



            // Test insert
            Assert.AreEqual(42, _maxHeap.Items[0]);
            Assert.AreEqual(35, _maxHeap.Items[1]);
            Assert.AreEqual(18, _maxHeap.Items[2]);
            Assert.AreEqual(29, _maxHeap.Items[3]);

            // Text extract max
            _maxHeap.Print();
            Assert.AreEqual(42, _maxHeap.ExtractMax());
            _maxHeap.Print();

            Assert.AreEqual(35, _maxHeap.ExtractMax());
            Assert.AreEqual(29, _maxHeap.ExtractMax());
            Assert.AreEqual(18, _maxHeap.ExtractMax());

            _maxHeap.Print();
        }

        [Test]
        public void ExtractMaxBigger()
        {
            _maxHeap = new MaxIntHeap();
            _maxHeap.Insert(42);
            _maxHeap.Insert(29);
            _maxHeap.Insert(18);
            _maxHeap.Insert(14);
            _maxHeap.Insert(7);
            _maxHeap.Insert(18);
            _maxHeap.Insert(12);
            _maxHeap.Insert(11);
            _maxHeap.Insert(13);
            _maxHeap.Print();

            Assert.AreEqual(42, _maxHeap.ExtractMax());
            _maxHeap.Print();


            Assert.AreEqual(29, _maxHeap.ExtractMax());
            Assert.AreEqual(18, _maxHeap.ExtractMax());
            Assert.AreEqual(18, _maxHeap.ExtractMax());
            Assert.AreEqual(14, _maxHeap.ExtractMax());
            Assert.AreEqual(13, _maxHeap.ExtractMax());
            Assert.AreEqual(12, _maxHeap.ExtractMax());
            Assert.AreEqual(11, _maxHeap.ExtractMax());
            Assert.AreEqual(7, _maxHeap.ExtractMax());
        }

        [Test]
        public void Insert35()
        {
            Debug.WriteLine("9/2 = " + 9 / 2);
            Debug.WriteLine("7/2 = " + 7 / 2);

        }

    }
}
