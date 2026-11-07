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
        // ========================================================================
        public List<string> SortWordsByLength(string[] words)
        {
            return words.OrderBy(w => w.Length).ThenBy(s  => s).ToList();

            // Better (same logic, one lambda name for the whole chain):
            // return words.OrderBy(w => w.Length).ThenBy(w => w).ToList();
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
        // ========================================================================
        public List<string> SortPeopleByAgeThenName(List<Person> people)
        {
            return people.OrderBy(p => p.Age).ThenBy(a => a.Name).Select( s => s.Name).ToList();

            // Better (a Person is "p" in every step, one call per line):
            // return people
            //     .OrderBy(p => p.Age)
            //     .ThenBy(p => p.Name)
            //     .Select(p => p.Name)
            //     .ToList();
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
        // ========================================================================
        public List<string> SortPeopleByCityThenOldest(List<Person> people)
        {
            return people.OrderBy(p => p.City).ThenByDescending( a => a.Age).Select(s=> s.Name).ToList();

            // Better (same logic, "p" in every step):
            // return people
            //     .OrderBy(p => p.City)
            //     .ThenByDescending(p => p.Age)
            //     .Select(p => p.Name)
            //     .ToList();
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

        // ========================================================================
        public List<string> SortEmployeesBySalaryThenName(List<Employee> employees)
        {
            return employees.OrderByDescending(e => e.Salary).ThenBy(n => n.Name).Select(o => o.Name).ToList();

            // Better (an Employee is "e" in every step; "n" / "o" read like
            // a name and an order):
            // return employees
            //     .OrderByDescending(e => e.Salary)
            //     .ThenBy(e => e.Name)
            //     .Select(e => e.Name)
            //     .ToList();
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
        // ========================================================================
        public List<int> EvensFirst(int[] numbers)
        {
            return numbers.OrderBy(p => p % 2 != 0).ThenBy(s => s).ToList();

            // Better (same logic; an int is "n", and a named bool says what
            // the key means):
            // return numbers.OrderBy(n => IsOdd(n)).ThenBy(n => n).ToList();
            // static bool IsOdd(int n) => n % 2 != 0;   // -3 % 2 == -1, so not "== 1"
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
        // ========================================================================
        public List<string> SortWordsByLastLetter(string[] words)
        {
            return words.OrderBy(p => p[p.Length - 1]).ThenBy(s => s).ToList();

            // Better ("w" for a word, and an empty word doesn't crash: it gets
            // '\0', which sorts before every letter):
            // return words
            //     .OrderBy(w => w.Length > 0 ? w[w.Length - 1] : '\0')
            //     .ThenBy(w => w)
            //     .ToList();
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

        // ========================================================================
        public List<string> SortIgnoringCaseUpperFirst(string[] words)
        {
            return words.OrderBy(w => w.ToLowerInvariant()).ThenBy(s => !char.IsUpper( s[0]) ).ToList();

            // Better: a comparer instead of a lower-case COPY of every word, and
            // IsLower instead of !IsUpper (no double negative; lower = true = last):
            // return words
            //     .OrderBy(w => w, StringComparer.OrdinalIgnoreCase)
            //     .ThenBy(w => char.IsLower(w[0]))
            //     .ToList();
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

        // ========================================================================
        public List<string> SortLeaderboard(Dictionary<string, int> scores)
        {
            return scores.OrderByDescending(s => s.Value).ThenBy(n => n.Key).Select(s => s.Key).ToList();

            // Better (same logic; the element is a KeyValuePair, so "kv" in every step):
            // return scores
            //     .OrderByDescending(kv => kv.Value)
            //     .ThenBy(kv => kv.Key)
            //     .Select(kv => kv.Key)
            //     .ToList();
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

        // ========================================================================
        public List<string> AdultsFirstThenByName(List<Person> people)
        {
            return people.OrderByDescending(p => p.Age >= 18).ThenBy(s => s.Name).Select(s => s.Name).ToList();

            // Better (same logic, "p" in every step):
            // return people
            //     .OrderByDescending(p => p.Age >= 18)
            //     .ThenBy(p => p.Name)
            //     .Select(p => p.Name)
            //     .ToList();
            // Also valid: OrderBy(p => p.Age < 18) (minors = true = last).
            // Descending on the bool reads closer to "adults FIRST".
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

        // ========================================================================
        public List<string> RankDepartments(List<Employee> employees)
        {
            return employees.GroupBy(e => e.Department)
                .OrderByDescending(x => x.Count())
                .ThenByDescending(s => s.Sum( x=> x.Salary))
                .ThenBy(y => y.Key)
                .Select(s => s.Key)
                .ToList();

            // Better (same logic; after GroupBy every lambda gets a GROUP, so "g",
            // and the inner lambda gets an Employee, so "e"):
            // return employees
            //     .GroupBy(e => e.Department)
            //     .OrderByDescending(g => g.Count())
            //     .ThenByDescending(g => g.Sum(e => e.Salary))
            //     .ThenBy(g => g.Key)
            //     .Select(g => g.Key)
            //     .ToList();
        }
    }
}
