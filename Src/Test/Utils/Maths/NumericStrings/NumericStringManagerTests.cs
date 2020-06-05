using NUnit.Framework;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;

namespace USC.GISResearchLab.Common.Core.Maths.NumericStrings.Tests
{
    [TestFixture()]
    public class NumericStringManagerTests
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
        public void IsSomeFormOfNumericValueTest_ReturnTrue(string value)
        {
            var result = _numericStringManager.IsSomeFormOfNumericValue(value);
            Assert.IsTrue(result, $"{value} should be true");
        }



        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("asdf")]
        public void IsSomeFormOfNumericValueTest_ReturnFalse(string value)
        {
            var result = _numericStringManager.IsSomeFormOfNumericValue(value);
            Assert.IsFalse(result, $"{value} should be false");
        }


        [Test()]
        [TestCase("-1", "0")]
        [TestCase("zero", "1")]
        [TestCase("one", "first")]
        [TestCase("2", "two")]
        [TestCase("second", "3")]
        [TestCase("three", "third")]
        [TestCase("4", "four")]
        [TestCase("fourth", "5")]
        [TestCase("five", "fifth")]
        [TestCase("10", "ten")]
        [TestCase("tenth", "11")]
        [TestCase("eleven", "eleventh")]
        public void AreBothSomeFormOfNumericValuesTest_ReturnTrue(string value1, string value2)
        {
            var result = _numericStringManager.AreBothSomeFormOfNumericValues(value1, value2);
            Assert.IsTrue(result, $"{value1} and {value2} should be true");
        }

        [Test()]
        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase("", null)]
        [TestCase(null, "")]
        [TestCase("asdf", "1")]
        public void AreBothSomeFormOfNumericValuesTest_ReturnFalse(string value1, string value2)
        {
            var result = _numericStringManager.AreBothSomeFormOfNumericValues(value1, value2);
            Assert.IsFalse(result, $"{value1} and {value2} should be false");
        }

        public static IEnumerable AreBothSomeFormOfNumericValuesTestData_ReturnTrue()
        {
            // path = D:\\DevSource\\Tamu\\GeoInnovation\\Common.Core.Utils\\Src\\Test\\bin\\Debug\\net48
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var directoryInfo = Directory.GetParent(Assembly.GetExecutingAssembly().Location);
            var dataFilePath = directoryInfo.Parent.Parent.Parent.FullName;
            dataFilePath = Path.Combine(dataFilePath, "TestData", "NumericStringManagerTests-AreBothSomeFormOfNumericValuesTestData_ReturnTrue.txt");

            if (File.Exists(dataFilePath))
            {
                var testData = File.ReadAllLines(dataFilePath)
                    .Select(s => s.Split(','));


                if (testData != null)
                {
                    foreach (var list in testData)
                    {
                        if (list != null && list.Length == 2)
                        {
                            yield return new TestCaseData(list[0], list[1]).Returns(true);
                        }
                    }
                }
            }
        }

        [Test, TestCaseSource("AreBothSomeFormOfNumericValuesTestData_ReturnTrue")]
        public bool AreBothSomeFormOfNumericValuesTestFromDataFile_ReturnTrue(string value1, string value2)
        {
            return _numericStringManager.AreBothSomeFormOfNumericValues(value1, value2);
        }

        public static IEnumerable AreBothSomeFormOfNumericValuesTestData_ReturnFalse()
        {
            // path = D:\\DevSource\\Tamu\\GeoInnovation\\Common.Core.Utils\\Src\\Test\\bin\\Debug\\net48
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var directoryInfo = Directory.GetParent(Assembly.GetExecutingAssembly().Location);
            var dataFilePath = directoryInfo.Parent.Parent.Parent.FullName;
            dataFilePath = Path.Combine(dataFilePath, "TestData", "NumericStringManagerTests-AreBothSomeFormOfNumericValuesTestData_ReturnFalse.txt");

            if (File.Exists(dataFilePath))
            {
                var testData = File.ReadAllLines(dataFilePath)
                    .Select(s => s.Split(','));


                if (testData != null)
                {
                    foreach (var list in testData)
                    {
                        if (list != null && list.Length == 2)
                        {
                            yield return new TestCaseData(list[0], list[1]).Returns(false);
                        }
                    }
                }
            }
        }

        [Test, TestCaseSource("AreBothSomeFormOfNumericValuesTestData_ReturnFalse")]
        public bool AreBothSomeFormOfNumericValuesTestFromDataFile_ReturnFalse(string value1, string value2)
        {
            return _numericStringManager.AreBothSomeFormOfNumericValues(value1, value2);
            //Assert.IsFalse(result, $"{value1} and {value2} should be false");
        }

        [Test()]
        [TestCase("zero", "0")]
        [TestCase("one", "1")]
        [TestCase("one", "first")]
        [TestCase("1", "first")]
        [TestCase("two", "2")]
        [TestCase("two", "second")]
        [TestCase("2", "second")]
        public void AreEquivalentNumericValuesTest_ReturnTrue(string value1, string value2)
        {
            var result = _numericStringManager.AreEquivalentNumericValues(value1, value2);
            Assert.IsTrue(result, $"{value1} and {value2} should be true");
        }

        [Test()]
        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase("", null)]
        [TestCase(null, "")]
        [TestCase("", "1")]
        [TestCase(null, "1")]
        [TestCase("1", null)]
        public void AreEquivalentNumericValuesTest_ReturnFalse(string value1, string value2)
        {
            var result = _numericStringManager.AreEquivalentNumericValues(value1, value2);
            Assert.IsFalse(result, $"{value1} and {value2} should be false");
        }

        [Test()]
        [TestCase("1st")]
        [TestCase("2nd")]
        [TestCase("3rd")]
        [TestCase("4th")]
        [TestCase("5th")]
        [TestCase("10th")]
        [TestCase("11th")]
        [TestCase("21st")]
        [TestCase("22nd")]
        [TestCase("23rd")]
        [TestCase("24th")]
        [TestCase("101st")]
        [TestCase("102nd")]
        [TestCase("103rd")]
        [TestCase("104th")]
        public void IsNumberAndNumericAbbreviationSuffixTest_ReturnTrue(string value)
        {
            var result = _numericStringManager.IsNumberAndNumericAbbreviationSuffix(value);
            Assert.IsTrue(result, $"{value} should be true");
        }

        [Test()]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("st")]
        [TestCase("nd")]
        [TestCase("rd")]
        [TestCase("th")]
        [TestCase("0st")]
        [TestCase("1nd")]
        [TestCase("1rd")]
        [TestCase("1th")]
        [TestCase("2st")]
        [TestCase("2rd")]
        [TestCase("2th")]
        [TestCase("3st")]
        [TestCase("3nd")]
        [TestCase("3th")]
        [TestCase("ast")]
        [TestCase("and")]
        [TestCase("ard")]
        [TestCase("ath")]
        [TestCase("one")]
        [TestCase("two")]
        [TestCase("three")]
        [TestCase("four")]
        [TestCase("first")]
        [TestCase("second")]
        [TestCase("third")]
        [TestCase("fourth")]
        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        [TestCase("4")]
        public void IsNumberAndNumericAbbreviationSuffixTest_ReturnFalse(string value)
        {
            var result = _numericStringManager.IsNumberAndNumericAbbreviationSuffix(value);
            Assert.IsFalse(result, $"{value} should be true");
        }

        [Test()]
        [TestCase("one", "1st")]
        [TestCase("two", "2nd")]
        [TestCase("three", "3rd")]
        [TestCase("four", "4th")]
        [TestCase("ten", "10th")]
        public void WordsToNumericAbbreviationTest_ReturnTrue(string input, string expected)
        {
            var result = _numericStringManager.WordsToNumericAbbreviation(input);
            Assert.AreEqual(expected, result.ToLower(), $"{input} should be true");
        }

        [Test()]
        [TestCase("1")]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void WordsToNumericAbbreviationTest_ReturnExcpetion(string input)
        {
            var ex = Assert.Throws<ArgumentException>(() => _numericStringManager.WordsToNumericAbbreviation(input));
            Assert.That(ex.Message, Is.EqualTo("Invalid parameter value"));
        }
    }
}