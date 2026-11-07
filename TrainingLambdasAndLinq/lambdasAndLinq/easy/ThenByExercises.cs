using System;
using System.Collections.Generic;
using System.Linq;
using TrainingLambdasAndLinq.POCOS;

namespace TrainingLambdasAndLinq.lambdasAndLinq.easy
{
    // ============================================================================
    // THENBY / THENBYDESCENDING (sort by one thing, then break the ties)
    // ============================================================================
    // OrderBy(key1).ThenBy(key2)   -> sort by key1; ONLY when key1 is equal,
    //                                 sort those equal ones by key2.
    //
    // Think of a phone book: sort by LAST name, and for the same last name
    // sort by FIRST name.
    //
    //   OrderBy(a)                 -> the main sort
    //   ThenBy(b)                  -> tie-break, ascending (A-Z, small -> big)
    //   ThenByDescending(b)        -> tie-break, descending (Z-A, big -> small)
    //   OrderByDescending(a)       -> main sort, descending
    //
    // THE CLASSIC MISTAKE: two OrderBy in a row.
    //   words.OrderBy(w => w.Length).OrderBy(w => w)
    //   The second OrderBy sorts everything again and THROWS AWAY the first sort.
    //   Only the last OrderBy wins. For a tie-break you need ThenBy.
    //
    // ThenBy can only come AFTER an OrderBy / OrderByDescending (or another
    // ThenBy). It does not exist on a plain list.
    //
    // Sort keys can be: a number, a string, a char, even a bool
    // (false comes BEFORE true, so OrderBy(x => isOdd) puts the evens first).
    //
    // Strings: use StringComparer.Ordinal in the tests' mind: "A-Z" here means
    // plain letter order, same as the other sorting exercises.
    //
    // Total practice time: ~85 min (10 exercises, easy to medium)
    // ============================================================================
    public class ThenByExercises
    {
        // ========================================================================
        // SAMPLE 1: Words by length, ties A-Z
        // ========================================================================
        // (["pear", "fig", "apple", "kiwi", "date"])
        //   -> ["fig", "date", "kiwi", "pear", "apple"]
        //   (3 letters: fig | 4 letters: date, kiwi, pear in A-Z | 5 letters: apple)
        // ([])  -> []
        //
        // Difficulty: Easy
        // Expected time to solve: 5 min
        // Topic: OrderBy + ThenBy on the SAME element (the word is its own key)
        // Tip 1: First key = w.Length. Second key = the word itself (w => w).
        // Tip 2: Try OrderBy(Length).OrderBy(w => w) and see which test fails.
        //        That is the "two OrderBy" mistake from the header.
        // ========================================================================
        public List<string> SortWordsByLength(string[] words)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 2: People by age, ties by name (return the names)
        // ========================================================================
        // [Ana 30, Luis 25, Eva 30, Bob 25]
        //   -> ["Bob", "Luis", "Ana", "Eva"]
        //   (25: Bob, Luis | 30: Ana, Eva)
        //
        // Difficulty: Easy
        // Expected time to solve: 5 min
        // Topic: ThenBy on a PROPERTY of an object
        // Tip:   Sort the Person objects first, THEN Select the names. After
        //        Select(p => p.Name) the age is gone and you can't sort by it.
        // ========================================================================
        public List<string> SortPeopleByAgeThenName(List<Person> people)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 3: People by city A-Z, the OLDEST first inside each city
        // ========================================================================
        // [Ana 20 Lima, Luis 30 Quito, Sofia 45 Lima, Pedro 25 Quito, Maria 35 Lima]
        //   -> ["Sofia", "Maria", "Ana", "Luis", "Pedro"]
        //   (Lima: Sofia 45, Maria 35, Ana 20 | Quito: Luis 30, Pedro 25)
        //
        // Difficulty: Easy
        // Expected time to solve: 8 min
        // Topic: ThenByDescending (the tie-break goes the other way)
        // Tip:   The main sort is ascending, the tie-break is descending. They
        //        are independent: OrderBy(...).ThenByDescending(...).
        // ========================================================================
        public List<string> SortPeopleByCityThenOldest(List<Person> people)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 4: Highest salary first, ties by name A-Z (return the names)
        // ========================================================================
        // [Ana 6000, Luis 3000, Sofia 6000, Pedro 5000]
        //   -> ["Ana", "Sofia", "Pedro", "Luis"]
        //   (6000: Ana, Sofia in A-Z | then 5000 | then 3000)
        //
        // Difficulty: Easy
        // Expected time to solve: 5 min
        // Topic: OrderByDescending + ThenBy (main goes down, tie-break goes up)
        // Tip:   It is the mirror of Sample 3. Say it out loud: "salary, biggest
        //        first; if equal, name A-Z".
        // ========================================================================
        public List<string> SortEmployeesBySalaryThenName(List<Employee> employees)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 5: Evens first, then odds. Each part from small to big
        // ========================================================================
        // ([5, 2, 8, 1, 4, 3])  -> [2, 4, 8, 1, 3, 5]
        // ([-3, 2, -4, 1])      -> [-4, 2, -3, 1]
        // ([7, 9])              -> [7, 9]
        // ([])                  -> []
        //
        // Difficulty: Easy-Medium
        // Expected time to solve: 8 min
        // Topic: A bool as the FIRST sort key
        // Tip 1: false sorts BEFORE true. So the first key must be "is odd":
        //        OrderBy(n => n % 2 != 0). Evens get false, so they come first.
        // Tip 2: Use "% 2 != 0", not "% 2 == 1": in C# -3 % 2 is -1, not 1.
        //        The second key is the number itself.
        // ========================================================================
        public List<int> EvensFirst(int[] numbers)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 6: Words by their LAST letter, ties A-Z
        // ========================================================================
        // (["banana", "apple", "kiwi", "pear", "tuna"])
        //   -> ["banana", "tuna", "apple", "kiwi", "pear"]
        //   (last letter a: banana, tuna | e: apple | i: kiwi | r: pear)
        // ([])  -> []
        //
        // Difficulty: Easy-Medium
        // Expected time to solve: 8 min
        // Topic: A char as the sort key
        // Tip:   The last char of w is w[w.Length - 1]. A char sorts by its
        //        letter order. The words in the tests are never empty.
        // ========================================================================
        public List<string> SortWordsByLastLetter(string[] words)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 7: A-Z ignoring case, for the same word UPPER case first
        // ========================================================================
        // (["Bob", "alice", "Alice", "bob"])  -> ["Alice", "alice", "Bob", "bob"]
        // (["b", "A", "a", "B"])              -> ["A", "a", "B", "b"]
        // (["zed", "Amy"])                    -> ["Amy", "zed"]
        // ([])                                -> []
        //
        // Difficulty: Medium
        // Expected time to solve: 10 min
        // Topic: Two different "views" of the same word as keys
        // Tip 1: Main key: the word in lower case (w.ToLowerInvariant()).
        //        "Alice" and "alice" are now EQUAL, so they need a tie-break.
        // Tip 2: Tie-break: is the first letter lower case? char.IsLower(w[0])
        //        returns a bool, and false (= upper case) comes first.
        // ========================================================================
        public List<string> SortIgnoringCaseUpperFirst(string[] words)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 8: Leaderboard: best score first, ties A-Z (return the names)
        // ========================================================================
        // { Zoe: 90, Ana: 70, Luis: 90, Eva: 85 }
        //   -> ["Luis", "Zoe", "Eva", "Ana"]
        //   (90: Luis, Zoe in A-Z | 85: Eva | 70: Ana)
        // {}  -> []
        //
        // Difficulty: Medium
        // Expected time to solve: 8 min
        // Topic: ThenBy on a Dictionary (the element is a KeyValuePair)
        // Tip:   Each element has .Key (the name) and .Value (the score).
        //        Sort the pairs first, then Select(s => s.Key).
        // ========================================================================
        public List<string> SortLeaderboard(Dictionary<string, int> scores)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 9: Adults first (age >= 18), then each part by name A-Z
        // ========================================================================
        // [Tom 10, Ana 20, Bea 17, Carl 40, Dan 18]
        //   -> ["Ana", "Carl", "Dan", "Bea", "Tom"]
        //   (adults: Ana, Carl, Dan | minors: Bea, Tom)
        //
        // Difficulty: Medium
        // Expected time to solve: 8 min
        // Topic: A bool key where TRUE must come first
        // Tip:   false sorts before true, and here you want the adults (true)
        //        first. Which of OrderBy / OrderByDescending do you need?
        //        (Same bool trick as Sample 5, but the other direction.)
        // ========================================================================
        public List<string> AdultsFirstThenByName(List<Person> people)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 10: Rank the departments (GroupBy + three sort keys)
        // ========================================================================
        // IT: Ana 6000, Sofia 6000, Pedro 5000       (3 people, total 17000)
        // Sales: Maria 4000, Lucia 4000              (2 people, total 8000)
        // Ops: Raul 5000, Eva 4000                   (2 people, total 9000)
        // HR: Luis 3000                              (1 person,  total 3000)
        // Fin: Zoe 3000                              (1 person,  total 3000)
        //   -> ["IT", "Ops", "Sales", "Fin", "HR"]
        //
        // Rank by: 1) more people first, 2) if equal, bigger total salary first,
        //          3) if still equal, department name A-Z.
        // ([])  -> []
        //
        // Difficulty: Medium
        // Expected time to solve: 12 min
        // Pattern: GetTopKFrequentWords (GroupByExercises 12) + Samples 3 and 4
        // Topic: ThenBy chained TWICE on GROUPS
        // Tip 1: After GroupBy, each element is a box g (see GroupByExercises):
        //        g.Count(), g.Sum(e => e.Salary) and g.Key are all available.
        // Tip 2: OrderByDescending(...).ThenByDescending(...).ThenBy(...).
        //        Sort the boxes BEFORE Select(g => g.Key).
        // ========================================================================
        public List<string> RankDepartments(List<Employee> employees)
        {
            throw new NotImplementedException();
        }
    }
}
