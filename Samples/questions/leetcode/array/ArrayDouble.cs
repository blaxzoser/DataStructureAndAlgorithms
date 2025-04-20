using System;
using System.Diagnostics;

namespace Samples.questions.leetcode.array
{
    public class ArrayDouble
    {
        /// <summary>
        /// You are given an n x n 2D matrix representing an image, 
        /// rotate the image by 90 degrees (clockwise).
        // You have to rotate the image in-place,
        // which means you have to modify the input 2D matrix directly.
        // DO NOT allocate another 2D matrix and do the rotation.
        // e.g 1
        // Input: [[1,2,3],[4,5,6],[7,8,9]]:
        // { 1, 2, 3},
        // { 4, 5, 6},
        // { 7, 8, 9 }
        // Output : [[7,4,1],[8,5,2],[9,6,3]]
        // { 7, 4, 1},
        // { 8, 5, 2},
        // { 9, 6, 3 }

        // e.g 2
        // Input: [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
        // { 5, 1, 9, 11},
        // { 2, 4, 8, 10},
        // { 13, 3, 6, 7 }
        // { 15, 14, 12, 16 }
        // Output : [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]
        // { 15, 13, 2, 5},
        // { 14, 3, 4,  1},
        // { 12, 6, 8 , 9}
        // { 16, 7, 10 ,11}


        /// </summary>
        /// <param name="matrix"></param>
        public void RotateImage(int[][] matrix)
        {
            int n = matrix.Length;
            // Step 1: Transpose the matrix\
            // It means that we swap the elements matrix[i][j] with matrix[j][i]
            for (int i = 0; i < n; i++)
            {
                // It start on read first row
                Debug.WriteLine($"Row index: {i}:");


                for (int j = i + 1; j < n; j++)
                {
                    // it start on read first column
                    Debug.WriteLine($"Column index:{j}");
                    Debug.WriteLine($"Row Column Value {matrix[i][j]}:");


                    // Swap the elements matrix[i][j] with matrix[j][i]
                    // This will convert the matrix from:
                    // { 1, 2, 3},
                    // { 4, 5, 6},
                    // { 7, 8, 9 }
                    // to:
                    // { 1, 4, 7},
                    // { 2, 5, 8},
                    // { 3, 6, 9 }
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            // Step 2: Reverse each row
            for (int i = 0; i < n; i++)
            {
                // So that we can easily reverse the rows
                Array.Reverse(matrix[i]);
            }
        }
        
        public void ReverseArrayDoubleOnlyRows(int[][] matrix)
        {
            var lengthRows = matrix.Length;
            for (int i = 0; i < lengthRows; i++)
            {
                var stoper = matrix[i].Length/2;
               for (int j = 0; j < stoper; j++)
               {
                    var temp = matrix[i][j];
                    var limitColumn = (matrix[j].Length - j) - 1;
                    matrix[i][j] = matrix[i][limitColumn];
                    matrix[i][limitColumn] = temp;
                }
            }

        }


    }
}
