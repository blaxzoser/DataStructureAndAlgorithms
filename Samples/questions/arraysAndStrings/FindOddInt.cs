using System.Collections;
using System.Diagnostics;

namespace Samples.questions.lambdas
{
    public partial class Kata
    {
        public static int FindInt(int[] seq)
        {
            Hashtable collection = new Hashtable();
            for (int i = 0; i < seq.Length; i++)
            {
                if (collection.ContainsKey(seq[i]))
                {
                    var temp = (int)collection[seq[i]];
                    collection[seq[i]] = temp + 1;
                }
                else
                {
                    collection.Add(seq[i], 1);
                }
            }

            Debug.WriteLine(collection);
            foreach (DictionaryEntry row in collection)
            {
                var temp = (int)row.Value;
                if (temp % 2 == 1)
                    return (int)row.Key;

            }

            return 0;
        }

    }
}