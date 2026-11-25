using System;
using System.Collections.Generic;

namespace TrainingAlgorithms.algorithms.medium
{
    // ============================================================================
    // LONGEST RUN OF UNIQUE NUMBERS (rep 1 of LongestSubstringWithoutRepeating)
    // ============================================================================
    // Same skeleton as LengthOfLongest, line for line. Same HashSet, same
    // 'while (Contains)' BEFORE adding, same Remove(left), same best.
    //
    //   THE ONE CHANGE:   string text  ->  int[] numbers
    //                     HashSet<char> -> HashSet<int>
    //
    // Total practice time: ~10 min
    // ============================================================================
    public class LongestUniqueNumbers
    {
        // ========================================================================
        // SAMPLE 1: Length of the longest continuous piece with all different numbers
        // ========================================================================
        // A subarray is a CONTINUOUS piece of the array (no gaps).
        //
        // [1,2,3,1,2,3,2,2]  -> 3   ([1,2,3], like "abcabcbb")
        // [2,2,2,2]          -> 1
        // [1,2,2,3,4,5]      -> 4   ([2,3,4,5], found AFTER a shrink)
        // [1,2,1,3]          -> 3   ([2,1,3])
        // [3,1,4,1,5,9,2]    -> 5   ([4,1,5,9,2])
        // [4,1,1,4]          -> 2   (like "abba": the old 4 already left)
        // [1,2,3,4]          -> 4   (no repeats: the whole array)
        // [7]                -> 1
        // [] or null         -> 0
        //
        // Difficulty: Medium (rep)
        // Goal: Time O(n), Space O(n)
        // Expected time to solve: 10 min
        // Pattern: Sliding window + Seen set (LongestSubstringWithoutRepeating)
        // Topic: Arrays + Hashing + Sliding window
        // Tip 1: Write LengthOfLongest from memory and change ONLY the types.
        //        for (right) -> while (memory.Contains(numbers[right])) ->
        //        Add(numbers[right]) -> best = Math.Max(best, right - left + 1).
        // Tip 2: Inside the while, EVERY line uses left:
        //        memory.Remove(numbers[left]); left++;
        //        No left++ anywhere else.
        // ========================================================================
        public int LengthOfLongest(int[] numbers)
        {
            if(numbers ==null || numbers.Length == 0) return 0;

            HashSet<int> window = new HashSet<int>();
            var left = 0;
            var maxLength = 0;
            
            for (int right = 0; right < numbers.Length; right++) {
                while (window.Contains(numbers[right]))
                {
                    window.Remove(numbers[left]);
                    left++;
                }
                window.Add(numbers[right]);
                maxLength = Math.Max(maxLength, right - left + 1);
                
            }

            return maxLength;
        }
    }
}
