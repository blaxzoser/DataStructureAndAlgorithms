# Tracking: TestTrainingLambdasAndLinq

Every exercise that has tests in `TestTrainingLambdasAndLinq`. Fill in a row each
time you solve (or re-solve) an exercise.

**How to fill it in**

- **Rounds**: one row per class each time you solve the whole class: real time
  (expected time in brackets), date and how many tests pass.
- **Checked**: `✅` all its tests pass · `❌` tests failing / reviewed with help · empty = not done yet.
- **Notes**: what went wrong, what you learned, what to remember.

Run the tests with:

```bash
dotnet test TestTrainingLambdasAndLinq/TestTrainingLambdasAndLinq.csproj
```

One class at a time:

```bash
dotnet test TestTrainingLambdasAndLinq/TestTrainingLambdasAndLinq.csproj --filter "FullyQualifiedName~ContainsExercisesTest"
```

---

## Rounds

| Class | Time | Date | Tests | Checked |
|---|---|---|---|---|
| `FirstExercises` | 20 min (35) | 2026-10-18 | 17 / 17 | ✅ |
| `WhereExercises` | 30 min (40) | 2026-10-18 | 14 / 14 | ✅ |
| `ContainsExercises` | 34 min (40) | 2026-10-25 | 24 / 24 | ✅ (after fix) |
| `SelectManyExercises` (1-5) | 30 min (45) | 2026-11-07 | 11 / 11 | ✅ |
| `SelectManyExercises` (6-15) | (150) | | | |
| `SkipExercises` | 45 min (40) | 2026-10-25 | 25 / 25 | ✅ (a little AI help: clues for 4 and 6) |
| `GroupByExercises` (1-5) | 60 min (45) | 2026-10-25 | 24 / 24 | ❌ (a lot of AI help: 4 and 5 written by Claude) |
| `GroupByExercises` (6-10) | (50) | | | |
| `GroupByExercises` (11-20) senior mock | (110) | | | |
| `ThenByExercises` | 50 min (85) | 2026-11-07 | 26 / 26 | ✅ |

---

## Easy

### First / FirstOrDefault — [FirstExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/FirstExercisesTest.cs)

| # | Exercise | Expected | Checked | Notes |
|---|---|---|---|---|
| 1 | `GetFirstGreaterThan` | 5 min | ✅ | `First(predicate)` throws when nothing matches; the test expects it |
| 2 | `GetFirstNegativeOrZero` | 5 min | ✅ | `FirstOrDefault` on `int` already gives 0 |
| 3 | `FindPersonByName` | 5 min | ✅ | `string.Equals(..., OrdinalIgnoreCase)` |
| 4 | `GetFirstWordStartingWith` | 10 min | ✅ | Works, but `StartsWith(letter.ToString())` makes a string per word and follows the computer's language settings. Better: `w.Length > 0 && w[0] == letter` |
| 5 | `GetFirstAdultNameInCity` | 10 min | ✅ | Split the conditions between `Where` and `FirstOrDefault`. Keep them together: `FirstOrDefault(p => p.City == city && p.Age >= 18)?.Name`. Name a `Person` `p`, not `s` |

### Where — [WhereExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/WhereExercisesTest.cs)

| # | Exercise | Expected | Checked | Notes |
|---|---|---|---|---|
| 1 | `GetEvenNumbers` | 5 min | ✅ | |
| 2 | `GetWordsLongerThan` | 5 min | ✅ | Closure: the lambda uses `minLength` from the method |
| 3 | `GetAdults` | 5 min | ✅ | |
| 4 | `GetPeopleFromCityOlderThan` | 10 min | ✅ | Both conditions in one lambda. Two chained `Where` calls also work and still make one pass (lazy) |
| 5 | `GetElementsAtEvenIndex` | 10 min | ✅ | `(e, i) =>` overload. Unused parameter → name it `_` |

### Contains / Any / All — [ContainsExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ContainsExercisesTest.cs)

| # | Exercise | Expected | Checked | Notes |
|---|---|---|---|---|
| 1 | `HasNumber` | 3 min | ✅ | Used `Any(x => x == target)`. Works, but `Contains(target)` is the one-call answer. Use `Any` when the check isn't plain equality (a property, a range...) |
| 2 | `CountVowels` | 5 min | ✅ | Correct. The topic was `Contains`: `"aeiou".Contains(char.ToLowerInvariant(c))` replaces the 5 `\|\|`. `text.ToLower()` copies the whole string |
| 3 | `ArrayDiff` | 5 min | ✅ (after fix) | First try had 2 bugs: no `.ToArray()` (error CS0266, it broke the build for the WHOLE test project) and no `!` (kept the values of `b` instead of removing them). Read the lambda out loud: "keep `n` if..." |
| 4 | `IsPangram` | 10 min | ✅ (after fix) | The hand-typed alphabet was missing `'u'`; added it. Old tests passed by luck (both sentences have a "u"); new test `"abcdefghijklmnopqrstvwxyz"` caught it. Still to improve: use the string `"abcdefghijklmnopqrstuvwxyz"` (easy to check), and `ToLower()` is still inside the lambda, so it runs 26 times: do it once before |
| 5 | `GetPeopleFromCities` | 5 min | ✅ | `cities.Contains(p.City)` = SQL `WHERE City IN (...)` |
| 6 | `IsBinary` | 5 min | ✅ | Correct with `All`. Try `!Any(s => s != "0" && s != "1")` too: same answer |
| 7 | `GetPeopleInCapitals` | 10 min | | Extra: `List<Person>` vs `List<City>` (different types). `Any(c => c.IsCapital && c.Name == p.City)`. Passes all tests (reviewed) |
| 7.1 | `GetPeopleInCapitalsFast` | 5 min | | Same as 7 but O(p + c): `Where` + `Select` + `HashSet<string>` built once, then `Contains`. Duplicate capitals must not repeat people |

### SelectMany — [SelectManyExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SelectManyExercisesTest.cs)

| # | Exercise | Expected | Checked | Notes |
|---|---|---|---|---|
| 1 | `Flatten` | 5 min | ✅ | `SelectMany(x => x)`: each inner array is already a collection |
| 2 | `GetAllCharacters` | 5 min | ✅ | A `string` is an `IEnumerable<char>`, so `SelectMany(w => w)` works. The lambda was named `words` (same as the array): name it `w` |
| 3 | `GetAllCourses` | 10 min | ✅ | Flatten → `Distinct` → `OrderBy`, in that order |
| 4 | `GetAllPairs` | 10 min | ✅ | Cross join: `SelectMany(n => letters.Select(l => ...))`. Empty `letters` gives `[]` for free |
| 5 | `GetCustomerProducts` | 15 min | ✅ | Result-selector overload `(order, product) => ...` keeps the parent data |
| 6 | `ExpandRunLength` | 15 min | | LeetCode 1313. `Enumerable.Range` over the pairs + `Enumerable.Repeat` |
| 7 | `Shuffle` | 15 min | | LeetCode 1470. One index IN, a small array OUT |
| 8 | `GetDistinctWords` | 15 min | | `Split` inside the `SelectMany` + lower case + `Distinct` + `OrderBy`. netstandard2.0: `Split(new[] { ' ' }, ...)` |
| 9 | `GetExcelCells` | 15 min | | LeetCode 2194. Cross join columns x rows; a `char` is a number |
| 10 | `GetPairsWithSum` | 15 min | | All pairs `i < j` (like `IsUniqueNoExtraSpace`). Follow-up: Two Sum in O(n) |
| 11 | `GetProductsBoughtInCity` | 15 min | | New POCO `Customer` -> `List<Order>` -> `List<string>`: two levels |
| 12 | `GetOrderLines` | 15 min | | `SelectMany` inside a `SelectMany` (closure keeps the customer) |
| 13 | `GetStudentsByCourse` | 15 min | | Many-to-many turned around: result selector -> `GroupBy` -> `ToDictionary` |
| 14 | `GetPeopleWithCountry` | 15 min | | `SelectMany` as an INNER JOIN between two `List<T>` (not `.Join()`) |
| 15 | `GetPeopleWithCountryOrUnknown` | 15 min | | LEFT JOIN: `SelectMany` + `DefaultIfEmpty`. Very common interview question |

### Skip / Take / SkipWhile / TakeWhile — [SkipExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SkipExercisesTest.cs)

| # | Exercise | Expected | Checked | Notes |
|---|---|---|---|---|
| 1 | `SkipFirst` | 3 min | ✅ | |
| 2 | `GetPage` | 10 min | ✅ | `Skip(pageSize * (pageNumber - 1)).Take(pageSize)`: page 1 skips 0. Instructions were unclear at first (page 3 missing); rewritten with a full page table. Interview extra: `pageNumber = 0` gives `Skip(-3)` = skip 0, so it silently returns page 1 |
| 3 | `GetLastN` | 5 min | ✅ | `.Take(n)` isn't needed: after skipping `Length - n` exactly n items are left. Works when n > Length because `Skip` treats a negative count as 0 (so no `Math.Max` needed) |
| 4 | `RemoveLeadingZeros` | 5 min | ✅ (after clue) | First try `SkipWhile(x => x != 0)` was backwards: the lambda must be `true` for what you SKIP. Say it out loud: "skip while it's zero" |
| 5 | `TakeUntilNegative` | 5 min | ✅ | `TakeWhile` stops at the first -1 and never looks again (unlike `Where`) |
| 6 | `RemoveFirstAndLast` | 10 min | ✅ (after clue) | First try took `Length - 1` (one too many). Keep = `Length - 2`. The 2 `if`s aren't needed: `Take` with a negative number returns nothing. Same lesson as RansomNote: too many special cases |

### GroupBy — [GroupByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercisesTest.cs)

| # | Exercise | Expected | Checked | Notes |
|---|---|---|---|---|
| 1 | `CharFrequency` | 5 min | ✅ | `GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count())`: the classic frequency count. See the TRACE + `CharFrequencyDebug` |
| 2 | `GetDuplicates` | 10 min | ✅ | Correct. After `GroupBy` the lambdas get a GROUP: name it `g`, not `x` / `s`. See the TRACE + `GetDuplicatesDebug` |
| 3 | `GroupNamesByCity` | 10 min | ✅ | Used the element-selector overload `GroupBy(c => c.City, p => p.Name)` (the bonus). Name the `Person` lambda `p` in both |
| 4 | `GetMostFrequentChar` | 10 min | ❌ | Solution written by Claude (it was still a stub). Re-do it from memory. Key: `OrderByDescending` is stable, so a tie keeps the first-seen char. See the TRACE + `GetMostFrequentCharDebug` |
| 5 | `GroupWordsByLength` | 10 min | ❌ | Solution written by Claude (it was still a stub). Re-do it from memory. Key: `OrderBy(g => g.Key)` sorts the GROUPS; `string.Join(", ", g)` works on a group directly. See the TRACE + `GroupWordsByLengthDebug` |
| 6 | `CountEvenAndOdd` | 5 min | | |
| 7 | `CountWordsByFirstLetter` | 10 min | | |
| 8 | `GetCitiesWithAtLeast` | 10 min | | |
| 9 | `CountProductsByCustomer` | 10 min | | |
| 10 | `GetOldestPersonByCity` | 15 min | | |
| 11 | `GetValuesAppearingOnce` | 5 min | | Warm-up: Sample 2 with `== 1` |
| 12 | `GetTopKFrequentWords` | 10 min | | `OrderByDescending` + `ThenBy` tie-break A-Z + `Take(k)` (LeetCode 692) |
| 13 | `BuildNamesByCityLookup` | 5 min | | `ToLookup`: runs now, missing key gives empty (no exception). Know GroupBy vs ToLookup |
| 14 | `GetAverageSalaryByDepartment` | 10 min | | `Employee` POCO. `g.Average(...)` + `Math.Round(x, 2)` |
| 15 | `GetSecondHighestSalaryByDepartment` | 15 min | | `Distinct` + `OrderByDescending` + `Skip(1)` + `FirstOrDefault` (0 when none) |
| 16 | `CountStudentsByCourse` | 10 min | | `SelectMany` BEFORE `GroupBy`; `Distinct` per student, not after flattening |
| 17 | `CountPeopleByCityAndAgeGroup` | 15 min | | Composite key `new { p.City, AgeGroup }`; `OrderBy` + `ThenBy` on `g.Key.X` |
| 18 | `SplitIntoBatches` | 10 min | | `Select((n, i) => ...)` + `GroupBy(x => x.i / size, x => x.n)` |
| 19 | `CountPeopleByCountry` | 15 min | | Build `ToDictionary` of cities ONCE, `TryGetValue` in the key, `"Unknown"` fallback |
| 20 | `GetProductCountsByCustomer` | 15 min | | Nested: GroupBy customer → `SelectMany` products → GroupBy product |
| 21 | `GetTopKHashtags` | 8 min | | Practice again Sample 12 + a `Where` BEFORE the `GroupBy` (`w[0] == '#'`). Don't reuse `k` as a lambda name |
| 22 | `CountEmployeesByDepartmentAndLevel` | 12 min | | Practice again Sample 17: composite key `{ Department, Level }` + `Count()` AND `Sum()` in one text. `Select` last; watch the exact text |

### ThenBy / ThenByDescending — [ThenByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ThenByExercisesTest.cs)

| # | Exercise | Expected | Checked | Notes |
|---|---|---|---|---|
| 1 | `SortWordsByLength` | 5 min | ✅ | `OrderBy(Length).ThenBy(w => w)`. Two `OrderBy` in a row throws the first sort away. Correct. Keep one lambda name per chain: `w` in both (`ThenBy(w => w)`), not `w` then `s` |
| 2 | `SortPeopleByAgeThenName` | 5 min | ✅ | Sort the `Person` first, `Select` the name LAST. Correct. Same lambda-name note as First 5: a `Person` is `p` in every step (`a`, `s` hide what it is) |
| 3 | `SortPeopleByCityThenOldest` | 8 min | ✅ | `ThenByDescending`: main ascending, tie-break descending. Correct |
| 4 | `SortEmployeesBySalaryThenName` | 5 min | ✅ | `OrderByDescending` + `ThenBy` (mirror of 3). Correct. Name an `Employee` `e` in every step (`n`, `o` read like a name and an order) |
| 5 | `EvensFirst` | 8 min | ✅ | Bool key: `false` before `true`. `% 2 != 0`, not `== 1` (negatives). Correct. An `int` lambda: `n`, not `p` / `s` |
| 6 | `SortWordsByLastLetter` | 8 min | ✅ | A `char` as the key: `w[w.Length - 1]`. Correct. Interview edge case: an empty word crashes on `w[w.Length - 1]` |
| 7 | `SortIgnoringCaseUpperFirst` | 10 min | ✅ | Key 1 `ToLowerInvariant()`, tie-break `char.IsLower(w[0])` (upper = false = first). Correct: `!char.IsUpper(w[0])` puts upper (false) first. `char.IsLower(w[0])` says the same without the double negative. Also valid: `OrderBy(w => w, StringComparer.OrdinalIgnoreCase)` (no lower-case copy of every word) |
| 8 | `SortLeaderboard` | 8 min | ✅ | Elements are `KeyValuePair`: `.Value` score, `.Key` name. Correct |
| 9 | `AdultsFirstThenByName` | 8 min | ✅ | Bool key where `true` must be first → `OrderByDescending`. Correct |
| 10 | `RankDepartments` | 12 min | ✅ | `GroupBy`, then `OrderByDescending(Count)` → `ThenByDescending(Sum)` → `ThenBy(Key)`. Correct, first try on 3 keys. After `GroupBy` name the lambda `g` (`g.Count()`, `g.Sum(e => e.Salary)`, `g.Key`) as in GroupBy 2. `OrderBy` works out each key once per group, so `Count()`/`Sum()` don't run on every comparison |

---

## Summary

| Topic | Total | ✅ | ❌ | Pending |
|---|---|---|---|---|
| First | 5 | 5 | 0 | 0 |
| Where | 5 | 5 | 0 | 0 |
| Contains | 8 | 6 | 0 | 2 |
| SelectMany | 15 | 5 | 0 | 10 |
| Skip | 6 | 6 | 0 | 0 |
| GroupBy | 22 | 3 | 2 | 17 |
| ThenBy | 10 | 10 | 0 | 0 |
| **All** | **71** | **40** | **2** | **29** |
