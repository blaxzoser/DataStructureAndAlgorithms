using System;

namespace TrainingAlgorithms.algorithms.easy
{
    // ============================================================================
    // VALID ANAGRAM (LeetCode 242)
    // ============================================================================
    // Same frequency count as FirstUniqueCharacter, but comparing TWO strings.
    // The worked examples in Samples solve it by SORTING
    // (PermutationDetector) or with LINQ (StringProblems.IsAnagram).
    // Here: solve it with ONE count array, no sorting, no LINQ.
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class ValidAnagram
    {
        // ========================================================================
        // SAMPLE 1: Are the two strings anagrams?
        // ========================================================================
        // An anagram uses exactly the same characters, the same number of times,
        // in any order. Case sensitive, spaces count.
        //
        // ("anagram", "nagaram") -> true
        // ("listen",  "silent")  -> true
        // ("rat",     "car")     -> false
        // ("aacc",    "ccac")    -> false (same letters, different counts)
        // ("ab",      "abc")     -> false (different length)
        // ("",        "")        -> true
        // (null,      "a")       -> false
        //
        // Difficulty: Easy
        // Goal: Time O(n), Space O(1) (count array of fixed size)
        // Expected time to solve: 15 min
        // Pattern: Frequency count (builds on FirstUniqueCharacter)
        // Topic: Strings + Hashing
        // Tip 1: Different lengths can never be anagrams: check that first.
        // Tip 2: One int[128]: +1 for every char of the first string, -1 for every
        //        char of the second. Anagrams leave every count at 0.
        // ========================================================================
        public bool IsAnagram(string first, string second)
        {
            throw new NotImplementedException();
        }
    }
}
