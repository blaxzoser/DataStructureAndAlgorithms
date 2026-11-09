# Tracking: TestTrainingAlgorithms

Every exercise that has tests in `TestTrainingAlgorithms`. Fill in a row each
time you solve (or re-solve) an exercise.

**How to fill it in**

- **Time**: how long it really took you (expected time in brackets).
- **Date**: when you solved it (`yyyy-mm-dd`).
- **Checked**: `✅` all its tests pass · `❌` tests failing / reviewed with help · empty = not done yet.
- **Notes**: what went wrong, what you learned, what to remember.

Run the tests with:

```bash
dotnet test TestTrainingAlgorithms/TestTrainingAlgorithms.csproj
```

---

## Easy

| # | Exercise | Test file | Time | Date | Checked | Notes |
|---|---|---|---|---|---|---|
| 1 | `Palindrome.IsPalindrome` | [PalindromeTest.cs](../TestTrainingAlgorithms/algorithms/easy/PalindromeTest.cs) | 15 min (10) | 2026-10-18 | ✅ | Use `while` instead of `do...while`: no special case for `""` |
| 2 | `Palindrome.IsValidPalindrome` | [PalindromeTest.cs](../TestTrainingAlgorithms/algorithms/easy/PalindromeTest.cs) | 30 min (15) | 2026-10-18 | ✅ | Built a clean copy (Space O(n)) and crashes on `null` |
| 3 | `Palindrome.IsPalindromeNumber` | [PalindromeTest.cs](../TestTrainingAlgorithms/algorithms/easy/PalindromeTest.cs) | 20 min (15) | 2026-10-18 | ❌ | Only checked the last digit; solution written by Claude. Re-do it from memory |
| 4 | `Palindrome.Sample1Refactor` | [PalindromeTest.cs](../TestTrainingAlgorithms/algorithms/easy/PalindromeTest.cs) | (10) | | | Reference solution by Claude. Re-write it from memory to check it stuck |
| 5 | `Palindrome.Sample2Refactor` | [PalindromeTest.cs](../TestTrainingAlgorithms/algorithms/easy/PalindromeTest.cs) | (15) | | | Reference solution by Claude. Key: the 2 inner `while` loops that skip |
| 6 | `ReverseOnlyLetters.Reverse` | [ReverseOnlyLettersTest.cs](../TestTrainingAlgorithms/algorithms/easy/ReverseOnlyLettersTest.cs) | 40 min (15) | 2026-10-24 | ✅ | First try used if/else if and hung when both sides were symbols. Rewrote with the 2 inner whiles. Also missed `)` and a `!` |
| 7 | `ReverseVowels.Reverse` | [ReverseVowelsTest.cs](../TestTrainingAlgorithms/algorithms/easy/ReverseVowelsTest.cs) | 20 min (15) | 2026-10-24 | ✅ | Loop with the 2 inner whiles written from memory, plus helper `IsVowel`. Fixed `text.ToString()` → `new string(text)` and removed `ToLower()` (it changed the output) |
| 12 | `UniqueCharacters.IsUnique` | [UniqueCharactersTest.cs](../TestTrainingAlgorithms/algorithms/easy/UniqueCharactersTest.cs) | 30 min (10) | 2026-10-24 | ✅ | New pattern: seen set. Correct with `HashSet` + `Contains`/`Add`. The `Length == 1 \|\| ""` check isn't needed (the loop handles it), and `if (!hash.Add(c)) return false;` does check + add in one call |
| 13 | `UniqueCharacters.IsUniqueNoExtraSpace` | [UniqueCharactersTest.cs](../TestTrainingAlgorithms/algorithms/easy/UniqueCharactersTest.cs) | 12 min (15) | 2026-10-24 | ✅ | Follow-up: no HashSet, compare every pair. Under the expected time. `j = i + 1` avoids comparing a char with itself. Same unneeded `Length == 1` / `""` check as `IsUnique` |
| 14 | `FirstUniqueCharacter.FindIndex` | [FirstUniqueCharacterTest.cs](../TestTrainingAlgorithms/algorithms/easy/FirstUniqueCharacterTest.cs) | 30 min (15) | 2026-10-24 | ✅ | Score 7/10 before the fix. Right shape (count in a `Dictionary`, then 2nd pass over the string), but checked `> 1` (first repeated) instead of `== 1` (first unique). Extra `Length == 1` check again |
| 15 | `ValidAnagram.IsAnagram` | [ValidAnagramTest.cs](../TestTrainingAlgorithms/algorithms/easy/ValidAnagramTest.cs) | 20 min (15) | 2026-10-25 | ✅ | Fixed: all 11 pass (~9/10). Before the fix: score 5/10, 3 of 11 tests failed (every "true" case). Right idea (count first, subtract second, `Count == 0`), but `Add(c, i)` stores the INDEX instead of 1, and the 2nd loop reads `source[i]` (first string) instead of `second[i]`. The "false" tests passed by accident |
| 16 | `RansomNote.CanConstruct` | [RansomNoteTest.cs](../TestTrainingAlgorithms/algorithms/easy/RansomNoteTest.cs) | 20 min (15) | 2026-10-25 | ❌ | Score 6/10, 2 of 10 tests fail (`NullReferenceException` on `null`). Main logic is right (count the note, use up with the magazine, `Count == 0`). The 5 special-case lines at the top cause the bugs: `.Trim()` / `.Length` run before the `null` checks. One line `if (note == null \|\| magazine == null) return false;` replaces all 5 |
| 19 | `AssignCookies.MaxContentChildren` | [AssignCookiesTest.cs](../TestTrainingAlgorithms/algorithms/easy/AssignCookiesTest.cs) | (15) | | | First greedy (simpler than `ContainerWithMostWater`): sort both, give each cookie to the least greedy sad child |

## Medium

| # | Exercise | Test file | Time | Date | Checked | Notes |
|---|---|---|---|---|---|---|
| 8 | `ValidPalindromeOneDeletion.CanBePalindrome` | [ValidPalindromeOneDeletionTest.cs](../TestTrainingAlgorithms/algorithms/medium/ValidPalindromeOneDeletionTest.cs) | (15) | | | |
| 9 | `ContainerWithMostWater.MaxArea` | [ContainerWithMostWaterTest.cs](../TestTrainingAlgorithms/algorithms/medium/ContainerWithMostWaterTest.cs) | (15) | | | |
| 17 | `LongestSubstringWithoutRepeating.LengthOfLongest` | [LongestSubstringWithoutRepeatingTest.cs](../TestTrainingAlgorithms/algorithms/medium/LongestSubstringWithoutRepeatingTest.cs) | (15) | | | |
| 18 | `GroupAnagrams.Group` | [GroupAnagramsTest.cs](../TestTrainingAlgorithms/algorithms/medium/GroupAnagramsTest.cs) | (15) | | | |
| 20 | `BoatsToSavePeople.MinBoats` | [BoatsToSavePeopleTest.cs](../TestTrainingAlgorithms/algorithms/medium/BoatsToSavePeopleTest.cs) | (15) | | | Practice for `ContainerWithMostWater`: sort + two pointers, the heaviest always boards, the lightest only if it fits |
| 24 | `ThreeSumClosest.FindClosestSum` | [ThreeSumClosestTest.cs](../TestTrainingAlgorithms/algorithms/medium/ThreeSumClosestTest.cs) | (30) | | | Second round of `ThreeSum`: sort + fix one + two pointers, but return the sum closest to a target. No duplicate skipping; keep one `best` variable, start it with the first 3 sorted numbers |

## Hard

| # | Exercise | Test file | Time | Date | Checked | Notes |
|---|---|---|---|---|---|---|
| 10 | `ValidPalindromeSkipAndDelete.CanBeValidPalindrome` | [ValidPalindromeSkipAndDeleteTest.cs](../TestTrainingAlgorithms/algorithms/hard/ValidPalindromeSkipAndDeleteTest.cs) | (15) | | | |
| 11 | `TrappingRainWater.Trap` | [TrappingRainWaterTest.cs](../TestTrainingAlgorithms/algorithms/hard/TrappingRainWaterTest.cs) | (15) | | | |
| 21 | `EmailGenerator.Generate` | [EmailGeneratorTest.cs](../TestTrainingAlgorithms/algorithms/hard/EmailGeneratorTest.cs) | 90 min (60 → 30 after simplifying) | 2026-11-08 | ✅ | **Score 6/10**: 15/15 tests pass, but 90 min vs 60 expected and it needed help 3 times. **Common mistakes (check before submitting):** (1) `TakeWhile` where a `Where` filter was needed, and an `IEnumerable<char>` inside `$"{...}"` prints the type name: use `string.Concat(...)`. (2) `Select((i, v) => ...)`: the order is (element, index). (3) `return null` inside `Select` for empty entries, then `string.Join` still adds `, `: filter with `Where(!IsNullOrWhiteSpace)` BEFORE the `Select`; `IsNullOrEmpty` lets `" "` through. (4) Handling name shapes one by one (`Length == 1/2/3`): the last name is always `words[^1]`/`words[Length - 1]` and the first is `words[0]`, so 4+ words still work. (5) Building the output from `[0]`+`[1]`+`[2]`: use `string.Join(" ", words)`. (6) Letters-only filter applied in one branch but not the others: clean the last name once, before the `if`s. (7) Case: the dictionary key must ignore case, but the email keeps the last name's case: `Dictionary` with `StringComparer.OrdinalIgnoreCase` instead of `.ToLower()` on every access. (8) `ContainsKey` + 3 times the key lookup: `TryGetValue` once, `count + 1`. |
| 22 | `UsernameGenerator.Generate` | [UsernameGeneratorTest.cs](../TestTrainingAlgorithms/algorithms/hard/UsernameGeneratorTest.cs) | (60) | | | Practice for `EmailGenerator`: some usernames are already taken, so find the smallest FREE number (HashSet + Dictionary "next number") |
| 23 | `ThreeSum.CountTriplets` | [ThreeSumTest.cs](../TestTrainingAlgorithms/algorithms/hard/ThreeSumTest.cs) | (60) | | | Sort + fix one + two pointers moved by the sum (`IsSumPairEqualToTarget`), skip repeats with `Sample2Refactor`'s inner whiles. Counts unique triplets |

---

## Summary

| Level | Total | ✅ | ❌ | Pending |
|---|---|---|---|---|
| Easy | 13 | 8 | 2 | 3 |
| Medium | 6 | 0 | 0 | 6 |
| Hard | 5 | 1 | 0 | 4 |
| **All** | **24** | **9** | **2** | **13** |
