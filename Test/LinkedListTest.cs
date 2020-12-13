using NUnit.Framework;
using Samples.datastructures;
using System; 
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class LinkedListTest
    {
        private LinkedList _linkedList;

        [SetUp]
        public void Setup()
        {
            _linkedList = new LinkedList();
        }

        [Test]
        public void AddFront()
        {
            _linkedList.AddFront(1);
            _linkedList.AddFront(2);
            _linkedList.AddFront(3);

            Assert.AreEqual(3, _linkedList.GetFirst());
            Assert.AreEqual(1, _linkedList.GetLast());
        }

        [Test]
        public void GetFirst()
        {
            _linkedList.AddFront(1);
            Assert.AreEqual(1, _linkedList.GetFirst());
        }

        [Test]
        public void GetLast()
        {
            _linkedList.AddFront(1);
            _linkedList.AddFront(2);
            _linkedList.AddFront(3);

            Assert.AreEqual(1, _linkedList.GetLast());
        }

        [Test]
        public void AddBack()
        {
            _linkedList.AddBack(1);
            _linkedList.AddBack(2);
            _linkedList.AddBack(3);

            Assert.AreEqual(1, _linkedList.GetFirst());
            Assert.AreEqual(3, _linkedList.GetLast());
        }


        [Test]
        public void Size()
        {
            Assert.AreEqual(0, _linkedList.Size());
            
            _linkedList.AddBack(1);
            Assert.AreEqual(1, _linkedList.Size());
            
            _linkedList.AddBack(2);
            Assert.AreEqual(2, _linkedList.Size());

            _linkedList.AddBack(3);
            Assert.AreEqual(3, _linkedList.Size());
        }

        [Test]
        public void Clear()
        {
            _linkedList.AddBack(1);
            _linkedList.AddBack(2);
            _linkedList.AddBack(3);

            _linkedList.Clear();
            Assert.AreEqual(0, _linkedList.Size());
        }

        [Test]
        public void DeleteValue()
        {
            _linkedList.AddBack(1);
            _linkedList.AddBack(2);
            _linkedList.AddBack(3);

            _linkedList.DeleteValue(2);
            Assert.AreEqual(2, _linkedList.Size());
            Assert.AreEqual(1, _linkedList.GetFirst());
            Assert.AreEqual(3, _linkedList.GetLast());

        }


    }
}
