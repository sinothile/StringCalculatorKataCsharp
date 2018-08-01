using NUnit.Framework;
using StringCalculatorDay13;
using System;

namespace StringCalculatorDay13Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenAStringWithEmptyOrNullOrWhiteSpace_ShouldReturn0(string number)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(number);

            //Assert
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1",1)]
        [TestCase("5",5)]
        public void Add_GivenASingleNumber_ShouldReturnThatNumber(string number, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(number);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("5,5", 10)]
        [TestCase("10,5,6", 21)]
        public void Add_GivenMultipleNumbersSeparatedByComma_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("10\n20,30", 60)]
        [TestCase("100\n100,3", 203)]
        public void Add_GivenMultipleNumbersSeparatedByCommaAndNewLineInBetween_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//;\n10;20;50;10;10", 100)]
        public void Add_GivenMultipleNumbersSeparatedByDifferentDelimeters_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n-10;20", "Negatives Not Allowed -10")]
        [TestCase("1\n-2,-3", "Negatives Not Allowed -2 -3")]
        [TestCase("10,-5,6", "Negatives Not Allowed -5")]
        public void Add_GivenNegativeNumbers_ShouldReturnNegativesNotAllowedAndThoseNegativeNumbers(string numbers, string expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(numbers));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("//;\n1000;3;3", 1006)]
        [TestCase("//;\n999;3;3", 1005)]
        [TestCase("//;\n1001;3;3", 6)]
        public void Add_GivenNumbersGreaterThan1000_ShouldIgnoreThem(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[***]\n1***2***3",6)]
        [TestCase("//[*********]\n1**********2**********3",6)]
        [TestCase("//[**************]\n10***********20*************30***********40************100",200)]
        public void Add_GivenMultipleNumbersSeparatedByDelimeterInBrackets_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[*][%]\n1*2%3",6)]
        [TestCase("//[*****][%%%%]\n10*****20%%%%%30",60)]
        [TestCase("//[***%%**%%][%%%**%%**]\n1***%%**%%2%%%**%%**3**%%**%%5**%%10",21)]
        public void Add_GivenMultipleNumbersSeparatedByDifferentDelimetersInBrackets_ShouldReturnTheirSum(string numbers, int expected)
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
