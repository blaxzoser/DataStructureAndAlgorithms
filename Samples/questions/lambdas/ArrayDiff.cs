using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples.questions.lambdas
{
    public class  Kata
    {
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            if (b.Length == 0) return a;
            if (a.Length == 0) return new int[0];

            int initialCapacity = 1;
            int[] result = new int[initialCapacity];
            for (int i = 0; i < a.Length; i++)
            {
                for (int y = 0; y < b.Length; y++)
                {
                    if (a[i] != b[y])
                    {
                        int[] newOne = new int[initialCapacity];
                        for (int x = 0; x < initialCapacity; x++)
                        {
                            newOne[x] = a[i];
                        }
                        result = newOne;
                        initialCapacity = initialCapacity + 1;
                    }
                }
            }
            return result;
        }

        public static int[] ArrayDiffLambdasFail(int[] a, int[] b)
        {
            if (b.Length == 0) return a;
            if (a.Length == 0) return new int[0];

            return a.Except(b).ToArray();
        }

        public static int[] ArrayDiffLambdasGood(int[] a, int[] b)
        {
            return a.Where(n => !b.Contains(n)).ToArray();
        }

    }
}
