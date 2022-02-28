using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.questions.interviews
{
    /// <summary>
    ///  We need to remove 2 characters on the list and return the same e.g
    ///  Input: Luis Pintado
    ///  Output: Luis Pntado
    /// </summary>
    public class StringDuplicates
    {
        public static string RemoveDuplicates(string text)
        {
            bool[] totalAscii = new bool[128]; // The key is here too because you should know 127 characters is total with spaces,extra character and lower
            StringBuilder newText = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                int index = text[i]; //Key is here because we need to convert a string to ascii(numbers)
                if (totalAscii[index] == false)
                {
                    totalAscii[index] = true;
                    newText.Append(text[i]);
                }

            }
            return newText.ToString();
        }

    }
}
