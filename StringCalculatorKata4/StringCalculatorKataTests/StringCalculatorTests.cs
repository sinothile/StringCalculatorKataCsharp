using NUnit.Framework;
using StringCalculatorKata4;
using System;

namespace StringCalculatorKataTests
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
            int expected = 0;
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

        [TestCase("1,2", 3)]
        [TestCase("2,5,2", 9)]
        [TestCase("3,4,5,5", 17)]
        public void Add_GivenMultipleNumbers_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("1\n4,5", 10)]
        [TestCase("1\n2,3,1,1,1,1,1", 11)]
        public void Add_GivenMultipleNumbersWithNewLineInBetween_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//;\n1;2;4;1;1;1", 10)]
        [TestCase("//;\n1;2,5", 8)]
        public void Add_GivenMultipleNumbersWithDifferentDelimiters_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n-4,-5")]
        public void Add_GivenNegativeNumbers_ShouldReturnNegativesNotAllowedWithThoseNegativeNumbers(string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var expected = Assert.Throws<Exception>(() => sut.Add(numbers));

            //Assert
            Assert.AreEqual("Negatives Not Allowed -4 -5", expected.Message);
        }

        [TestCase("1\n1000,5", 1006)]
        [TestCase("1\n999,5", 1005)]
        [TestCase("1\n1001,5", 6)]
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
        [TestCase("//[**********]\n2**********2**********1", 5)]
        [TestCase("//[**********************]\n5****************5*****************5", 15)]
        public void Add_GivenMultipleNumbersWithBracketsAroundDifferentDelimiters_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[***][%%%]\n4***4%%%5", 13)]
        [TestCase("//[******][%%%%%%]\n5*2%%%%%%5", 12)]
        public void Add_GivenMultipleNumbersWithTwoBracketsAroundDifferentDelimiters_ShouldReturnTheirSum(string numbers, int expected)
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
