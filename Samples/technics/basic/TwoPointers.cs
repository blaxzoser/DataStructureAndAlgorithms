namespace Samples.technics.basic
{

    // when using two pointers,
    // we usually have one pointer starting at the beginning of the data structure
    // and the other pointer starting at the end of the data structure,
    // and we move the pointers towards each other based on certain conditions.
    public class TwoPointers
    {
        // Problem palindrome check using two pointers
        // Given a string s, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
        // Example 1:
        // Input: anitalabalatina
        // Output: true
        // Example 2:
        // Input: hello
        // Output: false
        public bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            for(int i= 0; i < s.Length / 2; i++)
            {
               if(s[left] != s[right])
               {
                   return false;
               }
                left++;
                right--;
            }
            return true;
        }

        // Problem Sum of Pair Equal to Target
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
           int left = 0;
           int right = numbers.Length - 1;

           while(left < right)
           {
                int totalSum = numbers[left] + numbers[right];
                if(totalSum == target)                
                    return true;
                else if (totalSum < target)
                    left++; // Move left pointer to the right
                else
                    right--; // Move right pointer to the left
            }
           
           return false;
        }

    }
}
