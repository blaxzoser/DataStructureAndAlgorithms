# Graph Report - DataStructureAndAlgorithms  (2026-11-07)

## Corpus Check
- 121 files · ~57,828 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 3 file(s) not represented in the graph (top: (none) 3)

## Summary
- 1030 nodes · 2500 edges · 63 communities (29 shown, 34 thin omitted)
- Extraction: 78% EXTRACTED · 22% INFERRED · 0% AMBIGUOUS · INFERRED: 552 edges (avg confidence: 0.87)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `531861f7`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- StringProblemsTest
- system
- ChatGPTTest
- ContainsExercisesTest
- AVL & BST Trees
- nunit_framework
- QuickSort
- OtherTest
- Stack
- GroupByExercises
- Value vs Reference Types
- Solution & Project Files
- Max Heap
- Dynamic Array
- Linked List
- Arrays & Strings (CtCI)
- MergeSort
- Loop Patterns
- Hash Table
- ArrayFind Approaches
- Two Pointers Technique
- Console Entry Point
- Main Project File
- CodeWars
- GroupAnagramsTest
- TrappingRainWaterTest
- SelectManyExercisesTest
- SkipExercises
- GroupByExercisesTest
- FibonacciTest
- system_diagnostics
- Test
- TrainingAlgorithms.algorithms.easy
- Person
- ValidAnagramTest
- system_collections_generic
- ContainsExercisesTest
- Test.csproj
- BubbleSort
- Recursion
- ThenByExercisesTest
- ArrayDouble
- PalindromeTest
- WhereExercisesTest
- RansomNoteTest
- StringProblems
- Employee
- Easy
- List
- UniqueCharactersTest
- FirstUniqueCharacterTest
- ReverseOnlyLettersTest
- TrainingAlgorithms.algorithms.medium
- AssignCookiesTest

## God Nodes (most connected - your core abstractions)
1. `StringProblemsTest` - 65 edges
2. `GroupByExercisesTest` - 57 edges
3. `GroupByExercises` - 32 edges
4. `SelectManyExercisesTest` - 31 edges
5. `GroupBy — [GroupByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercisesTest.cs)` - 29 edges
6. `Person` - 26 edges
7. `Node` - 22 edges
8. `MaxIntHeap` - 21 edges
9. `BinarySearchTree` - 20 edges
10. `StringProblems` - 20 edges

## Surprising Connections (you probably didn't know these)
- `Easy` --references--> `ContainerWithMostWater`  [INFERRED]
  docs/trackingTestTrainingAlgorithms.md → TrainingAlgorithms/algorithms/medium/ContainerWithMostWater.cs
- `GroupBy — [GroupByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercisesTest.cs)` --references--> `Employee`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/POCOS/Employee.cs
- `ThenBy / ThenByDescending — [ThenByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ThenByExercisesTest.cs)` --references--> `Employee`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/POCOS/Employee.cs
- `Rounds` --references--> `FirstExercises`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/lambdasAndLinq/easy/FirstExercises.cs
- `Rounds` --references--> `GroupByExercises`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercises.cs

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **Two Pointer Pattern Family** — docs_cheatsheet_two_pointers_opposite_ends, docs_cheatsheet_two_pointers_skip, docs_cheatsheet_two_pointers_skip_swap [EXTRACTED 1.00]
- **Palindrome Exercise Series** — docs_cheatsheet_palindrome_ispalindrome, docs_cheatsheet_palindrome_isvalidpalindrome, docs_cheatsheet_palindrome_sample2refactor, docs_cheatsheet_palindrome_ispalindromenumber [INFERRED 0.85]

## Communities (63 total, 34 thin omitted)

### Community 1 - "system"
Cohesion: 0.16
Nodes (6): Samples.questions.lambdas, Samples.questions.arraysAndStrings, Test.algorithms.questions, Samples.POCOS, Kata, RemoveDuplicates

### Community 2 - "ChatGPTTest"
Cohesion: 0.11
Nodes (5): Person, Age, Name, ChatGPT, ChatGPTTest

### Community 3 - "ContainsExercisesTest"
Cohesion: 0.11
Nodes (6): Contains / Any / All — [ContainsExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ContainsExercisesTest.cs), Easy, Rounds, Summary, Tracking: TestTrainingLambdasAndLinq, ContainsExercises

### Community 4 - "AVL & BST Trees"
Cohesion: 0.09
Nodes (15): AVLTree, Node, Height, Key, Left, Right, BinarySearchTree, Root (+7 more)

### Community 7 - "OtherTest"
Cohesion: 0.07
Nodes (6): Compressor, Palindrome, StringDuplicates, Parangram, StringMerger, OtherTest

### Community 8 - "Stack"
Cohesion: 0.10
Nodes (12): Node, Data, Next, Queue, Node, Data, Next, Stack (+4 more)

### Community 10 - "Value vs Reference Types"
Cohesion: 0.12
Nodes (9): System.Runtime.CompilerServices, Samples.memory, PersonClass, Age, Name, PersonRecord, ValuesTypeVsReferenceType, IsExternalInit (+1 more)

### Community 11 - "Solution & Project Files"
Cohesion: 0.06
Nodes (32): Algorithms Cheat Sheet, C# Quick Reference (Strings, Chars, Loops), Edge-Case Checklist, Integer Overflow (int.MaxValue), LINQ Allocation Cost, Palindrome.IsPalindrome, Palindrome.IsPalindromeNumber, Palindrome.IsValidPalindrome (+24 more)

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

### Community 18 - "Hash Table"
Cohesion: 0.24
Nodes (6): HashEntry, Key, Next, Value, HashTable, HashTableTest

### Community 20 - "Two Pointers Technique"
Cohesion: 0.23
Nodes (4): Samples.technics.basic, Test.techicsTest.easyTest, TwoPointers, TwoPointersTest

### Community 24 - "GroupAnagramsTest"
Cohesion: 0.06
Nodes (20): Medium, Summary, Tracking: TestTrainingAlgorithms, Current algorithm exercises, Data Structures & Algorithms in C#, Docs, Getting started, Repository structure (+12 more)

### Community 25 - "TrappingRainWaterTest"
Cohesion: 0.16
Nodes (7): TrainingAlgorithms.algorithms.hard, TestTrainingAlgorithms.algorithms.hard, Hard, TrappingRainWaterTest, ValidPalindromeSkipAndDeleteTest, TrappingRainWater, ValidPalindromeSkipAndDelete

### Community 26 - "SelectManyExercisesTest"
Cohesion: 0.08
Nodes (10): SelectMany — [SelectManyExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SelectManyExercisesTest.cs), SelectManyExercisesTest, SelectManyExercises, Customer, City, Name, Orders, Student (+2 more)

### Community 27 - "SkipExercises"
Cohesion: 0.23
Nodes (3): Skip / Take / SkipWhile / TakeWhile — [SkipExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SkipExercisesTest.cs), SkipExercisesTest, SkipExercises

### Community 29 - "FibonacciTest"
Cohesion: 0.29
Nodes (3): FibonacciMemoized, FibonacciNaive, FibonacciTest

### Community 30 - "system_diagnostics"
Cohesion: 0.15
Nodes (4): Test.leetcode, Samples.questions.interviews, Samples.questions.leetcode.array, Samples.questions.recursive

### Community 33 - "Person"
Cohesion: 0.15
Nodes (7): First / FirstOrDefault — [FirstExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/FirstExercisesTest.cs), FirstExercisesTest, FirstExercises, Person, Age, City, Name

### Community 35 - "system_collections_generic"
Cohesion: 0.19
Nodes (4): TrainingLambdasAndLinq.lambdasAndLinq.easy, Test.questions.lamdas, TestTrainingLambdasAndLinq.lambdasAndLinq.easy, TrainingLambdasAndLinq.POCOS

### Community 36 - "ContainsExercisesTest"
Cohesion: 0.22
Nodes (5): ContainsExercisesTest, City, Country, IsCapital, Name

### Community 37 - "Test.csproj"
Cohesion: 0.14
Nodes (5): netcoreapp3.1, Microsoft.NET.Test.Sdk (16.5.0), NUnit (3.12.0), NUnit3TestAdapter (3.16.1), Microsoft.NET.Sdk

### Community 40 - "ThenByExercisesTest"
Cohesion: 0.13
Nodes (3): ThenBy / ThenByDescending — [ThenByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ThenByExercisesTest.cs), ThenByExercisesTest, ThenByExercises

### Community 44 - "WhereExercisesTest"
Cohesion: 0.24
Nodes (3): Where — [WhereExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/WhereExercisesTest.cs), WhereExercisesTest, WhereExercises

### Community 47 - "Employee"
Cohesion: 0.16
Nodes (4): Employee, Department, Name, Salary

### Community 48 - "Easy"
Cohesion: 0.43
Nodes (3): Easy, ReverseVowelsTest, ReverseVowels

### Community 49 - "List"
Cohesion: 0.24
Nodes (4): Order, Customer, Id, Products

## Knowledge Gaps
- **67 isolated node(s):** `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name`, `Age`, `netstandard2.0` (+62 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 99 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **34 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `GroupByExercisesTest` connect `GroupByExercisesTest` to `system_collections_generic`, `GroupByExercises`, `Dictionary`, `Employee`, `List`?**
  _High betweenness centrality (0.048) - this node is a cross-community bridge._
- **What connects `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name` to the rest of the system?**
  _67 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `StringProblemsTest` be split into smaller, more focused modules?**
  _Cohesion score 0.13768115942028986 - nodes in this community are weakly interconnected._
- **Why does `MaxIntHeap` connect `Max Heap` to `system_diagnostics`?**
  _High betweenness centrality (0.046) - this node is a cross-community bridge._
- **Should `ChatGPTTest` be split into smaller, more focused modules?**
  _Cohesion score 0.11 - nodes in this community are weakly interconnected._
- **Why does `GroupByExercises` connect `GroupByExercises` to `system_collections_generic`, `ContainsExercisesTest`, `Dictionary`, `Employee`, `List`, `GroupByExercisesTest`?**
  _High betweenness centrality (0.030) - this node is a cross-community bridge._
- **Should `ContainsExercisesTest` be split into smaller, more focused modules?**
  _Cohesion score 0.11052631578947368 - nodes in this community are weakly interconnected._