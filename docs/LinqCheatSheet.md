# LINQ Cheat Sheet

Quick reminders for the LINQ operators practiced in `TrainingLambdasAndLinq`.
Every example below comes from an exercise you already solved (class + method
name in brackets), so you can open the code and the test next to it.

Update this file every time you solve a new LINQ exercise.

Related: [CheatSheet.md](CheatSheet.md) (algorithms) ·
[trackingTestTrainingLambdasAndLinq.md](trackingTestTrainingLambdasAndLinq.md) (rounds and notes)

---

## 1. Which operator do I need?

| I want to…                                   | Use                                   | Section |
|----------------------------------------------|---------------------------------------|---------|
| keep only some elements                      | `Where`                               | [2](#2-where--filter) |
| get ONE element                              | `First` / `FirstOrDefault`            | [3](#3-first--firstordefault--take-one) |
| ask a yes/no question                        | `Contains` / `Any` / `All`            | [4](#4-contains--any--all--yesno) |
| count / add up                               | `Count(pred)` / `Sum` / `Average`     | [4](#4-contains--any--all--yesno), [7](#7-groupby--buckets) |
| take a slice (first n, skip n, a page)       | `Skip` / `Take` / `SkipWhile` / `TakeWhile` | [5](#5-skip--take--skipwhile--takewhile--slices) |
| sort, and break ties                         | `OrderBy` + `ThenBy`                  | [6](#6-orderby--thenby--sort-and-break-ties) |
| put elements into buckets / count each value | `GroupBy` (+ `ToDictionary`)          | [7](#7-groupby--buckets) |
| look up groups by key later                  | `ToLookup`                            | [7](#7-groupby--buckets) |
| flatten a list of lists                      | `SelectMany`                          | [8](#8-selectmany--flatten) |
| change each element (1 in → 1 out)           | `Select` / `Select((x, i) => …)`      | [9](#9-select--distinct--small-helpers) |
| remove repeats                               | `Distinct` / `HashSet<T>`             | [9](#9-select--distinct--small-helpers) |

**Read a chain like SQL:**

```
FROM    people                       people
WHERE   p.Age >= 18                  .Where(p => p.Age >= 18)
GROUP BY p.City                      .GroupBy(p => p.City)
HAVING  COUNT(*) >= 2                .Where(g => g.Count() >= 2)
ORDER BY City, …                     .OrderBy(g => g.Key).ThenBy(…)
SELECT  City                         .Select(g => g.Key)
                                     .ToList()          // runs it all
```

---

## 2. Where — filter

Keeps the elements where the lambda returns `true`. Does not change them.
**Lazy:** nothing runs until `ToList` / `ToArray` / `foreach`.

```csharp
numbers.Where(n => n % 2 == 0).ToArray();                    // [WhereExercises.GetEvenNumbers]
words.Where(w => w.Length > minLength).ToArray();            // closure: uses a method parameter
people.Where(p => p.Age >= 18).ToList();                     // over objects

// several conditions + ignore case                           [GetPeopleFromCityOlderThan]
people.Where(p => string.Equals(p.City, city, StringComparison.OrdinalIgnoreCase)
               && p.Age > minAge)
      .ToList();

// filter by POSITION: (element, index)                       [GetElementsAtEvenIndex]
words.Where((w, i) => i % 2 == 0).ToArray();                 // ["a","b","c","d","e"] -> ["a","c","e"]
```

---

## 3. First / FirstOrDefault — take one

| Call                     | Match found | No match                         |
|--------------------------|-------------|----------------------------------|
| `First(pred)`            | the element | **throws** `InvalidOperationException` |
| `FirstOrDefault(pred)`   | the element | `default(T)`: `0` for `int`, `null` for classes/strings |

Both **stop** at the first match.

```csharp
numbers.First(n => n > value);                               // [FirstExercises.GetFirstGreaterThan] throws if none
numbers.FirstOrDefault(n => n < 0);                          // [GetFirstNegativeOrZero] 0 if none

people.FirstOrDefault(p => string.Equals(p.Name, name,       // [FindPersonByName] null if none
                         StringComparison.OrdinalIgnoreCase));

words.FirstOrDefault(w => w.Length > 0 && w[0] == letter)    // [GetFirstWordStartingWith]
     ?? "NOT FOUND";                                         // ?? = fallback when null

people.FirstOrDefault(p => p.City == city && p.Age >= 18)    // [GetFirstAdultNameInCity]
      ?.Name;                                                // ?. = don't crash when null
```

`Where(pred).FirstOrDefault()` and `FirstOrDefault(pred)` give the same result;
the second one reads shorter.

---

## 4. Contains / Any / All — yes/no

| Call              | `true` when                       | Empty list |
|-------------------|-----------------------------------|------------|
| `Contains(value)` | that exact value is there         | `false`    |
| `Any(pred)`       | **at least one** matches          | `false`    |
| `All(pred)`       | **every** element matches         | **`true`** |

All three stop as soon as they know the answer.
`All(x => ok)` == `!Any(x => !ok)`.

```csharp
numbers.Contains(target);                                        // [ContainsExercises.HasNumber]
numbers.Any(n => n == target);                                   // same; Any when you need a condition
text.ToLower().Count(c => "aeiou".Contains(c));                  // [CountVowels] Count(pred)

a.Where(x => !b.Contains(x)).ToArray();                          // [ArrayDiff] remove every value of b

var lower = sentence.ToLower();                                  // [IsPangram] once, OUTSIDE the lambda
"abcdefghijklmnopqrstuvwxyz".All(c => lower.Contains(c));

text.Split(',').All(s => s == "0" || s == "1");                  // [IsBinary]

// SQL "WHERE City IN (...)"                                       [GetPeopleFromCities]
people.Where(p => cities.Contains(p.City)).ToList();
```

**Two lists of different types** (`List<Person>` vs `List<City>`):
`cities.Contains(p.City)` doesn't compile, so use `Any`, or build a `HashSet` once.

```csharp
// O(p * c): rescans cities for every person                     [GetPeopleInCapitals]
people.Where(p => cities.Any(c => c.IsCapital && c.Name == p.City)).ToList();

// O(p + c): build the lookup ONCE, before the Where             [GetPeopleInCapitalsFast]
var capitals = new HashSet<string>(cities.Where(c => c.IsCapital).Select(c => c.Name));
people.Where(p => capitals.Contains(p.City)).ToList();
```

> Rule: anything that does **not** depend on the lambda variable belongs
> **outside** the lambda (`ToLower`, the `HashSet`, a `Dictionary`).

---

## 5. Skip / Take / SkipWhile / TakeWhile — slices

| Call              | Does                                                        |
|-------------------|-------------------------------------------------------------|
| `Skip(n)`         | drop the first n                                            |
| `Take(n)`         | keep the first n                                            |
| `SkipWhile(pred)` | drop while `pred` is true, then keep **everything** after   |
| `TakeWhile(pred)` | keep while `pred` is true, then **stop**                    |

Never throw: `[1,2].Skip(5)` → `[]`, `[1,2].Take(5)` → `[1,2]`, `Take(-1)` → `[]`, `Skip(-1)` = `Skip(0)`.

```csharp
numbers.Skip(count).ToArray();                                   // [SkipExercises.SkipFirst]

// PAGINATION (pages start at 1)                                  [GetPage]
items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArray();

numbers.Skip(Math.Max(0, numbers.Length - n)).ToArray();         // [GetLastN] no TakeLast in netstandard2.0

digits.SkipWhile(d => d == 0).ToArray();                         // [RemoveLeadingZeros] [0,0,1,0,2] -> [1,0,2]
numbers.TakeWhile(n => n >= 0).ToArray();                        // [TakeUntilNegative]  [3,5,-1,7] -> [3,5]

items.Skip(1).Take(items.Length - 2).ToArray();                  // [RemoveFirstAndLast] Take(negative) = []
```

**Trap:** `Where(n => n != 0)` also removes the zero in the **middle**.
`SkipWhile`/`TakeWhile` stop checking after the first `false`.

---

## 6. OrderBy / ThenBy — sort and break ties

```
OrderBy(a)             main sort, ascending (A-Z, small -> big)
OrderByDescending(a)   main sort, descending
ThenBy(b)              tie-break, ascending   (only reorders items with the SAME a)
ThenByDescending(b)    tie-break, descending
```

**Classic mistake:** `OrderBy(a).OrderBy(b)` — the 2nd `OrderBy` throws away
the 1st sort. For a tie-break always use `ThenBy`.

Sorting is **stable**: equal keys keep their original order.

```csharp
words.OrderBy(w => w.Length).ThenBy(w => w).ToList();            // [ThenByExercises.SortWordsByLength]

people.OrderBy(p => p.Age).ThenBy(p => p.Name)                   // [SortPeopleByAgeThenName]
      .Select(p => p.Name).ToList();

people.OrderBy(p => p.City).ThenByDescending(p => p.Age)         // [SortPeopleByCityThenOldest]
      .Select(p => p.Name).ToList();

employees.OrderByDescending(e => e.Salary).ThenBy(e => e.Name)   // [SortEmployeesBySalaryThenName]
         .Select(e => e.Name).ToList();

// char key, empty-safe                                          [SortWordsByLastLetter]
words.OrderBy(w => w.Length > 0 ? w[w.Length - 1] : '\0').ThenBy(w => w).ToList();

// ignore case, then UPPER first                                 [SortIgnoringCaseUpperFirst]
words.OrderBy(w => w, StringComparer.OrdinalIgnoreCase)
     .ThenBy(w => char.IsLower(w[0])).ToList();

// Dictionary: the element is a KeyValuePair                     [SortLeaderboard]
scores.OrderByDescending(kv => kv.Value).ThenBy(kv => kv.Key)
      .Select(kv => kv.Key).ToList();
```

**A `bool` as sort key:** `false` comes **before** `true`.

```csharp
numbers.OrderBy(n => n % 2 != 0).ThenBy(n => n).ToList();        // [EvensFirst] odd = true = last
people.OrderByDescending(p => p.Age >= 18)                       // [AdultsFirstThenByName] adult = true = first
      .ThenBy(p => p.Name).Select(p => p.Name).ToList();
```

**Sorting GROUPS with three keys:**

```csharp
employees.GroupBy(e => e.Department)                             // [RankDepartments]
         .OrderByDescending(g => g.Count())                      // 1) more people
         .ThenByDescending(g => g.Sum(e => e.Salary))            // 2) bigger total
         .ThenBy(g => g.Key)                                     // 3) name A-Z
         .Select(g => g.Key)
         .ToList();
```

---

## 7. GroupBy — buckets

`GroupBy(key)` puts every element into a bucket by its key. Each bucket is an
`IGrouping<TKey, TElement>`:

- `g.Key` → the value they share
- `g` itself → the elements (`g.Count()`, `g.Sum(…)`, `g.Select(…)`, `g.ToList()`)

Groups come out in the order their key is **first seen**.

**Name the lambda `g` after `GroupBy`** — from there on every lambda gets a
**box**, not an element:

```
before GroupBy -> Person (p)  -> pick a field:  p.City
after  GroupBy -> a box  (g)  -> ask the box:   g.Key, g.Count(), g.Max(p => p.Age)
```

### 7.1 Count each value (the interview classic)

```csharp
text.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());  // [GroupByExercises.CharFrequency]
// "hello" -> { h:1, e:1, l:2, o:1 }
```

### 7.2 Filter groups (SQL `HAVING`)

```csharp
numbers.GroupBy(n => n).Where(g => g.Count() > 1)                // [GetDuplicates]  [4,1,4,2,1,4] -> [4,1]
       .Select(g => g.Key).ToArray();

numbers.GroupBy(n => n).Where(g => g.Count() == 1)               // [GetValuesAppearingOnce]
       .Select(g => g.Key).ToArray();

people.GroupBy(p => p.City)                                      // [GetCitiesWithAtLeast]
      .Where(g => g.Count() >= minPeople)                        // BEFORE Select(g => g.Key)!
      .OrderBy(g => g.Key)
      .Select(g => g.Key)
      .ToList();
```

### 7.3 Computed key (not the element itself)

```csharp
numbers.GroupBy(n => n % 2 == 0 ? "Even" : "Odd")                // [CountEvenAndOdd]
       .ToDictionary(g => g.Key, g => g.Count());

words.GroupBy(w => char.ToLowerInvariant(w[0]))                  // [CountWordsByFirstLetter] normalize the KEY
     .ToDictionary(g => g.Key, g => g.Count());
```

### 7.4 Choose what goes inside the bucket (2nd lambda)

```csharp
people.GroupBy(p => p.City, p => p.Name)                         // [GroupNamesByCity]
      .ToDictionary(g => g.Key, g => g.ToList());
// { "Lima": ["Ana","Sofia"], "Quito": ["Luis"] }
```

### 7.5 ToLookup — GroupBy that runs NOW

```csharp
people.ToLookup(p => p.City, p => p.Name);                       // [BuildNamesByCityLookup]
// lookup["Cusco"] -> []   (a Dictionary would throw KeyNotFoundException)
```

| | `GroupBy` | `ToLookup` |
|---|---|---|
| Runs | lazy (again on every `foreach`) | immediately, once |
| Missing key | — | empty sequence |
| Editable | — | read-only |

### 7.6 Sort the groups / format each group

```csharp
// most frequent, tie = first seen (stable sort)                 [GetMostFrequentChar]
text.Where(c => c != ' ').GroupBy(c => c)
    .OrderByDescending(g => g.Count()).First().Key;

// one line of text per group                                    [GroupWordsByLength]
words.GroupBy(w => w.Length).OrderBy(g => g.Key)
     .Select(g => $"{g.Key}: {string.Join(", ", g)}").ToList();
// ["2: ox", "3: cat, dog", "4: bird", "5: horse"]

// Top K, tie A-Z                                                [GetTopKFrequentWords]
sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .GroupBy(w => w.ToLowerInvariant())
        .OrderByDescending(g => g.Count())
        .ThenBy(g => g.Key)
        .Take(k)
        .Select(g => g.Key)
        .ToList();

// same + Where BEFORE GroupBy (fewer boxes)                     [GetTopKHashtags]
text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
    .Where(t => t[0] == '#')
    .GroupBy(t => t.ToLowerInvariant())
    .OrderByDescending(g => g.Count()).ThenBy(g => g.Key)
    .Select(g => g.Key).Take(k).ToList();
```

### 7.7 Aggregates / work INSIDE each group

```csharp
orders.GroupBy(o => o.Customer)                                  // [CountProductsByCustomer]
      .ToDictionary(g => g.Key, g => g.Sum(o => o.Products.Count));   // g.Count() would count ORDERS

employees.GroupBy(e => e.Department)                             // [GetAverageSalaryByDepartment]
         .ToDictionary(g => g.Key, g => Math.Round(g.Average(e => e.Salary), 2));

people.GroupBy(p => p.City)                                      // [GetOldestPersonByCity] sort INSIDE the group
      .ToDictionary(g => g.Key, g => g.OrderByDescending(p => p.Age).First().Name);

employees.GroupBy(e => e.Department)                             // [GetSecondHighestSalaryByDepartment]
         .ToDictionary(g => g.Key,
                       g => g.Select(e => e.Salary)
                             .Distinct()
                             .OrderByDescending(s => s)
                             .Skip(1)                            // Nth highest = Skip(n - 1)
                             .FirstOrDefault());                 // 0 when there is none
```

`Average()` on an empty sequence throws — never a problem inside a group
(a group always has at least 1 element).

### 7.8 Composite key (GROUP BY two columns)

```csharp
people.GroupBy(p => new { p.City, AgeGroup = p.Age >= 18 ? "Adult" : "Minor" })   // [CountPeopleByCityAndAgeGroup]
      .OrderBy(g => g.Key.City)
      .ThenBy(g => g.Key.AgeGroup)
      .Select(g => $"{g.Key.City} - {g.Key.AgeGroup}: {g.Count()}")
      .ToList();
// ["Lima - Adult: 3", "Lima - Minor: 1", "Quito - Adult: 1", "Quito - Minor: 1"]
```

An anonymous type (or a tuple `(p.City, group)`) works as a key because it
compares by **value**. A normal class compares by reference → one group per object.

### 7.9 Group by POSITION (batches)

`GroupBy` has no `(x, i)` overload, so attach the index with `Select` first.

```csharp
numbers.Select((n, i) => new { n, i })                           // [SplitIntoBatches]
       .GroupBy(x => x.i / size, x => x.n)                       // i / size -> consecutive batches
       .Select(g => g.ToList())
       .ToList();
// ([1..7], 3) -> [[1,2,3], [4,5,6], [7]]
// i % players  -> round-robin hands (deal cards)
```

### 7.10 Flatten BEFORE grouping / GroupBy inside a GroupBy

```csharp
students.SelectMany(s => s.Courses.Distinct())                   // [CountStudentsByCourse]
        .GroupBy(c => c)
        .ToDictionary(g => g.Key, g => g.Count());

orders.GroupBy(o => o.Customer)                                  // [GetProductCountsByCustomer]
      .ToDictionary(g => g.Key,
                    g => g.SelectMany(o => o.Products)
                          .GroupBy(p => p)
                          .ToDictionary(pg => pg.Key, pg => pg.Count()));
// { "Ana": { Pen:2, Book:1 }, "Luis": { Cup:1 }, "Sofia": { } }
```

---

## 8. SelectMany — flatten

```
Select     -> 1 in, 1 out     -> [[1,2],[3]]   (list of lists)
SelectMany -> 1 in, MANY out  -> [1,2,3]       (one flat list)
```

```csharp
matrix.SelectMany(row => row).ToArray();                         // [SelectManyExercises.Flatten]
words.SelectMany(w => w).ToArray();                              // [GetAllCharacters] a string IS IEnumerable<char>

students.SelectMany(s => s.Courses)                              // [GetAllCourses]
        .Distinct().OrderBy(c => c).ToList();

// cross join = replaces a double foreach                        [GetAllPairs]
numbers.SelectMany(n => letters.Select(l => n.ToString() + l)).ToArray();
// ([1,2], ["a","b"]) -> ["1a","1b","2a","2b"]

// result selector: keep the PARENT next to each child           [GetCustomerProducts]
orders.SelectMany(o => o.Products, (order, product) => order.Customer + ":" + product)
      .ToList();
// ["Ana:Pen", "Ana:Book", "Luis:Cup"]
```

---

## 9. Select / Distinct / small helpers

```csharp
list.Select(x => x.Name)                // 1 in -> 1 out (change the shape)
list.Select((x, i) => new { x, i })     // element + index
list.Distinct()                         // remove repeats (keeps first-seen order)
new HashSet<string>(seq)                // remove repeats + O(1) Contains
string.Join(", ", seq)                  // seq -> "a, b, c"
s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)   // netstandard2.0 form
```

**Ending the chain:** `ToList()` / `ToArray()` / `ToDictionary(k, v)` / `ToLookup(k, v)`
run the lazy chain. Without them you return an `IEnumerable` → error
`CS0266` when the method returns `List<T>` / `T[]`.

---

## 10. Pitfalls checklist

- [ ] After `GroupBy`, the lambda gets a **group**: call it `g`, not `x` / `s`.
- [ ] `Where(g => g.Count() …)` goes **before** `Select(g => g.Key)` (after it, `Count()` counts characters).
- [ ] Two `OrderBy` in a row → only the last one counts. Use `ThenBy`.
- [ ] `OrderBy` instead of `OrderByDescending` → you get the **least** frequent.
- [ ] `.Max(g => g.Count())` returns the **count**, not the key.
- [ ] `First()` on an empty sequence throws; `FirstOrDefault()` returns `0` / `null`.
- [ ] `All()` on an empty list is `true`.
- [ ] Work that doesn't depend on the lambda variable goes **outside** the lambda.
- [ ] `Any` inside a `Where` = O(n · m). A `HashSet` / `Dictionary` built once = O(n + m).
- [ ] `ToDictionary` throws if two elements give the same key.
- [ ] Exact text in `$"..."` — one extra space and the test fails.
- [ ] netstandard2.0 has no `TakeLast`, `Chunk`, `Split(' ', options)`.

---

## 11. Time / Space quick guide

| Operation                                   | Time            | Notes |
|---------------------------------------------|-----------------|-------|
| `Where`, `Select`, `SelectMany`, `Skip`, `Take` | O(n)        | lazy, one pass |
| `First`, `Any`, `All`, `Contains` (list)    | O(n) worst      | stop early |
| `HashSet.Contains`, `Dictionary` lookup     | O(1)            | build once: O(n) |
| `GroupBy`, `ToLookup`, `ToDictionary`, `Distinct` | O(n)      | Space O(n) |
| `OrderBy` (+ `ThenBy`)                      | O(n log n)      | stable |
| `Count()` / `Sum` / `Average` on a group    | O(group size)   | |

---

## 12. Progress log

| Class                     | Solved samples               | Still open |
|---------------------------|------------------------------|------------|
| `WhereExercises`          | 1–5                          | — |
| `FirstExercises`          | 1–5                          | — |
| `ContainsExercises`       | 1–7.1                        | — |
| `SkipExercises`           | 1–6                          | — |
| `ThenByExercises`         | 1–10                         | — |
| `GroupByExercises`        | 1–18, 20, 21                 | 19 `CountPeopleByCountry`, 22 `CountEmployeesByDepartmentAndLevel`, 23 `DealCards` |
| `SelectManyExercises`     | 1–5                          | 6–15 (Range/Repeat, joins, `DefaultIfEmpty`) |
