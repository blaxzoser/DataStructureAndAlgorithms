using System;
using System.Collections.Generic;

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
        //
        // Result 1: 20 min, 2 of 10 tests fail (score 6/10): null input crashes
        //           because .Trim() / .Length run before the null checks.
        //           Main logic (count note, use up with magazine) is correct.
        // ========================================================================
        public bool CanConstruct(string note, string magazine)
        {
            if (note == null || magazine == null) return false;

            if (note?.Trim() == "" && !string.IsNullOrEmpty(magazine)) return true;

            if(note == null && !string.IsNullOrEmpty(magazine)) return false;

            if (note.Length == 1 && magazine?.Trim() == "") return false;

            if (!string.IsNullOrEmpty(note) && magazine == null) return false;

            if (!string.IsNullOrEmpty(magazine) && note == null) return false;


            var memory  = new Dictionary<char, int>();
            for(int i = 0; i < note.Length; i++)
            {
                if (!memory.ContainsKey(note[i]))
                {
                    memory.Add(note[i], 1);
                }

                else
                {
                    memory[note[i]]++;
                }
            }

            for (int y = 0; y < magazine.Length; y++)
            {
                if (memory.ContainsKey(magazine[y]))
                {
                    if(memory[magazine[y]] == 1)
                    {
                        memory.Remove(magazine[y]);
                    }
                    else
                    {
                        memory[magazine[y]]--;
                    }
                }
            }

            return memory.Count == 0;
        }
    }
}
