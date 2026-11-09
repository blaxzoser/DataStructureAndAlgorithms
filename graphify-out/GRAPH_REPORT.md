# Graph Report - DataStructureAndAlgorithms  (2026-11-08)

## Corpus Check
- 128 files · ~63,319 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 3 file(s) not represented in the graph (top: (none) 3)

## Summary
- 1081 nodes · 2601 edges · 65 communities (35 shown, 30 thin omitted)
- Extraction: 78% EXTRACTED · 22% INFERRED · 0% AMBIGUOUS · INFERRED: 578 edges (avg confidence: 0.87)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `18b17fd1`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- StringProblemsTest
- Test
- ChatGPTTest
- WhereExercises
- AVL & BST Trees
- nunit_framework
- QuickSort
- OtherTest
- Queue
- GroupByExercises
- Value vs Reference Types
- TestTrainingAlgorithms.csproj
- Max Heap
- Dynamic Array
- Linked List
- Arrays & Strings (CtCI)
- Loop Patterns
- Hash Table
- ArrayFind Approaches
- Two Pointers Technique
- Console Entry Point
- Main Project File
- TestCase
- LINQ Cheat Sheet
- TrappingRainWaterTest
- List
- SkipExercises
- GroupByExercisesTest
- FibonacciTest
- SetUp
- system_text
- TrainingAlgorithms.algorithms.easy
- Person
- AssignCookiesTest
- system_collections_generic
- ContainsExercisesTest
- Test.csproj
- BubbleSort
- ArrayDouble
- SelectManyExercisesTest
- Algorithms Cheat Sheet
- PalindromeTest
- ContainsExercisesTest
- RansomNoteTest
- StringProblems
- Employee
- SelectMany — [SelectManyExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SelectManyExercisesTest.cs)
- Order
- UniqueCharactersTest
- Easy
- TrainingAlgorithms.algorithms.medium
- Student
- ReverseOnlyLettersTest
- Progress Log
- OtherTest.cs

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
- `Easy` --references--> `ContainerWithMostWater`  [INFERRED]
  docs/trackingTestTrainingAlgorithms.md → TrainingAlgorithms/algorithms/medium/ContainerWithMostWater.cs
- `SelectMany — [SelectManyExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SelectManyExercisesTest.cs)` --references--> `Customer`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/POCOS/Customer.cs
- `GroupBy — [GroupByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/GroupByExercisesTest.cs)` --references--> `Employee`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/POCOS/Employee.cs
- `ThenBy / ThenByDescending — [ThenByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ThenByExercisesTest.cs)` --references--> `Employee`  [INFERRED]
  docs/trackingTestTrainingLambdasAndLinq.md → TrainingLambdasAndLinq/POCOS/Employee.cs
- `12. Progress log` --references--> `ContainsExercises`  [INFERRED]
  docs/LinqCheatSheet.md → TrainingLambdasAndLinq/lambdasAndLinq/easy/ContainsExercises.cs

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **Two Pointer Pattern Family** — docs_cheatsheet_two_pointers_opposite_ends, docs_cheatsheet_two_pointers_skip, docs_cheatsheet_two_pointers_skip_swap [EXTRACTED 1.00]
- **Palindrome Exercise Series** — docs_cheatsheet_palindrome_ispalindrome, docs_cheatsheet_palindrome_isvalidpalindrome, docs_cheatsheet_palindrome_sample2refactor, docs_cheatsheet_palindrome_ispalindromenumber [INFERRED 0.85]

## Communities (65 total, 30 thin omitted)

### Community 2 - "ChatGPTTest"
Cohesion: 0.11
Nodes (5): Person, Age, Name, ChatGPT, ChatGPTTest

### Community 3 - "WhereExercises"
Cohesion: 0.24
Nodes (3): Where — [WhereExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/WhereExercisesTest.cs), WhereExercisesTest, WhereExercises

### Community 4 - "AVL & BST Trees"
Cohesion: 0.09
Nodes (15): AVLTree, Node, Height, Key, Left, Right, BinarySearchTree, Root (+7 more)

### Community 7 - "OtherTest"
Cohesion: 0.07
Nodes (6): Compressor, Palindrome, StringDuplicates, Parangram, StringMerger, OtherTest

### Community 8 - "Queue"
Cohesion: 0.27
Nodes (5): Node, Data, Next, Queue, QueueTest

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
Cohesion: 0.10
Nodes (12): LinkedList, Node, Data, Next, Node, Data, Next, Stack (+4 more)

### Community 15 - "Arrays & Strings (CtCI)"
Cohesion: 0.16
Nodes (4): PermutationDetector, UniqueCharacters, UrlConverter, ArraysAndStringsTest

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
Cohesion: 0.07
Nodes (15): TrainingAlgorithms.algorithms.hard, TestTrainingAlgorithms.algorithms.hard, Hard, Summary, Tracking: TestTrainingAlgorithms, EmailGeneratorTest, ThreeSumTest, TrappingRainWaterTest (+7 more)

### Community 26 - "List"
Cohesion: 0.13
Nodes (3): ThenBy / ThenByDescending — [ThenByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ThenByExercisesTest.cs), ThenByExercisesTest, ThenByExercises

### Community 27 - "SkipExercises"
Cohesion: 0.23
Nodes (3): Skip / Take / SkipWhile / TakeWhile — [SkipExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SkipExercisesTest.cs), SkipExercisesTest, SkipExercises

### Community 29 - "FibonacciTest"
Cohesion: 0.29
Nodes (3): FibonacciMemoized, FibonacciNaive, FibonacciTest

### Community 30 - "SetUp"
Cohesion: 0.05
Nodes (19): Medium, MergeSort, Recursion, CodeWars, MergeSortTest, RecursionTest, CodeWarsTest, FirstUniqueCharacterTest (+11 more)

### Community 31 - "system_text"
Cohesion: 0.11
Nodes (7): Test.questions.lamdas, Samples.questions.lambdas, Samples.questions.arraysAndStrings, Test.algorithms.questions, Samples.POCOS, Kata, RemoveDuplicates

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

### Community 40 - "SelectManyExercisesTest"
Cohesion: 0.16
Nodes (3): SelectMany — [SelectManyExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SelectManyExercisesTest.cs), SelectManyExercisesTest, SelectManyExercises

### Community 42 - "Algorithms Cheat Sheet"
Cohesion: 0.22
Nodes (9): Algorithms Cheat Sheet, C# Quick Reference (Strings, Chars, Loops), Edge-Case Checklist, Integer Overflow (int.MaxValue), LINQ Allocation Cost, C# String Immutability, StringBuilder, Time / Space Complexity Quick Guide (+1 more)

### Community 44 - "ContainsExercisesTest"
Cohesion: 0.22
Nodes (5): ContainsExercisesTest, City, Country, IsCapital, Name

### Community 47 - "Employee"
Cohesion: 0.16
Nodes (4): Employee, Department, Name, Salary

### Community 48 - "SelectMany — [SelectManyExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SelectManyExercisesTest.cs)"
Cohesion: 0.24
Nodes (4): Customer, City, Name, Orders

### Community 49 - "Order"
Cohesion: 0.26
Nodes (4): Order, Customer, Id, Products

### Community 52 - "Easy"
Cohesion: 0.36
Nodes (3): Easy, ReverseVowelsTest, ReverseVowels

### Community 53 - "TrainingAlgorithms.algorithms.medium"
Cohesion: 0.16
Nodes (4): Test.leetcode, Samples.questions.leetcode.array, TestTrainingAlgorithms.algorithms.medium, TrainingAlgorithms.algorithms.medium

### Community 55 - "Student"
Cohesion: 0.31
Nodes (3): Student, Courses, Name

### Community 64 - "Progress Log"
Cohesion: 0.24
Nodes (7): Palindrome.IsPalindrome, Palindrome.IsPalindromeNumber, Palindrome.IsValidPalindrome, Palindrome.Sample2Refactor, Progress Log, ReverseOnlyLetters.Reverse, while vs do...while vs for Loops

## Knowledge Gaps
- **67 isolated node(s):** `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name`, `Age`, `netstandard2.0` (+62 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 121 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **30 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `GroupByExercisesTest` connect `GroupByExercisesTest` to `system_collections_generic`, `GroupByExercises`, `Dictionary`, `Employee`, `Order`?**
  _High betweenness centrality (0.047) - this node is a cross-community bridge._
- **What connects `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name` to the rest of the system?**
  _67 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `StringProblemsTest` be split into smaller, more focused modules?**
  _Cohesion score 0.13768115942028986 - nodes in this community are weakly interconnected._
- **Why does `12. Progress log` connect `GroupByExercises` to `Person`, `WhereExercises`, `ContainsExercisesTest`, `SelectManyExercisesTest`, `Employee`, `LINQ Cheat Sheet`, `List`, `SkipExercises`, `GroupByExercisesTest`?**
  _High betweenness centrality (0.034) - this node is a cross-community bridge._
- **Should `ChatGPTTest` be split into smaller, more focused modules?**
  _Cohesion score 0.11 - nodes in this community are weakly interconnected._
- **Why does `LINQ Cheat Sheet` connect `LINQ Cheat Sheet` to `GroupByExercises`?**
  _High betweenness centrality (0.030) - this node is a cross-community bridge._
- **Should `AVL & BST Trees` be split into smaller, more focused modules?**
  _Cohesion score 0.09019607843137255 - nodes in this community are weakly interconnected._