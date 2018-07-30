using NUnit.Framework;
using StringCalculatorKataDay11;
using System;

namespace StringCalculatorKataDay11Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenANumberWithEmptyOrNullOrWhiteSpace_ShouldReturn0(string numbers)
        {
            //Arrange
            StringCalculator sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        public void Add_GivenASingleNumber_ShouldReturnThatNumber(string numbers, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("2,4,4", 10)]
        [TestCase("5,5,5,5", 20)]
        public void Add_GivenMultipleNumbersSeparatedByComma_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("1\n5,5,5", 16)]
        [TestCase("10\n15,5", 30)]
        public void Add_GivenMultipleNumbersSeparatedByCommaAndNewLineInBetween_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//;\n10;20;30", 60)]
        [TestCase("//;\n90;20,10,10", 130)]
        public void Add_GivenMultipleNumbersSeparatedByDifferentDelimitersAndNewLineInBetween_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNegativeNumbers_ShouldReturnNegativesNotAllowedAndThoseNegativeNumbers()
        {
            //Arrange
            var numbers = "//;\n-1;-2;5;-5";
            var sut = CreateStringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(numbers));

            //Assert
            var expected = "Negatives Not Allowed -1 -2 -5";
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("1\n1000,3", 1004)]
        [TestCase("1\n999,3", 1003)]
        [TestCase("10\n1001,5", 15)]
        public void Add_GivenNumbersGreaterThan1000_ShouldIgnoreThem(string numbers, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[******************]\n10***********************20************************30", 60)]
        [TestCase("//[*******************************]\n15*******************************************15************************30", 60)]
        public void Add_GivenMultipleNumbersSeparatedByADelimiterInBrackets_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[***********][%%%%%%%%%]\n10********20%%%%%%%%%30", 60)]
        [TestCase("//[*****%%%%%%******%%%%%%%***][%%%******%%%%%%%%******%%%%]\n100********%%%%%%%***200%%%%%%%%*********300", 600)]
        public void Add_GivenMultipleNumbersSeparatedByDifferentDelimitersInBrackets_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
