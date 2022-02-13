using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Samples.questions.recursive
{

    /// <summary>
    /// https://www.codewars.com/kata/54c9fcad28ec4c6e680011aa/train/csharp
    /// At a job interview, you are challenged to write an algorithm to check if a given string, s, can be formed from two other strings, part1 and part2.
    /// The restriction is that the characters in part1 and part2 should be in the same order as in s.
    /// The interviewer gives you the following example and tells you to figure out the rest from the given test cases.
    //  For example:
    // 'codewars' is a merge from 'cdw' and 'oears':
    //  s:      c o d e w a r s = codewars
    //  part1:  c   d   w         = cdw
    //  part2:    o   e   a r s   = oears
    /// </summary>
    public class StringMerger
    {
        public static bool IsMergeOldFashon(string s, string part1, string part2)
        {

            if (part2 == "" && part1 == "")
                return true;
            else if (part2.Length + part1.Length != s.Length)
                return false;

            int y = 0, x = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (part1.IndexOf(s[i]) >= 0 && part1[x] == s[i])
                {
                    x++;
                    continue;
                }
                else if (part2.IndexOf(s[i]) >= 0 && part2[y] == s[i])
                {
                    y++;
                    continue;
                }
                else
                    return false;
            }
            return true;
        }

        public static bool IsMerge(string s, string part1, string part2)
        {
            Debug.WriteLine("target: " + s);
            Debug.WriteLine("part 1: " + part1);
            Debug.WriteLine("part 2: " + part2);

            bool isEmpty1 = part1.Length == 0,
                 isEmpty2 = part2.Length == 0,
                 works1 = false,
                 works2 = false;

            if (s.Length == 0)
            {
                if (part1.Length == 0 && part2.Length == 0) return true;
                return false;
            }
            else
            {
                if (!isEmpty1 && s[0] == part1[0])
                {
                    works1 = IsMerge(s.Substring(1), part1.Substring(1), part2);
                }
                if (!isEmpty2 && s[0] == part2[0])
                {
                    works2 = IsMerge(s.Substring(1), part1, part2.Substring(1));
                }
                return works1 || works2;
            }
        }


        // Things to learn ... a recursive with substring is the key
        public static string ForRecursive(string value)
        {
            Debug.WriteLine("Print: " + value);
            if (value.Length == 0)
                return string.Empty;
            else
                ForRecursive(value.Substring(1));

            return string.Empty;
        }




    }
}
