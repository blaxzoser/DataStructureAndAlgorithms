using NUnit.Framework;
using Samples.questions.arraysAndStrings;

namespace Test
{

    public class OtherTest
    {

        [Test]
        public void TestParangram()
        {
            Assert.AreEqual(true, Parangram.IsPangram("The quick brown fox jumps over the lazy dog."));
        }

        [Test]
        public void TestParangramWithLambdas()
        {
            Assert.AreEqual(true, Parangram.IsParangramLamdas("The quick brown fox jumps over the lazy dog."));
        }
    }
}
