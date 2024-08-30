using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples.questions.lambdas
{
    public class CodeWars
    {
        /// <summary>
        /// https://www.codewars.com/kata/5264d2b162488dc400000001
        /// Stop gninnipS My sdroW!
        /// Write a function that takes in a string of one or more words, 
        /// and returns the same string, but with all words that have five or more letters reversed (Just like the name of this Kata).
        /// Strings passed in will consist of only letters and spaces. 
        /// Spaces will be included only when more than one word is present.
        /// "Hey fellow warriors"  --> "Hey wollef sroirraw" 
        //  "This is a test        --> "This is a test" 
        //  "This is another test" --> "This is rehtona test"
        /// </summary>
        public string RemplaceText(int limit,string text)
        {
            //return string.Join(" ", text.Split(' ')
            //    .Select(x => x.Length > limit ? new string(x.Reverse().ToArray()) : x));
            // Another option
            return string.Join(" ", text.Split(' ')
               .Select(x => x.Length > limit ? string.Concat(x.Reverse()) : x));

        }
        /// <summary>
        ///  input = "1,3,2,2,2,3"
        ///  output = 3
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int CountOdd(string text)
        {
            return      text.Split(',')
                        .Select(x => int.Parse(x))
                        .GroupBy(source => source)
                        .Select(x => new { key = x, count = x.Count(n => n % 2 != 0) })
                        .OrderByDescending(x => x.count).First().key.Key;

        }
    }
}
