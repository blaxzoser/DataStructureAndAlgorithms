using System.Text;

namespace Samples.questions.arraysAndStrings
{
    public class Compressor
    {
        public static string Compress(string text)
        {
            var transformation = new StringBuilder();
            int count = 0;
            for(int i = 0; i < text.Length; i++)
            {
                count++;
                //If next char different , append this result
                if(text.Length <= 1 + i || text[i] != text[i + 1] )
                {
                    transformation.Append(text[i]);
                    transformation.Append(count);
                    count = 0;              
                }
            }
            return transformation.ToString();
        }
    }
}
