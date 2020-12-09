using NUnit.Framework;
using Samples.datastructures;

namespace Test
{
    public class QueueTest
    {
        private Queue _queue;

        [SetUp]
        public void Setup()
        {
            _queue = new Queue();
        }


        [Test]
        public void Add()
        {
            _queue.Add(1);
            _queue.Add(2);
            
            Assert.AreEqual(1, _queue.Peek());
        }


        [Test]
        public void Remove()
        {
            _queue.Add(1);
            _queue.Add(2);
            _queue.Add(3);

            Assert.AreEqual(1, _queue.Remove());
            Assert.AreEqual(2, _queue.Peek());
        }
    }
}
