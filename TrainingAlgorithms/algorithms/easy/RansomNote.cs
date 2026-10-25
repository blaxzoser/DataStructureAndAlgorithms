using System;

namespace TrainingAlgorithms.algorithms.easy
{
    // ============================================================================
    // RANSOM NOTE (LeetCode 383)
    // ============================================================================
    // Third round of the frequency count: like ValidAnagram, but the two
    // strings don't need the same length. The magazine can have EXTRA letters.
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class RansomNote
    {
        // ========================================================================
        // SAMPLE 1: Can the note be built with letters cut from the magazine?
        // ========================================================================
        // Each character of the magazine can be used only ONCE. Case sensitive.
        //
        // ("a",    "b")         -> false
        // ("aa",   "ab")        -> false (only one 'a' in the magazine)
        // ("aa",   "aab")       -> true
        // ("abc",  "cbaxyz")    -> true  (order doesn't matter, extras are fine)
        // ("Aa",   "aa")        -> false ('A' is not 'a')
        // ("",     "anything")  -> true  (empty note needs nothing)
        // ("a",    "")          -> false
        // (null,   "a")         -> false
        //
        // Difficulty: Easy
        // Goal: Time O(n + m), Space O(1) (count array of fixed size)
        // Expected time to solve: 15 min
        // Pattern: Frequency count (builds on ValidAnagram)
        // Topic: Strings + Hashing
        // Tip 1: Count the MAGAZINE first (what you have), then walk the note
        //        and use up one count per char (what you need).
        // Tip 2: The moment a count would go below 0 you're out of that letter:
        //        return false right away, no need to check the rest.
        // ========================================================================
        public bool CanConstruct(string note, string magazine)
        {
            throw new NotImplementedException();
        }
    }
}
