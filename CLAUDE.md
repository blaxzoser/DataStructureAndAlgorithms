## Project overview

Personal C# practice repo for data structures, algorithms and LINQ. One solution
(`DataStructureAndAlgorithms.sln`), NUnit 3 tests. Libraries target
`netstandard2.0` (LangVersion 9.0), test projects target `netcoreapp3.1`.

The user is practicing: **training exercises are solved by the user**. Don't
fill in a stub unless asked; when reviewing, explain and suggest, and put any
reference solution in a separate method (e.g. `Sample1Refactor`) next to theirs.

## Project map

| Folder | Kind | Contents | Tested by |
|---|---|---|---|
| `Samples/` | library | Worked examples with explanations | `Test/` |
| `Samples/algorithms/` | | AVLTree, BinarySearchTree, BubbleSort, MergeSort, QuickSort, MaxIntHeap, Fibonacci (naive/memoized), Recursion | `Test/algorithms/` |
| `Samples/datastructures/` | | DynamicArray, HashTable, LinkedList, Queue, Stack | `Test/*Test.cs` (root) |
| `Samples/technics/basic/` | | TwoPointers (IsPalindrome, IsSumPairEqualToTarget) | `Test/techicsTest/easyTest/` |
| `Samples/questions/arraysAndStrings/` | | Compressor, FindOddInt, PermutationDetector, RemoveDuplicates, UniqueCharacters, UrlConverter | `Test/algorithms/questions/` |
| `Samples/questions/interviews/` | | Palindrome, StringDuplicates | |
| `Samples/questions/lambdas/` | | ArrayDiff, ArrayFind, Balance, ChatGPT, CodeWars, Parangram, Patterns, StringProblems | `Test/` root, `Test/questions/lamdas/`, `Test/algorithms/questions/` |
| `Samples/questions/leetcode/array/` | | ArrayDouble | `Test/leetcode/` |
| `Samples/questions/recursive/` | | StringMerger | |
| `Samples/memory/` | | ValuesTypeVsReferenceType | `Test/MemoryTest.cs` |
| `Samples/POCOS/` | | Person | |
| `TrainingAlgorithms/algorithms/{easy,medium,hard}/` | library | Algorithm exercises (stubs) | `TestTrainingAlgorithms/algorithms/{easy,medium,hard}/` |
| `TrainingLambdasAndLinq/lambdasAndLinq/easy/` | library | LINQ exercises: Where, First, Contains, Skip, SelectMany, GroupBy | `TestTrainingLambdasAndLinq/lambdasAndLinq/easy/` |
| `TrainingLambdasAndLinq/POCOS/` | | Person, Order, Student (data for LINQ exercises) | |
| `DataStructureAndAlgorithms/` | console app | Hello World entry point, unused | |
| `docs/CheatSheet.md` | doc | Patterns + templates, C# quick reference, Time/Space, edge cases, progress log | |
| `docs/trackingTestTrainingAlgorithms.md` | doc | Time / date / checked / notes for every exercise tested in `TestTrainingAlgorithms` | |
| `docs/trackingTestTrainingLambdasAndLinq.md` | doc | Rounds per class + checked / notes for every exercise tested in `TestTrainingLambdasAndLinq` | |
| `graphify-out/` | generated | Knowledge graph (see below) | |

Current `TrainingAlgorithms` exercises, by pattern family:
- Two pointers
  - easy: `Palindrome` (+ `Sample1Refactor`/`Sample2Refactor` reference solutions), `ReverseOnlyLetters`, `ReverseVowels`
  - medium: `ValidPalindromeOneDeletion`, `ContainerWithMostWater`
  - hard: `ValidPalindromeSkipAndDelete`, `TrappingRainWater`
- Seen set / frequency count (worked LINQ/sort versions live in `Samples/questions/arraysAndStrings` and `Samples/questions/lambdas/StringProblems.cs`)
  - easy: `UniqueCharacters` (`IsUnique` + `IsUniqueNoExtraSpace`), `FirstUniqueCharacter`, `ValidAnagram`, `RansomNote`
  - medium: `LongestSubstringWithoutRepeating` (sliding window), `GroupAnagrams`

## Conventions for training exercises

- Test project mirrors the library: same folder (`easy`/`medium`/`hard`), namespace
  `TrainingAlgorithms.algorithms.<level>` ↔ `TestTrainingAlgorithms.algorithms.<level>`,
  test class `<Exercise>Test` with `[SetUp]` creating the instance and `[TestCase]` rows.
- New exercise = stub that throws `NotImplementedException` with a comment header:
  problem, examples (incl. edge cases like `""`, `null`), Difficulty, Goal (Time/Space),
  Expected time to solve, Pattern (which earlier exercise it builds on), Topic, Tip 1/Tip 2.
- Exercises should reuse a pattern the user already practiced and step up difficulty
  gradually (~15 min each). Check existing exercises (and `Samples/`) to avoid repeats.
- Verify test expectations with a temporary reference solution, then strip it back to a stub.
- When adding an exercise, also add a row to `docs/trackingTestTrainingAlgorithms.md`
  (LINQ exercises: `docs/trackingTestTrainingLambdasAndLinq.md`)
  (and its summary) and to the progress log in `docs/CheatSheet.md`.

## Commands

```bash
dotnet build DataStructureAndAlgorithms.sln
dotnet test TestTrainingAlgorithms/TestTrainingAlgorithms.csproj
dotnet test TestTrainingAlgorithms/TestTrainingAlgorithms.csproj --filter "FullyQualifiedName~<TestClass>"
```

Training tests fail until the user solves the exercise; that's expected.

## graphify

This project has a knowledge graph at graphify-out/ with god nodes, community structure, and cross-file relationships.

Rules:
- When graphify-out/graph.json exists, run `graphify query "<question>"` before your first grep, search or source-file read for a codebase question, and put this rule in every subagent prompt that explores code. Read raw files only for lines the graph or an earlier read already located. Use `graphify path "<A>" "<B>"` for relationships and `graphify explain "<concept>"` for focused concepts. These return a scoped subgraph, usually much smaller than GRAPH_REPORT.md or raw grep output.
- If graphify-out/wiki/index.md exists, use it for broad navigation instead of raw source browsing.
- Read graphify-out/GRAPH_REPORT.md only for broad architecture review or when query/path/explain do not surface enough context.
- After modifying code, run `graphify update .` to keep the graph current (AST-only, no API cost).
- A committed graphify-out/graph.json is rewritten whole on every build, so a large diff to it in a pull request is expected. Do not flag it as churn or suggest skipping the graph rebuild or its hooks.
