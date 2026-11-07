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

        // ========================== ROUND 2 (6-15) ===========================

        // -------------------------- ExpandRunLength ---------------------------

        [TestCase(new[] { 1, 2, 3, 4 }, new[] { 2, 4, 4, 4 })]
        [TestCase(new[] { 1, 1, 2, 3 }, new[] { 1, 3, 3 })]
        [TestCase(new[] { 0, 5, 2, 7 }, new[] { 7, 7 })]
        [TestCase(new int[0], new int[0])]
        public void ShouldExpandRunLength(int[] nums, int[] output)
        {
            CollectionAssert.AreEqual(output, selectMany.ExpandRunLength(nums));
        }

        // ------------------------------ Shuffle -------------------------------

        [TestCase(new[] { 2, 5, 1, 3, 4, 7 }, 3, new[] { 2, 3, 5, 4, 1, 7 })]
        [TestCase(new[] { 1, 2, 3, 4, 4, 3, 2, 1 }, 4, new[] { 1, 4, 2, 3, 3, 2, 4, 1 })]
        [TestCase(new[] { 1, 1, 2, 2 }, 2, new[] { 1, 2, 1, 2 })]
        [TestCase(new int[0], 0, new int[0])]
        public void ShouldShuffle(int[] nums, int n, int[] output)
        {
            CollectionAssert.AreEqual(output, selectMany.Shuffle(nums, n));
        }

        // -------------------------- GetDistinctWords --------------------------

        [Test]
        public void ShouldGetDistinctWordsLowerCaseAndSorted()
        {
            var sentences = new List<string> { "The cat", "the dog  ran", "A Cat" };

            CollectionAssert.AreEqual(
                new[] { "a", "cat", "dog", "ran", "the" },
                selectMany.GetDistinctWords(sentences));
        }

        [Test]
        public void ShouldGetOneWordWhenOnlyCaseChanges()
        {
            CollectionAssert.AreEqual(
                new[] { "hi" },
                selectMany.GetDistinctWords(new List<string> { "Hi hi HI" }));
        }

        [Test]
        public void ShouldGetNoWordsFromEmptyOrBlankSentences()
        {
            CollectionAssert.IsEmpty(selectMany.GetDistinctWords(new List<string> { "", "   " }));
            CollectionAssert.IsEmpty(selectMany.GetDistinctWords(new List<string>()));
        }

        // --------------------------- GetExcelCells ----------------------------

        [TestCase("K1:L2", new[] { "K1", "K2", "L1", "L2" })]
        [TestCase("A1:F1", new[] { "A1", "B1", "C1", "D1", "E1", "F1" })]
        [TestCase("C1:C3", new[] { "C1", "C2", "C3" })]
        [TestCase("B3:B3", new[] { "B3" })]
        public void ShouldGetExcelCells(string range, string[] output)
        {
            CollectionAssert.AreEqual(output, selectMany.GetExcelCells(range));
        }

        [Test]
        public void ShouldGetAllCellsOfTheBiggestSheet()
        {
            var cells = selectMany.GetExcelCells("A1:Z9");

            Assert.AreEqual(26 * 9, cells.Length);
            Assert.AreEqual("A1", cells[0]);
            Assert.AreEqual("Z9", cells[cells.Length - 1]);
        }

        // -------------------------- GetPairsWithSum ---------------------------

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, new[] { "1+4", "2+3" })]
        [TestCase(new[] { -1, 6, 0, 5 }, 5, new[] { "-1+6", "0+5" })]
        [TestCase(new[] { 2, 2, 2 }, 4, new[] { "2+2", "2+2", "2+2" })]
        [TestCase(new[] { 3 }, 6, new string[0])]
        [TestCase(new int[0], 1, new string[0])]
        public void ShouldGetPairsWithSum(int[] numbers, int target, string[] output)
        {
            CollectionAssert.AreEqual(output, selectMany.GetPairsWithSum(numbers, target));
        }

        // ---------------------- GetProductsBoughtInCity -----------------------

        private static List<Customer> Customers()
        {
            return new List<Customer>
            {
                new Customer("Ana", "Lima", new List<Order>
                {
                    new Order(1, "Ana", new List<string> { "Pen", "Book" }),
                    new Order(2, "Ana", new List<string> { "Pen" }),
                }),
                new Customer("Luis", "Quito", new List<Order>
                {
                    new Order(3, "Luis", new List<string> { "Cup" }),
                }),
                new Customer("Sofia", "Lima", new List<Order>
                {
                    new Order(4, "Sofia", new List<string> { "Lamp", "Book" }),
                    new Order(5, "Sofia", new List<string>()),
                }),
                new Customer("Juan", "Lima", new List<Order>()),
            };
        }

        [TestCase("Lima", new[] { "Book", "Lamp", "Pen" })]
        [TestCase("Quito", new[] { "Cup" })]
        [TestCase("Cusco", new string[0])]
        public void ShouldGetProductsBoughtInCity(string city, string[] output)
        {
            CollectionAssert.AreEqual(output, selectMany.GetProductsBoughtInCity(Customers(), city));
        }

        // --------------------------- GetOrderLines ----------------------------

        [Test]
        public void ShouldGetOrderLinesWithCustomerCityAndOrderId()
        {
            CollectionAssert.AreEqual(
                new[]
                {
                    "Ana (Lima) #1: Pen", "Ana (Lima) #1: Book", "Ana (Lima) #2: Pen",
                    "Luis (Quito) #3: Cup", "Sofia (Lima) #4: Lamp", "Sofia (Lima) #4: Book",
                },
                selectMany.GetOrderLines(Customers()));
        }

        [Test]
        public void ShouldGetNoOrderLinesForNoCustomers()
        {
            CollectionAssert.IsEmpty(selectMany.GetOrderLines(new List<Customer>()));
        }

        // ------------------------ GetStudentsByCourse -------------------------

        [Test]
        public void ShouldGetStudentsByCourseSortedWithoutRepeats()
        {
            var students = new List<Student>
            {
                new Student("Luis", new List<string> { "Math" }),
                new Student("Ana", new List<string> { "Math", "Art" }),
                new Student("Sofia", new List<string> { "Art", "Math", "Art" }),
                new Student("Juan", new List<string>()),
            };

            var result = selectMany.GetStudentsByCourse(students);

            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEqual(new[] { "Ana", "Luis", "Sofia" }, result["Math"]);
            CollectionAssert.AreEqual(new[] { "Ana", "Sofia" }, result["Art"]);
        }

        [Test]
        public void ShouldGetNoCoursesForNoStudents()
        {
            CollectionAssert.IsEmpty(selectMany.GetStudentsByCourse(new List<Student>()));
        }

        // ------------------- GetPeopleWithCountry (joins) ---------------------

        private static List<Person> People()
        {
            return new List<Person>
            {
                new Person("Ana", 20, "Lima"),
                new Person("Luis", 30, "Quito"),
                new Person("Juan", 25, "Paris"),
                new Person("Sofia", 12, "Lima"),
            };
        }

        private static List<City> Cities()
        {
            return new List<City>
            {
                new City("Lima", "Peru", true),
                new City("Quito", "Ecuador", true),
                new City("Cusco", "Peru", false),
            };
        }

        [Test]
        public void ShouldGetPeopleWithCountryLeavingOutUnknownCities()
        {
            CollectionAssert.AreEqual(
                new[] { "Ana - Peru", "Luis - Ecuador", "Sofia - Peru" },
                selectMany.GetPeopleWithCountry(People(), Cities()));
        }

        [Test]
        public void ShouldGetNobodyWhenThereAreNoCities()
        {
            CollectionAssert.IsEmpty(selectMany.GetPeopleWithCountry(People(), new List<City>()));
        }

        [Test]
        public void ShouldGetPeopleWithCountryOrUnknown()
        {
            CollectionAssert.AreEqual(
                new[] { "Ana - Peru", "Luis - Ecuador", "Juan - Unknown", "Sofia - Peru" },
                selectMany.GetPeopleWithCountryOrUnknown(People(), Cities()));
        }

        [Test]
        public void ShouldGetEveryoneUnknownWhenThereAreNoCities()
        {
            CollectionAssert.AreEqual(
                new[] { "Ana - Unknown", "Luis - Unknown", "Juan - Unknown", "Sofia - Unknown" },
                selectMany.GetPeopleWithCountryOrUnknown(People(), new List<City>()));
        }

        [Test]
        public void ShouldGetNoRowsWhenThereAreNoPeople()
        {
            CollectionAssert.IsEmpty(selectMany.GetPeopleWithCountryOrUnknown(new List<Person>(), Cities()));
        }
    }
}
