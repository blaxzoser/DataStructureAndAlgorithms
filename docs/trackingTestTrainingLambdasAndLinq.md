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
| `SelectManyExercises` | (45) | | | |
| `SkipExercises` | 45 min (40) | 2026-10-25 | 25 / 25 | ✅ (a little AI help: clues for 4 and 6) |
| `GroupByExercises` (1-5) | 60 min (45) | 2026-10-25 | 24 / 24 | ❌ (a lot of AI help: 4 and 5 written by Claude) |
| `GroupByExercises` (6-10) | (50) | | | |

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

### SelectMany — [SelectManyExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SelectManyExercisesTest.cs)

| # | Exercise | Expected | Checked | Notes |
|---|---|---|---|---|
| 1 | `Flatten` | 5 min | | |
| 2 | `GetAllCharacters` | 5 min | | |
| 3 | `GetAllCourses` | 10 min | | |
| 4 | `GetAllPairs` | 10 min | | |
| 5 | `GetCustomerProducts` | 15 min | | |

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

---

## Summary

| Topic | Total | ✅ | ❌ | Pending |
|---|---|---|---|---|
| First | 5 | 5 | 0 | 0 |
| Where | 5 | 5 | 0 | 0 |
| Contains | 6 | 6 | 0 | 0 |
| SelectMany | 5 | 0 | 0 | 5 |
| Skip | 6 | 6 | 0 | 0 |
| GroupBy | 10 | 3 | 2 | 5 |
| **All** | **37** | **25** | **2** | **10** |
