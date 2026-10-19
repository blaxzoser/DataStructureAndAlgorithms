using System;
using System.Linq;

namespace TrainingAlgorithms.algorithms.easy
{
    // ============================================================================
    // PALINDROME
    // ============================================================================
    // A palindrome reads the same forwards and backwards.
    // Examples: "racecar", "anitalavalatina", 121
    //
    // Total practice time: ~40 min
    // ============================================================================
    public class Palindrome
    {
        // ========================================================================
        // SAMPLE 1: Simple palindrome check (exact characters)
        // ========================================================================
        // "racecar" -> true
        // "hello"   -> false
        // ""        -> true
        // null      -> false
        //
        // Goal: Time O(n), Space O(1)
        // Expected time to solve: 10 min
        // 1 intent 15 min 
        // Topic: Strings + Two Pointers
        // Tip:   Put one index at the start and one at the end, compare,
        //        and move both toward the middle until they meet.
        // ========================================================================
        public bool IsPalindrome(string input)
        {
           if (input == null) return false;
           else if(input == string.Empty || input.Length == 1) return true;

           int indexLeft = 0;
           int indexRight = input.Length -1;

            do
            {
                if (input[indexLeft]  == input[indexRight])
                {
                    indexLeft++;
                    indexRight--;
                }
                else
                {
                    return false;
                }
            }
            while (indexLeft < indexRight);

           return true;
        }

        // ========================================================================
        // SAMPLE 1 REFACTOR: compare with IsPalindrome above
        // ========================================================================
        // Changes:
        //   - 'while' instead of 'do...while': the condition is checked BEFORE
        //     the first comparison, so "" and "a" just skip the loop and
        //     return true. No special case needed (and no input[0] crash on "").
        //   - Return false as soon as a pair doesn't match, so the happy path
        //     (move both pointers) doesn't need an 'else'.
        // ========================================================================
        public bool Sample1Refactor(string input)
        {
            if (input == null) return false;

            int left = 0;
            int right = input.Length - 1;

            while (left < right)
            {
                if (input[left] != input[right]) return false;

                left++;
                right--;
            }

            return true;
        }

        // ========================================================================
        // SAMPLE 2: Valid palindrome (LeetCode 125)
        // ========================================================================
        // Ignore case and every character that is not a letter or digit.
        // "A man, a plan, a canal: Panama" -> true
        // "race a car"                     -> false
        // " "                              -> true
        //
        // Goal: Time O(n), Space O(1)
        // Expected time to solve: 15 min
        // 1 takes 30 min
        // Topic: Strings + Two Pointers + Character handling
        // Tip:   Same idea as Sample 1, but before comparing, skip characters
        //        you don't care about. char.IsLetterOrDigit and char.ToLower help.
        // ========================================================================
        public bool IsValidPalindrome(string input)
        {        
            string cleanInput = String.Concat(input.ToLower().Trim().Where(s => char.IsLetterOrDigit(s)));
            if (string.IsNullOrEmpty(cleanInput) || cleanInput.Length == 1) { return true; }

            var lefttIndex = 0;
            var rightIndex = cleanInput.Length - 1;
            do
            {
                if (cleanInput[lefttIndex] == cleanInput[rightIndex])
                {
                    lefttIndex++;
                    rightIndex--;
                }
                else
                {
                    return false;
                }

            } 
            while (lefttIndex < rightIndex);

            return true;

        }

        // ========================================================================
        // SAMPLE 2 REFACTOR: compare with IsValidPalindrome above
        // ========================================================================
        // Changes:
        //   - null check first, so null returns false instead of crashing
        //     on input.ToLower().
        //   - No cleanInput string. Building it allocates a new string the
        //     size of the input (Space O(n)). Here the pointers skip the
        //     characters we don't care about directly (Space O(1)).
        //   - No .Trim(): spaces aren't letters or digits, so they're skipped
        //     anyway.
        //   - Lower-case one char at a time with char.ToLowerInvariant.
        //
        //
        // WHY 2 WHILES INSIDE THE OUTER WHILE? (this is the key)
        //   - Outer while:   each round compares ONE PAIR of characters.
        //   - Inner while 1: keeps moving 'left' forward (left++) until it
        //                    lands on a letter or digit.
        //   - Inner while 2: keeps moving 'right' back (right--) until it
        //                    lands on a letter or digit.
        //   Skipping still MOVES the pointers: 'left' only goes forward,
        //   'right' only goes back, they never go back. Skipping just means
        //   moving a pointer without comparing anything.
        //
        // WHY IT'S STILL O(n) WITH LOOPS INSIDE A LOOP?
        //   Nested loops are often O(n^2), but not here. The inner loops don't
        //   start over each round, they continue from where the pointers are.
        //   'left' and 'right' together move at most n steps in total, so each
        //   character is visited at most once.
        //
        // WHY THE INNER WHILES ALSO CHECK left < right?
        //   With a string that is only junk, like ".,", 'left' would run past
        //   'right' (or past the end of the string). The extra check stops the
        //   pointers once they meet.
        //
        // TRACE: "a, b a"
        //   index:  0   1   2   3   4   5
        //   char:   a   ,  ' '  b  ' '  a
        //
        //   Round 1: left=0 'a' (no skip)   right=5 'a' (no skip)
        //            'a' == 'a' ✓ -> left=1, right=4
        //   Round 2: inner 1: ',' skip -> left=2, ' ' skip -> left=3 'b' stop
        //            inner 2: ' ' skip -> right=3 'b' stop
        //            'b' == 'b' ✓ -> left=4, right=2
        //   left < right is false -> loop ends -> true
        // ========================================================================
        public bool Sample2Refactor(string input)
        {
            if (input == null) return false;

            int left = 0;
            int right = input.Length - 1;

            while (left < right)
            {
                // inner 1: move 'left' forward past characters that aren't letters or digits
                while (left < right && !char.IsLetterOrDigit(input[left])) left++;
                // inner 2: move 'right' back past characters that aren't letters or digits
                while (left < right && !char.IsLetterOrDigit(input[right])) right--;

                // compare the pair, ignoring case

                if (char.ToLowerInvariant(input[left]) != char.ToLowerInvariant(input[right])) return false;

                // pair matched, move both pointers toward the middle
                left++;
                right--;
            }

            return true;
        }

        // ========================================================================
        // SAMPLE 3: Palindrome number (LeetCode 9) - without converting to string
        // ========================================================================
        // 121  -> true
        // -121 -> false (reads "121-" backwards)
        // 10   -> false (reads "01" backwards)
        //
        // Goal: Time O(log10 n), Space O(1)
        // Expected time to solve: 15 min
        // Result 1: takes me 20 minutues even i dont undestand the flow
        // Topic: Math (digit manipulation)
        // Tip:   number % 10 gives the last digit, number / 10 removes it.
        //        Build the reversed number digit by digit and compare.
        // ========================================================================
        public bool IsPalindromeNumber(int number)
        {
            // STEP 1: Rule out numbers that can never be palindromes
            //   - Negative: the '-' has no match at the other end (-121 -> "121-")
            //   - Ends in 0 (but isn't 0): no number starts with 0, so 10 -> "01" fails
            if (number < 0 || (number % 10 == 0 && number != 0)) return false;

            // STEP 2: Move digits from the END of 'number' to the END of 'reversed'
            //   number % 10  -> takes the last digit       (1234 % 10 = 4)
            //   number / 10  -> removes the last digit     (1234 / 10 = 123)
            //   reversed * 10 + digit -> appends the digit (12 * 10 + 3 = 123)
            //
            // We stop at the MIDDLE: once 'reversed' is >= 'number', we've moved
            // half the digits. No need to reverse the whole thing (also avoids
            // overflow on big numbers like 2147483647).
            //
            //   number = 1221           number = 12321
            //   number | reversed       number | reversed
            //   -------+---------       -------+---------
            //    1221  |    0           12321  |    0
            //     122  |    1            1232  |    1
            //      12  |   12  stop       123  |   12
            //                              12  |  123  stop
            int reversed = 0;
            while (number > reversed)
            {
                int lastDigit = number % 10;
                reversed = reversed * 10 + lastDigit;
                number /= 10;
            }

            // STEP 3: Compare the two halves
            //   - Even digit count: halves are equal     (12 == 12)
            //   - Odd digit count: 'reversed' holds the middle digit as its
            //     last digit, so drop it with / 10       (12 == 123 / 10)
            return number == reversed || number == reversed / 10;
        }
    }
}
