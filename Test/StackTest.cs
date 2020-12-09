using NUnit.Framework;
using Samples.datastructures;

namespace Test
{
    public class StackTest
    {
        private Stack _stack;

        [SetUp]
        public void Setup()
        {
            _stack = new Stack();
        }

        [Test]
        public void Push()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);

            Assert.AreEqual(3, _stack.Size);
        }

        [Test]
        public void Pop()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);

            Assert.AreEqual(3, _stack.Pop());
            Assert.AreEqual(2, _stack.Size);
        }

        [Test]
        public void Peek()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);

            Assert.AreEqual(3, _stack.Peek());
            Assert.AreEqual(3, _stack.Size);

            Assert.AreEqual(3, _stack.Pop());
            Assert.AreEqual(2, _stack.Peek());
        }
    }
}
