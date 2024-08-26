using NUnit.Framework;
using Samples.questions.lambdas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.algorithms.questions
{
    public class PatternsTest
    {
        private readonly Patterns patterns;
        
        public PatternsTest()
        {
            patterns = new Patterns();
        }


        [Test]
        public void ShouldReturnSumMax()
        {
            Assert.AreEqual(27,patterns.MaxGroupSum("1 2 3,3 4 5,1 2 3 4 5,9 9 9,7 5,3 4 6"));
        }

        [Test]
        public void ShoudReturHasContains()
        {
            Assert.AreEqual("coco,mexico,tiachelayrosa", patterns.ContainsLetter("terra,coco,mexico,maxima,tiachelayrosa","o"));
        }

        [Test]
        public void ShoudReturnMaxContains()
        {
            Assert.AreEqual("tiachelayrosa", patterns.MaxContains("terra,coco,mexico,maxima,tiachelayrosa"));
        }

        [Test]
        public void ShoudReturnSkipEverySecondWord()
        {
            var elements = new string[] { "luis","micke","pipo","arez" };
            var result = new string[] { "luis", "pipo", };
            Assert.AreEqual(result, patterns.SkipSecondWord(elements));
        }


        [Test]
        public void ShoudReturnOnlyLenghtEven()
        {
            var elements = new string[] { "mi", "pip", "arez","a" };
            var result = new string[] {  "pip","a" };
            Assert.AreEqual(result, patterns.ReturnEven(elements));
        }
    }
}
