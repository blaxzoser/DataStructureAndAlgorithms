using System;
using System.Collections.Generic;

namespace TrainingAlgorithms.algorithms.medium
{
    // ============================================================================
    // MAXIMUM SUM OF DISTINCT SUBARRAYS WITH LENGTH K (LeetCode 2461)
    // ============================================================================
    // Third round of the sliding window. SAME as MaximumUniqueSubarraySum.MaxSum
    // (HashSet + running sum + shrink while), but now the window has a FIXED size k.
    //
    //   MaximumUniqueSubarraySum              ->  this exercise
    //   ---------------------------------         ----------------------------
    //   window can be any size                ->  window must be EXACTLY k long
    //   shrink only on a repeat               ->  shrink on a repeat OR when full
    //   best = max(best, sum) every step      ->  only when size == k
    //
    // Total practice time: ~15-20 min
    // ============================================================================
    public class MaximumSumDistinctSubarrayOfLengthK
    {
        // ========================================================================
        // SAMPLE 1: Biggest sum of a piece of length k with all different numbers
        // ========================================================================
        // A subarray is a CONTINUOUS piece of the array (no gaps).
        // All numbers are positive. The piece must be EXACTLY k long and all its
        // numbers different. Return its biggest SUM, or 0 if there is none.
        //
        // [1,5,4,2,9,9,9], k=3  -> 15  (4+2+9; [5,4,2]=11 is smaller)
        // [4,4,4], k=3          -> 0   (no piece of 3 different numbers)
        // [1,2,1,3,4], k=3      -> 8   ([1,2,1] has a repeat; [2,1,3]=6, [1,3,4]=8)
        // [9,9,1,2,3], k=2      -> 10  (9+1, found right AFTER a repeat)
        // [1,1,1,7,8,9], k=3    -> 24  (7+8+9 at the END)
        // [3,1,2], k=1          -> 3   (k=1: just the biggest number)
        // [1,2,3,4], k=4        -> 10  (the whole array)
        // [1,2], k=3            -> 0   (k bigger than the array)
        // [] or null            -> 0
        //
        //   [1,2,1,3,4], k=3      window = [left .. right], all different, size <= k
        //    [1]2 1 3 4           sum 1   size 1
        //    [1 2]1 3 4           sum 3   size 2
        //     1[2 1]3 4           2nd 1 repeats -> drop 1 (sum 2), add 1 (sum 3)
        //     1[2 1 3]4           sum 6   size 3 == k -> best 6
        //     1 2[1 3 4]          window FULL -> drop 2 (sum 4), add 4 (sum 8) -> best 8
        //
        // Difficulty: Medium
        // Goal: Time O(n), Space O(k)
        // Expected time to solve: 15-20 min
        // Pattern: Sliding window + Seen set + running sum (MaximumUniqueSubarraySum)
        // Topic: Arrays + Hashing + Sliding window (fixed size)
        // Tip 1: Write MaxSum from memory first (for right, while Contains, Add,
        //        sum +=). The shrink loop ALWAYS works on numbers[left]:
        //        Remove(numbers[left]), sum -= numbers[left], left++.
        // Tip 2: Add one more reason to shrink: the window is already full
        //        (right - left == k, BEFORE adding numbers[right]). So the while is:
        //        while (memory.Contains(numbers[right]) || right - left == k).
        //        Then update best ONLY if right - left + 1 == k.
        // ========================================================================
        public int MaxSum(int[] numbers, int k)
        {
            throw new NotImplementedException();
        }
    }
}
