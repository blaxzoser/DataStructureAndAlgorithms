using System;
using System.Runtime.InteropServices;

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
        //
        // Result 1: 40 min, all tests pass after rewriting with the 2 inner whiles
        // ========================================================================
        // WHY THE 2 INNER WHILES ARE A GOOD SOLUTION
        // ========================================================================
        // Each round of the outer while has 3 steps:
        //   1. inner while 1: move LEFT forward until it's on a letter
        //   2. inner while 2: move RIGHT back until it's on a letter
        //   3. now BOTH are on letters -> swap, then move both inward
        //
        // First attempt (if / else if) had to list every case by hand:
        //
        //   chars[left]   chars[right]   what happened
        //   -----------   ------------   ---------------------------------
        //   letter        letter         swap, move both          ✓
        //   symbol        letter         left++                   ✓
        //   letter        symbol         right--                  ✓
        //   symbol        symbol         NO BRANCH -> nothing moves
        //                                -> infinite loop (the hang)  ❌
        //
        // The inner whiles don't need cases: whatever side is on a symbol
        // keeps moving until it isn't. So there's no case left out.
        //
        // TRACE: "a-b!c" -> "c-b!a"
        //
        //   index:  0   1   2   3   4
        //           a   -   b   !   c
        //           L               R    both letters -> swap, L=1 R=3
        //
        //           c   -   b   !   a
        //               L       R        inner 1: '-' is a symbol -> L=2
        //                   L   R        inner 2: '!' is a symbol -> R=2
        //                   LR           L == R: swap 'b' with itself
        //                                (no change), L=3 R=1
        //
        //           c   -   b   !   a    L < R is false -> done ✓
        //
        // TRACE: "-a-" -> "-a-" (both ends are symbols, the case that hung)
        //
        //           -   a   -
        //           L       R            inner 1: '-' -> L=1, 'a' stop
        //               LR               inner 2: stops, L < R is false
        //                                swap 'a' with itself, done ✓
        //
        // WHY "left < right" IS ALSO IN THE INNER WHILES
        //   Without it, in "123" (no letters at all) LEFT would keep going past
        //   RIGHT and past the end of the string -> IndexOutOfRangeException.
        //
        // WHY IT'S STILL O(n) WITH A WHILE INSIDE A WHILE
        //   LEFT only goes forward and RIGHT only goes back, never restart.
        //   Together they move at most n steps -> each char visited once.
        //
        // SAME SHAPE AS Palindrome.Sample2Refactor: only step 3 changes
        //   Sample2Refactor: compare chars[left] and chars[right]
        //   Reverse:         swap    chars[left] and chars[right]
        // ========================================================================
        public string Reverse(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            int left = 0;
            int right = input.Length - 1;
            char[] chars = input.ToCharArray();
            while (left < right)
            {
                while (left < right && !char.IsLetter(chars[left]))
                    left++;
                while(left < right && !char.IsLetter(chars[right]))
                    right--;
            
                var tempLeft = input[left];
                var tempRight = input[right];
                chars[left] = tempRight;
                chars[right] = tempLeft;

                left++;
                right--;                
            }
            return new string(chars);
        }
    }
}
