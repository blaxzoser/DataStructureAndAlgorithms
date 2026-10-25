# Data Structures & Algorithms in C#

A personal practice repo for data structures, algorithms and LINQ in C#.
It has two parts: **samples** (worked examples with explanations) and
**training** (exercises left empty to solve yourself, checked by unit tests).

## Repository structure

```
DataStructureAndAlgorithms.sln
│
├── Samples/                     Worked examples (library)
│   ├── algorithms/              Sorting, trees, heap, recursion, Fibonacci
│   ├── datastructures/          Dynamic array, hash table, linked list, queue, stack
│   ├── memory/                  Value types vs reference types
│   ├── technics/basic/          Techniques (two pointers)
│   ├── questions/               Interview, LeetCode, CodeWars and LINQ problems
│   └── POCOS/                   Simple model classes
├── Test/                        NUnit tests for Samples
│
├── TrainingAlgorithms/          Algorithm exercises to solve (library)
│   └── algorithms/easy|medium|hard/
├── TestTrainingAlgorithms/      NUnit tests for TrainingAlgorithms (same folders)
│
├── TrainingLambdasAndLinq/      LINQ / lambda exercises to solve (library)
│   ├── lambdasAndLinq/easy/     Where, First, Contains, Skip, SelectMany, GroupBy
│   └── POCOS/                   Person, Order, Student
├── TestTrainingLambdasAndLinq/  NUnit tests for TrainingLambdasAndLinq
│
├── DataStructureAndAlgorithms/  Console app (entry point, not used yet)
├── docs/                        Cheat sheet and progress tracking
└── graphify-out/                Generated knowledge graph of the code
```

## Training workflow

Each training exercise is a method that throws `NotImplementedException`. Its
comment header has the problem, examples, difficulty, Time/Space goal, expected
time, topic and tips.

1. Pick the next exercise in [docs/trackingTestTrainingAlgorithms.md](docs/trackingTestTrainingAlgorithms.md).
2. Write the solution in `TrainingAlgorithms/algorithms/<level>/`.
3. Run the tests until they pass.
4. Record the time, date and notes in the tracking file.
5. Add what you learned to [docs/CheatSheet.md](docs/CheatSheet.md).

Exercises are grouped by **pattern** and repeated with growing difficulty
(easy → medium → hard), so each pattern gets practiced until it sticks.

### Current algorithm exercises

| Level | Exercises | Pattern |
|---|---|---|
| Easy | Palindrome, ReverseOnlyLetters, ReverseVowels | Two pointers (+ skip, + swap), digit manipulation |
| Medium | ValidPalindromeOneDeletion, ContainerWithMostWater | Two pointers (one deletion, move the shorter side) |
| Hard | ValidPalindromeSkipAndDelete, TrappingRainWater | Two pointers (combined patterns, side max) |

## Getting started

**Requirements:** the [.NET SDK](https://dotnet.microsoft.com/download). Test
projects target `netcoreapp3.1`, so the .NET Core 3.1 runtime is needed to run
them. Libraries target `netstandard2.0`.

Build everything:

```bash
dotnet build DataStructureAndAlgorithms.sln
```

Run all tests:

```bash
dotnet test DataStructureAndAlgorithms.sln
```

Run only the algorithm training tests:

```bash
dotnet test TestTrainingAlgorithms/TestTrainingAlgorithms.csproj
```

Run the tests for one exercise:

```bash
dotnet test TestTrainingAlgorithms/TestTrainingAlgorithms.csproj --filter "FullyQualifiedName~ReverseVowelsTest"
```

> Training tests fail until the exercise is solved. That's expected.

## Docs

| File | What it is |
|---|---|
| [docs/CheatSheet.md](docs/CheatSheet.md) | Patterns with templates, C# quick reference, Time/Space guide, edge-case checklist |
| [docs/trackingTestTrainingAlgorithms.md](docs/trackingTestTrainingAlgorithms.md) | Time, date, result and notes for every algorithm exercise |

## Tech

C# 9 · .NET Standard 2.0 / .NET Core 3.1 · NUnit 3
