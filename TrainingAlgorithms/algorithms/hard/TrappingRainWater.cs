using System;

namespace TrainingAlgorithms.algorithms.hard
{
    // ============================================================================
    // TRAPPING RAIN WATER (LeetCode 42)
    // ============================================================================
    // Same idea as ContainerWithMostWater (medium): two pointers on an array,
    // always move the side with the SHORTER height. The new part: you also
    // remember the tallest bar seen so far on each side.
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class TrappingRainWater
    {
        // ========================================================================
        // SAMPLE 1: How much rain water is trapped between the bars?
        // ========================================================================
        // heights[i] is a bar of width 1. After it rains, water stays on top of
        // a bar if there are taller bars on BOTH sides.
        // Water on bar i = min(tallest on the left, tallest on the right) - heights[i]
        //
        // [0,1,0,2,1,0,1,3,2,1,2,1] -> 6
        // [4,2,0,3,2,5]             -> 9
        // [2,0,2]                   -> 2
        // [1,2,3]                   -> 0 (water runs off)
        // [] or null                -> 0
        //
        //   [4,2,0,3,2,5]
        //             █
        //   █ ~ ~ ~ ~ █      ~ = water (2 + 4 + 1 + 2 = 9)
        //   █ ~ ~ █ ~ █
        //   █ █ ~ █ █ █
        //   █ █ ~ █ █ █
        //
        // Difficulty: Hard
        // Goal: Time O(n), Space O(1)
        // Expected time to solve: 15 min
        // Pattern: Two Pointers (opposite ends), move the SHORTER side
        //          (same move rule as ContainerWithMostWater)
        // Topic: Arrays + Two Pointers
        // Tip 1: Keep 4 variables: left, right, leftMax, rightMax. If
        //        heights[left] < heights[right], the left side is the limit:
        //        the water at 'left' only depends on leftMax.
        // Tip 2: On the side you move: if the bar is taller than its max,
        //        update the max (no water). Otherwise add max - bar to the total.
        // ========================================================================
        public int Trap(int[] heights)
        {
            throw new NotImplementedException();
        }
    }
}
