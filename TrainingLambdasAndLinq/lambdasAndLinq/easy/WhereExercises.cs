using System;
using System.Collections.Generic;
using System.Linq;
using TrainingLambdasAndLinq.POCOS;

namespace TrainingLambdasAndLinq.lambdasAndLinq.easy
{
    // ============================================================================
    // WHERE (filtering)
    // ============================================================================
    // Where keeps only the elements for which the lambda returns true.
    //   numbers.Where(n => n > 3)        [1, 5, 2, 8] -> [5, 8]
    //
    // It does NOT change the elements, it only decides who stays.
    // It is LAZY: nothing runs until you iterate (foreach, ToArray, ToList...).
    //
    // Total practice time: ~40 min
    // ============================================================================
    public class WhereExercises
    {
        // ========================================================================
        // SAMPLE 1: Even numbers
        // ========================================================================
        // [1, 2, 3, 4, 5, 6] -> [2, 4, 6]
        // [1, 3, 5]          -> []
        // []                 -> []
        //
        // Expected time to solve: 5 min
        // Topic: Where + simple predicate
        // Tip:   n % 2 == 0. Don't forget .ToArray() at the end.
        // ========================================================================
        public int[] GetEvenNumbers(int[] numbers)
        {
            
        }

        // ========================================================================
        // SAMPLE 2: Words longer than a given length
        // ========================================================================
        // (["apple", "fig", "banana", "kiwi"], 4) -> ["apple", "banana"]
        // (["a", "bb"], 5)                        -> []
        //
        // Expected time to solve: 5 min
        // Topic: Where + using a method parameter inside the lambda (closure)
        // Tip:   The lambda can "see" minLength even though it's not one of
        //        its own parameters. That is called a closure.
        // ========================================================================
        public string[] GetWordsLongerThan(string[] words, int minLength)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 3: Adults (objects instead of numbers)
        // ========================================================================
        // Return every person with Age >= 18, in the same order.
        // [Ana 17, Luis 30, Sofia 18, Pedro 12] -> [Luis, Sofia]
        //
        // Expected time to solve: 5 min
        // Topic: Where over a List of objects
        // Tip:   p => p.Age >= 18. Return a List, so use .ToList().
        // ========================================================================
        public List<Person> GetAdults(List<Person> people)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 4: Several conditions in the same lambda
        // ========================================================================
        // People who live in 'city' AND are older than 'minAge' (strictly).
        // City comparison ignores case ("lima" == "Lima").
        //
        // ([Ana 25 Lima, Luis 30 Quito, Sofia 40 lima, Pedro 20 Lima], "Lima", 21)
        //   -> [Ana, Sofia]
        //
        // Expected time to solve: 10 min
        // Topic: Where + && + string comparison
        // Tip:   string.Equals(a, b, StringComparison.OrdinalIgnoreCase)
        //        You can also chain two Where calls. Try both and compare.
        // ========================================================================
        public List<Person> GetPeopleFromCityOlderThan(List<Person> people, string city, int minAge)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 5: Filter by POSITION (Where with index)
        // ========================================================================
        // Keep the elements at even positions (0, 2, 4...).
        // ["a", "b", "c", "d", "e"] -> ["a", "c", "e"]
        // ["x"]                     -> ["x"]
        //
        // Expected time to solve: 10 min
        // Topic: Where overload (element, index) => ...
        // Tip:   Where has a second version where the lambda receives TWO
        //        parameters: the element and its index.
        //        words.Where((word, index) => ...)
        // ========================================================================
        public string[] GetElementsAtEvenIndex(string[] words)
        {
            throw new NotImplementedException();
        }
    }
}
