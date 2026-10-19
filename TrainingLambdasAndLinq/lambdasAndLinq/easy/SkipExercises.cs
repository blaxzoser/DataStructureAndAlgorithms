using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainingLambdasAndLinq.lambdasAndLinq.easy
{
    // ============================================================================
    // SKIP / TAKE / SKIPWHILE / TAKEWHILE (taking a slice)
    // ============================================================================
    // Skip(n)            -> ignore the first n elements, keep the rest.
    // Take(n)            -> keep only the first n elements.
    // SkipWhile(pred)    -> ignore elements WHILE pred is true, then keep
    //                       EVERYTHING after (it never checks pred again).
    // TakeWhile(pred)    -> keep elements WHILE pred is true, then STOP.
    //
    // None of them throw when n is bigger than the collection:
    //   [1, 2].Skip(5) -> []      [1, 2].Take(5) -> [1, 2]
    //
    // Interview classic: pagination = Skip((page - 1) * size).Take(size)
    //
    // Total practice time: ~40 min
    // ============================================================================
    public class SkipExercises
    {
        // ========================================================================
        // SAMPLE 1: Skip the first n numbers
        // ========================================================================
        // ([1, 2, 3, 4, 5], 2) -> [3, 4, 5]
        // ([1, 2], 5)          -> []
        // ([1, 2], 0)          -> [1, 2]
        //
        // Expected time to solve: 3 min
        // Topic: Skip
        // ========================================================================
        public int[] SkipFirst(int[] numbers, int count)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 2: Pagination (pages start at 1)
        // ========================================================================
        // items = [1..10], pageSize = 3
        //   page 1 -> [1, 2, 3]
        //   page 2 -> [4, 5, 6]
        //   page 4 -> [10]          (last page can be shorter)
        //   page 5 -> []            (past the end)
        //
        // Expected time to solve: 10 min
        // Topic: Skip + Take together
        // Tip:   How many items come BEFORE page 'pageNumber'? That is how
        //        many you skip. Watch out: pages start at 1, not 0.
        // ========================================================================
        public int[] GetPage(int[] items, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 3: The last n elements
        // ========================================================================
        // ([1, 2, 3, 4, 5], 2) -> [4, 5]
        // ([1, 2], 5)          -> [1, 2]
        // ([1, 2], 0)          -> []
        //
        // Expected time to solve: 5 min
        // Topic: Skip with a computed count
        // Tip:   There is no TakeLast in netstandard2.0 (this project), so use
        //        Skip. How many do you skip to keep only the last n?
        //        Math.Max(0, ...) helps when n is bigger than the array.
        // ========================================================================
        public int[] GetLastN(int[] numbers, int n)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 4: Remove leading zeros
        // ========================================================================
        // [0, 0, 1, 0, 2] -> [1, 0, 2]   (the zero in the middle STAYS)
        // [0, 0]          -> []
        // [5, 0]          -> [5, 0]
        //
        // Expected time to solve: 5 min
        // Topic: SkipWhile vs Where
        // Tip:   Try Where(n => n != 0) first and see which test fails.
        //        That shows the difference: Where checks every element,
        //        SkipWhile stops checking after the first 'false'.
        // ========================================================================
        public int[] RemoveLeadingZeros(int[] digits)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 5: Numbers before the first negative
        // ========================================================================
        // [3, 5, -1, 7, 8] -> [3, 5]
        // [-1, 2]          -> []
        // [1, 2, 3]        -> [1, 2, 3]
        //
        // Expected time to solve: 5 min
        // Topic: TakeWhile
        // Tip:   Same trap as Sample 4: Where(n => n >= 0) would also keep
        //        7 and 8. TakeWhile stops at -1 and never looks again.
        // ========================================================================
        public int[] TakeUntilNegative(int[] numbers)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 6: Remove the first and the last element
        // ========================================================================
        // ["<", "a", "b", ">"] -> ["a", "b"]
        // ["x", "y"]           -> []
        // ["x"]                -> []
        // []                   -> []
        //
        // Expected time to solve: 10 min
        // Topic: Skip + Take with a computed count
        // Tip:   Skip(1) removes the first. To remove the last, Take one less
        //        than what is left. Check what Take does with a negative number.
        // ========================================================================
        public string[] RemoveFirstAndLast(string[] items)
        {
            throw new NotImplementedException();
        }
    }
}
