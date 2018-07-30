using NUnit.Framework;
using StringCalculatorDay5;
using System;

namespace StringCalculatorDay5Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase(" ")]
        [TestCase("")]
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
        [TestCase("1,3,2,1", 7)]
        [TestCase("5,5,5,5,5,5,5", 35)]
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
        [TestCase("1\n5,5", 11)]
        [TestCase("1\n4,4", 9)]
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
        [TestCase("//;\n5;5", 10)]
        [TestCase("//;\n9;10", 19)]
        public void Add_GivenMultipleNumbersSeparatedByDifferentDelimetersAndNewLineInBetween_ShouldReturnTheirSum(string numbers, int expected)
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
            var sut = new StringCalculator();
            var numbers = "1\n-2,-3";

            //Act
            var expected = Assert.Throws<Exception>(() => sut.Add(numbers));

            //Assert
            Assert.AreEqual("Negatives Not Allowed -2 -3", expected.Message);
        }

        [TestCase("1\n1000,3", 1004)]
        [TestCase("1\n999,5", 1005)]
        [TestCase("1\n1001,4", 5)]
        public void Add_GivenNumbersThatAreGreaterThan1000_ShouldIgnoreThem(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[**********]\n5**********10*********5", 20)]
        [TestCase("//[*********************]\n10******************20****************30", 60)]
        public void Add_GivenMultipleNumbersSeparatedByADelimiterInABracket_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[***][%%%]\n10*%%**10%*%%10", 30)]
        [TestCase("//[*%*%][%%%]\n20*%%20%**30", 70)]

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
