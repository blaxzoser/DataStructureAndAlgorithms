# Graph Report - DataStructureAndAlgorithms  (2026-11-24)

## Corpus Check
- 137 files · ~69,611 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 3 file(s) not represented in the graph (top: (none) 3)

## Summary
- 1126 nodes · 2721 edges · 69 communities (36 shown, 33 thin omitted)
- Extraction: 77% EXTRACTED · 23% INFERRED · 0% AMBIGUOUS · INFERRED: 618 edges (avg confidence: 0.87)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `f00ee600`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- StringProblemsTest
- nunit_framework
- ChatGPTTest
- SelectManyExercisesTest
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
- ThenByExercisesTest
- SkipExercises
- GroupByExercisesTest
- City
- ContainsExercisesTest
- system
- TrainingAlgorithms.algorithms.easy
- Person
- GroupAnagramsTest
- system_collections_generic
- ContainsExercisesTest
- Test.csproj
- Order
- Easy
- List
- Medium
- Student
- WhereExercises
- ThreeSumClosest
- StringProblems
- Employee
- ValidPalindromeOneDeletionTest
- UniqueCharactersTest
- BoatsToSavePeople
- FibonacciTest
- BubbleSort
- system_text
- LongestSubstringWithoutRepeatingTest
- MergeSort
- Recursion
- AssignCookiesTest
- FirstUniqueCharacterTest
- ReverseOnlyLettersTest
- MaximumSumDistinctSubarrayOfLengthK
- MaximumUniqueSubarraySumTest

## God Nodes (most connected - your core abstractions)
1. `StringProblemsTest` - 65 edges
2. `GroupByExercisesTest` - 57 edges
3. `GroupByExercises` - 33 edges
4. `SelectManyExercisesTest` - 31 edges
5. `GroupBy — [GroupByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercisesTest.cs)` - 29 edges
6. `Person` - 26 edges
7. `Node` - 22 edges
8. `MaxIntHeap` - 21 edges
9. `BinarySearchTree` - 20 edges
10. `StringProblems` - 20 edges

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

## Communities (69 total, 33 thin omitted)

### Community 2 - "ChatGPTTest"
Cohesion: 0.11
Nodes (5): Person, Age, Name, ChatGPT, ChatGPTTest

### Community 4 - "AVL & BST Trees"
Cohesion: 0.09
Nodes (15): AVLTree, Node, Height, Key, Left, Right, BinarySearchTree, Root (+7 more)

### Community 7 - "OtherTest"
Cohesion: 0.07
Nodes (6): Compressor, Palindrome, StringDuplicates, Parangram, StringMerger, OtherTest

### Community 8 - "Stack"
Cohesion: 0.18
Nodes (7): Node, Data, Next, Stack, Size, Balance, StackTest

### Community 9 - "GroupByExercises"
Cohesion: 0.10
Nodes (3): 12. Progress log, GroupBy — [GroupByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercisesTest.cs), GroupByExercises

### Community 10 - "Value vs Reference Types"
Cohesion: 0.13
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
Cohesion: 0.12
Nodes (10): LinkedList, Node, Data, Next, Node, Data, Next, Queue (+2 more)

### Community 15 - "Arrays & Strings (CtCI)"
Cohesion: 0.16
Nodes (4): PermutationDetector, UniqueCharacters, UrlConverter, ArraysAndStringsTest

### Community 16 - "ThreeSum"
Cohesion: 0.25
Nodes (6): ThreeSumTest, ThreeSum, 2. Two pointers, 2b. + Skip (the 2 inner whiles), 2c. + Skip + Swap, 2d. Decide which pointer moves (no inner whiles)

### Community 18 - "Hash Table"
Cohesion: 0.24
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

### Community 26 - "ThenByExercisesTest"
Cohesion: 0.14
Nodes (3): ThenBy / ThenByDescending — [ThenByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ThenByExercisesTest.cs), ThenByExercisesTest, ThenByExercises

### Community 27 - "SkipExercises"
Cohesion: 0.23
Nodes (3): Skip / Take / SkipWhile / TakeWhile — [SkipExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SkipExercisesTest.cs), SkipExercisesTest, SkipExercises

### Community 30 - "ContainsExercisesTest"
Cohesion: 0.22
Nodes (5): ContainsExercisesTest, City, Country, IsCapital, Name

### Community 31 - "system"
Cohesion: 0.12
Nodes (3): Test.questions.lamdas, Samples.questions.lambdas, Kata

### Community 32 - "TrainingAlgorithms.algorithms.easy"
Cohesion: 0.14
Nodes (4): TrainingAlgorithms.algorithms.easy, TestTrainingAlgorithms.algorithms.easy, TestTrainingAlgorithms.algorithms.medium, TrainingAlgorithms.algorithms.medium

### Community 33 - "Person"
Cohesion: 0.15
Nodes (7): First / FirstOrDefault — [FirstExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/FirstExercisesTest.cs), FirstExercisesTest, FirstExercises, Person, Age, City, Name

### Community 35 - "system_collections_generic"
Cohesion: 0.17
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
Cohesion: 0.06
Nodes (24): Algorithms Cheat Sheet, C# Quick Reference (Strings, Chars, Loops), Edge-Case Checklist, Integer Overflow (int.MaxValue), LINQ Allocation Cost, Palindrome.IsPalindrome, Palindrome.IsPalindromeNumber, Palindrome.IsValidPalindrome (+16 more)

### Community 40 - "List"
Cohesion: 0.24
Nodes (4): Customer, City, Name, Orders

### Community 42 - "Medium"
Cohesion: 0.16
Nodes (10): Medium, ContainerWithMostWaterTest, LongestSubstringKDistinctTest, ContainerWithMostWater, LongestSubstringKDistinct, 1. Which one is it?, 3. Sliding window, 4. Tricky cases (+2 more)

### Community 43 - "Student"
Cohesion: 0.31
Nodes (3): Student, Courses, Name

### Community 44 - "WhereExercises"
Cohesion: 0.24
Nodes (3): Where — [WhereExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/WhereExercisesTest.cs), WhereExercisesTest, WhereExercises

### Community 47 - "Employee"
Cohesion: 0.16
Nodes (4): Employee, Department, Name, Salary

### Community 51 - "FibonacciTest"
Cohesion: 0.39
Nodes (3): FibonacciMemoized, FibonacciNaive, FibonacciTest

### Community 52 - "BubbleSort"
Cohesion: 0.12
Nodes (6): BubbleSort, CodeWars, ArrayDouble, BubbleSortTest, CodeWarsTest, ArrayDoubleTest

### Community 53 - "system_text"
Cohesion: 0.13
Nodes (6): Samples.questions.interviews, Samples.questions.recursive, Samples.questions.arraysAndStrings, Test.algorithms.questions, Samples.POCOS, RemoveDuplicates

### Community 63 - "AssignCookiesTest"
Cohesion: 0.26
Nodes (4): RansomNoteTest, ValidAnagramTest, RansomNote, ValidAnagram

## Knowledge Gaps
- **67 isolated node(s):** `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name`, `Age`, `netstandard2.0` (+62 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 125 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **33 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `GroupByExercisesTest` connect `GroupByExercisesTest` to `system_collections_generic`, `Order`, `GroupByExercises`, `Dictionary`, `Employee`, `ThenByExercisesTest`?**
  _High betweenness centrality (0.041) - this node is a cross-community bridge._
- **What connects `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name` to the rest of the system?**
  _67 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `StringProblemsTest` be split into smaller, more focused modules?**
  _Cohesion score 0.13768115942028986 - nodes in this community are weakly interconnected._
- **Why does `12. Progress log` connect `GroupByExercises` to `Person`, `SelectManyExercisesTest`, `ContainsExercisesTest`, `WhereExercises`, `Employee`, `LINQ Cheat Sheet`, `ThenByExercisesTest`, `SkipExercises`, `GroupByExercisesTest`?**
  _High betweenness centrality (0.032) - this node is a cross-community bridge._
- **Should `ChatGPTTest` be split into smaller, more focused modules?**
  _Cohesion score 0.11 - nodes in this community are weakly interconnected._
- **Why does `LINQ Cheat Sheet` connect `LINQ Cheat Sheet` to `GroupByExercises`?**
  _High betweenness centrality (0.029) - this node is a cross-community bridge._
- **Should `AVL & BST Trees` be split into smaller, more focused modules?**
  _Cohesion score 0.09019607843137255 - nodes in this community are weakly interconnected._