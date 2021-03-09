using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.questions.arraysAndStrings
{
    public class PermutationDetector
    {
        public bool IsPermutation(string text,string perm) 
        {
            if (text.Length != perm.Length) return false;
            return BubbleSort(text) == BubbleSort(perm);

        }

        public bool IsPermutationRefactor(string text, string perm)
        {
            if (text.Length != perm.Length) return false;
            return Sort(text).Equals(Sort(perm));
        }

        public string Sort(string s) 
        {
            var content = s.ToCharArray();
            Array.Sort(content);
            return new string(content);
        }

        public string BubbleSort(string text)
        {
            var elements = text.ToCharArray();
            for(int i = 0; i < text.Length; i++) 
            {
                for(int y = 0; y < text.Length - i - 1; y++) 
                { 
                   if(elements[y] > elements[y + 1])
                   {
                        var temp = elements[y];
                        elements[y] = elements[y+1];
                        elements[y+1] = temp;
                   }
                }            
            }

            return  new string(elements);
        }
    }
}
