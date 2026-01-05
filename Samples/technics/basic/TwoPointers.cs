namespace Samples.technics.basic
{

    // ============================================================================
    // TWO POINTERS TECHNIQUE
    // ============================================================================
    // When using two pointers, we usually have:
    //   - One pointer starting at the BEGINNING of the data structure
    //   - Another pointer starting at the END of the data structure
    //   - We move the pointers TOWARDS EACH OTHER based on certain conditions
    //
    // VISUAL REPRESENTATION:
    //   Initial state:  [a][b][c][d][e]
    //                    ↑           ↑
    //                  left        right
    //
    //   After moves:    [a][b][c][d][e]
    //                       ↑   ↑
    //                     left right
    //
    //   Final state:    [a][b][c][d][e]
    //                           ↑
    //                      left/right (meet in middle)
    // ============================================================================
    public class TwoPointers
    {
        // ========================================================================
        // PROBLEM: Palindrome Check Using Two Pointers
        // ========================================================================
        // A palindrome reads the same forwards and backwards.
        // Example: "racecar" -> r-a-c-e-c-a-r (same both ways)
        //
        // STRATEGY:
        //   1. Place one pointer at START (left) and one at END (right)
        //   2. Compare characters at both pointers
        //   3. If they match, move both pointers TOWARDS CENTER
        //   4. If they don't match, it's NOT a palindrome
        //   5. Stop when pointers meet or cross
        //
        // VISUAL EXAMPLE with "racecar":
        //   Step 1:  r a c e c a r
        //            ↑           ↑
        //          left(0)   right(6)  → Compare 'r' == 'r' ✓, move both inward
        //
        //   Step 2:  r a c e c a r
        //              ↑       ↑
        //          left(1)   right(5)  → Compare 'a' == 'a' ✓, move both inward
        //
        //   Step 3:  r a c e c a r
        //                ↑   ↑
        //          left(2)   right(4)  → Compare 'c' == 'c' ✓, move both inward
        //
        //   Step 4:  r a c e c a r
        //                  ↑
        //            left(3)=right(3)  → Pointers meet! All matched ✓ → PALINDROME
        //
        // VISUAL EXAMPLE with "hello" (NOT a palindrome):
        //   Step 1:  h e l l o
        //            ↑       ↑
        //          left(0) right(4)  → Compare 'h' == 'o' ✗ → NOT PALINDROME
        //
        // Given a string s, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
        // Example 1:
        // Input: anitalabalatina
        // Output: true
        // Example 2:
        // Input: hello
        // Output: false
        public bool IsPalindrome(string s)
        {
            // Initialize pointers: left at start (index 0), right at end (last index)
            int left = 0;                    // Points to first character
            int right = s.Length - 1;        // Points to last character
            
            // We only need to check half the string because:
            // - If first half matches second half, it's a palindrome
            // - Once pointers cross, we've checked everything
            for(int i= 0; i < s.Length / 2; i++)
            {
               // Compare characters at both pointer positions
               // If they don't match, it's NOT a palindrome
               if(s[left] != s[right])
               {
                   return false;  // Found mismatch → not a palindrome
               }
               
               // Characters match! Move both pointers TOWARDS CENTER
               left++;   // Move left pointer RIGHT (towards center)
               right--;  // Move right pointer LEFT (towards center)
            }
            
            // If we get here, all character pairs matched → it's a palindrome
            return true;
        }

        // ========================================================================
        // PROBLEM: Sum of Pair Equal to Target (Two Sum in Sorted Array)
        // ========================================================================
        // Find two numbers in a SORTED array that add up to a target value.
        //
        // KEY INSIGHT: Because the array is SORTED, we can use two pointers!
        //   - If sum is TOO SMALL → move left pointer RIGHT (to get bigger numbers)
        //   - If sum is TOO LARGE → move right pointer LEFT (to get smaller numbers)
        //   - If sum equals target → FOUND IT!
        //
        // VISUAL EXAMPLE 1: [10, 20, 35, 50], target = 70
        //   Step 1:  [10] [20] [35] [50]    sum = 10 + 50 = 60
        //            ↑                    ↑
        //          left(0)              right(3)  60 < 70 → too small, move left →
        //
        //   Step 2:  [10] [20] [35] [50]    sum = 20 + 50 = 70
        //                 ↑              ↑
        //             left(1)        right(3)  70 == 70 → FOUND! ✓
        //
        // VISUAL EXAMPLE 2: [10, 20, 30], target = 70
        //   Step 1:  [10] [20] [30]         sum = 10 + 30 = 40
        //            ↑              ↑
        //          left(0)       right(2)  40 < 70 → too small, move left →
        //
        //   Step 2:  [10] [20] [30]         sum = 20 + 30 = 50
        //                 ↑       ↑
        //             left(1)  right(2)  50 < 70 → too small, move left →
        //
        //   Step 3:  [10] [20] [30]         left(2) == right(2) → STOP
        //                      ↑
        //                  left/right     No pair found ✗
        //
        // VISUAL EXAMPLE 3: [-8, 1, 4, 6, 10, 45], target = 16
        //   Step 1:  [-8] [1] [4] [6] [10] [45]    sum = -8 + 45 = 37
        //            ↑                        ↑
        //          left(0)                 right(5)  37 > 16 → too large, move right ←
        //
        //   Step 2:  [-8] [1] [4] [6] [10] [45]    sum = -8 + 10 = 2
        //            ↑                  ↑
        //          left(0)           right(4)  2 < 16 → too small, move left →
        //
        //   Step 3:  [-8] [1] [4] [6] [10] [45]    sum = 1 + 10 = 11
        //                 ↑           ↑
        //             left(1)     right(4)  11 < 16 → too small, move left →
        //
        //   Step 4:  [-8] [1] [4] [6] [10] [45]    sum = 4 + 10 = 14
        //                    ↑        ↑
        //                left(2)   right(4)  14 < 16 → too small, move left →
        //
        //   Step 5:  [-8] [1] [4] [6] [10] [45]    sum = 6 + 10 = 16
        //                       ↑    ↑
        //                   left(3) right(4)  16 == 16 → FOUND! ✓
        //
        // Given an array of integers numbers sorted in ascending order,
        // find two numbers such that they add up to a specific target number.
        // The function should return true if such a pair exists, otherwise false.
        // Example 1:
        // Input: arr[] = [10, 20, 35, 50], target = 70
        // Output: true (There is a pair (20, 50) with given target.)
        // Example 2:
        // Input: arr[] = [10, 20, 30], target =70
        // Output: false
        // Example 3:
        // Input: arr[] = [-8, 1, 4, 6, 10, 45], target = 16
        // Output: true (There is a pair (6, 10) with given target.)
        // Source 1: https://www.geeksforgeeks.org/dsa/two-pointers-technique/
        public bool IsSumPairEqualToTarget(int[] numbers, int target)
        {
           // Initialize pointers: left at start (smallest), right at end (largest)
           int left = 0;                    // Points to smallest number
           int right = numbers.Length - 1;  // Points to largest number

           // Continue until pointers meet or cross
           // When left >= right, we've checked all possible pairs
           while(left < right)
           {
                // Calculate sum of numbers at both pointer positions
                int totalSum = numbers[left] + numbers[right];
                
                // CASE 1: Perfect match! We found the pair
                if(totalSum == target)                
                    return true;  // Found pair that sums to target ✓
                
                // CASE 2: Sum is too small
                // Since array is sorted, moving left pointer RIGHT gives us a LARGER number
                // This increases our sum, getting us closer to the target
                else if (totalSum < target)
                    left++; // Move left pointer to the right → get bigger number
                
                // CASE 3: Sum is too large
                // Since array is sorted, moving right pointer LEFT gives us a SMALLER number
                // This decreases our sum, getting us closer to the target
                else
                    right--; // Move right pointer to the left → get smaller number
            }
           
           // If we exit the loop, no pair was found
           return false;  // No pair sums to target ✗
        }

    }
}
