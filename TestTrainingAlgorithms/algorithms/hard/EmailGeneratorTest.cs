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

        [TestCase("Peter Benjamin Parker", "Marvel",
            "Peter Benjamin Parker <pbParker@marvel.com>")]
        [TestCase("Ana Maria Luisa Silva", "x",
            "Ana Maria Luisa Silva <amlSilva@x.com>")]
        [TestCase("Peter Benjamin Parker, Peter Parker", "Marvel",
            "Peter Benjamin Parker <pbParker@marvel.com>, Peter Parker <pParker@marvel.com>")]
        [TestCase("Paul Brian Parker, Peter Benjamin Parker", "Marvel",
            "Paul Brian Parker <pbParker@marvel.com>, Peter Benjamin Parker <pbParker2@marvel.com>")]
        [TestCase("Luis Pintado, Cher", "example",
            "Luis Pintado <lPintado@example.com>, Cher <cher@example.com>")]
        [TestCase("  Ana   Maria  Garcia-Lopez ", "NBA",
            "Ana Maria Garcia-Lopez <amGarciaLopez@nba.com>")]
        public void ShouldGenerateEmailsWithMiddleNames(string names, string company, string output)
        {
            Assert.AreEqual(output, generator.Generate(names, company, includeMiddleNames: true));
        }

        [TestCase("Peter Parker-Hot", "Marvel",
            "Peter Parker-Hot <pParker@marvel.com>")]
        [TestCase("Ana Garcia-Lopez", "NBA",
            "Ana Garcia-Lopez <aGarcia@nba.com>")]
        [TestCase("Shaquille O'Neal-Smith", "NBA",
            "Shaquille O'Neal-Smith <sONeal@nba.com>")]
        [TestCase("Peter Parker-Hot, Paul Parker", "Marvel",
            "Peter Parker-Hot <pParker@marvel.com>, Paul Parker <pParker2@marvel.com>")]
        [TestCase("Luis Pintado, Cher", "example",
            "Luis Pintado <lPintado@example.com>, Cher <cher@example.com>")]
        public void ShouldGenerateEmailsWithOnlyFirstPartOfLastName(string names, string company, string output)
        {
            Assert.AreEqual(output, generator.Generate(names, company, onlyFirstPartOfLastName: true));
        }

        [TestCase("Peter Benjamin Parker-Hot, Paul Brian Parker", "Marvel",
            "Peter Benjamin Parker-Hot <pbParker@marvel.com>, Paul Brian Parker <pbParker2@marvel.com>")]
        [TestCase("  Ana   Maria  Garcia-Lopez ", "NBA",
            "Ana Maria Garcia-Lopez <amGarcia@nba.com>")]
        public void ShouldGenerateEmailsWithBothOptions(string names, string company, string output)
        {
            Assert.AreEqual(output, generator.Generate(names, company,
                includeMiddleNames: true, onlyFirstPartOfLastName: true));
        }

        [Test]
        public void ShouldReturnEmptyWhenNamesIsNull()
        {
            Assert.AreEqual("", generator.Generate(null, "example"));
        }
    }
}
