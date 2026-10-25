using System;

namespace TrainingAlgorithms.algorithms.hard
{
    // ============================================================================
    // VALID PALINDROME: SKIP SYMBOLS + ONE DELETION (LeetCode 125 + 680 combined)
    // ============================================================================
    // Puts together the two palindrome patterns you practiced:
    //   - Palindrome.Sample2Refactor        -> skip non letters/digits, ignore case
    //   - ValidPalindromeOneDeletion (medium) -> allow ONE mismatch
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class ValidPalindromeSkipAndDelete
    {
        // ========================================================================
        // SAMPLE 1: Palindrome ignoring case/symbols, after at most one deletion
        // ========================================================================
        // Ignore case and every character that is not a letter or digit.
        // Then allow deleting at most ONE letter or digit.
        //
        // "A man, a plan, a canal: Panama" -> true  (already a palindrome)
        // "race a car"                     -> true  (delete the 'e')
        // "Ab, c a"                        -> true  ("abca": delete 'b' or 'c')
        // "No lemon, no melons"            -> true  (delete the last 's')
        // "Tact, Coa"                      -> false ("tactcoa": needs 2 deletions)
        // "a.b.c"                          -> false
        // ""                               -> true
        // null                             -> false
        //
        // Difficulty: Hard (in this set: two patterns at the same time)
        // Goal: Time O(n), Space O(1)
        // Expected time to solve: 15 min
        // Pattern: Two Pointers + Skip (Sample2Refactor) + one deletion (medium)
        // Topic: Strings + Two Pointers + Character handling
        // Tip 1: Write a helper IsValidRange(string s, int left, int right) that
        //        is Sample2Refactor but on a range. Then the main method is the
        //        same as the medium one, calling this helper twice.
        // Tip 2: Do the skipping BEFORE comparing in both the main loop and the
        //        helper, otherwise a symbol can be "deleted" by mistake.
        // ========================================================================
        public bool CanBeValidPalindrome(string input)
        {
            throw new NotImplementedException();
        }
    }
}
