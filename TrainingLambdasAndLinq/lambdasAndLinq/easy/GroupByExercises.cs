using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
        public List<string> GetCitiesWithAtLeast(List<Person> people, int minPeople)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
