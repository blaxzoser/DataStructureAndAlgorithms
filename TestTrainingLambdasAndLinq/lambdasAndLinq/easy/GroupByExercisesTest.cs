using System.Collections.Generic;
using NUnit.Framework;
using TrainingLambdasAndLinq.lambdasAndLinq.easy;
using TrainingLambdasAndLinq.POCOS;

namespace TestTrainingLambdasAndLinq.lambdasAndLinq.easy
{
    public class GroupByExercisesTest
    {
        GroupByExercises groupBy;

        [SetUp]
        public void Setup()
        {
            groupBy = new GroupByExercises();
        }

        // ---------------------------- CharFrequency ---------------------------

        [Test]
        public void ShouldGetCharFrequency()
        {
            var result = groupBy.CharFrequency("hello");

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(1, result['h']);
            Assert.AreEqual(1, result['e']);
            Assert.AreEqual(2, result['l']);
            Assert.AreEqual(1, result['o']);
        }

        [Test]
        public void ShouldGetEmptyFrequencyForEmptyText()
        {
            CollectionAssert.IsEmpty(groupBy.CharFrequency(""));
        }

        // ---------------------------- GetDuplicates ---------------------------

        [TestCase(new[] { 4, 1, 4, 2, 1, 4 }, new[] { 4, 1 })]
        [TestCase(new[] { 1, 2, 3 }, new int[0])]
        [TestCase(new[] { 7, 7 }, new[] { 7 })]
        [TestCase(new int[0], new int[0])]
        public void ShouldGetDuplicates(int[] numbers, int[] output)
        {
            CollectionAssert.AreEqual(output, groupBy.GetDuplicates(numbers));
        }

        // -------------------------- GroupNamesByCity --------------------------

        [Test]
        public void ShouldGroupNamesByCity()
        {
            var people = new List<Person>
            {
                new Person("Ana", 20, "Lima"),
                new Person("Luis", 30, "Quito"),
                new Person("Sofia", 25, "Lima"),
            };

            var result = groupBy.GroupNamesByCity(people);

            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEqual(new[] { "Ana", "Sofia" }, result["Lima"]);
            CollectionAssert.AreEqual(new[] { "Luis" }, result["Quito"]);
        }

        // ------------------------- GetMostFrequentChar ------------------------

        [TestCase("hello world", 'l')]
        [TestCase("aabb", 'a')]
        [TestCase("bbaa", 'b')]
        [TestCase("x", 'x')]
        [TestCase("a b b", 'b')]
        [TestCase("a   b", 'a')]
        public void ShouldGetMostFrequentChar(string text, char output)
        {
            Assert.AreEqual(output, groupBy.GetMostFrequentChar(text));
        }

        // ------------------------- GroupWordsByLength -------------------------

        [Test]
        public void ShouldGroupWordsByLength()
        {
            var words = new[] { "cat", "horse", "dog", "bird", "ox" };

            CollectionAssert.AreEqual(
                new[] { "2: ox", "3: cat, dog", "4: bird", "5: horse" },
                groupBy.GroupWordsByLength(words));
        }

        [Test]
        public void ShouldReturnEmptyWhenNoWords()
        {
            CollectionAssert.IsEmpty(groupBy.GroupWordsByLength(new string[0]));
        }
    }
}
