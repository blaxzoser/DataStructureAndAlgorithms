using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Samples.algorithms
{
    public class MergeSort
    {
        /// <summary>
        /// O(nLogn)
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public void Sort(int[] array, int left, int right)
        {
            Debug.WriteLine("Spliting left right:'"+ left + ' ' + right);
            if (left < right)
            {
                //Find the middle point
                var middle = (left + right) / 2;

                //Sort first and second halves
                Sort(array, left, middle);
                Debug.WriteLine("Its over first part left middle  right :" + left + middle + right);

                Sort(array, middle + 1, right);
                Debug.WriteLine("Its over second part left middle right :" + left + middle + right);


                //Merge the sorted halves
                Merge(array, left, middle, right);
            }
        }

        // Merges two subarrays of arr[].
        // First subarray is arr[l..m]
        // Second subarray is arr[m+1..r]
        public void Merge(int[] array,int left, int middle,int right) 
        {
           Debug.WriteLine("----------------------------------------------------");
           Debug.WriteLine("merge left middle right:" + left + " " + middle + " " + right);
            // Find sizes of two subarrays to be merged
            int n1 = middle - left + 1;
            Debug.WriteLine("n1 = {0}", n1);

            int n2 = right - middle;
            Debug.WriteLine("n2 = {0}", n2);

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];

            //Copy data to temp arrays
            Debug.WriteLine("Copy data to temp arrays");
            Debug.WriteLine("----------------------------------------------------");
            for (int x = 0; x < n1; x++)
            {
                Debug.WriteLine("L[{0}] = {1}",x, array[left + x]);
                L[x] = array[left + x];
            }
            for (int y = 0; y < n2; y++)
            {
                R[y] = array[middle + 1 + y];
                Debug.WriteLine("R[{0}] = {1}", y, array[middle + 1 + y]);
            }


            Debug.WriteLine("Merge the temp arrays ");
            Debug.WriteLine("----------------------------------------------------");

            /* Merge the temp arrays */
            // Initial indexes of first and second subarrays
            int i = 0, j = 0;

            // Initial index of merged subarry array
            int k = left;
            while (i < n1 && j < n2)
            {
                Debug.WriteLine("L[{0}] <= R[{1}] ===== {2} <= {3}", i, j, L[i], R[j]);
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
            Debug.WriteLine("----------------------------------------------------");
            Debug.WriteLine("Copy remaining elements of L[] if any");
            Debug.WriteLine("While({0}<{1})",i,n1);
            while (i < n1)
            {
                Debug.WriteLine("array[{0}] = L[{1}]", k, i);
                array[k] = L[i];
                i++;
                k++;
            }

            Debug.WriteLine("While({0}<{1})", j, n2);
            while (j < n2)
            {
                array[k] = R[j];
                Debug.WriteLine("array[{0}] = R[{1}]", k, j);
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
