using System;
namespace Samples.questions.lambdas
{
    public class ArrayFind
    {
        public int FindSmallestIntApproachSimple(int[] array)
        {
            Array.Sort(array);
            return array[0];
        }

        public int FindSmallestIntApproachLinq(int[] array)
        {
            return System.Linq.Enumerable.Min(array);
        }

        public int FindSmallestIntApproachLoop(int[] array)
        {
            int smallest = array[0];
            foreach (int number in array)
            {
                if (number < smallest)
                {
                    smallest = number;
                }
            }
            return smallest;
        }

        public int FindLargestIntApproachLoop(int[] array)
        {
            int largest = array[0];
            for (int number = 0; number < array.Length; number++)
            {
                if (array[number] > largest)
                {
                    largest = array[number];
                }
            }
            return largest;
        }

        public int FindSecondLargestNumberApproachSimple(int[] array)
        {
            Array.Sort(array);
            return array[1];
        }

        public int FindSecondLargestNumberWithLoop(int[] array)
        {
            int largest = array[0];
            int second = array[1];
            
            for (int i = 1; i < array.Length; i++)
            {
                int temp = array[i];
                if (largest < temp)
                {
                    second = largest;
                    largest = temp;
                }
                else if(temp > second && temp != largest)
                {
                    second = temp;
                }
            }
            return second;

        }
    }
}
