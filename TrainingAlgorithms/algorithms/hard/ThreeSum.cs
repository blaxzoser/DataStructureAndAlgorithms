using System;

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
        // Tip 1: Array.Sort(numbers) first. Then for each i: left = i + 1,
        //        right = end. sum < 0 -> left++, sum > 0 -> right--,
        //        sum == 0 -> count++, then move BOTH pointers.
        // Tip 2: Repeats are skipped in 2 places:
        //        - the fixed number: if (i > 0 && numbers[i] == numbers[i - 1]) continue;
        //        - after a match: while (left < right && numbers[left] == numbers[left - 1]) left++;
        //          (and the same idea for right, comparing with right + 1)
        // ========================================================================
        public int CountTriplets(int[] numbers)
        {
            throw new NotImplementedException();
        }
    }
}
