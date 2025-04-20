using NUnit.Framework;
using Samples.questions.leetcode.array;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.leetcode
{
    public class ArrayDoubleTest
    {
        ArrayDouble arrayDouble;

        [SetUp]
        public void Setup()
        {
            arrayDouble = new ArrayDouble();
        }

        [Test]
        public void ShouldReturnTotalSum()
        {
            int[][] input = new int[3][]
            {
                new int[] {1, 2, 3},
                new int[] {4, 5, 6},
                new int[] {7, 8, 9}
            };

            int[][] output = new int[3][]
           {
                new int[] {7, 4, 1},
                new int[] {8, 5, 2},
                new int[] {9, 6, 3}
           };

            arrayDouble.RotateImage(input);

            Assert.AreEqual(input, output);
        }


        [Test]
        public void ShouldReturnReverseRows()
        {
            int[][] input = new int[3][]
            {
                new int[] {1, 2, 3,5},
                new int[] {4, 5, 6,8},
                new int[] {7, 8, 9,10}
            };

            int[][] output = new int[3][]
           {
                new int[] {5,3,2,1},
                new int[] {8, 6, 5, 4},
                new int[] {10,9, 8, 7}
           };

            arrayDouble.ReverseArrayDoubleOnlyRows(input);

            Assert.AreEqual(input, output);
        }

    }
}
