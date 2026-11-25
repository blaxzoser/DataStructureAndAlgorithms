using System;
using System.Collections.Generic;

namespace TrainingAlgorithms.algorithms.medium
{
    // ============================================================================
    // LONGEST RUN OF UNIQUE WORDS (rep 2 of LongestSubstringWithoutRepeating)
    // ============================================================================
    // Same skeleton as LengthOfLongest, line for line. Same HashSet, same
    // 'while (Contains)' BEFORE adding, same Remove(left), same best.
    //
    //   THE ONE CHANGE:   split the sentence into words FIRST, then run the
    //                     same loop over the words (HashSet<string>).
    //
    // Total practice time: ~10-15 min
    // ============================================================================
    public class LongestUniqueWords
    {
        // ========================================================================
        // SAMPLE 1: How many words in the longest run of consecutive different words
        // ========================================================================
        // Words are separated by ONE space. Case sensitive ("The" != "the").
        //
        // "the cat the dog"          -> 3   ("cat the dog")
        // "go go go"                 -> 1
        // "a b c a b c b b"          -> 3   (like "abcabcbb", one word per letter)
        // "one two two three four"   -> 3   ("two three four", AFTER a shrink)
        // "red blue blue red"        -> 2   (like "abba")
        // "I like it"                -> 3   (no repeats: all the words)
        // "The the"                  -> 2   (different case = different words)
        // "hello"                    -> 1
        // "" or null                 -> 0
        //
        // Difficulty: Medium (rep)
        // Goal: Time O(n), Space O(n)
        // Expected time to solve: 10-15 min
        // Pattern: Sliding window + Seen set (LongestSubstringWithoutRepeating)
        // Topic: Strings + Hashing + Sliding window
        // Tip 1: Check string.IsNullOrEmpty(sentence) first, then
        //        string[] words = sentence.Split(' ');
        //        From here it's LengthOfLongest with words[right] / words[left].
        // Tip 2: Inside the while, EVERY line uses left:
        //        memory.Remove(words[left]); left++;
        //        best = Math.Max(best, right - left + 1) counts WORDS, not letters.
        // ========================================================================
        public int LengthOfLongest(string sentence)
        {
            throw new NotImplementedException();
        }
    }
}
