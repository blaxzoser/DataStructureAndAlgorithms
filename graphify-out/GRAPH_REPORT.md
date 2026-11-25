# Graph Report - DataStructureAndAlgorithms  (2026-11-24)

## Corpus Check
- 143 files · ~71,000 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 3 file(s) not represented in the graph (top: (none) 3)

## Summary
- 1150 nodes · 2785 edges · 78 communities (35 shown, 43 thin omitted)
- Extraction: 77% EXTRACTED · 23% INFERRED · 0% AMBIGUOUS · INFERRED: 633 edges (avg confidence: 0.87)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `4fc1da38`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- StringProblemsTest
- nunit_framework
- ChatGPTTest
- nunit_framework
- AVL & BST Trees
- Samples.algorithms
- QuickSort
- OtherTest
- Stack
- GroupByExercises
- Value vs Reference Types
- TestTrainingAlgorithms.csproj
- Max Heap
- Dynamic Array
- Linked List
- Arrays & Strings (CtCI)
- ThreeSum
- Loop Patterns
- Hash Table
- ArrayFind Approaches
- Two Pointers Technique
- Console Entry Point
- Main Project File
- ArrayDoubleTest.cs
- LINQ Cheat Sheet
- TrappingRainWaterTest
- TestCase
- SkipExercises
- GroupByExercisesTest
- Progress Log
- ContainsExercisesTest
- TrainingAlgorithms.algorithms.easy
- Person
- GroupAnagramsTest
- system_collections_generic
- ContainsExercisesTest
- Test.csproj
- Order
- Easy
- Algorithms Cheat Sheet
- Medium
- ReverseVowels
- WhereExercises
- ThreeSumClosest
- StringProblems
- Employee
- ValidPalindromeOneDeletionTest
- UniqueCharactersTest
- Medium
- FibonacciTest
- BubbleSort
- system_text
- LongestSubstringWithoutRepeatingTest
- MergeSort
- Recursion
- ValidAnagramTest
- FirstUniqueCharacterTest
- ReverseOnlyLettersTest
- MaximumSumDistinctSubarrayOfLengthK
- MaximumUniqueSubarraySumTest
- OtherTest.cs
- CodeWars
- ArrayDouble
- AssignCookiesTest
- LongestUniqueNumbersTest
- LongestUniqueSubstringTest
- LongestUniqueWordsTest

## God Nodes (most connected - your core abstractions)
1. `StringProblemsTest` - 65 edges
2. `GroupByExercisesTest` - 57 edges
3. `GroupByExercises` - 33 edges
4. `SelectManyExercisesTest` - 31 edges
5. `GroupBy — [GroupByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercisesTest.cs)` - 29 edges
6. `Person` - 26 edges
7. `TrainingAlgorithms.algorithms.medium` - 24 edges
8. `Node` - 22 edges
9. `MaxIntHeap` - 21 edges
10. `BinarySearchTree` - 20 edges

## Surprising Connections (you probably didn't know these)
- `1. Which one is it?` --references--> `ReverseOnlyLetters`  [INFERRED]
  TwoPointersAndSlidingWindow.md → TrainingAlgorithms/algorithms/easy/ReverseOnlyLetters.cs
- `1. Which one is it?` --references--> `ReverseVowels`  [INFERRED]
  TwoPointersAndSlidingWindow.md → TrainingAlgorithms/algorithms/easy/ReverseVowels.cs
- `Medium` --references--> `ThreeSum`  [INFERRED]
  docs/trackingTestTrainingAlgorithms.md → TrainingAlgorithms/algorithms/hard/ThreeSum.cs
- `1. Which one is it?` --references--> `ThreeSum`  [INFERRED]
  TwoPointersAndSlidingWindow.md → TrainingAlgorithms/algorithms/hard/ThreeSum.cs
- `1. Which one is it?` --references--> `BoatsToSavePeople`  [INFERRED]
  TwoPointersAndSlidingWindow.md → TrainingAlgorithms/algorithms/medium/BoatsToSavePeople.cs

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **Two Pointer Pattern Family** — docs_cheatsheet_two_pointers_opposite_ends, docs_cheatsheet_two_pointers_skip, docs_cheatsheet_two_pointers_skip_swap [EXTRACTED 1.00]
- **Palindrome Exercise Series** — docs_cheatsheet_palindrome_ispalindrome, docs_cheatsheet_palindrome_isvalidpalindrome, docs_cheatsheet_palindrome_sample2refactor, docs_cheatsheet_palindrome_ispalindromenumber [INFERRED 0.85]

## Communities (78 total, 43 thin omitted)

### Community 2 - "ChatGPTTest"
Cohesion: 0.11
Nodes (5): Person, Age, Name, ChatGPT, ChatGPTTest

### Community 3 - "nunit_framework"
Cohesion: 0.28
Nodes (3): Test.questions.lamdas, TestTrainingAlgorithms.algorithms.medium, TrainingAlgorithms.algorithms.medium

### Community 4 - "AVL & BST Trees"
Cohesion: 0.09
Nodes (15): AVLTree, Node, Height, Key, Left, Right, BinarySearchTree, Root (+7 more)

### Community 7 - "OtherTest"
Cohesion: 0.07
Nodes (6): Compressor, Palindrome, StringDuplicates, Parangram, StringMerger, OtherTest

### Community 8 - "Stack"
Cohesion: 0.10
Nodes (12): Node, Data, Next, Queue, Node, Data, Next, Stack (+4 more)

### Community 9 - "GroupByExercises"
Cohesion: 0.11
Nodes (3): 12. Progress log, GroupBy — [GroupByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercisesTest.cs), GroupByExercises

### Community 10 - "Value vs Reference Types"
Cohesion: 0.12
Nodes (9): System.Runtime.CompilerServices, Samples.memory, PersonClass, Age, Name, PersonRecord, ValuesTypeVsReferenceType, IsExternalInit (+1 more)

### Community 11 - "TestTrainingAlgorithms.csproj"
Cohesion: 0.10
Nodes (16): netstandard2.0, Microsoft.NET.Sdk, netcoreapp3.1, Microsoft.NET.Test.Sdk (16.5.0), NUnit (3.12.0), NUnit3TestAdapter (3.16.1), Microsoft.NET.Sdk, netcoreapp3.1 (+8 more)

### Community 12 - "Max Heap"
Cohesion: 0.21
Nodes (3): MaxIntHeap, Items, MaxIntHeapTest

### Community 13 - "Dynamic Array"
Cohesion: 0.22
Nodes (4): DynamicArray, IsEmpty, Size, DynamicArrayTest

### Community 14 - "Linked List"
Cohesion: 0.22
Nodes (5): LinkedList, Node, Data, Next, LinkedListTest

### Community 15 - "Arrays & Strings (CtCI)"
Cohesion: 0.16
Nodes (4): PermutationDetector, UniqueCharacters, UrlConverter, ArraysAndStringsTest

### Community 16 - "ThreeSum"
Cohesion: 0.25
Nodes (5): ThreeSumTest, ThreeSum, 2. Two pointers, 2b. + Skip (the 2 inner whiles), 2d. Decide which pointer moves (no inner whiles)

### Community 18 - "Hash Table"
Cohesion: 0.22
Nodes (6): HashEntry, Key, Next, Value, HashTable, HashTableTest

### Community 20 - "Two Pointers Technique"
Cohesion: 0.23
Nodes (4): Samples.technics.basic, Test.techicsTest.easyTest, TwoPointers, TwoPointersTest

### Community 24 - "LINQ Cheat Sheet"
Cohesion: 0.06
Nodes (29): 10. Pitfalls checklist, 11. Time / Space quick guide, 1. Which operator do I need?, 2. Where — filter, 3. First / FirstOrDefault — take one, 4. Contains / Any / All — yes/no, 5. Skip / Take / SkipWhile / TakeWhile — slices, 6. OrderBy / ThenBy — sort and break ties (+21 more)

### Community 25 - "TrappingRainWaterTest"
Cohesion: 0.08
Nodes (13): TrainingAlgorithms.algorithms.hard, TestTrainingAlgorithms.algorithms.hard, Hard, Summary, Tracking: TestTrainingAlgorithms, EmailGeneratorTest, TrappingRainWaterTest, UsernameGeneratorTest (+5 more)

### Community 26 - "TestCase"
Cohesion: 0.05
Nodes (15): SelectMany — [SelectManyExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SelectManyExercisesTest.cs), ThenBy / ThenByDescending — [ThenByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ThenByExercisesTest.cs), RansomNoteTest, SelectManyExercisesTest, ThenByExercisesTest, RansomNote, SelectManyExercises, ThenByExercises (+7 more)

### Community 27 - "SkipExercises"
Cohesion: 0.23
Nodes (3): Skip / Take / SkipWhile / TakeWhile — [SkipExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SkipExercisesTest.cs), SkipExercisesTest, SkipExercises

### Community 29 - "Progress Log"
Cohesion: 0.24
Nodes (7): Palindrome.IsPalindrome, Palindrome.IsPalindromeNumber, Palindrome.IsValidPalindrome, Palindrome.Sample2Refactor, Progress Log, ReverseOnlyLetters.Reverse, while vs do...while vs for Loops

### Community 30 - "ContainsExercisesTest"
Cohesion: 0.22
Nodes (5): ContainsExercisesTest, City, Country, IsCapital, Name

### Community 33 - "Person"
Cohesion: 0.15
Nodes (7): First / FirstOrDefault — [FirstExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/FirstExercisesTest.cs), FirstExercisesTest, FirstExercises, Person, Age, City, Name

### Community 35 - "system_collections_generic"
Cohesion: 0.23
Nodes (3): TrainingLambdasAndLinq.lambdasAndLinq.easy, TestTrainingLambdasAndLinq.lambdasAndLinq.easy, TrainingLambdasAndLinq.POCOS

### Community 36 - "ContainsExercisesTest"
Cohesion: 0.11
Nodes (6): Contains / Any / All — [ContainsExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ContainsExercisesTest.cs), Easy, Rounds, Summary, Tracking: TestTrainingLambdasAndLinq, ContainsExercises

### Community 37 - "Test.csproj"
Cohesion: 0.14
Nodes (5): netcoreapp3.1, Microsoft.NET.Test.Sdk (16.5.0), NUnit (3.12.0), NUnit3TestAdapter (3.16.1), Microsoft.NET.Sdk

### Community 38 - "Order"
Cohesion: 0.29
Nodes (4): Order, Customer, Id, Products

### Community 39 - "Easy"
Cohesion: 0.20
Nodes (4): Easy, PalindromeTest, Palindrome, 2a. Opposite ends (basic)

### Community 40 - "Algorithms Cheat Sheet"
Cohesion: 0.22
Nodes (9): Algorithms Cheat Sheet, C# Quick Reference (Strings, Chars, Loops), Edge-Case Checklist, Integer Overflow (int.MaxValue), LINQ Allocation Cost, C# String Immutability, StringBuilder, Time / Space Complexity Quick Guide (+1 more)

### Community 42 - "Medium"
Cohesion: 0.25
Nodes (6): LongestSubstringKDistinctTest, LongestSubstringKDistinct, 1. Which one is it?, 3. Sliding window, 5. Your common mistakes (check before running the tests), Cheat Sheet: Two Pointers and Sliding Window

### Community 44 - "WhereExercises"
Cohesion: 0.24
Nodes (3): Where — [WhereExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/WhereExercisesTest.cs), WhereExercisesTest, WhereExercises

### Community 47 - "Employee"
Cohesion: 0.16
Nodes (4): Employee, Department, Name, Salary

### Community 50 - "Medium"
Cohesion: 0.23
Nodes (6): Medium, BoatsToSavePeopleTest, ContainerWithMostWaterTest, BoatsToSavePeople, ContainerWithMostWater, 4. Tricky cases

### Community 51 - "FibonacciTest"
Cohesion: 0.29
Nodes (3): FibonacciMemoized, FibonacciNaive, FibonacciTest

### Community 53 - "system_text"
Cohesion: 0.13
Nodes (6): Samples.questions.lambdas, Samples.questions.arraysAndStrings, Test.algorithms.questions, Samples.POCOS, Kata, RemoveDuplicates

### Community 66 - "ReverseOnlyLettersTest"
Cohesion: 0.43
Nodes (3): ReverseOnlyLettersTest, ReverseOnlyLetters, 2c. + Skip + Swap

## Knowledge Gaps
- **67 isolated node(s):** `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name`, `Age`, `netstandard2.0` (+62 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 125 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **43 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `GroupByExercisesTest` connect `GroupByExercisesTest` to `system_collections_generic`, `Order`, `GroupByExercises`, `Dictionary`, `.BuildNamesByCityLookup`, `.CountWordsByFirstLetter`, `Employee`?**
  _High betweenness centrality (0.031) - this node is a cross-community bridge._
- **What connects `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name` to the rest of the system?**
  _67 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `StringProblemsTest` be split into smaller, more focused modules?**
  _Cohesion score 0.13768115942028986 - nodes in this community are weakly interconnected._
- **Why does `SelectManyExercisesTest` connect `TestCase` to `system_collections_generic`?**
  _High betweenness centrality (0.030) - this node is a cross-community bridge._
- **Should `ChatGPTTest` be split into smaller, more focused modules?**
  _Cohesion score 0.11 - nodes in this community are weakly interconnected._
- **Why does `Order` connect `Order` to `TestCase`, `system_collections_generic`?**
  _High betweenness centrality (0.027) - this node is a cross-community bridge._
- **Should `AVL & BST Trees` be split into smaller, more focused modules?**
  _Cohesion score 0.08748114630467571 - nodes in this community are weakly interconnected._