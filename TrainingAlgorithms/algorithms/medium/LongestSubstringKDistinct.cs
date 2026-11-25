using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainingAlgorithms.algorithms.medium
{
    // ============================================================================
    // LONGEST SUBSTRING WITH AT MOST K DISTINCT CHARACTERS (LeetCode 340)
    // ============================================================================
    // Next round of LongestSubstringWithoutRepeating. SAME sliding window, SAME
    // 'for right' + shrink 'while' + best = right - left + 1. What changes:
    //
    //   LongestSubstringWithoutRepeating      ->  this exercise
    //   ---------------------------------         ----------------------------
    //   no letter twice                       ->  letters CAN repeat, but at most
    //                                             k DIFFERENT letters in the window
    //   HashSet<char> (in / not in)           ->  Dictionary<char,int> (how many)
    //   shrink while letter is in the set     ->  shrink while counts.Count > k
    //
    // The Dictionary count is the one from ValidAnagram / RansomNote.
    //
    // Total practice time: ~20 min
    // ============================================================================
    public class LongestSubstringKDistinct
    {
        // ========================================================================
        // SAMPLE 1: Longest substring that has at most k different characters
        // ========================================================================
        // A substring is a CONTINUOUS piece of the string. Case sensitive.
        //
        // "eceba", k=2          -> 3   ("ece": only 'e' and 'c')
        // "aa", k=1             -> 2   ("aa": repeats are fine)
        // "abaccc", k=2         -> 4   ("accc", found AFTER a shrink)
        // "aabbcc", k=1         -> 2
        // "aabbcc", k=2         -> 4   ("aabb" or "bbcc")
        // "aabacbebebe", k=3    -> 7   ("cbebebe")
        // "abc", k=5            -> 3   (k bigger than the different letters: all)
        // "abc", k=0            -> 0   (no letters allowed)
        // "" or null            -> 0
        //
        //   "eceba", k=2      counts = letter -> how many times in the window
        //    [e]c e b a       {e:1}            size 1
        //    [e c]e b a       {e:1,c:1}        size 2
        //    [e c e]b a       {e:2,c:1}        size 3  <- best
        //    [e c e b]a       {e:2,c:1,b:1}    3 different > k -> shrink:
        //     e[c e b]a         drop 'e' -> {e:1,c:1,b:1}  still 3
        //     e c[e b]a         drop 'c' -> c is 0, REMOVE the key -> {e:1,b:1}
        //     e c e[b a]      ...same again when 'a' enters
        //
        // Difficulty: Medium
        // Goal: Time O(n), Space O(k)
        // Expected time to solve: 20 min
        // Pattern: Sliding window (LongestSubstringWithoutRepeating) + frequency
        //          count (ValidAnagram, RansomNote)
        // Topic: Strings + Hashing + Sliding window
        // Tip 1: Write LengthOfLongest from memory, then swap the HashSet for a
        //        Dictionary<char,int>. A letter ENTERS: counts[c] + 1 (start at 1
        //        if it's new). Shrink AFTER adding: while (counts.Count > k).
        // Tip 2: A letter LEAVES (text[left]): counts[c] - 1, and if it hits 0
        //        REMOVE the key, or counts.Count never goes down. Then left++.
        //        best = Math.Max(best, right - left + 1) after the while.
        // ========================================================================
        public int LengthOfLongest(string text, int k)
        {
            if (string.IsNullOrEmpty(text)) return 0;
            
           Dictionary<char,int> window = new Dictionary<char,int>();
           var left = 0;
           var bestSize = 0;
           
           for (int right = 0; right < text.Length; right++) {

                if (window.ContainsKey(text[right]))
                    window[text[right]]++;
                else
                    window[text[right]] = 1;


                // too many DIFFERENT letters → text[left] LEAVES
                while (window.Count > k)
                {
                    window[text[left]]--;
                    if (window[text[left]] == 0)
                        window.Remove(text[left]);   // gone from the window → one less different letter
                    left++;
                }

                bestSize = Math.Max(bestSize, right - left + 1);
            }

           return bestSize;
        }
    }
}
