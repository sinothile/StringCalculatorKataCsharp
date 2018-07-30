using NUnit.Framework;
using StringCalculatorKataDay7;
using System;

namespace StringCalculatorKataDay7Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenAnEmptyOrNullNumber_ShouldReturn0(string numbers)
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
        [TestCase("2",2)]
        [TestCase("3",3)]
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
        [TestCase("10,10,10", 30)]
        [TestCase("100,50,200,10", 360)]
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
        [TestCase("10\n20,30,10,10,10,10",100)]
        [TestCase("50\n50,50,50,50,50,50,50,50",450)]
        public void Add_GivenMultipleNumbersSeparatedByACommaAndNewLineInBetween_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2",3)]
        [TestCase("//;\n80;20,10",110)]
        [TestCase("//;\n50;20,20,10,10,20",130)]
        public void Add_GivenMultipleNumbersSeparatedByDifferentDelimitersAndNewLineInBetween_ShouldReturnTheirSum(string numbers, int expected)
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
            var numbers = "//;\n-1;-2;5";
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(numbers));

            //Assert
            var expected = "Negatives Not Allowed -1 -2";
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("50,1000,10", 1060)]
        [TestCase("50,999,10", 1059)]
        [TestCase("50,1001,10", 60)]
        public void Add_GivenNumbersGreaterThan1000_ShouldIgnoreThem(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[***************]\n10***************10*****************3", 23)]
        [TestCase("//[*****************************************]\n1000*****************************20*******************************30", 1050)]
        public void Add_GivenMultipleNumbersSeparatedByDelimiterInBrackets_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[*][%]\n1*2%3",6)]
        [TestCase("//[***************][%%%%%%%%%%%%%%%%%]\n10************************20%%%%%%%%%%%%%%%%%%%%%%30",60)]
        [TestCase("//[***%%%***%%%][%%%***%%%***]\n90***%%%***%%%10%%%***%%%***30",130)]
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
