using NUnit.Framework;
using StringCalculator;
using System;

namespace StringCalculatorTests
{
    [TestFixture]
    public class StringCalculatorTest
    {
      [TestCase("")]
      [TestCase(" ")]
      [TestCase(null)]
      public void Add_GivenAnEmptyNumber_ShouldReturn0(string numbers)
        {
            //arrange
            var sut = new StringCalculatorService();

            //act
            var actual = sut.Add(numbers);

            //assert
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1",1)]
        [TestCase("2",2)]
        [TestCase("3",3)]
        public void Add_GivenASingleNumber_ShouldReturnThatNumber(string numbers, int expected)
        {
            //arrange
            var sut = new StringCalculatorService();

            //act
            var actual = sut.Add(numbers);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("3,3", 6)]
        [TestCase("2,1,3,3", 9)]
        [TestCase("5,5,5,5", 20)]
        public void Add_GivenMultipleNumbers_ShouldReturnTheirSum(string numbers, int expected)
        {
            //arrange
            var sut = new StringCalculatorService();

            //act
            var actual = sut.Add(numbers);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("1\n2,3,1,2", 9)]
        [TestCase("1\n9,10,1", 21)]
        public void Add_GivenMultipleNumbersWithANewLineInBetween_ShouldReturnTheirSum(string numbers, int expected)
        {
            //arrange
            var sut = new StringCalculatorService();

            //act
            var actual = sut.Add(numbers);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//;\n5;5", 10)]
        [TestCase("//;\n2;2;4;4", 12)]
        public void Add_GivenMultipleNumbersWithDifferentDelimeters_ShouldReturnTheirSum(string numbers, int expected)
        {
            //arrange
            var sut = new StringCalculatorService();

            //act
            var actual = sut.Add(numbers);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n-9,-10,-1")]
        public void Add_GivenNegativeNumbers_ShouldReturnNegativesNotAllowedWithNegativeNumbers(string numbers)
        {
            //arrange
            var sut = new StringCalculatorService();

            //act
            var expected = Assert.Throws <Exception> (() => sut.Add(numbers));

            //assert
            Assert.AreEqual("Negatives Not Allowed -9 -10 -1", expected.Message);
        }

        [TestCase("1\n1000,1", 1002)]
        [TestCase("1\n1001,1", 2)]
        [TestCase("1\n999,1", 1001)]
        public void Add_GivenNumbersGreaterThan1000_ShouldIgnoreThem(string numbers, int expected)
        {
            //arrange
            var sut = new StringCalculatorService();

            //act
            var actual = sut.Add(numbers);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[******]\n4******4******4", 12)]
        [TestCase("//[**********]\n5**********5**********3", 13)]
        public void Add_GivenMultipleNumbersWithDifferentDelimetersOfAnyLength_ShouldReturnTheirSum(string numbers, int expected)
        {
            //arrange
            var sut = new StringCalculatorService();

            //act
            var actual = sut.Add(numbers);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[***][%%%]\n1*2%3%1%1*1", 9)]
        [TestCase("//[**********][%%%%%%%%%%]\n5*9%1", 15)]
        public void Add_GivenMultipleNumbersWithBracketsAroundDelimeters_ShouldReturnTheirSum(string numbers, int expected)
        {
            //arrange
            var sut = new StringCalculatorService();

            //act
            var actual = sut.Add(numbers);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
