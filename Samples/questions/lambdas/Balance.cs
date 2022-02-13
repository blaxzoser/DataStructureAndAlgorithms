using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.questions.lambdas
{
    public class Balance
    {
        public bool IsBalance(string text)
        {
            return true;
        }


        public static bool Read(string text,int index,char previous)
        {
            if (text[index] == text.Length - 1)
                return true;

            if (text[index] == '{' || text[index] == '[' || text[index] == '(' || text[index] == previous)
            {
                Read(text.Substring(index + 1), index++, text[index]);
            }
            else
                return false;

            return false;
        }
    }
}
