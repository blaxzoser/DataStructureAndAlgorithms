using NUnit.Framework;
using Samples.POCOS;
using Samples.questions.lambdas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Test
{
    public class ChatGPTTest
    {
        ChatGPT chatGPT;
        [SetUp]
        public void Setup()
        {
            chatGPT = new ChatGPT();
        }

        [Test]
        public void ShouldReturnTotalSum()
        {           
            Assert.AreEqual(2, chatGPT.SumLambda(1, 1));
            Assert.AreEqual(12, chatGPT.SumLambda(5, 7));
        }

        [Test]
        public void ShouldReturnFilterLambda()
        {
            Assert.AreEqual(new List<int> { 2,4 }, chatGPT.FilterLambda(new List<int> { 1, 2, 3, 4 }));
            Assert.AreEqual(new List<int> { 10, 2 }, chatGPT.FilterLambda(new List<int> { 5, 7, 10, 2 }));
        }

        [Test]
        public void ShouldReturnOrderBySize()
        {
            Assert.AreEqual(new List<string> { "c","aa","aba"}, chatGPT.OrderLambda( new List<string> { "aa", "c", "aba" }));          
        }


        [Test]
        public void ShouldCallDeletate()
        {
            Action<int> performOperation;
            performOperation = PrintPerformOperation;
            chatGPT.PerformOperation(performOperation, 5);

            //Another solution
            // Action<int> performOperation = parameter => Debug.WriteLine(parameter); 
            //chatGPT.PerformOperation(printSquare, 5);
        }

        private static void PrintPerformOperation(int parameter)
        {
            Debug.WriteLine(parameter);
        }

        [Test]
        public void ShouldTransformToSquared()
        {
            Assert.AreEqual(new List<int> { 4,16,36 }, chatGPT.TransformLambda(new List<int> { 2,4,6 }));

        }

        [Test]
        public void ShouldTransformCombination()
        {
            Assert.AreEqual(new List<int> {3,4,5,6}, chatGPT.TransformCombinationLambda(new List<int> { 1, 1, 2, 3, 4, 5, 6 }));

        }

        [Test]
        public void ShouldGetPersonsOrderByName()
        {
            var expected = new List<Person>
            {
                new Person() { Name= "alberto",Age =50 },
                new Person() { Name= "beto",Age =37 },
                new Person() { Name= "cente",Age =70 },
                new Person() { Name= "xolo",Age =31 }
            };

            var actual = chatGPT.GetPersonsOrderByName(
                new List<Person>
                {
                    new Person() { Name= "tito",Age = 15 },
                    new Person() { Name= "zolo",Age =30 },
                    new Person() { Name= "beto",Age =37 },
                    new Person() { Name= "alberto",Age =50 },
                    new Person() { Name= "xolo",Age =31 },
                    new Person() { Name= "cente",Age =70 },
                });


            Assert.That(actual, Is.EquivalentTo(expected));

        }

        [Test]
        public void ShouldGetMajorityElement()
        {
            Assert.AreEqual(2, chatGPT.MajorityElement(new int[] { 1, 2, 1, 4 }));
            Assert.AreEqual(6, chatGPT.MajorityElement(new int[] { 2, 2, 3, 3,4,4,1,2,0,0,0,0,0,0 }));
        }
    }
}
