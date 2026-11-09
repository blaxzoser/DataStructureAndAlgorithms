using NUnit.Framework;
using TrainingAlgorithms.algorithms.hard;

namespace TestTrainingAlgorithms.algorithms.hard
{
    public class EmailGeneratorTest
    {
        EmailGenerator generator;

        [SetUp]
        public void Setup()
        {
            generator = new EmailGenerator();
        }

        [TestCase("Luis Pintado", "example",
            "Luis Pintado <lPintado@example.com>")]
        [TestCase("Luis Pintado, Laura Pintado, Lucas Pintado", "example",
            "Luis Pintado <lPintado@example.com>, Laura Pintado <lPintado2@example.com>, Lucas Pintado <lPintado3@example.com>")]
        [TestCase("Luis Pintado, John Doe, Lina Pintado, Jane Doe", "example",
            "Luis Pintado <lPintado@example.com>, John Doe <jDoe@example.com>, Lina Pintado <lPintado2@example.com>, Jane Doe <jDoe2@example.com>")]
        [TestCase("Peter Benjamin Parker", "Marvel",
            "Peter Benjamin Parker <pParker@marvel.com>")]
        [TestCase("Peter Benjamin Parker, Peter Parker", "Marvel",
            "Peter Benjamin Parker <pParker@marvel.com>, Peter Parker <pParker2@marvel.com>")]
        [TestCase("Shaquille O'Neal, Ana Garcia-Lopez", "NBA",
            "Shaquille O'Neal <sONeal@nba.com>, Ana Garcia-Lopez <aGarciaLopez@nba.com>")]
        [TestCase("Peter Parker-Hot", "Marvel",
            "Peter Parker-Hot <pParkerHot@marvel.com>")]
        [TestCase("Ana Silva, ana silva", "x",
            "Ana Silva <aSilva@x.com>, ana silva <asilva2@x.com>")]
        [TestCase("Cher, Carl Her", "music",
            "Cher <cher@music.com>, Carl Her <cHer2@music.com>")]
        [TestCase("Luis Pintado, Cher", "example",
            "Luis Pintado <lPintado@example.com>, Cher <cher@example.com>")]
        [TestCase("John Doe", "Acme Corp",
            "John Doe <jDoe@acmecorp.com>")]
        [TestCase("  Luis   Pintado ,, Laura Pintado,", "example",
            "Luis Pintado <lPintado@example.com>, Laura Pintado <lPintado2@example.com>")]
        [TestCase(", ,  ", "example", "")]
        [TestCase("", "example", "")]
        public void ShouldGenerateEmails(string names, string company, string output)
        {
            Assert.AreEqual(output, generator.Generate(names, company));
        }

        [Test]
        public void ShouldReturnEmptyWhenNamesIsNull()
        {
            Assert.AreEqual("", generator.Generate(null, "example"));
        }
    }
}
