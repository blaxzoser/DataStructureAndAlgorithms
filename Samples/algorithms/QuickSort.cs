using System.Diagnostics;

namespace Samples.algorithms
{
    public class QuickSort
    {
        public int[] Sort(int[] array) 
        {
            // Pick a pivot element randomly

            // Walk through the array making sure that all the elements
            // are smaller before the pivot, and that all elements after are bigger
            // and we do this in place! That's the killer feature. No extra array required.
            //
            // Then we repeat the process to the left and right portions over and over again
            // Then eventually our array becomes sorted.
            QuickSortMethod(array, 0, array.Length - 1);
            return array;
        }

        public void QuickSortMethod(int[] array, int left,int right) 
        {
            if (left >= right)
            { 
                return;
            }

            // Step 1: Pick a pivot element - we will choose the center
            // Better would be to choose left + (right-left)/2 (as this would avoid overflow error for large arrays i.e. 2GB))
            int pivot = array[(left + right) / 2];

            // Step 2: Partition the array around this pivot - return the index of the partition
            int index = Partition(array, left, right, pivot);

            // Step 3: Sort on the left and the right side
            QuickSortMethod(array, left, index - 1);
            QuickSortMethod(array, index, right);
        }

        private int Partition(int[] array, int left, int right, int pivot)
        {
            // Move the left and right pointers in towards each other
            while (left <= right)
            {

                // Move left until you find an element bigger than the pivot
                while (array[left] < pivot)
                {
                    left++;
                }

                // Move right until you find an element smaller than the pivot
                while (array[right] > pivot)
                {
                    right--;
                }

                // Then swap
                if (left <= right)
                {
                    Swap(array, left, right);
                    left++;
                    right--;
                }
            }

            // When we get here, everything in this partition will be in the right order
            // Now we need to return next partition point - which for us will be left
            return left;
        }

        private void Swap(int[] array, int left, int right)
        {
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }

        public void PrettyPrint(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
               Debug.WriteLine(a[i]);
            }
        }
    }
}
