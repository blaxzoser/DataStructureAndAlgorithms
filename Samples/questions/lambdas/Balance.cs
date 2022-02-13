using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.questions.lambdas
{
    public class Balance
    {
        public static bool IsBalance(string text)
        {
            Stack<char> lastOpen = new Stack<char>();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '{')
                {
                    lastOpen.Push(text[i]);
                    continue;
                }
                else if (text[i] == '[')
                {
                    lastOpen.Push(text[i]);
                    continue;
                }
                else if (text[i] == '(')
                {
                    lastOpen.Push(text[i]);
                    continue;
                }
                else if (text[i] == ')')
                {
                    if (lastOpen.Count == 0 || lastOpen.Pop() != '(')
                        return false;
                    continue;
                }
                else if (text[i] == ']')
                {
                    if (lastOpen.Count == 0 || lastOpen.Pop() != '[')
                        return false;
                    continue;
                }
                else if (text[i] == '}')
                {
                    if (lastOpen.Count == 0 || lastOpen.Pop() != '{')
                        return false;
                    continue;
                }
            }

            if (lastOpen.Count == 0) return true;
            else return false;

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
