using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace Samples.questions.lambdas
{
    public class StringProblems
    {
        //Return a method that delete all special characters and spaces
        public string CleanString(string str)
        {             
           // CORRECT APPROACH: Use Where to filter
           return string.Join("", str.Where(Char.IsLetterOrDigit));
           
           // ========================================================================
           // WHY Select() IS WRONG - Detailed Explanation:
           // ========================================================================
           // YES, Select() DOES iterate through each character one by one ✓
           // BUT Select() TRANSFORMS each element, it doesn't FILTER!
           //
           // Select() = TRANSFORM (char → bool)
           // Where() = FILTER (keep/remove based on condition)
           //
           // VISUAL EXAMPLE with input: "Hi, 123!"
           //
           // Select(char.IsLetterOrDigit) - TRANSFORMS each char to bool:
           //   'H' → IsLetterOrDigit('H') → true
           //   'i' → IsLetterOrDigit('i') → true  
           //   ',' → IsLetterOrDigit(',') → false
           //   ' ' → IsLetterOrDigit(' ') → false
           //   '1' → IsLetterOrDigit('1') → true
           //   '2' → IsLetterOrDigit('2') → true
           //   '3' → IsLetterOrDigit('3') → true
           //   '!' → IsLetterOrDigit('!') → false
           //
           // Result: [true, true, false, false, true, true, true, false]
           // Type: IEnumerable<bool> ❌
           // Problem: Method signature requires string, not IEnumerable<bool>!
           //
           // Where(Char.IsLetterOrDigit) - FILTERS (keeps only matching chars):
           //   'H' → IsLetterOrDigit('H') → true → KEEP 'H'
           //   'i' → IsLetterOrDigit('i') → true → KEEP 'i'
           //   ',' → IsLetterOrDigit(',') → false → REMOVE ','
           //   ' ' → IsLetterOrDigit(' ') → false → REMOVE ' '
           //   '1' → IsLetterOrDigit('1') → true → KEEP '1'
           //   '2' → IsLetterOrDigit('2') → true → KEEP '2'
           //   '3' → IsLetterOrDigit('3') → true → KEEP '3'
           //   '!' → IsLetterOrDigit('!') → false → REMOVE '!'
           //
           // Result: ['H', 'i', '1', '2', '3']
           // Type: IEnumerable<char> → string.Join converts to "Hi123" ✓
           //
           // return str.Select(char.IsLetterOrDigit);  // ❌ Returns IEnumerable<bool>, not string!
        }

        // ========================================================================
        // EXERCISE 1: Count Vowels in String
        // ========================================================================
        // Write a method that counts the number of vowels (a, e, i, o, u) in a string.
        // Use lambda expressions and LINQ methods.
        // 
        // Example:
        // Input: "Hello World"
        // Output: 3 (e, o, o)
        //
        // Hint: Use Count() with a lambda expression
        public int CountVowels(string str)
        {            
            return str.ToLower().Trim().Count(s => s == 'a' || s == 'e' || s == 'i' || s == 'o' || s == 'u');
        }

        // ========================================================================
        // EXERCISE 2: Reverse Words in String
        // ========================================================================
        // Write a method that reverses the order of words in a string.
        // Use lambda expressions and LINQ methods.
        //
        // Example:
        // Input: "the sky is blue"
        // Output: "blue is sky the"
        //
        // Example 2:
        // Input: "  hello world  "
        // Output: "world hello" (trim extra spaces)
        //
        // Hint: Use Split(), Reverse(), and string.Join()
        public string ReverseWords(string str)
        {         
            return string.Join(" ",str.Split(' ').Reverse());
        }

        // ========================================================================
        // EXERCISE 3: Find Most Frequent Character
        // ========================================================================
        // Write a method that finds the most frequently occurring character in a string.
        // If there's a tie, return the character that appears first alphabetically.
        // Use lambda expressions and LINQ methods.
        //
        // Example:
        // Input: "programming"
        // Output: 'g' (appears 2 times, and 'r' comes after 'g' alphabetically)
        //
        // Example 2:
        // Input: "aabbcc"
        // Output: 'a' (all appear twice, 'a' is first alphabetically)
        //
        // Hint: Use GroupBy(), OrderByDescending(), ThenBy()
        public char FindMostFrequentChar(string str)
        {
            // CLUE: You've grouped the characters, great start! ✓
            // Now think about:
            //   1. After GroupBy, you have groups. Each group has a Key (the character) and a collection of that character.
            //  "programming" → GroupBy → 
            //  Groups: [('p', [p]), ('r', [r, r]), ('o', [o]), ('g', [g, g]), ...]
            //  → Count each group → 
            //  [('p', 1), ('r', 2), ('o', 1), ('g', 2), ...]
            //  → Order by count DESC, then by char ASC →
            //  [('r', 2), ('g', 2), ('p', 1), ...]
            //  → First() → ('g', 2) → Key → 'g' ✓


            //   2. You need to know the COUNT of each group (how many times each character appears)
            //   3. Then ORDER by that count (most frequent first) using OrderByDescending()
            //   4. If counts are equal, use ThenBy() to sort by the character itself (alphabetically)
            //   5. Finally, get the FIRST one and extract its Key (the character)
            //
            // Think about: Select() to transform groups, Count() to count, First() to get first element
            return str.GroupBy(s => s)
                      // CLUE FOR LINE 131: You're creating an anonymous object - good! ✓
                      // But check the syntax: when creating anonymous objects with { }, 
                      // you use = (equals) not => (lambda arrow)
                      // 
                      // Current: count => r.Count()  ❌ (this is lambda syntax, not object property)
                      // Should be: count = r.Count()  ✓ (this is property assignment)
                      //
                      // Also think: after Select(), you have objects with 'key' and 'count' properties
                      // How will you ORDER by the count? What property should you use in OrderByDescending()?
                      .Select(r => new { key = r.Key, count = r.Count() })
                      // CLUE FOR LINE 132: OrderByDescending needs to know WHAT to order by
                      // You can't order by the whole object (x => x), you need to order by a property
                      // Which property contains the frequency count?
                      .OrderByDescending(x => x.count)
                      .ThenBy(x => x.key)
                      // CLUE FOR LINE 133: FirstOrDefault() with a predicate is for filtering
                      // But you've already ordered, so you just need the FIRST element
                      // Then extract the 'key' property (the character) from that first element
                      //
                      // ⚠️ POTENTIAL ISSUE: FirstOrDefault() can return null if the collection is empty!
                      // If str is empty or null, GroupBy returns empty, FirstOrDefault() returns null,
                      // and accessing .key on null will throw NullReferenceException!
                      //
                      // For non-empty strings, FirstOrDefault() should work, but consider:
                      // - Use First() if you're sure the string is not empty
                      // - Or handle null case: .FirstOrDefault()?.key ?? default(char)
                      //
                      // DEBUGGING TIP: In "programming", characters with count=2 are: r, g, m
                      // Alphabetically: g < m < r
                      // So ThenBy(x => x.key) should put 'g' first, not 'r'
                      // If test expects 'r', check if the requirement means something else!
                      //
                      // 🔍 TO DEBUG: Add this temporary code to see what's happening:
                      // var debug = str.GroupBy(s => s)
                      //     .Select(r => new { key = r.Key, count = r.Count() })
                      //     .OrderByDescending(x => x.count)
                      //     .ThenBy(x => x.key)
                      //     .ToList();
                      // // Check: debug[0].key should be 'g', but test expects 'r'
                      //
                      // 💡 POSSIBLE FIXES:
                      // 1. If requirement is "first alphabetically": current code is correct, test might be wrong
                      // 2. If requirement is "first occurrence in string": need different approach
                      // 3. Check if FirstOrDefault() is returning null (would cause exception)
                      .First().key;
                    // TODO: Continue the chain...
                    // Step 1: Transform groups to include count
                    // Step 2: Order by count (descending), then by character (ascending)
                    // Step 3: Get first element
                    // Step 4: Extract the character (Key)
        }

        // ========================================================================
        // EXERCISE 4: Check if String Contains Only Unique Characters
        // ========================================================================
        // Write a method that returns true if all characters in the string are unique (no duplicates).
        // Use lambda expressions and LINQ methods.
        //
        // Example:
        // Input: "abcdef"
        // Output: true (all characters are unique)
        //
        // Example 2:
        // Input: "hello"
        // Output: false (contains duplicate 'l')
        //
        // Hint: Use Distinct() and compare lengths
        public bool HasAllUniqueCharacters(string str)
        {
            // TODO: Implement using lambda and LINQ
            throw new NotImplementedException();
        }

        // ========================================================================
        // EXERCISE 5: Remove Duplicate Characters
        // ========================================================================
        // Write a method that removes duplicate characters from a string, keeping only the first occurrence.
        // Use lambda expressions and LINQ methods.
        //
        // Example:
        // Input: "programming"
        // Output: "progamin" (removed duplicate 'r', 'm', 'g')
        //
        // Example 2:
        // Input: "aabbcc"
        // Output: "abc"
        //
        // Hint: Use Distinct() or GroupBy()
        public string RemoveDuplicates(string str)
        {
            // TODO: Implement using lambda and LINQ
            throw new NotImplementedException();
        }

        // ========================================================================
        // EXERCISE 6: Count Character Frequency Dictionary
        // ========================================================================
        // Write a method that returns a dictionary where keys are characters and values are their frequencies.
        // Use lambda expressions and LINQ methods.
        //
        // Example:
        // Input: "hello"
        // Output: Dictionary { {'h', 1}, {'e', 1}, {'l', 2}, {'o', 1} }
        //
        // Hint: Use GroupBy() and ToDictionary()
        public Dictionary<char, int> GetCharacterFrequency(string str)
        {
            // TODO: Implement using lambda and LINQ
            throw new NotImplementedException();
        }

        // ========================================================================
        // EXERCISE 7: Capitalize First Letter of Each Word
        // ========================================================================
        // Write a method that capitalizes the first letter of each word in a string.
        // Use lambda expressions and LINQ methods.
        //
        // Example:
        // Input: "hello world"
        // Output: "Hello World"
        //
        // Example 2:
        // Input: "  multiple   spaces  "
        // Output: "  Multiple   Spaces  " (preserve spaces)
        //
        // Hint: Use Select() with index, or Split() and Select()
        public string CapitalizeWords(string str)
        {
            // TODO: Implement using lambda and LINQ
            throw new NotImplementedException();
        }

        // ========================================================================
        // EXERCISE 8: Check if String is Anagram
        // ========================================================================
        // Write a method that checks if two strings are anagrams (contain same characters in different order).
        // Use lambda expressions and LINQ methods.
        // Ignore case and spaces.
        //
        // Example:
        // Input: "listen", "silent"
        // Output: true
        //
        // Example 2:
        // Input: "hello", "world"
        // Output: false
        //
        // Example 3:
        // Input: "The Morse Code", "Here come dots"
        // Output: true (ignoring case and spaces)
        //
        // Hint: Use OrderBy() to sort characters, then compare
        public bool IsAnagram(string str1, string str2)
        {
            // TODO: Implement using lambda and LINQ
            throw new NotImplementedException();
        }

        // ========================================================================
        // EXERCISE 9: Find Longest Word
        // ========================================================================
        // Write a method that finds the longest word in a string.
        // If multiple words have the same length, return the first one.
        // Use lambda expressions and LINQ methods.
        //
        // Example:
        // Input: "The quick brown fox jumps"
        // Output: "quick" (or "brown" or "jumps" - all have 5 characters, return first)
        //
        // Example 2:
        // Input: "programming is fun"
        // Output: "programming"
        //
        // Hint: Use Split(), OrderByDescending(), or Aggregate()
        public string FindLongestWord(string str)
        {
            // TODO: Implement using lambda and LINQ
            throw new NotImplementedException();
        }

        // ========================================================================
        // EXERCISE 10: Remove Characters at Odd Indices
        // ========================================================================
        // Write a method that removes all characters at odd indices (1, 3, 5, ...).
        // Use lambda expressions and LINQ methods.
        //
        // Example:
        // Input: "abcdef"
        // Output: "ace" (kept indices 0, 2, 4)
        //
        // Example 2:
        // Input: "Hello"
        // Output: "Hlo"
        //
        // Hint: Use Select() with index parameter, or Where() with index
        public string RemoveOddIndexCharacters(string str)
        {
            // TODO: Implement using lambda and LINQ
            throw new NotImplementedException();
        }

        // ========================================================================
        // EXERCISE 11: Group Words by Length
        // ========================================================================
        // Write a method that groups words by their length and returns a dictionary.
        // Use lambda expressions and LINQ methods.
        //
        // Example:
        // Input: "I am learning C# programming"
        // Output: Dictionary {
        //   {1, ["I"]},
        //   {2, ["am", "C#"]},
        //   {8, ["learning", "programming"]}
        // }
        //
        // Hint: Use Split(), GroupBy(), ToDictionary()
        public Dictionary<int, List<string>> GroupWordsByLength(string str)
        {
            // TODO: Implement using lambda and LINQ
            throw new NotImplementedException();
        }

        // ========================================================================
        // EXERCISE 12: Check if String is Palindrome (ignoring case and non-alphanumeric)
        // ========================================================================
        // Write a method that checks if a string is a palindrome, ignoring case and non-alphanumeric characters.
        // Use lambda expressions and LINQ methods.
        //
        // Example:
        // Input: "A man, a plan, a canal: Panama"
        // Output: true (reads same forwards and backwards: "amanaplanacanalpanama")
        //
        // Example 2:
        // Input: "race a car"
        // Output: false
        //
        // Hint: Use Where() to filter, then compare with reversed sequence
        public bool IsPalindromeIgnoreCaseAndSpecial(string str)
        {
            // TODO: Implement using lambda and LINQ
            throw new NotImplementedException();
        }

        // ========================================================================
        // EXERCISE 13: Find All Substrings of Given Length
        // ========================================================================
        // Write a method that returns all substrings of a given length from a string.
        // Use lambda expressions and LINQ methods.
        //
        // Example:
        // Input: "hello", length = 3
        // Output: ["hel", "ell", "llo"]
        //
        // Example 2:
        // Input: "abc", length = 2
        // Output: ["ab", "bc"]
        //
        // Hint: Use Enumerable.Range() with Select() and Substring()
        public List<string> GetAllSubstrings(string str, int length)
        {
            // TODO: Implement using lambda and LINQ
            throw new NotImplementedException();
        }

        // ========================================================================
        // EXERCISE 14: Sort Characters by Frequency (Descending)
        // ========================================================================
        // Write a method that sorts characters in a string by their frequency (most frequent first).
        // If frequencies are equal, maintain original order.
        // Use lambda expressions and LINQ methods.
        //
        // Example:
        // Input: "tree"
        // Output: "eetr" or "eert" (e appears twice, t and r appear once)
        //
        // Example 2:
        // Input: "cccaaa"
        // Output: "cccaaa" or "aaaccc" (both c and a appear 3 times)
        //
        // Hint: Use GroupBy(), OrderByDescending(), SelectMany()
        public string SortByFrequency(string str)
        {
            // TODO: Implement using lambda and LINQ
            throw new NotImplementedException();
        }

        // ========================================================================
        // EXERCISE 15: Replace All Occurrences Using Lambda
        // ========================================================================
        // Write a method that replaces all occurrences of a character with another character.
        // Use lambda expressions and LINQ methods (don't use string.Replace()).
        //
        // Example:
        // Input: "hello world", oldChar = 'l', newChar = 'x'
        // Output: "hexxo worxd"
        //
        // Hint: Use Select() with ternary operator
        public string ReplaceCharacter(string str, char oldChar, char newChar)
        {
            // TODO: Implement using lambda and LINQ (don't use string.Replace())
            throw new NotImplementedException();
        }
    }
}
