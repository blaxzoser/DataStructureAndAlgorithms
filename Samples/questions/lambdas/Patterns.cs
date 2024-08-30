using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples.questions.lambdas
{
    public  class Patterns
    {
        /// <summary>
        ///  Find the sum group patter
        ///  string array = "1 2 3,3 4 5,1 2 3 4 5,9 9 9,7 5,3 4 6";
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int MaxGroupSum(string text)
        {
            return text.Split(',')
                .Select(y => y.Split(' ')
                            .Select(r => Int32.Parse(r))
                            .Sum())
                .Max();
        }


        public string ContainsLetter(string text,string letter)
        {
            var source = string.Join(",",text.Split(',').Where(e => e.Contains(letter)));
            return source.ToString();
        }

        public string MaxContains(string text)
        {
            return text.Split(',').GroupBy(x => x).ToDictionary(g=> g.Key, g => g.Key.Length)
                .OrderByDescending(s => s.Value).First().Key;
        }

         public string[] SkipSecondWord(string[] text)
        {
            return text.Where((i, n) => n % 2 == 0).ToArray();
        }

        public string[] ReturnEven(string[] text)
        {
            return text.Where(s => s.Length % 2 != 0).ToArray();
        }


        /// <summary>
        /// Count how many numbers odd has it 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int CountOdd(string text)
        {
            return text.Split(',')
                .Select(x => int.Parse(x))
                .Where(s => s % 2 != 0)
                .Count();
        }

    }
}
