using System.Collections.Generic;
using NUnit.Framework;
using TrainingLambdasAndLinq.lambdasAndLinq.easy;
using TrainingLambdasAndLinq.POCOS;

namespace TestTrainingLambdasAndLinq.lambdasAndLinq.easy
{
    public class SelectManyExercisesTest
    {
        SelectManyExercises selectMany;

        [SetUp]
        public void Setup()
        {
            selectMany = new SelectManyExercises();
        }

        // ------------------------------ Flatten -------------------------------

        [Test]
        public void ShouldFlattenMatrix()
        {
            var matrix = new[] { new[] { 1, 2 }, new[] { 3 }, new[] { 4, 5, 6 } };

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, selectMany.Flatten(matrix));
        }

        [Test]
        public void ShouldFlattenMatrixWithEmptyRows()
        {
            var matrix = new[] { new int[0], new[] { 7 }, new int[0] };

            CollectionAssert.AreEqual(new[] { 7 }, selectMany.Flatten(matrix));
        }

        // -------------------------- GetAllCharacters --------------------------

        [TestCase(new[] { "hi", "yo" }, new[] { 'h', 'i', 'y', 'o' })]
        [TestCase(new[] { "", "abc" }, new[] { 'a', 'b', 'c' })]
        [TestCase(new string[0], new char[0])]
        public void ShouldGetAllCharacters(string[] input, char[] output)
        {
            CollectionAssert.AreEqual(output, selectMany.GetAllCharacters(input));
        }

        // --------------------------- GetAllCourses ----------------------------

        [Test]
        public void ShouldGetAllCoursesDistinctAndSorted()
        {
            var students = new List<Student>
            {
                new Student("Ana", new List<string> { "Math", "Art" }),
                new Student("Luis", new List<string> { "Math", "History" }),
                new Student("Sofia", new List<string> { "Biology" }),
            };

            CollectionAssert.AreEqual(
                new[] { "Art", "Biology", "History", "Math" },
                selectMany.GetAllCourses(students));
        }

        [Test]
        public void ShouldReturnEmptyCoursesWhenStudentsHaveNone()
        {
            var students = new List<Student> { new Student("Ana", new List<string>()) };

            CollectionAssert.IsEmpty(selectMany.GetAllCourses(students));
        }

        // ---------------------------- GetAllPairs -----------------------------

        [TestCase(new[] { 1, 2 }, new[] { "a", "b" }, new[] { "1a", "1b", "2a", "2b" })]
        [TestCase(new[] { 1 }, new string[0], new string[0])]
        [TestCase(new[] { 3 }, new[] { "x", "y", "z" }, new[] { "3x", "3y", "3z" })]
        public void ShouldGetAllPairs(int[] numbers, string[] letters, string[] output)
        {
            CollectionAssert.AreEqual(output, selectMany.GetAllPairs(numbers, letters));
        }

        // ------------------------ GetCustomerProducts -------------------------

        [Test]
        public void ShouldGetCustomerProducts()
        {
            var orders = new List<Order>
            {
                new Order(1, "Ana", new List<string> { "Pen", "Book" }),
                new Order(2, "Luis", new List<string> { "Cup" }),
                new Order(3, "Sofia", new List<string>()),
            };

            CollectionAssert.AreEqual(
                new[] { "Ana:Pen", "Ana:Book", "Luis:Cup" },
                selectMany.GetCustomerProducts(orders));
        }
    }
}
