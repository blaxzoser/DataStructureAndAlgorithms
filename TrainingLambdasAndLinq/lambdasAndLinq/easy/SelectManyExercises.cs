using System;
using System.Collections.Generic;
using System.Linq;
using TrainingLambdasAndLinq.POCOS;

namespace TrainingLambdasAndLinq.lambdasAndLinq.easy
{
    // ============================================================================
    // SELECTMANY (flattening)
    // ============================================================================
    // Select    -> one element IN, one element OUT  (you can end up with a
    //              collection of collections: [[1,2],[3]])
    // SelectMany -> one element IN, MANY elements OUT, and all of them are
    //               joined into ONE flat collection: [1, 2, 3]
    //
    //   [[1, 2], [3], [4, 5]].SelectMany(inner => inner) -> [1, 2, 3, 4, 5]
    //
    // Total practice time: ~45 min
    // ============================================================================
    public class SelectManyExercises
    {
        // ========================================================================
        // SAMPLE 1: Flatten a jagged array
        // ========================================================================
        // [[1, 2], [3], [4, 5, 6]] -> [1, 2, 3, 4, 5, 6]
        // [[], [7], []]            -> [7]
        //
        // Expected time to solve: 5 min
        // Topic: SelectMany with the identity lambda
        // Tip:   Each element is already an int[], so the lambda just returns
        //        it: row => row
        // ========================================================================
        public int[] Flatten(int[][] matrix)
        {
            return  matrix.SelectMany(x => x).ToArray();
        }

        // ========================================================================
        // SAMPLE 2: All characters of all words
        // ========================================================================
        // ["hi", "yo"]  -> ['h', 'i', 'y', 'o']
        // ["", "abc"]   -> ['a', 'b', 'c']
        //
        // Expected time to solve: 5 min
        // Topic: SelectMany over strings
        // Tip:   A string IS an IEnumerable<char>, so word => word works.
        // ========================================================================
        public char[] GetAllCharacters(string[] words)
        {
          return words.SelectMany(words => words).ToArray();
        }

        // ========================================================================
        // SAMPLE 3: All courses of all students, no duplicates, sorted A-Z
        // ========================================================================
        // Ana   -> ["Math", "Art"]
        // Luis  -> ["Math", "History"]
        // Sofia -> ["Biology"]
        //   -> ["Art", "Biology", "History", "Math"]
        //
        // Expected time to solve: 10 min
        // Topic: SelectMany over a property + Distinct + OrderBy
        // Tip:   First try students.Select(s => s.Courses) and look at the
        //        type you get (List<List<string>>-ish). Then change it to
        //        SelectMany and see the difference.
        // ========================================================================
        public List<string> GetAllCourses(List<Student> students)
        {
            return students.SelectMany(s=> s.Courses).Distinct().OrderBy(c=> c).ToList();
        }

        // ========================================================================
        // SAMPLE 4: Every combination of two lists (cross join)
        // ========================================================================
        // ([1, 2], ["a", "b"]) -> ["1a", "1b", "2a", "2b"]
        // ([1], [])            -> []
        //
        // Expected time to solve: 10 min
        // Topic: SelectMany + nested Select (it replaces a double foreach)
        // Tip:   numbers.SelectMany(n => letters.Select(l => ...))
        //        For each n you produce MANY strings, SelectMany joins them.
        // ========================================================================
        public string[] GetAllPairs(int[] numbers, string[] letters)
        {
            return numbers.SelectMany(n => letters.Select(l => n.ToString() + l)).ToArray();
        }

        // ========================================================================
        // SAMPLE 5: SelectMany with result selector (keep the parent data)
        // ========================================================================
        // For each product of each order, build "Customer:Product".
        // Order 1 Ana  -> ["Pen", "Book"]
        // Order 2 Luis -> ["Cup"]
        //   -> ["Ana:Pen", "Ana:Book", "Luis:Cup"]
        //
        // Expected time to solve: 15 min
        // Topic: SelectMany overload (collectionSelector, resultSelector)
        // ========================================================================
        public List<string> GetCustomerProducts(List<Order> orders)
        {
            return orders.SelectMany(o => o.Products, (order, product) =>  order.Customer + ":" + product).ToList();
        }

        // ============================================================================
        // ROUND 2: SelectMany with List<T> + common interview questions (Samples 6-15)
        // ============================================================================
        // Round 1 flattened one level. This round:
        //   - SelectMany over indexes (Enumerable.Range)  -> Samples 6, 7, 9, 10
        //     (LeetCode 1313, 1470, 2194 + the classic "all pairs with sum")
        //   - SelectMany over words of sentences          -> Sample 8
        //   - TWO levels of lists: List<Customer> -> List<Order> -> List<string>
        //                                                 -> Samples 11, 12
        //   - Turn a many-to-many around (student -> courses  becomes
        //     course -> students)                         -> Sample 13
        //   - SelectMany as a JOIN between two List<T> (inner and left join)
        //                                                 -> Samples 14, 15
        //
        // Rules: max 15 min each, say the Time / Space out loud when you finish.
        //
        // Total practice time: ~150 min
        // ============================================================================

        // ========================================================================
        // SAMPLE 6: Decompress a run-length encoded list (LeetCode 1313)
        // ========================================================================
        // nums is made of pairs [freq, val]. Each pair means "val, freq times".
        // Join the pieces, in order.
        // [1, 2, 3, 4]  -> [2, 4, 4, 4]      (one 2, then three 4)
        // [1, 1, 2, 3]  -> [1, 3, 3]
        // [0, 5, 2, 7]  -> [7, 7]            (freq 0 adds nothing)
        // []            -> []
        //
        // Difficulty: Easy
        // Goal: Time O(n + output), Space O(output)
        // Expected time to solve: 15 min
        // Pattern: Flatten (Sample 1): every pair becomes a small collection
        // Topic:   SelectMany over INDEXES (Enumerable.Range) + Enumerable.Repeat
        // Interview follow-up: write it with a for loop + List<int>. Which one
        //          would you pick in production, and why?
        // ========================================================================
        public int[] ExpandRunLength(int[] nums)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 7: Shuffle the array (LeetCode 1470)
        // ========================================================================
        // nums = [x1, x2, ..., xn, y1, y2, ..., yn]  (length 2n)
        // Return  [x1, y1, x2, y2, ..., xn, yn]
        // ([2, 5, 1, 3, 4, 7], 3)        -> [2, 3, 5, 4, 1, 7]
        // ([1, 2, 3, 4, 4, 3, 2, 1], 4)  -> [1, 4, 2, 3, 3, 2, 4, 1]
        // ([1, 1, 2, 2], 2)              -> [1, 2, 1, 2]
        // ([], 0)                        -> []
        //
        // Difficulty: Easy
        // Goal: Time O(n), Space O(n)
        // Expected time to solve: 15 min
        // Pattern: ExpandRunLength (Sample 6): one index IN, a few values OUT
        // Topic:   SelectMany over indexes, returning a small array per index
        // Interview follow-up: what changes if the two halves can have
        //          different lengths? (hint: Zip stops at the shorter one)
        // ========================================================================
        public int[] Shuffle(int[] nums, int n)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 8: All different words of many sentences
        // ========================================================================
        // Words are separated by one OR MORE spaces. Ignore case (return them
        // in lower case), no duplicates, sorted A-Z.
        // ["The cat", "the dog  ran", "A Cat"] -> ["a", "cat", "dog", "ran", "the"]
        // ["Hi hi HI"]                         -> ["hi"]
        // ["", "   "]                          -> []
        // []                                   -> []
        //
        // Note: the library is netstandard2.0: Split(' ', options) does NOT
        //       exist there, only Split(new[] { ' ' }, options).
        //
        // Difficulty: Easy-Medium
        // Goal: Time O(c + w log w) (c = characters, w = different words), Space O(c)
        // Expected time to solve: 15 min
        // Pattern: GetAllCourses (Sample 3), but the inner list comes from Split
        // Topic:   SelectMany + Split + Select + Distinct + OrderBy
        // Interview follow-up: where do you put the ToLowerInvariant: before
        //          Split, or after it on every word? Does it matter?
        // ========================================================================
        public List<string> GetDistinctWords(List<string> sentences)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 9: Cells in a range on an Excel sheet (LeetCode 2194)
        // ========================================================================
        // range = "<col1><row1>:<col2><row2>", columns 'A'-'Z', rows 1-9,
        // col1 <= col2 and row1 <= row2.
        // Return every cell of the rectangle, by column first, then by row.
        // "K1:L2" -> ["K1", "K2", "L1", "L2"]
        // "A1:F1" -> ["A1", "B1", "C1", "D1", "E1", "F1"]
        // "C1:C3" -> ["C1", "C2", "C3"]
        // "B3:B3" -> ["B3"]
        //
        // Difficulty: Easy-Medium
        // Goal: Time O(cells), Space O(cells)
        // Expected time to solve: 15 min
        // Pattern: GetAllPairs (Sample 4): a cross join, columns x rows
        // Topic:   SelectMany + nested Select over two Enumerable.Range;
        //          a char is a number ('L' - 'K' == 1)
        // Interview follow-up: how many cells does "A1:Z9" return, without
        //          running it?
        // ========================================================================
        public string[] GetExcelCells(string range)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 10: All pairs that add up to a target
        // ========================================================================
        // Return every pair numbers[i] + numbers[j] == target with i < j,
        // as "a+b", ordered by i, then by j. A number can't pair with itself
        // (same index), but two EQUAL numbers at different indexes can.
        // ([1, 2, 3, 4, 5], 5)  -> ["1+4", "2+3"]
        // ([-1, 6, 0, 5], 5)    -> ["-1+6", "0+5"]
        // ([2, 2, 2], 4)        -> ["2+2", "2+2", "2+2"]   (indexes 0-1, 0-2, 1-2)
        // ([3], 6)              -> []
        // ([], 1)               -> []
        //
        // Difficulty: Medium
        // Goal: Time O(n^2), Space O(pairs)
        // Expected time to solve: 15 min
        // Pattern: UniqueCharacters.IsUniqueNoExtraSpace (j starts at i + 1)
        //          + GetAllPairs (Sample 4)
        // Topic:   SelectMany over indexes + Where on the pair
        // Interview follow-up: "Two Sum" only needs ONE pair. How do you get it
        //          in O(n) with a HashSet / Dictionary?
        // ========================================================================
        public List<string> GetPairsWithSum(int[] numbers, int target)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 11: Products bought by the customers of one city (two levels)
        // ========================================================================
        // Customer -> List<Order> -> List<string> Products.
        // No duplicates, sorted A-Z.
        // Ana   Lima  -> #1 [Pen, Book], #2 [Pen]
        // Luis  Quito -> #3 [Cup]
        // Sofia Lima  -> #4 [Lamp, Book], #5 []
        // Juan  Lima  -> (no orders)
        //   "Lima"  -> ["Book", "Lamp", "Pen"]
        //   "Quito" -> ["Cup"]
        //   "Cusco" -> []
        //
        // Difficulty: Medium
        // Goal: Time O(total products + d log d) (d = different products), Space O(d)
        // Expected time to solve: 15 min
        // Pattern: GetAllCourses (Sample 3), one level deeper
        // Topic:   Where + SelectMany + SelectMany (two levels of List<T>)
        // Interview follow-up: can you write it with ONE SelectMany? (hint:
        //          what can go inside the lambda?)
        // ========================================================================
        public List<string> GetProductsBoughtInCity(List<Customer> customers, string city)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 12: Order lines that keep the customer AND the order
        // ========================================================================
        // One line per product: "<Customer name> (<City>) #<Order Id>: <Product>"
        // Keep the original order (customers, then orders, then products).
        // The city only exists on the Customer, the Id only on the Order.
        // Same data as Sample 11:
        //   -> ["Ana (Lima) #1: Pen",   "Ana (Lima) #1: Book", "Ana (Lima) #2: Pen",
        //       "Luis (Quito) #3: Cup", "Sofia (Lima) #4: Lamp", "Sofia (Lima) #4: Book"]
        //   (Sofia's empty order #5 and Juan add nothing)
        //
        // Difficulty: Medium
        // Goal: Time O(total products), Space O(total products)
        // Expected time to solve: 15 min
        // Pattern: GetCustomerProducts (Sample 5) + GetProductsBoughtInCity (Sample 11)
        // Topic:   SelectMany INSIDE a SelectMany: the inner lambda can still
        //          see the outer variable (closure)
        // Interview follow-up: write it in query syntax:
        //          from c in customers from o in c.Orders from p in o.Products select ...
        //          The compiler turns each extra "from" into a SelectMany.
        // ========================================================================
        public List<string> GetOrderLines(List<Customer> customers)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 13: Turn it around: course -> students
        // ========================================================================
        // Each student has a list of courses. Build the opposite:
        // for each course, the NAMES of its students, sorted A-Z, no repeats
        // (a student who wrote the same course twice appears once).
        // Luis  -> [Math]
        // Ana   -> [Math, Art]
        // Sofia -> [Art, Math, Art]
        // Juan  -> []
        //   -> { "Math": ["Ana", "Luis", "Sofia"], "Art": ["Ana", "Sofia"] }
        // []  -> {}
        //
        // Difficulty: Medium
        // Goal: Time O(total courses + s log s per course), Space O(total courses)
        // Expected time to solve: 15 min
        // Pattern: GetCustomerProducts (Sample 5) + GroupByExercises.GroupNamesByCity (Sample 3)
        // Topic:   SelectMany with a result selector (keep the student) -> GroupBy
        //          -> ToDictionary (a many-to-many turned around)
        // Interview follow-up: in GroupBy Sample 16 you only COUNTED students per
        //          course. Why do you need the result selector here and not there?
        // ========================================================================
        public Dictionary<string, List<string>> GetStudentsByCourse(List<Student> students)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 14: People with their country (SelectMany as an INNER JOIN)
        // ========================================================================
        // Match each person with the City that has the same name and return
        // "<Name> - <Country>", in the order of people. A person whose city is
        // NOT in the cities list is left out (SQL: INNER JOIN).
        // Solve it with SelectMany (or two "from" in query syntax), NOT .Join().
        // people: Ana Lima, Luis Quito, Juan Paris, Sofia Lima
        // cities: Lima Peru, Quito Ecuador, Cusco Peru
        //   -> ["Ana - Peru", "Luis - Ecuador", "Sofia - Peru"]   (no Paris: Juan out)
        // (people, [])  -> []
        //
        // Difficulty: Medium
        // Goal: Time O(p * c), Space O(p)
        // Expected time to solve: 15 min
        // Pattern: ContainsExercises.GetPeopleInCapitals (a 2nd list in the lambda)
        //          + GetPairsWithSum (Sample 10): every pair, then a Where
        // Topic:   SelectMany as a JOIN between two List<T>
        // Interview follow-up: .Join() does the same in O(p + c). How? (hint:
        //          what does it build from the cities first?)
        // ========================================================================
        public List<string> GetPeopleWithCountry(List<Person> people, List<City> cities)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 15: People with their country or "Unknown" (LEFT JOIN)
        // ========================================================================
        // Same as Sample 14, but NOBODY is left out: if the city is not in the
        // list, the country is "Unknown" (SQL: LEFT JOIN).
        // people: Ana Lima, Luis Quito, Juan Paris, Sofia Lima
        // cities: Lima Peru, Quito Ecuador, Cusco Peru
        //   -> ["Ana - Peru", "Luis - Ecuador", "Juan - Unknown", "Sofia - Peru"]
        // (people, [])  -> everyone "Unknown"
        // ([], cities)  -> []
        //
        // Difficulty: Medium
        // Goal: Time O(p * c), Space O(p)
        // Expected time to solve: 15 min
        // Pattern: GetPeopleWithCountry (Sample 14), one change
        // Topic:   SelectMany + DefaultIfEmpty = LEFT JOIN in LINQ
        //          (one of the most asked LINQ interview questions)
        // Interview follow-up: what does DefaultIfEmpty() return for an empty
        //          List<City>, and why does the result selector then need "?."?
        // ========================================================================
        public List<string> GetPeopleWithCountryOrUnknown(List<Person> people, List<City> cities)
        {
            throw new NotImplementedException();
        }
    }
}
