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
        //
        // Result 1: 20 min (ReverseOnlyLetters took 40), loop from memory with
        //           helper IsVowel. Fixed: text.ToString() -> new string(text),
        //           removed input.ToLower() (it lower-cased the output too)
        // ========================================================================
        public string Reverse(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            char[] text = input.ToCharArray();
            int left = 0;
            int right = input.Length - 1;
            while (left < right) {
                while (left < right && !IsVowel(text[left])) 
                {
                    left++;
                }

                while (left < right && !IsVowel(text[right]))
                {
                    right--;
                }

                var tempA = text[left];
                var tempB = text[right];
                text[left] = tempB;
                text[right] = tempA;

                left++;
                right--;
            }

            return new string(text);
        }

        private bool IsVowel(char c)        
        {
            return "aeiouAEIOU".IndexOf(c) >= 0;
        }
    }
}
