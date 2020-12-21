using System.Diagnostics;


namespace Samples.algorithms
{
    /// <summary>
    /// O(2^n)
    /// </summary>
    public class FibonacciNaive
    {
        public int Fib(int n)
        {
            Debug.WriteLine("Start fib(" + n + ")");
            if (n <= 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return Fib(n - 1) + Fib(n - 2);
            }
        }
    }
}
