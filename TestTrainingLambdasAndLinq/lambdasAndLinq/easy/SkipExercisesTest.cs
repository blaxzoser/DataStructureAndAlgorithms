using NUnit.Framework;
using TrainingLambdasAndLinq.lambdasAndLinq.easy;

namespace TestTrainingLambdasAndLinq.lambdasAndLinq.easy
{
    public class SkipExercisesTest
    {
        SkipExercises skip;

        [SetUp]
        public void Setup()
        {
            skip = new SkipExercises();
        }

        // ------------------------------ SkipFirst -----------------------------

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 3, 4, 5 })]
        [TestCase(new[] { 1, 2 }, 5, new int[0])]
        [TestCase(new[] { 1, 2 }, 0, new[] { 1, 2 })]
        public void ShouldSkipFirst(int[] numbers, int count, int[] output)
        {
            CollectionAssert.AreEqual(output, skip.SkipFirst(numbers, count));
        }

        // ------------------------------- GetPage ------------------------------

        [TestCase(1, new[] { 1, 2, 3 })]
        [TestCase(2, new[] { 4, 5, 6 })]
        [TestCase(3, new[] { 7, 8, 9 })]
        [TestCase(4, new[] { 10 })]
        [TestCase(5, new int[0])]
        public void ShouldGetPage(int pageNumber, int[] output)
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            CollectionAssert.AreEqual(output, skip.GetPage(items, pageNumber, 3));
        }

        // ------------------------------ GetLastN ------------------------------

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 4, 5 })]
        [TestCase(new[] { 1, 2 }, 5, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, 0, new int[0])]
        [TestCase(new int[0], 3, new int[0])]
        public void ShouldGetLastN(int[] numbers, int n, int[] output)
        {
            CollectionAssert.AreEqual(output, skip.GetLastN(numbers, n));
        }

        // ------------------------- RemoveLeadingZeros -------------------------

        [TestCase(new[] { 0, 0, 1, 0, 2 }, new[] { 1, 0, 2 })]
        [TestCase(new[] { 0, 0 }, new int[0])]
        [TestCase(new[] { 5, 0 }, new[] { 5, 0 })]
        [TestCase(new int[0], new int[0])]
        public void ShouldRemoveLeadingZeros(int[] digits, int[] output)
        {
            CollectionAssert.AreEqual(output, skip.RemoveLeadingZeros(digits));
        }

        // -------------------------- TakeUntilNegative -------------------------

        [TestCase(new[] { 3, 5, -1, 7, 8 }, new[] { 3, 5 })]
        [TestCase(new[] { -1, 2 }, new int[0])]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 0, 4, -2 }, new[] { 0, 4 })]
        public void ShouldTakeUntilNegative(int[] numbers, int[] output)
        {
            CollectionAssert.AreEqual(output, skip.TakeUntilNegative(numbers));
        }

        // ------------------------- RemoveFirstAndLast -------------------------

        [TestCase(new[] { "<", "a", "b", ">" }, new[] { "a", "b" })]
        [TestCase(new[] { "x", "y", "z" }, new[] { "y" })]
        [TestCase(new[] { "x", "y" }, new string[0])]
        [TestCase(new[] { "x" }, new string[0])]
        [TestCase(new string[0], new string[0])]
        public void ShouldRemoveFirstAndLast(string[] items, string[] output)
        {
            CollectionAssert.AreEqual(output, skip.RemoveFirstAndLast(items));
        }
    }
}
