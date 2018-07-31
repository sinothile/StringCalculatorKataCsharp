using NUnit.Framework;
using StringCalculatorDay12;
using System;

namespace StringCalculatorDay12Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenAStringWithEmptyOrNullOrWhitespace_ShouldReturn0(string number)
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
        [TestCase("2",2)]
        [TestCase("100",100)]
        public void Add_GivenASingleNumber_ShouldReturnThatNumber(string number, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(number);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,3", 4)]
        [TestCase("2,7,1", 10)]
        [TestCase("100,100,100,50", 350)]
        public void Add_GivenMultipleNumbersSeparatedByAComma_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3",6)]
        [TestCase("10\n20,30",60)]
        public void Add_GivenMultipleNumbersSeparatedByACommaAndNewLineInBetween_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//;\n10;20;80", 110)]
        public void Add_GivenMultipleNumbersSeparatedByDifferentDelimiters_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNegativeNumbers_ShouldReturnNegativesNotAllowedAndThoseNegativeNumbers()
        {
            //Arrange
            var numbers = "//;\n-1;-2;6;9";

            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(numbers));

            //Assert
            var expected = "Negatives are Not Allowed -1 -2";
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("//;\n1000;2", 1002)]
        [TestCase("//;\n999,1", 1000)]
        [TestCase("//;\n1001,1", 1)]
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
        [TestCase("//[**********]\n10*********20********30",60)]
        [TestCase("//[*******************]\n50***50***50",150)]
        public void Add_GivenMultipleNumbersSeparatedByADelimiterInBrackets_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[***][%%%]\n10***20%%%30", 60)]
        [TestCase("//[***********][%%%%%%%%%%%]\n50**********200%%%%%%%%%%%%300", 550)]
        public void Add_GivenMultipleNumbersSeparatedByDifferentDelimitersInBrackets_ShouldReturnTheirSum(string numbers, int expected)
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
