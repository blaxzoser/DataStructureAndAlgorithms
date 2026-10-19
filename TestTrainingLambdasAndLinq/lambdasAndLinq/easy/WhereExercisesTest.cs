using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TrainingLambdasAndLinq.lambdasAndLinq.easy;
using TrainingLambdasAndLinq.POCOS;

namespace TestTrainingLambdasAndLinq.lambdasAndLinq.easy
{
    public class WhereExercisesTest
    {
        WhereExercises where;

        [SetUp]
        public void Setup()
        {
            where = new WhereExercises();
        }

        // --------------------------- GetEvenNumbers ---------------------------

        [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 2, 4, 6 })]
        [TestCase(new[] { 1, 3, 5 }, new int[0])]
        [TestCase(new int[0], new int[0])]
        [TestCase(new[] { -4, -3, 0 }, new[] { -4, 0 })]
        public void ShouldGetEvenNumbers(int[] input, int[] output)
        {
            CollectionAssert.AreEqual(output, where.GetEvenNumbers(input));
        }

        // ------------------------- GetWordsLongerThan -------------------------

        [TestCase(new[] { "apple", "fig", "banana", "kiwi" }, 4, new[] { "apple", "banana" })]
        [TestCase(new[] { "a", "bb" }, 5, new string[0])]
        [TestCase(new[] { "abc", "abcd" }, 3, new[] { "abcd" })]
        public void ShouldGetWordsLongerThan(string[] input, int minLength, string[] output)
        {
            CollectionAssert.AreEqual(output, where.GetWordsLongerThan(input, minLength));
        }

        // ------------------------------ GetAdults -----------------------------

        [Test]
        public void ShouldGetAdults()
        {
            var people = new List<Person>
            {
                new Person("Ana", 17, "Lima"),
                new Person("Luis", 30, "Quito"),
                new Person("Sofia", 18, "Lima"),
                new Person("Pedro", 12, "Quito"),
            };

            var result = where.GetAdults(people);

            CollectionAssert.AreEqual(new[] { "Luis", "Sofia" }, result.Select(p => p.Name));
        }

        [Test]
        public void ShouldReturnEmptyWhenNoAdults()
        {
            var people = new List<Person> { new Person("Ana", 10, "Lima") };

            CollectionAssert.IsEmpty(where.GetAdults(people));
        }

        // --------------------- GetPeopleFromCityOlderThan ---------------------

        [Test]
        public void ShouldGetPeopleFromCityOlderThan()
        {
            var people = new List<Person>
            {
                new Person("Ana", 25, "Lima"),
                new Person("Luis", 30, "Quito"),
                new Person("Sofia", 40, "lima"),
                new Person("Pedro", 20, "Lima"),
                new Person("Maria", 21, "Lima"),
            };

            var result = where.GetPeopleFromCityOlderThan(people, "Lima", 21);

            CollectionAssert.AreEqual(new[] { "Ana", "Sofia" }, result.Select(p => p.Name));
        }

        // ----------------------- GetElementsAtEvenIndex -----------------------

        [TestCase(new[] { "a", "b", "c", "d", "e" }, new[] { "a", "c", "e" })]
        [TestCase(new[] { "x" }, new[] { "x" })]
        [TestCase(new[] { "x", "y" }, new[] { "x" })]
        [TestCase(new string[0], new string[0])]
        public void ShouldGetElementsAtEvenIndex(string[] input, string[] output)
        {
            CollectionAssert.AreEqual(output, where.GetElementsAtEvenIndex(input));
        }
    }
}
