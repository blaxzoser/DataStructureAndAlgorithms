using System.Collections.Generic;
using NUnit.Framework;
using TrainingLambdasAndLinq.lambdasAndLinq.easy;
using TrainingLambdasAndLinq.POCOS;

namespace TestTrainingLambdasAndLinq.lambdasAndLinq.easy
{
    public class ThenByExercisesTest
    {
        ThenByExercises thenBy;

        [SetUp]
        public void Setup()
        {
            thenBy = new ThenByExercises();
        }

        // -------------------------- SortWordsByLength -------------------------

        [TestCase(new[] { "pear", "fig", "apple", "kiwi", "date" }, new[] { "fig", "date", "kiwi", "pear", "apple" })]
        [TestCase(new[] { "b", "a" }, new[] { "a", "b" })]
        [TestCase(new[] { "bb", "a", "aa" }, new[] { "a", "aa", "bb" })]
        [TestCase(new string[0], new string[0])]
        public void ShouldSortWordsByLength(string[] words, string[] output)
        {
            CollectionAssert.AreEqual(output, thenBy.SortWordsByLength(words));
        }

        // ------------------------- SortPeopleByAgeThenName --------------------

        [Test]
        public void ShouldSortPeopleByAgeThenName()
        {
            var people = new List<Person>
            {
                new Person("Ana", 30, "Lima"),
                new Person("Luis", 25, "Quito"),
                new Person("Eva", 30, "Lima"),
                new Person("Bob", 25, "Cusco"),
            };

            CollectionAssert.AreEqual(new[] { "Bob", "Luis", "Ana", "Eva" }, thenBy.SortPeopleByAgeThenName(people));
        }

        [Test]
        public void ShouldReturnEmptyWhenNoPeopleToSortByAge()
        {
            CollectionAssert.IsEmpty(thenBy.SortPeopleByAgeThenName(new List<Person>()));
        }

        // ------------------------ SortPeopleByCityThenOldest ------------------

        [Test]
        public void ShouldSortPeopleByCityThenOldest()
        {
            var people = new List<Person>
            {
                new Person("Ana", 20, "Lima"),
                new Person("Luis", 30, "Quito"),
                new Person("Sofia", 45, "Lima"),
                new Person("Pedro", 25, "Quito"),
                new Person("Maria", 35, "Lima"),
            };

            CollectionAssert.AreEqual(
                new[] { "Sofia", "Maria", "Ana", "Luis", "Pedro" },
                thenBy.SortPeopleByCityThenOldest(people));
        }

        // ---------------------- SortEmployeesBySalaryThenName -----------------

        [Test]
        public void ShouldSortEmployeesBySalaryThenName()
        {
            var employees = new List<Employee>
            {
                new Employee("Ana", "IT", 6000),
                new Employee("Luis", "HR", 3000),
                new Employee("Sofia", "IT", 6000),
                new Employee("Pedro", "IT", 5000),
            };

            CollectionAssert.AreEqual(
                new[] { "Ana", "Sofia", "Pedro", "Luis" },
                thenBy.SortEmployeesBySalaryThenName(employees));
        }

        [Test]
        public void ShouldKeepAllEmployeesWithTheSameSalary()
        {
            var employees = new List<Employee>
            {
                new Employee("Zoe", "IT", 1000),
                new Employee("Ana", "IT", 1000),
            };

            CollectionAssert.AreEqual(new[] { "Ana", "Zoe" }, thenBy.SortEmployeesBySalaryThenName(employees));
        }

        // ------------------------------ EvensFirst ----------------------------

        [TestCase(new[] { 5, 2, 8, 1, 4, 3 }, new[] { 2, 4, 8, 1, 3, 5 })]
        [TestCase(new[] { 3, 1, 2 }, new[] { 2, 1, 3 })]
        [TestCase(new[] { -3, 2, -4, 1 }, new[] { -4, 2, -3, 1 })]
        [TestCase(new[] { 7, 9 }, new[] { 7, 9 })]
        [TestCase(new int[0], new int[0])]
        public void ShouldPutEvensFirst(int[] numbers, int[] output)
        {
            CollectionAssert.AreEqual(output, thenBy.EvensFirst(numbers));
        }

        // ------------------------ SortWordsByLastLetter -----------------------

        [TestCase(new[] { "banana", "apple", "kiwi", "pear", "tuna" }, new[] { "banana", "tuna", "apple", "kiwi", "pear" })]
        [TestCase(new[] { "cb", "ba", "aa" }, new[] { "aa", "ba", "cb" })]
        [TestCase(new string[0], new string[0])]
        public void ShouldSortWordsByLastLetter(string[] words, string[] output)
        {
            CollectionAssert.AreEqual(output, thenBy.SortWordsByLastLetter(words));
        }

        // ------------------------ SortIgnoringCaseUpperFirst ------------------

        [TestCase(new[] { "Bob", "alice", "Alice", "bob" }, new[] { "Alice", "alice", "Bob", "bob" })]
        [TestCase(new[] { "b", "A", "a", "B" }, new[] { "A", "a", "B", "b" })]
        [TestCase(new[] { "zed", "Amy" }, new[] { "Amy", "zed" })]
        [TestCase(new string[0], new string[0])]
        public void ShouldSortIgnoringCaseUpperFirst(string[] words, string[] output)
        {
            CollectionAssert.AreEqual(output, thenBy.SortIgnoringCaseUpperFirst(words));
        }

        // ---------------------------- SortLeaderboard -------------------------

        [Test]
        public void ShouldSortLeaderboard()
        {
            var scores = new Dictionary<string, int>
            {
                { "Zoe", 90 },
                { "Ana", 70 },
                { "Luis", 90 },
                { "Eva", 85 },
            };

            CollectionAssert.AreEqual(new[] { "Luis", "Zoe", "Eva", "Ana" }, thenBy.SortLeaderboard(scores));
        }

        [Test]
        public void ShouldReturnEmptyLeaderboardWhenNoScores()
        {
            CollectionAssert.IsEmpty(thenBy.SortLeaderboard(new Dictionary<string, int>()));
        }

        // -------------------------- AdultsFirstThenByName ---------------------

        [Test]
        public void ShouldPutAdultsFirstThenByName()
        {
            var people = new List<Person>
            {
                new Person("Tom", 10, "Lima"),
                new Person("Ana", 20, "Lima"),
                new Person("Bea", 17, "Lima"),
                new Person("Carl", 40, "Lima"),
                new Person("Dan", 18, "Lima"),
            };

            CollectionAssert.AreEqual(
                new[] { "Ana", "Carl", "Dan", "Bea", "Tom" },
                thenBy.AdultsFirstThenByName(people));
        }

        // --------------------------- RankDepartments --------------------------

        [Test]
        public void ShouldRankDepartments()
        {
            var employees = new List<Employee>
            {
                new Employee("Ana", "IT", 6000),
                new Employee("Sofia", "IT", 6000),
                new Employee("Pedro", "IT", 5000),
                new Employee("Maria", "Sales", 4000),
                new Employee("Lucia", "Sales", 4000),
                new Employee("Raul", "Ops", 5000),
                new Employee("Eva", "Ops", 4000),
                new Employee("Luis", "HR", 3000),
                new Employee("Zoe", "Fin", 3000),
            };

            CollectionAssert.AreEqual(
                new[] { "IT", "Ops", "Sales", "Fin", "HR" },
                thenBy.RankDepartments(employees));
        }

        [Test]
        public void ShouldReturnEmptyWhenNoEmployeesToRank()
        {
            CollectionAssert.IsEmpty(thenBy.RankDepartments(new List<Employee>()));
        }
    }
}
