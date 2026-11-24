using System;
using System.Collections.Generic;

namespace TrainingAlgorithms.algorithms.medium
{
    // ============================================================================
    // MAXIMUM UNIQUE SUBARRAY SUM (LeetCode 1695, "Maximum Erasure Value")
    // ============================================================================
    // Second round of LongestSubstringWithoutRepeating. SAME sliding window,
    // SAME HashSet, SAME shrink loop. Only 2 things change:
    //
    //   LongestSubstringWithoutRepeating      ->  this exercise
    //   ---------------------------------         ----------------------------
    //   string, letters                       ->  int[], numbers
    //   best = biggest SIZE (right-left+1)    ->  best = biggest SUM of the window
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class MaximumUniqueSubarraySum
    {
        // ========================================================================
        // SAMPLE 1: Biggest sum of a continuous piece with all different numbers
        // ========================================================================
        // A subarray is a CONTINUOUS piece of the array (no gaps).
        // All numbers are positive. Return the biggest SUM, not the length.
        //
        // [4,2,4,5,6]          -> 17  (2+4+5+6)
        // [5,2,1,2,5,2,1,2,5]  -> 8   (5+2+1 or 1+2+5)
        // [1,2,3,1,9]          -> 15  (2+3+1+9, found AFTER a shrink)
        // [10,1,1,2]           -> 11  (10+1 at the START: best must remember it)
        // [2,1,1,2]            -> 3   (like "abba": the old 2 already left)
        // [7,7,7]              -> 7
        // [1,2,3,4]            -> 10  (no repeats: the whole array)
        // [5]                  -> 5
        // [] or null           -> 0
        //
        //   [4,2,4,5,6]   window = [left .. right], all different inside
        //    [4]2 4 5 6          sum 4
        //    [4 2]4 5 6          sum 6
        //     4[2 4]5 6          2nd 4 repeats -> drop 4 (sum 6-4=2), add 4 (sum 6)
        //     4[2 4 5]6          sum 11
        //     4[2 4 5 6]         sum 17  <- best
        //
        // Difficulty: Medium
        // Goal: Time O(n), Space O(n)
        // Expected time to solve: 15 min
        // Pattern: Sliding window + Seen set (LongestSubstringWithoutRepeating)
        // Topic: Arrays + Hashing + Sliding window
        // Tip 1: Write LengthOfLongest from memory first, then change it.
        //        Keep a running 'sum' of the window: when a number ENTERS the
        //        window, sum += it. Best = max(best, sum).
        // Tip 2: When a number LEAVES the window (inside the shrink while loop),
        //        remove it from the set AND subtract it from sum, then left++.
        //        Don't recompute the sum with a loop: that would be O(n^2).
        // ========================================================================
        public int MaxSum(int[] numbers)
        {
            if (numbers == null ||  numbers.Length == 0  ) 
                return 0;

            HashSet<int> memory = new HashSet<int>();
            int left= 0;
            int best= 0, sum = 0;
            for (int right = 0; right < numbers.Length; right++)
            {
                while (memory.Contains(numbers[right]))
                {
                    memory.Remove(numbers[left]);
                    sum -= numbers[left];
                    left++;
                }
                memory.Add(numbers[right]);
                sum += numbers[right];

                //int size = right - left + 1;

                //it's bad its O(n²)
                //for (int i = left; i <= right; i++) {
                //    sum += numbers[i];
                //}

                best = Math.Max(best , sum);
            }

            return best;
        }
    }
}
