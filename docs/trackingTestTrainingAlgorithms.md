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
| 14 | `FirstUniqueCharacter.FindIndex` | [FirstUniqueCharacterTest.cs](../TestTrainingAlgorithms/algorithms/easy/FirstUniqueCharacterTest.cs) | (15) | | | |
| 15 | `ValidAnagram.IsAnagram` | [ValidAnagramTest.cs](../TestTrainingAlgorithms/algorithms/easy/ValidAnagramTest.cs) | (15) | | | |
| 16 | `RansomNote.CanConstruct` | [RansomNoteTest.cs](../TestTrainingAlgorithms/algorithms/easy/RansomNoteTest.cs) | (15) | | | |

## Medium

| # | Exercise | Test file | Time | Date | Checked | Notes |
|---|---|---|---|---|---|---|
| 8 | `ValidPalindromeOneDeletion.CanBePalindrome` | [ValidPalindromeOneDeletionTest.cs](../TestTrainingAlgorithms/algorithms/medium/ValidPalindromeOneDeletionTest.cs) | (15) | | | |
| 9 | `ContainerWithMostWater.MaxArea` | [ContainerWithMostWaterTest.cs](../TestTrainingAlgorithms/algorithms/medium/ContainerWithMostWaterTest.cs) | (15) | | | |
| 17 | `LongestSubstringWithoutRepeating.LengthOfLongest` | [LongestSubstringWithoutRepeatingTest.cs](../TestTrainingAlgorithms/algorithms/medium/LongestSubstringWithoutRepeatingTest.cs) | (15) | | | |
| 18 | `GroupAnagrams.Group` | [GroupAnagramsTest.cs](../TestTrainingAlgorithms/algorithms/medium/GroupAnagramsTest.cs) | (15) | | | |

## Hard

| # | Exercise | Test file | Time | Date | Checked | Notes |
|---|---|---|---|---|---|---|
| 10 | `ValidPalindromeSkipAndDelete.CanBeValidPalindrome` | [ValidPalindromeSkipAndDeleteTest.cs](../TestTrainingAlgorithms/algorithms/hard/ValidPalindromeSkipAndDeleteTest.cs) | (15) | | | |
| 11 | `TrappingRainWater.Trap` | [TrappingRainWaterTest.cs](../TestTrainingAlgorithms/algorithms/hard/TrappingRainWaterTest.cs) | (15) | | | |

---

## Summary

| Level | Total | ✅ | ❌ | Pending |
|---|---|---|---|---|
| Easy | 12 | 6 | 1 | 5 |
| Medium | 4 | 0 | 0 | 4 |
| Hard | 2 | 0 | 0 | 2 |
| **All** | **18** | **6** | **1** | **11** |
