using NUnit.Framework;
using StringCalculatorKataDay6;
using System;

namespace StringCalculatorKataTestsDay6
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

        [TestCase("3,2", 5)]
        [TestCase("3,2,1,5", 11)]
        [TestCase("10,10,10,10", 40)]
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
        [TestCase("1\n5,5,5", 16)]
        [TestCase("1\n10,10,10,10", 41)]
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
        [TestCase("//;\n1;2;1;1;1", 6)]
        [TestCase("//;\n8;2;10", 20)]
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
        public void Add_GivenNegativeNumbers_ShouldReturnNegativesNotAllowedAndThoseNegativeNumnber()
        {
            //Arrange
            var numbers = "//;\n-1;-2;1";
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(numbers));

            //Assert
            var expected = "Negatives Not Allowed -1 -2";
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("//;\n1000;10", 1010)]
        [TestCase("//;\n999;10", 1009)]
        [TestCase("//;\n1001;10", 10)]
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
        [TestCase("//[***********]\n2***************2**************3", 7)]
        [TestCase("//[***********************************]\n5**************************5***************************5", 15)]
        public void Add_GivenMultipleNumbersSeparatedByDifferentDelimitersAndBracketAroundDelimiter_ShouldReturnTheirSum(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[******************][%%%%%%%%%%%%%%%]\n1*2%%%%%%%%%%%%%%%%%%%%%3", 6)]
        [TestCase("//[*%%%%%%%%%*******][%**********%%%%%%%%%%%]\n1*****%%%%%%%%%2%***********3", 6)]
        public void Add_GivenMultipleNumbersSeparatedByDifferentDelimitersWithinBrackets_ShouldReturnTheirSum(string numbers, int expected)
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
