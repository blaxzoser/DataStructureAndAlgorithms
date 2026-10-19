using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TrainingLambdasAndLinq.lambdasAndLinq.easy;
using TrainingLambdasAndLinq.POCOS;

namespace TestTrainingLambdasAndLinq.lambdasAndLinq.easy
{
    public class ContainsExercisesTest
    {
        ContainsExercises contains;

        [SetUp]
        public void Setup()
        {
            contains = new ContainsExercises();
        }

        // ------------------------------ HasNumber -----------------------------

        [TestCase(new[] { 1, 5, 9 }, 5, true)]
        [TestCase(new[] { 1, 5, 9 }, 4, false)]
        [TestCase(new int[0], 1, false)]
        public void ShouldCheckHasNumber(int[] numbers, int target, bool output)
        {
            Assert.AreEqual(output, contains.HasNumber(numbers, target));
        }

        // ----------------------------- CountVowels ----------------------------

        [TestCase("hello", 2)]
        [TestCase("AEIOU", 5)]
        [TestCase("Programming in CSharp", 5)]
        [TestCase("rhythm", 0)]
        [TestCase("", 0)]
        public void ShouldCountVowels(string text, int output)
        {
            Assert.AreEqual(output, contains.CountVowels(text));
        }

        // ------------------------------ ArrayDiff -----------------------------

        [TestCase(new[] { 1, 2, 2, 3 }, new[] { 2 }, new[] { 1, 3 })]
        [TestCase(new[] { 1, 1, 3 }, new[] { 2 }, new[] { 1, 1, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new int[0], new[] { 1, 2, 3 })]
        [TestCase(new int[0], new[] { 1 }, new int[0])]
        [TestCase(new[] { 1, 2 }, new[] { 1, 2 }, new int[0])]
        public void ShouldGetArrayDiff(int[] a, int[] b, int[] output)
        {
            CollectionAssert.AreEqual(output, contains.ArrayDiff(a, b));
        }

        // ------------------------------ IsPangram -----------------------------

        [TestCase("The quick brown fox jumps over the lazy dog", true)]
        [TestCase("Pack my box with five dozen liquor jugs", true)]
        [TestCase("Hello world", false)]
        [TestCase("", false)]
        public void ShouldCheckPangram(string sentence, bool output)
        {
            Assert.AreEqual(output, contains.IsPangram(sentence));
        }

        // ------------------------- GetPeopleFromCities ------------------------

        [Test]
        public void ShouldGetPeopleFromCities()
        {
            var people = new List<Person>
            {
                new Person("Ana", 20, "Lima"),
                new Person("Luis", 30, "Quito"),
                new Person("Sofia", 25, "Cusco"),
                new Person("Pedro", 40, "Lima"),
            };

            var result = contains.GetPeopleFromCities(people, new[] { "Lima", "Cusco" });

            CollectionAssert.AreEqual(new[] { "Ana", "Sofia", "Pedro" }, result.Select(p => p.Name));
        }

        [Test]
        public void ShouldReturnEmptyWhenNoCitiesGiven()
        {
            var people = new List<Person> { new Person("Ana", 20, "Lima") };

            CollectionAssert.IsEmpty(contains.GetPeopleFromCities(people, new string[0]));
        }

        // ------------------------------ IsBinary ------------------------------

        [TestCase("1,0,1,1", true)]
        [TestCase("1", true)]
        [TestCase("1,0,2", false)]
        [TestCase("10,1", false)]
        public void ShouldCheckIsBinary(string text, bool output)
        {
            Assert.AreEqual(output, contains.IsBinary(text));
        }
    }
}
