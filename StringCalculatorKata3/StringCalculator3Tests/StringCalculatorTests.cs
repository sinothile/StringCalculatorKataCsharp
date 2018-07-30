using NUnit.Framework;
using StringCalculatorKata3;
using System;

namespace StringCalculator3Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenEmptyNumber_ShouldReturn0(string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
        [TestCase("1",1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        public void Add_GivenASingleNumber_ShouldReturnThatNumber(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("3,3", 6)]
        [TestCase("3,3,5", 11)]
        [TestCase("1,3,5", 9)]
        public void Add_GivenMultipleNumbersSeparatedByAComma_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("1\n2,3,1,1", 8)]
        public void Add_GivenMultipleNumbersSeparatedByACommaAndNewLine_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        public void Add_GivenMultipleNumbersSeparatedByDifferentDelimitersAndNewLine_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNegativeNumbers_ShouldReturnNegativesNotAllowedAndNumbersThatAreNegative()
        {
            //Arrange
            var sut = new StringCalculator();
            var numbers = "1\n-2,-3";

            //Act
            var expected = Assert.Throws<Exception> (() => sut.Add(numbers));

            //Assert
            Assert.AreEqual(" Negatives Not Allowed -2 -3", expected.Message);
        }

        [TestCase("1\n1000,3", 1004)]
        [TestCase("1\n1001,3", 4)]
        public void Add_GivenNumbersGreaterThan1000_ShouldBeIgnored(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
