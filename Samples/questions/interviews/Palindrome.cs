using System.Diagnostics;

namespace Samples.questions.interviews
{
    public class Palindrome
    {
        public static bool IsPalindromeDetector(string text)
        {
            string reverse = "";
            for(int i = text.Length-1; 0 <= i; i--)
            {
                reverse += text[i];
            }
            return reverse == text;
        }

        public static bool IsPalindromeRefactor(string text)
        {
            char[] characters = text.ToCharArray();
            int length = text.Length;

            for (int i = 0; i < characters.Length/2; i++)
            {
                Debug.WriteLine(characters[i]);
                Debug.WriteLine(characters[length - i - 1]);
                if (characters[i] != characters[length -i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}