using System;
using System.Collections.Generic;

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
        //
        // Result 1: 20 min, 3 of 11 tests fail (score 5/10). Add(c, i) stores the
        //           index instead of 1, and the 2nd loop reads source[i] (first
        //           string) instead of second[i].
        // ========================================================================
        public bool IsAnagram(string first, string second)
        {
            if (first == "" && second == "")
                return true;

            if(string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second)) 
                return false;

            if(first.Length != second.Length) return false;
          

            Dictionary<char,int> dicc = new Dictionary<char, int>();
            for (int i = 0; i < first.Length; i++) {
                if (!dicc.ContainsKey(first[i]))
                {
                    dicc.Add(first[i], 1);
                }
                else
                {
                    dicc[first[i]] = dicc[first[i]] + 1;
                }               
            }

            for (int i = 0; i < second.Length; i++)
            {
                if (!dicc.ContainsKey(second[i]))
                {
                    return false;
                }
                else
                {
                    if (dicc[second[i]] == 1)
                    {
                        dicc.Remove(second[i]);
                    }
                    else
                    {
                        dicc[second[i]] += -1;
                    }
                }
            }

            return dicc.Count == 0;               
        }
    }
}
