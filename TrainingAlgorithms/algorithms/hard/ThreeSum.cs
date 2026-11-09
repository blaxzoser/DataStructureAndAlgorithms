using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainingAlgorithms.algorithms.hard
{
    // ============================================================================
    // THREE SUM (LeetCode 15, counting version)
    // ============================================================================
    // Builds on 3 things you already practiced:
    //   - IsSumPairEqualToTarget (Samples/technics/basic/TwoPointers): on a SORTED
    //     array, sum too small -> left++, sum too big -> right--.
    //   - Palindrome.Sample2Refactor: the inner 'while' loops that SKIP items
    //     (there: symbols, here: repeated numbers) and "match -> move both".
    //   - ContainerWithMostWater: the sorted order tells you which side to move.
    // The new part: an outer 'for' loop that fixes the FIRST number, so the
    // two pointers only have to find the other two.
    //
    // Total practice time: ~1 hour
    // ============================================================================
    public class ThreeSum
    {
        // ========================================================================
        // SAMPLE 1: How many different triplets add up to 0?
        // ========================================================================
        // Count the triplets numbers[i] + numbers[j] + numbers[k] == 0 with
        // i, j, k different positions. Count each triplet of VALUES only once:
        // [-1, 0, 1] and [0, 1, -1] are the same triplet, and so are two
        // [-1, 0, 1] built from different -1s.
        //
        // { 1, 1, -2 }               -> 1   [1, 1, -2]
        // { 1, 12, -1, 5, 4 }        -> 0   only -1 is negative, and no pair adds to +1
        // { -1, 0, 1, 2, -1, -4 }    -> 2   [-1, -1, 2] and [-1, 0, 1]
        // { 0, 0, 0, 0 }             -> 1   [0, 0, 0] counted once
        // { -2, -2, 0, 0, 2, 2 }     -> 1   [-2, 0, 2] counted once
        // { 1, 2, 3 }                -> 0
        // { 0, 1 } or {} or null     -> 0   (fewer than 3 numbers)
        //
        //   sorted: [-4, -1, -1, 0, 1, 2]
        //   i=0 (-4): need 4 from the rest -> biggest pair 1 + 2 = 3, none
        //   i=1 (-1): need 1
        //             L=-1 R=2 -> sum 0 ✓ count=1, move both
        //             L=0  R=1 -> sum 0 ✓ count=2, move both, L > R stop
        //   i=2 (-1): same value as i=1 -> SKIP (or you count them twice)
        //   i=3 (0):  need 0 -> L=1 R=2 -> sum 3, too big, R-- -> L == R stop
        //   -> 2
        //
        // Difficulty: Hard
        // Goal: Time O(n²), Space O(1) extra (sort in place)
        // Expected time to solve: 60 min
        // Pattern: Sort + fix one + Two Pointers (opposite ends), move by the sum
        //          (IsSumPairEqualToTarget) + skip repeats (Sample2Refactor's
        //          inner whiles)
        // Topic: Arrays + Sorting + Two Pointers
        // ========================================================================
        public int CountTriplets(int[] numbers)
        {
            // FIX 1: guard. null or fewer than 3 numbers can never make a triplet.
            // (Before: '!numbers.Any()' crashed on null and let { 0, 1 } through.)
            if (numbers == null || numbers.Length < 3) return 0;

            var counter = 0;
            var sorted = numbers.OrderBy(x => x).ToList();
            var target = 0;
            var keepUnique = new HashSet<string>();

            // FIX 2: i stops at Count - 3. The last two positions can't be the
            // FIRST number because left and right need room after i.
            // (Before: i went to the end and sorted[left] threw IndexOutOfRange.)
            //
            // DEBUG SAMPLE for this line (breakpoint here, watch i / sorted.Count):
            //   input { -1, 0, 1, 2, -1, -4 } -> sorted [-4, -1, -1, 0, 1, 2]
            //   sorted.Count = 6, so the condition is i < 6 - 2 = i < 4
            //
            //   hit  i   i < 4 ?  first number (a)  left right   what happens
            //   1    0   true     -4                1    5       need b+c = 4, max is 1+2 = 3 -> none
            //   2    1   true     -1                2    5       finds [-1,-1,2] and [-1,0,1]
            //   3    2   true     -1                3    5       same triplets again -> HashSet rejects
            //   4    3   true      0                4    5       0+1+2 = 3 too big -> right-- -> stop
            //   5    4   FALSE    (loop ends)                    i=4 would give left=5, right=5
            //                                                   -> left < right is already false,
            //                                                   so nothing could ever match
            //
            //   Why stop at Count - 3 (last valid i = 3):
            //   i needs TWO numbers after it (left and right). From i = 3 there are exactly
            //   2 left (idx 4 and 5). i = 4 has only 1 left, i = 5 has 0.
            //
            //   Try it with the guard's edge: { 1, 1, -2 } -> Count = 3 -> i < 1
            //   -> only i = 0 runs: left=1, right=2 -> 1 + 1 + -2 = 0 -> count 1. Correct.
            for (int i = 0; i < sorted.Count - 2; i++)
            {
                var left = i + 1;
                var right = sorted.Count - 1;

                while (left < right)
                {
                    int totalSum = sorted[i] + sorted[left] + sorted[right];

                    if (totalSum == target)
                    {
                        // FIX 3: ONE key, built in ONE place, with separators.
                        // (Before: lookup used "a, b,c" but Add stored "abc", so the
                        // set never matched. Without separators "1","12" and "11","2"
                        // would also collide.)
                        var key = $"{sorted[i]},{sorted[left]},{sorted[right]}";

                        // HashSet.Add returns false when the key already exists,
                        // so this is "count it only if it is new".
                        // FIX 4: the duplicate check lives HERE, right before counting.
                        // (Before: the Contains checks at the top of the for/while looked
                        // at triplets that had not been tested yet, so they did nothing.)
                        if (keepUnique.Add(key))
                            counter++;

                        // Match: move BOTH. Moving only one can't give sum 0 again.
                        left++;
                        right--;
                    }
                    else if (totalSum < target)
                    {
                        left++;   // too small -> need a bigger number
                    }
                    else
                    {
                        right--;  // too big -> need a smaller number
                    }
                }
            }

            return counter;
        }

        // ========================================================================
        // HOW TO SIMULATE A DEBUG SESSION BY HAND (do this on paper or with F9/F10)
        // ========================================================================
        // Put a breakpoint on the line 'int totalSum = ...' and watch 5 values:
        //   i, left, right, totalSum, counter   (and keepUnique in the Watch window)
        // Each time the breakpoint hits, that is ONE row of the table below.
        // After each row, ask: "which pointer moves, and why?"
        //
        // Input { -2, -2, 0, 0, 2, 2 }   expected 1
        // sorted: idx  0   1   2  3  4  5
        //             -2  -2   0  0  2  2
        //
        //  i  left right  sum  action                          counter keepUnique
        //  0   1     5    -2   < 0  -> left++                    0     {}
        //  0   2     5     0   == 0 -> key "-2,0,2" is NEW,      1     {"-2,0,2"}
        //                           count, left++ right--
        //  0   3     4     0   == 0 -> key "-2,0,2" ALREADY      1     (unchanged)
        //                           there, do NOT count
        //                           left++ right--
        //  0   4     3     -   left > right -> while ends
        //  1   2     5     0   same triplet again (i=1 is also -2) -> already in set,
        //                           not counted. This is the 2nd '-2' being "skipped"
        //                           by the HashSet instead of by a neighbour compare.
        //  ... the rest finds nothing new                          1
        //
        // Without FIX 3 (key mismatch) the set never matches, so the table would
        // show counter going 1,2,3,4 -> that is how you SEE the bug in the Watch window.
        //
        // Input { 0, 0, 0, 0 }   expected 1
        //  i=0 left=1 right=3 sum 0 -> new "0,0,0" counter=1, left=2 right=2 -> stop
        //  i=1 left=2 right=3 sum 0 -> "0,0,0" already in set -> counter stays 1
        //  i=2 is not visited: the for stops at Count - 3 (FIX 2)
        //
        // Input { 0, 1 }  -> guard returns 0 before anything else (FIX 1)
        //
        // Debug habit: when a loop never ends, check that EVERY branch changes
        // left or right. If one branch doesn't (an old 'counter++' alone, or a
        // 'continue' before the pointer moved) the same row repeats forever.

        // ========================================================================
        // REFERENCE SOLUTION (Sample1Refactor): no HashSet, O(1) extra space.
        // Duplicates are skipped by comparing NEIGHBOURS, because sorted equal
        // values sit next to each other (same idea as Palindrome.Sample2Refactor).
        // ========================================================================
        public int Sample1Refactor(int[] numbers)
        {
            if (numbers == null || numbers.Length < 3) return 0;

            var sorted = numbers.OrderBy(x => x).ToArray();
            var counter = 0;

            for (int i = 0; i < sorted.Length - 2; i++)
            {
                // Same first number as the previous i -> its triplets were already counted.
                //
                // DEBUG SAMPLE for the next line (breakpoint here, watch i / sorted[i] / sorted[i-1]):
                //   input { -1, 0, 1, 2, -1, -4 } -> sorted [-4, -1, -1, 0, 1, 2]
                //                                    idx      0   1   2  3  4  5
                //
                //   hit  i   i > 0 ?  sorted[i]  sorted[i-1]  equal?  result
                //   1    0   false    -4         (not read)    -       && short-circuits, so
                //                                                      sorted[-1] is never read
                //                                                      (no crash) -> go on
                //   2    1   true     -1         -4            no      go on: finds
                //                                                      [-1,-1,2] and [-1,0,1]
                //   3    2   true     -1         -1            YES     continue -> skip the whole
                //                                                      while for this i
                //   4    3   true      0         -1            no      go on: 0+1+2 = 3, nothing
                //
                //   WHY skip i = 2: it is the second -1. Its pairs are a subset of what i = 1
                //   already saw (i = 1 even used the -1 at idx 2 as 'left'). Running it again
                //   would count [-1,0,1] a second time -> counter 3 instead of 2.
                //
                //   WHY compare with i - 1 and NOT i + 1: we want the FIRST of a run of equal
                //   values to do the work. Comparing with i + 1 would skip the first -1 and keep
                //   the last one, which has fewer numbers after it and would MISS [-1,-1,2]
                //   (needs the other -1 as 'left').
                //
                //   Run of 3 equal: { -1, -1, -1, 2, 0 } -> sorted [-1, -1, -1, 0, 2]
                //     i=0: left=1 right=4 -> -1 + -1 + 2 = 0 -> counter=1   (uses two -1s)
                //     i=1: sorted[1] == sorted[0] -> skip
                //     i=2: sorted[2] == sorted[1] -> skip
                //     i=3 never runs: Count = 5, so the for stops at i < 3
                //     -> 1. Correct.
                if (i > 0 && sorted[i] == sorted[i - 1]) continue;

                var left = i + 1;
                var right = sorted.Length - 1;

                while (left < right)
                {
                    var sum = sorted[i] + sorted[left] + sorted[right];

                    if (sum == 0)
                    {
                        counter++;
                        left++;
                        right--;

                        // Skip repeats of the pair we just used.
                        //
                        // DEBUG SAMPLE for the next 2 lines (breakpoint on each, watch left / right):
                        //   input { -2, -2, 0, 0, 2, 2 } -> sorted [-2, -2, 0, 0, 2, 2]
                        //                                   idx       0   1  2  3  4  5
                        //   i = 0 (a = -2). Earlier, left=2 right=5 matched: -2 + 0 + 2 = 0
                        //   Just ran: counter++ (=1), left++ -> 3, right-- -> 4
                        //
                        //   WHY the skip is needed: now left=3 (0) and right=4 (2) would match
                        //   AGAIN: -2 + 0 + 2 = 0 -> counter 2. That is the SAME triplet of
                        //   values, built from the second 0 and the second 2. Wrong.
                        //
                        //   line 203: sorted[left] == sorted[left - 1] ?
                        //     left=3: sorted[3]=0 vs sorted[2]=0 -> equal   -> left++ -> 4
                        //     left=4: left < right? 4 < 4 is false -> stop (also the "&&" guard
                        //             protects us from reading past right)
                        //   line 204: sorted[right] == sorted[right + 1] ?
                        //     right=4: left < right? 4 < 4 is false -> not evaluated, stop
                        //   Back in 'while (left < right)': 4 < 4 is false -> exits, i = 1 comes next
                        //
                        //   Compare to what sits on the OTHER side of the pointer:
                        //     line 203 looks BACK (left - 1): "is the number I just left behind the same?"
                        //     line 204 looks FORWARD (right + 1): "is the number I just left behind the same?"
                        //   Both ask the same question: "is my new position the same value as the
                        //   one I just used?" left moved right, so "behind" is left-1;
                        //   right moved left, so "behind" is right+1.
                        //
                        //   Second sample where BOTH lines skip: { -4, 0, 0, 2, 4, 4 }
                        //   sorted idx 0..5 = -4, 0, 0, 2, 4, 4   i=0 (a=-4)
                        //     left=1 right=5: -4 + 0 + 4 = 0 -> counter=1, left=2, right=4
                        //     line 203: left=2, sorted[2]=0 == sorted[1]=0 -> left++ -> 3
                        //               left=3, sorted[3]=2 != sorted[2]=0 -> stop
                        //     line 204: right=4, sorted[4]=4 == sorted[5]=4 -> right-- -> 3
                        //               left < right? 3 < 3 false -> stop
                        //     while ends. Total 1. Without these lines: left=2 right=4 ->
                        //     -4 + 0 + 4 = 0 -> counter=2 (WRONG, same triplet).
                        while (left < right && sorted[left] == sorted[left - 1]) left++;
                        while (left < right && sorted[right] == sorted[right + 1]) right--;
                    }
                    else if (sum < 0) left++;
                    else right--;
                }
            }

            return counter;
        }
    }
}
