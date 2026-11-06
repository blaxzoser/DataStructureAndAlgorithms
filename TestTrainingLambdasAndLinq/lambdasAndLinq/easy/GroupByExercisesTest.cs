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

        // ============================ ROUND 3 =================================

        private static List<Employee> Employees() => new List<Employee>
        {
            new Employee("Ana", "IT", 6000),
            new Employee("Luis", "HR", 3000),
            new Employee("Sofia", "IT", 6000),
            new Employee("Pedro", "IT", 5000),
            new Employee("Maria", "Sales", 4000),
            new Employee("Juan", "IT", 4500),
            new Employee("Lucia", "Sales", 4000),
        };

        // ------------------------ GetValuesAppearingOnce ----------------------

        [TestCase(new[] { 4, 1, 4, 2, 1, 5 }, new[] { 2, 5 })]
        [TestCase(new[] { 7, 7 }, new int[0])]
        [TestCase(new[] { 3, 9, 3 }, new[] { 9 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        [TestCase(new int[0], new int[0])]
        public void ShouldGetValuesAppearingOnce(int[] numbers, int[] output)
        {
            CollectionAssert.AreEqual(output, groupBy.GetValuesAppearingOnce(numbers));
        }

        // ------------------------- GetTopKFrequentWords -----------------------

        [TestCase("the cat and the hat and the bat", 2, new[] { "the", "and" })]
        [TestCase("the cat and the hat and the bat", 3, new[] { "the", "and", "bat" })]
        [TestCase("b a c a b c", 2, new[] { "a", "b" })]
        [TestCase("Hi hi HI", 5, new[] { "hi" })]
        [TestCase("  one   two  one ", 1, new[] { "one" })]
        [TestCase("", 3, new string[0])]
        public void ShouldGetTopKFrequentWords(string sentence, int k, string[] output)
        {
            CollectionAssert.AreEqual(output, groupBy.GetTopKFrequentWords(sentence, k));
        }

        // ------------------------ BuildNamesByCityLookup ----------------------

        [Test]
        public void ShouldBuildNamesByCityLookup()
        {
            var people = new List<Person>
            {
                new Person("Ana", 20, "Lima"),
                new Person("Luis", 30, "Quito"),
                new Person("Sofia", 25, "Lima"),
            };

            var lookup = groupBy.BuildNamesByCityLookup(people);

            Assert.AreEqual(2, lookup.Count);
            CollectionAssert.AreEqual(new[] { "Ana", "Sofia" }, lookup["Lima"]);
            CollectionAssert.AreEqual(new[] { "Luis" }, lookup["Quito"]);
        }

        [Test]
        public void ShouldGetEmptyNamesForMissingCityInLookup()
        {
            var people = new List<Person> { new Person("Ana", 20, "Lima") };

            var lookup = groupBy.BuildNamesByCityLookup(people);

            Assert.IsFalse(lookup.Contains("Cusco"));
            CollectionAssert.IsEmpty(lookup["Cusco"]);
        }

        // --------------------- GetAverageSalaryByDepartment -------------------

        [Test]
        public void ShouldGetAverageSalaryByDepartment()
        {
            var employees = new List<Employee>
            {
                new Employee("Ana", "IT", 5000),
                new Employee("Luis", "HR", 3000),
                new Employee("Sofia", "IT", 6000),
                new Employee("Pedro", "IT", 4500),
                new Employee("Maria", "HR", 3500),
            };
            var expected = new Dictionary<string, double> { { "IT", 5166.67 }, { "HR", 3250 } };

            CollectionAssert.AreEquivalent(expected, groupBy.GetAverageSalaryByDepartment(employees));
        }

        [Test]
        public void ShouldGetEmptyAverageSalaryForNoEmployees()
        {
            CollectionAssert.IsEmpty(groupBy.GetAverageSalaryByDepartment(new List<Employee>()));
        }

        // ------------------ GetSecondHighestSalaryByDepartment ----------------

        [Test]
        public void ShouldGetSecondHighestSalaryByDepartment()
        {
            var expected = new Dictionary<string, int> { { "IT", 5000 }, { "HR", 0 }, { "Sales", 0 } };

            CollectionAssert.AreEquivalent(expected, groupBy.GetSecondHighestSalaryByDepartment(Employees()));
        }

        [Test]
        public void ShouldGetSecondHighestSalaryWhenUnsorted()
        {
            var employees = new List<Employee>
            {
                new Employee("Ana", "IT", 1000),
                new Employee("Luis", "IT", 9000),
                new Employee("Sofia", "IT", 7000),
                new Employee("Pedro", "IT", 3000),
            };
            var expected = new Dictionary<string, int> { { "IT", 7000 } };

            CollectionAssert.AreEquivalent(expected, groupBy.GetSecondHighestSalaryByDepartment(employees));
        }

        // ------------------------ CountStudentsByCourse -----------------------

        [Test]
        public void ShouldCountStudentsByCourse()
        {
            var students = new List<Student>
            {
                new Student("Ana", new List<string> { "Math", "Art" }),
                new Student("Luis", new List<string> { "Math" }),
                new Student("Sofia", new List<string> { "Art", "Math", "Art" }),
                new Student("Juan", new List<string>()),
            };
            var expected = new Dictionary<string, int> { { "Math", 3 }, { "Art", 2 } };

            CollectionAssert.AreEquivalent(expected, groupBy.CountStudentsByCourse(students));
        }

        [Test]
        public void ShouldCountNoCoursesWhenStudentsHaveNone()
        {
            var students = new List<Student> { new Student("Juan", new List<string>()) };

            CollectionAssert.IsEmpty(groupBy.CountStudentsByCourse(students));
        }

        // --------------------- CountPeopleByCityAndAgeGroup -------------------

        [Test]
        public void ShouldCountPeopleByCityAndAgeGroup()
        {
            var people = new List<Person>
            {
                new Person("Ana", 20, "Lima"),
                new Person("Luis", 15, "Quito"),
                new Person("Sofia", 12, "Lima"),
                new Person("Pedro", 40, "Lima"),
                new Person("Maria", 30, "Quito"),
                new Person("Juan", 18, "Lima"),
            };

            CollectionAssert.AreEqual(
                new[] { "Lima - Adult: 3", "Lima - Minor: 1", "Quito - Adult: 1", "Quito - Minor: 1" },
                groupBy.CountPeopleByCityAndAgeGroup(people));
        }

        [Test]
        public void ShouldSortCityBeforeAgeGroup()
        {
            var people = new List<Person>
            {
                new Person("Ana", 10, "Quito"),
                new Person("Luis", 50, "Cusco"),
                new Person("Sofia", 9, "Cusco"),
            };

            CollectionAssert.AreEqual(
                new[] { "Cusco - Adult: 1", "Cusco - Minor: 1", "Quito - Minor: 1" },
                groupBy.CountPeopleByCityAndAgeGroup(people));
        }

        [Test]
        public void ShouldCountNoGroupsForNoPeople()
        {
            CollectionAssert.IsEmpty(groupBy.CountPeopleByCityAndAgeGroup(new List<Person>()));
        }

        // --------------------------- SplitIntoBatches -------------------------

        [Test]
        public void ShouldSplitIntoBatches()
        {
            var result = groupBy.SplitIntoBatches(new[] { 1, 2, 3, 4, 5, 6, 7 }, 3);

            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result[0]);
            CollectionAssert.AreEqual(new[] { 4, 5, 6 }, result[1]);
            CollectionAssert.AreEqual(new[] { 7 }, result[2]);
        }

        [Test]
        public void ShouldMakeOneBatchWhenSizeIsBigger()
        {
            var result = groupBy.SplitIntoBatches(new[] { 1, 2 }, 5);

            Assert.AreEqual(1, result.Count);
            CollectionAssert.AreEqual(new[] { 1, 2 }, result[0]);
        }

        [Test]
        public void ShouldMakeBatchesOfOne()
        {
            var result = groupBy.SplitIntoBatches(new[] { 8, 9 }, 1);

            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEqual(new[] { 8 }, result[0]);
            CollectionAssert.AreEqual(new[] { 9 }, result[1]);
        }

        [Test]
        public void ShouldMakeNoBatchesForEmptyArray()
        {
            CollectionAssert.IsEmpty(groupBy.SplitIntoBatches(new int[0], 3));
        }

        // ------------------------- CountPeopleByCountry -----------------------

        [Test]
        public void ShouldCountPeopleByCountry()
        {
            var cities = new List<City>
            {
                new City("Lima", "Peru", true),
                new City("Cusco", "Peru", false),
                new City("Quito", "Ecuador", true),
            };
            var people = new List<Person>
            {
                new Person("Ana", 20, "Lima"),
                new Person("Luis", 30, "Quito"),
                new Person("Sofia", 25, "Cusco"),
                new Person("Pedro", 40, "Lima"),
                new Person("Maria", 35, "Bogota"),
            };
            var expected = new Dictionary<string, int> { { "Peru", 3 }, { "Ecuador", 1 }, { "Unknown", 1 } };

            CollectionAssert.AreEquivalent(expected, groupBy.CountPeopleByCountry(people, cities));
        }

        [Test]
        public void ShouldCountEveryoneAsUnknownWhenNoCities()
        {
            var people = new List<Person>
            {
                new Person("Ana", 20, "Lima"),
                new Person("Luis", 30, "Quito"),
            };
            var expected = new Dictionary<string, int> { { "Unknown", 2 } };

            CollectionAssert.AreEquivalent(expected, groupBy.CountPeopleByCountry(people, new List<City>()));
        }

        // ---------------------- GetProductCountsByCustomer --------------------

        [Test]
        public void ShouldGetProductCountsByCustomer()
        {
            var orders = new List<Order>
            {
                new Order(1, "Ana", new List<string> { "Pen", "Book" }),
                new Order(2, "Luis", new List<string> { "Cup" }),
                new Order(3, "Ana", new List<string> { "Pen" }),
                new Order(4, "Sofia", new List<string>()),
            };

            var result = groupBy.GetProductCountsByCustomer(orders);

            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "Pen", 2 }, { "Book", 1 } }, result["Ana"]);
            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "Cup", 1 } }, result["Luis"]);
            CollectionAssert.IsEmpty(result["Sofia"]);
        }

        [Test]
        public void ShouldCountSameProductTwiceInOneOrder()
        {
            var orders = new List<Order> { new Order(1, "Ana", new List<string> { "Pen", "Pen" }) };

            var result = groupBy.GetProductCountsByCustomer(orders);

            CollectionAssert.AreEquivalent(new Dictionary<string, int> { { "Pen", 2 } }, result["Ana"]);
        }
    }
}
