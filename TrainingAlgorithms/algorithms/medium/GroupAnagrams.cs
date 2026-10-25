using System;
using System.Collections.Generic;

namespace TrainingAlgorithms.algorithms.medium
{
    // ============================================================================
    // GROUP ANAGRAMS (LeetCode 49)
    // ============================================================================
    // Builds on ValidAnagram: instead of comparing 2 words, put MANY words into
    // groups of anagrams. The new idea: give every word a KEY that is the same
    // for all its anagrams, and group by that key in a Dictionary.
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class GroupAnagrams
    {
        // ========================================================================
        // SAMPLE 1: Group the words that are anagrams of each other
        // ========================================================================
        // Return the groups in any order; the words inside a group in any order.
        // Case sensitive.
        //
        // ["eat","tea","tan","ate","nat","bat"]
        //   -> [["eat","tea","ate"], ["tan","nat"], ["bat"]]
        // ["abc","bca","cab","xyz"] -> [["abc","bca","cab"], ["xyz"]]
        // [""]                      -> [[""]]
        // ["a"]                     -> [["a"]]
        // [] or null                -> []
        //
        //   word    key (sorted letters)
        //   "eat"   "aet"  ┐
        //   "tea"   "aet"  ├─ same key -> same group
        //   "ate"   "aet"  ┘
        //   "tan"   "ant"  ┐
        //   "nat"   "ant"  ┘
        //   "bat"   "abt"  -> its own group
        //
        // Difficulty: Medium
        // Goal: Time O(n * k log k) (n words, k = longest word), Space O(n * k)
        // Expected time to solve: 15 min
        // Pattern: Frequency / grouping with a Dictionary (builds on ValidAnagram)
        // Topic: Strings + Hashing + Sorting
        // Tip 1: Key = the word's letters sorted: ToCharArray(), Array.Sort(chars),
        //        new string(chars). All anagrams get the same key.
        // Tip 2: Dictionary<string, List<string>>: if the key isn't there yet,
        //        add a new empty list. Then add the word to that key's list.
        //        At the end, return the dictionary's values.
        // ========================================================================
        public IList<IList<string>> Group(string[] words)
        {
            throw new NotImplementedException();
        }
    }
}
