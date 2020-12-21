using NUnit.Framework;
using Samples.algorithms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.algorithms
{
    public class FibonacciTest
    {
        private FibonacciNaive _naive;
        private FibonacciMemoized _memo;

        [SetUp]
        public void SetUp()
        {
            _naive = new FibonacciNaive();
            _memo = new FibonacciMemoized();
        }

        [Test]
        public void Naive()
        {
            Assert.AreEqual(0, _naive.Fib(0));
            Assert.AreEqual(1, _naive.Fib(1));
            Assert.AreEqual(1, _naive.Fib(2));
            Assert.AreEqual(2, _naive.Fib(3));
            Assert.AreEqual(3, _naive.Fib(4));
            Assert.AreEqual(5, _naive.Fib(5));
            Assert.AreEqual(8, _naive.Fib(6));
            Assert.AreEqual(13, _naive.Fib(7));
            Assert.AreEqual(21, _naive.Fib(8));
        }


        [Test]
        public void Memoized()
        {
            Assert.AreEqual(0, _memo.Fib(0));
            Assert.AreEqual(1, _memo.Fib(1));
            Assert.AreEqual(1, _memo.Fib(2));
            Assert.AreEqual(2, _memo.Fib(3));
            Assert.AreEqual(3, _memo.Fib(4));
            Assert.AreEqual(5, _memo.Fib(5));
            Assert.AreEqual(8, _memo.Fib(6));
            Assert.AreEqual(13, _memo.Fib(7));
            Assert.AreEqual(21, _memo.Fib(8));
        }

    }
}
