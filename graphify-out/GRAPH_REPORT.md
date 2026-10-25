# Graph Report - DataStructureAndAlgorithms  (2026-10-24)

## Corpus Check
- 99 files · ~34,529 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 3 file(s) not represented in the graph (top: (none) 3)

## Summary
- 786 nodes · 1747 edges · 25 communities (19 shown, 6 thin omitted)
- Extraction: 82% EXTRACTED · 18% INFERRED · 0% AMBIGUOUS · INFERRED: 323 edges (avg confidence: 0.85)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `abf3734a`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- String Problems (LINQ)
- Namespaces & Array Exercises
- LINQ Exercise Tests
- Cheat Sheet & Palindrome Training
- AVL & BST Trees
- Lambdas & SelectMany
- SetUp
- Kata & Interview Questions
- Stack & Queue
- BubbleSort
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
- Data Structures & Algorithms in C#
- FibonacciTest

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
10. `FirstExercisesTest` - 13 edges

## Surprising Connections (you probably didn't know these)
- `AVLTreeTest` --references--> `AVLTree`  [EXTRACTED]
  Test/algorithms/AVLTreeTest.cs → Samples/algorithms/AVLTree.cs
- `BinarySearchTreeTest` --references--> `BinarySearchTree`  [EXTRACTED]
  Test/algorithms/BinarySearchTreeTest.cs → Samples/algorithms/BinarySearchTree.cs
- `BubbleSortTest` --references--> `BubbleSort`  [EXTRACTED]
  Test/algorithms/BubbleSortTest.cs → Samples/algorithms/BubbleSort.cs
- `FibonacciTest` --references--> `FibonacciMemoized`  [EXTRACTED]
  Test/algorithms/FibonacciTest.cs → Samples/algorithms/FibonacciMemoized.cs
- `FibonacciTest` --references--> `FibonacciNaive`  [EXTRACTED]
  Test/algorithms/FibonacciTest.cs → Samples/algorithms/FibonacciNaive.cs

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **Two Pointer Pattern Family** — docs_cheatsheet_two_pointers_opposite_ends, docs_cheatsheet_two_pointers_skip, docs_cheatsheet_two_pointers_skip_swap [EXTRACTED 1.00]
- **Palindrome Exercise Series** — docs_cheatsheet_palindrome_ispalindrome, docs_cheatsheet_palindrome_isvalidpalindrome, docs_cheatsheet_palindrome_sample2refactor, docs_cheatsheet_palindrome_ispalindromenumber [INFERRED 0.85]

## Communities (25 total, 6 thin omitted)

### Community 0 - "String Problems (LINQ)"
Cohesion: 0.06
Nodes (7): StringProblems, StringProblemsTest, netcoreapp3.1, Microsoft.NET.Test.Sdk (16.5.0), NUnit (3.12.0), NUnit3TestAdapter (3.16.1), Microsoft.NET.Sdk

### Community 1 - "Namespaces & Array Exercises"
Cohesion: 0.07
Nodes (17): TrainingLambdasAndLinq.lambdasAndLinq.easy, Test.algorithms, Test.questions.lamdas, Test.leetcode, Samples.questions.lambdas, Test, Samples.datastructures, Samples.questions.interviews (+9 more)

### Community 2 - "LINQ Exercise Tests"
Cohesion: 0.05
Nodes (12): ContainsExercisesTest, FirstExercisesTest, SkipExercisesTest, WhereExercisesTest, ContainsExercises, FirstExercises, SkipExercises, WhereExercises (+4 more)

### Community 3 - "Cheat Sheet & Palindrome Training"
Cohesion: 0.06
Nodes (24): TrainingAlgorithms.algorithms.easy, TestTrainingAlgorithms.algorithms.easy, Algorithms Cheat Sheet, C# Quick Reference (Strings, Chars, Loops), Edge-Case Checklist, Integer Overflow (int.MaxValue), LINQ Allocation Cost, Palindrome.IsPalindrome (+16 more)

### Community 4 - "AVL & BST Trees"
Cohesion: 0.09
Nodes (15): AVLTree, Node, Height, Key, Left, Right, BinarySearchTree, Root (+7 more)

### Community 5 - "Lambdas & SelectMany"
Cohesion: 0.07
Nodes (14): Person, Age, Name, ChatGPT, ChatGPTTest, SelectManyExercisesTest, SelectManyExercises, Order (+6 more)

### Community 6 - "SetUp"
Cohesion: 0.08
Nodes (10): MergeSort, QuickSort, Recursion, CodeWars, ArrayDouble, MergeSortTest, QuickSortTest, RecursionTest (+2 more)

### Community 7 - "Kata & Interview Questions"
Cohesion: 0.07
Nodes (7): Compressor, Kata, Palindrome, StringDuplicates, Parangram, StringMerger, OtherTest

### Community 8 - "Stack & Queue"
Cohesion: 0.18
Nodes (7): Node, Data, Next, Stack, Size, Balance, StackTest

### Community 10 - "Value vs Reference Types"
Cohesion: 0.13
Nodes (9): System.Runtime.CompilerServices, Samples.memory, PersonClass, Age, Name, PersonRecord, ValuesTypeVsReferenceType, IsExternalInit (+1 more)

### Community 11 - "Solution & Project Files"
Cohesion: 0.09
Nodes (17): TrainingAlgorithms, netstandard2.0, Microsoft.NET.Sdk, netcoreapp3.1, Microsoft.NET.Test.Sdk (16.5.0), NUnit (3.12.0), NUnit3TestAdapter (3.16.1), Microsoft.NET.Sdk (+9 more)

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

### Community 24 - "Data Structures & Algorithms in C#"
Cohesion: 0.06
Nodes (23): TestTrainingAlgorithms.algorithms.medium, TrainingAlgorithms.algorithms.medium, TrainingAlgorithms.algorithms.hard, TestTrainingAlgorithms.algorithms.hard, Hard, Medium, Summary, Tracking: TestTrainingAlgorithms (+15 more)

### Community 26 - "FibonacciTest"
Cohesion: 0.29
Nodes (3): FibonacciMemoized, FibonacciNaive, FibonacciTest

## Knowledge Gaps
- **58 isolated node(s):** `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name`, `Age`, `netstandard2.0` (+53 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 87 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **6 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `MaxIntHeap` connect `Max Heap` to `Namespaces & Array Exercises`?**
  _High betweenness centrality (0.035) - this node is a cross-community bridge._
- **What connects `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name` to the rest of the system?**
  _58 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `String Problems (LINQ)` be split into smaller, more focused modules?**
  _Cohesion score 0.05512016718913271 - nodes in this community are weakly interconnected._
- **Why does `BinarySearchTree` connect `AVL & BST Trees` to `Namespaces & Array Exercises`?**
  _High betweenness centrality (0.033) - this node is a cross-community bridge._
- **Should `Namespaces & Array Exercises` be split into smaller, more focused modules?**
  _Cohesion score 0.06568986568986569 - nodes in this community are weakly interconnected._
- **Why does `StringProblemsTest` connect `String Problems (LINQ)` to `Namespaces & Array Exercises`?**
  _High betweenness centrality (0.027) - this node is a cross-community bridge._
- **Should `LINQ Exercise Tests` be split into smaller, more focused modules?**
  _Cohesion score 0.05223880597014925 - nodes in this community are weakly interconnected._