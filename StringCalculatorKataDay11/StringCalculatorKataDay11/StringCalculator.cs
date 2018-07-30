using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKataDay11
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (NullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var numbersWithoutNonDelimiter = RemoveNonDelimiter(numbers);
            var numberStorage = SplitNumbers(numbersWithoutNonDelimiter);
            var convertedNumbers = ConvertNumbers(numberStorage);
            var negativeNumbers = convertedNumbers.Where(x => x < 0);
            var joinedNegativeNumbers = string.Join(" ", negativeNumbers);
            CheckForNegativeNumbers(negativeNumbers, joinedNegativeNumbers);
            var sum = GetSum(convertedNumbers);

            return sum;
        }

        private void CheckForNegativeNumbers(IEnumerable<int> negativeNumbers, string joinedNegativeNumbers)
        {
            if (negativeNumbers.Any())
            {
                throw new Exception($"Negatives Not Allowed {joinedNegativeNumbers}");
            }
        }

        private int GetSum(int[] convertedNumbers)
        {
            return convertedNumbers.Where(x => x <= 1000).Sum(x => x);
        }

        private int[] ConvertNumbers(string[] numberStorage)
        {
            return numberStorage.Select(x => int.Parse(x)).ToArray();
        }

        private string[] SplitNumbers(string removedDelimiter)
        {
            return removedDelimiter.Split(new char[] { ',', '\n', '/', ';', '*', '%' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private string RemoveNonDelimiter(string numbers)
        {
            return numbers.Replace("[", string.Empty)
                          .Replace("]", string.Empty);
        }

        private bool NullOrWhiteSpace(string numbers)
        {
            return string.IsNullOrWhiteSpace(numbers);
        }
    }
}
