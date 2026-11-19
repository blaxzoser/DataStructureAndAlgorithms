# Graph Report - DataStructureAndAlgorithms  (2026-11-08)

## Corpus Check
- 130 files · ~65,713 words
- Verdict: corpus is large enough that graph structure adds value.
- Unclassified: 3 file(s) not represented in the graph (top: (none) 3)

## Summary
- 1091 nodes · 2627 edges · 72 communities (31 shown, 41 thin omitted)
- Extraction: 78% EXTRACTED · 22% INFERRED · 0% AMBIGUOUS · INFERRED: 583 edges (avg confidence: 0.87)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `338f0c72`
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
- Stack
- GroupByExercises
- Value vs Reference Types
- TestTrainingAlgorithms.csproj
- Max Heap
- Dynamic Array
- Linked List
- Arrays & Strings (CtCI)
- CodeWars
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
- FibonacciTest
- Medium
- system_text
- TrainingAlgorithms.algorithms.easy
- Person
- Easy
- system_collections_generic
- ContainsExercisesTest
- Test.csproj
- BubbleSort
- PalindromeTest
- Samples.questions.lambdas
- GroupAnagramsTest
- Algorithms Cheat Sheet
- StringProblems
- Employee
- ContainsExercises
- UniqueCharactersTest
- Easy
- ThreeSumClosestTest
- MergeSort
- system
- Recursion
- Half-Reverse Palindrome Number Trick
- AssignCookiesTest
- FirstUniqueCharacterTest
- RansomNoteTest
- ReverseOnlyLettersTest
- ValidAnagramTest
- OtherTest.cs
- LongestSubstringWithoutRepeatingTest
- ValidPalindromeOneDeletionTest

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
- `Medium` --references--> `ThreeSum`  [INFERRED]
  docs/trackingTestTrainingAlgorithms.md → TrainingAlgorithms/algorithms/hard/ThreeSum.cs
- `Easy` --references--> `ContainerWithMostWater`  [INFERRED]
  docs/trackingTestTrainingAlgorithms.md → TrainingAlgorithms/algorithms/medium/ContainerWithMostWater.cs
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

## Communities (72 total, 41 thin omitted)

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

### Community 8 - "Stack"
Cohesion: 0.10
Nodes (12): Node, Data, Next, Queue, Node, Data, Next, Stack (+4 more)

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
Cohesion: 0.07
Nodes (15): TrainingAlgorithms.algorithms.hard, TestTrainingAlgorithms.algorithms.hard, Hard, Summary, Tracking: TestTrainingAlgorithms, EmailGeneratorTest, ThreeSumTest, TrappingRainWaterTest (+7 more)

### Community 26 - "TestCase"
Cohesion: 0.05
Nodes (17): SelectMany — [SelectManyExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SelectManyExercisesTest.cs), ThenBy / ThenByDescending — [ThenByExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ThenByExercisesTest.cs), SelectManyExercisesTest, ThenByExercisesTest, SelectManyExercises, ThenByExercises, Customer, City (+9 more)

### Community 27 - "SkipExercises"
Cohesion: 0.23
Nodes (3): Skip / Take / SkipWhile / TakeWhile — [SkipExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/SkipExercisesTest.cs), SkipExercisesTest, SkipExercises

### Community 29 - "FibonacciTest"
Cohesion: 0.29
Nodes (3): FibonacciMemoized, FibonacciNaive, FibonacciTest

### Community 30 - "Medium"
Cohesion: 0.24
Nodes (5): Medium, BoatsToSavePeopleTest, ContainerWithMostWaterTest, BoatsToSavePeople, ContainerWithMostWater

### Community 31 - "system_text"
Cohesion: 0.19
Nodes (4): Samples.questions.arraysAndStrings, Test.algorithms.questions, Samples.POCOS, RemoveDuplicates

### Community 33 - "Person"
Cohesion: 0.14
Nodes (8): 12. Progress log, First / FirstOrDefault — [FirstExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/FirstExercisesTest.cs), FirstExercisesTest, FirstExercises, Person, Age, City, Name

### Community 34 - "Easy"
Cohesion: 0.20
Nodes (5): Contains / Any / All — [ContainsExercisesTest.cs](../TestTrainingLambdasAndLinq/lambdasAndLinq/easy/ContainsExercisesTest.cs), Easy, Rounds, Summary, Tracking: TestTrainingLambdasAndLinq

### Community 35 - "system_collections_generic"
Cohesion: 0.23
Nodes (3): TrainingLambdasAndLinq.lambdasAndLinq.easy, TestTrainingLambdasAndLinq.lambdasAndLinq.easy, TrainingLambdasAndLinq.POCOS

### Community 36 - "ContainsExercisesTest"
Cohesion: 0.22
Nodes (5): ContainsExercisesTest, City, Country, IsCapital, Name

### Community 37 - "Test.csproj"
Cohesion: 0.14
Nodes (5): netcoreapp3.1, Microsoft.NET.Test.Sdk (16.5.0), NUnit (3.12.0), NUnit3TestAdapter (3.16.1), Microsoft.NET.Sdk

### Community 38 - "BubbleSort"
Cohesion: 0.18
Nodes (4): BubbleSort, ArrayDouble, BubbleSortTest, ArrayDoubleTest

### Community 40 - "Samples.questions.lambdas"
Cohesion: 0.15
Nodes (3): Test.questions.lamdas, Samples.questions.lambdas, Kata

### Community 43 - "Algorithms Cheat Sheet"
Cohesion: 0.18
Nodes (13): Algorithms Cheat Sheet, C# Quick Reference (Strings, Chars, Loops), LINQ Allocation Cost, Palindrome.IsPalindrome, Palindrome.IsValidPalindrome, Palindrome.Sample2Refactor, Progress Log, ReverseOnlyLetters.Reverse (+5 more)

### Community 47 - "Employee"
Cohesion: 0.16
Nodes (4): Employee, Department, Name, Salary

### Community 50 - "Easy"
Cohesion: 0.36
Nodes (3): Easy, ReverseVowelsTest, ReverseVowels

### Community 62 - "Half-Reverse Palindrome Number Trick"
Cohesion: 0.40
Nodes (3): Edge-Case Checklist, Integer Overflow (int.MaxValue), Palindrome.IsPalindromeNumber

## Knowledge Gaps
- **67 isolated node(s):** `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name`, `Age`, `netstandard2.0` (+62 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 123 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **41 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `GroupByExercisesTest` connect `GroupByExercisesTest` to `system_collections_generic`, `.CharFrequency`, `GroupByExercises`, `Dictionary`, `.CountPeopleByCountry`, `.GetProductCountsByCustomer`, `Employee`?**
  _High betweenness centrality (0.051) - this node is a cross-community bridge._
- **What connects `netcoreapp3.1`, `Microsoft.NET.Sdk`, `Name` to the rest of the system?**
  _67 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `StringProblemsTest` be split into smaller, more focused modules?**
  _Cohesion score 0.13768115942028986 - nodes in this community are weakly interconnected._
- **Why does `12. Progress log` connect `Person` to `WhereExercises`, `GroupByExercises`, `.CountPeopleByCountry`, `Employee`, `ContainsExercises`, `LINQ Cheat Sheet`, `TestCase`, `SkipExercises`, `GroupByExercisesTest`?**
  _High betweenness centrality (0.043) - this node is a cross-community bridge._
- **Should `ChatGPTTest` be split into smaller, more focused modules?**
  _Cohesion score 0.11 - nodes in this community are weakly interconnected._
- **Why does `LINQ Cheat Sheet` connect `LINQ Cheat Sheet` to `Person`?**
  _High betweenness centrality (0.040) - this node is a cross-community bridge._
- **Should `AVL & BST Trees` be split into smaller, more focused modules?**
  _Cohesion score 0.09019607843137255 - nodes in this community are weakly interconnected._