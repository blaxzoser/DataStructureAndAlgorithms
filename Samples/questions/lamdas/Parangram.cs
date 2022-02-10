using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples.questions.arraysAndStrings
{

    // https://www.codewars.com/kata/545cedaa9943f7fe7b000048/csharp
    //    A pangram is a sentence that contains every single letter of the alphabet at least once.For example, the sentence "The quick brown fox jumps over the lazy dog" is a pangram, because it uses the letters A-Z at least once(case is irrelevant).
    //   Given a string, detect whether or not it is a pangram.Return True if it is, False if not.Ignore numbers and punctuation.
    public class Parangram
    {
        public static bool IsParangramLamdas(string text)
        {
            return text
                .ToLower()
                .Where(character => Char.IsLetter(character))
                .Distinct()
                .Count() == 26;
        }

        public static bool IsPangram(string str)
        {
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            for (int i = 0; i < letters.Length; i++)
            {
                if (!str.ToLower().Contains(letters[i]))
                    return false;
            }
            return true;
        }

    }
}
