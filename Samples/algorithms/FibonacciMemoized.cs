using System.Diagnostics;

namespace Samples.algorithms
{
    public class FibonacciMemoized
    {
        private int[] memo = new int[1001];

        public int Fib(int n)
        {
            Debug.WriteLine("n = " + n);
            if (n <= 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else if (memo[n] == 0)
            {
                memo[n] = Fib(n - 1) + Fib(n - 2);
            }
            return memo[n];
        }

    }
}
