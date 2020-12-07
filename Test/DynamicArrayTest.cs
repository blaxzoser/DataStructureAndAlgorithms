using NUnit.Framework;
using Samples.datastructures;

namespace Test
{
 
    public class DynamicArrayTest
    {
        private DynamicArray array;

        [SetUp]
        public void Setup()
        {
            array = new DynamicArray(2);
        }

        [Test]
        public void Insert()
        {
            array.Add("a");
            array.Add("b");
            array.Add("c");

            array.Insert(1, "d");
            Assert.AreEqual(4, array.Size);
            Assert.AreEqual("a", array.Get(0)); 
            Assert.AreEqual("d", array.Get(1));
            Assert.AreEqual("b", array.Get(2));
            Assert.AreEqual("c", array.Get(3));
        }
        
        [Test]
        public void DeleteFirst() 
        {
            array.Add("a");
            array.Add("b");
            array.Add("c");

            array.Delete(0);

            Assert.AreEqual(2, array.Size);
            Assert.AreEqual("b", array.Get(0));
            Assert.AreEqual("c", array.Get(1));
            Assert.AreEqual(null, array.Get(2));
        }

        [Test]
        public void DeleteMiddle() 
        {
            array.Add("a");
            array.Add("b");
            array.Add("c");

            array.Delete(1);

            Assert.AreEqual(2, array.Size);
            Assert.AreEqual("a", array.Get(0));
            Assert.AreEqual("c", array.Get(1));
            Assert.AreEqual(null, array.Get(2));
        }

        [Test]
        public void DeleteLast()
        {
            array.Add("a");
            array.Add("b");
            array.Add("c");

            array.Delete(2);

            Assert.AreEqual(2, array.Size);
            Assert.AreEqual("a", array.Get(0));
            Assert.AreEqual("b", array.Get(1));
            Assert.AreEqual(null, array.Get(2));
        }

        [Test]
        public void IsEmpty()
        {
            Assert.IsTrue(array.IsEmpty);
            array.Add("a");
            Assert.IsFalse(array.IsEmpty);
        }

        [Test]
        public void Contains() 
        {
            Assert.IsFalse(array.Contains("a"));           
            
            array.Add("a");            
            Assert.IsTrue(array.Contains("a"));
            
            array.Add("b");
            array.Add("b");
            array.Add("c");
            Assert.IsTrue(array.Contains("b"));
            Assert.IsTrue(array.Contains("c"));
           
            array.Delete(3);            
            Assert.IsFalse(array.Contains("c"));

            array.Delete(2);
            Assert.IsTrue(array.Contains("b"));

            array.Delete(1);
            Assert.IsFalse(array.Contains("b"));

            array.Delete(0);
            Assert.IsFalse(array.Contains("a"));




        }


        [Test]
        public void Delete() 
        {
            array.Add("a");
            array.Add("b"); 
            array.Add("c");

            array.Delete(1);

            Assert.AreEqual(2, array.Size);
            Assert.AreEqual("a", array.Get(0));
            Assert.AreEqual("c", array.Get(1));
        }
      
    }
}