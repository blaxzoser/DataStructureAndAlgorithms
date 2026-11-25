# Cheat Sheet: Two Pointers and Sliding Window

Only these two patterns, in one page. The full cheat sheet (all patterns, C#
reference, progress log) is [docs/CheatSheet.md](docs/CheatSheet.md).

---

## 1. Which one is it?

Both use `left` and `right`. The difference is **what you look at**:

- **Two pointers** look at the **2 cells** the pointers sit on. What's in between doesn't matter.
- **Sliding window** looks at **every cell between** `left` and `right`, and keeps a summary of it.

**Quick test on a new problem:**

1. Asks for a **pair** (both ends match, two numbers that sum to a target, the best two walls)? → **Two pointers** (often after sorting)
2. Asks for the longest / biggest / "at most k" **continuous piece** (substring, subarray)? → **Sliding window**

| | Two pointers | Sliding window |
|---|---|---|
| Pointers start | Opposite ends: `left = 0`, `right = n - 1` | Both at 0 |
| Direction | Toward each other | Same direction, left to right |
| Who moves | You decide each step (one `if/else`, or both) | `right` always (`for`), `left` only to fix the window (`while`) |
| Inner `while` does | **Skips** cells that don't count: "step over it" | **Removes** cells from the left until the window is valid: "the window is broken, throw out the oldest" |
| Key tool | Compare `a[left]` with `a[right]` | A summary of the window: `HashSet` / `sum` / `Dictionary` |
| Answer from | The comparison of the 2 cells | `right - left + 1` (size) or `sum` |
| Your exercises | `Palindrome`, `ReverseOnlyLetters`, `ReverseVowels`, `ContainerWithMostWater`, `BoatsToSavePeople`, `ThreeSum`, `ThreeSumClosest` | `LongestSubstringWithoutRepeating` (+ reps `LongestUniqueNumbers`, `LongestUniqueWords`, `LongestUniqueSubstring`), `MaximumUniqueSubarraySum`, `MaximumSumDistinctSubarrayOfLengthK`, (later) `LongestSubstringKDistinct` |

**One line:** two pointers look at 2 cells; a sliding window looks at all the
cells between them, keeping a running summary as `right` adds and `left` removes.

---

## 2. Two pointers

### 2a. Opposite ends (basic)

**Use it when:** you compare or swap things from **both ends**: palindromes, reversing.

```csharp
int left = 0;
int right = input.Length - 1;

while (left < right)          // stop when they meet or cross
{
    // compare / swap input[left] and input[right]
    left++;
    right--;
}
```

- Time **O(n)**, Space **O(1)**.
- Prefer `while` over `do...while`: `""` and `"a"` skip the loop, no special case needed.
- Return early as soon as the answer is known (`return false` on a mismatch).

**Seen in:** `Palindrome.IsPalindrome`

### 2b. + Skip (the 2 inner whiles)

**Use it when:** same as above, but some characters **don't count** (spaces, symbols, case).

```csharp
while (left < right)
{
    while (left < right && !Counts(input[left]))  left++;    // skip forward
    while (left < right && !Counts(input[right])) right--;   // skip back

    // compare input[left] and input[right]
    left++;
    right--;
}
```

- The inner whiles **skip** junk; the pointers only ever move inward.
- Still **O(n)**: the inner loops don't start over, each cell is visited once.
- The inner loops also need `left < right`, or a string of only junk (`".,"`) goes out of range.
- Don't build a "clean" copy of the string first: Space O(n).

**Seen in:** `Palindrome.Sample2Refactor`, duplicate skipping in `ThreeSum`

### 2c. + Skip + Swap

**Use it when:** you reverse / rearrange only SOME elements (only letters, only vowels).

```csharp
char[] chars = input.ToCharArray();          // strings can't be changed
while (left < right)
{
    while (left < right && !Counts(chars[left]))  left++;
    while (left < right && !Counts(chars[right])) right--;

    (chars[left], chars[right]) = (chars[right], chars[left]);   // swap instead of compare
    left++;
    right--;
}
return new string(chars);
```

- Don't write `if / else if` per case (letter/symbol on each side): you forget
  "both are symbols", nothing moves → infinite loop. The inner whiles cover every case.

**Seen in:** `ReverseOnlyLetters.Reverse`, `ReverseVowels.Reverse`

### 2d. Decide which pointer moves (no inner whiles)

**Use it when:** each step, one side is clearly "worse" and can be dropped
(usually on a **sorted** array, or comparing heights).

```csharp
while (left < right)
{
    // use a[left] and a[right] (area, pair sum, boat...)
    if (/* left side is the worse one */) left++;
    else right--;
}
```

- One `if/else` per step, no skip loops.
- Pair sum on a sorted array: sum too small → `left++`, too big → `right--`.

**Seen in:** `ContainerWithMostWater`, `BoatsToSavePeople`, `ThreeSum`, `ThreeSumClosest`

---

## 3. Sliding window

**Use it when:** the question asks for the longest / biggest / "at most k"
**continuous** piece (substring, subarray) that follows a rule.

```csharp
for (int right = 0; right < n; right++)      // right ALWAYS moves: a[right] wants to enter
{
    while (/* adding a[right] would break the rule */)
    {
        // a[left] LEAVES: Remove(a[left]) / sum -= a[left] / count--
        left++;
    }
    // a[right] ENTERS: Add(a[right]) / sum += a[right] / count++
    best = Math.Max(best, /* right - left + 1  or  sum */);
}
```

- Window = `[left .. right]`, size = `right - left + 1`.
- Still **O(n)**: each pointer only moves forward.
- **The shrink loop uses `a[left]` on EVERY line.** `a[right]` only appears in the `while` condition.
- Keep a **running** `sum` (`+=` on enter, `-=` on leave). Re-adding the window with a loop is O(n²).

**The window's summary (pick what the rule needs):**

| Summary | Answers | Shrink while… | Exercise |
|---|---|---|---|
| `HashSet` | Is this already inside? | `set.Contains(a[right])` | `LengthOfLongest` (+ the 3 reps), `MaxSum` |
| `sum` | What's the total inside? | (same as the set) | `MaxSum` |
| `HashSet` + size | Repeat, or window full? | `Contains(a[right]) \|\| right - left == k` | `MaximumSumDistinctSubarrayOfLengthK` |
| `Dictionary<char,int>` | How many of each inside? | `counts.Count > k` (shrink AFTER adding) | `LongestSubstringKDistinct` |

- With a `Dictionary`, when a count hits 0 **remove the key**, or `Count` never goes down.

---

## 4. Tricky cases

- Not every two-pointer problem has the skip whiles: `ContainerWithMostWater` and `BoatsToSavePeople` use one `if/else` (2d).
- Same direction but **not** a window: `RemoveDuplicates` (slow pointer writes, fast pointer reads). No summary of the range = not a window.

---

## 5. Your common mistakes (check before running the tests)

- `null` check **first**: `numbers == null || numbers.Length == 0` (`||` stops at the first true).
- No extra `Length == 1` special case: the main loop already handles it.
- Window: `right` grows (`for`, `Add(a[right])`, `sum +=`), `left` shrinks (`while`, `Remove(a[left])`, `sum -=`, `left++`). **Don't swap them.**
- `sum =+ x` means `sum = +x`. You want `sum += x`.
- Two pointers + skip: `if / else if` instead of the 2 inner whiles → infinite loop when both sides are junk.
