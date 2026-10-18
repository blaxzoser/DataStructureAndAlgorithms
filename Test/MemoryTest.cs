using NUnit.Framework;
using Samples.memory;

namespace Test
{
    public class MemoryTest
    {
        ValuesTypeVsReferenceType valuesTypeVsReferenceType;

        [SetUp]
        public void Setup()
        {
            valuesTypeVsReferenceType = new ValuesTypeVsReferenceType();
        }


        #region Reference Type

        [Test]
        public void ValuesTypeVsReferenceType_SampleEqualsOnString()
        {
            var result = valuesTypeVsReferenceType.SampleEqualsOnString();

            Assert.That(result.isValueEquals, Is.True);
            Assert.That(result.isReferenceEquals, Is.True);
        }

        [Test]
        public void ValuesTypeVsReferenceType_SampleImmutableOnString()
        {
            var result = valuesTypeVsReferenceType.SampleImmutableOnString();

            Assert.That(result.isActualValue, Is.True);
            Assert.That(result.isOriginalValue, Is.False);
        }

        #endregion


        #region Value Type

        [Test]
        public void ValuesTypeVsReferenceType_SampleEqualsOnInt()
        {
            var result = valuesTypeVsReferenceType.SampleEqualsOnInt();

            Assert.That(result.isValue, Is.True);
            Assert.That(result.isReference, Is.False);
        }

        #endregion
    }
}
