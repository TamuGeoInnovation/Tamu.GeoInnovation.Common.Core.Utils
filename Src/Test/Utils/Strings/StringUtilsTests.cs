using NUnit.Framework;

namespace USC.GISResearchLab.Common.Utils.Strings.Tests
{
    [TestFixture()]
    public class StringUtilsTests
    {

        [Test]
        [TestCase("1st")]
        [TestCase("2st")]
        [TestCase("10st")]
        [TestCase("100st")]
        public void IsSomeFormOfNumericValueTest_ReturnTrue(string value)
        {
            var result = StringUtils.StartsWithNumber(value);
            Assert.IsTrue(result, $"{value} should be true");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("_")]
        [TestCase("st")]
        public void IsSomeFormOfNumericValueTest_ReturnFalse(string value)
        {
            var result = StringUtils.StartsWithNumber(value);
            Assert.IsFalse(result, $"{value} should be true");
        }
    }
}
