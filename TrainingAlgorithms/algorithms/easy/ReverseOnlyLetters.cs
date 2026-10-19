using System;

namespace TrainingAlgorithms.algorithms.easy
{
    // ============================================================================
    // REVERSE ONLY LETTERS (LeetCode 917)
    // ============================================================================
    // Practice for the same pattern as Palindrome.Sample2Refactor:
    // two pointers that SKIP the characters we don't care about.
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class ReverseOnlyLetters
    {
        // ========================================================================
        // SAMPLE 1: Reverse only the letters
        // ========================================================================
        // Reverse the letters of the string. Every character that is NOT a
        // letter (digits, '-', '=', '!', spaces...) stays in the same position.
        //
        // "ab-cd"                -> "dc-ba"
        // "a-bC-dEf-ghIj"        -> "j-Ih-gfE-dCba"
        // "Test1ng-Leet=code-Q!" -> "Qedo1ct-eeLg=ntse-T!"
        // "123"                  -> "123"
        // ""                     -> ""
        // null                   -> null
        //
        // Goal: Time O(n), Space O(n) (the new string you return)
        // Expected time to solve: 15 min
        // Topic: Strings + Arrays + Two Pointers + Character handling
        // Tip:   Strings can't be changed in C#, so work on input.ToCharArray()
        //        and return new string(chars) at the end.
        //        Same skipping idea as Sample2Refactor, but when both pointers
        //        are on a letter, SWAP them instead of comparing.
        //        char.IsLetter helps.
        // ========================================================================
        public string Reverse(string input)
        {
            throw new NotImplementedException();
        }
    }
}
