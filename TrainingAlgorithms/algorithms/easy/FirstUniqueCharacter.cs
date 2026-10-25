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
        // ========================================================================
        public int FindIndex(string input)
        {
            if(string.IsNullOrEmpty(input)) return -1;

            if (input.Length == 1) return 0;
            var hash = new Dictionary<char,int>();
            for (int i = 0; i < input.Length; i++)
            {

                if (!hash.ContainsKey(input[i]))
                {
                    hash.Add(input[i], 1);
                }
                else
                {
                    hash[input[i]] = hash[input[i]] + 1;
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (hash[input[i]] == 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
