using System;

namespace TrainingAlgorithms.algorithms.medium
{
    // ============================================================================
    // CONTAINER WITH MOST WATER (LeetCode 11)
    // ============================================================================
    // Same two pointers from both ends, but on an ARRAY of numbers. The new
    // part: deciding WHICH pointer to move, instead of always moving both.
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class ContainerWithMostWater
    {
        // ========================================================================
        // SAMPLE 1: Max water between two lines
        // ========================================================================
        // heights[i] is a vertical line at position i. Pick two lines: the water
        // they hold is  width * min(height of the two lines)
        //               (right - left) * Math.Min(heights[left], heights[right])
        // Return the biggest amount possible.
        //
        // [1,8,6,2,5,4,8,3,7] -> 49 (lines at 1 and 8: width 7 * height 7)
        // [1,1]               -> 1
        // [4,3,2,1,4]         -> 16
        // [5]                 -> 0  (need two lines)
        // [] or null          -> 0
        //
        // Difficulty: Medium
        // Goal: Time O(n), Space O(1)
        // Expected time to solve: 15 min
        // Pattern: Two Pointers (opposite ends), move ONE pointer per round
        // Topic: Arrays + Two Pointers + Greedy
        // Tip 1: Start with the widest container (left = 0, right = end) and
        //        keep track of the best area seen so far.
        // Tip 2: The shorter line limits the water. Moving the TALLER line can
        //        never help, so always move the pointer at the shorter line.
        // ========================================================================
        public int MaxArea(int[] heights)
        {
            throw new NotImplementedException();
        }
    }
}
