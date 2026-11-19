using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainingAlgorithms.algorithms.medium
{
    // ============================================================================
    // LONGEST SUBSTRING WITHOUT REPEATING CHARACTERS (LeetCode 3)
    // ============================================================================
    // Mixes two patterns you already know:
    //   - Seen set (UniqueCharacters): "is this char already in the window?"
    //   - Two pointers: but now BOTH start at the left and move the SAME way
    //     (a "sliding window"), instead of starting at opposite ends.
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class LongestSubstringWithoutRepeating
    {
        // ========================================================================
        // SAMPLE 1: Length of the longest substring with all unique characters
        // ========================================================================
        // A substring is a CONTINUOUS piece of the string. Case sensitive.
        //
        // "abcabcbb" -> 3 ("abc")
        // "bbbbb"    -> 1 ("b")
        // "pwwkew"   -> 3 ("wke"; "pwke" is not continuous)
        // "abba"     -> 2 ("ab" or "ba")
        // "dvdf"     -> 3 ("vdf")
        // "au"       -> 2
        // "" or null -> 0
        //
        //   "pwwkew"  window = [left .. right], all unique inside
        //    [p]w w k e w     size 1
        //    [p w]w k e w     size 2
        //     p w[w]k e w     2nd 'w' repeats -> move left past the 1st 'w'
        //     p w[w k e]w     size 3  <- best
        //     p w w[k e w]    'w' repeats -> move left, size 3
        //
        // Difficulty: Medium
        // Goal: Time O(n), Space O(min(n, 128))
        // Expected time to solve: 15 min
        // Pattern: Sliding window + Seen set (UniqueCharacters + two pointers)
        // Topic: Strings + Hashing + Sliding window
        // Tip 1: 'right' walks every char (for loop). Keep a HashSet with the
        //        chars inside the window. Best = max(best, right - left + 1).
        // Tip 2: When input[right] is already in the set, SHRINK from the left:
        //        remove input[left] from the set and left++, in a while loop,
        //        until the repeated char is gone. Then add input[right].
        // ========================================================================
        public int LengthOfLongest(string input)
        {

            // FIX 1: check the input first.
            //   null -> 'input.Length' crashed.   "" -> '.Max()' on an empty set crashed.
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            // The bag: letters currently INSIDE the window [left .. right].
            // One item per letter -> { "p", "w" }, never one item "pw".


            HashSet<string> memory = new HashSet<string>();


            // FIX 2: one int is enough (the "high score").
            //   We only need the BIGGEST size so far, not every size.
            int best = 0;

            // BAD
            //HashSet<int> size = new HashSet<int>();
            //int maxSize = 0;
            //int best = 0;

            int left = 0;
            int right = 0;

            //***************************************************************************************************
            // WRONG you dont need move 2 pointers
            //while (right < input.Length) {

            //    if (!memory.Contains(input[right].ToString()))
            //    {
            //        memory.Add(input[right].ToString());
            //    }
            //    else
            //    {
            //        memory.Remove(input[left].ToString());
            //        left++;

            //    }


            //    if (!memory.Contains(input[left].ToString()))
            //    {
            //        memory.Add(input[left].ToString());
            //    }

            //    size.Add(right - left + 1);

            //    right++;
            //}
            //***************************************************************************************************
            // GOOD
            while (right < input.Length)
            {
                string letter = input[right].ToString();

                // FIX 3: your 'else', but as a WHILE.
                //   The new letter is already in the window -> shrink from the left
                //   until the old copy is gone.
                //   "pwwkew", right = 2 (second 'w'):
                //     remove "p" (left 0 -> 1) -> old "w" still inside, keep going
                //     remove "w" (left 1 -> 2) -> old "w" gone, stop
                while (memory.Contains(letter))
                {
                    memory.Remove(input[left].ToString());
                    left++;
                }

                // Now it's safe: add the NEW letter (input[right], not input[left]).
                memory.Add(letter);

                // FIX 4: size = right - left + 1. Update 'best' only when this window beats it.
                //   "abcdd": at the end size is 1 ([d]), but best must stay 4 ("abcd").
                best = Math.Max(best, right - left + 1);

                right++;   // kept from your code: after measuring the size
            }

            // FIX 5 (removed): the 'if (!memory.Contains(input[left]))' block.
            //   Adding letters is done once, above. 'left' only moves in the shrink loop.

            return best;
        }
    }
}
