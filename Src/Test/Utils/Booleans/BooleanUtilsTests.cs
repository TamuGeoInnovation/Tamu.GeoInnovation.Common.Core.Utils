using NUnit.Framework;

namespace USC.GISResearchLab.Common.Core.Utils.Booleans.Tests
{
    [TestFixture()]
    public class BooleanUtilsTests
    {
        [Test]
        [TestCase("1")]
        [TestCase("true")]
        [TestCase("True")]
        [TestCase("TRUE")]
        [TestCase("0")]
        [TestCase("false")]
        [TestCase("False")]
        [TestCase("FALSE")]
        public void IsBooleanTest_ReturnTrue(string value)
        {
            var result = BooleanUtils.IsBoolean(value);
            Assert.IsTrue(result, $"{value} should be true");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("_")]
        [TestCase("st")]
        public void IsBooleanTest_ReturnFalse(string value)
        {
            var result = BooleanUtils.IsBoolean(value);
            Assert.IsFalse(result, $"{value} should be true");
        }
    }
}