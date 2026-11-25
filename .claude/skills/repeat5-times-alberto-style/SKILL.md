---
name: repeat5-times-alberto-style
description: Create 5 practice reps of an existing TrainingAlgorithms exercise X that keep X's EXACT code skeleton (same data structure, same loop, same while condition, same order of lines) and change ONLY the context/data type (string, int[], char[], string[] words, List<int>, List<string>, List<Person>). Each rep is a ~15 min stub with a clear header (samples, complexity, tips) plus NUnit tests. Use this whenever the user says "repeat5TimeAs Alberto style", "repeat 5 times Alberto style", "Alberto style", "give me reps of X", "same skeleton as X", "more practice like X without adding complexity", or asks for exercises "similar to X" to keep practicing a pattern until it sticks.
---

# Repeat 5 times, Alberto style

The user learns a pattern by writing the **same skeleton again and again** until
it sticks. They got frustrated (fairly) when a "follow-up" exercise quietly
changed two things at once (new data structure AND a different loop order), and
they failed because of the extra complexity, not the pattern.

So this skill produces **5 reps of exercise X** where the code they write is
**line for line the same as X**. The only thing that changes from rep to rep is
the **context**: the type of data the loop walks over. If a rep needs any other
change to work, it's the wrong rep: pick a different context.

Input: `X` = an existing exercise, e.g. `LongestSubstringWithoutRepeating.LengthOfLongest`
or just `MaxSum`. Optional: how many reps (default 5) and which contexts.

## Step 1: Read X and write down its skeleton

Read X's class (header + body; the user's own solution if they solved it), its
test file, and its row in `docs/trackingTestTrainingAlgorithms.md` (the notes
say where the user made mistakes). Also read section 5 "Your common mistakes"
of `TwoPointersAndSlidingWindow.md` if the pattern is two pointers or a window.

If X is unsolved and has no reference solution, write one privately to learn
the skeleton (don't save it into X's file).

Then write the **skeleton card** for X in your reply, before creating anything:

| Part | X uses |
|---|---|
| Input / output | e.g. `string` → `int` (length) |
| Data structure | e.g. `HashSet<char>` |
| Outer loop | e.g. `for (int right = 0; right < n; right++)` |
| Inner loop + condition | e.g. `while (memory.Contains(a[right]))` BEFORE adding |
| Lines inside the inner loop | e.g. `memory.Remove(a[left]); left++;` |
| After the inner loop | e.g. `memory.Add(a[right]);` |
| Answer update | e.g. `best = Math.Max(best, right - left + 1);` |
| Guard at the top | e.g. `if (input == null \|\| input.Length == 0) return 0;` |

Every rep must keep every row except "Input" (and the element type inside the
data structure, which follows from the input).

## Step 2: Choose 5 contexts

Pick from this menu, closest to X first, `List<Person>` last (it's the least
familiar):

| Context | What the loop walks over | Element type in the data structure |
|---|---|---|
| `int[]` | numbers | `int` |
| `string` | letters | `char` |
| `char[]` | letters | `char` |
| `string` sentence → `string[] words = sentence.Split(' ')` | words | `string` |
| `List<int>` | numbers (`.Count` instead of `.Length`) | `int` |
| `List<string>` | names / words | `string` |
| `List<Person>` | one property: `people[i].Name`, `.Age` or `.City` | that property's type |

Skip the context X itself already uses. Read the existing exercises in
`TrainingAlgorithms/algorithms/` and the project map in `CLAUDE.md` so a rep
doesn't duplicate an exercise that already exists.

**The one-change check (do this for each rep before writing it):** list what
differs from X. Allowed: the input type, the element type, `.Length` ↔ `.Count`,
the `Split(' ')` line for sentences, `people[i].Name` instead of `a[i]`, the
names of variables, and the story in the header. If anything else differs
(another data structure, another condition, another order, an extra parameter
like `k`, a different return kind, sorting, LINQ, an extra rule like "ignore
case"), drop that context and pick another. Why: each extra difference is a new
thing to learn, and the point is that nothing is new except the data.

Keep the **return kind** of X (if X returns a length, the rep returns a length;
if X returns a sum, the rep returns a sum).

## Step 3: Write each rep (stub + header)

Location and names follow the project conventions in `CLAUDE.md`:

- Same level folder as X (`easy` / `medium` / `hard`), namespace
  `TrainingAlgorithms.algorithms.<level>`.
- A class name that says the context, e.g. `LongestUniqueNumbers`,
  `LongestUniqueWords`, `LongestUniqueNames`. Keep X's method name when it fits
  (e.g. `LengthOfLongest`), so it reads as the same exercise.
- The body is only `throw new NotImplementedException();`.
- ASCII only in `.cs` files (`->`, not arrows or `²`): the user's editor has
  saved files in a legacy encoding before, and non-ASCII characters break.

Header template (fill every line; keep it short and concrete):

```csharp
    // ============================================================================
    // <TITLE> (rep N of <X class>)
    // ============================================================================
    // Same skeleton as <X method>, line for line. Same <data structure>, same
    // '<inner loop condition>' <before/after> adding, same <inside lines>, same <answer update>.
    //
    //   THE ONE CHANGE:   <X input>  ->  <new input>
    //                     <X element type> -> <new element type>
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class <Name>
    {
        // ========================================================================
        // SAMPLE 1: <one-line problem in plain words>
        // ========================================================================
        // <1-2 lines of rules: continuous piece, case sensitive, ...>
        //
        // <8-10 samples, input -> output (short why)>
        //
        // Difficulty: <same as X> (rep)
        // Goal: Time <same as X>, Space <same as X>
        // Expected time to solve: 15 min
        // Pattern: <X's pattern> (<X class>)
        // Topic: <...>
        // Tip 1: Write <X method> from memory and change ONLY the types.
        //        <the skeleton in one or two lines, with this rep's names>
        // Tip 2: <the line the user got wrong in X, from the tracking notes,
        //        written for this rep, e.g. "Inside the while, EVERY line uses left">
        // ========================================================================
        public <same return type> <Method>(<new input>)
        {
            throw new NotImplementedException();
        }
    }
```

**Samples: translate X's samples into the new context**, keeping the same
expected answers where possible. The user already knows "abcabcbb" → 3,
"pwwkew" → 3, "abba" → 2; seeing `[1,2,3,1,2,3,2,2]` → 3 and
`"red blue blue red"` → 2 makes it obvious it's the same exercise. Always
include: a normal case, the "found after a shrink/skip" case, X's tricky case
(like "abba"), all the same, no repeats, one element, empty, and null.

## Step 4: Write the NUnit tests

`TestTrainingAlgorithms/algorithms/<level>/<Name>Test.cs`, namespace
`TestTrainingAlgorithms.algorithms.<level>`, class `<Name>Test`, a `[SetUp]`
that creates the instance, one `[TestCase]` row per sample (8–10), and a
separate `[Test]` for null. Look at X's test file and mirror its shape.

`[TestCase]` can't take objects, so for `List<...>` contexts pass an array and
build the list in a small private helper inside the test class:

```csharp
[TestCase(new[] { "Ana", "Luis", "Ana", "Eva" }, 3)]
public void ShouldGetLongestRunOfUniqueNames(string[] names, int output)
{
    Assert.AreEqual(output, longestUniqueNames.LengthOfLongest(ToPeople(names)));
}

private static List<Person> ToPeople(string[] names) =>
    names.Select(n => new Person(n, 30, "Lima")).ToList();
```

(That test file needs `using System.Collections.Generic;`, `using System.Linq;`
and `using TrainingAlgorithms.POCOS;`. The helper lives in the test, not in the
exercise, so the user's code stays the plain skeleton.)

`TrainingAlgorithms` has no `Person` class yet. The first time a rep needs one,
create `TrainingAlgorithms/POCOS/Person.cs` (namespace `TrainingAlgorithms.POCOS`)
with just `Name`, `Age`, `City` and a constructor `(name, age, city)`, the same
shape as `TrainingLambdasAndLinq/POCOS/Person.cs`. Reuse it after that.

## Step 5: Verify, then strip back to stubs

1. Put a temporary reference solution in each rep: X's skeleton with this rep's
   types (nothing else). If it needs anything more, the rep breaks the
   one-change rule: go back to Step 2.
2. Run only the new tests:
   `dotnet test TestTrainingAlgorithms/TestTrainingAlgorithms.csproj --filter "FullyQualifiedName~<Name>Test|FullyQualifiedName~<Name2>Test"`
   Fix the test expectations until all pass.
3. Replace each body with `throw new NotImplementedException();` again and
   build. Never change X's file or any file holding the user's own code.

## Step 6: Update the docs

- `docs/trackingTestTrainingAlgorithms.md`: one row per rep (next numbers),
  time `(15)`, notes = "Rep N of `<X>`, identical skeleton. Only change: ...";
  update the Summary counts.
- `docs/CheatSheet.md`: progress log rows, the suggested-order chain (reps go
  right after X), and the pattern's "Seen in" line.
- `TwoPointersAndSlidingWindow.md`, if X is two pointers or a sliding window:
  add the reps to the "Your exercises" cell and the summary table.
- `CLAUDE.md`: add the reps to the "Current TrainingAlgorithms exercises" list.
- Run `graphify update .`.

## Step 7: Report

Show a table: rep number, class/method (as a file link), THE ONE CHANGE, time,
number of tests. Say that all tests passed against the temporary solutions and
that the stubs are back. Give one `dotnet test --filter` command per rep (each
in its own `powershell` block), in the order to do them. Mention that nothing
is committed.
