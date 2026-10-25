using System;
using System.Collections.Generic;

namespace TrainingAlgorithms.algorithms.easy
{
    // ============================================================================
    // FIRST UNIQUE CHARACTER (LeetCode 387)
    // ============================================================================
    // Builds on UniqueCharacters: instead of "seen or not" (true/false), you
    // need HOW MANY TIMES each char appears -> a count, not just a set.
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class FirstUniqueCharacter
    {
        // ========================================================================
        // SAMPLE 1: Index of the first character that appears only once
        // ========================================================================
        // Return the index of the first non-repeating character, or -1.
        // Case sensitive.
        //
        // "leetcode"     -> 0  ('l' appears once)
        // "loveleetcode" -> 2  ('v')
        // "aabb"         -> -1 (every char repeats)
        // "aAbB"         -> 0  ('a' and 'A' are different)
        // "z"            -> 0
        // "" or null     -> -1
        //
        // Difficulty: Easy
        // Goal: Time O(n), Space O(1) (at most 128 different chars)
        // Expected time to solve: 15 min
        // Pattern: Frequency count (builds on UniqueCharacters)
        // Topic: Strings + Hashing
        // Tip 1: TWO passes over the string. Pass 1: count every char.
        //        Pass 2: the first char whose count is 1 is the answer.
        // Tip 2: For the counts, a Dictionary<char, int> works, or an int[128]
        //        indexed by the char itself: counts[c]++ (a char is a number).
        // ========================================================================
        public int FindIndex(string input)
        {
            throw new NotImplementedException();
        }
    }
}
