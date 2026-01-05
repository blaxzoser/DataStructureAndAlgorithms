using System;
namespace Samples.questions.lambdas
{
    // ============================================================================
    // ARRAY FINDING OPERATIONS
    // ============================================================================
    // This class demonstrates different approaches to finding values in arrays:
    //   - Finding smallest/largest numbers
    //   - Finding second largest numbers
    //   - Using different techniques: sorting, LINQ, and manual loops
    // ============================================================================
    public class ArrayFind
    {
        // ========================================================================
        // APPROACH 1: Find Smallest Integer (Using Sort)
        // ========================================================================
        // STRATEGY: Sort the array, then return the first element
        // TIME COMPLEXITY: O(n log n) - sorting takes time
        // SPACE COMPLEXITY: O(1) - no extra space needed
        //
        // VISUAL EXAMPLE: [5, 2, 8, 1, 9]
        //   Step 1: Sort array → [1, 2, 5, 8, 9]
        //   Step 2: Return first element → 1 ✓
        //
        // NOTE: This modifies the original array!
        public int FindSmallestIntApproachSimple(int[] array)
        {
            Array.Sort(array);  // Sort in ascending order: smallest → largest
            return array[0];    // First element is now the smallest
        }

        // ========================================================================
        // APPROACH 2: Find Smallest Integer (Using LINQ)
        // ========================================================================
        // STRATEGY: Use LINQ's Min() function
        // TIME COMPLEXITY: O(n) - must check every element
        // SPACE COMPLEXITY: O(1) - no extra space needed
        //
        // VISUAL EXAMPLE: [5, 2, 8, 1, 9]
        //   Min() scans: 5 → 2 → 8 → 1 → 9
        //   Compares: 5 vs 2 → keep 2, 2 vs 8 → keep 2, 2 vs 1 → keep 1, 1 vs 9 → keep 1
        //   Result: 1 ✓
        //
        // NOTE: This does NOT modify the original array!
        public int FindSmallestIntApproachLinq(int[] array)
        {
            return System.Linq.Enumerable.Min(array);  // LINQ finds minimum value
        }

        // ========================================================================
        // APPROACH 3: Find Smallest Integer (Using Manual Loop)
        // ========================================================================
        // STRATEGY: Loop through array, keep track of smallest value seen so far
        // TIME COMPLEXITY: O(n) - must check every element once
        // SPACE COMPLEXITY: O(1) - only one variable needed
        //
        // VISUAL EXAMPLE: [5, 2, 8, 1, 9]
        //   Initial: smallest = 5 (first element)
        //   
        //   Iteration 1: Check 5 → 5 < 5? No → smallest stays 5
        //   Iteration 2: Check 2 → 2 < 5? Yes → smallest = 2
        //   Iteration 3: Check 8 → 8 < 2? No → smallest stays 2
        //   Iteration 4: Check 1 → 1 < 2? Yes → smallest = 1
        //   Iteration 5: Check 9 → 9 < 1? No → smallest stays 1
        //
        //   Final result: 1 ✓
        //
        // NOTE: This does NOT modify the original array!
        public int FindSmallestIntApproachLoop(int[] array)
        {
            // Start with first element as our initial "smallest" candidate
            int smallest = array[0];
            
            // Check every element in the array
            foreach (int number in array)
            {
                // If we find a number smaller than our current smallest, update it
                if (number < smallest)
                {
                    smallest = number;  // Found a new smallest value!
                }
            }
            
            return smallest;  // Return the smallest value found
        }

        // ========================================================================
        // Find Largest Integer (Using Manual Loop)
        // ========================================================================
        // STRATEGY: Loop through array, keep track of largest value seen so far
        // TIME COMPLEXITY: O(n) - must check every element once
        // SPACE COMPLEXITY: O(1) - only one variable needed
        //
        // VISUAL EXAMPLE: [5, 2, 8, 1, 9]
        //   Initial: largest = 5 (first element)
        //   
        //   Iteration 0: Check array[0] = 5 → 5 > 5? No → largest stays 5
        //   Iteration 1: Check array[1] = 2 → 2 > 5? No → largest stays 5
        //   Iteration 2: Check array[2] = 8 → 8 > 5? Yes → largest = 8
        //   Iteration 3: Check array[3] = 1 → 1 > 8? No → largest stays 8
        //   Iteration 4: Check array[4] = 9 → 9 > 8? Yes → largest = 9
        //
        //   Final result: 9 ✓
        //
        // NOTE: This does NOT modify the original array!
        public int FindLargestIntApproachLoop(int[] array)
        {
            // Start with first element as our initial "largest" candidate
            int largest = array[0];
            
            // Loop through all indices (using index-based loop instead of foreach)
            for (int number = 0; number < array.Length; number++)
            {
                // If we find a number larger than our current largest, update it
                if (array[number] > largest)
                {
                    largest = array[number];  // Found a new largest value!
                }
            }
            
            return largest;  // Return the largest value found
        }

        // ========================================================================
        // APPROACH 1: Find Second Largest Number (Using Sort)
        // ========================================================================
        // STRATEGY: Sort the array, then return the second-to-last element
        // TIME COMPLEXITY: O(n log n) - sorting takes time
        // SPACE COMPLEXITY: O(1) - no extra space needed
        //
        // VISUAL EXAMPLE: [5, 2, 8, 1, 9]
        //   Step 1: Sort array → [1, 2, 5, 8, 9]
        //   Step 2: Return second-to-last element (index 1) → 8 ✓
        //
        // NOTE: This modifies the original array!
        // WARNING: This assumes array has at least 2 elements!
        public int FindSecondLargestNumberApproachSimple(int[] array)
        {
            Array.Sort(array);  // Sort in ascending order: smallest → largest
            return array[1];    // Second element is now the second smallest
            // NOTE: This actually returns second SMALLEST, not second LARGEST!
            // For second LARGEST, should use: array[array.Length - 2]
        }

        // ========================================================================
        // APPROACH 2: Find Second Largest Number (Using Manual Loop)
        // ========================================================================
        // STRATEGY: Track both largest and second largest as we scan the array
        // TIME COMPLEXITY: O(n) - must check every element once
        // SPACE COMPLEXITY: O(1) - only two variables needed
        //
        // KEY INSIGHT: When we find a new largest number:
        //   - The old largest becomes the new second largest
        //   - The new number becomes the largest
        //
        // VISUAL EXAMPLE: [5, 2, 8, 1, 9]
        //   Initial: largest = 5, second = 2
        //   
        //   Iteration 1 (i=1): Check array[1] = 2
        //      - 2 > 5? No
        //      - 2 > 2? No
        //      - largest = 5, second = 2
        //
        //   Iteration 2 (i=2): Check array[2] = 8
        //      - 8 > 5? Yes! → New largest found!
        //      - second = 5 (old largest)
        //      - largest = 8 (new largest)
        //
        //   Iteration 3 (i=3): Check array[3] = 1
        //      - 1 > 8? No
        //      - 1 > 5? No
        //      - largest = 8, second = 5
        //
        //   Iteration 4 (i=4): Check array[4] = 9
        //      - 9 > 8? Yes! → New largest found!
        //      - second = 8 (old largest)
        //      - largest = 9 (new largest)
        //
        //   Final result: second = 8 ✓
        //
        // NOTE: This does NOT modify the original array!
        public int FindSecondLargestNumberWithLoop(int[] array)
        {
            // Initialize with first two elements
            // Assume first is largest, second is second largest
            int largest = array[0];  // Track the largest number seen so far
            int second = array[1];   // Track the second largest number seen so far
            
            // Start from index 1 (we already processed index 0)
            for (int i = 1; i < array.Length; i++)
            {
                int temp = array[i];  // Current number we're examining
                
                // CASE 1: Found a new largest number!
                // When this happens, the old largest becomes the new second largest
                if (largest < temp)
                {
                    second = largest;  // Old largest becomes second largest
                    largest = temp;    // New number becomes largest
                }
                // CASE 2: Number is between second and largest
                // This number could be the new second largest (if it's not equal to largest)
                else if(temp > second && temp != largest)
                {
                    second = temp;  // Update second largest
                }
                // CASE 3: Number is <= second or == largest
                // Do nothing, our current largest and second are still correct
            }
            
            return second;  // Return the second largest value found
        }
    }
}
