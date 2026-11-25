using System;
using System.Collections.Generic;

namespace TrainingAlgorithms.algorithms.medium
{
    // ============================================================================
    // RETURN THE LONGEST UNIQUE SUBSTRING (rep 3 of LongestSubstringWithoutRepeating)
    // ============================================================================
    // Same skeleton as LengthOfLongest, line for line. Same HashSet, same
    // 'while (Contains)' BEFORE adding, same Remove(left).
    //
    //   THE ONE CHANGE:   return the SUBSTRING, not its length. So instead of
    //                     best = Math.Max(...), remember WHERE the best window
    //                     starts (bestStart) when a bigger one appears.
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class LongestUniqueSubstring
    {
        // ========================================================================
        // SAMPLE 1: The longest substring with all different characters
        // ========================================================================
        // If two pieces have the same length, return the FIRST one found.
        //
        // "abcabcbb" -> "abc"
        // "bbbbb"    -> "b"
        // "pwwkew"   -> "wke"     ("kew" is just as long but comes later)
        // "abba"     -> "ab"      ("ba" is just as long but comes later)
        // "dvdf"     -> "vdf"
        // "aab"      -> "ab"
        // "abcdef"   -> "abcdef"
        // " "        -> " "
        // "" or null -> ""
        //
        // Difficulty: Medium (rep)
        // Goal: Time O(n), Space O(n)
        // Expected time to solve: 15 min
        // Pattern: Sliding window + Seen set (LongestSubstringWithoutRepeating)
        // Topic: Strings + Hashing + Sliding window
        // Tip 1: Write LengthOfLongest from memory. Keep 2 ints: best (length)
        //        and bestStart (where it starts). Replace the Math.Max line with:
        //        if (right - left + 1 > best) { best = right - left + 1; bestStart = left; }
        //        Use '>' (not '>='), so a later window of the same size doesn't win.
        // Tip 2: At the end: return text.Substring(bestStart, best);
        //        Substring takes (start, LENGTH), not (start, end).
        // ========================================================================
        public string Find(string text)
        {
            throw new NotImplementedException();
        }
    }
}
