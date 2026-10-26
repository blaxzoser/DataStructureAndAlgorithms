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
| `SkipExercises` | (40) | | | |
| `GroupByExercises` | (45) | | | |

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
| 1 | `SkipFirst` | 3 min | | |
| 2 | `GetPage` | 10 min | | |
| 3 | `GetLastN` | 5 min | | |
| 4 | `RemoveLeadingZeros` | 5 min | | |
| 5 | `TakeUntilNegative` | 5 min | | |
| 6 | `RemoveFirstAndLast` | 10 min | | |

### GroupBy — [GroupByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercisesTest.cs)

| # | Exercise | Expected | Checked | Notes |
|---|---|---|---|---|
| 1 | `CharFrequency` | 5 min | | |
| 2 | `GetDuplicates` | 10 min | | |
| 3 | `GroupNamesByCity` | 10 min | | |
| 4 | `GetMostFrequentChar` | 10 min | | |
| 5 | `GroupWordsByLength` | 10 min | | |

---

## Summary

| Topic | Total | ✅ | ❌ | Pending |
|---|---|---|---|---|
| First | 5 | 5 | 0 | 0 |
| Where | 5 | 5 | 0 | 0 |
| Contains | 6 | 6 | 0 | 0 |
| SelectMany | 5 | 0 | 0 | 5 |
| Skip | 6 | 0 | 0 | 6 |
| GroupBy | 5 | 0 | 0 | 5 |
| **All** | **32** | **16** | **0** | **16** |
