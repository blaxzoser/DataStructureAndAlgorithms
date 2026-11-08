using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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
        // ========================================================================
        public Dictionary<char, int> CharFrequency(string text)
        {
            return text.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        }

        // ========================================================================
        // SAMPLE 1 TRACE: what each step of CharFrequency does
        // ========================================================================
        // The chain has 2 steps:
        //   text.GroupBy(x => x)                          -> STEP 1: make buckets
        //       .ToDictionary(g => g.Key, g => g.Count()) -> STEP 2: bucket -> pair
        //
        // TRACE: "hello"
        //   index:  0   1   2   3   4
        //   char:   h   e   l   l   o
        //
        // STEP 1: GroupBy(x => x)
        //   Walk the string once. The key of each char is the char itself
        //   (x => x), so equal chars land in the same bucket.
        //
        //   read | key | buckets after this char
        //   -----+-----+------------------------------------------
        //    'h' | 'h' | h:[h]                        (new bucket)
        //    'e' | 'e' | h:[h]  e:[e]                 (new bucket)
        //    'l' | 'l' | h:[h]  e:[e]  l:[l]          (new bucket)
        //    'l' | 'l' | h:[h]  e:[e]  l:[l,l]        (existing bucket)
        //    'o' | 'o' | h:[h]  e:[e]  l:[l,l]  o:[o] (new bucket)
        //
        //   Result: 4 groups, in the order each key was FIRST seen.
        //     g.Key = 'h'   g = ['h']
        //     g.Key = 'e'   g = ['e']
        //     g.Key = 'l'   g = ['l', 'l']
        //     g.Key = 'o'   g = ['o']
        //
        // STEP 2: ToDictionary(g => g.Key, g => g.Count())
        //   For EACH group: first lambda -> the dictionary key,
        //                   second lambda -> the dictionary value.
        //
        //   group     | g.Key | g.Count() | dictionary entry
        //   ----------+-------+-----------+-----------------
        //   ['h']     |  'h'  |     1     |  'h' -> 1
        //   ['e']     |  'e'  |     1     |  'e' -> 1
        //   ['l','l'] |  'l'  |     2     |  'l' -> 2
        //   ['o']     |  'o'  |     1     |  'o' -> 1
        //
        //   Result: { 'h': 1, 'e': 1, 'l': 2, 'o': 1 } ✓
        //
        // EDGE CASE "": STEP 1 makes 0 groups, STEP 2 makes an empty dictionary.
        //
        // WHEN DOES IT RUN? GroupBy is LAZY: STEP 1 only builds a "recipe".
        // ToDictionary is what actually runs it (one pass over the string).
        // That's why the whole thing is Time O(n).
        // ========================================================================
        // DEBUG VERSION: same result, one variable per step.
        //   - Put a breakpoint on each 'return'/'Debug.WriteLine' line and hover
        //     the variables, or debug the test ShouldGetSameCharFrequencyInDebugVersion.
        //   - Debug.WriteLine prints to Visual Studio's Output window (Debug).
        //   - .ToList() after GroupBy is ONLY for debugging: it runs the lazy
        //     step right away so you can see the groups. The real version
        //     doesn't need it.
        // ========================================================================
        public Dictionary<char, int> CharFrequencyDebug(string text)
        {
            // STEP 1: make buckets
            List<IGrouping<char, char>> groups = text.GroupBy(c => c).ToList();
            foreach (var g in groups)
                Debug.WriteLine($"STEP 1  key '{g.Key}' -> [{string.Join(", ", g)}]");

            // STEP 2: one dictionary entry per bucket
            Dictionary<char, int> frequency = groups.ToDictionary(g => g.Key, g => g.Count());
            foreach (var pair in frequency)
                Debug.WriteLine($"STEP 2  '{pair.Key}' -> {pair.Value}");

            return frequency;
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
           return numbers.GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .Select(s => s.Key).ToArray();
        }

        // ========================================================================
        // SAMPLE 2 TRACE: what each step of GetDuplicates does
        // ========================================================================
        // The chain has 4 steps:
        //   numbers.GroupBy(x => x)        -> STEP 1: make buckets
        //       .Where(x => x.Count() > 1) -> STEP 2: keep only BIG buckets
        //       .Select(s => s.Key)        -> STEP 3: bucket -> its key
        //       .ToArray()                 -> STEP 4: run it all, make the array
        //
        // Naming tip: after GroupBy every lambda receives a GROUP, not a number.
        // Calling it 'g' (instead of 'x' / 's') reminds you of that:
        //   .Where(g => g.Count() > 1).Select(g => g.Key)
        //
        // TRACE: [4, 1, 4, 2, 1, 4]
        //   index:  0  1  2  3  4  5
        //   value:  4  1  4  2  1  4
        //
        // STEP 1: GroupBy(x => x)
        //
        //   read | buckets after this number
        //   -----+-----------------------------------
        //     4  | 4:[4]                       (new)
        //     1  | 4:[4]      1:[1]            (new)
        //     4  | 4:[4,4]    1:[1]
        //     2  | 4:[4,4]    1:[1]    2:[2]   (new)
        //     1  | 4:[4,4]    1:[1,1]  2:[2]
        //     4  | 4:[4,4,4]  1:[1,1]  2:[2]
        //
        //   Result: 3 groups, in FIRST-seen order: 4, 1, 2
        //
        // STEP 2: Where(g => g.Count() > 1)
        //   Here Where filters GROUPS, not numbers.
        //
        //   group     | g.Count() | > 1 ? | stays?
        //   ----------+-----------+-------+-------
        //   [4, 4, 4] |     3     | true  |  yes
        //   [1, 1]    |     2     | true  |  yes
        //   [2]       |     1     | false |  no
        //
        //   Result: 2 groups: [4, 4, 4], [1, 1]
        //
        // STEP 3: Select(g => g.Key)
        //   Each group becomes ONE value: its key. That is what removes the
        //   repeats: [4, 4, 4] -> 4, [1, 1] -> 1.
        //
        //   group     | g.Key
        //   ----------+------
        //   [4, 4, 4] |   4
        //   [1, 1]    |   1
        //
        // STEP 4: ToArray()
        //   Steps 1-3 are LAZY "recipes". ToArray runs them and builds [4, 1] ✓
        //
        // EDGE CASE [1, 2, 3]: STEP 1 -> [1] [2] [3], STEP 2 removes all of
        // them (count 1), so the result is [].
        //
        // DEBUG VERSION below: same steps, one variable per step (see the
        // notes on CharFrequencyDebug). Debug the test
        // ShouldGetSameDuplicatesInDebugVersion to step through it.
        // ========================================================================
        public int[] GetDuplicatesDebug(int[] numbers)
        {
            // STEP 1: make buckets
            List<IGrouping<int, int>> groups = numbers.GroupBy(n => n).ToList();
            foreach (var g in groups)
                Debug.WriteLine($"STEP 1  key {g.Key} -> [{string.Join(", ", g)}]  count {g.Count()}");

            // STEP 2: keep only the groups with more than 1 element
            List<IGrouping<int, int>> repeated = groups.Where(g => g.Count() > 1).ToList();
            foreach (var g in repeated)
                Debug.WriteLine($"STEP 2  kept key {g.Key} (count {g.Count()})");

            // STEP 3 + 4: each group -> its key, then build the array
            int[] duplicates = repeated.Select(g => g.Key).ToArray();
            Debug.WriteLine($"STEP 3  result [{string.Join(", ", duplicates)}]");

            return duplicates;
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
           return people.GroupBy(c => c.City, p=> p.Name)
                .ToDictionary( g => g.Key, g => g.ToList());
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
            // Solution written by Claude: re-do it from memory later.
            return text.Where(c => c != ' ')
                       .GroupBy(c => c)
                       .OrderByDescending(g => g.Count())
                       .First()
                       .Key;
        }

        // ========================================================================
        // SAMPLE 4 TRACE: what each step of GetMostFrequentChar does
        // ========================================================================
        // The chain has 5 steps:
        //   text.Where(c => c != ' ')           -> STEP 1: drop the spaces
        //       .GroupBy(c => c)                -> STEP 2: one bucket per char
        //       .OrderByDescending(g => g.Count()) -> STEP 3: biggest bucket first
        //       .First()                        -> STEP 4: take the biggest bucket
        //       .Key                            -> STEP 5: bucket -> its char
        //
        // TRACE: "hello world"
        //   index:  0  1  2  3  4  5  6  7  8  9  10
        //   char:   h  e  l  l  o ' ' w  o  r  l  d
        //
        // STEP 1: Where(c => c != ' ')
        //   'h' 'e' 'l' 'l' 'o' ' ' 'w' 'o' 'r' 'l' 'd'
        //                        ^ removed
        //   Result: h e l l o w o r l d   (10 chars)
        //
        // STEP 2: GroupBy(c => c)   (same as CharFrequency)
        //   Groups in FIRST-seen order:
        //
        //   order | g.Key | group           | g.Count()
        //   ------+-------+-----------------+----------
        //     1   |  'h'  | [h]             |    1
        //     2   |  'e'  | [e]             |    1
        //     3   |  'l'  | [l, l, l]       |    3
        //     4   |  'o'  | [o, o]          |    2
        //     5   |  'w'  | [w]             |    1
        //     6   |  'r'  | [r]             |    1
        //     7   |  'd'  | [d]             |    1
        //
        // STEP 3: OrderByDescending(g => g.Count())
        //   Sort the GROUPS by their size, biggest first.
        //
        //   g.Key | g.Count()
        //   ------+----------
        //    'l'  |    3      <- biggest
        //    'o'  |    2
        //    'h'  |    1      \
        //    'e'  |    1       |  tie at 1: they KEEP the order from STEP 2
        //    'w'  |    1       |  (h, e, w, r, d), because OrderByDescending
        //    'r'  |    1       |  is STABLE
        //    'd'  |    1      /
        //
        // STEP 4: First()  -> the group [l, l, l]
        // STEP 5: .Key     -> 'l' ✓
        //
        // WHY THE TIE WORKS: "aabb"
        //   STEP 2: 'a' [a, a] count 2   (seen first)
        //           'b' [b, b] count 2
        //   STEP 3: same count -> stable sort keeps a before b
        //   STEP 5: 'a' ✓        ("bbaa" gives 'b' for the same reason)
        //
        // COMMON MISTAKES
        //   - OrderBy instead of OrderByDescending -> you get the LEAST frequent.
        //   - .Max(g => g.Count()) returns the COUNT (3), not the char ('l').
        //   - Forgetting STEP 1: "a   b" has 3 spaces, so ' ' would win.
        //   - Empty string (or only spaces): STEP 4 First() has no group and
        //     throws InvalidOperationException. Fine here (not in the tests),
        //     but say it in an interview.
        //
        // TIME: GroupBy O(n) + sorting k groups O(k log k), where k = number of
        // different chars (k <= n). A single loop that remembers the best
        // count would be O(n), but this version is easier to read.
        //
        // DEBUG VERSION below: one variable per step (see the notes on
        // CharFrequencyDebug). Debug the test
        // ShouldGetSameMostFrequentCharInDebugVersion to step through it.
        // ========================================================================
        public char GetMostFrequentCharDebug(string text)
        {
            // STEP 1: drop the spaces
            List<char> noSpaces = text.Where(c => c != ' ').ToList();
            Debug.WriteLine($"STEP 1  [{string.Join(", ", noSpaces)}]");

            // STEP 2: one bucket per char (first-seen order)
            List<IGrouping<char, char>> groups = noSpaces.GroupBy(c => c).ToList();
            foreach (var g in groups)
                Debug.WriteLine($"STEP 2  key '{g.Key}' -> [{string.Join(", ", g)}]  count {g.Count()}");

            // STEP 3: biggest bucket first (ties keep the STEP 2 order)
            List<IGrouping<char, char>> sorted = groups.OrderByDescending(g => g.Count()).ToList();
            foreach (var g in sorted)
                Debug.WriteLine($"STEP 3  '{g.Key}' count {g.Count()}");

            // STEP 4: take the biggest bucket
            IGrouping<char, char> biggest = sorted.First();

            // STEP 5: bucket -> its char
            char mostFrequent = biggest.Key;
            Debug.WriteLine($"STEP 5  result '{mostFrequent}'");

            return mostFrequent;
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
            // Solution written by Claude: re-do it from memory later.
            return words.GroupBy(w => w.Length)
                        .OrderBy(g => g.Key)
                        .Select(g => $"{g.Key}: {string.Join(", ", g)}")
                        .ToList();
        }

        // ========================================================================
        // SAMPLE 5 TRACE: what each step of GroupWordsByLength does
        // ========================================================================
        // The chain has 4 steps:
        //   words.GroupBy(w => w.Length)       -> STEP 1: one bucket per length
        //        .OrderBy(g => g.Key)          -> STEP 2: sort the GROUPS by length
        //        .Select(g => $"...")          -> STEP 3: group -> one line of text
        //        .ToList()                     -> STEP 4: run it all, make the list
        //
        // TRACE: ["cat", "horse", "dog", "bird", "ox"]
        //
        // STEP 1: GroupBy(w => w.Length)
        //   The key is NOT the word, it's its length. Words with the same
        //   length share a bucket.
        //
        //   read    | key | buckets after this word
        //   --------+-----+-------------------------------------------
        //   "cat"   |  3  | 3:[cat]                            (new)
        //   "horse" |  5  | 3:[cat]  5:[horse]                 (new)
        //   "dog"   |  3  | 3:[cat, dog]  5:[horse]
        //   "bird"  |  4  | 3:[cat, dog]  5:[horse]  4:[bird]  (new)
        //   "ox"    |  2  | 3:[cat, dog]  5:[horse]  4:[bird]  2:[ox] (new)
        //
        //   Result: groups in FIRST-seen order: 3, 5, 4, 2   (not sorted yet!)
        //   Inside each group the words keep the INPUT order: cat before dog.
        //
        // STEP 2: OrderBy(g => g.Key)
        //   Sort the GROUPS (not the words) by their key, smallest first.
        //
        //   before (STEP 1)     after (STEP 2)
        //   ---------------     --------------
        //   3: [cat, dog]       2: [ox]
        //   5: [horse]          3: [cat, dog]
        //   4: [bird]           4: [bird]
        //   2: [ox]             5: [horse]
        //
        // STEP 3: Select(g => $"{g.Key}: {string.Join(", ", g)}")
        //   Each group becomes ONE string.
        //     g.Key                -> the number       3
        //     string.Join(", ", g) -> the words joined "cat, dog"
        //     $"{...}: {...}"      -> put together     "3: cat, dog"
        //
        //   group          | g.Key | string.Join(", ", g) | line
        //   ---------------+-------+----------------------+-------------
        //   [ox]           |   2   | "ox"                 | "2: ox"
        //   [cat, dog]     |   3   | "cat, dog"           | "3: cat, dog"
        //   [bird]         |   4   | "bird"               | "4: bird"
        //   [horse]        |   5   | "horse"              | "5: horse"
        //
        // STEP 4: ToList()
        //   Runs steps 1-3 (they are lazy) -> ["2: ox", "3: cat, dog", "4: bird", "5: horse"] ✓
        //
        // EDGE CASE []: STEP 1 makes 0 groups, so every step after gets
        // nothing and ToList() gives an empty list. No 'if' needed.
        //
        // COMMON MISTAKES
        //   - Forgetting STEP 2: output starts with "3: ..." (first-seen order).
        //   - OrderBy(w => w) on the words instead of the groups: wrong level.
        //   - "3:cat" (no space) or ";" instead of ", " -> the strings differ
        //     and CollectionAssert.AreEqual fails.
        //   - Returning the Select without ToList(): it's an IEnumerable,
        //     not a List<string> (compile error CS0266, like ArrayDiff).
        //
        // DEBUG VERSION below: one variable per step. Debug the test
        // ShouldGetSameWordsByLengthInDebugVersion to step through it.
        // ========================================================================
        public List<string> GroupWordsByLengthDebug(string[] words)
        {
            // STEP 1: one bucket per length (first-seen order)
            List<IGrouping<int, string>> groups = words.GroupBy(w => w.Length).ToList();
            foreach (var g in groups)
                Debug.WriteLine($"STEP 1  key {g.Key} -> [{string.Join(", ", g)}]");

            // STEP 2: sort the groups by their key
            List<IGrouping<int, string>> sorted = groups.OrderBy(g => g.Key).ToList();
            foreach (var g in sorted)
                Debug.WriteLine($"STEP 2  key {g.Key}");

            // STEP 3 + 4: each group -> one line, then build the list
            List<string> lines = sorted.Select(g => $"{g.Key}: {string.Join(", ", g)}").ToList();
            foreach (var line in lines)
                Debug.WriteLine($"STEP 3  \"{line}\"");

            return lines;
        }

        // ============================================================================
        // ROUND 2: more GroupBy practice (Samples 6-10)
        // ============================================================================
        // Same 4-step shape as Samples 1-5:
        //   GroupBy(key) -> (Where on groups) -> (OrderBy on groups) -> Select / ToDictionary
        // Each one reuses a sample you already did, with one new twist.
        // Try them WITHOUT the TRACE comments above first.
        //
        // Total practice time: ~50 min
        // ============================================================================

        // ========================================================================
        // SAMPLE 6: Count even and odd numbers
        // ========================================================================
        // [1, 2, 3, 4, 5] -> { "Odd": 3, "Even": 2 }
        // [2, 4]          -> { "Even": 2 }          (no "Odd" key at all)
        // []              -> { }
        //
        // Expected time to solve: 5 min
        // Pattern: CharFrequency (Sample 1)
        // Topic:   GroupBy on a COMPUTED key (not the value itself)
        // Tip 1:   The key doesn't have to be the element. The lambda can
        //          return anything: n => n % 2 == 0 ? "Even" : "Odd"
        // Tip 2:   Then it's the same ToDictionary as Sample 1.
        // ========================================================================
        public Dictionary<string, int> CountEvenAndOdd(int[] numbers)
        {
            return numbers.GroupBy(n => n % 2 == 0 ? "Even" : "Odd")
                 .ToDictionary(s => s.Key, x => x.Count());
        }

        // ========================================================================
        // SAMPLE 7: Count words by first letter (ignore case)
        // ========================================================================
        // ["Apple", "avocado", "banana", "Blueberry", "cherry"]
        //   -> { 'a': 2, 'b': 2, 'c': 1 }
        // []  -> { }
        //
        // Expected time to solve: 10 min
        // Pattern: CharFrequency (Sample 1) + CountEvenAndOdd (Sample 6)
        // Topic:   GroupBy on a computed key + normalizing the key
        // Tip 1:   The key is the FIRST char of the word: w[0] 
        // Tip 2:   'A' and 'a' must land in the same bucket. Lower-case the
        //          KEY (char.ToLowerInvariant), not the whole word.
        // ========================================================================
        public Dictionary<char, int> CountWordsByFirstLetter(string[] words)
        {
            return words.GroupBy(s => char.ToLowerInvariant(s[0])).ToDictionary(s => s.Key, x => x.Count());
        }

        // ========================================================================
        // SAMPLE 8: Cities with at least N people, sorted A-Z
        // ========================================================================
        // ([Ana Lima, Luis Quito, Sofia Lima, Pedro Cusco, Maria Cusco, Juan Lima], 2)
        //   -> ["Cusco", "Lima"]      (Quito has only 1)
        // (people, 5) -> []
        //
        // Expected time to solve: 10 min
        // Pattern: GetDuplicates (Sample 2) + GroupWordsByLength (Sample 5)
        // Topic:   Where on groups (SQL HAVING) + OrderBy on the Key
        // Tip 1:   Same as GetDuplicates, but with objects: group by p.City,
        //          keep the groups with Count() >= minPeople.
        // Tip 2:   Sort by g.Key BEFORE or AFTER the Select? Both work,
        //          think about which reads better.
        // ========================================================================
        // NOTES: think of GroupBy as "SQL GROUP BY ... HAVING ... ORDER BY".
        //   GroupBy(city) -> Where(count >= N) -> OrderBy(key) -> Select(key) -> ToList()
        //
        // Example: [Ana Lima, Luis Quito, Sofia Lima, Pedro Cusco, Maria Cusco, Juan Lima], N = 2
        public List<string> GetCitiesWithAtLeast(List<Person> people, int minPeople)
        {
            return people
                // STEP 1: p is ONE Person. The lambda only gives the LABEL (the Key).
                //   Each FULL Person object (not just the name) goes into the box of its city:
                //     Lima  -> [ Person(Ana,20,Lima), Person(Sofia,25,Lima), Person(Juan,30,Lima) ]
                //     Quito -> [ Person(Luis,30,Quito) ]
                //     Cusco -> [ Person(Pedro,40,Cusco), Person(Maria,35,Cusco) ]
                //   Type now: IEnumerable<IGrouping<string, Person>> = a sequence of BOXES.
                .GroupBy(p => p.City)

                // STEP 2: g is ONE BOX (not a Person). It runs once per box.
                //   g.Count() = how many Person objects are inside the box. No field of
                //   Person is needed, we only ask the box for its size.
                //     Lima 3 >= 2 keep | Quito 1 >= 2 drop | Cusco 2 >= 2 keep
                //   ">=" because "at least N" includes N (Cusco has exactly 2).
                //   Must run BEFORE Select(g => g.Key): after that there are only strings
                //   and Count() would count characters.
                .Where(g => g.Count() >= minPeople)

                // STEP 3: still boxes, so g.Key (the city) exists. Sorts A-Z: Cusco, Lima.
                .OrderBy(g => g.Key)

                // STEP 4: open each box and keep only its label. The people are not needed
                //   anymore. Type now: IEnumerable<string>.
                .Select(g => g.Key)

                // STEP 5: the method returns List<string>, so materialize it (without it:
                //   error CS0266, which breaks the build of the whole test project).
                .ToList();

            // LAMBDA VARIABLE = ONE element of the sequence in front of it:
            //   before GroupBy -> Person (p)   -> pick a field: p.City
            //   after GroupBy  -> a box (g)    -> ask the box: g.Key, g.Count(), g.Max(p => p.Age)
        }

        // ========================================================================
        // SAMPLE 9: Total products bought by each customer
        // ========================================================================
        // A customer can have MANY orders. Add up the products of all of them.
        // Order 1 Ana  -> ["Pen", "Book"]
        // Order 2 Luis -> ["Cup"]
        // Order 3 Ana  -> ["Lamp"]
        // Order 4 Luis -> []
        //   -> { "Ana": 3, "Luis": 1 }
        //
        // Expected time to solve: 10 min
        // Pattern: GroupNamesByCity (Sample 3)
        // Topic:   GroupBy + Sum inside each group
        // Tip 1:   Group the ORDERS by o.Customer. Each group is then all the
        //          orders of one customer.
        // Tip 2:   g.Count() would count ORDERS (Ana: 2). You need the
        //          products: g.Sum(o => o.Products.Count)
        // ========================================================================
        public Dictionary<string, int> CountProductsByCustomer(List<Order> orders)
        {
            return orders
                .GroupBy(p => p.Customer)
                .ToDictionary(a => a.Key, s => s.Sum(o => o.Products.Count )                                                        
                );
        }

        // ========================================================================
        // SAMPLE 10: Oldest person in each city
        // ========================================================================
        // [Ana 20 Lima, Luis 30 Quito, Sofia 45 Lima, Pedro 25 Quito, Maria 45 Lima]
        //   -> { "Lima": "Sofia", "Quito": "Luis" }
        //   (tie in Lima: Sofia and Maria are 45, Sofia comes first)
        //
        // Expected time to solve: 15 min
        // Pattern: GetMostFrequentChar (Sample 4) + GroupNamesByCity (Sample 3)
        // Topic:   Sorting INSIDE each group
        // Tip 1:   In Sample 4 you sorted the GROUPS. Here you sort the
        //          PEOPLE inside each group: the value of ToDictionary is
        //          g.OrderByDescending(p => p.Age).First().Name
        // Tip 2:   Same stable-sort trick as Sample 4 solves the tie.
        // ========================================================================
        public Dictionary<string, string> GetOldestPersonByCity(List<Person> people)
        {
            return people.GroupBy(o => o.City)
                   .ToDictionary(x => x.Key, y => y.OrderByDescending(s=> s.Age).First().Name);
        }

        // ============================================================================
        // ROUND 3: senior mock-interview GroupBy (Samples 11-20)
        // ============================================================================
        // The GroupBy questions that come up most in C# / .NET interviews.
        // Mix of simple data (int[], string) and objects with lists inside
        // (Employee, Student.Courses, Order.Products, Person + City).
        //
        // Interview rules: max 15 min each, no TRACE comments, say the
        // Time / Space out loud when you finish, then answer the
        // "Interview follow-up" question of each sample.
        //
        // New things in this round:
        //   - ThenBy (tie-break)            -> Sample 12
        //   - ToLookup                      -> Sample 13
        //   - Average / Distinct + Skip     -> Samples 14, 15
        //   - SelectMany BEFORE GroupBy     -> Samples 16, 20
        //   - Composite key (anonymous type)-> Sample 17
        //   - Select((x, i) => ...) + GroupBy (batching) -> Sample 18
        //   - Lookup in a 2nd list, then GroupBy (like a SQL JOIN) -> Sample 19
        //   - GroupBy inside a GroupBy (nested dictionary)         -> Sample 20
        //
        // Total practice time: ~110 min
        // ============================================================================

        // ========================================================================
        // SAMPLE 11: Values that appear exactly once (warm-up)
        // ========================================================================
        // Keep the order they first appear.
        // [4, 1, 4, 2, 1, 5] -> [2, 5]
        // [7, 7]             -> []
        // []                 -> []
        //
        // Difficulty: Easy
        // Goal: Time O(n), Space O(n)
        // Expected time to solve: 5 min
        // Pattern: GetDuplicates (Sample 2), the opposite filter
        // Topic:   Where on groups
        // Tip 1:   Same chain as Sample 2, only the Where changes.
        // Tip 2:   "exactly once" -> == 1 (not >= 1, not > 1).
        // Interview follow-up: "first non-repeating number" -> what changes?
        // ========================================================================
        public int[] GetValuesAppearingOnce(int[] numbers)
        {
            return numbers.GroupBy( x => x )
                   .Where(s => s.Count() == 1  )
                   .Select(o => o.Key).ToArray();
        }

        // ========================================================================
        // SAMPLE 12: Top K most frequent words
        // ========================================================================
        // Words are separated by spaces (can be more than one). Ignore case:
        // return the words in lower case. Most frequent first. Tie: A-Z.
        // ("the cat and the hat and the bat", 2) -> ["the", "and"]
        //     the: 3, and: 2, cat/hat/bat: 1
        // ("b a c a b c", 2)  -> ["a", "b"]    (all have 2: A-Z decides)
        // ("Hi hi HI", 5)     -> ["hi"]        (k bigger than the words: all)
        // ("", 3)             -> []
        //
        // Difficulty: Easy-Medium
        // Goal: Time O(n + w log w) (w = different words), Space O(w)
        // Expected time to solve: 10 min
        // Pattern: GetMostFrequentChar (Sample 4) + CountWordsByFirstLetter (Sample 7)
        // Topic:   OrderByDescending + ThenBy + Take
        // Tip 1:   sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        //          ("" and double spaces give no empty words).
        // Tip 2:   In Sample 4 the tie used first-seen order. Here the tie is
        //          A-Z, so add .ThenBy(g => g.Key) after the OrderByDescending.
        // Interview follow-up: LeetCode 692. Can you do it without sorting
        //          all the words? (heap / PriorityQueue of size k)
        // ========================================================================
        public List<string> GetTopKFrequentWords(string sentence, int k)
        {
            return sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .GroupBy(w => w.ToLowerInvariant())
                 .OrderByDescending(g => g.Count())
                 .ThenBy(g => g.Key)
                 .Take(k)
                 .Select(g => g.Key)
                 .ToList();
        }

        // ========================================================================
        // SAMPLE 13: Names by city with ToLookup
        // ========================================================================
        // Same data as Sample 3, but return an ILookup instead of a Dictionary.
        // [Ana Lima, Luis Quito, Sofia Lima]
        //   lookup["Lima"]  -> ["Ana", "Sofia"]
        //   lookup["Quito"] -> ["Luis"]
        //   lookup["Cusco"] -> []      (NO exception, a Dictionary would throw)
        //
        // Difficulty: Easy
        // Goal: Time O(n), Space O(n)
        // Expected time to solve: 5 min
        // Pattern: GroupNamesByCity (Sample 3)
        // Topic:   ToLookup vs GroupBy + ToDictionary
        // Tip 1:   ToLookup has the same 2 lambdas as GroupBy:
        //          ToLookup(keySelector, elementSelector).
        // Tip 2:   It's ONE call, no ToDictionary needed.
        // Interview follow-up (very common): "GroupBy vs ToLookup?"
        //          GroupBy is LAZY (runs again on every foreach), ToLookup runs
        //          NOW (once) and is read-only. A missing key gives an empty
        //          sequence instead of KeyNotFoundException.
        // ========================================================================
        public ILookup<string, string> BuildNamesByCityLookup(List<Person> people)
        {
            return people.ToLookup(s => s.City, y => y.Name);             
        }

        // ========================================================================
        // SAMPLE 14: Average salary by department
        // ========================================================================
        // Round to 2 decimals.
        // [Ana IT 5000, Luis HR 3000, Sofia IT 6000, Pedro IT 4500, Maria HR 3500]
        //   -> { "IT": 5166.67, "HR": 3250 }
        // [] -> { }
        //
        // Difficulty: Easy
        // Goal: Time O(n), Space O(d) (d = departments)
        // Expected time to solve: 10 min
        // Pattern: CountProductsByCustomer (Sample 9)
        // Topic:   Aggregates inside a group: Average (also Sum, Min, Max)
        // Tip 1:   Sample 9 used g.Sum(...). Here: g.Average(e => e.Salary).
        //          Average of ints returns a double.
        // Tip 2:   Math.Round(value, 2).
        // Interview follow-up: "Average() on an empty sequence?" -> it throws
        //          InvalidOperationException. Why is that never a problem
        //          inside a GroupBy? (a group always has >= 1 element)
        // ========================================================================
        public Dictionary<string, double> GetAverageSalaryByDepartment(List<Employee> employees)
        {
            return employees.GroupBy(s => s.Department)
                            .ToDictionary(s => s.Key, p =>  Math.Round(
                                ( p.Average(t => t.Salary)),2));
        }

        // ========================================================================
        // SAMPLE 15: Second highest salary by department
        // ========================================================================
        // The classic SQL interview question, in LINQ. "Second highest" means
        // the second DIFFERENT salary. If there is none, the value is 0.
        // IT:    6000, 6000, 5000, 4500 -> 5000  (6000 twice is still 1st place)
        // HR:    3000                   -> 0     (only one employee)
        // Sales: 4000, 4000             -> 0     (only one DIFFERENT salary)
        //
        // Difficulty: Medium
        // Goal: Time O(n log n), Space O(n)
        // Expected time to solve: 15 min
        // Pattern: GetOldestPersonByCity (Sample 10) + SkipExercises + FirstExercises 2
        // Topic:   Select + Distinct + OrderByDescending + Skip INSIDE each group
        // Tip 1:   For one group: take the salaries, remove repeats, sort
        //          biggest first, skip the first one, take the next.
        // Tip 2:   FirstOrDefault() on an int sequence gives 0 when it's empty
        //          (you saw it in GetFirstNegativeOrZero). No 'if' needed.
        // Interview follow-up: "Nth highest?" -> Skip(n - 1). And what if 0 is
        //          a real salary? (return int? / nullable instead)
        // ========================================================================
        public Dictionary<string, int> GetSecondHighestSalaryByDepartment(List<Employee> employees)
        {
            return employees.GroupBy(e => e.Department)
                            .ToDictionary(s => s.Key, 
                                x => x.Select(s => s.Salary)
                                      .Distinct()
                                      .OrderByDescending(t => t)
                                      .Skip(1)
                                      .FirstOrDefault()
                            );
        }

        // ========================================================================
        // SAMPLE 16: How many students take each course
        // ========================================================================
        // Each Student has a LIST of courses. Count STUDENTS, not rows: if a
        // student wrote the same course twice, it counts once.
        // Ana   -> [Math, Art]
        // Luis  -> [Math]
        // Sofia -> [Art, Math, Art]     (Art twice: counts once)
        // Juan  -> []                   (adds nothing)
        //   -> { "Math": 3, "Art": 2 }
        //
        // Difficulty: Easy-Medium
        // Goal: Time O(total courses), Space O(different courses)
        // Expected time to solve: 10 min
        // Pattern: CharFrequency (Sample 1) + SelectManyExercises.GetAllCourses
        // Topic:   SelectMany BEFORE GroupBy (flatten the lists, then count)
        // Interview follow-up: "Which course has the most students?"
        // ========================================================================
        public Dictionary<string, int> CountStudentsByCourse(List<Student> students)
        {
            return students.SelectMany(s => s.Courses.Distinct())
                            .GroupBy(a => a)
                            .ToDictionary( y => y.Key, m => m.Count());
        }

        // ========================================================================
        // SAMPLE 17: Count people by city AND age group (composite key)
        // ========================================================================
        // Age group: "Adult" if Age >= 18, else "Minor".
        // Sort by city A-Z, then by group A-Z. Format: "<City> - <Group>: <count>"
        // [Ana 20 Lima, Luis 15 Quito, Sofia 12 Lima, Pedro 40 Lima,
        //  Maria 30 Quito, Juan 18 Lima]
        //   -> ["Lima - Adult: 3", "Lima - Minor: 1",
        //       "Quito - Adult: 1", "Quito - Minor: 1"]
        //   (Juan is exactly 18 -> Adult)
        //
        // Difficulty: Medium
        // Goal: Time O(n + g log g) (g = groups), Space O(n)
        // Expected time to solve: 15 min
        // Pattern: CountEvenAndOdd (Sample 6) + GroupWordsByLength (Sample 5)
        // Topic:   GroupBy on TWO things at once = anonymous type key
        //          (SQL: GROUP BY City, AgeGroup)
        // Tip 1:   The key can be an object:
        //          GroupBy(p => new { p.City, AgeGroup = p.Age >= 18 ? "Adult" : "Minor" })
        //          Then g.Key.City and g.Key.AgeGroup.
        // Tip 2:   Two sort levels: OrderBy(...).ThenBy(...), never two OrderBy
        //          (the 2nd OrderBy throws away the 1st sort).
        // Interview follow-up: "Why does an anonymous type work as a key but
        //          a normal class doesn't?" (anonymous types compare by VALUE:
        //          they override Equals/GetHashCode. A class compares by
        //          reference -> every person gets their own group. Tuples
        //          (p.City, group) also work.)
        // ========================================================================
        public List<string> CountPeopleByCityAndAgeGroup(List<Person> people)
        {
            // DEBUG TRACE. Input used in every step below:
            //   Ana 20 Lima | Luis 15 Quito | Sofia 12 Lima | Pedro 40 Lima
            //   Maria 30 Quito | Juan 18 Lima
            return people
                // STEP 1: GroupBy. The lambda runs ONCE PER PERSON (s = one Person) and
                //   builds the key. People with an EQUAL key go into the same box:
                //     Ana   -> { Lima,  Adult }    Luis  -> { Quito, Minor }
                //     Sofia -> { Lima,  Minor }    Pedro -> { Lima,  Adult }
                //     Maria -> { Quito, Adult }    Juan  -> { Lima,  Adult }  (18 >= 18)
                //   The anonymous type compares by VALUE, so Ana, Pedro and Juan share a box.
                //   Result: boxes in order of FIRST appearance (NOT sorted yet).
                //   The key is only the LABEL. Each box holds the FULL Person objects
                //   (Name, Age, City), not just the names:
                //     BOX 1 { Lima,  Adult } -> [ Person(Ana,20,Lima), Person(Pedro,40,Lima), Person(Juan,18,Lima) ]
                //     BOX 2 { Quito, Minor } -> [ Person(Luis,15,Quito) ]
                //     BOX 3 { Lima,  Minor } -> [ Person(Sofia,12,Lima) ]
                //     BOX 4 { Quito, Adult } -> [ Person(Maria,30,Quito) ]
                //   Type: IEnumerable<IGrouping<{City, AgeGroup}, Person>>
                //   ("Person" at the end of the type is what each box holds.)
                .GroupBy(s => new { s.City, AgeGroup = s.Age >= 18 ? "Adult" : "Minor" })

                // STEP 2: OrderBy. s is now ONE BOX (not a Person). Main sort: the city A-Z.
                //   Lima boxes first, then Quito. Inside the same city nothing is decided yet
                //   (OrderBy is stable, so they keep the order from step 1):
                //     BOX 1 { Lima,  Adult }   BOX 3 { Lima,  Minor }
                //     BOX 2 { Quito, Minor }   BOX 4 { Quito, Adult }   <- Minor before Adult: wrong yet
                //   Still boxes, so s.Key.City exists.
                .OrderBy(s=> s.Key.City)

                // STEP 3: ThenBy = the TIE-BREAK. It only reorders boxes with the SAME city.
                //   Group A-Z: "Adult" comes before "Minor". Never use a 2nd OrderBy here:
                //   it would throw away the city sort from step 2.
                //     Lima:  BOX 1 { Lima,  Adult }, BOX 3 { Lima,  Minor }
                //     Quito: BOX 4 { Quito, Adult }, BOX 2 { Quito, Minor }
                //   Order now: BOX 1, BOX 3, BOX 4, BOX 2 (the expected output order).
                .ThenBy(o => o.Key.AgeGroup)

                // STEP 4: Select. Turns each BOX into ONE string. Keep Key and Count()
                //   for the LAST step: after this the boxes are gone, only text is left.
                //     BOX 1 -> "Lima - Adult: 3"     (t.Count() = 3 people in the box)
                //     BOX 3 -> "Lima - Minor: 1"
                //     BOX 4 -> "Quito - Adult: 1"
                //     BOX 2 -> "Quito - Minor: 1"
                //   Watch the exact text: no space before ':' and none at the end,
                //   the test compares the strings character by character.
                .Select(t => $"{t.Key.City} - {t.Key.AgeGroup}: {t.Count()}")

                // STEP 5: ToList. The method returns List<string>; Select gives an
                //   IEnumerable<string> (lazy, nothing ran until now). ToList runs the whole
                //   chain once. Without it: error CS0266 and the test project doesn't build.
                //   -> ["Lima - Adult: 3", "Lima - Minor: 1", "Quito - Adult: 1", "Quito - Minor: 1"]
                .ToList();
        }

        // ========================================================================
        // SAMPLE 18: Split into batches of size N
        // ========================================================================
        // ([1, 2, 3, 4, 5, 6, 7], 3) -> [[1, 2, 3], [4, 5, 6], [7]]
        // ([1, 2], 5)                -> [[1, 2]]
        // ([], 3)                    -> []
        //
        // Difficulty: Medium
        // Goal: Time O(n), Space O(n)
        // Expected time to solve: 10 min
        // Pattern: WhereExercises.GetElementsAtEvenIndex ((e, i) => overload)
        // Topic:   GroupBy on the INDEX: the key is index / size
        // Tip 1:   GroupBy has no (x, i) overload, but Select does:
        //          Select((n, i) => new { n, i })
        // Tip 2:   Integer division: index 0,1,2 / 3 = 0 | 3,4,5 / 3 = 1 | 6 / 3 = 2.
        //          Use the 2nd lambda of GroupBy to keep only the number.
        // Interview follow-up: "Why batch?" (send 1000 rows per DB call / API
        //          page). .NET 6 has Chunk(size), but it's not in netstandard2.0.
        // ========================================================================
        public List<List<int>> SplitIntoBatches(int[] numbers, int size)
        {
            return numbers
                .Select((n, i) => new { n, i })            // STEP 1: attach the position to each number
                .GroupBy(x => x.i / size, x => x.n)        // STEP 2: batch number = index / size, keep only n
                .Select(g => g.ToList())                   // STEP 3: each batch (group) -> List<int>
                .ToList();                                 // STEP 4: all the batches -> List<List<int>>
        }

        // ========================================================================
        // SAMPLE 18 TRACE: what each step of SplitIntoBatches does
        // ========================================================================
        // Your first try did GroupBy(x => x / size) FIRST. That divides the VALUE,
        // not the POSITION: 1/3=0, 2/3=0, 3/3=1 ... -> [1,2] [3,4,5] [6,7]  (wrong).
        // The batch depends on WHERE the number is, so we need the index first.
        //
        // TRACE: numbers = [1, 2, 3, 4, 5, 6, 7], size = 3
        //
        // STEP 1: Select((n, i) => new { n, i })
        //   Select with 2 parameters: n = the item, i = its index (starts at 0).
        //   One small box { n, i } per number. Same count as the input (7).
        //
        //   n | 1  2  3  4  5  6  7
        //   i | 0  1  2  3  4  5  6
        //
        // STEP 2: GroupBy(x => x.i / size, x => x.n)
        //   1st lambda = the KEY (which bucket), 2nd lambda = what we STORE.
        //   Integer division: the decimals are dropped (2 / 3 = 0, not 0.66).
        //
        //   n | i | i / 3 (key) | stored | buckets after this item
        //   --+---+-------------+--------+---------------------------
        //   1 | 0 |      0      |   1    | 0:[1]
        //   2 | 1 |      0      |   2    | 0:[1,2]
        //   3 | 2 |      0      |   3    | 0:[1,2,3]
        //   4 | 3 |      1      |   4    | 0:[1,2,3] 1:[4]
        //   5 | 4 |      1      |   5    | 0:[1,2,3] 1:[4,5]
        //   6 | 5 |      1      |   6    | 0:[1,2,3] 1:[4,5,6]
        //   7 | 6 |      2      |   7    | 0:[1,2,3] 1:[4,5,6] 2:[7]
        //
        //   Result: 3 groups (the keys 0, 1, 2 are only labels; we never use them).
        //
        // STEP 3: Select(g => g.ToList())
        //   Now Select has ONE parameter, because we only need the group g.
        //   A group is an IEnumerable<int>; the method must return List<int>.
        //   [1,2,3]  [4,5,6]  [7]
        //
        // STEP 4: ToList()
        //   The outer sequence -> List<List<int>>. This is also what RUNS the lazy
        //   chain (one pass over the array, Time O(n)).
        //
        // EDGE CASES:
        //   ([1, 2], 5) -> keys 0/5=0, 1/5=0 -> one group [1,2]     OK
        //   ([], 3)     -> STEP 1 makes 0 boxes -> 0 groups -> []    OK, no special case
        //   (size = 0)  -> i / 0 throws DivideByZeroException (not tested here;
        //                  in real code you would validate size > 0 first).
        //
        // Remember the two uses of Select:  Select(n => ...)      -> only the item
        //                                   Select((n, i) => ...) -> item + index
        // ========================================================================
        // DEBUG VERSION: same result, one variable per step.
        //   Put a breakpoint on each Debug.WriteLine, or debug the test
        //   ShouldGetSameBatchesInDebugVersion and hover the variables.
        //   .ToList() on the early steps is ONLY for debugging (it runs the lazy
        //   step now so you can see the content).
        // ========================================================================
        public List<List<int>> SplitIntoBatchesDebug(int[] numbers, int size)
        {
            // STEP 1: number + index.  [1,2,3,4,5,6,7] -> {1,0} {2,1} {3,2} ...
            var withIndex = numbers.Select((n, i) => new { n, i }).ToList();
            foreach (var x in withIndex)
                Debug.WriteLine($"STEP 1  n={x.n}  i={x.i}  -> key i/size = {x.i / size}");

            // STEP 2: buckets by index / size, storing only the number
            List<IGrouping<int, int>> groups = withIndex.GroupBy(x => x.i / size, x => x.n).ToList();
            foreach (var g in groups)
                Debug.WriteLine($"STEP 2  key {g.Key} -> [{string.Join(", ", g)}]");

            // STEP 3: each group -> List<int>
            List<List<int>> batches = groups.Select(g => g.ToList()).ToList();
            foreach (var b in batches)
                Debug.WriteLine($"STEP 3  batch [{string.Join(", ", b)}]");

            return batches;
        }

        // ========================================================================
        // SAMPLE 19: Count people by country (two lists, like a SQL JOIN)
        // ========================================================================
        // A Person only has a City. The country is in the 2nd list (City).
        // A city that is not in the list counts as "Unknown".
        // cities: [Lima Peru, Cusco Peru, Quito Ecuador]
        // people: [Ana Lima, Luis Quito, Sofia Cusco, Pedro Lima, Maria Bogota]
        //   -> { "Peru": 3, "Ecuador": 1, "Unknown": 1 }
        //
        // Difficulty: Medium
        // Goal: Time O(p + c), Space O(c)
        // Expected time to solve: 15 min
        // Pattern: ContainsExercises.GetPeopleInCapitalsFast (build a lookup once)
        //          + CountEvenAndOdd (Sample 6, computed key)
        // Topic:   GroupBy on a key that comes from ANOTHER collection
        // Tip 1:   Build it ONCE, before the GroupBy:
        //          var countryOf = cities.ToDictionary(c => c.Name, c => c.Country);
        //          (a cities.First(...) inside the lambda is O(p * c)).
        // Tip 2:   The key lambda: countryOf.TryGetValue(p.City, out var country)
        //          ? country : "Unknown"
        // Interview follow-up: "Do it with Join." (join drops Maria: that's an
        //          INNER join. Keeping her = LEFT join = GroupJoin.) And what
        //          does ToDictionary do if a city name appears twice? (throws)
        // ========================================================================
        public Dictionary<string, int> CountPeopleByCountry(List<Person> people, List<City> cities)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 20: How many of each product every customer bought (nested)
        // ========================================================================
        // Order 1 Ana   -> [Pen, Book]
        // Order 2 Luis  -> [Cup]
        // Order 3 Ana   -> [Pen]
        // Order 4 Sofia -> []
        //   -> {
        //        "Ana":   { "Pen": 2, "Book": 1 },
        //        "Luis":  { "Cup": 1 },
        //        "Sofia": { }               (customer stays, inner is empty)
        //      }
        //
        // Difficulty: Medium-Hard
        // Goal: Time O(total products), Space O(total products)
        // Expected time to solve: 15 min
        // Pattern: CountProductsByCustomer (Sample 9) + CharFrequency (Sample 1)
        //          + CountStudentsByCourse (Sample 16)
        // Topic:   A GroupBy inside the value of another GroupBy
        // Tip 1:   Outer: group the ORDERS by customer (like Sample 9).
        // Tip 2:   Inner, for ONE group g: g.SelectMany(o => o.Products) gives all
        //          the products of that customer; then it's Sample 1 again.
        // Interview follow-up: "Why does Sofia stay but has no products?"
        //          (her ORDER makes the outer group; the inner has nothing to
        //          count). What would change if you flattened FIRST?
        // ========================================================================
        public Dictionary<string, Dictionary<string, int>> GetProductCountsByCustomer(List<Order> orders)
        {
            return orders.GroupBy(c => c.Customer)
                         .ToDictionary(g => g.Key , 
                                p => p.SelectMany(e => e.Products)
                                       .GroupBy(  s =>s)
                                       .ToDictionary(y => y.Key, x => 
                                                                x.Count())                         
                         );
        }

        // ========================================================================
        // SAMPLE 21: Top K most used hashtags (practice again: Sample 12)
        // ========================================================================
        // Words are separated by spaces (can be more than one). Only the words that
        // START with '#' are hashtags; ignore the rest. Ignore case: return them in
        // lower case, WITH the '#'. Most used first. Tie: A-Z.
        // ("#dotnet is fun #linq #DotNet #csharp #linq #dotnet", 2) -> ["#dotnet", "#linq"]
        //     #dotnet: 3, #linq: 2, #csharp: 1
        // ("#dotnet is fun #linq #DotNet #csharp #linq #dotnet", 3) -> ["#dotnet", "#linq", "#csharp"]
        // ("#b #a #c #a #b #c", 2)  -> ["#a", "#b"]    (all have 2: A-Z decides)
        // ("#Hi #hi #HI", 5)        -> ["#hi"]         (k bigger than the hashtags: all)
        // ("price a#b #x", 2)       -> ["#x"]          (a#b does NOT start with '#')
        // ("no tags here", 3)       -> []
        // ("", 3)                   -> []
        //
        // Difficulty: Easy-Medium
        // Goal: Time O(n + h log h) (h = different hashtags), Space O(h)
        // Expected time to solve: 8 min (Sample 12 took longer: beat it)
        // Pattern: GetTopKFrequentWords (Sample 12) + a Where BEFORE the GroupBy
        // Topic:   Where + GroupBy + OrderByDescending + ThenBy + Take
        // Interview follow-up: the Where could come AFTER the GroupBy too. Which
        //          is cheaper, and why? (hint: how many boxes get built?)
        // ========================================================================
        public List<string> GetTopKHashtags(string text, int k)
        {
            return       text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(t =>  t[0] == '#')
                        .GroupBy(x => x.ToLowerInvariant())
                        .OrderByDescending(g => g.Count())
                        .ThenBy(g => g.Key)
                        .Select(g => g.Key)
                        .Take(k)
                        .ToList();
        }

        // ========================================================================
        // SAMPLE 22: Employees by department AND salary level (practice again: Sample 17)
        // ========================================================================
        // Salary level: "High" if Salary >= 5000, else "Low".
        // Sort by department A-Z, then by level A-Z.
        // Format: "<Department> - <Level>: <count> (total <sum of salaries>)"
        // [Ana IT 6000, Luis HR 3000, Sofia IT 6000, Pedro IT 4500,
        //  Maria Sales 4000, Juan IT 5000, Lucia Sales 5500, Eva HR 5000]
        //   -> ["HR - High: 1 (total 5000)",    "HR - Low: 1 (total 3000)",
        //       "IT - High: 3 (total 17000)",   "IT - Low: 1 (total 4500)",
        //       "Sales - High: 1 (total 5500)", "Sales - Low: 1 (total 4000)"]
        //   (Juan and Eva are exactly 5000 -> High)
        // ([])  -> []
        //
        // Difficulty: Medium
        // Goal: Time O(n + g log g) (g = groups), Space O(n)
        // Expected time to solve: 12 min (Sample 17 took longer: beat it)
        // Pattern: CountPeopleByCityAndAgeGroup (Sample 17) + GetAverageSalaryByDepartment (Sample 14)
        // Topic:   Composite key + TWO aggregates in one text (Count AND Sum)
        // Tip 1:   Same steps as Sample 17. The key is
        //          new { e.Department, Level = e.Salary >= 5000 ? "High" : "Low" }
        //          and each box now holds Employee objects (not just names).
        // Tip 2:   Order of steps, as SQL, before you type:
        //          GroupBy -> OrderBy(department) -> ThenBy(level) -> Select(text) -> ToList().
        //          The text needs g.Count() AND g.Sum(e => e.Salary): both only
        //          exist while g is still a box, so Select goes LAST.
        // Tip 3:   Watch the exact text: "IT - High: 3 (total 17000)". One wrong
        //          space and the test fails (it happened in Sample 17).
        // Interview follow-up: use a TUPLE key instead: GroupBy(e => (e.Department, Level)).
        //          Then g.Key.Department and g.Key.Level (or g.Key.Item1 / Item2). When
        //          would you still prefer an anonymous type? (hint: names of the parts)
        // ========================================================================
        public List<string> CountEmployeesByDepartmentAndLevel(List<Employee> employees)
        {
            throw new NotImplementedException();
        }

        // ========================================================================
        // SAMPLE 23: Deal cards to players (practice again: Sample 18)
        // ========================================================================
        // Card 0 goes to player 0, card 1 to player 1, ... and when the players
        // run out, start again from player 0 (like dealing in a card game).
        // (["A","B","C","D","E","F","G"], 3) -> [["A","D","G"], ["B","E"], ["C","F"]]
        // (["A","B"], 5)                     -> [["A"], ["B"]]   (no empty hands)
        // ([], 3)                            -> []
        //
        // Difficulty: Medium
        // Goal: Time O(n), Space O(n)
        // Expected time to solve: 8 min (Sample 18 took longer: beat it)
        // Pattern: SplitIntoBatches (Sample 18): Select((x, i) => ...) + GroupBy on the INDEX
        // Topic:   Same idea, other key: i % players instead of i / size
        // Tip 1:   Read the TRACE of Sample 18 first. Step 1 is identical:
        //          Select((c, i) => new { c, i }). Only the key of GroupBy changes.
        // Tip 2:   % gives the REMAINDER: index 0,1,2,3,4,5,6 % 3 = 0,1,2,0,1,2,0.
        //          Players are the keys, so the first card of each player decides
        //          the group order (that's why the hands come out as player 0, 1, 2).
        // Interview follow-up: "What is the difference between i / size and i % size?"
        //          (/ makes CONSECUTIVE batches, % makes ROUND-ROBIN hands.)
        // ========================================================================
        public List<List<string>> DealCards(string[] cards, int players)
        {
            throw new NotImplementedException();
        }
    }
}
