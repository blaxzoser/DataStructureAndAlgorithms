using System;

namespace TrainingAlgorithms.algorithms.medium
{
    // ============================================================================
    // VALID PALINDROME WITH ONE DELETION (LeetCode 680)
    // ============================================================================
    // Builds on Palindrome.Sample1Refactor: same two pointers, but now one
    // mismatch is allowed if deleting ONE character fixes it.
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class ValidPalindromeOneDeletion
    {
        // ========================================================================
        // SAMPLE 1: Can it be a palindrome after deleting at most one character?
        // ========================================================================
        // Compare exact characters (no skipping, case matters).
        //
        // "aba"   -> true  (already a palindrome)
        // "abca"  -> true  (delete 'b' or 'c')
        // "abc"   -> false (one deletion is not enough)
        // "cbbcc" -> true  (delete the last 'c')
        // ""      -> true
        // null    -> false
        //
        // Difficulty: Medium (LeetCode marks it Easy, but it's a step up from
        //             the palindromes you already did)
        // Goal: Time O(n), Space O(1)
        // Expected time to solve: 15 min
        // Pattern: Two Pointers (same as Palindrome.Sample1Refactor)
        // Topic: Strings + Two Pointers
        // Tip 1: Walk inward like a normal palindrome. At the FIRST mismatch you
        //        have only two choices: skip the left char or skip the right char.
        // Tip 2: Write a helper IsPalindrome(string s, int left, int right) that
        //        checks just a range, and call it for both choices.
        // ========================================================================
        public bool CanBePalindrome(string input)
        {
            throw new NotImplementedException();
        }
    }
}
