using System;
using System.Collections.Generic;
using System.Linq;
using TrainingLambdasAndLinq.POCOS;

namespace TrainingLambdasAndLinq.lambdasAndLinq.easy
{
    // ============================================================================
    // FIRST / FIRSTORDEFAULT (take one element)
    // ============================================================================
    // First(predicate)          -> first match. If there is NO match it throws
    //                              InvalidOperationException.
    // FirstOrDefault(predicate) -> first match, or default(T) if there is none
    //                              (0 for int, null for classes/strings).
    //
    // Both STOP as soon as they find a match (they don't scan the rest).
    //
    // Total practice time: ~35 min
    // 1 Round 20 min 
    // ============================================================================
    public class FirstExercises
    {
        // ========================================================================
        // SAMPLE 1: First number greater than a value
        // ========================================================================
        // ([1, 7, 3, 9], 5) -> 7
        // ([1, 2], 5)       -> throws InvalidOperationException
        //
        // Expected time to solve: 5 min
        // Topic: First with predicate
        // Tip:   Don't catch the exception, let First throw it. The test
        //        expects it.
        // ========================================================================
        public int GetFirstGreaterThan(int[] numbers, int value)
        {
             return numbers.First( number => number > value );
        }

        // ========================================================================
        // SAMPLE 2: First negative number, or 0 if there isn't one
        // ========================================================================
        // [3, -2, 5, -8] -> -2
        // [1, 2, 3]      -> 0
        // []             -> 0
        //
        // Expected time to solve: 5 min
        // Topic: FirstOrDefault with a value type
        // Tip:   default(int) is 0, so FirstOrDefault already returns 0.
        // ========================================================================
        public int GetFirstNegativeOrZero(int[] numbers)
        {
           return  numbers.FirstOrDefault( number => number < 0 );
        }

        // ========================================================================
        // SAMPLE 3: Find a person by name (ignore case)
        // ========================================================================
        // ([Ana, Luis, Sofia], "luis")  -> the Luis object
        // ([Ana, Luis, Sofia], "Pedro") -> null
        //
        // Expected time to solve: 5 min
        // Topic: FirstOrDefault with a reference type
        // Tip:   default(Person) is null. Use
        //        string.Equals(a, b, StringComparison.OrdinalIgnoreCase)
        // ========================================================================
        public Person FindPersonByName(List<Person> people, string name)
        {
            return people.FirstOrDefault( person =>  string.Equals(person.Name,name,StringComparison.OrdinalIgnoreCase));
        }

        // ========================================================================
        // SAMPLE 4: First word that starts with a letter, or "NOT FOUND"
        // ========================================================================
        // (["apple", "banana", "blueberry"], 'b') -> "banana"
        // (["apple"], 'z')                        -> "NOT FOUND"
        //
        // Expected time to solve: 10 min
        // Topic: FirstOrDefault + null-coalescing operator ??
        // Tip:   FirstOrDefault(...) ?? "NOT FOUND"
        //        Careful with empty strings: "" has no first character.
        // ========================================================================
        public string GetFirstWordStartingWith(string[] words, char letter)
        {
            // REFACTOR : words.FirstOrDefault(w => w.Length > 0 && w[0] == letter) ?? "NOT FOUND";
            return words.FirstOrDefault(s => s.StartsWith(letter.ToString())) ?? "NOT FOUND";
        }

        // ========================================================================
        // SAMPLE 5: Name of the first adult who lives in a city, or null
        // ========================================================================
        // ([Ana 15 Lima, Luis 30 Quito, Sofia 22 Lima, Pedro 40 Lima], "Lima")
        //   -> "Sofia"
        // ([Ana 15 Lima], "Lima") -> null
        //
        // Expected time to solve: 10 min
        // Topic: Where + First vs First(predicate), then take a property
        // Tip:   Solve it once with .Where(...).FirstOrDefault() and once with
        //        .FirstOrDefault(...) only. Same result, which reads better?
        //        If nobody matches, person is null: person?.Name avoids a crash.
        // ========================================================================
        public string GetFirstAdultNameInCity(List<Person> people, string city)
        {
            //REFACTOR:
            //people.Where(p => p.City == city && p.Age >= 18).FirstOrDefault()?.Name;   // Where + First
            //people.FirstOrDefault(p => p.City == city && p.Age >= 18)?.Name;           // First(predicate) only
            return people.Where(s=> s.City == city).FirstOrDefault( s=> s.Age >= 18)?.Name;
        }
    }
}
