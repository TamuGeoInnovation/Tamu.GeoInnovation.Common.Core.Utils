using NUnit.Framework;
using USC.GISResearchLab.Common.Core.Maths.NumericStrings;

namespace Tamu.GeoInnovation.Common.Core.Maths.NumericStrings.Test
{
    [TestFixture]
    public class UnitTestNumericStrings
    {
        private NumericStringManager _numericStringManager;
        [SetUp]
        public void Setup()
        {
            _numericStringManager = new NumericStringManager();
        }

        [Test]
        [TestCase("-1")]
        [TestCase("0")]
        [TestCase("zero")]
        [TestCase("1")]
        [TestCase("one")]
        [TestCase("first")]
        [TestCase("2")]
        [TestCase("two")]
        [TestCase("second")]
        [TestCase("3")]
        [TestCase("three")]
        [TestCase("third")]
        [TestCase("4")]
        [TestCase("four")]
        [TestCase("fourth")]
        [TestCase("5")]
        [TestCase("five")]
        [TestCase("fifth")]
        [TestCase("10")]
        [TestCase("ten")]
        [TestCase("tenth")]
        [TestCase("11")]
        [TestCase("eleven")]
        [TestCase("eleventh")]
        public void IsSomeFormOfNumericValue_ReturnTrue(string value)
        {
            var result = _numericStringManager.IsSomeFormOfNumericValue(value);
            Assert.IsTrue(result, $"{value} should be true");
        }



        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("asdf")]
        public void IsSomeFormOfNumericValue_ReturnFalse(string value)
        {
            var result = _numericStringManager.IsSomeFormOfNumericValue(value);
            Assert.IsFalse(result, $"{value} should be false");
        }
    }
}