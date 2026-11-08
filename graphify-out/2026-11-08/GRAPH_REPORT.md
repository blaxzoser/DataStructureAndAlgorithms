# Graph Report - DataStructureAndAlgorithms  (2026-11-08)

## Corpus Check
- 126 files · ~61,780 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 3 file(s) not represented in the graph (top: (none) 3)

## Summary
- 1071 nodes · 2576 edges · 70 communities (34 shown, 36 thin omitted)
- Extraction: 78% EXTRACTED · 22% INFERRED · 0% AMBIGUOUS · INFERRED: 572 edges (avg confidence: 0.87)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `90058f86`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- StringProblemsTest
- system
- ChatGPTTest
- SelectManyExercisesTest
- AVL & BST Trees
- nunit_framework
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
- MergeSort
- Loop Patterns
- Hash Table
- ArrayFind Approaches
- Two Pointers Technique
- Console Entry Point
- Main Project File
- CodeWars
- LINQ Cheat Sheet
- TrappingRainWaterTest
- ThenByExercisesTest
- SkipExercises
- GroupByExercisesTest
- FibonacciTest
- GroupAnagramsTest
- system_text
- TrainingAlgorithms.algorithms.easy
- Person
- TestCase
- system_collections_generic
- ContainsExercisesTest
- Test.csproj
- BubbleSort
- Recursion
- Medium
- ArrayDouble
- PalindromeTest
- City
- RansomNoteTest
- StringProblems
- Employee
- Easy
- Order
- UniqueCharactersTest
- FirstUniqueCharacterTest
- ReverseOnlyLettersTest
- TrainingAlgorithms.algorithms.medium
- List
- Samples.questions.lambdas
- Student
- BoatsToSavePeopleTest
- LongestSubstringWithoutRepeatingTest
- ValidPalindromeOneDeletionTest
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

## Communities (70 total, 36 thin omitted)

### Community 1 - "system"
Cohesion: 0.13
Nodes (3): Test.leetcode, Samples.datastructures, Samples.questions.leetcode.array

### Community 2 - "ChatGPTTest"
Cohesion: 0.11
Nodes (5): Person, Age, Name, ChatGPT, ChatGPTTest

### Community 3 - "SelectManyExercisesTest"
Cohesion: 0.14
Nodes (3): SelectMany — [SelectManyExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SelectManyExercisesTest.cs), SelectManyExercisesTest, SelectManyExercises

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
Cohesion: 0.13
Nodes (9): System.Runtime.CompilerServices, Samples.memory, PersonClass, Age, Name, PersonRecord, ValuesTypeVsReferenceType, IsExternalInit (+1 more)

### Community 11 - "TestTrainingAlgorithms.csproj"
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

### Community 24 - "LINQ Cheat Sheet"
Cohesion: 0.06
Nodes (29): 10. Pitfalls checklist, 11. Time / Space quick guide, 1. Which operator do I need?, 2. Where — filter, 3. First / FirstOrDefault — take one, 4. Contains / Any / All — yes/no, 5. Skip / Take / SkipWhile / TakeWhile — slices, 6. OrderBy / ThenBy — sort and break ties (+21 more)

### Community 25 - "TrappingRainWaterTest"
Cohesion: 0.09
Nodes (11): TrainingAlgorithms.algorithms.hard, TestTrainingAlgorithms.algorithms.hard, Hard, EmailGeneratorTest, TrappingRainWaterTest, UsernameGeneratorTest, ValidPalindromeSkipAndDeleteTest, EmailGenerator (+3 more)

### Community 26 - "ThenByExercisesTest"
Cohesion: 0.13
Nodes (3): ThenBy / ThenByDescending — [ThenByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ThenByExercisesTest.cs), ThenByExercisesTest, ThenByExercises

### Community 27 - "SkipExercises"
Cohesion: 0.23
Nodes (3): Skip / Take / SkipWhile / TakeWhile — [SkipExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SkipExercisesTest.cs), SkipExercisesTest, SkipExercises

### Community 29 - "FibonacciTest"
Cohesion: 0.29
Nodes (3): FibonacciMemoized, FibonacciNaive, FibonacciTest

### Community 31 - "system_text"
Cohesion: 0.19
Nodes (4): Samples.questions.arraysAndStrings, Test.algorithms.questions, Samples.POCOS, RemoveDuplicates

### Community 32 - "TrainingAlgorithms.algorithms.easy"
Cohesion: 0.22
Nodes (3): TrainingAlgorithms.algorithms.easy, TestTrainingAlgorithms.algorithms.easy, Test

### Community 33 - "Person"
Cohesion: 0.09
Nodes (11): 12. Progress log, First / FirstOrDefault — [FirstExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/FirstExercisesTest.cs), Where — [WhereExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/WhereExercisesTest.cs), FirstExercisesTest, WhereExercisesTest, FirstExercises, WhereExercises, Person (+3 more)

### Community 34 - "TestCase"
Cohesion: 0.24
Nodes (4): AssignCookiesTest, ValidAnagramTest, AssignCookies, ValidAnagram

### Community 35 - "system_collections_generic"
Cohesion: 0.22
Nodes (3): TrainingLambdasAndLinq.lambdasAndLinq.easy, TestTrainingLambdasAndLinq.lambdasAndLinq.easy, TrainingLambdasAndLinq.POCOS

### Community 36 - "ContainsExercisesTest"
Cohesion: 0.11
Nodes (7): Contains / Any / All — [ContainsExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ContainsExercisesTest.cs), Easy, Rounds, Summary, Tracking: TestTrainingLambdasAndLinq, ContainsExercisesTest, ContainsExercises

### Community 37 - "Test.csproj"
Cohesion: 0.14
Nodes (5): netcoreapp3.1, Microsoft.NET.Test.Sdk (16.5.0), NUnit (3.12.0), NUnit3TestAdapter (3.16.1), Microsoft.NET.Sdk

### Community 40 - "Medium"
Cohesion: 0.33
Nodes (5): Medium, Summary, Tracking: TestTrainingAlgorithms, ContainerWithMostWaterTest, ContainerWithMostWater

### Community 44 - "City"
Cohesion: 0.21
Nodes (4): City, Country, IsCapital, Name

### Community 47 - "Employee"
Cohesion: 0.16
Nodes (4): Employee, Department, Name, Salary

### Community 48 - "Easy"
Cohesion: 0.36
Nodes (3): Easy, ReverseVowelsTest, ReverseVowels

### Community 49 - "Order"
Cohesion: 0.29
Nodes (4): Order, Customer, Id, Products

### Community 55 - "List"
Cohesion: 0.27
Nodes (4): Customer, City, Name, Orders

### Community 62 - "Samples.questions.lambdas"
Cohesion: 0.15
Nodes (3): Test.questions.lamdas, Samples.questions.lambdas, Kata

### Community 63 - "Student"
Cohesion: 0.31
Nodes (3): Student, Courses, Name

## Knowledge Gaps
- **67 isolated node(s):** `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name`, `Age`, `netstandard2.0` (+62 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 119 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **36 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `GroupByExercisesTest` connect `GroupByExercisesTest` to `.BuildNamesByCityLookup`, `system_collections_generic`, `.GetOldestPersonByCity`, `GroupByExercises`, `Dictionary`, `Employee`, `Order`?**
  _High betweenness centrality (0.041) - this node is a cross-community bridge._
- **What connects `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name` to the rest of the system?**
  _67 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `StringProblemsTest` be split into smaller, more focused modules?**
  _Cohesion score 0.13768115942028986 - nodes in this community are weakly interconnected._
- **Why does `12. Progress log` connect `Person` to `SelectManyExercisesTest`, `ContainsExercisesTest`, `GroupByExercises`, `Dictionary`, `Employee`, `LINQ Cheat Sheet`, `ThenByExercisesTest`, `SkipExercises`, `GroupByExercisesTest`?**
  _High betweenness centrality (0.027) - this node is a cross-community bridge._
- **Should `system` be split into smaller, more focused modules?**
  _Cohesion score 0.13157894736842105 - nodes in this community are weakly interconnected._
- **Why does `SelectManyExercisesTest` connect `SelectManyExercisesTest` to `system_collections_generic`, `City`, `Student`, `List`?**
  _High betweenness centrality (0.025) - this node is a cross-community bridge._
- **Should `ChatGPTTest` be split into smaller, more focused modules?**
  _Cohesion score 0.11 - nodes in this community are weakly interconnected._