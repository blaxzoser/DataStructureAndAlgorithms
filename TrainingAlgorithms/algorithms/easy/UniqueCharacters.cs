using System;
using System.Collections.Generic;

namespace TrainingAlgorithms.algorithms.easy
{
    // ============================================================================
    // UNIQUE CHARACTERS (Cracking the Coding Interview 1.1)
    // ============================================================================
    // NEW PATTERN: "Seen set / Frequency count"
    //   Walk the input once and REMEMBER what you've already seen
    //   (HashSet<char>, bool[128], int[26], Dictionary<char,int>).
    //   Asking "have I seen this before?" is then O(1).
    //
    // Worked example (with LINQ / other ideas): Samples/questions/arraysAndStrings/UniqueCharacters.cs
    // Here: solve it BY HAND, with loops, no LINQ.
    //
    // Total practice time: ~25 min
    // ============================================================================
    public class UniqueCharacters
    {
        // ========================================================================
        // SAMPLE 1: Does the string have all unique characters?
        // ========================================================================
        // Case sensitive: 'a' and 'A' are different. Spaces count as characters.
        //
        // "abcde" -> true
        // "hello" -> false ('l' twice)
        // "aA"    -> true  (different case = different char)
        // "a b c" -> false (the space appears twice)
        // "a"     -> true
        // ""      -> true  (nothing repeats)
        // null    -> false
        //
        // CASES TO THINK ABOUT before coding:
        //   - Empty and one-char strings: no pair to compare -> true
        //   - Upper vs lower case: same letter, different char
        //   - Spaces and symbols are characters too
        //   - The duplicate can be far apart: "abcda" ('a' at 0 and 4)
        //   - The duplicate can be next to each other: "abbc"
        //
        // Difficulty: Easy
        // Goal: Time O(n), Space O(n) (or O(1): at most 128 ASCII chars)
        // Expected time to solve: 10 min
        // Pattern: Seen set (new)
        // Topic: Strings + Hashing
        // Tip 1: Keep a HashSet<char> of what you've seen. If the current char is
        //        already in it, you found a duplicate -> return false right away.
        // Tip 2: HashSet.Add returns false when the item is already there, so
        //        "check and add" can be one call.
        //
        // Result 1: 30 min, all tests pass (HashSet + Contains/Add)
        // ========================================================================
        public bool IsUnique(string input)
        {
            if (input == null) return false;

            if(input.Length == 1 || input == "") return true;

            var hash = new HashSet<char>();
            for (int i = 0; i < input.Length; i++) {
                if (hash.Contains(input[i])) {
                    return false;
                }
                else
                {
                    hash.Add(input[i]);
                }
            }
            return true;
        }

        // ========================================================================
        // SAMPLE 2: Same problem, but WITHOUT any extra data structure
        // ========================================================================
        // Same examples and results as Sample 1.
        // The classic follow-up question: "What if you can't use a HashSet?"
        //
        // Difficulty: Easy
        // Goal: Time O(n^2), Space O(1)
        // Expected time to solve: 15 min
        // Pattern: Compare every pair (brute force)
        // Topic: Strings + Nested loops
        // Tip 1: Compare each char with every char AFTER it: i from 0, j from i + 1.
        //        Starting j at i + 1 avoids comparing a char with itself.
        // Tip 2: Think about why this is O(n^2) and Sample 1 is O(n): here the
        //        inner loop STARTS OVER for each i (unlike the two-pointer loops).
        // ========================================================================
        public bool IsUniqueNoExtraSpace(string input)
        {
            if (input == null) return false;
            if (input.Length == 1 || input == "") return true;

            for (int i = 0; i < input.Length; i++) {
                for (int j = 1 + i; j < input.Length; j++)
                {
                    if (input[j] == input[i]) {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
