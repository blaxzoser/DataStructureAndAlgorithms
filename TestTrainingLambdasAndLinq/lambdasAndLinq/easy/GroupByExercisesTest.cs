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

        [TestCase("hello")]
        [TestCase("")]
        [TestCase("aabbbc")]
        public void ShouldGetSameCharFrequencyInDebugVersion(string text)
        {
            CollectionAssert.AreEquivalent(groupBy.CharFrequency(text), groupBy.CharFrequencyDebug(text));
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

        [TestCase(new[] { 4, 1, 4, 2, 1, 4 }, new[] { 4, 1 })]
        [TestCase(new[] { 1, 2, 3 }, new int[0])]
        public void ShouldGetSameDuplicatesInDebugVersion(int[] numbers, int[] output)
        {
            CollectionAssert.AreEqual(output, groupBy.GetDuplicatesDebug(numbers));
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

        [TestCase("hello world", 'l')]
        [TestCase("aabb", 'a')]
        [TestCase("a   b", 'a')]
        public void ShouldGetSameMostFrequentCharInDebugVersion(string text, char output)
        {
            Assert.AreEqual(output, groupBy.GetMostFrequentCharDebug(text));
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

        [Test]
        public void ShouldGetSameWordsByLengthInDebugVersion()
        {
            var words = new[] { "cat", "horse", "dog", "bird", "ox" };

            CollectionAssert.AreEqual(
                new[] { "2: ox", "3: cat, dog", "4: bird", "5: horse" },
                groupBy.GroupWordsByLengthDebug(words));
        }

        // ============================ ROUND 2 =================================

        // --------------------------- CountEvenAndOdd --------------------------

        [Test]
        public void ShouldCountEvenAndOdd()
        {
            var expected = new Dictionary<string, int> { { "Odd", 3 }, { "Even", 2 } };

            CollectionAssert.AreEquivalent(expected, groupBy.CountEvenAndOdd(new[] { 1, 2, 3, 4, 5 }));
        }

        [Test]
        public void ShouldHaveNoOddKeyWhenAllEven()
        {
            var expected = new Dictionary<string, int> { { "Even", 2 } };

            CollectionAssert.AreEquivalent(expected, groupBy.CountEvenAndOdd(new[] { 2, 4 }));
        }

        [Test]
        public void ShouldCountNegativeNumbersToo()
        {
            var expected = new Dictionary<string, int> { { "Odd", 2 }, { "Even", 2 } };

            CollectionAssert.AreEquivalent(expected, groupBy.CountEvenAndOdd(new[] { -3, -2, 0, 7 }));
        }

        [Test]
        public void ShouldCountEvenAndOddOfEmptyArray()
        {
            CollectionAssert.IsEmpty(groupBy.CountEvenAndOdd(new int[0]));
        }

        // ----------------------- CountWordsByFirstLetter ----------------------

        [Test]
        public void ShouldCountWordsByFirstLetterIgnoringCase()
        {
            var words = new[] { "Apple", "avocado", "banana", "Blueberry", "cherry" };
            var expected = new Dictionary<char, int> { { 'a', 2 }, { 'b', 2 }, { 'c', 1 } };

            CollectionAssert.AreEquivalent(expected, groupBy.CountWordsByFirstLetter(words));
        }

        [Test]
        public void ShouldCountWordsByFirstLetterOfEmptyArray()
        {
            CollectionAssert.IsEmpty(groupBy.CountWordsByFirstLetter(new string[0]));
        }

        // ------------------------- GetCitiesWithAtLeast -----------------------

        [TestCase(2, new[] { "Cusco", "Lima" })]
        [TestCase(3, new[] { "Lima" })]
        [TestCase(1, new[] { "Cusco", "Lima", "Quito" })]
        [TestCase(5, new string[0])]
        public void ShouldGetCitiesWithAtLeast(int minPeople, string[] output)
        {
            var people = new List<Person>
            {
                new Person("Ana", 20, "Lima"),
                new Person("Luis", 30, "Quito"),
                new Person("Sofia", 25, "Lima"),
                new Person("Pedro", 40, "Cusco"),
                new Person("Maria", 35, "Cusco"),
                new Person("Juan", 50, "Lima"),
            };

            CollectionAssert.AreEqual(output, groupBy.GetCitiesWithAtLeast(people, minPeople));
        }

        // ----------------------- CountProductsByCustomer ----------------------

        [Test]
        public void ShouldCountProductsByCustomer()
        {
            var orders = new List<Order>
            {
                new Order(1, "Ana", new List<string> { "Pen", "Book" }),
                new Order(2, "Luis", new List<string> { "Cup" }),
                new Order(3, "Ana", new List<string> { "Lamp" }),
                new Order(4, "Luis", new List<string>()),
            };
            var expected = new Dictionary<string, int> { { "Ana", 3 }, { "Luis", 1 } };

            CollectionAssert.AreEquivalent(expected, groupBy.CountProductsByCustomer(orders));
        }

        [Test]
        public void ShouldCountZeroProductsForCustomerWithEmptyOrders()
        {
            var orders = new List<Order> { new Order(1, "Sofia", new List<string>()) };
            var expected = new Dictionary<string, int> { { "Sofia", 0 } };

            CollectionAssert.AreEquivalent(expected, groupBy.CountProductsByCustomer(orders));
        }

        // ------------------------ GetOldestPersonByCity -----------------------

        [Test]
        public void ShouldGetOldestPersonByCity()
        {
            var people = new List<Person>
            {
                new Person("Ana", 20, "Lima"),
                new Person("Luis", 30, "Quito"),
                new Person("Sofia", 45, "Lima"),
                new Person("Pedro", 25, "Quito"),
                new Person("Maria", 45, "Lima"),
            };
            var expected = new Dictionary<string, string> { { "Lima", "Sofia" }, { "Quito", "Luis" } };

            CollectionAssert.AreEquivalent(expected, groupBy.GetOldestPersonByCity(people));
        }

        [Test]
        public void ShouldGetOnlyPersonWhenCityHasOne()
        {
            var people = new List<Person> { new Person("Ana", 20, "Cusco") };
            var expected = new Dictionary<string, string> { { "Cusco", "Ana" } };

            CollectionAssert.AreEquivalent(expected, groupBy.GetOldestPersonByCity(people));
        }
    }
}
