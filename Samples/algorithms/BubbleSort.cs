
namespace Samples.algorithms
{
    public class BubbleSort
    {
        /// <summary>
        /// O(n^2)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int[] Sort(int[] array) 
        {
            for (int i = array.Length; i > 0; i--)
            {
                for (int y = 0; y < i-1 ; y++)
                {
                    if(array[y] > array[y+1])
                    {
                        var temp = array[y];
                        array[y] = array[y + 1];
                        array[y + 1] = temp;
                    }
                }
            }

            return array;
        }

        public int[] SortRefactor(int[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                for (int y = 0; y < array.Length-i-1; y++)
                {
                    if (array[y] > array[y + 1])
                    {
                        var temp = array[y];
                        array[y] = array[y + 1];
                        array[y + 1] = temp;
                    }
                }
            }

            return array;
        }
    }
}
