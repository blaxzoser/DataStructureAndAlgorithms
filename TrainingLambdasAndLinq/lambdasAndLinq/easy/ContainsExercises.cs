using System;
using System.Collections.Generic;
using System.Linq;
using TrainingLambdasAndLinq.POCOS;

namespace TrainingLambdasAndLinq.lambdasAndLinq.easy
{
    // ============================================================================
    // CONTAINS / ANY / ALL (asking yes-or-no questions)
    // ============================================================================
    // Contains(value)  -> true if the collection has that exact value.
    // Any(predicate)   -> true if AT LEAST ONE element matches.
    // All(predicate)   -> true if EVERY element matches (true for an empty list!).
    //
    // All three STOP as soon as they know the answer.
    //
    // Interview classic: list.Contains(x) inside a Where is the C# version of
    // SQL "WHERE x IN (...)". With Entity Framework it becomes exactly that.
    //
    // Total practice time: ~40 min
    // ============================================================================
    public class ContainsExercises
    {
        // ========================================================================
        // SAMPLE 1: Does the array have the number?
        // ========================================================================
        // ([1, 5, 9], 5) -> true
        // ([1, 5, 9], 4) -> false
        // ([], 1)        -> false
        //
        // Expected time to solve: 3 min
        // Topic: Contains on an array
        // Tip:   One method call. Then solve it again with Any(...) and
        //        think about when you would need Any instead of Contains.
        // ========================================================================
        public bool HasNumber(int[] numbers, int target)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 2: Count the vowels (based on Samples StringProblems)
        // ========================================================================
        // "hello"         -> 2
        // "AEIOU"         -> 5
        // "rhythm"        -> 0
        // ""              -> 0
        //
        // Expected time to solve: 5 min
        // Topic: Contains on a string + Count(predicate)
        // Tip:   "aeiou".Contains(c) works because a string is a collection of
        //        chars. Count(predicate) is a Where + Count in one call.
        //        Don't forget uppercase letters.
        // ========================================================================
        public int CountVowels(string text)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 3: Array difference (CodeWars, based on Samples ArrayDiff)
        // ========================================================================
        // Remove from 'a' EVERY value that appears in 'b'. Keep the order.
        // ([1, 2, 2, 3], [2])  -> [1, 3]
        // ([1, 2, 3], [])      -> [1, 2, 3]
        // ([], [1])            -> []
        //
        // Expected time to solve: 5 min
        // Topic: Where + !Contains
        // Tip:   Careful: a.Except(b) looks like the answer but it ALSO removes
        //        duplicates from 'a'. ([1, 1, 3], [2]) must give [1, 1, 3].
        // ========================================================================
        public int[] ArrayDiff(int[] a, int[] b)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 4: Is it a pangram? (based on Samples Parangram)
        // ========================================================================
        // A pangram uses every letter a-z at least once (case doesn't matter).
        // "The quick brown fox jumps over the lazy dog" -> true
        // "Hello world"                                 -> false
        //
        // Expected time to solve: 10 min
        // Topic: All + Contains
        // Tip:   Think backwards: don't loop over the sentence, loop over the
        //        alphabet. "Do ALL letters appear in the sentence?"
        //        Lower-case the sentence ONCE, outside the lambda.
        // ========================================================================
        public bool IsPangram(string sentence)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 5: People who live in any of the given cities (SQL "IN")
        // ========================================================================
        // ([Ana Lima, Luis Quito, Sofia Cusco, Pedro Lima], ["Lima", "Cusco"])
        //   -> [Ana, Sofia, Pedro]
        // (people, [])  -> []
        //
        // Expected time to solve: 5 min
        // Topic: Where + Contains on a second collection
        // Tip:   Here Contains is called on 'cities', not on the person.
        //        people.Where(p => cities.Contains(...))
        // ========================================================================
        public List<Person> GetPeopleFromCities(List<Person> people, string[] cities)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 6: Is the text binary? (based on Samples Patterns)
        // ========================================================================
        // Comma-separated values. True if every value is "0" or "1".
        // "1,0,1,1" -> true
        // "1,0,2"   -> false
        // "1"       -> true
        //
        // Expected time to solve: 5 min
        // Topic: All vs Any (they are opposites)
        // Tip:   Solve it with All(...). Then solve it with !Any(...).
        //        "All are binary" == "There isn't any that is not binary".
        // ========================================================================
        public bool IsBinary(string text)
        {
            throw new NotImplementedException();
        }
    }
}
