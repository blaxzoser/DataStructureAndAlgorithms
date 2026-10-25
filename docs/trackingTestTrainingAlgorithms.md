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
| 7 | `ReverseVowels.Reverse` | [ReverseVowelsTest.cs](../TestTrainingAlgorithms/algorithms/easy/ReverseVowelsTest.cs) | (15) | | | |

## Medium

| # | Exercise | Test file | Time | Date | Checked | Notes |
|---|---|---|---|---|---|---|
| 8 | `ValidPalindromeOneDeletion.CanBePalindrome` | [ValidPalindromeOneDeletionTest.cs](../TestTrainingAlgorithms/algorithms/medium/ValidPalindromeOneDeletionTest.cs) | (15) | | | |
| 9 | `ContainerWithMostWater.MaxArea` | [ContainerWithMostWaterTest.cs](../TestTrainingAlgorithms/algorithms/medium/ContainerWithMostWaterTest.cs) | (15) | | | |

## Hard

| # | Exercise | Test file | Time | Date | Checked | Notes |
|---|---|---|---|---|---|---|
| 10 | `ValidPalindromeSkipAndDelete.CanBeValidPalindrome` | [ValidPalindromeSkipAndDeleteTest.cs](../TestTrainingAlgorithms/algorithms/hard/ValidPalindromeSkipAndDeleteTest.cs) | (15) | | | |
| 11 | `TrappingRainWater.Trap` | [TrappingRainWaterTest.cs](../TestTrainingAlgorithms/algorithms/hard/TrappingRainWaterTest.cs) | (15) | | | |

---

## Summary

| Level | Total | ✅ | ❌ | Pending |
|---|---|---|---|---|
| Easy | 7 | 3 | 1 | 3 |
| Medium | 2 | 0 | 0 | 2 |
| Hard | 2 | 0 | 0 | 2 |
| **All** | **11** | **3** | **1** | **7** |
