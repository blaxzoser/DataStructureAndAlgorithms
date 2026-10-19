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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
        // Tip:   orders.SelectMany(o => o.Products, (order, product) => ...)
        //        The second lambda receives BOTH the parent (order) and the
        //        child (product), so you don't lose who bought what.
        // ========================================================================
        public List<string> GetCustomerProducts(List<Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}
