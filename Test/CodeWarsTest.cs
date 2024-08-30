using NUnit.Framework;
using Samples.questions.lambdas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class CodeWarsTest
    {
        private CodeWars _codeWars;

        [SetUp]
        public void Setup()
        {
            _codeWars = new CodeWars();
        }

        [Test]
        public void ShoulBeEqualsText()
        {
            Assert.AreEqual("Hey wollef sroirraw", _codeWars.RemplaceText(5, "Hey fellow warriors"));
        }

        [Test]
        public void ShouldCountOdds()
        {
            Assert.AreEqual(3,_codeWars.CountOdd("1,3,2,2,2,3"));
        }
    }
}
