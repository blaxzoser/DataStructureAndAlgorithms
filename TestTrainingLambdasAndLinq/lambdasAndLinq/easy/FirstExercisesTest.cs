using System;
using System.Collections.Generic;
using NUnit.Framework;
using TrainingLambdasAndLinq.lambdasAndLinq.easy;
using TrainingLambdasAndLinq.POCOS;

namespace TestTrainingLambdasAndLinq.lambdasAndLinq.easy
{
    public class FirstExercisesTest
    {
        FirstExercises first;
        List<Person> people;

        [SetUp]
        public void Setup()
        {
            first = new FirstExercises();
            people = new List<Person>
            {
                new Person("Ana", 15, "Lima"),
                new Person("Luis", 30, "Quito"),
                new Person("Sofia", 22, "Lima"),
                new Person("Pedro", 40, "Lima"),
            };
        }

        // ------------------------ GetFirstGreaterThan -------------------------

        [TestCase(new[] { 1, 7, 3, 9 }, 5, 7)]
        [TestCase(new[] { 10 }, 5, 10)]
        [TestCase(new[] { 5, 6 }, 5, 6)]
        public void ShouldGetFirstGreaterThan(int[] input, int value, int output)
        {
            Assert.AreEqual(output, first.GetFirstGreaterThan(input, value));
        }

        [Test]
        public void ShouldThrowWhenNoNumberIsGreater()
        {
            Assert.Throws<InvalidOperationException>(() => first.GetFirstGreaterThan(new[] { 1, 2 }, 5));
        }

        // ----------------------- GetFirstNegativeOrZero -----------------------

        [TestCase(new[] { 3, -2, 5, -8 }, -2)]
        [TestCase(new[] { 1, 2, 3 }, 0)]
        [TestCase(new int[0], 0)]
        public void ShouldGetFirstNegativeOrZero(int[] input, int output)
        {
            Assert.AreEqual(output, first.GetFirstNegativeOrZero(input));
        }

        // -------------------------- FindPersonByName --------------------------

        [Test]
        public void ShouldFindPersonByNameIgnoringCase()
        {
            var result = first.FindPersonByName(people, "luis");

            Assert.IsNotNull(result);
            Assert.AreEqual("Luis", result.Name);
            Assert.AreEqual(30, result.Age);
        }

        [Test]
        public void ShouldReturnNullWhenPersonNotFound()
        {
            Assert.IsNull(first.FindPersonByName(people, "Maria"));
        }

        // ---------------------- GetFirstWordStartingWith ----------------------

        [TestCase(new[] { "apple", "banana", "blueberry" }, 'b', "banana")]
        [TestCase(new[] { "apple" }, 'z', "NOT FOUND")]
        [TestCase(new[] { "", "cat" }, 'c', "cat")]
        [TestCase(new string[0], 'a', "NOT FOUND")]
        public void ShouldGetFirstWordStartingWith(string[] words, char letter, string output)
        {
            Assert.AreEqual(output, first.GetFirstWordStartingWith(words, letter));
        }

        // ---------------------- GetFirstAdultNameInCity -----------------------

        [TestCase("Lima", "Sofia")]
        [TestCase("Quito", "Luis")]
        [TestCase("Cusco", null)]
        public void ShouldGetFirstAdultNameInCity(string city, string output)
        {
            Assert.AreEqual(output, first.GetFirstAdultNameInCity(people, city));
        }

        [Test]
        public void ShouldReturnNullWhenNoAdultInCity()
        {
            var kids = new List<Person> { new Person("Ana", 15, "Lima") };

            Assert.IsNull(first.GetFirstAdultNameInCity(kids, "Lima"));
        }
    }
}
