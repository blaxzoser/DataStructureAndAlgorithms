# Graph Report - DataStructureAndAlgorithms  (2026-11-06)

## Corpus Check
- 116 files · ~51,387 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 3 file(s) not represented in the graph (top: (none) 3)

## Summary
- 971 nodes · 2315 edges · 56 communities (28 shown, 28 thin omitted)
- Extraction: 78% EXTRACTED · 22% INFERRED · 0% AMBIGUOUS · INFERRED: 502 edges (avg confidence: 0.87)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `d558e77e`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- StringProblemsTest
- system
- ChatGPTTest
- ContainsExercisesTest
- AVL & BST Trees
- Person
- QuickSort
- Kata & Interview Questions
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
- Easy
- TrainingAlgorithms.algorithms.easy
- Employee
- Order
- BubbleSort
- Recursion
- ThenByExercisesTest
- Test.csproj
- ArrayDouble
- PalindromeTest
- WhereExercisesTest
- TestCase
- StringProblems
- Easy
- UniqueCharactersTest
- FirstUniqueCharacterTest
- ReverseOnlyLettersTest

## God Nodes (most connected - your core abstractions)
1. `StringProblemsTest` - 65 edges
2. `GroupByExercisesTest` - 52 edges
3. `GroupByExercises` - 30 edges
4. `GroupBy — [GroupByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercisesTest.cs)` - 27 edges
5. `Person` - 23 edges
6. `Node` - 22 edges
7. `MaxIntHeap` - 21 edges
8. `BinarySearchTree` - 20 edges
9. `StringProblems` - 20 edges
10. `ContainsExercisesTest` - 20 edges

## Surprising Connections (you probably didn't know these)
- `GroupBy — [GroupByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercisesTest.cs)` --references--> `Employee`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/POCOS/Employee.cs
- `Rounds` --references--> `ContainsExercises`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/lambdasAndLinq/easy/ContainsExercises.cs
- `Rounds` --references--> `FirstExercises`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/lambdasAndLinq/easy/FirstExercises.cs
- `Rounds` --references--> `GroupByExercises`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercises.cs
- `Rounds` --references--> `SelectManyExercises`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/lambdasAndLinq/easy/SelectManyExercises.cs

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **Two Pointer Pattern Family** — docs_cheatsheet_two_pointers_opposite_ends, docs_cheatsheet_two_pointers_skip, docs_cheatsheet_two_pointers_skip_swap [EXTRACTED 1.00]
- **Palindrome Exercise Series** — docs_cheatsheet_palindrome_ispalindrome, docs_cheatsheet_palindrome_isvalidpalindrome, docs_cheatsheet_palindrome_sample2refactor, docs_cheatsheet_palindrome_ispalindromenumber [INFERRED 0.85]

## Communities (56 total, 28 thin omitted)

### Community 1 - "system"
Cohesion: 0.06
Nodes (20): TrainingLambdasAndLinq.lambdasAndLinq.easy, Test.algorithms, Test.questions.lamdas, Test.leetcode, Samples.questions.lambdas, Test, Samples.datastructures, Samples.questions.interviews (+12 more)

### Community 2 - "ChatGPTTest"
Cohesion: 0.11
Nodes (5): Person, Age, Name, ChatGPT, ChatGPTTest

### Community 3 - "ContainsExercisesTest"
Cohesion: 0.13
Nodes (6): ContainsExercisesTest, ContainsExercises, City, Country, IsCapital, Name

### Community 4 - "AVL & BST Trees"
Cohesion: 0.09
Nodes (15): AVLTree, Node, Height, Key, Left, Right, BinarySearchTree, Root (+7 more)

### Community 5 - "Person"
Cohesion: 0.15
Nodes (7): First / FirstOrDefault — [FirstExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/FirstExercisesTest.cs), FirstExercisesTest, FirstExercises, Person, Age, City, Name

### Community 7 - "Kata & Interview Questions"
Cohesion: 0.07
Nodes (6): Compressor, Palindrome, StringDuplicates, Parangram, StringMerger, OtherTest

### Community 8 - "Stack"
Cohesion: 0.18
Nodes (7): Node, Data, Next, Stack, Size, Balance, StackTest

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
Cohesion: 0.12
Nodes (10): LinkedList, Node, Data, Next, Node, Data, Next, Queue (+2 more)

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
Nodes (18): Medium, Summary, Tracking: TestTrainingAlgorithms, Current algorithm exercises, Data Structures & Algorithms in C#, Docs, Getting started, Repository structure (+10 more)

### Community 25 - "TrappingRainWaterTest"
Cohesion: 0.16
Nodes (7): TrainingAlgorithms.algorithms.hard, TestTrainingAlgorithms.algorithms.hard, Hard, TrappingRainWaterTest, ValidPalindromeSkipAndDeleteTest, TrappingRainWater, ValidPalindromeSkipAndDelete

### Community 26 - "SelectManyExercisesTest"
Cohesion: 0.16
Nodes (6): SelectMany — [SelectManyExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SelectManyExercisesTest.cs), SelectManyExercisesTest, SelectManyExercises, Student, Courses, Name

### Community 27 - "SkipExercises"
Cohesion: 0.23
Nodes (3): Skip / Take / SkipWhile / TakeWhile — [SkipExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SkipExercisesTest.cs), SkipExercisesTest, SkipExercises

### Community 29 - "FibonacciTest"
Cohesion: 0.29
Nodes (3): FibonacciMemoized, FibonacciNaive, FibonacciTest

### Community 31 - "Easy"
Cohesion: 0.20
Nodes (5): Contains / Any / All — [ContainsExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ContainsExercisesTest.cs), Easy, Rounds, Summary, Tracking: TestTrainingLambdasAndLinq

### Community 33 - "Employee"
Cohesion: 0.14
Nodes (4): Employee, Department, Name, Salary

### Community 35 - "Order"
Cohesion: 0.22
Nodes (4): Order, Customer, Id, Products

### Community 40 - "ThenByExercisesTest"
Cohesion: 0.17
Nodes (3): ThenBy / ThenByDescending — [ThenByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ThenByExercisesTest.cs), ThenByExercisesTest, ThenByExercises

### Community 41 - "Test.csproj"
Cohesion: 0.14
Nodes (5): netcoreapp3.1, Microsoft.NET.Test.Sdk (16.5.0), NUnit (3.12.0), NUnit3TestAdapter (3.16.1), Microsoft.NET.Sdk

### Community 44 - "WhereExercisesTest"
Cohesion: 0.24
Nodes (3): Where — [WhereExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/WhereExercisesTest.cs), WhereExercisesTest, WhereExercises

### Community 45 - "TestCase"
Cohesion: 0.24
Nodes (4): RansomNoteTest, ValidAnagramTest, RansomNote, ValidAnagram

### Community 48 - "Easy"
Cohesion: 0.36
Nodes (3): Easy, ReverseVowelsTest, ReverseVowels

## Knowledge Gaps
- **64 isolated node(s):** `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name`, `Age`, `netstandard2.0` (+59 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 96 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **28 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `GroupByExercisesTest` connect `GroupByExercisesTest` to `system`, `.BuildNamesByCityLookup`, `Employee`, `Order`, `GroupByExercises`, `SelectManyExercisesTest`, `Dictionary`?**
  _High betweenness centrality (0.041) - this node is a cross-community bridge._
- **What connects `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name` to the rest of the system?**
  _64 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `StringProblemsTest` be split into smaller, more focused modules?**
  _Cohesion score 0.13768115942028986 - nodes in this community are weakly interconnected._
- **Why does `MaxIntHeap` connect `Max Heap` to `system`?**
  _High betweenness centrality (0.029) - this node is a cross-community bridge._
- **Should `system` be split into smaller, more focused modules?**
  _Cohesion score 0.05622710622710623 - nodes in this community are weakly interconnected._
- **Should `ChatGPTTest` be split into smaller, more focused modules?**
  _Cohesion score 0.11 - nodes in this community are weakly interconnected._
- **Should `ContainsExercisesTest` be split into smaller, more focused modules?**
  _Cohesion score 0.13227513227513227 - nodes in this community are weakly interconnected._