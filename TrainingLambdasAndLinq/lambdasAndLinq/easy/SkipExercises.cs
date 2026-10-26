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
            return numbers.Skip(count).ToArray();
        }

        // ========================================================================
        // SAMPLE 2: Pagination (pages start at 1)
        // ========================================================================
        // Think of a search results page or an online shop: you can't show
        // all items at once, so you split them into PAGES of 'pageSize' items
        // and return only the page the user asked for.
        //
        // Return the items of page number 'pageNumber'.
        //   - Every page has 'pageSize' items, in the original order.
        //   - Page numbers start at 1 (page 1 = the first page).
        //   - The last page can have fewer items.
        //   - A page after the last one is empty: [].
        //
        // EXAMPLE: items = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10], pageSize = 3
        //
        //   items:  1  2  3 | 4  5  6 | 7  8  9 | 10
        //           page 1  | page 2  | page 3  | page 4
        //
        //   call                     | result       | why
        //   -------------------------+--------------+--------------------------
        //   GetPage(items, 1, 3)     | [1, 2, 3]    | first 3 items
        //   GetPage(items, 2, 3)     | [4, 5, 6]    | next 3
        //   GetPage(items, 3, 3)     | [7, 8, 9]    | next 3
        //   GetPage(items, 4, 3)     | [10]         | only 1 left (shorter page)
        //   GetPage(items, 5, 3)     | []           | no items left
        //
        // Expected time to solve: 10 min
        // Topic: Skip + Take together
        // Tip 1: Do it in 2 moves: Skip the items of all the pages BEFORE
        //        this one, then Take one page.
        // Tip 2: Fill in this table, then turn the "skip" column into a
        //        formula using pageNumber and pageSize:
        //
        //          page | pages before it | items to skip | items to take
        //          -----+-----------------+---------------+--------------
        //           1   |       0         |       0       |      3
        //           2   |       1         |       3       |      3
        //           3   |       ?         |       ?       |      3
        //           4   |       ?         |       ?       |      3 (only 1 left: Take is fine with that)
        //
        //        Careful: pages start at 1, but page 1 skips NOTHING.
        // ========================================================================
        public int[] GetPage(int[] items, int pageNumber, int pageSize)
        {
           return  items.Skip(pageSize * (pageNumber -1) ).Take(pageSize).ToArray();
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
            return numbers.Skip(numbers.Length - n).Take(n).ToArray();
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
            return digits.SkipWhile(x => x == 0).ToArray();
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
             return numbers.TakeWhile(x => x >= 0).ToArray();
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
            if (items.Length == 0)
                return items ;

            if(items.Length == 1)
                return items.Skip(1).ToArray();

            return items.Skip(1).Take(items.Length-2).ToArray();
        }
    }
}
