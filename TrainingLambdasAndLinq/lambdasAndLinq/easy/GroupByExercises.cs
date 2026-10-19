using System;
using System.Collections.Generic;
using System.Linq;
using TrainingLambdasAndLinq.POCOS;

namespace TrainingLambdasAndLinq.lambdasAndLinq.easy
{
    // ============================================================================
    // GROUPBY (putting elements into buckets)
    // ============================================================================
    // GroupBy(keySelector) puts every element into a bucket by its key.
    // Each bucket is an IGrouping<TKey, TElement>:
    //   - g.Key      -> the value they share
    //   - g itself   -> the elements in that bucket (you can Count, Select...)
    //
    //   ["ant", "bee", "ape"].GroupBy(w => w[0])
    //     'a' -> ["ant", "ape"]
    //     'b' -> ["bee"]
    //
    // Groups come out in the order their key is FIRST seen.
    //
    // Interview classic: "count how many times each X appears" =
    //   GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count())
    //
    // Total practice time: ~45 min
    // ============================================================================
    public class GroupByExercises
    {
        // ========================================================================
        // SAMPLE 1: Character frequency (based on Samples StringProblems)
        // ========================================================================
        // "hello" -> { 'h': 1, 'e': 1, 'l': 2, 'o': 1 }
        // ""      -> { }
        //
        // Expected time to solve: 5 min
        // Topic: GroupBy + ToDictionary
        // Tip:   Group each char by itself (c => c). The key is the char,
        //        the size of the group is how many times it appears.
        // ========================================================================
        public Dictionary<char, int> CharFrequency(string text)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 2: Find the duplicates
        // ========================================================================
        // Return each value that appears MORE than once, only once, in the
        // order it first appears.
        // [4, 1, 4, 2, 1, 4] -> [4, 1]
        // [1, 2, 3]          -> []
        //
        // Expected time to solve: 10 min
        // Topic: GroupBy + Where on the groups + Select the Key
        // Tip:   After GroupBy you are filtering GROUPS, not numbers:
        //        .Where(g => g.Count() > 1)
        // ========================================================================
        public int[] GetDuplicates(int[] numbers)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 3: Group people by city
        // ========================================================================
        // [Ana Lima, Luis Quito, Sofia Lima]
        //   -> { "Lima": ["Ana", "Sofia"], "Quito": ["Luis"] }
        //
        // Expected time to solve: 10 min
        // Topic: GroupBy on a property + ToDictionary with a Select inside
        // Tip:   ToDictionary(g => g.Key, g => ...). The value is the list of
        //        NAMES, so the group (Person objects) needs a Select.
        //        Bonus: look at GroupBy(p => p.City, p => p.Name), the
        //        second lambda picks what goes inside each bucket.
        // ========================================================================
        public Dictionary<string, List<string>> GroupNamesByCity(List<Person> people)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 4: Most frequent character (based on Samples FindMostFrequentChar)
        // ========================================================================
        // Ignore spaces. If there is a tie, return the one that appears first.
        // "hello world" -> 'l'
        // "aabb"        -> 'a'   (tie: 'a' comes first)
        // "x"           -> 'x'
        //
        // Expected time to solve: 10 min
        // Topic: Where + GroupBy + OrderByDescending + First
        // Tip:   OrderByDescending is STABLE: when two groups have the same
        //        count, it keeps their original order. And GroupBy keeps the
        //        order the keys first appear. Together they solve the tie.
        // ========================================================================
        public char GetMostFrequentChar(string text)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 5: Words grouped by length, as text
        // ========================================================================
        // Sort the groups by length (shortest first). Inside a group keep the
        // original word order. Format: "<length>: word, word"
        // ["cat", "horse", "dog", "bird", "ox"]
        //   -> ["2: ox", "3: cat, dog", "4: bird", "5: horse"]
        //
        // Expected time to solve: 10 min
        // Topic: GroupBy + OrderBy on the Key + Select to format each group
        // Tip:   string.Join(", ", group) joins the words of one group.
        //        Use $"{g.Key}: ..." to build each line.
        // ========================================================================
        public List<string> GroupWordsByLength(string[] words)
        {
            throw new NotImplementedException();
        }
    }
}
