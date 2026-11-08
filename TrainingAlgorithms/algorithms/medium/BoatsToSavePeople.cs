using System;
using System.Linq;

namespace TrainingAlgorithms.algorithms.medium
{
    // ============================================================================
    // BOATS TO SAVE PEOPLE (LeetCode 881)
    // ============================================================================
    // Practice for ContainerWithMostWater: two pointers from both ends of a
    // SORTED array, and a rule that decides which pointer moves. The greedy
    // proof is the same kind: the extreme element decides, and you never undo.
    //
    // Total practice time: ~15 min
    // ============================================================================
    public class BoatsToSavePeople
    {
        // ========================================================================
        // SAMPLE 1: Minimum number of boats
        // ========================================================================
        // weights[i] = weight of person i. Each boat carries AT MOST 2 people and
        // a total weight <= limit. Return the minimum number of boats.
        // (Assume every single person weighs <= limit.)
        //
        // ([1,2],       3) -> 1  (1 + 2 = 3)
        // ([3,2,2,1],   3) -> 3  ([3], [2,1], [2])
        // ([3,5,3,4],   5) -> 4  (nobody fits with anybody)
        // ([5,1,4,2],   6) -> 2  ([5,1], [4,2])  <- NOT sorted: sort first
        // ([1,2,3,4,5], 5) -> 3  ([5], [4,1], [3,2])
        // ([1],         3) -> 1
        // ([],          3) -> 0
        // (null,        3) -> 0
        //
        // Drawing of ([1,2,3,4,5], limit 5) after sorting, same L / R pointers
        // as MaxArea:
        //
        //   index   0  1  2  3  4
        //   weight  1  2  3  4  5
        //           L           R
        //
        //   round 1: heaviest R=5 ALWAYS boards. Does L=1 fit? 5+1=6 > 5 NO
        //            -> boat [5],   only R moves   (R=3)
        //   round 2: R=4, L=1: 4+1=5 <= 5 YES
        //            -> boat [4,1], both move      (L=1, R=2)
        //   round 3: R=3, L=2: 3+2=5 <= 5 YES
        //            -> boat [3,2], both move      (L=2, R=1) pointers crossed, stop
        //   boats = 3
        //
        // Difficulty: Medium
        // Goal: Time O(n log n) because of the sort, Space O(1)
        // Expected time to solve: 15 min
        // Pattern: Two Pointers (opposite ends) + decide who moves, like MaxArea
        // Topic: Arrays + Sorting + Greedy
        // Tip 1: Sort first. Then every round uses one boat (boats++), the
        //        heaviest person (right) always boards it.
        // Tip 2: The lightest person (left) boards too ONLY if they fit with the
        //        heaviest. If the lightest doesn't fit, nobody else does, so the
        //        heaviest goes alone. Careful with the loop condition: it is
        //        left <= right (one person can be left alone in the middle).
        // ========================================================================
        public int MinBoats(int[] weights, int limit)
        {
            throw new NotImplementedException();
        }
    }
}
