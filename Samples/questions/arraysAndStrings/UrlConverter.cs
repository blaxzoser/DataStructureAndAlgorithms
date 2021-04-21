using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.questions.arraysAndStrings
{
    public class UrlConverter
    {
        public static string Urlify(string text,int size)
        {
            var stringWithSpaces =  text.ToCharArray();
            StringBuilder newformat = new StringBuilder();
            int counter = 0, index = 0;
            while(counter < size)
            {
                if (stringWithSpaces[index].ToString() == " ")
                {
                    newformat.Append("%20");
                    counter += 3;
                }
                else
                {
                    newformat.Append(stringWithSpaces[index]);
                    counter += 1;
                }
                index++;
            }
                
            return newformat.ToString();
        }

        public static string UrlifyRefactor(string text, int size)
        {
            var result = new char[size];
            
            text = text.Trim();

            var urlChars = text.ToCharArray();

            var pointer = 0;
            for(int i=0;i<urlChars.Length; i++)
            {
                if(urlChars[i] != ' ')
                {
                    result[pointer] = urlChars[i];
                    pointer++;
                }
                else
                {
                    result[pointer] = '%';
                    result[pointer+1] = '2';
                    result[pointer+2] = '0';
                    pointer = pointer + 3;
                }
            }
            return String.Join("",result);
        }
    }
}
