using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.algorithms
{
    public class Recursion
    {
        public string StringZeros(string text)        
        {
            if (text[0] == '0')
                return StringZeros(text.Substring(1,text.Length-1));
            else
                return text;
        }


        public string StringZerosRefactor(string text)
        {
            return text.StartsWith("0")? StringZerosRefactor(text.Substring(1)):text;
        }
    }
}
