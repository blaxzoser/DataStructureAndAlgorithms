using System;

namespace TrainingAlgorithms.algorithms.hard
{
    // ============================================================================
    // USERNAME GENERATOR (similar to LeetCode 1487 "Making File Names Unique")
    // ============================================================================
    // Practice for EmailGenerator: same idea (build a name from the person's
    // words, add a number when it repeats). The new part: some usernames are
    // ALREADY taken before you start, so "count + 1" isn't enough. You must
    // look for the smallest number that is still free.
    //
    // Total practice time: ~1 hour
    // ============================================================================
    public class UsernameGenerator
    {
        // ========================================================================
        // SAMPLE 1: Give every new person a free username
        // ========================================================================
        // 'names' holds full names ("First [Middle ...] Last"). 'taken' holds the
        // usernames that already exist. Return one username per name, in the
        // same order.
        //
        // Rules:
        //   1. Username = first 3 letters of the FIRST name + first 3 letters of
        //      the LAST name, all lower case. "Luis Pintado" -> luipin
        //   2. Only letters count, and a shorter name uses all its letters.
        //      "Shaquille O'Neal" -> shaone, "Al Bo" -> albo
        //   3. Middle names are ignored. "Peter Benjamin Parker" -> petpar
        //   4. A one-word name uses its first 6 letters. "Madonna" -> madonn
        //   5. If the username is free, use it. If not, add the SMALLEST number
        //      (starting at 1) that makes it free: luipin1, luipin2, ...
        //   6. Taken means: in 'taken' OR given to someone earlier in this call.
        //      Compare IGNORING case ("LUIPIN" in 'taken' blocks luipin).
        //   7. null names -> empty array. null taken -> nothing is taken yet.
        //
        // (["Luis Pintado", "Luisa Pinzon", "Luigi Pinto"], [])
        //   -> ["luipin", "luipin1", "luipin2"]
        // (["Luis Pintado", "Luisa Pinzon", "Luigi Pinto"], ["luipin", "luipin2"])
        //   -> ["luipin1", "luipin3", "luipin4"]
        // (["Ana Silva"], ["ANASIL"])          -> ["anasil1"]
        // (["Al Bo", "Madonna"], [])           -> ["albo", "madonn"]
        // (null, ["x"])                        -> []
        //
        //   taken = { luipin, luipin2 }
        //   name            base     try                        result
        //   "Luis Pintado"  luipin   luipin X, luipin1 ok       luipin1
        //   "Luisa Pinzon"  luipin   luipin2 X, luipin3 ok      luipin3
        //   "Luigi Pinto"   luipin   luipin4 ok                 luipin4
        //
        // Difficulty: Hard
        // Goal: Time O(n + m) on average (n names, m taken), Space O(n + m)
        // Expected time to solve: 60 min
        // Pattern: Seen set (UniqueCharacters) + frequency count with a Dictionary
        //          (EmailGenerator)
        // Topic: Strings + Hashing
        // Tip 1: Put every taken username in a HashSet<string> with
        //        StringComparer.OrdinalIgnoreCase. Each time you give out a
        //        username, Add it to the same set.
        // Tip 2: Don't start from 1 every time: keep a Dictionary<string, int>
        //        base -> next number to try. Loop while base + number is in the
        //        set, number++. Save the number for the next person with the
        //        same base.
        // ========================================================================
        public string[] Generate(string[] names, string[] taken)
        {
            throw new NotImplementedException();
        }
    }
}
