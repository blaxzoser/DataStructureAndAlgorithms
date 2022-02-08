using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.questions.arraysAndStrings
{
    public class UniqueCharacters
    {
        public bool IsUnique(string text)
        {
            for(int i = 0; i< text.Length -1;i++)
            {
                for (int y = text.Length-1;y > i; y--)
                {
                    if (text[i] == text[y])
                        return !true;
                }
            }
            return true;
        }


        public bool IsUniqueRefactor(string text)
        {
            const int ASCII = 128;
            if (text.Length > ASCII) return false;

            bool[] charSet = new bool[ASCII];
            for(int i=0; i < text.Length; i++) 
            {
                var value = text.IndexOf(text[i]);
                if (charSet[value] == true) 
                {
                    return false;
                }
                else
                {
                    charSet[value] = true;
                }
            }
            return true;
        }
    }
}
