using System;

namespace TrainingAlgorithms.algorithms.easy
{
    // ============================================================================
    // REVERSE VOWELS (LeetCode 345)
    // ============================================================================
    // Second round of the same pattern as ReverseOnlyLetters:
    // two pointers that SKIP what doesn't count and SWAP what does.
    // Only the "what counts" check changes: vowels instead of letters.
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class ReverseVowels
    {
        // ========================================================================
        // SAMPLE 1: Reverse only the vowels
        // ========================================================================
        // Reverse the vowels (a, e, i, o, u, upper or lower case) of the string.
        // Every other character stays in the same position.
        //
        // "hello"    -> "holle"
        // "leetcode" -> "leotcede"
        // "IceCreAm" -> "AceCreIm"
        // "bcd"      -> "bcd"
        // ""         -> ""
        // null       -> null
        //
        // Difficulty: Easy
        // Goal: Time O(n), Space O(n) (the new string you return)
        // Expected time to solve: 15 min
        // Pattern: Two Pointers + Skip + Swap (same as ReverseOnlyLetters)
        // Topic: Strings + Arrays + Two Pointers + Character handling
        // Tip 1: Write a small helper IsVowel(char c). "aeiouAEIOU".IndexOf(c) >= 0
        //        is a quick way to check it.
        // Tip 2: The loop is the same as ReverseOnlyLetters: only the skip
        //        condition changes. Try to write it from memory first.
        // ========================================================================
        public string Reverse(string input)
        {
            throw new NotImplementedException();
        }
    }
}
