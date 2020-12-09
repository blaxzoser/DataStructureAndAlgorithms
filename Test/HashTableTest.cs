using NUnit.Framework;
using Samples.datastructures;

namespace Test
{
    public class HashTableTest
    {
        private HashTable _hastTable;

        [SetUp]
        public void Setup()
        {
            _hastTable = new HashTable();
        }

        [Test]
        public void PutAndGet()
        {
            _hastTable.Put("John Smith", "521-1234");
            _hastTable.Put("Lisa Smith", "521-8976");
            _hastTable.Put("Sam Doe", "521-5030");
            _hastTable.Put("Sandra Dee", "521-9655");
            _hastTable.Put("Ted Baker", "418-4165");

            Assert.AreEqual("521-1234", _hastTable.Get("John Smith"));
            Assert.AreEqual("521-8976", _hastTable.Get("Lisa Smith"));
            Assert.AreEqual("521-5030", _hastTable.Get("Sam Doe"));
            Assert.AreEqual("521-9655", _hastTable.Get("Sandra Dee"));
            Assert.AreEqual("418-4165", _hastTable.Get("Ted Baker"));
            Assert.AreEqual(null, _hastTable.Get("Tim Lee"));

            _hastTable.ToString();
        }

        [Test]
        public void Empty()
        {
            Assert.AreEqual(null, _hastTable.Get("Ted Baker"));
            Assert.AreEqual(null, _hastTable.Get("Tim Lee"));
            _hastTable.ToString();
        }

        [Test]
        public void Collision()
        {
            // these keys will collide
            _hastTable.Put("John Smith", "521-1234");
            _hastTable.Put("Sandra Dee", "521-9655");

            Assert.AreEqual("521-1234", _hastTable.Get("John Smith"));
            Assert.AreEqual("521-9655", _hastTable.Get("Sandra Dee"));
            Assert.AreEqual(null, _hastTable.Get("Tim Lee"));
        }
    }
}
