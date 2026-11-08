using System;
using System.Collections.Generic;
using System.Linq;

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
        //
        // Drawing of the example above ( █ = line, ~ = water held ):
        //
        // height
        //   8 |    █              █
        //   7 |    █  ~  ~  ~  ~  █  ~  █
        //   6 |    █  █  ~  ~  ~  █  ~  █
        //   5 |    █  █  ~  █  ~  █  ~  █
        //   4 |    █  █  ~  █  █  █  ~  █
        //   3 |    █  █  ~  █  █  █  █  █
        //   2 |    █  █  █  █  █  █  █  █
        //   1 | █  █  █  █  █  █  █  █  █
        //     +---------------------------
        //       0  1  2  3  4  5  6  7  8   <- position (index)
        //          ^                    ^
        //        left                 right
        //
        //   width  = right - left          = 8 - 1 = 7
        //   height = min(8, 7)             = 7  (the shorter wall limits it)
        //   area   = 7 * 7                 = 49
        //
        // Only the two walls matter; taller lines between them don't change it.
        //
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
        // ------------------------------------------------------------------------
        // YOUR ORIGINAL CODE (kept as a comment). Mistakes found:
        //  1) while (left == right)  -> the loop is true only when both pointers
        //     are on the SAME index, and at the start left=0, right=n-1, so for
        //     n > 1 it NEVER runs and the method returns 0. Must be left < right.
        //  2) width + height          -> area is width * height, not a sum.
        //  3) areasMemory[0] = areas  -> always writes index 0, so each round
        //     overwrites the previous one. You only need ONE variable: maxArea.
        //  4) null / [] / [5]         -> heights.Length throws on null, and the
        //     spec says these return 0.
        //  5) The area was computed AFTER moving the pointer, but 'height' was
        //     taken before it, so that part was fine; just keep the order:
        //     compute area -> update best -> move pointer.
        //
        // public int MaxArea(int[] heights)
        // {
        //     var left = 0;
        //     var right = heights.Length - 1;
        //     var areasMemory = new int[heights.Length];
        //     while (left == right) {
        //
        //         var width = right - left;
        //         var height = 0;
        //         if (heights[left] < heights[right]) {
        //             height = heights[left];
        //             left++;
        //         }
        //         else
        //         {
        //             height = heights[right];
        //             right--;
        //         }
        //         var areas = width + height;
        //         areasMemory[0] = areas;
        //     }
        //
        //     return areasMemory.Max( s => s);
        // }

        // ------------------------------------------------------------------------
        // FIXED VERSION with debug output. Set DebugLog = false to silence it.
        // Trace for [1,8,6,2,5,4,8,3,7]:
        //   L=0 R=8 h=(1,7) width=8 area=8  best=8   -> move LEFT  (1 < 7)
        //   L=1 R=8 h=(8,7) width=7 area=49 best=49  -> move RIGHT (7 <= 8)
        //   ... the rest are all <= 49, answer 49
        // ------------------------------------------------------------------------
        //
        // ------------------------------------------------------------------------
        // LINE-BY-LINE SIMULATION  heights = [1,8,6,2,5,4,8,3,7]
        //                           index     0 1 2 3 4 5 6 7 8
        //
        // SETUP (runs once)
        //   heights == null || Length < 2 ?  -> 9 lines, so no, keep going
        //   left    = 0                      -> pointer on the first line  (1)
        //   right   = heights.Length - 1 = 8 -> pointer on the last line   (7)
        //   maxArea = 0                      -> best answer so far
        //
        // LOOP: each round does these 6 steps, in this order
        //   a) while (left < right)        keep going while the pointers haven't met
        //   b) width  = right - left       distance between the two walls
        //   c) height = min(L, R)          the SHORTER wall limits the water
        //   d) area   = width * height
        //   e) if (area > maxArea) maxArea = area     remember the best
        //   f) move the pointer at the SHORTER wall (left++ or right--)
        //
        //  round | left right | L  R | width | height | area | maxArea | move
        //  ------+------------+------+-------+--------+------+---------+------------------
        //    1   |  0    8    | 1  7 |   8   |   1    |   8  |    8    | L<R  -> left++  (L=1)
        //    2   |  1    8    | 8  7 |   7   |   7    |  49  |   49    | L>=R -> right-- (R=7)
        //    3   |  1    7    | 8  3 |   6   |   3    |  18  |   49    | right-- (R=6)
        //    4   |  1    6    | 8  8 |   5   |   8    |  40  |   49    | equal -> right-- (R=5)
        //    5   |  1    5    | 8  4 |   4   |   4    |  16  |   49    | right-- (R=4)
        //    6   |  1    4    | 8  5 |   3   |   5    |  15  |   49    | right-- (R=3)
        //    7   |  1    3    | 8  2 |   2   |   2    |   4  |   49    | right-- (R=2)
        //    8   |  1    2    | 8  6 |   1   |   6    |   6  |   49    | right-- (R=1)
        //  stop  |  1    1    | left < right is FALSE (pointers met) -> exit loop
        //
        //  return maxArea -> 49
        //
        // Look at round 1: area is only 8, but we still moved LEFT (the short 1).
        // Moving right would keep the height capped at 1 with less width, so it
        // could never beat 8. That is the whole greedy idea.
        // ------------------------------------------------------------------------
        private const bool DebugLog = true;

        public int MaxArea(int[] heights)
        {
            // FIX 4: guard null and fewer than 2 lines
            if (heights == null || heights.Length < 2) return 0; // null/[]/[5] -> 0

            var left = 0;                    // first line
            var right = heights.Length - 1;  // last line (widest container)
            var maxArea = 0; // FIX 3: one variable instead of the array

            // FIX 1: stop when the pointers meet (left < right)
            while (left < right) // a) still two different lines to compare?
            {
                var width = right - left; // b) e.g. round 2: 8 - 1 = 7
                var height = Math.Min(heights[left], heights[right]); // c) shorter wall limits water, e.g. min(8,7) = 7
                var area = width * height; // d) FIX 2: multiply, not add, e.g. 7 * 7 = 49

                if (area > maxArea) maxArea = area; // e) keep the best, e.g. 8 -> 49

                if (DebugLog)
                {
                    Console.WriteLine(
                        $"L={left} R={right} heights=({heights[left]},{heights[right]}) " +
                        $"width={width} height={height} area={area} best={maxArea}");
                }

                // move the pointer at the SHORTER line (moving the taller never helps)
                if (heights[left] < heights[right])
                {
                    if (DebugLog) Console.WriteLine($"  -> move LEFT  ({heights[left]} < {heights[right]})");
                    left++;
                }
                else
                {
                    if (DebugLog) Console.WriteLine($"  -> move RIGHT ({heights[right]} <= {heights[left]})");
                    right--;
                }
            }

            return maxArea;
        }
    }
}
