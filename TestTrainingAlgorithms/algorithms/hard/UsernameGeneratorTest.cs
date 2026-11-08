using NUnit.Framework;
using TrainingAlgorithms.algorithms.hard;

namespace TestTrainingAlgorithms.algorithms.hard
{
    public class UsernameGeneratorTest
    {
        UsernameGenerator generator;

        [SetUp]
        public void Setup()
        {
            generator = new UsernameGenerator();
        }

        [TestCase(new[] { "Luis Pintado" }, new string[0],
            new[] { "luipin" })]
        [TestCase(new[] { "Luis Pintado", "Luisa Pinzon", "Luigi Pinto" }, new string[0],
            new[] { "luipin", "luipin1", "luipin2" })]
        [TestCase(new[] { "Luis Pintado", "Luisa Pinzon", "Luigi Pinto" }, new[] { "luipin", "luipin2" },
            new[] { "luipin1", "luipin3", "luipin4" })]
        [TestCase(new[] { "Ana Silva" }, new[] { "ANASIL" },
            new[] { "anasil1" })]
        [TestCase(new[] { "Al Bo", "Ed Li" }, new string[0],
            new[] { "albo", "edli" })]
        [TestCase(new[] { "Peter Benjamin Parker", "Shaquille O'Neal" }, new string[0],
            new[] { "petpar", "shaone" })]
        [TestCase(new[] { "Madonna", "Cher" }, new string[0],
            new[] { "madonn", "cher" })]
        [TestCase(new[] { "  luis   PINTADO " }, new string[0],
            new[] { "luipin" })]
        [TestCase(new[] { "Bob Smith", "Bobby Smithers", "Bo Smit" }, new[] { "bobsmi1" },
            new[] { "bobsmi", "bobsmi2", "bosmi" })]
        [TestCase(new string[0], new string[0],
            new string[0])]
        public void ShouldGenerateUsernames(string[] names, string[] taken, string[] output)
        {
            Assert.AreEqual(output, generator.Generate(names, taken));
        }

        [Test]
        public void ShouldReturnEmptyWhenNamesIsNull()
        {
            Assert.AreEqual(new string[0], generator.Generate(null, new[] { "x" }));
        }

        [Test]
        public void ShouldWorkWhenTakenIsNull()
        {
            Assert.AreEqual(new[] { "luipin", "luipin1" },
                generator.Generate(new[] { "Luis Pintado", "Luisa Pinzon" }, null));
        }
    }
}
