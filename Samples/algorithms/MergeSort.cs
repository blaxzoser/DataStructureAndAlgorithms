using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Samples.algorithms
{
    public class MergeSort
    {
        public void Sort(int[] array, int left, int right)
        {
            Debug.WriteLine("Spliting left right:'"+ left + ' ' + right);
            if (left < right)
            {
                //Find the middle point
                var middle = (left + right) / 2;

                //Sort first and second halves
                Sort(array, left, middle);
                Sort(array, middle + 1, right);

                //Merge the sorted halves
                Merge(array, left, middle, right);
            }
        }

        // Merges two subarrays of arr[].
        // First subarray is arr[l..m]
        // Second subarray is arr[m+1..r]
        public void Merge(int[] array,int left, int middle,int right) 
        {
            Debug.WriteLine("merge left middle right:" + left + " " + middle + " " + right);
            // Find sizes of two subarrays to be merged
            int n1 = middle - left + 1;
            int n2 = right - middle;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];

            //Copy data to temp arrays
            for (int x = 0; x < n1; x++)
                L[x] = array[left + x];
            for (int y = 0; y < n2; y++)
                R[y] = array[middle + 1 + y];



            /* Merge the temp arrays */
            // Initial indexes of first and second subarrays
            int i = 0, j = 0;

            // Initial index of merged subarry array
            int k = left;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }
                k++;
            }

            /* Copy remaining elements of L[] if any */
            while (i < n1)
            {
                array[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = R[j];
                j++;
                k++;
            }

            Debug.WriteLine("After merge");
            PrintArray(array);
        }



        public void PrintArray(int[] array) 
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
                Debug.Write(array[i] + " ");
            Debug.WriteLine("");
        }
    }
}
