using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata4
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }
            numbers = RemoveUnnecessaryCharacters(numbers);
            string[] numberArray = SplitNumbers(numbers);
            var negativeNumbers = numberArray.Where(x => int.Parse(x) < 0);
            CheckNegativeNumbers(negativeNumbers);
            var sum = numberArray.Where(x => int.Parse(x) <= 1000).Sum(x => int.Parse(x));
            return sum;
        }

        private static void CheckNegativeNumbers(IEnumerable<string> negativeNumbers)
        {
            if (negativeNumbers.Any())
            {
                throw new Exception($"Negatives Not Allowed {string.Join(" ", negativeNumbers)}");
            }
        }
        private static string[] SplitNumbers(string numbers)
        {
            return numbers.Split(new char[] { ',', '\n', ';','*','%' }, StringSplitOptions.RemoveEmptyEntries);
        }
        private static string RemoveUnnecessaryCharacters(string numbers)
        {
            return numbers.Replace("//", string.Empty).Replace("[",string.Empty).Replace("]",string.Empty);
        }
    }
}
