using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }
    }
}
