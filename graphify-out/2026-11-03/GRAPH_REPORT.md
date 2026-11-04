# Graph Report - DataStructureAndAlgorithms  (2026-10-25)

## Corpus Check
- 112 files · ~39,225 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 3 file(s) not represented in the graph (top: (none) 3)

## Summary
- 853 nodes · 1934 edges · 27 communities (21 shown, 6 thin omitted)
- Extraction: 80% EXTRACTED · 20% INFERRED · 0% AMBIGUOUS · INFERRED: 385 edges (avg confidence: 0.86)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `676a996f`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- String Problems (LINQ)
- system
- List
- AVL & BST Trees
- QuickSort
- Kata & Interview Questions
- Stack & Queue
- Value vs Reference Types
- Solution & Project Files
- Max Heap
- Dynamic Array
- Linked List
- Arrays & Strings (CtCI)
- GroupBy Exercises
- Loop Patterns
- Hash Table
- ArrayFind Approaches
- Two Pointers Technique
- Console Entry Point
- Main Project File
- FirstExercisesTest
- Data Structures & Algorithms in C#
- TrappingRainWaterTest
- TestCase
- Samples.algorithms
- CodeWars
- ArrayDouble

## God Nodes (most connected - your core abstractions)
1. `StringProblemsTest` - 65 edges
2. `Node` - 22 edges
3. `MaxIntHeap` - 21 edges
4. `BinarySearchTree` - 20 edges
5. `StringProblems` - 20 edges
6. `Samples.algorithms` - 17 edges
7. `OtherTest` - 17 edges
8. `DynamicArray` - 14 edges
9. `Samples.questions.lambdas` - 14 edges
10. `TrainingAlgorithms.algorithms.easy` - 14 edges

## Surprising Connections (you probably didn't know these)
- `Rounds` --references--> `GroupByExercises`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercises.cs
- `Rounds` --references--> `SelectManyExercises`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/lambdasAndLinq/easy/SelectManyExercises.cs
- `Rounds` --references--> `SkipExercises`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/lambdasAndLinq/easy/SkipExercises.cs
- `Rounds` --references--> `ContainsExercises`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/lambdasAndLinq/easy/ContainsExercises.cs
- `Rounds` --references--> `FirstExercises`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/lambdasAndLinq/easy/FirstExercises.cs

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **Two Pointer Pattern Family** — docs_cheatsheet_two_pointers_opposite_ends, docs_cheatsheet_two_pointers_skip, docs_cheatsheet_two_pointers_skip_swap [EXTRACTED 1.00]
- **Palindrome Exercise Series** — docs_cheatsheet_palindrome_ispalindrome, docs_cheatsheet_palindrome_isvalidpalindrome, docs_cheatsheet_palindrome_sample2refactor, docs_cheatsheet_palindrome_ispalindromenumber [INFERRED 0.85]

## Communities (27 total, 6 thin omitted)

### Community 0 - "String Problems (LINQ)"
Cohesion: 0.06
Nodes (7): StringProblems, StringProblemsTest, netcoreapp3.1, Microsoft.NET.Test.Sdk (16.5.0), NUnit (3.12.0), NUnit3TestAdapter (3.16.1), Microsoft.NET.Sdk

### Community 1 - "system"
Cohesion: 0.06
Nodes (18): TrainingLambdasAndLinq.lambdasAndLinq.easy, TrainingAlgorithms.algorithms.easy, Test.questions.lamdas, TestTrainingAlgorithms.algorithms.easy, Test.leetcode, Samples.questions.lambdas, Test, Samples.datastructures (+10 more)

### Community 2 - "List"
Cohesion: 0.06
Nodes (15): SelectMany — [SelectManyExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SelectManyExercisesTest.cs), Person, Age, Name, ChatGPT, ChatGPTTest, SelectManyExercisesTest, SelectManyExercises (+7 more)

### Community 4 - "AVL & BST Trees"
Cohesion: 0.09
Nodes (15): AVLTree, Node, Height, Key, Left, Right, BinarySearchTree, Root (+7 more)

### Community 7 - "Kata & Interview Questions"
Cohesion: 0.07
Nodes (7): Compressor, Kata, Palindrome, StringDuplicates, Parangram, StringMerger, OtherTest

### Community 8 - "Stack & Queue"
Cohesion: 0.10
Nodes (12): Node, Data, Next, Queue, Node, Data, Next, Stack (+4 more)

### Community 10 - "Value vs Reference Types"
Cohesion: 0.13
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

### Community 16 - "GroupBy Exercises"
Cohesion: 0.21
Nodes (3): GroupBy — [GroupByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercisesTest.cs), GroupByExercisesTest, GroupByExercises

### Community 18 - "Hash Table"
Cohesion: 0.24
Nodes (6): HashEntry, Key, Next, Value, HashTable, HashTableTest

### Community 20 - "Two Pointers Technique"
Cohesion: 0.23
Nodes (4): Samples.technics.basic, Test.techicsTest.easyTest, TwoPointers, TwoPointersTest

### Community 23 - "FirstExercisesTest"
Cohesion: 0.06
Nodes (17): Contains / Any / All — [ContainsExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ContainsExercisesTest.cs), Easy, First / FirstOrDefault — [FirstExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/FirstExercisesTest.cs), Rounds, Summary, Tracking: TestTrainingLambdasAndLinq, Where — [WhereExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/WhereExercisesTest.cs), ContainsExercisesTest (+9 more)

### Community 24 - "Data Structures & Algorithms in C#"
Cohesion: 0.07
Nodes (18): Medium, Summary, Tracking: TestTrainingAlgorithms, Current algorithm exercises, Data Structures & Algorithms in C#, Docs, Getting started, Repository structure (+10 more)

### Community 25 - "TrappingRainWaterTest"
Cohesion: 0.16
Nodes (7): TrainingAlgorithms.algorithms.hard, TestTrainingAlgorithms.algorithms.hard, Hard, TrappingRainWaterTest, ValidPalindromeSkipAndDeleteTest, TrappingRainWater, ValidPalindromeSkipAndDelete

### Community 27 - "TestCase"
Cohesion: 0.05
Nodes (18): Easy, Skip / Take / SkipWhile / TakeWhile — [SkipExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SkipExercisesTest.cs), FirstUniqueCharacterTest, PalindromeTest, RansomNoteTest, ReverseOnlyLettersTest, ReverseVowelsTest, UniqueCharactersTest (+10 more)

### Community 29 - "Samples.algorithms"
Cohesion: 0.07
Nodes (11): Test.algorithms, Samples.algorithms, BubbleSort, FibonacciMemoized, FibonacciNaive, MergeSort, Recursion, BubbleSortTest (+3 more)

### Community 42 - "ArrayDouble"
Cohesion: 0.31
Nodes (3): Samples.questions.leetcode.array, ArrayDouble, ArrayDoubleTest

## Knowledge Gaps
- **58 isolated node(s):** `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name`, `Age`, `netstandard2.0` (+53 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 88 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **6 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `MaxIntHeap` connect `Max Heap` to `Samples.algorithms`?**
  _High betweenness centrality (0.033) - this node is a cross-community bridge._
- **What connects `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name` to the rest of the system?**
  _58 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `String Problems (LINQ)` be split into smaller, more focused modules?**
  _Cohesion score 0.05512016718913271 - nodes in this community are weakly interconnected._
- **Why does `BinarySearchTree` connect `AVL & BST Trees` to `Samples.algorithms`?**
  _High betweenness centrality (0.031) - this node is a cross-community bridge._
- **Should `system` be split into smaller, more focused modules?**
  _Cohesion score 0.05722772277227723 - nodes in this community are weakly interconnected._
- **Why does `StringProblemsTest` connect `String Problems (LINQ)` to `system`?**
  _High betweenness centrality (0.027) - this node is a cross-community bridge._
- **Should `List` be split into smaller, more focused modules?**
  _Cohesion score 0.06352941176470588 - nodes in this community are weakly interconnected._