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