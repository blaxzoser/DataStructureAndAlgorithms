# Algorithms Cheat Sheet

Quick reminders to recognize a problem and pick the right technique.
Update this file every time you finish a new exercise in `TrainingAlgorithms`.

---

## 1. How to start any problem

1. Read the examples and write 2–3 of your own, including edge cases.
2. Ask: **what kind of input is it?** (string, array, number, linked list, tree…)
3. Ask: **does it look like one of the patterns below?**
4. Write the simplest working solution first, then improve Time/Space.
5. Run the tests and go through the edge-case checklist (section 5).

---

## 2. Patterns

### Two Pointers (opposite ends)

**Use it when:** the problem compares or swaps things from **both ends** of a
string or array: palindromes, reversing, pair sums on a sorted array.

**Template:**

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
- Prefer `while` over `do...while`: `""` and `"a"` skip the loop, so no special case is needed.
- Return early as soon as the answer is known (`return false` on a mismatch).

### Two Pointers + Skip

**Use it when:** same as above, but some characters **don't count**
(spaces, symbols, upper/lower case).

**Template:**

```csharp
while (left < right)
{
    while (left < right && !Counts(input[left])) left++;    // skip forward
    while (left < right && !Counts(input[right])) right--;  // skip back

    // compare input[left] and input[right]

    left++;
    right--;
}
```

- **Key idea:** skipping still moves the pointers. `left` only goes forward and `right` only goes back.
- Still **O(n)**, even with loops inside a loop: the inner loops don't start over, so each character is visited at most once.
- The inner loops also need `left < right`, or a string of only junk (`".,"`) makes the pointers cross or go out of range.
- Don't build a "clean" copy of the string first: it costs Space O(n).

**Seen in:** `Palindrome.Sample2Refactor`

### Two Pointers + Skip + Swap

**Use it when:** you must reverse / rearrange only SOME elements and leave the
rest in place (only letters, only vowels…).

Same template as Two Pointers + Skip, only the last step changes:

```csharp
char[] chars = input.ToCharArray();          // strings can't be changed
while (left < right)
{
    while (left < right && !Counts(chars[left])) left++;
    while (left < right && !Counts(chars[right])) right--;

    (chars[left], chars[right]) = (chars[right], chars[left]);   // swap instead of compare

    left++;
    right--;
}
return new string(chars);
```

- Don't write `if / else if` for each case (letter/symbol on each side): it's
  easy to forget "both are symbols", and then nothing moves → infinite loop.
  The inner whiles cover every case.
- When `left == right` the swap is with itself: harmless.

**Seen in:** `ReverseOnlyLetters.Reverse` (40 min, first try hung), `ReverseVowels.Reverse`

### Digit manipulation (numbers without strings)

**Use it when:** the problem is about the digits of a number (reverse it,
sum the digits, palindrome number).

```csharp
int lastDigit = number % 10;          // 1234 -> 4
number /= 10;                         // 1234 -> 123
reversed = reversed * 10 + lastDigit; // 12   -> 123
```

- Time **O(log10 n)**: one step per digit.
- Reversing a whole `int` can **overflow** (`2147483647`). Reversing only half avoids it.
- Palindrome trick: stop when `reversed >= number`, then compare
  `number == reversed || number == reversed / 10` (the `/ 10` drops the middle digit when the number has an odd number of digits).

**Seen in:** `Palindrome.IsPalindromeNumber`

---

## 3. C# quick reference

### Strings and chars

| Need | Code |
|---|---|
| Char is a letter | `char.IsLetter(c)` |
| Char is letter or digit | `char.IsLetterOrDigit(c)` |
| Char is a digit | `char.IsDigit(c)` |
| Compare ignoring case | `char.ToLowerInvariant(a) == char.ToLowerInvariant(b)` |
| Null or empty | `string.IsNullOrEmpty(s)` |
| Change characters | `char[] chars = s.ToCharArray();` … `return new string(chars);` |
| Build a string in a loop | `var sb = new StringBuilder(); sb.Append(c); sb.ToString();` |
| Swap two items | `(chars[i], chars[j]) = (chars[j], chars[i]);` |

- Strings are **immutable** in C#: `s[0] = 'x'` doesn't compile. Use a `char[]` or `StringBuilder`.
- `s1 + s2` in a loop creates a new string every time: use `StringBuilder`.
- LINQ (`Where`, `Concat`, `Reverse`) is short to write but allocates new collections, so watch the Space.

### Loops

| Loop | Checks the condition | Use when |
|---|---|---|
| `while` | before each round | the loop may run 0 times (most two-pointer problems) |
| `do...while` | after each round | the loop must run at least once |
| `for` | before each round | you know the start, end and step |

---

## 4. Time / Space quick guide

| Complexity | Typical cause |
|---|---|
| O(1) | a few variables, no loops depending on n |
| O(log n) | the input shrinks by half (or /10) each step |
| O(n) | one pass, or pointers that never go back |
| O(n log n) | sorting |
| O(n²) | a loop inside a loop where the inner loop **starts over** each time |

- Space counts the **extra** memory you create: a copy of the string or a new array is O(n).
- Nested loops are **not always** O(n²). Count how many times each pointer can move in total.

---

## 5. Edge-case checklist

- [ ] `null`
- [ ] Empty: `""` / `[]`
- [ ] One element: `"a"` / `[1]`
- [ ] Two elements: `"ab"` / `[1, 2]`
- [ ] Only "junk": `" "`, `".,"`, `"123"`
- [ ] Upper vs lower case: `"Racecar"`
- [ ] Negative numbers and `0`
- [ ] Numbers ending in `0`: `10`
- [ ] Very large values (overflow): `int.MaxValue`

---

## 6. Progress log

| Exercise | Pattern | Expected | Real | Result | Notes |
|---|---|---|---|---|---|
| `Palindrome.IsPalindrome` | Two Pointers | 10 min | 15 min | ✅ | Use `while` instead of `do...while` |
| `Palindrome.IsValidPalindrome` | Two Pointers + Skip | 15 min | 30 min | ✅ | Built a clean copy (Space O(n)); see `Sample2Refactor` |
| `Palindrome.IsPalindromeNumber` | Digit manipulation | 15 min | 20 min | ❌ → reviewed | Only checked the last digit; review the half-reverse trick |
| `ReverseOnlyLetters.Reverse` | Two Pointers + Skip + Swap | 15 min | 40 min | ✅ | if/else if missed the "both symbols" case (hang); use the 2 inner whiles |
| `ReverseVowels.Reverse` (easy) | Two Pointers + Skip + Swap | 15 min | | | |
| `ValidPalindromeOneDeletion.CanBePalindrome` (medium) | Two Pointers + one deletion | 15 min | | | |
| `ContainerWithMostWater.MaxArea` (medium) | Two Pointers, move the shorter side | 15 min | | | |
| `ValidPalindromeSkipAndDelete.CanBeValidPalindrome` (hard) | Two Pointers + Skip + one deletion | 15 min | | | |
| `TrappingRainWater.Trap` (hard) | Two Pointers, move the shorter side + side max | 15 min | | | |

**Suggested order** (each one reuses the one before it):
`ReverseOnlyLetters` → `ReverseVowels` → `ValidPalindromeOneDeletion` → `ValidPalindromeSkipAndDelete`
and `ContainerWithMostWater` → `TrappingRainWater`.
